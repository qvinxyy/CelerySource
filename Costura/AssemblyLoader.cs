using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		private static Stream LoadStream(string fullName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullName.EndsWith(".compressed"))
			{
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						return memoryStream;
					}
				}
			}
			return executingAssembly.GetManifestResourceStream(fullName);
		}

		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string fullName;
			if (resourceNames.TryGetValue(name, out fullName))
			{
				return AssemblyLoader.LoadStream(fullName);
			}
			return null;
		}

		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = requestedAssemblyName.CultureInfo.Name + "." + text;
			}
			byte[] rawAssembly;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			lock (obj)
			{
				if (AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
			if (assembly == null)
			{
				object obj2 = AssemblyLoader.nullCacheLock;
				lock (obj2)
				{
					AssemblyLoader.nullCache[e.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}


		static AssemblyLoader()
		{
			AssemblyLoader.assemblyNames.Add("ar-dz.materialdesignextensions.resources", "costura.ar-dz.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("betterfolderbrowser", "costura.betterfolderbrowser.dll.compressed");
			AssemblyLoader.assemblyNames.Add("costura", "costura.costura.dll.compressed");
			AssemblyLoader.symbolNames.Add("costura", "costura.costura.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("cs.materialdesignextensions.resources", "costura.cs.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("cs-cz.materialdesignextensions.resources", "costura.cs-cz.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("de.materialdesignextensions.resources", "costura.de.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("dragablz", "costura.dragablz.dll.compressed");
			AssemblyLoader.symbolNames.Add("dragablz", "costura.dragablz.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("fr.materialdesignextensions.resources", "costura.fr.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("fr-fr.materialdesignextensions.resources", "costura.fr-fr.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("materialdesigncolors", "costura.materialdesigncolors.dll.compressed");
			AssemblyLoader.symbolNames.Add("materialdesigncolors", "costura.materialdesigncolors.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("materialdesignextensions", "costura.materialdesignextensions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("materialdesignthemes.wpf", "costura.materialdesignthemes.wpf.dll.compressed");
			AssemblyLoader.symbolNames.Add("materialdesignthemes.wpf", "costura.materialdesignthemes.wpf.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.web.webview2.core", "costura.microsoft.web.webview2.core.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.web.webview2.winforms", "costura.microsoft.web.webview2.winforms.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.web.webview2.wpf", "costura.microsoft.web.webview2.wpf.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.xaml.behaviors", "costura.microsoft.xaml.behaviors.dll.compressed");
			AssemblyLoader.symbolNames.Add("microsoft.xaml.behaviors", "costura.microsoft.xaml.behaviors.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("pt.materialdesignextensions.resources", "costura.pt.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("pt-br.materialdesignextensions.resources", "costura.pt-br.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("ru.materialdesignextensions.resources", "costura.ru.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("ru-ru.materialdesignextensions.resources", "costura.ru-ru.materialdesignextensions.resources.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.diagnostics.diagnosticsource", "costura.system.diagnostics.diagnosticsource.dll.compressed");
			AssemblyLoader.assemblyNames.Add("uz-latn-uz.materialdesignextensions.resources", "costura.uz-latn-uz.materialdesignextensions.resources.dll.compressed");
		}

		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		private static object nullCacheLock = new object();

		private static Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		private static Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		private static Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		private static int isAttached;
	}
}
