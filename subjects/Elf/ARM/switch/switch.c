// switch.c
// Generated by decompiling switch
// using Reko decompiler version 0.7.2.0.

#include "switch.h"

// 000082F0: Register word32 _init(Register word32 lr, Register word32 pc, Register out ptr32 r10Out)
word32 _init(word32 lr, word32 pc, ptr32 & r10Out)
{
	word32 r10_6;
	*r10Out = call_gmon_start(pc, lr);
	frame_dummy();
	word32 sp_8;
	return __do_global_ctors_aux(dwArg00, out sp_8);
}

// 00008314: Register word32 abort(Register word32 pc)
word32 abort(word32 pc)
{
	<anonymous> ** ip_5 = pc + globals->dw8320;
	word32 sp_6;
	word32 pc_7;
	word32 ip_8;
	(*ip_5)();
	return ip_8;
}

// 00008324: void __libc_start_main(Register word32 pc)
void __libc_start_main(word32 pc)
{
	<anonymous> ** ip_5 = pc + globals->dw8330;
	word32 sp_6;
	word32 pc_7;
	word32 ip_8;
	(*ip_5)();
}

// 00008334: void _start(Register word32 r4, Register word32 r5, Register word32 r6, Register Eq_54 r8, Register word32 pc, Stack word32 dwArg00)
void _start(word32 r4, word32 r5, word32 r6, Eq_54 r8, word32 pc, word32 dwArg00)
{
	word32 ip_3 = globals->dw8360;
	union Eq_54 * r0_14 = globals->ptr8364;
	__libc_start_main(pc);
	abort(pc);
	*r0_14 = (union Eq_54 *) r8;
	if (Z)
		call_gmon_start(pc, ip_3);
	else
		call_gmon_start(pc, ip_3);
}

// 0000836C: Register word32 call_gmon_start(Register word32 pc, Stack word32 dwArg00)
word32 call_gmon_start(word32 pc, word32 dwArg00)
{
	<anonymous> ** r10_11 = pc + globals->dw8394;
	<anonymous> * r3_12 = *r10_11;
	if (!Z)
		return dwLoc08;
	word32 sp_26;
	word32 r10_27;
	word32 lr_28;
	word32 r3_29;
	word32 pc_30;
	byte NZCV_31;
	byte Z_32;
	r3_12();
	return r10_27;
}

// 0000839C: void __do_global_dtors_aux(Stack word32 dwArg00)
void __do_global_dtors_aux(word32 dwArg00)
{
	union Eq_120 * r5_10 = globals->ptr83F4;
	if (!Z)
		return;
	<anonymous> *** r4_29 = globals->ptr83F8;
	<anonymous> * r2_31 = **r4_29;
	if (Z)
		*r5_10 = 0x01;
	else
	{
		*r4_29 = (<anonymous> ***) ((char *) *r4_29 + 0x04);
		word32 sp_37;
		word32 r4_38;
		word32 r5_39;
		word32 lr_40;
		word32 pc_41;
		word32 r3_42;
		byte NZCV_43;
		byte Z_44;
		word32 r2_45;
		r2_31();
	}
}

// 000083FC: void call___do_global_dtors_aux()
void call___do_global_dtors_aux()
{
}

// 00008404: void frame_dummy()
void frame_dummy()
{
	if (!Z)
		return;
	if (!Z)
		return;
	word32 sp_16;
	word32 pc_17;
	word32 r0_18;
	word32 r3_19;
	byte NZCV_20;
	byte Z_21;
	fn00000000();
}

// 0000842C: void call_frame_dummy()
void call_frame_dummy()
{
}

// 00008434: Register ui32 frobulate(Register ui32 r0, Register word32 lr, Stack word32 dwArg00, Stack ui32 dwArg04, Register out ptr32 fpOut)
ui32 frobulate(ui32 r0, word32 lr, word32 dwArg00, ui32 dwArg04, ptr32 & fpOut)
{
	word32 fp_24;
	*fpOut = fp;
	return __divsi3(r0 * r0, 1337, lr);
}

// 00008470: Register word32 bazulate(Register ui32 r0, Register word32 r1, Register word32 lr, Stack ui32 dwArg00)
word32 bazulate(ui32 r0, word32 r1, word32 lr, ui32 dwArg00)
{
	struct Eq_171 * fp_23;
	ui32 r0_28 = __divsi3(r0 + r1, frobulate(r0, lr, r1, r0, out fp_23), lr);
	struct Eq_180 * fp_33;
	__divsi3(r0_28, frobulate(fp_23->dwFFFFFFE8, lr, r4, dwArg04, out fp_33), lr);
	return fp_33->dw0004;
}

