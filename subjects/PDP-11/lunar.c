// lunar.c
// Generated by decompiling lunar.lda
// using Reko decompiler version 0.6.2.0.

#include "lunar.h"

void fn00E0(word16 * r0, word16 * r2, ci16 r4, word16 pc)
{
	sp = fp;
	r0 = r0 - 0x02;
	r2 = r2 - 0x02;
	*r2 + 0x00 = *r0;
	r1 = 8188;
	r1 = 8188 - r0;
	r1 = r1 >> 0x01;
	r1 = r1 >> 0x01;
	NZVC = cond(r1);
	fn00EC(r0, r1, r4, pc);
	return;
}

void fn00EC(word16 * r0, int16 r1, ci16 r4, word16 pc)
{
	do
	{
		*r0 = 0xF700;
		word16 * r0_8 = r0 + 0x01;
		*r0_8 = 0x00;
		r0 = r0_8 + 0x01;
		r1 = r1 - 0x01;
	} while (r1 > 0x00);
	word16 * r0_15 = globals->a34E0;
	ci16 r1_19 = 711;
	do
	{
		*r0_15 = 0xF700;
		word16 * r0_25 = r0_15 + 0x01;
		*r0_25 = 0x00;
		r0_15 = r0_25 + 0x01;
		r1_19 = r1_19 - 0x01;
	} while (r1_19 > 0x00);
	*(word16 *) ~0x01 = 0x00;
	word16 * r0_35 = globals->a013E;
	while (true)
	{
		word16 * v17_39 = *r0_35;
		word16 * r0_40 = r0_35 + 0x01;
		if (v17_39 == null)
			break;
		*v17_39 = *r0_40;
		r0_35 = r0_40 + 0x01;
	}
	fn0122(r4, pc);
	return;
}

void fn0122(ci16 r4, word16 pc)
{
	while (true)
		fn0128(r4, pc);
}

void fn0128(ci16 r4, word16 pc)
{
	__wait();
	word16 r0_3 = globals->w006C;
	if (r0_3 != 0x00)
	{
		globals->w006C = 0x00;
		globals->w006E = r0_3;
		fn053A(r4, pc);
	}
	return;
}

void fn0204()
{
	sp = fp;
	__halt();
}

void fn0242(word16 r0)
{
	globals->w0080 = 0x00;
	globals->w0082 = 0x00;
	globals->w0086 = 0x7FFF;
	ci16 r2_18 = fn02C8(r0 + 0x02);
}

word16 fn02C8(Eq_166 * r4)
{
	fn125E((int16) r4->b0000, globals->w004A);
	fn125E((int16) r4->b0001, globals->w004C);
	return fn125E((int16) r4->b0001, globals->w004A) + fn125E((int16) r4->b0000, globals->w004C);
}

void fn0300(ci16 r4)
{
	if (globals->w0068 == 0x00)
	{
		globals->w25C0 = 0xF700;
		globals->w0066 = 0x00;
		globals->w006A = 14300;
		globals->w006A = globals->w006A + globals->w0068;
		globals->w004E = 0x00;
		globals->w0050 = 0x00;
		globals->w0052 = 62866;
		return;
	}
	else
	{
		word16 * r3_100;
		ci16 r2_24;
		word16 * r3_25;
		fn114A(globals->ptr0064, 10500, out r2_24, out r3_25);
		ci16 r3_30;
		fn126C(100, r2_24, r3_25, out r3_30);
		globals->w0066 = r3_30;
		ci16 r2_37;
		word16 * r3_38;
		fn114A(globals->w006E, r3_30, out r2_37, out r3_38);
		word16 r3_43;
		fn126C(1500, r2_37, r3_38, out r3_43);
		ci16 r3_45 = r3_43 - globals->w0068;
		if (r3_45 >= 0x00)
		{
			globals->w25C0 = 0xF700;
			r3_100 = null;
		}
		else
		{
			r3_100 = -r3_45;
			if (globals->w25C0 != 0x00 && 2000 - r3_100 < 0x00)
			{
				globals->w25C0 = 0x00;
				*(word16 *) 62466 = *(word16 *) 62466;
			}
		}
		globals->w0068 = r3_100;
		word16 r3_57;
		fn126C(0x0A, 0x00, r3_100, out r3_57);
		globals->w006A = r3_57 + 14300;
		ci16 r2_66;
		word16 * r3_67;
		fn114A(globals->w0066, 0x3ED7, out r2_66, out r3_67);
		word16 * r3_73;
		fn126C(r4, r2_66, r3_67, out r3_73);
		globals->w004E = r3_73;
		globals->w0050 = fn125E(r3_73, globals->w004A);
		globals->w0052 = fn125E(globals->w004E, globals->w004C) - 0x0A6E;
		return;
	}
}

void fn03CE()
{
	int16 r2_9 = (int16) (globals->ptr0064 >> 0x03)->b2766;
	globals->w008A = globals->w008A + 0x01;
	Eq_437 r2_14 = r2_9 + (int16) (globals->w008A & ~~0x1F)->b2773;
	globals->w008C = r2_14.u0;
	ci16 r4_19 = 0x0C;
	byte * r5_20 = globals->a27B0;
	byte * r3_21 = (globals->w008C & ~~0x03) + 10131;
	do
	{
		*r5_20 = *r3_21;
		union Eq_437 * r5_30 = r5_20 + 0x01;
		*r5_30 = (union Eq_437 *) r2_14;
		r3_21 = r3_21 + 0x01;
		r5_20 = (byte *) r5_30;
		r4_19 = r4_19 - 0x01;
	} while (r4_19 > 0x00);
	globals->w0090 = globals->w0090 + 0x01;
	globals->w0090 = globals->w0090 & ~~0x03;
	globals->w008E = globals->w008E + 0x0180;
	globals->w008E = globals->w008E & ~~0x0380;
	globals->w27A8 = 0x8C54;
	globals->w27A8 = globals->w27A8 | globals->w0090;
	globals->w27A8 = globals->w27A8 | globals->w008E;
	fn0242(0x27A2);
	return;
}

void fn0444()
{
	ci16 r0_15 = globals->w0046;
	if (r0_15 <= 0x00)
	{
		do
		{
			if (65356 - r0_15 > 0x00)
				goto l0464;
			r0_15 = r0_15 + 0x0168;
		} while (r0_15 > 0x00);
	}
	else
	{
		do
		{
			if (0xB4 - r0_15 <= 0x00)
				goto l0464;
			r0_15 = r0_15 - 0x0168;
		} while (r0_15 < 0x00);
	}
l0464:
	globals->w0046 = r0_15;
	if (v12 <= 0x00)
		r0_15 = r0_15 + 0x0168;
	struct Eq_600 * r0_16 = r0_15 << 0x01;
	globals->w004A = r0_16->w31DC;
	if (0x021C - r0_16 >= 0x00)
		r0_16 = r0_16 - 0x02D0;
	globals->w004C = r0_16->w3290;
	return;
}

