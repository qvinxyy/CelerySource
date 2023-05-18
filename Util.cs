using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using EyeStepPackage;
public class Util
{
	public static List<Util.ProcInfo> openProcessesByName(string processName)
	{
		List<Util.ProcInfo> list = new List<Util.ProcInfo>();
		foreach (Process process in Process.GetProcessesByName(processName.Replace(".exe", "")))
		{
			try
			{
				bool flag = process.Id != 0 && !process.HasExited;
				if (flag)
				{
					bool flag2 = process.MainModule != null;
					if (flag2)
					{
						bool flag3 = process.MainModule.ModuleName.Length > 0;
						if (flag3)
						{
							int num = Imports.OpenProcess(2035711U, false, process.Id);
							bool flag4 = num != 0;
							if (flag4)
							{
								Util.openedHandles.Add(num);
								int num2 = process.MainModule.BaseAddress.ToInt32();
								int moduleMemorySize = process.MainModule.ModuleMemorySize;
								bool flag5 = num2 != 0 && moduleMemorySize > 0;
								if (flag5)
								{
									list.Add(new Util.ProcInfo
									{
										processRef = process,
										baseModule = num2,
										handle = num,
										processId = process.Id,
										processName = processName,
										windowName = ""
									});
								}
							}
						}
					}
				}
			}
			catch (Win32Exception ex)
			{
			}
		}
		return list;
	}

	public void flush()
	{
		foreach (int hObject in Util.openedHandles)
		{
			Imports.CloseHandle(hObject);
		}
	}

	private static List<int> openedHandles = new List<int>();

	public class ProcInfo
	{
		public ProcInfo()
		{
			this.processRef = null;
			this.processId = 0;
			this.handle = 0;
		}

		public bool isOpen()
		{
			bool flag = this.processRef == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool hasExited = this.processRef.HasExited;
				if (hasExited)
				{
					result = false;
				}
				else
				{
					bool flag2 = this.processRef.Id == 0;
					if (flag2)
					{
						result = false;
					}
					else
					{
						bool flag3 = this.processRef.Handle == IntPtr.Zero;
						result = (!flag3 && this.processId != 0 && this.handle != 0);
					}
				}
			}
			return result;
		}

		public Util.ProcInfo.ProcessRegion getSection(string name)
		{
			int num = this.baseModule + 584;
			Util.ProcInfo.ProcessRegion processRegion = new Util.ProcInfo.ProcessRegion();
			for (;;)
			{
				bool flag = this.readString(num, name.Length) == name;
				if (flag)
				{
					break;
				}
				num += 40;
			}
			processRegion.start = this.readInt32(num + 12);
			processRegion.end = this.readInt32(num + 12) + this.readInt32(num + 8);
			return processRegion;
		}

		public Imports.MEMORY_BASIC_INFORMATION getPage(int address)
		{
			Imports.MEMORY_BASIC_INFORMATION result = default(Imports.MEMORY_BASIC_INFORMATION);
			Imports.VirtualQueryEx(this.handle, address, out result, 28U);
			return result;
		}

		public bool isAccessible(int address)
		{
			Imports.MEMORY_BASIC_INFORMATION page = this.getPage(address);
			uint protect = page.Protect;
			return page.State == 4096U && (protect == 4U || protect == 2U || protect == 64U || protect == 32U);
		}

		public uint setPageProtect(int address, int size, uint protect)
		{
			uint result = 0U;
			Imports.VirtualProtectEx(this.handle, address, size, protect, ref result);
			return result;
		}

		public bool writeByte(int address, byte value)
		{
			byte[] array = new byte[]
			{
				value
			};
			return Imports.WriteProcessMemory(this.handle, address, array, array.Length, ref this.nothing);
		}

		public bool writeBytes(int address, byte[] bytes, int count = -1)
		{
			return Imports.WriteProcessMemory(this.handle, address, bytes, (count == -1) ? bytes.Length : count, ref this.nothing);
		}

		public bool writeString(int address, string str, int count = -1)
		{
			char[] array = str.ToCharArray(0, str.Length);
			List<byte> list = new List<byte>();
			foreach (byte item in array)
			{
				list.Add(item);
			}
			return Imports.WriteProcessMemory(this.handle, address, list.ToArray(), (count == -1) ? list.Count : count, ref this.nothing);
		}

		public bool writeWString(int address, string str, int count = -1)
		{
			int num = address;
			char[] array = str.ToCharArray(0, str.Length);
			foreach (char value in array)
			{
				this.writeUInt16(num, Convert.ToUInt16(value));
				num += 2;
			}
			return true;
		}

