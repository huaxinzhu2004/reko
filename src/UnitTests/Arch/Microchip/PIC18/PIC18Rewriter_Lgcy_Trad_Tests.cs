﻿#region License
/* 
 * Copyright (C) 2017-2018 Christian Hostelet.
 * inspired by work of:
 * Copyright (C) 1999-2017 John Källén.
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

using Microchip.Crownking;
using NUnit.Framework;

namespace Reko.UnitTests.Arch.Microchip.PIC18.Rewriter
{

    /// <summary>
    /// PIC18 legacy("pic18")/traditional execution mode rewriter tests.
    /// </summary>
    [TestFixture]
    public class PIC18Rewriter_Lgcy_Trad_Tests : PIC18RewriterTestsBase
    {
        [TestFixtureSetUp]
        public void OneSetup_Lgcy_Trad()
        {
            SetPICMode(InstructionSetID.PIC18, PICExecMode.Traditional);
        }

        [Test]
        public void Rewriter_ADDLW_Lgcy_Trad()
        {
            ExecTest(Words(0x0F00),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + 0x00",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x0F55),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + 0x55",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
        }

        [Test]
        public void Rewriter_ADDWF_Lgcy_Trad()
        {
            ExecTest(Words(0x2400),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[0x00:byte]",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2401),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[0x01:byte]",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x24C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + ADRESL",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2500),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[(BSR << 0x08) + 0x00:byte]",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2501),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x25C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2601),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = WREG + Mem0[0x01:byte]",
                    "2|L--|CDCZOVN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x26C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = WREG + ADRESL",
                    "2|L--|CDCZOVN = cond(ADRESL)"
                );
            ExecTest(Words(0x2701),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = WREG + Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x27C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = WREG + Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_ADDWFC_Lgcy_Trad()
        {
            ExecTest(Words(0x2000),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[0x00:byte] + C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2001),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[0x01:byte] + C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x20C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + ADRESL + C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2100),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[(BSR << 0x08) + 0x00:byte] + C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2101),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[(BSR << 0x08) + 0x01:byte] + C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x21C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG + Mem0[(BSR << 0x08) + 0xC3:byte] + C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2212),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x12:byte] = WREG + Mem0[0x12:byte] + C",
                    "2|L--|CDCZOVN = cond(Mem0[0x12:byte])"
                );
            ExecTest(Words(0x22C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = WREG + ADRESL + C",
                    "2|L--|CDCZOVN = cond(ADRESL)"
                );
            ExecTest(Words(0x233F),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x3F:byte] = WREG + Mem0[(BSR << 0x08) + 0x3F:byte] + C",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0x3F:byte])"                
                );
            ExecTest(Words(0x23C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = WREG + Mem0[(BSR << 0x08) + 0xC3:byte] + C",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"                
                );
        }

        [Test]
        public void Rewriter_ANDLW_Lgcy_Trad()
        {
            ExecTest(Words(0x0B00),
               "0|L--|0x000200(2): 2 instructions", "1|L--|WREG = WREG & 0x00", "2|L--|ZN = cond(WREG)"
               );
            ExecTest(Words(0x0B55),
               "0|L--|0x000200(2): 2 instructions", "1|L--|WREG = WREG & 0x55", "2|L--|ZN = cond(WREG)"
               );
        }

        [Test]
        public void Rewriter_ANDWF_Lgcy_Trad()
        {
            ExecTest(Words(0x1400),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG & Mem0[0x00:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1401),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG & Mem0[0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x14C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG & ADRESL",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1500),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG & Mem0[(BSR << 0x08) + 0x00:byte]",
                    "2|L--|ZN = cond(WREG)"               
                );
            ExecTest(Words(0x1501),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG & Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x15C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG & Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1614),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x14:byte] = WREG & Mem0[0x14:byte]",
                    "2|L--|ZN = cond(Mem0[0x14:byte])"
                );
            ExecTest(Words(0x16C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = WREG & ADRESL",
                    "2|L--|ZN = cond(ADRESL)"
                );
            ExecTest(Words(0x173F),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x3F:byte] = WREG & Mem0[(BSR << 0x08) + 0x3F:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0x3F:byte])"               
                );
            ExecTest(Words(0x17C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = WREG & Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"    
                );
        }

        [Test]
        public void Rewriter_BC_Lgcy_Trad()
        {
            ExecTest(Words(0xE200),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(ULT,C)) branch 0x000202"
                );
            ExecTest(Words(0xE27F),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(ULT,C)) branch 0x000300"
                );
            ExecTest(Words(0xE2FF),
               "0|T--|0x000200(2): 1 instructions",
                   "1|T--|if (Test(ULT,C)) branch 0x000200"
               );
        }

        [Test]
        public void Rewriter_BCF_Lgcy_Trad()
        {
            ExecTest(Words(0x9001),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] & 0xFE"
                );
            ExecTest(Words(0x94C4),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|ADRESH = ADRESH & 0xFB"
                );
            ExecTest(Words(0x9101),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = Mem0[(BSR << 0x08) + 0x01:byte] & 0xFE"
                );
            ExecTest(Words(0x9FC4),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC4:byte] = Mem0[(BSR << 0x08) + 0xC4:byte] & 0x7F"
                );
        }

        [Test]
        public void Rewriter_BN_Lgcy_Trad()
        {
            ExecTest(Words(0xE600),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(LT,N)) branch 0x000202"
                );
            ExecTest(Words(0xE67F),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(LT,N)) branch 0x000300"
                );
            ExecTest(Words(0xE6FF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(LT,N)) branch 0x000200"
                );
        }

        [Test]
        public void Rewriter_BNC_Lgcy_Trad()
        {
            ExecTest(Words(0xE300),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(UGE,C)) branch 0x000202"
                );
            ExecTest(Words(0xE37F),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(UGE,C)) branch 0x000300"
                );
            ExecTest(Words(0xE3FF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(UGE,C)) branch 0x000200"
                );
        }

        [Test]
        public void Rewriter_BNN_Lgcy_Trad()
        {
            ExecTest(Words(0xE700),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(GE,N)) branch 0x000202"
                );
            ExecTest(Words(0xE77F),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(GE,N)) branch 0x000300"
                );
            ExecTest(Words(0xE7FF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(GE,N)) branch 0x000200"
                );
        }

        [Test]
        public void Rewriter_BNOV_Lgcy_Trad()
        {
            ExecTest(Words(0xE500),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(NO,OV)) branch 0x000202"
                );
            ExecTest(Words(0xE57F),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(NO,OV)) branch 0x000300"
                );
            ExecTest(Words(0xE5FF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(NO,OV)) branch 0x000200"
                );
        }

        [Test]
        public void Rewriter_BNZ_Lgcy_Trad()
        {
            ExecTest(Words(0xE100),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(NE,Z)) branch 0x000202"
                );
            ExecTest(Words(0xE17F),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(NE,Z)) branch 0x000300"
                );
            ExecTest(Words(0xE1FF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(NE,Z)) branch 0x000200"
                );
        }

        [Test]
        public void Rewriter_BOV_Lgcy_Trad()
        {
            ExecTest(Words(0xE400),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(OV,OV)) branch 0x000202"
                );
            ExecTest(Words(0xE47F),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(OV,OV)) branch 0x000300"
                );
            ExecTest(Words(0xE4FF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(OV,OV)) branch 0x000200"
                );
        }

        [Test]
        public void Rewriter_BRA_Lgcy_Trad()
        {
            ExecTest(Words(0xD000),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|goto 0x000202"
                );
            ExecTest(Words(0xD005),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|goto 0x00020C"
                );
            ExecTest(Words(0xD3FF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|goto 0x000A00"
                );
            ExecTest(Words(0xD7FF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|goto 0x000200"
                );
        }

        [Test]
        public void Rewriter_BSF_Lgcy_Trad()
        {
            ExecTest(Words(0x8001),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] | 0x01"
                );
            ExecTest(Words(0x84C3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|ADRESL = ADRESL | 0x04"
                );
            ExecTest(Words(0x8101),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = Mem0[(BSR << 0x08) + 0x01:byte] | 0x01"
                );
            ExecTest(Words(0x8FC3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = Mem0[(BSR << 0x08) + 0xC3:byte] | 0x80"
                );
        }

        [Test]
        public void Rewriter_BTFSC_Lgcy_Trad()
        {
            ExecTest(Words(0xB000),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if ((Mem0[0x00:byte] & 0x01) == 0x00) branch 0x000204"
                );
            ExecTest(Words(0xB102),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if ((Mem0[(BSR << 0x08) + 0x02:byte] & 0x01) == 0x00) branch 0x000204"
                );
        }

        [Test]
        public void Rewriter_BTFSS_Lgcy_Trad()
        {
            ExecTest(Words(0xA002),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if ((Mem0[0x02:byte] & 0x01) != 0x00) branch 0x000204"
                );
            ExecTest(Words(0xA105),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if ((Mem0[(BSR << 0x08) + 0x05:byte] & 0x01) != 0x00) branch 0x000204"
                );
        }

        [Test]
        public void Rewriter_BTG_Lgcy_Trad()
        {
            ExecTest(Words(0x7001),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] ^ 0x01"
                );
            ExecTest(Words(0x74C3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|ADRESL = ADRESL ^ 0x04"
                );
            ExecTest(Words(0x7101),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = Mem0[(BSR << 0x08) + 0x01:byte] ^ 0x01"
                );
            ExecTest(Words(0x7FC3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = Mem0[(BSR << 0x08) + 0xC3:byte] ^ 0x80"
                );
        }

        [Test]
        public void Rewriter_BZ_Lgcy_Trad()
        {
            ExecTest(Words(0xE000),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(EQ,Z)) branch 0x000202"
                );
            ExecTest(Words(0xE07F),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(EQ,Z)) branch 0x000300"
                );
            ExecTest(Words(0xE0FF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Test(EQ,Z)) branch 0x000200"
                );
        }

        [Test]
        public void Rewriter_CALL_Lgcy_Trad()
        {
            ExecTest(Words(0xEC06, 0xF000),
                "0|T--|0x000200(4): 1 instructions",
                    "1|T--|call 0x00000C (1)"
                );

            ExecTest(Words(0xEC12, 0xF345),
                "0|T--|0x000200(4): 1 instructions",
                    "1|T--|call 0x068A24 (1)"
                );

            ExecTest(Words(0xED06, 0xF000),
                "0|T--|0x000200(4): 1 instructions",
                    "1|T--|call 0x00000C (1)"
                );

            ExecTest(Words(0xED12, 0xF345),
                "0|T--|0x000200(4): 1 instructions",
                    "1|T--|call 0x068A24 (1)"
                );


        }

        [Test]
        public void Rewriter_CLRF_Lgcy_Trad()
        {
            ExecTest(Words(0x6A01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = 0x00",
                    "2|L--|Z = true"
                );

            ExecTest(Words(0x6AC4),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESH = 0x00",
                    "2|L--|Z = true"
                );

            ExecTest(Words(0x6B02),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x02:byte] = 0x00",
                    "2|L--|Z = true"
                );

            ExecTest(Words(0x6BC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = 0x00",
                    "2|L--|Z = true"
                );


        }

        [Test]
        public void Rewriter_CLRWDT_Lgcy_Trad()
        {
            ExecTest(Words(0x0004),
                "0|L--|0x000200(2): 1 instructions",
                "1|L--|RCON = RCON | 0x0C"
               );
        }

        [Test]
        public void Rewriter_COMF_Lgcy_Trad()
        {
            ExecTest(Words(0x1C00),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ~Mem0[0x00:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1C01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ~Mem0[0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1CC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ~ADRESL",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1D00),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ~Mem0[(BSR << 0x08) + 0x00:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1D01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ~Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1DC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ~Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1E12),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x12:byte] = ~Mem0[0x12:byte]",
                    "2|L--|ZN = cond(Mem0[0x12:byte])"
                );
            ExecTest(Words(0x1EC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = ~ADRESL",
                    "2|L--|ZN = cond(ADRESL)"
                );
            ExecTest(Words(0x1F3F),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x3F:byte] = ~Mem0[(BSR << 0x08) + 0x3F:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0x3F:byte])"
                );
            ExecTest(Words(0x1FC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = ~Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_CPFSEQ_Lgcy_Trad()
        {
            ExecTest(Words(0x6200),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[0x00:byte] == WREG) branch 0x000204"
                );
            ExecTest(Words(0x6201),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[0x01:byte] == WREG) branch 0x000204"
                );
            ExecTest(Words(0x62C3),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (ADRESL == WREG) branch 0x000204"
                );
            ExecTest(Words(0x6300),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0x00:byte] == WREG) branch 0x000204"
                );
            ExecTest(Words(0x6301),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0x01:byte] == WREG) branch 0x000204"
                );
            ExecTest(Words(0x63C3),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0xC3:byte] == WREG) branch 0x000204"
                );
        }

        [Test]
        public void Rewriter_CPFSGT_Lgcy_Trad()
        {
            ExecTest(Words(0x6400),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[0x00:byte] >u WREG) branch 0x000204"
                );
            ExecTest(Words(0x6401),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[0x01:byte] >u WREG) branch 0x000204"
                );
            ExecTest(Words(0x64C3),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (ADRESL >u WREG) branch 0x000204"
                );
            ExecTest(Words(0x6500),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0x00:byte] >u WREG) branch 0x000204"
                );
            ExecTest(Words(0x6501),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0x01:byte] >u WREG) branch 0x000204"
                );
            ExecTest(Words(0x65C3),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0xC3:byte] >u WREG) branch 0x000204"
                );
        }

        [Test]
        public void Rewriter_CPFSLT_Lgcy_Trad()
        {
            ExecTest(Words(0x6000),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[0x00:byte] <u WREG) branch 0x000204"
                );
            ExecTest(Words(0x6001),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[0x01:byte] <u WREG) branch 0x000204"
                );
            ExecTest(Words(0x60C3),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (ADRESL <u WREG) branch 0x000204"
                );
            ExecTest(Words(0x6100),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0x00:byte] <u WREG) branch 0x000204"
                );
            ExecTest(Words(0x6101),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0x01:byte] <u WREG) branch 0x000204"
                );
            ExecTest(Words(0x61C3),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0xC3:byte] <u WREG) branch 0x000204"
                );
        }

        [Test]
        public void Rewriter_DAW_Lgcy_Trad()
        {
            ExecTest(Words(0x0007),
                "0|L--|0x000200(2): 2 instructions",
                "1|L--|WREG = __daw(WREG, C, DC)()"
                );
        }

        [Test]
        public void Rewriter_DCFSNZ_Lgcy_Trad()
        {
            ExecTest(Words(0x4C00),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x00:byte] - 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4C01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x01:byte] - 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4CC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ADRESH - 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4D00),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x00:byte] - 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4D01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x01:byte] - 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4DC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0xC4:byte] - 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4E01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] - 0x01",
                    "2|T--|if (Mem0[0x01:byte] != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4EC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|ADRESH = ADRESH - 0x01",
                    "2|T--|if (ADRESH != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4F44),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x44:byte] = Mem0[(BSR << 0x08) + 0x44:byte] - 0x01",
                    "2|T--|if (Mem0[(BSR << 0x08) + 0x44:byte] != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4FC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC4:byte] = Mem0[(BSR << 0x08) + 0xC4:byte] - 0x01",
                    "2|T--|if (Mem0[(BSR << 0x08) + 0xC4:byte] != 0x00) branch 0x000204"
                );

        }

        [Test]
        public void Rewriter_DECF_Lgcy_Trad()
        {
            ExecTest(Words(0x0400),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x00:byte] - 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x0401),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x01:byte] - 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x04C4),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ADRESH - 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x0500),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x00:byte] - 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x0501),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x01:byte] - 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x05C4),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0xC4:byte] - 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x0601),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] - 0x01",
                    "2|L--|CDCZOVN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x06C4),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESH = ADRESH - 0x01",
                    "2|L--|CDCZOVN = cond(ADRESH)"
                );
            ExecTest(Words(0x0744),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x44:byte] = Mem0[(BSR << 0x08) + 0x44:byte] - 0x01",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0x44:byte])"
                );
            ExecTest(Words(0x07C4),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC4:byte] = Mem0[(BSR << 0x08) + 0xC4:byte] - 0x01",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0xC4:byte])"
                );

        }

        [Test]
        public void Rewriter_DECFSZ_Lgcy_Trad()
        {
            ExecTest(Words(0x2C00),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x00:byte] - 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x2C01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x01:byte] - 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x2CC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ADRESH - 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x2D00),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x00:byte] - 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x2D01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x01:byte] - 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x2DC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0xC4:byte] - 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x2E01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] - 0x01",
                    "2|T--|if (Mem0[0x01:byte] == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x2EC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|ADRESH = ADRESH - 0x01",
                    "2|T--|if (ADRESH == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x2F44),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x44:byte] = Mem0[(BSR << 0x08) + 0x44:byte] - 0x01",
                    "2|T--|if (Mem0[(BSR << 0x08) + 0x44:byte] == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x2FC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC4:byte] = Mem0[(BSR << 0x08) + 0xC4:byte] - 0x01",
                    "2|T--|if (Mem0[(BSR << 0x08) + 0xC4:byte] == 0x00) branch 0x000204"
                );

        }

        [Test]
        public void Rewriter_GOTO_Lgcy_Trad()
        {
            ExecTest(Words(0xEF00, 0xF000),
                "0|T--|0x000200(4): 1 instructions",
                    "1|T--|goto 0x000000"
                );
            ExecTest(Words(0xEF12, 0xF345),
                "0|T--|0x000200(4): 1 instructions",
                    "1|T--|goto 0x068A24"
                );
        }

        [Test]
        public void Rewriter_INCF_Lgcy_Trad()
        {
            ExecTest(Words(0x2800),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x00:byte] + 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2801),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x01:byte] + 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x28C3), 
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ADRESL + 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2900), 
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x00:byte] + 0x01",
                    "2|L--|CDCZOVN = cond(WREG)" 
                );
            ExecTest(Words(0x2901),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x01:byte] + 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x29C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0xC3:byte] + 0x01",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x2A01), 
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] + 0x01",
                    "2|L--|CDCZOVN = cond(Mem0[0x01:byte])" 
                );
            ExecTest(Words(0x2AC3), 
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = ADRESL + 0x01",
                    "2|L--|CDCZOVN = cond(ADRESL)"
                );
            ExecTest(Words(0x2B33), 
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x33:byte] = Mem0[(BSR << 0x08) + 0x33:byte] + 0x01",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0x33:byte])"  
                );
            ExecTest(Words(0x2BC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = Mem0[(BSR << 0x08) + 0xC3:byte] + 0x01",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"   
                );

        }

        [Test]
        public void Rewriter_INCFSZ_Lgcy_Trad()
        {
            ExecTest(Words(0x3C00),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x00:byte] + 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x3C01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x01:byte] + 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x3CC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ADRESH + 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x3D00),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x00:byte] + 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x3D01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x01:byte] + 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x3DC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0xC4:byte] + 0x01",
                    "2|T--|if (WREG == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x3E01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] + 0x01",
                    "2|T--|if (Mem0[0x01:byte] == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x3EC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|ADRESH = ADRESH + 0x01",
                    "2|T--|if (ADRESH == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x3F44),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x44:byte] = Mem0[(BSR << 0x08) + 0x44:byte] + 0x01",
                    "2|T--|if (Mem0[(BSR << 0x08) + 0x44:byte] == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x3FC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC4:byte] = Mem0[(BSR << 0x08) + 0xC4:byte] + 0x01",
                    "2|T--|if (Mem0[(BSR << 0x08) + 0xC4:byte] == 0x00) branch 0x000204"
                );

        }

        [Test]
        public void Rewriter_INFSNZ_Lgcy_Trad()
        {
            ExecTest(Words(0x4800),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x00:byte] + 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4801),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x01:byte] + 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x48C4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ADRESH + 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4900),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x00:byte] + 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4901),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x01:byte] + 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x49C4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0xC4:byte] + 0x01",
                    "2|T--|if (WREG != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4A01),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] + 0x01",
                    "2|T--|if (Mem0[0x01:byte] != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4AC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|ADRESH = ADRESH + 0x01",
                    "2|T--|if (ADRESH != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4B44),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x44:byte] = Mem0[(BSR << 0x08) + 0x44:byte] + 0x01",
                    "2|T--|if (Mem0[(BSR << 0x08) + 0x44:byte] != 0x00) branch 0x000204"
                );
            ExecTest(Words(0x4BC4),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC4:byte] = Mem0[(BSR << 0x08) + 0xC4:byte] + 0x01",
                    "2|T--|if (Mem0[(BSR << 0x08) + 0xC4:byte] != 0x00) branch 0x000204"
                );

        }

        [Test]
        public void Rewriter_IORLW_Lgcy_Trad()
        {
            ExecTest(Words(0x0900),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG | 0x00",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x0955),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG | 0x55",
                    "2|L--|ZN = cond(WREG)"
                );
        }

        [Test]
        public void Rewriter_IORWF_Lgcy_Trad()
        {
            ExecTest(Words(0x1000),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG | Mem0[0x00:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1001),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG | Mem0[0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x10C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG | ADRESL",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1100),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG | Mem0[(BSR << 0x08) + 0x00:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1101),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG | Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x11C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG | Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1201),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = WREG | Mem0[0x01:byte]",
                    "2|L--|ZN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x12C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = WREG | ADRESL",
                    "2|L--|ZN = cond(ADRESL)"
                );
            ExecTest(Words(0x1301),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = WREG | Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x13C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = WREG | Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_LFSR_Lgcy_Trad()
        {
            ExecTest(Words(0xEE01, 0xF023),
                "0|L--|0x000200(4): 1 instructions",
                    "1|L--|FSR0H_FSR0L = 0x0123"
                );
            ExecTest(Words(0xEE14, 0xF056),
                "0|L--|0x000200(4): 1 instructions",
                    "1|L--|FSR1H_FSR1L = 0x0456"
                );
            ExecTest(Words(0xEE27, 0xF089),
                "0|L--|0x000200(4): 1 instructions",
                    "1|L--|FSR2H_FSR2L = 0x0789"
                );
        }

        [Test]
        public void Rewriter_MOVF_Lgcy_Trad()
        {
            ExecTest(Words(0x5000),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x00:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x5001),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x50C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ADRESL",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x5100),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x00:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x5101),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x51C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x5201),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte]",
                    "2|L--|ZN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x52C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = ADRESL",
                    "2|L--|ZN = cond(ADRESL)"
                );
            ExecTest(Words(0x5301),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x53C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_MOVFF_Lgcy_Trad()
        {
            ExecTest(Words(0xC123, 0xF456),
                "0|L--|0x000200(4): 1 instructions",
                    "1|L--|Mem0[0x0456:byte] = Mem0[0x0123:byte]"
                );
        }

        [Test]
        public void Rewriter_MOVLB_Lgcy_Trad()
        {
            ExecTest(Words(0x0100),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|BSR = 0x00" 
                );
            ExecTest(Words(0x0105),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|BSR = 0x05" 
                );
        }

        [Test]
        public void Rewriter_MOVLW_Lgcy_Trad()
        {
            ExecTest(Words(0x0E00),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|WREG = 0x00"
                );
            ExecTest(Words(0x0E55),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|WREG = 0x55"
                );
            ExecTest(Words(0x0EBC),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|WREG = 0xBC"
                );
        }

        [Test]
        public void Rewriter_MOVWF_Lgcy_Trad()
        {
            ExecTest(Words(0x6E01),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[0x01:byte] = WREG"
                );

            ExecTest(Words(0x6EC4),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|ADRESH = WREG"
                );

            ExecTest(Words(0x6F02),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x02:byte] = WREG"
                );

            ExecTest(Words(0x6FC3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = WREG"
                );

        }

        [Test]
        public void Rewriter_MULLW_Lgcy_Trad()
        {
            ExecTest(Words(0x0D00),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|PRODH_PRODL = WREG *u 0x00"
                );
            ExecTest(Words(0x0D55),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|PRODH_PRODL = WREG *u 0x55"
                );
        }

        [Test]
        public void Rewriter_MULWF_Lgcy_Trad()
        {
            ExecTest(Words(0x0344),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|PRODH_PRODL = Mem0[(BSR << 0x08) + 0x44:byte] *u WREG"
                );
            ExecTest(Words(0x0389),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|PRODH_PRODL = Mem0[(BSR << 0x08) + 0x89:byte] *u WREG"
                );
            ExecTest(Words(0x0200),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|PRODH_PRODL = Mem0[0x00:byte] *u WREG"
                );
            ExecTest(Words(0x025F),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|PRODH_PRODL = Mem0[0x5F:byte] *u WREG"
                );
            ExecTest(Words(0x02A8),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|PRODH_PRODL = EEDATA *u WREG"
                );
        }

        [Test]
        public void Rewriter_NEGF_Lgcy_Trad()
        {
            ExecTest(Words(0x6C01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = -Mem0[0x01:byte]",
                    "2|L--|CDCZOVN = cond(Mem0[0x01:byte])"
                );

            ExecTest(Words(0x6CC4),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESH = -ADRESH",
                    "2|L--|CDCZOVN = cond(ADRESH)"
                );

            ExecTest(Words(0x6D02),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x02:byte] = -Mem0[(BSR << 0x08) + 0x02:byte]",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0x02:byte])"
                );

            ExecTest(Words(0x6DC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = -Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );

        }

        [Test]
        public void Rewriter_NOP_Lgcy_Trad()
        {

            ExecTest(Words(0x0000),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|nop"
                );

            ExecTest(Words(0xF000),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|nop"
                );

            ExecTest(Words(0xF123),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|nop"
                );

            ExecTest(Words(0xFEDC, 0xF256),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|nop",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop"
                );

        }

        [Test]
        public void Rewriter_POP_Lgcy_Trad()
        {
            ExecTest(Words(0x0006),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|STKPTR = STKPTR - 0x01"
                );
        }

        [Test]
        public void Rewriter_PUSH_Lgcy_Trad()
        {
            ExecTest(Words(0x0005),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|STKPTR = STKPTR + 0x01"
                );
        }

        [Test]
        public void Rewriter_RCALL_Lgcy_Trad()
        {
            ExecTest(Words(0xD800),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|call 0x000202 (1)"
                );
            ExecTest(Words(0xDFFF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|call 0x000200 (1)"
                );
            ExecTest(Words(0xDBFF),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|call 0x000A00 (1)"
                );
        }

        [Test]
        public void Rewriter_RESET_Lgcy_Trad()
        {
            ExecTest(Words(0x00FF),
                "0|H--|0x000200(2): 2 instructions",
                    "1|L--|STKPTR = 0x00",
                    "2|L--|__reset()"
                );
        }

        [Test]
        public void Rewriter_RETFIE_Lgcy_Trad()
        {
            ExecTest(Words(0x0010),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|return (1,0)"
                );
            ExecTest(Words(0x0011),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|return (1,0)"
                );
        }

        [Test]
        public void Rewriter_RETLW_Lgcy_Trad()
        {
            ExecTest(Words(0x0C00),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = 0x00",
                    "2|T--|return (1,0)"
                );
            ExecTest(Words(0x0C55),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = 0x55",
                    "2|T--|return (1,0)"
                );
            ExecTest(Words(0x0CCC),
                "0|T--|0x000200(2): 2 instructions",
                    "1|L--|WREG = 0xCC",
                    "2|T--|return (1,0)"
                );
        }

        [Test]
        public void Rewriter_RETURN_Lgcy_Trad()
        {
            ExecTest(Words(0x0012),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|return (1,0)"
                );
            ExecTest(Words(0x0013),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|return (1,0)"
                );
        }

        [Test]
        public void Rewriter_RLCF_Lgcy_Trad()
        {
            ExecTest(Words(0x3400),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlcf(Mem0[0x00:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x3401),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlcf(Mem0[0x01:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x34C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlcf(ADRESL, C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x3500),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlcf(Mem0[(BSR << 0x08) + 0x00:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x3501),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlcf(Mem0[(BSR << 0x08) + 0x01:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x35C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlcf(Mem0[(BSR << 0x08) + 0xC3:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x3601),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = __rlcf(Mem0[0x01:byte], C)()",
                    "2|L--|CZN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x36C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = __rlcf(ADRESL, C)()",
                    "2|L--|CZN = cond(ADRESL)"
                );
            ExecTest(Words(0x3701),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = __rlcf(Mem0[(BSR << 0x08) + 0x01:byte], C)()",
                    "2|L--|CZN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x37C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = __rlcf(Mem0[(BSR << 0x08) + 0xC3:byte], C)()",
                    "2|L--|CZN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_RLNCF_Lgcy_Trad()
        {
            ExecTest(Words(0x4400),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlncf(Mem0[0x00:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x4401),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlncf(Mem0[0x01:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x44C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlncf(ADRESL)()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x4500),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlncf(Mem0[(BSR << 0x08) + 0x00:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x4501),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlncf(Mem0[(BSR << 0x08) + 0x01:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x45C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rlncf(Mem0[(BSR << 0x08) + 0xC3:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x4601),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = __rlncf(Mem0[0x01:byte])()",
                    "2|L--|ZN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x46C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = __rlncf(ADRESL)()",
                    "2|L--|ZN = cond(ADRESL)"
                );
            ExecTest(Words(0x4701),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = __rlncf(Mem0[(BSR << 0x08) + 0x01:byte])()",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x47C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = __rlncf(Mem0[(BSR << 0x08) + 0xC3:byte])()",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_RRCF_Lgcy_Trad()
        {
            ExecTest(Words(0x3000),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrcf(Mem0[0x00:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x3001),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrcf(Mem0[0x01:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x30C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrcf(ADRESL, C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x3100),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrcf(Mem0[(BSR << 0x08) + 0x00:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x3101),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrcf(Mem0[(BSR << 0x08) + 0x01:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x31C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrcf(Mem0[(BSR << 0x08) + 0xC3:byte], C)()",
                    "2|L--|CZN = cond(WREG)"
                );
            ExecTest(Words(0x3201),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = __rrcf(Mem0[0x01:byte], C)()",
                    "2|L--|CZN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x32C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = __rrcf(ADRESL, C)()",
                    "2|L--|CZN = cond(ADRESL)"
                );
            ExecTest(Words(0x3301),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = __rrcf(Mem0[(BSR << 0x08) + 0x01:byte], C)()",
                    "2|L--|CZN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x33C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = __rrcf(Mem0[(BSR << 0x08) + 0xC3:byte], C)()",
                    "2|L--|CZN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_RRNCF_Lgcy_Trad()
        {
            ExecTest(Words(0x4000),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrncf(Mem0[0x00:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x4001),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrncf(Mem0[0x01:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x40C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrncf(ADRESL)()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x4100),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrncf(Mem0[(BSR << 0x08) + 0x00:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x4101),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrncf(Mem0[(BSR << 0x08) + 0x01:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x41C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = __rrncf(Mem0[(BSR << 0x08) + 0xC3:byte])()",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x4201),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = __rrncf(Mem0[0x01:byte])()",
                    "2|L--|ZN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x42C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = __rrncf(ADRESL)()",
                    "2|L--|ZN = cond(ADRESL)"
                );
            ExecTest(Words(0x4301),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = __rrncf(Mem0[(BSR << 0x08) + 0x01:byte])()",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x43C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = __rrncf(Mem0[(BSR << 0x08) + 0xC3:byte])()",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_SETF_Lgcy_Trad()
        {
            ExecTest(Words(0x6801),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[0x01:byte] = 0xFF"
                );

            ExecTest(Words(0x68C4),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|ADRESH = 0xFF"
                );

            ExecTest(Words(0x6902),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x02:byte] = 0xFF"
                );

            ExecTest(Words(0x69C3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = 0xFF"
                );


        }

        [Test]
        public void Rewriter_SLEEP_Lgcy_Trad()
        {
            ExecTest(Words(0x0003),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|RCON = RCON & 0xFB",
                    "2|L--|RCON = RCON | 0x08"
                );
        }

        [Test]
        public void Rewriter_SUBFWB_Lgcy_Trad()
        {
            ExecTest(Words(0x5400),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG - Mem0[0x00:byte] - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5401),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG - Mem0[0x01:byte] - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x54C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG - ADRESL - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5500),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG - Mem0[(BSR << 0x08) + 0x00:byte] - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5501),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG - Mem0[(BSR << 0x08) + 0x01:byte] - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x55C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG - Mem0[(BSR << 0x08) + 0xC3:byte] - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5601),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = WREG - Mem0[0x01:byte] - !C",
                    "2|L--|CDCZOVN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x56C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = WREG - ADRESL - !C",
                    "2|L--|CDCZOVN = cond(ADRESL)"
                );
            ExecTest(Words(0x5701),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = WREG - Mem0[(BSR << 0x08) + 0x01:byte] - !C",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x57C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = WREG - Mem0[(BSR << 0x08) + 0xC3:byte] - !C",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_SUBLW_Lgcy_Trad()
        {
            ExecTest(Words(0x0800),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = 0x00 - WREG",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x0855),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = 0x55 - WREG",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
        }

        [Test]
        public void Rewriter_SUBWF_Lgcy_Trad()
        {
            ExecTest(Words(0x5C00),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x00:byte] - WREG",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5C01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x01:byte] - WREG",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5CC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ADRESL - WREG",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5D00),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x00:byte] - WREG",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5D01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x01:byte] - WREG",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5DC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0xC3:byte] - WREG",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5E01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] - WREG",
                    "2|L--|CDCZOVN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x5EC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = ADRESL - WREG",
                    "2|L--|CDCZOVN = cond(ADRESL)"
                );
            ExecTest(Words(0x5F01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = Mem0[(BSR << 0x08) + 0x01:byte] - WREG",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x5FC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = Mem0[(BSR << 0x08) + 0xC3:byte] - WREG",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_SUBWFB_Lgcy_Trad()
        {
            ExecTest(Words(0x5800),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x00:byte] - WREG - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5801),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[0x01:byte] - WREG - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x58C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = ADRESL - WREG - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5900),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x00:byte] - WREG - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5901),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0x01:byte] - WREG - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x59C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = Mem0[(BSR << 0x08) + 0xC3:byte] - WREG - !C",
                    "2|L--|CDCZOVN = cond(WREG)"
                );
            ExecTest(Words(0x5A01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = Mem0[0x01:byte] - WREG - !C",
                    "2|L--|CDCZOVN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x5AC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = ADRESL - WREG - !C",
                    "2|L--|CDCZOVN = cond(ADRESL)"
                );
            ExecTest(Words(0x5B01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = Mem0[(BSR << 0x08) + 0x01:byte] - WREG - !C",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x5BC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = Mem0[(BSR << 0x08) + 0xC3:byte] - WREG - !C",
                    "2|L--|CDCZOVN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter_SWAPF_Lgcy_Trad()
        {
            ExecTest(Words(0x3800),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|WREG = __swapf(Mem0[0x00:byte])()"
                );
            ExecTest(Words(0x3801),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|WREG = __swapf(Mem0[0x01:byte])()"
                );
            ExecTest(Words(0x38C3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|WREG = __swapf(ADRESL)()"
                );
            ExecTest(Words(0x3900),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|WREG = __swapf(Mem0[(BSR << 0x08) + 0x00:byte])()"
                );
            ExecTest(Words(0x3901),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|WREG = __swapf(Mem0[(BSR << 0x08) + 0x01:byte])()"
                );
            ExecTest(Words(0x39C3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|WREG = __swapf(Mem0[(BSR << 0x08) + 0xC3:byte])()"
                );
            ExecTest(Words(0x3A01),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[0x01:byte] = __swapf(Mem0[0x01:byte])()"
                );
            ExecTest(Words(0x3AC3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|ADRESL = __swapf(ADRESL)()"
                );
            ExecTest(Words(0x3B01),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = __swapf(Mem0[(BSR << 0x08) + 0x01:byte])()"
                );
            ExecTest(Words(0x3BC3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = __swapf(Mem0[(BSR << 0x08) + 0xC3:byte])()"
                );
        }

        [Test]
        public void Rewriter_TBLRD_Lgcy_Trad()
        {
            ExecTest(Words(0x0008),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|__tblrd(0x00)"
                );
            ExecTest(Words(0x0009),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|__tblrd(0x01)"
                );
            ExecTest(Words(0x000A),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|__tblrd(0x02)"
                );
            ExecTest(Words(0x000B),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|__tblrd(0x03)"
                );
        }

        [Test]
        public void Rewriter_TBLWT_Lgcy_Trad()
        {
            ExecTest(Words(0x000C),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|__tblwt(0x00)"
                );
            ExecTest(Words(0x000D),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|__tblwt(0x01)"
                );
            ExecTest(Words(0x000E),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|__tblwt(0x02)"
                );
            ExecTest(Words(0x000F),
                "0|L--|0x000200(2): 1 instructions",
                    "1|L--|__tblwt(0x03)"
                );
        }

        [Test]
        public void Rewriter_TSTFSZ_Lgcy_Trad()
        {
            ExecTest(Words(0x6600),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[0x00:byte] == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x6601),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[0x01:byte] == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x66C3),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (ADRESL == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x6700),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0x00:byte] == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x6701),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0x01:byte] == 0x00) branch 0x000204"
                );
            ExecTest(Words(0x67C3),
                "0|T--|0x000200(2): 1 instructions",
                    "1|T--|if (Mem0[(BSR << 0x08) + 0xC3:byte] == 0x00) branch 0x000204"
                );
        }

        [Test]
        public void Rewriter_XORLW_Lgcy_Trad()
        {
            ExecTest(Words(0x0A00),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG ^ 0x00",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x0A55),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG ^ 0x55",
                    "2|L--|ZN = cond(WREG)"
                );
        }

        [Test]
        public void Rewriter_XORWF_Lgcy_Trad()
        {
            ExecTest(Words(0x1800),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG ^ Mem0[0x00:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1801),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG ^ Mem0[0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x18C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG ^ ADRESL",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1900),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG ^ Mem0[(BSR << 0x08) + 0x00:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1901),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG ^ Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x19C3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|WREG = WREG ^ Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(WREG)"
                );
            ExecTest(Words(0x1A01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[0x01:byte] = WREG ^ Mem0[0x01:byte]",
                    "2|L--|ZN = cond(Mem0[0x01:byte])"
                );
            ExecTest(Words(0x1AC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|ADRESL = WREG ^ ADRESL",
                    "2|L--|ZN = cond(ADRESL)"
                );
            ExecTest(Words(0x1B01),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0x01:byte] = WREG ^ Mem0[(BSR << 0x08) + 0x01:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0x01:byte])"
                );
            ExecTest(Words(0x1BC3),
                "0|L--|0x000200(2): 2 instructions",
                    "1|L--|Mem0[(BSR << 0x08) + 0xC3:byte] = WREG ^ Mem0[(BSR << 0x08) + 0xC3:byte]",
                    "2|L--|ZN = cond(Mem0[(BSR << 0x08) + 0xC3:byte])"
                );
        }

        [Test]
        public void Rewriter__Invalid_Lgcy_Trad()
        {
            ExecTest(Words(0x0001),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0002),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0002, 0xF000),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop"
                );

            ExecTest(Words(0x0002, 0xF000, 0x1234),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop",
                "4|L--|0x000204(2): 2 instructions",
                    "5|L--|Mem0[0x34:byte] = WREG | Mem0[0x34:byte]",
                    "6|L--|ZN = cond(Mem0[0x34:byte])"
                );

            ExecTest(Words(0x0002, 0xF123, 0xF456),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop",
                "4|L--|0x000204(2): 1 instructions",
                    "5|L--|nop"
                );

            ExecTest(Words(0x0014),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0015),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0016),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0017),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0018),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0019),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x001A),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x001B),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x001C),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x001D),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x001E),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x001F),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0020),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0040),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0060),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0067, 0x1234),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 2 instructions",
                    "3|L--|Mem0[0x34:byte] = WREG | Mem0[0x34:byte]",
                    "4|L--|ZN = cond(Mem0[0x34:byte])"
                );

            ExecTest(Words(0x006F, 0xF000),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop"
                );

            ExecTest(Words(0x006F, 0xF000, 0x1234),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop",
                "4|L--|0x000204(2): 2 instructions",
                    "5|L--|Mem0[0x34:byte] = WREG | Mem0[0x34:byte]",
                    "6|L--|ZN = cond(Mem0[0x34:byte])"
                );

            ExecTest(Words(0x006F, 0xF123, 0xF456),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop",
                "4|L--|0x000204(2): 1 instructions",
                    "5|L--|nop"
                );

            ExecTest(Words(0x0080),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x00F0),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0140),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x0180),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0x01E0),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xC000),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xC000, 0x0123),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|---|<invalid>"
                );

            ExecTest(Words(0xE800),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xE8C0),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xE900),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xE9C0),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xEA00),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xEB00),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xEB00, 0x1234),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 2 instructions",
                    "3|L--|Mem0[0x34:byte] = WREG | Mem0[0x34:byte]",
                    "4|L--|ZN = cond(Mem0[0x34:byte])"
                );

            ExecTest(Words(0xEB00, 0xF234),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop"
                );

            ExecTest(Words(0xEB80),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xEB80, 0x1234),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 2 instructions",
                    "3|L--|Mem0[0x34:byte] = WREG | Mem0[0x34:byte]",
                    "4|L--|ZN = cond(Mem0[0x34:byte])"
                );

            ExecTest(Words(0xEB80, 0xF567),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop"
                );

            ExecTest(Words(0xEC00),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xEC00, 0x1234),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 2 instructions",
                    "3|L--|Mem0[0x34:byte] = WREG | Mem0[0x34:byte]",
                    "4|L--|ZN = cond(Mem0[0x34:byte])"
                );

            ExecTest(Words(0xED00),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xED00, 0x989D),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|PIE1 = PIE1 & 0xEF"
                );

            ExecTest(Words(0xEE00),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xEE00, 0x64F3),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|T--|0x000202(2): 1 instructions",
                    "3|T--|if (PRODL >u WREG) branch 0x000206"
                );


            ExecTest(Words(0xEE00, 0xF400),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop"
                );

            ExecTest(Words(0xEE30, 0xF000),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|L--|nop"
                );

            ExecTest(Words(0xEE40),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xEEF0),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xEF00),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>"
                );

            ExecTest(Words(0xEF00, 0xEDCB),
                "0|L--|0x000200(2): 1 instructions",
                    "1|---|<invalid>",
                "2|L--|0x000202(2): 1 instructions",
                    "3|---|<invalid>"
                );

        }

    }

}