word16 * fn0488()
{
	ci16 r1_155 = globals->w0050;
	if (r1_155 <= 0x00)
		r1_155 = -r1_155;
	ci16 r2_13;
	word16 * r3_14;
	fn114A(globals->w006E, r1_155, out r2_13, out r3_14);
	ci16 r3_153;
	fn126C(3000, r2_13, r3_14, out r3_153);
	if (globals->w0050 <= 0x00)
		r3_153 = -r3_153;
	ci16 r3_31 = (r3_153 >> 0x01) + globals->w0054;
	globals->w0054 = globals->w0054 + r3_153;
	ci16 r1_151 = r3_31;
	if (r3_31 <= 0x00)
		r1_151 = -r3_31;
	word16 r2_46;
	word16 r3_47;
	fn114A(globals->w006E, r1_151, out r2_46, out r3_47);
	word16 * r3_50 = r3_47 + globals->w0056;
	word16 r3_149;
	word16 * r2_56 = fn126C(600, r3_50 < null, r3_50, out r3_149);
	if (r3_31 <= 0x00)
		r3_149 = -r3_149;
	globals->w005C = globals->w005C + r3_149;
	globals->w0056 = r2_56;
	ci16 r1_147 = globals->w0052;
	if (r1_147 <= 0x00)
		r1_147 = -r1_147;
	ci16 r2_80;
	word16 * r3_81;
	fn114A(globals->w006E, r1_147, out r2_80, out r3_81);
	ci16 r3_145;
	fn126C(3000, r2_80, r3_81, out r3_145);
	if (globals->w0052 <= 0x00)
		r3_145 = -r3_145;
	ci16 r3_98 = (r3_145 >> 0x01) + globals->w0058;
	globals->w0058 = globals->w0058 + r3_145;
	ci16 r1_104 = r3_98;
	if (r3_98 <= 0x00)
		r1_104 = -r3_98;
	word16 r2_113;
	word16 r3_114;
	fn114A(globals->w006E, r1_104, out r2_113, out r3_114);
	word16 * r3_117 = r3_114 + globals->w005A;
	word16 r3_122;
	word16 * r2_123 = fn126C(600, r3_117 < null, r3_117, out r3_122);
	if (r3_98 <= 0x00)
		r3_122 = -r3_122;
	globals->w005E = globals->w005E + r3_122;
	globals->w005A = r2_123;
	return r2_123;
}

void fn053A(ci16 r4, word16 pc)
{
fn053A_entry:
l053A:
	globals->w0084 = ~0x3F
	ci16 r5_19 = globals->w0044
	globals->w0044 = 0x00
	word16 * r0_22 = globals->w006E
	ci16 r1_23 = r5_19
	branch r5_19 > 0x00 l0552
l0550:
	r1_23 = -r5_19
l0552:
	word16 r2_29
	word16 r3_30
	fn114A(r0_22, r1_23, out r2_29, out r3_30)
	word16 * r3_33 = r3_30 + globals->w0048
	word16 r3_38
	word16 * r2_39 = fn126C(0x3C, r3_33 < null, r3_33, out r3_38)
	branch r5_19 > 0x00 l056A
l0568:
	r3_38 = -r3_38
l056A:
	globals->w0046 = globals->w0046 + r3_38
	globals->w0048 = r2_39
	fn0444()
	globals->w0092 = globals->w0092 + 0x02
	word16 r1_59 = (globals->w0092 & ~~0x02)->w34AC
	fn0242(9944)
	globals->w34BA = r1_59
	globals->w0088 = globals->w0086
	globals->ptr0064 = globals->w0060
	fn0300(r4)
	word16 * r2_74 = fn0488()
	int16 r4_77 = globals->w005C + 22400 >> 0x01
	globals->w0072 = r4_77 >> 0x04
	struct Eq_939 * r4_84 = r4_77 >> 0x04 << 0x01
	ci16 r0_89 = r4_84->w28F0 + r4_84->w28F2
	globals->w007C = r0_89 >> 0x01
	word16 * r0_101 = globals->w005E - (r0_89 >> 0x01)
	globals->ptr007E = r0_101
	branch false l05F2
l05E2:
	fn03CE()
	globals->w34C2 = 0x3588
	r0_101 = &globals->w3588
	goto l05F6
l05F2:
	globals->w34C2 = 0x00
l05F6:
	ci16 r0_112
	word16 r1_110
	r4 = globals->w0072
	branch r4 < 0x00 || 0x0A - r4 <= 0x00 l0668
	goto l0602
l05FC:
l0602:
	branch 0x037A - r4 >= 0x00 l0672
l0608:
	r4 = globals->w005E
	branch r4 < 0x00 l06B4
l060E:
	branch 25000 - r4 >= 0x00 l067C
l0614:
	branch 0x01C2 - r4 <= 0x00 l06B4
l061A:
	globals->w34B4 = globals->w0072
	ci16 r4_327 = (r4 >> 0x05) + 0x2B
	globals->w34B6 = r4_327
	branch globals->w009E == 0x00 l0640
l0638:
	fn0CEC(r0_101, r2_74, r4_327, r4_77 >> 0x04, pc)
	globals->w009E = 0x00
l0640:
	word16 r4_338
	fn1578(r0_101, pc, out r4_338)
	branch globals->ptr007E > 0x10 l0666
l064E:
	ci16 r4_355
	struct Eq_1074 * r5_356
	word16 * r0_357 = fn0E06(0x0280, out r4_355, out r5_356)
	globals->w009E = fp
	fn0CEC(r0_357, r2_74, r4_355, r5_356, pc)
	globals->w009E = 0x00
	fn0E32()
l0666:
	return
l0668:
	r0_112 = 0x0D
	r1_110 = 8188
	goto l0682
l0672:
	r0_112 = 0x0377
	r1_110 = 8220
	goto l0682
l067C:
	r0_112 = r4
	r1_110 = 0x2062
l0682:
	globals->w005C = (r0_112 << 0x05) - 22400
	globals->w34CA = r1_110
	globals->w0068 = 0x00
	globals->w0054 = 0x00
	ci16 r3_125 = globals->w005E
	int16 r3_127 = r3_125 >> 0x02
	branch r3_125 >> 0x02 < 0x00 l06AC
l06AA:
	r3_127 = -(r3_125 >> 0x02)
l06AC:
	globals->w0058 = r3_127
	goto l053A
l06B4:
	cui16 r0_281
	int16 r0_176
	branch *fp - globals->w009E == 0x00 l0792
l06BA:
	r0_281 = globals->w0072 - 0x09
l06C2:
	globals->w0074 = r0_281
	word16 * r0_288 = (r0_281 << 0x05) - 22400
	globals->w0076 = r0_288
	fn0F04(r0_288, r2_74, r4, r4_77 >> 0x04, pc)
	globals->w009E = *fp
	r0_176 = globals->w005C - globals->w0076
l06E8:
	int16 r3_218
	int16 r3_179 = r0_176 * 0x03
	globals->w34B4 = r3_179 >> 0x01
	word16 r3_187
	word16 * r2_188 = fn126C(0x30, 0x00, r3_179 >> 0x01, out r3_187)
	ui16 r3_189 = r3_187 + globals->w0074
	globals->w0078 = r3_189
	word16 r3_200
	fn123A(0x30 - r2_188, globals->a28F0[r3_189 * 0x02], out r3_200)
	*(fp - 0x02) = r3_200
	word16 r3_208
	fn123A(r2_188, globals->a28F2[r3_189 * 0x02], out r3_208)
	word16 * r3_214 = r3_208 + *(fp - 0x02)
	branch r3_214 > null l073A
l0730:
	word16 r3_273
	fn126C(0x30, 0x00, -r3_214, out r3_273)
	r3_218 = -r3_273
	goto l073E
l073A:
	fn126C(0x30, 0x00, r3_214, out r3_218)
l073E:
	ci16 r3_245
	globals->w007C = r3_218 >> 0x02
	wchar_t r4_228 = fn100C(r3_218)
	globals->w007A = r4_228
	int16 r3_234 = globals->w005E * 0x03 >> 0x01
	globals->w34B6 = r3_234 + 0x17
	globals->w34B6 = globals->w34B6 + 0x18
	ci16 r3_239 = r3_234 + 0x17 - r4_228
	r3_245 = r3_239
	branch r3_239 > 0x00 l0772
l0770:
	r3_245 = -r3_239
l0772:
	word16 r3_251
	word16 * r2_252 = fn126C(0x03, 0x00, r3_245 << 0x01, out r3_251)
	branch r3_239 > 0x00 l0784
l0782:
	r3_251 = -r3_251
l0784:
	globals->ptr007E = r3_251
	fn0856(&globals->w0003, r2_252, pc)
	fn0A0A()
	return
l0792:
	r0_176 = globals->w005C - globals->w0076
	branch 0x1E - r0_176 <= 0x00 l07AE
l07A0:
	branch 0x0244 - r0_176 < 0x00 l06E8
l07A6:
	r0_281 = globals->w0072 - 0x01
	goto l06C2
l07AE:
	r0_281 = globals->w0072 - 0x11
	goto l06C2
fn053A_exit:
}