		public bool writeInt16(int address, short value)
		{
			return Imports.WriteProcessMemory(this.handle, address, BitConverter.GetBytes(value), 2, ref this.nothing);
		}

		public bool writeUInt16(int address, ushort value)
		{
			return Imports.WriteProcessMemory(this.handle, address, BitConverter.GetBytes(value), 2, ref this.nothing);
		}

		public bool writeInt32(int address, int value)
		{
			return Imports.WriteProcessMemory(this.handle, address, BitConverter.GetBytes(value), 4, ref this.nothing);
		}

		public bool writeUInt32(int address, uint value)
		{
			return Imports.WriteProcessMemory(this.handle, address, BitConverter.GetBytes(value), 4, ref this.nothing);
		}

		public bool writeFloat(int address, float value)
		{
			return Imports.WriteProcessMemory(this.handle, address, BitConverter.GetBytes(value), 4, ref this.nothing);
		}

		public bool writeDouble(int address, double value)
		{
			return Imports.WriteProcessMemory(this.handle, address, BitConverter.GetBytes(value), 8, ref this.nothing);
		}

		public bool writeInt64(int address, long value)
		{
			return Imports.WriteProcessMemory(this.handle, address, BitConverter.GetBytes(value), 8, ref this.nothing);
		}

		public bool writeUInt64(int address, ulong value)
		{
			return Imports.WriteProcessMemory(this.handle, address, BitConverter.GetBytes(value), 8, ref this.nothing);
		}

		public byte readByte(int address)
		{
			byte[] array = new byte[1];
			Imports.ReadProcessMemory(this.handle, address, array, 1, ref this.nothing);
			return array[0];
		}

		public byte[] readBytes(int address, int count)
		{
			byte[] array = new byte[count];
			Imports.ReadProcessMemory(this.handle, address, array, count, ref this.nothing);
			return array;
		}

		public string readString(int address, int count = -1)
		{
			string text = "";
			int num = address;
			bool flag = count == -1;
			if (flag)
			{
				while (num != 512)
				{
					foreach (byte b in this.readBytes(num, 512))
					{
						bool flag2 = b != 10 && b != 13 && b != 9 && (b < 32 || b > 127);
						if (flag2)
						{
							num = 0;
							break;
						}
						string str = text;
						char c = (char)b;
						text = str + c.ToString();
					}
					num += 512;
				}
			}
			else
			{
				foreach (byte b2 in this.readBytes(num, count))
				{
					string str2 = text;
					char c = (char)b2;
					text = str2 + c.ToString();
				}
			}
			return text;
		}

		public string readWString(int address, int count = -1)
		{
			string text = "";
			int num = address;
			bool flag = count == -1;
			if (flag)
			{
				while (num != 512)
				{
					byte[] array = this.readBytes(num, 512);
					for (int i = 0; i < array.Length; i += 2)
					{
						char c = Convert.ToChar(BitConverter.ToUInt16(new byte[]
						{
							array[0],
							array[1]
						}, 0));
						bool flag2 = c == '\0';
						if (flag2)
						{
							num = 0;
							break;
						}
						text += c.ToString();
					}
					num += 512;
				}
			}
			else
			{
				byte[] array2 = this.readBytes(num, count * 2);
				for (int j = 0; j < array2.Length; j += 2)
				{
					text += Convert.ToChar(BitConverter.ToUInt16(new byte[]
					{
						array2[j],
						array2[j + 1]
					}, 0)).ToString();
				}
			}
			return text;
		}

		public short readInt16(int address)
		{
			byte[] array = new byte[2];
			Imports.ReadProcessMemory(this.handle, address, array, 2, ref this.nothing);
			return BitConverter.ToInt16(array, 0);
		}

		public ushort readUInt16(int address)
		{
			byte[] array = new byte[2];
			Imports.ReadProcessMemory(this.handle, address, array, 2, ref this.nothing);
			return BitConverter.ToUInt16(array, 0);
		}

		public int readInt32(int address)
		{
			byte[] array = new byte[4];
			Imports.ReadProcessMemory(this.handle, address, array, 4, ref this.nothing);
			return BitConverter.ToInt32(array, 0);
		}

		public uint readUInt32(int address)
		{
			byte[] array = new byte[4];
			Imports.ReadProcessMemory(this.handle, address, array, 4, ref this.nothing);
			return BitConverter.ToUInt32(array, 0);
		}

		public float readFloat(int address)
		{
			byte[] array = new byte[4];
			Imports.ReadProcessMemory(this.handle, address, array, 4, ref this.nothing);
			return BitConverter.ToSingle(array, 0);
		}

