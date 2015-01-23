﻿#region License
/* 
 * Copyright (C) 1999-2015 John Källén.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; see the file COPYING.  If not, write to
 * the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
 */
#endregion

using Decompiler.Arch.X86;
using Decompiler.Assemblers.x86;
using Decompiler.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decompiler.UnitTests.Arch.Intel
{
    [TestFixture]
    class X86EmulatorTests
    {
        private IntelArchitecture arch;
        private X86Emulator emu;
        private LoadedImage image;

        [SetUp]
        public void Setup()
        {
            arch = new IntelArchitecture(ProcessorMode.Protected32);
        }

        private void Given_RegValue(IntelRegister reg, uint value)
        {
            emu.WriteRegister(reg, value);
        }

        private void Given_Code(Action<IntelAssembler> coder)
        {
            var asm = new IntelAssembler(arch, new Address(0x00100000), new List<EntryPoint>());
            coder(asm);
            var lr = asm.GetImage();
            this.image = lr.Image;
            emu = new X86Emulator(arch, lr.Image);
            emu.InstructionPointer = lr.Image.BaseAddress;
            emu.WriteRegister(Registers.esp, lr.Image.BaseAddress.Linear + 0x0FFC);
            emu.ExceptionRaised += delegate { throw new Exception(); };
        }

        [Test]
        public void X86Emu_Mov32()
        {
            Given_Code(m => { m.Mov(m.eax, m.ebx); });
            Given_RegValue(Registers.ebx, 4);
            emu.Run();

            Assert.AreEqual(4, emu.Registers[Registers.eax.Number]);
        }

        [Test]
        public void X86Emu_Add32()
        {
            Given_Code(m => { m.Add(m.eax, m.ebx); });

            Given_RegValue(Registers.eax, 4);
            Given_RegValue(Registers.ebx, ~4u + 1u);
            emu.Run();

            Assert.AreEqual(0, emu.Registers[Registers.eax.Number]);
            Assert.AreEqual(1 + (1 << 6), emu.Flags, "Should set carry + zero flag");
        }

        [Test]
        public void X86Emu_Add32_ov()
        {
            Given_Code(m => { m.Add(m.eax, m.ebx); });

            Given_RegValue(Registers.eax, 0x80000000u);
            Given_RegValue(Registers.ebx, 0x80000000u);
            emu.Run();

            Assert.AreEqual(0, emu.Registers[Registers.eax.Number]);
            Assert.AreEqual(1 | (1 << 6) | (1 << 11), emu.Flags, "Should set carry + z + ov");
        }

        [Test]
        public void X86Emu_Sub32_ov()
        {
            Given_Code(m => {
                m.Mov(m.eax, ~0x7FFFFFFF);
                m.Mov(m.ebx, 0x00000001);
                m.Sub(m.eax, m.ebx); 
            });

            emu.Run();

            Assert.AreEqual(0x7FFFFFFFu, emu.Registers[Registers.eax.Number]);
            Assert.AreEqual(X86Emulator.Omask, emu.Flags, "Should set ov flag");
        }

        [Test]
        public void X86Emu_Sub32_cy()
        {
            Given_Code(m =>
            {
                m.Mov(m.eax, 0);
                m.Mov(m.ebx, 4);
                m.Sub(m.eax, m.ebx);
            });

            emu.Run();

            Assert.AreEqual(0xFFFFFFFCu, emu.Registers[Registers.eax.Number]);
            Assert.AreEqual(X86Emulator.Cmask, emu.Flags, "Should set C flag");
        }

        [Test]
        public void X86Emu_ReadDirect_W32()
        {
            Given_Code(m => {
                m.Label("datablob");
                m.Dd(0x12345678);
                m.Mov(m.eax, m.MemDw("datablob")); 
            });
            emu.InstructionPointer += 4;
            emu.Run();

            Assert.AreEqual(0x12345678u, emu.Registers[Registers.eax.Number]);
        }

        [Test]
        public void X86Emu_ReadIndexed_W32()
        {
            Given_Code(m =>
            {
                m.Label("datablob");
                m.Dd(0x12345678);
                m.Mov(m.eax, m.MemDw(Registers.ebx, -0x10));
            });
            Given_RegValue(Registers.ebx, 0x00100010);
            emu.InstructionPointer += 4;
            emu.Run();

            Assert.AreEqual(0x12345678u, emu.Registers[Registers.eax.Number]);
        }

        [Test]
        public void X86Emu_Immediate_W32()
        {
            Given_Code(m =>
            {
                m.Mov(m.eax, 0x1234);
            });
            Given_RegValue(Registers.eax, 0xFFFFFFFF);
            emu.Run();

            Assert.AreEqual(0x00001234u, emu.Registers[Registers.eax.Number]);
        }

        [Test]
        public void X86Emu_Write_Byte()
        {
            Given_Code(m =>
            {
                m.Label("datablob");
                m.Dd(0x12345678);
                m.Mov(m.MemB(0x00100000), m.ah);
            });
            Given_RegValue(Registers.eax, 0x40302010);
            emu.InstructionPointer += 4;
            emu.Run();

            Assert.AreEqual(0x12345620u, image.ReadLeUInt32(0));
        }

        [Test]
        public void X86Emu_Immediate_W16()
        {
            Given_Code(m =>
            {
                m.Mov(m.ax, 0x1234);
            });
            Given_RegValue(Registers.eax, 0xFFFFFFFF);
            emu.Run();

            Assert.AreEqual(0xFFFF1234u, emu.Registers[Registers.eax.Number]);
        }

        [Test]
        public void X86Emu_Xor()
        {
            Given_Code(m => { m.Xor(m.eax, m.eax); });
            Given_RegValue(Registers.eax, 0x1);

            emu.Run();

            Assert.AreEqual(0, emu.Registers[Registers.eax.Number]);
            Assert.AreEqual(1 << 6, emu.Flags, "Expected ZF set ");
        }

        [Test]
        public void X86Emu_or()
        {
            Given_Code(m => { m.Or(m.eax, m.eax); });
            Given_RegValue(Registers.eax, 0x1);

            emu.Run();

            Assert.AreEqual(1, emu.Registers[Registers.eax.Number]);
            Assert.AreEqual(0, emu.Flags, "Expected ZF clear ");
        }

        [Test]
        public void X86Emu_halt()
        {
            Given_Code(m => {
                m.Hlt();
                m.Mov(m.eax, 42);
            });

            emu.Run();

            Assert.AreNotEqual(42u, emu.Registers[Registers.eax.Number]);
        }


        [Test]
        public void X86Emu_jz()
        {
            Given_Code(m =>
            {
                m.Sub(m.eax, m.eax);
                m.Jz("z_flag_set");
                m.Hlt();
                m.Label("z_flag_set");
                m.Mov(m.eax, 42);
            });

            emu.Run();

            Assert.AreEqual(42u, emu.Registers[Registers.eax.Number]);
        }

        [Test]
        public void X86Emu_pusha()
        {
            Given_Code(m =>
            {
                m.Pusha();
                m.Hlt();
                m.Dw(0);
                m.Dd(0); m.Dd(0); m.Dd(0); m.Dd(0); 
                m.Dd(0); m.Dd(0); m.Dd(0); m.Dd(0); 
            });
            emu.WriteRegister(Registers.esp, image.BaseAddress.Linear + 0x24u);

            emu.Run();

            Assert.AreEqual(0x00100004u, emu.Registers[Registers.esp.Number]);
        }

        [Test]
        public void X86Emu_lea()
        {
            Given_Code(m =>
            {
                m.Lea(m.eax, m.MemDw(Registers.edx, Registers.edx, 4, null));
            });
            emu.WriteRegister(Registers.edx, 4);

            emu.Run();

            Assert.AreEqual(20u, emu.Registers[Registers.eax.Number]);
        }

        [Test]
        public void X86Emu_adc()
        {
            Given_Code(m =>
            {
                m.Add(m.eax, 1);
                m.Adc(m.ebx, 0);
            });
            emu.WriteRegister(Registers.eax, 0xFFFFFFFF);
            emu.WriteRegister(Registers.ebx, 1);

            emu.Run();

            Assert.AreEqual(2u, emu.Registers[Registers.ebx.Number]);
        }

        [Test]
        public void X86Emu_inc()
        {
            Given_Code(m =>
            {
                m.Mov(m.eax, 0x7FFFFFFF);
                m.Inc(m.eax);
            });

            emu.Run();

            Assert.AreEqual(0x80000000u, emu.Registers[Registers.eax.Number]);
            Assert.IsTrue((emu.Flags & X86Emulator.Zmask) == 0);
            Assert.IsTrue((emu.Flags & X86Emulator.Omask) != 0);
        }

        [Test]
        public void X86Emu_add_signextendedImmByte()
        {
            Given_Code(m =>
            {
                m.Mov(m.esi, -0x4);
                m.Db(0x83,0xEE,0xFC);     // sub esi,-4
            });

            emu.Run();

            Assert.AreEqual(0, emu.Registers[Registers.eax.Number]);
            Assert.IsTrue((emu.Flags & X86Emulator.Zmask) != 0);
            Assert.IsTrue((emu.Flags & X86Emulator.Omask) == 0);
        }

        [Test]
        public void X86Emu_shl()
        {
            Given_Code(m =>
            {
                m.Mov(m.esi, 4);
                m.Shl(m.esi, 2);
            });

            emu.Run();

            Assert.AreEqual(16, emu.Registers[Registers.esi.Number]);
        }

        [Test]
        public void X86Emu_sub_with_adc()
        {
            Given_Code(m =>
            {
                m.Mov(m.esi, 0x0401000);
                m.Xor(m.ebx, m.ebx);
                m.Db(0x83, 0xEE, 0xFC);     // sub esi,-4
                m.Adc(m.ebx, m.ebx);
            });

            emu.Run();

            Assert.AreEqual(1, emu.Registers[Registers.ebx.Number]);
        }
    }
}
/*
 *    011111 => 100000 overflow
 *    111111 => 000000 no overflow
*/