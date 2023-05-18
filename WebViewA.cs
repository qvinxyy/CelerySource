using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace CeleryApp
{
	public class WebViewA : WebView2
	{
		public bool IsDoMLoaded { get; set; } = false;
		public string Theme { get; set; } = "Dark";

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler EditorReady;

		[DebuggerStepThrough]
		public void WebViewInitialize(string BrowserExecutableFolder, string UserDataFolder, CoreWebView2EnvironmentOptions Options)
		{
			WebViewA.<WebViewInitialize>d__13 <WebViewInitialize>d__ = new WebViewA.<WebViewInitialize>d__13();
			<WebViewInitialize>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<WebViewInitialize>d__.<>4__this = this;
			<WebViewInitialize>d__.BrowserExecutableFolder = BrowserExecutableFolder;
			<WebViewInitialize>d__.UserDataFolder = UserDataFolder;
			<WebViewInitialize>d__.Options = Options;
			<WebViewInitialize>d__.<>1__state = -1;
			<WebViewInitialize>d__.<>t__builder.Start<WebViewA.<WebViewInitialize>d__13>(ref <WebViewInitialize>d__);
		}

		public WebViewA(string Text = "")
		{
			this.WebViewInitialize(null, Path.GetTempPath(), null);
			base.DefaultBackgroundColor = Color.FromArgb(0, 25, 25, 25);
			base.Source = new Uri(Directory.GetCurrentDirectory() + "\\bin\\Monaco\\index.html");
			base.CoreWebView2InitializationCompleted += this.WebViewAPI_CoreWebView2InitializationCompleted;
			this.ToSetText = Text;
		}

		protected virtual void OnEditorReady()
		{
			EventHandler editorReady = this.EditorReady;
			bool flag = editorReady != null;
			if (flag)
			{
				editorReady(this, new EventArgs());
			}
		}

		private void WebViewAPI_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
		{
			base.CoreWebView2.DOMContentLoaded += this.CoreWebView2_DOMContentLoaded;
			base.CoreWebView2.WebMessageReceived += this.CoreWebView2_WebMessageReceived;
			base.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
			base.CoreWebView2.Settings.AreDevToolsEnabled = false;
		}

		private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
		{
			this.LatestRecievedText = e.TryGetWebMessageAsString();
		}

		[DebuggerStepThrough]
		private void CoreWebView2_DOMContentLoaded(object sender, CoreWebView2DOMContentLoadedEventArgs e)
		{
			WebViewA.<CoreWebView2_DOMContentLoaded>d__18 <CoreWebView2_DOMContentLoaded>d__ = new WebViewA.<CoreWebView2_DOMContentLoaded>d__18();
			<CoreWebView2_DOMContentLoaded>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<CoreWebView2_DOMContentLoaded>d__.<>4__this = this;
			<CoreWebView2_DOMContentLoaded>d__.sender = sender;
			<CoreWebView2_DOMContentLoaded>d__.e = e;
			<CoreWebView2_DOMContentLoaded>d__.<>1__state = -1;
			<CoreWebView2_DOMContentLoaded>d__.<>t__builder.Start<WebViewA.<CoreWebView2_DOMContentLoaded>d__18>(ref <CoreWebView2_DOMContentLoaded>d__);
		}

		[DebuggerStepThrough]
		public Task<string> GetText()
		{
			WebViewA.<GetText>d__19 <GetText>d__ = new WebViewA.<GetText>d__19();
			<GetText>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<GetText>d__.<>4__this = this;
			<GetText>d__.<>1__state = -1;
			<GetText>d__.<>t__builder.Start<WebViewA.<GetText>d__19>(ref <GetText>d__);
			return <GetText>d__.<>t__builder.Task;
		}

		[DebuggerStepThrough]
		public void SetText(string Text)
		{
			WebViewA.<SetText>d__20 <SetText>d__ = new WebViewA.<SetText>d__20();
			<SetText>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<SetText>d__.<>4__this = this;
			<SetText>d__.Text = Text;
			<SetText>d__.<>1__state = -1;
			<SetText>d__.<>t__builder.Start<WebViewA.<SetText>d__20>(ref <SetText>d__);
		}

		public void AddIntellisense(string Label, Types Type, string Description, string Insert)
		{
			bool isDoMLoaded = this.IsDoMLoaded;
			if (isDoMLoaded)
			{
				string text = Type.ToString();
				bool flag = Type == Types.None;
				if (flag)
				{
					text = "";
				}
				base.ExecuteScriptAsync(string.Concat(new string[]
				{
					"AddIntellisense(",
					Label,
					", ",
					text,
					", ",
					Description,
					", ",
					Insert,
					");"
				}));
			}
		}

		public void Refresh()
		{
			bool isDoMLoaded = this.IsDoMLoaded;
			if (isDoMLoaded)
			{
				base.ExecuteScriptAsync("Refresh();");
			}
		}

		[DebuggerStepThrough]
		private void SetTheme(string ThemeName)
		{
			WebViewA.<SetTheme>d__23 <SetTheme>d__ = new WebViewA.<SetTheme>d__23();
			<SetTheme>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<SetTheme>d__.<>4__this = this;
			<SetTheme>d__.ThemeName = ThemeName;
			<SetTheme>d__.<>1__state = -1;
			<SetTheme>d__.<>t__builder.Start<WebViewA.<SetTheme>d__23>(ref <SetTheme>d__);
		}

		private string ToSetText;

		private string LatestRecievedText;
	}
}
