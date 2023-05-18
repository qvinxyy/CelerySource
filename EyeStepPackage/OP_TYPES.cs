using System;

namespace EyeStepPackage
{
	// Token: 0x02000037 RID: 55
	public enum OP_TYPES : byte
	{
		// Token: 0x040001DD RID: 477
		AL,
		// Token: 0x040001DE RID: 478
		AH,
		// Token: 0x040001DF RID: 479
		AX,
		// Token: 0x040001E0 RID: 480
		EAX,
		// Token: 0x040001E1 RID: 481
		ECX,
		// Token: 0x040001E2 RID: 482
		EDX,
		// Token: 0x040001E3 RID: 483
		ESP,
		// Token: 0x040001E4 RID: 484
		EBP,
		// Token: 0x040001E5 RID: 485
		CL,
		// Token: 0x040001E6 RID: 486
		CX,
		// Token: 0x040001E7 RID: 487
		DX,
		// Token: 0x040001E8 RID: 488
		Sreg,
		// Token: 0x040001E9 RID: 489
		ptr16_32,
		// Token: 0x040001EA RID: 490
		Flags,
		// Token: 0x040001EB RID: 491
		EFlags,
		// Token: 0x040001EC RID: 492
		ES,
		// Token: 0x040001ED RID: 493
		CS,
		// Token: 0x040001EE RID: 494
		DS,
		// Token: 0x040001EF RID: 495
		SS,
		// Token: 0x040001F0 RID: 496
		FS,
		// Token: 0x040001F1 RID: 497
		GS,
		// Token: 0x040001F2 RID: 498
		one,
		// Token: 0x040001F3 RID: 499
		r8,
		// Token: 0x040001F4 RID: 500
		r16,
		// Token: 0x040001F5 RID: 501
		r16_32,
		// Token: 0x040001F6 RID: 502
		r32,
		// Token: 0x040001F7 RID: 503
		r64,
		// Token: 0x040001F8 RID: 504
		r_m8,
		// Token: 0x040001F9 RID: 505
		r_m16,
		// Token: 0x040001FA RID: 506
		r_m16_32,
		// Token: 0x040001FB RID: 507
		r_m16_m32,
		// Token: 0x040001FC RID: 508
		r_m32,
		// Token: 0x040001FD RID: 509
		moffs8,
		// Token: 0x040001FE RID: 510
		moffs16_32,
		// Token: 0x040001FF RID: 511
		m16_32_and_16_32,
		// Token: 0x04000200 RID: 512
		m,
		// Token: 0x04000201 RID: 513
		m8,
		// Token: 0x04000202 RID: 514
		m14_28,
		// Token: 0x04000203 RID: 515
		m16,
		// Token: 0x04000204 RID: 516
		m16_32,
		// Token: 0x04000205 RID: 517
		m16_int,
		// Token: 0x04000206 RID: 518
		m32,
		// Token: 0x04000207 RID: 519
		m32_int,
		// Token: 0x04000208 RID: 520
		m32real,
		// Token: 0x04000209 RID: 521
		m64,
		// Token: 0x0400020A RID: 522
		m64real,
		// Token: 0x0400020B RID: 523
		m80real,
		// Token: 0x0400020C RID: 524
		m80dec,
		// Token: 0x0400020D RID: 525
		m94_108,
		// Token: 0x0400020E RID: 526
		m128,
		// Token: 0x0400020F RID: 527
		m512,
		// Token: 0x04000210 RID: 528
		rel8,
		// Token: 0x04000211 RID: 529
		rel16,
		// Token: 0x04000212 RID: 530
		rel16_32,
		// Token: 0x04000213 RID: 531
		rel32,
		// Token: 0x04000214 RID: 532
		imm8,
		// Token: 0x04000215 RID: 533
		imm16,
		// Token: 0x04000216 RID: 534
		imm16_32,
		// Token: 0x04000217 RID: 535
		imm32,
		// Token: 0x04000218 RID: 536
		mm,
		// Token: 0x04000219 RID: 537
		mm_m64,
		// Token: 0x0400021A RID: 538
		xmm,
		// Token: 0x0400021B RID: 539
		xmm0,
		// Token: 0x0400021C RID: 540
		xmm_m32,
		// Token: 0x0400021D RID: 541
		xmm_m64,
		// Token: 0x0400021E RID: 542
		xmm_m128,
		// Token: 0x0400021F RID: 543
		STi,
		// Token: 0x04000220 RID: 544
		ST1,
		// Token: 0x04000221 RID: 545
		ST2,
		// Token: 0x04000222 RID: 546
		ST,
		// Token: 0x04000223 RID: 547
		LDTR,
		// Token: 0x04000224 RID: 548
		GDTR,
		// Token: 0x04000225 RID: 549
		IDTR,
		// Token: 0x04000226 RID: 550
		PMC,
		// Token: 0x04000227 RID: 551
		TR,
		// Token: 0x04000228 RID: 552
		XCR,
		// Token: 0x04000229 RID: 553
		MSR,
		// Token: 0x0400022A RID: 554
		MSW,
		// Token: 0x0400022B RID: 555
		CRn,
		// Token: 0x0400022C RID: 556
		DRn,
		// Token: 0x0400022D RID: 557
		CR0,
		// Token: 0x0400022E RID: 558
		DR0,
		// Token: 0x0400022F RID: 559
		DR1,
		// Token: 0x04000230 RID: 560
		DR2,
		// Token: 0x04000231 RID: 561
		DR3,
		// Token: 0x04000232 RID: 562
		DR4,
		// Token: 0x04000233 RID: 563
		DR5,
		// Token: 0x04000234 RID: 564
		DR6,
		// Token: 0x04000235 RID: 565
		DR7,
		// Token: 0x04000236 RID: 566
		IA32_TIMESTAMP_COUNTER,
		// Token: 0x04000237 RID: 567
		IA32_SYS,
		// Token: 0x04000238 RID: 568
		IA32_BIOS,
		// Token: 0x04000239 RID: 569
		NONE
	}
}