// 000084D4: Register word32 switcheroo(Register ui32 r0, Register word32 lr, Stack word32 dwArg00)
word32 switcheroo(ui32 r0, word32 lr, word32 dwArg00)
{
	if (ZC)
		return *bazulate(0x00, 0x00, lr, r0);
	word32 sp_32;
	word32 ip_33;
	word32 fp_34;
	word32 lr_35;
	word32 pc_36;
	word32 r0_37;
	word32 r3_38;
	byte NZCV_39;
	byte ZC_40;
	bcuiposr0 None_41;
	word32 r1_42;
	(*((char *) globals->a84F8 + r0 * 0x04))();
	return fp_34;
}

// 0000855C: void main(Register ui32 r0, Register word32 r1, Register word32 lr, Stack word32 dwArg00)
void main(ui32 r0, word32 r1, word32 lr, word32 dwArg00)
{
	switcheroo(r0, lr, r1);
}

// 00008588: Register ui32 __divsi3(Register ui32 r0, Register word32 r1, Register word32 lr)
ui32 __divsi3(ui32 r0, word32 r1, word32 lr)
{
	uint32 r3_30 = 0x01;
	ui32 r2_22 = 0x00;
	if (Z)
	{
		__div0(r0, lr);
		return 0x00;
	}
	else
	{
		if (!C)
		{
			do
			{
				if (!C)
					r3_30 = r3_30 << 0x04;
			} while (C);
			do
			{
				if (!C)
					r3_30 = r3_30 << 0x01;
			} while (C);
			do
			{
				if (!C)
					r2_22 = r2_22 | r3_30;
				if (!C)
					r2_22 = r2_22 | r3_30 >> 0x01;
				if (!C)
					r2_22 = r2_22 | r3_30 >> 0x02;
				if (!C)
					r2_22 = r2_22 | r3_30 >> 0x03;
				if (!Z)
					r3_30 = r3_30 >> 0x04;
			} while (Z);
		}
		return r2_22;
	}
}

// 00008638: void __div0(Register ui32 r0, Stack word32 dwArg00)
void __div0(ui32 r0, word32 dwArg00)
{
	__syscall(0x00900014);
	if (!C)
		return;
	__syscall(0x00900025);
}

// 00008654: void __libc_csu_init(Register word32 lr, Register word32 pc, Stack word32 dwArg00)
void __libc_csu_init(word32 lr, word32 pc, word32 dwArg00)
{
	<anonymous> *** r10_18;
	word32 r4_19 = _init(lr, pc, out r10_18);
	<anonymous> ** r1_22 = *r10_18;
	if (!C)
		return;
	word32 sp_49;
	word32 r4_50;
	word32 r5_51;
	word32 r6_52;
	word32 r10_53;
	word32 lr_54;
	word32 pc_55;
	word32 r3_56;
	word32 r2_57;
	word32 r1_58;
	byte NZCV_59;
	byte C_60;
	bcuiposr0 None_61;
	(*r1_22)();
}

// 000086B0: void __libc_csu_fini(Register word32 r5, Register word32 pc, Stack word32 dwArg00)
void __libc_csu_fini(word32 r5, word32 pc, word32 dwArg00)
{
	<anonymous> *** r10_16 = pc + globals->dw8700;
	<anonymous> ** r1_17 = *r10_16;
	if (Z)
		_fini(r5);
	else
	{
		word32 sp_37;
		word32 r4_38;
		word32 r5_39;
		word32 r10_40;
		word32 lr_41;
		word32 pc_42;
		word32 r3_43;
		word32 r2_44;
		word32 r1_45;
		byte NZCV_46;
		byte Z_47;
		(*r1_17)();
	}
}

// 0000870C: Register word32 __do_global_ctors_aux(Stack word32 dwArg00, Register out ptr32 spOut)
word32 __do_global_ctors_aux(word32 dwArg00, ptr32 & spOut)
{
	<anonymous> * r2_9 = globals->ptr8740->ptrFFFFFFFC;
	if (Z)
	{
		word32 sp_28;
		word32 r4_29;
		word32 lr_30;
		word32 pc_31;
		word32 r3_32;
		word32 r2_33;
		byte NZCV_34;
		byte Z_35;
		r2_9();
		return r4_29;
	}
	else
	{
		word32 sp_24;
		*spOut = fp;
		return dwLoc08;
	}
}

// 00008744: void call___do_global_ctors_aux()
void call___do_global_ctors_aux()
{
}

// 0000874C: void _fini(Register word32 lr)
void _fini(word32 lr)
{
	__do_global_dtors_aux(lr);
}