void fn0856(word16 * r0, word16 * r2, word16 pc)
{
	word16 * r0_196;
	ci16 r4_11;
	fn1578(r0, pc, out r4_11);
	ci16 r5_7 = globals->ptr007E;
	if (r5_7 >= 0x00)
	{
		if (0x03 - r5_7 > 0x00)
		{
			r4_11 = globals->w0058;
			if (64936 - r4_11 >= 0x00)
			{
				if (65236 - r4_11 >= 0x00)
				{
					if (~0x95 - r4_11 >= 0x00)
					{
						if (8458 - globals->w34CA == 0x00)
							globals->w34CA = 0x00;
					}
					else
						globals->w34CA = 8458;
				}
				else
					globals->w34CA = 8408;
			}
			else
				globals->w34CA = 0x20AC;
l0888:
			ui16 r0_12 = globals->w0078;
			fn0CCA(r4_11, r0_12);
			word16 sp_23;
			word16 r5_24;
			byte NZ_25;
			bool V_26;
			bool N_27;
			byte NZVC_28;
			byte NZV_29;
			word16 r4_30;
			byte NV_31;
			bool Z_32;
			bool C_33;
			word16 r0_34;
			word16 r1_35;
			word16 r2_36;
			word16 r3_37;
			word16 pc_38;
			(*globals->a0FEC)();
			return;
		}
	}
	else if (~0x09 - r5_7 <= 0x00)
		goto l0904;
	globals->w0060 = 0x00;
	globals->w25AA = 0x01C2;
	globals->w34C2 = 0x00;
	globals->w34D2 = 0x00;
	if (r5_7 != 0x00 && r5_7 > 0x00)
		goto l0888;
	ci16 r4_216 = globals->w0058;
	if (64936 - r4_216 > 0x00)
	{
		if (65236 - r4_216 > 0x00)
		{
			if (~0x95 - r4_216 > 0x00)
			{
				if (~0x4F - r4_216 > 0x00)
					r0_196 = &globals->w214E;
				else
					r0_196 = &globals->w2176;
			}
			else
				r0_196 = &globals->w21A4;
		}
		else
			r0_196 = &globals->w21CE;
l091E:
		ci16 r0_149;
		word16 r1_150;
		globals->w34C2 = 0x00;
		globals->w34CA = r0_196;
		if (100 - globals->w0054 > 0x00 || ~0x63 - globals->w0054 < 0x00)
		{
l0964:
			r0_149 = globals->w0054;
			r1_150 = 0x22C6;
			goto l097C;
		}
		else
		{
			if (~0x0E - globals->w0046 >= 0x00 && 0x0F - globals->w0046 <= 0x00)
			{
				ui16 r1_168 = globals->w0078;
				r0_149 = globals->a28F2[r1_168 * 0x02] - (globals->a28F0)[r1_168 * 0x02];
				ci16 r2_173 = r0_149;
				if (r0_149 <= 0x00)
					r2_173 = -r0_149;
				if (0x30 - r2_173 < 0x00)
				{
					fn0B06(pc);
					goto l0964;
				}
				r1_150 = 8980;
			}
			else
			{
				r0_149 = globals->w0046;
				r1_150 = 0x2258;
			}
l097C:
			globals->w34C2 = r1_150;
			ui16 r1_61 = globals->w0078;
			ptr16 wLoc02_141 = 0x03;
			if (r0_149 >= 0x00)
				wLoc02_141 = 0x04;
			fn0C90(wLoc06, r1_61, wLoc02_141);
			ui16 r2_80 = globals->a28F2[r1_61 * 0x02] - (globals->a28F0)[r1_61 * 0x02];
			ci16 r2_86 = r2_80 - (r2_80 * 0x03 >> 0x02);
			ci16 r2_132 = r2_86 + (r2_86 >> 0x01);
			if (r2_132 <= 0x00)
			{
				if (~0x2C - r2_132 < 0x00)
					r2_132 = ~0x2C;
			}
			else if (0x2D - r2_132 > 0x00)
				r2_132 = 0x2D;
			ci16 r3_103 = 0x5A;
			if (r0_149 <= 0x00)
				r3_103 = -0x5A;
			globals->w0046 = r2_132 + r3_103;
			struct Eq_1676 * r1_110 = globals->w0092 + 0x02 & ~~0x02;
			globals->w0092 = r1_110;
			*(fp - 0x06) = r1_110->w34AC;
			fn0444();
			fn0242(9944);
			globals->w34BA = *(fp - 0x06);
			globals->w34B6 = globals->w34B6 - 0x07;
			fn13AA(pc, wLoc02_141);
		}
	}
l0904:
	globals->w34CA = 0x2212;
	ci16 r4_194;
	struct Eq_1323 * r5_195;
	r0_196 = fn0E06(0x20, out r4_194, out r5_195);
	fn0F04(r0_196, r2, r4_194, r5_195, pc);
	globals->w34BA = 0x00;
	fn0E32();
	goto l091E;
}

