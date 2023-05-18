using System;
using System.Collections.Generic;

namespace CeleryApp.CeleryAPI
{
	public class Yara : Util
	{
		public static void setCave(Util.ProcInfo pinfo, int start, int end)
		{
			Yara.codeCaveStart = start;
			Yara.codeCaveEnd = end;
			Yara.codeCaveAt = Yara.codeCaveStart;
			byte[] array = new byte[end - start];
			Array.Clear(array, 0, array.Length);
			pinfo.writeBytes(Yara.codeCaveStart, array, array.Length);
		}

		public static int silentAlloc(Util.ProcInfo pinfo, int size, uint protect)
		{
			bool flag = Yara.codeCaveStart == 0 || Yara.codeCaveAt == 0;
			int result;
			if (flag)
			{
				result = Imports.VirtualAllocEx(pinfo.handle, 0, size, 4096U, protect);
			}
			else
			{
				int num = Yara.codeCaveAt;
				pinfo.setPageProtect(Yara.codeCaveAt, size, protect);
				Yara.codeCaveAt += size + size % 4;
				result = num;
			}
			return result;
		}

		public static List<int> getRbxWow64Clone(Util.ProcInfo pinfo)
		{
			List<int> list = new List<int>();
			int num = 0;
			Imports.MEMORY_BASIC_INFORMATION memory_BASIC_INFORMATION;
			while (Imports.VirtualQueryEx(pinfo.handle, num, out memory_BASIC_INFORMATION, 28U) != 0)
			{
				bool flag = memory_BASIC_INFORMATION.AllocationProtect == 64U && memory_BASIC_INFORMATION.State == 4096U;
				if (flag)
				{
					bool flag2 = pinfo.readByte(num + 10) == 234 && pinfo.readByte(num + 101) != 233;
					if (flag2)
					{
						list.Add(num);
					}
				}
				num += memory_BASIC_INFORMATION.RegionSize;
			}
			return list;
		}

		public static byte[] makePayload(int stackRef)
		{
			byte[] bytes = BitConverter.GetBytes(stackRef);
			byte[] array = new byte[]
			{
				byte.MaxValue,
				210,
				86,
				87,
				83,
				82,
				191,
				0,
				0,
				0,
				0,
				139,
				63,
				139,
				116,
				36,
				20,
				137,
				55,
				139,
				116,
				36,
				24,
				137,
				119,
				4,
				139,
				116,
				36,
				28,
				137,
				119,
				8,
				139,
				116,
				36,
				32,
				137,
				119,
				12,
				139,
				116,
				36,
				36,
				137,
				119,
				16,
				191,
				0,
				0,
				0,
				0,
				131,
				124,
				36,
				24,
				0,
				119,
				7,
				199,
				71,
				4,
				0,
				0,
				0,
				0,
				139,
				116,
				36,
				32,
				129,
				126,
				16,
				0,
				16,
				0,
				0,
				116,
				25,
				129,
				126,
				16,
				0,
				32,
				0,
				0,
				116,
				16,
				129,
				126,
				16,
				0,
				48,
				0,
				0,
				116,
				7,
				90,
				91,
				95,
				94,
				194,
				24,
				0,
				144,
				144,
				144,
				144,
				144,
				144,
				144,
				144,
				144,
				144,
				144,
				144,
				131,
				126,
				20,
				64,
				116,
				7,
				90,
				91,
				95,
				94,
				194,
				24,
				0,
				139,
				116,
				36,
				32,
				199,
				70,
				8,
				1,
				0,
				0,
				0,
				199,
				70,
				16,
				0,
				0,
				1,
				0,
				199,
				70,
				20,
				1,
				0,
				0,
				0,
				139,
				116,
				36,
				24,
				191,
				0,
				0,
				0,
				0,
				131,
				127,
				4,
				32,
				119,
				14,
				131,
				71,
				4,
				4,
				139,
				223,
				3,
				95,
				4,
				131,
				195,
				4,
				137,
				51,
				90,
				91,
				95,
				94,
				194,
				24,
				0
			};
			array[7] = bytes[0];
			array[8] = bytes[1];
			array[9] = bytes[2];
			array[10] = bytes[3];
			array[48] = bytes[0];
			array[49] = bytes[1];
			array[50] = bytes[2];
			array[51] = bytes[3];
			array[159] = bytes[0];
			array[160] = bytes[1];
			array[161] = bytes[2];
			array[162] = bytes[3];
			return array;
		}

		public static bool Bypass(Util.ProcInfo pinfo)
		{
			int procAddress = Imports.GetProcAddress(Imports.GetModuleHandle("combase.dll"), "ObjectStublessClient3");
			bool flag = pinfo.getPage(procAddress).Protect == 64U;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				Yara.setCave(pinfo, procAddress, procAddress + 2048);
				int procAddress2 = Imports.GetProcAddress(Imports.GetModuleHandle("ntdll.dll"), "NtQueryVirtualMemory");
				int from = procAddress2 + 10;
				int num = Yara.silentAlloc(pinfo, 1024, 64U);
				int num2 = num + 768;
				int num3 = num2;
				pinfo.writeInt32(num3, num3 - 32);
				pinfo.writeInt32(num3 + 4, 0);
				byte[] array = Yara.makePayload(num3);
				pinfo.writeBytes(num, array, array.Length);
				pinfo.placeJmp(from, num);
				foreach (int num4 in Yara.getRbxWow64Clone(pinfo))
				{
					int from2 = num4 + 80;
					pinfo.placeJmp(from2, procAddress2);
				}
				result = true;
			}
			return result;
		}

		public static int codeCaveAt;

		public static int codeCaveStart;

		public static int codeCaveEnd;
	}
}
