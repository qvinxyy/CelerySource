using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using ManualMapApi;

namespace Injector
{
	public class MsStorePlayer : Util
	{
		public static void showConsole()
		{
			bool flag = !MsStorePlayer.consoleLoaded;
			if (flag)
			{
				MsStorePlayer.consoleLoaded = true;
				MsStorePlayer.consoleInUse = true;
				Imports.ConsoleHelper.Initialize(true);
			}
			else
			{
				MsStorePlayer.consoleInUse = true;
				Imports.ShowWindow(Imports.GetConsoleWindow(), 5);
			}
		}

		public static void hideConsole()
		{
			MsStorePlayer.consoleInUse = false;
			Imports.ConsoleHelper.Clear();
			Imports.ShowWindow(Imports.GetConsoleWindow(), 0);
		}

		public bool findProcess(ref Util.ProcInfo outPInfo)
		{
			using (List<Util.ProcInfo>.Enumerator enumerator = Util.openProcessesByName("Windows10Universal.exe").GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Util.ProcInfo procInfo = enumerator.Current;
					outPInfo = procInfo;
					return true;
				}
			}
			return false;
		}

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
			bool flag = !MsStorePlayer.isInjected(pinfo);
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
				bool flag3 = !MsStorePlayer.isInjected(pinfo);
				if (!flag3)
				{
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
		}

		public static InjectionStatus injectPlayer(Util.ProcInfo pinfo)
		{
			bool flag = MsStorePlayer.isInjectingPlayer;
			InjectionStatus result;
			if (flag)
			{
				result = InjectionStatus.ALREADY_INJECTING;
			}
			else
			{
				bool flag2 = MsStorePlayer.isInjected(pinfo);
				if (flag2)
				{
					result = InjectionStatus.ALREADY_INJECTED;
				}
				else
				{
					MsStorePlayer.isInjectingPlayer = true;
					int procAddress = Imports.GetProcAddress(Imports.GetModuleHandle("USER32.dll"), "DrawIcon");
					uint protect = pinfo.setPageProtect(procAddress, 32, 4U);
					pinfo.writeUInt32(procAddress + 8, 0U);
					pinfo.writeInt32(procAddress + 12, 0);
					pinfo.writeInt32(procAddress + 16, 0);
					pinfo.setPageProtect(procAddress, 32, protect);
					bool flag3 = File.Exists(AppDomain.CurrentDomain.BaseDirectory + "update.txt");
					if (flag3)
					{
						bool flag4 = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "update.txt") == "true";
						if (flag4)
						{
							return InjectionStatus.FAILED;
						}
					}
					Console.WriteLine("Manual mapping...");
					bool flag5 = MapInject.ManualMap(pinfo.processRef, AppDomain.CurrentDomain.BaseDirectory + "dll/" + MsStorePlayer.injectFileName);
					bool flag6 = flag5;
					if (flag6)
					{
						while (pinfo.isOpen() && !MsStorePlayer.isInjected(pinfo))
						{
							Thread.Sleep(10);
						}
						MsStorePlayer.postInjectedPlayer.Add(pinfo);
						MsStorePlayer.isInjectingPlayer = false;
						MsStorePlayer.showConsole();
						result = InjectionStatus.SUCCESS;
					}
					else
					{
						MsStorePlayer.isInjectingPlayer = false;
						result = InjectionStatus.FAILED;
					}
				}
			}
			return result;
		}

		public static List<Util.ProcInfo> getInjectedProcesses()
		{
			List<Util.ProcInfo> list = new List<Util.ProcInfo>();
			foreach (Util.ProcInfo procInfo in MsStorePlayer.postInjectedPlayer)
			{
				bool flag = MsStorePlayer.isInjected(procInfo);
				if (flag)
				{
					list.Add(procInfo);
				}
			}
			return list;
		}

		private static bool consoleLoaded = false;

		public static bool consoleInUse = false;

		private static string injectFileName = "celeryuwp.bin";

		private static List<Util.ProcInfo> postInjectedPlayer = new List<Util.ProcInfo>();

		private static bool isInjectingPlayer = false;
	}
}