word16 * fn0A0A()
{
	if (0x96 - globals->ptr007E < 0x00)
	{
		ci16 r4_138 = globals->ptr0064;
		if (0x3F - r4_138 > 0x00)
			r4_138 = 0x3F;
		word16 r4_38 = __rol(r4_138, r4_138);
		word16 r4_39 = __rol(r4_38, r4_38);
		word16 r4_40 = __rol(r4_39, r4_39);
		cui16 r4_42 = __rol(r4_40, r4_40) & ~~0x0380;
		globals->w35CA = r4_42 | 0x9C50;
		r4 = r4_42 | 0x9C50;
		if (0x2D - globals->w0046 <= 0x00 && ~0x2C - globals->w0046 >= 0x00)
		{
			ci16 r1_136 = globals->w004A;
			if (r1_136 <= 0x00)
				r1_136 = -r1_136;
			word16 * r0_60 = globals->w34B6 - globals->w007A;
			ci16 r2_65;
			word16 * r3_66;
			fn114A(r0_60, r1_136, out r2_65, out r3_66);
			word16 r3_134;
			fn126C(globals->w004C, r2_65, r3_66, out r3_134);
			ci16 r4_73 = r0_60 + r3_134;
			if (globals->w004A >= 0x00)
				r3_134 = -r3_134;
			globals->w35CC = r3_134 + globals->w34B4;
			globals->w35CE = globals->w007A;
			globals->w35D0 = 0xB000;
			r4 = r4_73 - 0x96;
			if (r4_73 <= 0x96)
			{
				r4 = 0x96 - r4_73;
				word16 r2_100;
				ci16 r3_101;
				fn114A(r4, globals->ptr0064, out r2_100, out r3_101);
				if (r3_101 >> 0x04 != 0x00)
					;
			}
		}
	}
	globals->w34D2 = 0x00;
	return r4;
}

void fn0B06(word16 pc)
{
	fn13AA(pc, ptrLoc02);
}

void fn0C90(word16 wArg00, ui16 wArg02, ptr16 wArg04)
{
	if (wArg02 >> 0x01 < 0x00)
	{
		(wArg02 >> 0x01)->w3013 = (wArg02 >> 0x01)->w3013 & ~0xF0;
		wArg04 = wArg04 << 0x04;
	}
	else
		(wArg02 >> 0x01)->w3013 = (wArg02 >> 0x01)->w3013 & ~0x0F;
	(wArg02 >> 0x01)->w3013 = (wArg02 >> 0x01)->w3013 | wArg04;
	return;
}

void fn0CCA(ci16 r4, ui16 wArg02)
{
	return;
}

void fn0CEC(word16 * r0, word16 * r2, ci16 r4, Eq_1074 * r5, word16 pc)
{
	fn0D3C(r0, r2, r4, pc);
	word16 r4_13 = (*globals->a28F0 >> 0x05) + 0x17;
	r5->w0000 = r4_13;
	globals->w0082 = r4_13;
	r5->w0002 = 0x8C50;
	cui16 * r5_22 = r5->w0002 + 0x01;
	struct Eq_1945 * r0_23 = globals->a28F0;
	while (true)
	{
		r0_23 = r0_23 + 0x01;
		r5_22 = fn0D78((r0_23->w0000 >> 0x05) + 0x17, r5_22, wLoc02);
	}
}

void fn0D3C(word16 * r0, word16 * r2, ci16 r4, word16 pc)
{
fn0D3C_entry:
	sp = fp
	sp = fp - 0x02
	wLoc02 = r2
	sp = fp - 0x04
	wLoc04 = r3
	sp = fp - 0x06
	wLoc06 = r0
	sp = fp - 0x08
	wLoc08 = r1
	sp = fp - 0x0A
	wLoc0A = r4
	globals->w00A0 = 225
	globals->w34DA = 0x00
	globals->w07BA = 0x00
	r5 = 6186
	v22 = 38996
	globals->w182A = 38996
	r5 = 6188
	v23 = 0xF0A0
	globals->w182C = 0xF0A0
	r5 = 0x182E
	v24 = 0x00
	globals->w182E = 0x00
	r5 = 0x1830
	C = false
	V = false
	N = false
	Z = true
	switch (fp - 0x0A) { l00E0 l0204 l00E0 l0206 l00E0 l020A }
l0206:
	__halt()
l020A:
	globals->w0096 = 0xCE
	globals->w00CE = 0x1428
	globals->w0094 = 0x00
	*(word16 *) 0xF400 = 0x16F2
	*(word16 *) ~0x99 = 0x40
	sp = 0x3FFE
	*(word16 *) ~0x01 = 0x00
	C = false
	V = false
	N = false
	Z = true
	fn0122(r4, pc)
	return
l022E_thunk_fn0122:
l0D3C:
l0D62_thunk_fn00E0:
	fn00E0(r0, r2, r4, pc)
	return
l0D62_thunk_fn00E0:
	fn00E0(r0, r2, r4, pc)
	return
l0D62_thunk_fn00E0:
	fn00E0(r0, r2, r4, pc)
	return
l0D62_thunk_fn0204:
	fn0204()
	return
fn0D3C_exit:
}

