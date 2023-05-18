using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CeleryApp.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{

		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}


		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("1")]
		public sbyte Opacity
		{
			get
			{
				return (sbyte)this["Opacity"];
			}
			set
			{
				this["Opacity"] = value;
			}
		}


		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool TopMost
		{
			get
			{
				return (bool)this["TopMost"];
			}
			set
			{
				this["TopMost"] = value;
			}
		}


		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool RPC
		{
			get
			{
				return (bool)this["RPC"];
			}
			set
			{
				this["RPC"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("False")]
		public bool Autolaunch
		{
			get
			{
				return (bool)this["Autolaunch"];
			}
			set
			{
				this["Autolaunch"] = value;
			}
		}

		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