		public double readDouble(int address)
		{
			byte[] array = new byte[8];
			Imports.ReadProcessMemory(this.handle, address, array, 8, ref this.nothing);
			return BitConverter.ToDouble(array, 0);
		}

		public long readInt64(int address)
		{
			byte[] array = new byte[8];
			Imports.ReadProcessMemory(this.handle, address, array, 8, ref this.nothing);
			return BitConverter.ToInt64(array, 0);
		}

		public ulong readUInt64(int address)
		{
			byte[] array = new byte[8];
			Imports.ReadProcessMemory(this.handle, address, array, 8, ref this.nothing);
			return BitConverter.ToUInt64(array, 0);
		}

		public void placeJmp(int from, int to)
		{
			int i;
			for (i = 0; i < 5; i += EyeStep.read(this.handle, from + i).len)
			{
			}
			uint protect = this.setPageProtect(from, i, 64U);
			this.writeByte(from, 233);
			this.writeInt32(from + 1, to - from - 5);
			for (int j = 5; j < i; j++)
			{
				this.writeByte(from + j, 144);
			}
			this.setPageProtect(from, i, protect);
		}

		public void placeCall(int from, int to)
		{
			int i;
			for (i = 0; i < 5; i += EyeStep.read(this.handle, from + i).len)
			{
			}
			uint protect = this.setPageProtect(from, i, 64U);
			this.writeByte(from, 232);
			this.writeInt32(from + 1, to - from - 5);
			for (int j = 5; j < i; j++)
			{
				this.writeByte(from + j, 144);
			}
			this.setPageProtect(from, i, protect);
		}

		public void placeTrampoline(int from, int to, int length)
		{
			this.placeJmp(from, to);
			this.placeJmp(to + length, from + 5);
		}

		public bool isPrologue(int address)
		{
			byte[] array = this.readBytes(address, 3);
			bool flag = array[0] == 139 && array[1] == byte.MaxValue && array[2] == 85;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = address % 16 != 0;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = (array[0] == 82 && array[1] == 139 && array[2] == 212) || (array[0] == 83 && array[1] == 139 && array[2] == 220) || (array[0] == 85 && array[1] == 139 && array[2] == 236) || (array[0] == 86 && array[1] == 139 && array[2] == 244) || (array[0] == 87 && array[1] == 139 && array[2] == byte.MaxValue);
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = this.readInt32(address - 4) > address - 32768 && this.readInt32(address - 4) < address && this.readInt32(address - 8) > address - 32768 && this.readInt32(address - 8) < address;
						result = flag4;
					}
				}
			}
			return result;
		}

		public bool isEpilogue(int address)
		{
			byte b = this.readByte(address);
			byte b2 = b;
			byte b3 = b2;
			if (b3 - 194 > 1)
			{
				if (b3 == 201)
				{
					return true;
				}
				if (b3 != 204)
				{
					goto IL_99;
				}
			}
			byte b4 = this.readByte(address - 1);
			byte b5 = b4;
			if (b5 - 90 <= 1 || b5 - 93 <= 2)
			{
				bool flag = b == 194;
				if (flag)
				{
					ushort num = this.readUInt16(address + 1);
					bool flag2 = num % 4 == 0 && num > 0 && num < 1024;
					if (flag2)
					{
						return true;
					}
				}
				return true;
			}
			IL_99:
			return false;
		}

		private bool isValidCode(int address)
		{
			return this.readUInt64(address) != 0UL || this.readUInt64(address + 8) > 0UL;
		}

		public int gotoPrologue(int address)
		{
			int num = address;
			bool flag = this.isPrologue(num);
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				while (!this.isPrologue(num) && this.isValidCode(address))
				{
					bool flag2 = num % 16 != 0;
					if (flag2)
					{
						num -= num % 16;
					}
					else
					{
						num -= 16;
					}
				}
				result = num;
			}
			return result;
		}

		public int gotoNextPrologue(int address)
		{
			int num = address;
			bool flag = this.isPrologue(num);
			if (flag)
			{
				num += 16;
			}
			while (!this.isPrologue(num) && this.isValidCode(num))
			{
				bool flag2 = num % 16 == 0;
				if (flag2)
				{
					num += 16;
				}
				else
				{
					num += num % 16;
				}
			}
			return num;
		}

		public Process processRef;

		public int processId;

		public string processName;

		public string windowName;

		public int handle;

		public int baseModule;

		private int nothing;

		public class ProcessRegion
		{
			public int start;

			public int end;
		}
	}
}