cui16 * fn0D78(wchar_t r4, cui16 * r5, word16 wArg00)
{
	cui16 wLoc02_11 = 0x0200;
	if (0x0400 - r4 >= 0x00)
	{
		r4 = 0x03FF;
		if (globals->w0082 == 0x03FF)
			goto l0D9C;
	}
	if (false)
	{
		r4 = 0x00;
		if (globals->w0082 == 0x00)
		{
l0D9C:
			globals->w00A2 = globals->w00A2 - 0x01;
			if (v19 <= 0x00)
			{
				globals->w00A4 = globals->w00A4 + 0x01;
				globals->w00A4 = globals->w00A4 & ~~0x03;
				globals->w00A4 = globals->w00A4 + 0x01;
				globals->w00A2 = globals->w00A4;
				globals->w00A6 = globals->w00A6 + 0x0280;
				globals->w00A6 = globals->w00A6 & ~~0x0380;
				globals->w00A8 = globals->w00A8 + 0x01;
				globals->w00A8 = globals->w00A8 & ~~0x03;
				*r5 = globals->w00A6;
				*r5 = globals->w00A8 | *r5;
				*r5 = *r5 | 0x8C04;
				r5 = r5 + 0x01;
			}
			cui16 r4_30;
			wchar_t r4_25 = r4 - globals->w0082;
			if (r4_25 <= 0x00)
			{
				cui16 r4_48 = -r4_25 & ~~0x3F;
				globals->w0082 = globals->w0082 - r4_48;
				r4_30 = r4_48 | 0x40;
			}
			else
			{
				r4_30 = r4_25 & ~~0x3F;
				globals->w0082 = globals->w0082 + r4_30;
			}
			*r5 = r4_30 | wLoc02_11;
			globals->w00A0 = globals->w00A0 - 0x01;
			cui16 * r5_37 = r5 + 0x01;
			return r5_37;
		}
	}
	wLoc02_11 = 0x4200;
	goto l0D9C;
}

int16 fn0E06(int16 r0, ptr16 & r4Out, ptr16 & r5Out)
{
	ui16 r1_3 = globals->w0072;
	struct Eq_2281 * r1_6 = (r1_3 << 0x01) + 0x28F0;
	word16 r4_4;
	*r4Out = r1_3;
	ptr16 wLoc02_17 = 0x03;
	word16 * r1_10 = &r1_6->w0002;
	word16 * r3_12 = &r1_6->w0002;
	ci16 r5_13 = r1_6->w0000 - r1_6->w0002;
	*r5Out = r5_13;
	if (r5_13 >= 0x00)
		wLoc02_17 = 0x04;
	fn0C90(wLoc06, r1_3, wLoc02_17);
	do
	{
		*r1_10 = r0 - *r1_10;
		r3_12 = r3_12 - 0x02;
		*r3_12 = r0 - *r3_12;
		r1_10 = r1_10 + 0x01;
		r0 = -(r0 >> 0x01);
	} while (r0 != 0x00);
	return r0;
}

void fn0E32()
{
	globals->w00AE = 0x00;
	globals->w34C2 = 0x00;
	globals->w34D2 = 0x00;
	*(word16 *) 62466 = *(word16 *) 62466;
}

void fn0F04(word16 * r0, word16 * r2, ci16 r4, Eq_1323 * r5, word16 pc)
{
	fn0D3C(r0, r2, r4, pc);
	globals->w00AA = 0x00;
	word16 * r0_40 = (globals->w0074 << 0x01) + 0x28F0;
	wchar_t r4_130 = fn100C(*r0_40);
	if (r4_130 <= 0x00)
		r4_130 = 0x00;
	else if (0x0400 - r4_130 >= 0x00)
		r4_130 = 0x03FF;
	r5->w0000 = r4_130;
	globals->w0082 = r4_130;
	r5->w0002 = 0x8C50;
	cui16 * r5_33 = r5->w0002 + 0x01;
	while (true)
	{
		wchar_t r3_121;
		word16 * r0_48 = r0_40 + 0x01;
		ci16 r1_61 = fn100C(*r0_40) - r4_130;
		if (r1_61 <= 0x00)
		{
			word16 r3_119;
			fn126C(0x0C, 0x00, 0x06 - r1_61, out r3_119);
			r3_121 = -r3_119;
		}
		else
			fn126C(0x0C, 0x00, r1_61 + 0x06, out r3_121);
		ci16 r2_100 = 0x0C;
		r0_40 = r0_48;
		do
		{
			globals->w00AA = globals->w00AA + 0x01;
			if (0x03 - globals->w00AA >= 0x00)
				globals->w0F70 = 0x0ADF;
			else if (~0x02 - globals->w00AA <= 0x00)
				globals->w0F70 = 0x0A9F;
			wchar_t r4_88 = r4_130 + globals->w00AA + r3_121;
			r5_33 = fn0D78(r4_88, r5_33, wLoc04);
			r4_130 = r4_88;
			r2_100 = r2_100 - 0x01;
		} while (r2_100 > 0x00);
	}
}

int16 fn100C(int16 r4)
{
	return (r4 * 0x03 >> 0x03) + 0x17;
}

