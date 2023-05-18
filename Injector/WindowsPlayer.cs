using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using ManualMapApi;

namespace Injector
{
	public class WindowsPlayer : Util
	{
		public static bool isInjected(Util.ProcInfo pinfo)
		{
			bool flag = pinfo.isOpen();
			if (flag)
			{
				bool flag2 = pinfo.readByte(Imports.GetProcAddress(Imports.GetModuleHandle("USER32.dll"), "DrawIcon") + 3) == 67;
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		public static void sendScript(Util.ProcInfo pinfo, string source)
		{
			bool flag = !WindowsPlayer.isInjected(pinfo);
			if (!flag)
			{
				int procAddress = Imports.GetProcAddress(Imports.GetModuleHandle("USER32.dll"), "DrawIcon");
				int num = 0;
				while (pinfo.readUInt32(procAddress + 8) > 0U)
				{
					Thread.Sleep(10);
					bool flag2 = num++ > 100;
					if (flag2)
					{
						return;
					}
				}
				uint protect = pinfo.setPageProtect(procAddress, 32, 4U);
				int num2 = 0;
				char[] chars = source.ToCharArray(0, source.Length);
				byte[] bytes = Encoding.UTF8.GetBytes(chars);
				int num3 = Imports.VirtualAllocEx(pinfo.handle, 0, bytes.Length, 12288U, 4U);
				Imports.WriteProcessMemory(pinfo.handle, num3, bytes, bytes.Length, ref num2);
				pinfo.writeUInt32(procAddress + 8, 1U);
				pinfo.writeInt32(procAddress + 12, num3);
				pinfo.writeInt32(procAddress + 16, bytes.Length);
				pinfo.setPageProtect(procAddress, 32, protect);
			}
		}

		public bool findProcess(ref Util.ProcInfo outPInfo)
		{
			foreach (Util.ProcInfo procInfo in Util.openProcessesByName("RobloxPlayerBeta.exe"))
			{
				uint num = procInfo.readUInt32(procInfo.baseModule + 80);
				bool flag = num > 0U;
				if (flag)
				{
					outPInfo = procInfo;
					return true;
				}
			}
			return false;
		}

		public bool findHiddenProcess(ref Util.ProcInfo outPInfo)
		{
			foreach (Util.ProcInfo procInfo in Util.openProcessesByName("RobloxPlayerBeta.exe"))
			{
				uint num = procInfo.readUInt32(procInfo.baseModule + 80);
				bool flag = num == 0U;
				if (flag)
				{
					outPInfo = procInfo;
					return true;
				}
			}
			return false;
		}

		public static InjectionStatus injectMainPlayer(Util.ProcInfo pinfo)
		{
			bool flag = WindowsPlayer.isInjectingMainPlayer;
			InjectionStatus result;
			if (flag)
			{
				result = InjectionStatus.ALREADY_INJECTING;
			}
			else
			{
				bool flag2 = WindowsPlayer.isInjected(pinfo);
				if (flag2)
				{
					result = InjectionStatus.ALREADY_INJECTED;
				}
				else
				{
					WindowsPlayer.isInjectingMainPlayer = true;
					int procAddress = Imports.GetProcAddress(Imports.GetModuleHandle("USER32.dll"), "DrawIcon");
					uint protect = pinfo.setPageProtect(procAddress, 32, 4U);
					pinfo.writeUInt32(procAddress + 8, 0U);
					pinfo.writeInt32(procAddress + 12, 0);
					pinfo.writeInt32(procAddress + 16, 0);
					pinfo.setPageProtect(procAddress, 32, protect);
					bool flag3 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "update.txt");
					bool flag5;
					if (flag3)
					{
						bool flag4 = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "update.txt") == "true";
						if (flag4)
						{
							flag5 = MapInject.ManualMap(pinfo.processRef, "C:\\Users\\javan\\Desktop\\Celery2.0\\dll\\celery.bin");
							return InjectionStatus.FAILED;
						}
					}
					Console.WriteLine("Manual mapping...");
					flag5 = MapInject.ManualMap(pinfo.processRef, AppDomain.CurrentDomain.BaseDirectory + "dll/" + WindowsPlayer.injectFileName);
					bool flag6 = flag5;
					if (flag6)
					{
						while (pinfo.isOpen() && !WindowsPlayer.isInjected(pinfo))
						{
							Thread.Sleep(10);
						}
						WindowsPlayer.postInjectedMainPlayer.Add(pinfo);
						WindowsPlayer.isInjectingMainPlayer = false;
						result = InjectionStatus.SUCCESS;
					}
					else
					{
						WindowsPlayer.isInjectingMainPlayer = false;
						result = InjectionStatus.FAILED;
					}
				}
			}
			return result;
		}

		public static List<Util.ProcInfo> getInjectedProcesses()
		{
			List<Util.ProcInfo> list = new List<Util.ProcInfo>();
			foreach (Util.ProcInfo procInfo in WindowsPlayer.postInjectedMainPlayer)
			{
				bool flag = WindowsPlayer.isInjected(procInfo);
				if (flag)
				{
					list.Add(procInfo);
				}
			}
			return list;
		}

		private static string injectFileName = "Celery.bin";

		private static List<Util.ProcInfo> postInjectedMainPlayer = new List<Util.ProcInfo>();

		private static bool isInjectingMainPlayer = false;
	}
}