bool fn114A(word16 * r0, ci16 r1, ptr16 & r2Out, ptr16 & r3Out)
{
	cu16 v10_5 = r0 - r1;
	uint16 r3_104 = 0x00;
	*r3Out = r3_104;
	bool C_22 = cond(v10_5);
	if (v10_5 < 0x00)
	{
		word16 r2_30;
		*r2Out = r1;
		if (r1 != 0x00)
			;
		return C_22;
	}
	word16 r2_39;
	*r2Out = r0;
	if (r0 == null)
		return C_22;
	cu16 r2_292;
	cu16 r2_275;
	cu16 r2_258;
	cu16 r2_241;
	cu16 r2_224;
	cu16 r2_207;
	cu16 r2_190;
	cu16 r2_173;
	cu16 r2_156;
	cu16 r2_139;
	cu16 r2_122;
	cu16 r2_105;
	cu16 r2_102;
	cu16 r2_347;
	cu16 r2_45 = __rol(r0, r0);
	if (r2_45 >= 0x00)
	{
		r2_292 = __rol(r2_45, r2_45);
		if (r2_292 >= 0x00)
		{
			r2_275 = __rol(r2_292, r2_292);
			if (r2_275 >= 0x00)
			{
				r2_258 = __rol(r2_275, r2_275);
				if (r2_258 >= 0x00)
				{
					r2_241 = __rol(r2_258, r2_258);
					if (r2_241 >= 0x00)
					{
						r2_224 = __rol(r2_241, r2_241);
						if (r2_224 >= 0x00)
						{
							r2_207 = __rol(r2_224, r2_224);
							if (r2_207 >= 0x00)
							{
								r2_190 = __rol(r2_207, r2_207);
								if (r2_190 >= 0x00)
								{
									r2_173 = __rol(r2_190, r2_190);
									if (r2_173 >= 0x00)
									{
										r2_156 = __rol(r2_173, r2_173);
										if (r2_156 >= 0x00)
										{
											r2_139 = __rol(r2_156, r2_156);
											if (r2_139 >= 0x00)
											{
												r2_122 = __rol(r2_139, r2_139);
												if (r2_122 >= 0x00)
												{
													r2_105 = __rol(r2_122, r2_122);
													if (r2_105 >= 0x00)
													{
														r2_102 = __rol(r2_105, r2_105);
														if (r2_102 >= 0x00)
														{
															r2_347 = __rol(r2_102, r2_102);
															if (r2_347 >= 0x00)
															{
																word16 r2_350;
																*r2Out = 0x00;
																C_22 = false;
																word16 r3_352;
																*r3Out = r1;
																return C_22;
															}
															goto l122A;
														}
														goto l1220;
													}
													goto l1216;
												}
												goto l120C;
											}
											goto l1202;
										}
										goto l11F8;
									}
									goto l11EE;
								}
								goto l11E4;
							}
							goto l11DA;
						}
						goto l11D0;
					}
					goto l11C6;
				}
				goto l11BC;
			}
			goto l11B2;
		}
	}
	else
	{
		r3_104 = r1 << 0x01;
		r2_292 = __rol(r2_45, r2_45);
		if (r2_292 >= 0x00)
			goto l11AC;
	}
	cu16 r3_299 = r3_104 + r1;
	r3_104 = r3_299 + r1;
	r2_292 = r2_292 + (r3_299 <u 0x00) + (r3_104 <u 0x00);
l11AC:
	r3_104 = r3_104 << 0x01;
	r2_275 = __rol(r2_292, r2_292);
	if (r2_275 >= 0x00)
	{
l11B6:
		r3_104 = r3_104 << 0x01;
		r2_258 = __rol(r2_275, r2_275);
		if (r2_258 >= 0x00)
		{
l11C0:
			r3_104 = r3_104 << 0x01;
			r2_241 = __rol(r2_258, r2_258);
			if (r2_241 >= 0x00)
			{
l11CA:
				r3_104 = r3_104 << 0x01;
				r2_224 = __rol(r2_241, r2_241);
				if (r2_224 >= 0x00)
				{
l11D4:
					r3_104 = r3_104 << 0x01;
					r2_207 = __rol(r2_224, r2_224);
					if (r2_207 >= 0x00)
					{
l11DE:
						r3_104 = r3_104 << 0x01;
						r2_190 = __rol(r2_207, r2_207);
						if (r2_190 >= 0x00)
						{
l11E8:
							r3_104 = r3_104 << 0x01;
							r2_173 = __rol(r2_190, r2_190);
							if (r2_173 >= 0x00)
							{
l11F2:
								r3_104 = r3_104 << 0x01;
								r2_156 = __rol(r2_173, r2_173);
								if (r2_156 >= 0x00)
								{
l11FC:
									r3_104 = r3_104 << 0x01;
									r2_139 = __rol(r2_156, r2_156);
									if (r2_139 >= 0x00)
									{
l1206:
										r3_104 = r3_104 << 0x01;
										r2_122 = __rol(r2_139, r2_139);
										if (r2_122 >= 0x00)
										{
l1210:
											r3_104 = r3_104 << 0x01;
											r2_105 = __rol(r2_122, r2_122);
											if (r2_105 >= 0x00)
											{
l121A:
												r3_104 = r3_104 << 0x01;
												r2_102 = __rol(r2_105, r2_105);
												if (r2_102 >= 0x00)
												{
l1224:
													r3_104 = r3_104 << 0x01;
													r2_347 = __rol(r2_102, r2_102);
													if (r2_347 >= 0x00)
													{
l122E:
														cu16 r2_51 = __rol(r2_347, r2_347);
														*r2Out = r2_51;
														ui16 r3_50 = r3_104 << 0x01;
														*r3Out = r3_50;
														bool C_53 = cond(r2_51);
														if (r2_51 < 0x00)
														{
															cu16 r3_66 = r3_50 + r1;
															*r3Out = r3_66;
															word16 r2_69 = r3_66 < 0x00;
															*r2Out = r2_69;
															C_53 = cond(r2_69);
														}
														return C_53;
													}
l122A:
													cu16 r3_78 = r3_104 + r1;
													r3_104 = r3_78 + r1;
													r2_347 = r2_347 + (r3_78 <u 0x00) + (r3_104 <u 0x00);
													goto l122E;
												}
l1220:
												cu16 r3_95 = r3_104 + r1;
												r3_104 = r3_95 + r1;
												r2_102 = r2_102 + (r3_95 <u 0x00) + (r3_104 <u 0x00);
												goto l1224;
											}
l1216:
											cu16 r3_112 = r3_104 + r1;
											r3_104 = r3_112 + r1;
											r2_105 = r2_105 + (r3_112 <u 0x00) + (r3_104 <u 0x00);
											goto l121A;
										}
l120C:
										cu16 r3_129 = r3_104 + r1;
										r3_104 = r3_129 + r1;
										r2_122 = r2_122 + (r3_129 <u 0x00) + (r3_104 <u 0x00);
										goto l1210;
									}
l1202:
									cu16 r3_146 = r3_104 + r1;
									r3_104 = r3_146 + r1;
									r2_139 = r2_139 + (r3_146 <u 0x00) + (r3_104 <u 0x00);
									goto l1206;
								}
l11F8:
								cu16 r3_163 = r3_104 + r1;
								r3_104 = r3_163 + r1;
								r2_156 = r2_156 + (r3_163 <u 0x00) + (r3_104 <u 0x00);
								goto l11FC;
							}
l11EE:
							cu16 r3_180 = r3_104 + r1;
							r3_104 = r3_180 + r1;
							r2_173 = r2_173 + (r3_180 <u 0x00) + (r3_104 <u 0x00);
							goto l11F2;
						}
l11E4:
						cu16 r3_197 = r3_104 + r1;
						r3_104 = r3_197 + r1;
						r2_190 = r2_190 + (r3_197 <u 0x00) + (r3_104 <u 0x00);
						goto l11E8;
					}
l11DA:
					cu16 r3_214 = r3_104 + r1;
					r3_104 = r3_214 + r1;
					r2_207 = r2_207 + (r3_214 <u 0x00) + (r3_104 <u 0x00);
					goto l11DE;
				}
l11D0:
				cu16 r3_231 = r3_104 + r1;
				r3_104 = r3_231 + r1;
				r2_224 = r2_224 + (r3_231 <u 0x00) + (r3_104 <u 0x00);
				goto l11D4;
			}
l11C6:
			cu16 r3_248 = r3_104 + r1;
			r3_104 = r3_248 + r1;
			r2_241 = r2_241 + (r3_248 <u 0x00) + (r3_104 <u 0x00);
			goto l11CA;
		}
l11BC:
		cu16 r3_265 = r3_104 + r1;
		r3_104 = r3_265 + r1;
		r2_258 = r2_258 + (r3_265 <u 0x00) + (r3_104 <u 0x00);
		goto l11C0;
	}
l11B2:
	cu16 r3_282 = r3_104 + r1;
	r3_104 = r3_282 + r1;
	r2_275 = r2_275 + (r3_282 <u 0x00) + (r3_104 <u 0x00);
	goto l11B6;
}

word16 fn123A(word16 * r0, ci16 r1, ptr16 & r3Out)
{
	if (r0 <= null)
	{
		r0 = -r0;
		if (r1 <= 0x00)
		{
			r1 = -r1;
l1246:
			word16 r2_26;
			word16 r3_27;
			fn114A(r0, r1, out r2_26, out r3_27);
			return r2_26;
		}
	}
	else
	{
		if (r1 > 0x00)
			goto l1246;
		r1 = -r1;
	}
	word16 r2_35;
	word16 r3_36;
	Eq_287 C_37 = fn114A(r0, r1, out r2_35, out r3_36);
	word16 r3_38;
	*r3Out = -r3_36;
	return -C_37;
}

word16 fn125E(word16 * r0, ci16 r1)
{
	word16 r3_4;
	word16 r2_5 = fn123A(r0, r1, out r3_4);
	word16 r2_7 = __rol(r2_5, r2_5);
	return __rol(r2_7, r2_7);
}

ci16 fn126C(ci16 r0, ci16 r2, word16 * r3, Eq_294 & r3Out)
{
	ci16 r2_224;
	ui16 r3_223;
	ci16 r2_209;
	ui16 r3_208;
	ci16 r2_194;
	ui16 r3_193;
	ci16 r2_179;
	ui16 r3_178;
	ci16 r2_164;
	ui16 r3_163;
	ci16 r2_149;
	ui16 r3_148;
	ci16 r2_134;
	ui16 r3_133;
	ci16 r2_119;
	ui16 r3_118;
	ci16 r2_104;
	ui16 r3_103;
	ci16 r2_107;
	ui16 r3_105;
	ci16 r2_100;
	ui16 r3_73;
	ci16 r2_59;
	ui16 r3_58;
	ci16 r2_44;
	ui16 r3_43;
	ci16 r2_29;
	ui16 r3_28;
	ci16 r2_18;
	ui16 r3_23;
	ci16 r2_7 = __rol(r2, r2) - r0;
	if (r2_7 <= 0x00)
	{
		r3_223 = r3 << 0x02;
		r2_224 = __rol(r2_7, r2_7) + r0;
		if (r2_224 <= 0x00)
		{
l127C:
			r3_208 = r3_223 << 0x01;
			r2_209 = __rol(r2_224, r2_224) + r0;
			if (r2_209 <= 0x00)
			{
l1284:
				r3_193 = r3_208 << 0x01;
				r2_194 = __rol(r2_209, r2_209) + r0;
				if (r2_194 <= 0x00)
				{
l128C:
					r3_178 = r3_193 << 0x01;
					r2_179 = __rol(r2_194, r2_194) + r0;
					if (r2_179 <= 0x00)
					{
l1294:
						r3_163 = r3_178 << 0x01;
						r2_164 = __rol(r2_179, r2_179) + r0;
						if (r2_164 <= 0x00)
						{
l129C:
							r3_148 = r3_163 << 0x01;
							r2_149 = __rol(r2_164, r2_164) + r0;
							if (r2_149 <= 0x00)
							{
l12A4:
								r3_133 = r3_148 << 0x01;
								r2_134 = __rol(r2_149, r2_149) + r0;
								if (r2_134 <= 0x00)
								{
l12AC:
									r3_118 = r3_133 << 0x01;
									r2_119 = __rol(r2_134, r2_134) + r0;
									if (r2_119 <= 0x00)
									{
l12B4:
										r3_103 = r3_118 << 0x01;
										r2_104 = __rol(r2_119, r2_119) + r0;
										if (r2_104 <= 0x00)
										{
l12BC:
											r3_105 = r3_103 << 0x01;
											r2_107 = __rol(r2_104, r2_104) + r0;
											if (r2_107 <= 0x00)
											{
l12C4:
												r3_73 = r3_105 << 0x01;
												r2_100 = __rol(r2_107, r2_107) + r0;
												if (r2_100 <= 0x00)
												{
l12CC:
													r3_58 = r3_73 << 0x01;
													r2_59 = __rol(r2_100, r2_100) + r0;
													if (r2_59 <= 0x00)
													{
l12D4:
														r3_43 = r3_58 << 0x01;
														r2_44 = __rol(r2_59, r2_59) + r0;
														if (r2_44 <= 0x00)
														{
l12DC:
															r3_28 = r3_43 << 0x01;
															r2_29 = __rol(r2_44, r2_44) + r0;
															if (r2_29 <= 0x00)
															{
l12E4:
																r3_23 = r3_28 << 0x01;
																*r3Out = r3_23;
																r2_18 = __rol(r2_29, r2_29) + r0;
																if (r2_18 <= 0x00)
																	return r2_18 + r0;
l1386:
																word16 r3_26;
																*r3Out = r3_23 + 0x01;
																return r2_18;
															}
l137C:
															r3_23 = r3_28 + 0x01 << 0x01;
															*r3Out = r3_23;
															r2_18 = __rol(r2_29, r2_29) - r0;
															if (r2_18 < 0x00)
																return r2_18 + r0;
															goto l1386;
														}
l1372:
														r3_28 = r3_43 + 0x01 << 0x01;
														r2_29 = __rol(r2_44, r2_44) - r0;
														if (r2_29 < 0x00)
															goto l12E4;
														goto l137C;
													}
l1368:
													r3_43 = r3_58 + 0x01 << 0x01;
													r2_44 = __rol(r2_59, r2_59) - r0;
													if (r2_44 < 0x00)
														goto l12DC;
													goto l1372;
												}
l135E:
												r3_58 = r3_73 + 0x01 << 0x01;
												r2_59 = __rol(r2_100, r2_100) - r0;
												if (r2_59 < 0x00)
													goto l12D4;
												goto l1368;
											}
l1354:
											r3_73 = r3_105 + 0x01 << 0x01;
											r2_100 = __rol(r2_107, r2_107) - r0;
											if (r2_100 < 0x00)
												goto l12CC;
											goto l135E;
										}
l134A:
										r3_105 = r3_103 + 0x01 << 0x01;
										r2_107 = __rol(r2_104, r2_104) - r0;
										if (r2_107 < 0x00)
											goto l12C4;
										goto l1354;
									}
l1340:
									r3_103 = r3_118 + 0x01 << 0x01;
									r2_104 = __rol(r2_119, r2_119) - r0;
									if (r2_104 < 0x00)
										goto l12BC;
									goto l134A;
								}
l1336:
								r3_118 = r3_133 + 0x01 << 0x01;
								r2_119 = __rol(r2_134, r2_134) - r0;
								if (r2_119 < 0x00)
									goto l12B4;
								goto l1340;
							}
l132C:
							r3_133 = r3_148 + 0x01 << 0x01;
							r2_134 = __rol(r2_149, r2_149) - r0;
							if (r2_134 < 0x00)
								goto l12AC;
							goto l1336;
						}
l1322:
						r3_148 = r3_163 + 0x01 << 0x01;
						r2_149 = __rol(r2_164, r2_164) - r0;
						if (r2_149 < 0x00)
							goto l12A4;
						goto l132C;
					}
l1318:
					r3_163 = r3_178 + 0x01 << 0x01;
					r2_164 = __rol(r2_179, r2_179) - r0;
					if (r2_164 < 0x00)
						goto l129C;
					goto l1322;
				}
l130E:
				r3_178 = r3_193 + 0x01 << 0x01;
				r2_179 = __rol(r2_194, r2_194) - r0;
				if (r2_179 < 0x00)
					goto l1294;
				goto l1318;
			}
l1304:
			r3_193 = r3_208 + 0x01 << 0x01;
			r2_194 = __rol(r2_209, r2_209) - r0;
			if (r2_194 < 0x00)
				goto l128C;
			goto l130E;
		}
	}
	else
	{
		r3_223 = (r3 << 0x01) + 0x01 << 0x01;
		r2_224 = __rol(r2_7, r2_7) - r0;
		if (r2_224 < 0x00)
			goto l127C;
	}
	r3_208 = r3_223 + 0x01 << 0x01;
	r2_209 = __rol(r2_224, r2_224) - r0;
	if (r2_209 < 0x00)
		goto l1284;
	goto l1304;
}

void fn13AA(word16 pc, ptr16 ptrArg00)
{
	word16 * r0_11;
	globals->w25C0 = 0xF700;
	word16 * r0_4 = *ptrArg00;
	r0_11 = r0_4;
	if (r0_4 <= null)
		r0_11 = -r0_4;
	do
		r0_11 = r0_11 - 0x01;
	while (r0_11 > null);
	do
	{
		__wait();
		ci16 r4_17;
	} while (globals->w0070 - fn1578(r0_11, pc, out r4_17) > 0x00);
	if (r0_4 < null)
		return;
	else
	{
		__reset();
		fn00E0(&globals->w182A, r0_4, r4_17, pc);
		return;
	}
}

word16 fn1578(word16 * r0, word16 pc, ptr16 & r4Out)
{
	struct Eq_3179 * r4_20 = null;
	while (true)
	{
		struct Eq_3192 * r5_37 = r4_20[2886];
		if (r5_37 == null)
			break;
		Mem45[Mem0[r4_20 + 0x1696:word16] + 0x12:word16] = r5_37 + 0x0A;
		word16 * r3_46 = *r5_37->ptrFFFC;
		ci16 r0_47 = r5_37->wFFFE;
		if (r0_47 != 0x00)
		{
			if (r3_46 <= null)
				r3_46 = -r3_46;
			fn126C(r0_47, 0x00, r3_46, out r3_46);
			if (*r5_37->ptrFFFC <= null)
				r3_46 = -r3_46;
		}
		fn1674(r3_46, Mem45[r4_20 + 0x1696:word16] + 0x0A, pc);
		r4_20 = r4_20 + 0x01;
	}
	if (globals->w0062 - globals->w0060 != 0x00)
	{
		word16 * r0_119 = globals->w0060;
		globals->w0062 = r0_119;
		fn1674(r0_119, &globals->t25B8, pc);
	}
	word16 r4_102;
	*r4Out = r4;
	return r1;
}

Eq_3217 * fn15F2(word16 * r0, Eq_3217 * r1, word16 pc)
{
	word16 wLoc02_14;
	r1->t0000.u0 = 0x20;
	if (10000 - r0 < 0x00)
	{
		r1->b0001 = 0x20;
		wLoc02_14 = 0x00;
	}
	else
	{
		r1->b0001 = 0x30;
		wLoc02_14 = pc;
		while (10000 - r0 >= 0x00)
		{
			r1->b0001 = r1->b0001 + 0x01;
			r0 = r0 - 10000;
		}
	}
	union Eq_3267 * r3_25;
	word16 * r2_24;
	if (100 - r0 >= 0x00)
	{
		cui16 r3_51;
		r2_24 = fn126C(100, 0x00, r0, out r3_51);
		r3_25 = (r3_51 << 0x01) + 10260;
	}
	else
	{
		r2_24 = r0;
		r3_25 = &globals->t2814;
	}
	union Eq_3267 * r3_26;
	struct Eq_3217 * r1_27 = fn1658(r1->b0001 + 0x01, r3_25, wLoc02_14, out r3_26);
	word16 r3_28;
	union Eq_3267 * r3_34;
	struct Eq_3217 * r1_35 = fn1658(fn1658(r1_27, r3_26, wLoc02_14, out r3_28), (r2_24 << 0x01) + 10260, wLoc02_14, out r3_34);
	word16 r3_41;
	return fn1658(r1_35, r3_34, pc, out r3_41);
}

Eq_3217 * fn1658(Eq_3217 * r1, Eq_3267 * r3, word16 wArg02, ptr16 & r3Out)
{
	if (wArg02 == 0x00)
	{
		if (0x30 - *r3 == 0x00)
		{
			r1->t0000.u0 = 0x20;
			return &r1->b0001;
		}
	}
	r1->t0000 = *r3;
	return &r1->b0001;
}

void fn1674(word16 * r0, Eq_3217 * r1, word16 pc)
{
	if (r0 > null)
	{
		fn15F2(r0, r1, pc);
		return;
	}
	else
	{
		word16 * r0_21 = fn15F2(-r0, r1, pc);
		do
			r0_21 = r0_21 - 0x02;
		while (*r0_21 != 0x20);
		*r0_21 = (word16) 0x2D;
		return;
	}
}

void fn34E0(word16 pc)
{
	__reset();
	__reset();
	__reset();
	__reset();
	__reset();
	*(word16 *) ~0x01 = 0x00;
	globals->w0004 = 13638;
	globals->w0006 = 0x00;
	*(word16 *) ~0x0471 = 0x00;
	fn355A();
	*(word16 *) ~0x0471 = 131;
	fn355A();
	*(word16 *) ~0x0471 = 131;
	fn355A();
	*(word16 *) ~0x0471 = 0x4B;
	fn355A();
	*(word16 *) ~0x0471 = 0x2F;
	fn355A();
	*(word16 *) ~0x0471 = 0x46;
	fn355A();
	*(word16 *) ~0x0471 = 0x0D;
	fn355A();
	*(word16 *) ~0x99 = 0x40;
	*(word16 *) 0xF400 = 13666;
	fn13AA(pc, ptrLoc02);
}

void fn355A()
{
	do
		;
	while (*(ci8 *) 64396 > 0x00);
	return;
}
