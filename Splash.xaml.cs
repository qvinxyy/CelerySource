using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace CeleryApp
{
	public partial class Splash : Window
	{
		public Splash()
		{
			this.InitializeComponent();
		}

		[DebuggerStepThrough]
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Splash.<Window_Loaded>d__7 <Window_Loaded>d__ = new Splash.<Window_Loaded>d__7();
			<Window_Loaded>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Window_Loaded>d__.<>4__this = this;
			<Window_Loaded>d__.sender = sender;
			<Window_Loaded>d__.e = e;
			<Window_Loaded>d__.<>1__state = -1;
			<Window_Loaded>d__.<>t__builder.Start<Splash.<Window_Loaded>d__7>(ref <Window_Loaded>d__);
		}

		private void ProgressValueIncrease(object sender, EventArgs e)
		{
			this.LoadBar.Value += 1.0;
		}

		[DebuggerStepThrough]
		private void Init(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			Splash.<Init>d__9 <Init>d__ = new Splash.<Init>d__9();
			<Init>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.sender = sender;
			<Init>d__.e = e;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<Splash.<Init>d__9>(ref <Init>d__);
		}

		private Animation Animate = new Animation();

		private WebClient wc = new WebClient();

		private Random Random = new Random();

		private DispatcherTimer DispatcherTimer = new DispatcherTimer();

		private string[] Quotes = new string[]
		{
			"Rexi is ass at C#, trust me",
			"Rexi is cool :sunglasses:",
			"Following the white rabbit....",
			"Not panicking...totally not panicking",
			"Making stuff up. Please wait...",
			"The world is your litterbox",
			"Sacrificing a resistor to the machine gods....",
			"The architects are still drafting",
			"Alt+F4 won't give you admin in every game *wink*",
			"I got cut off I have to resize it a hair smaller -Celery",
			"Rexi sucks at error handling",
			"Testing your patience..",
			"Fun Fact : Celery actually hates Celery",
			"Stay awhile and listen..",
			"You edhall not pass! yet..",
			"Well, this is embarrassing.",
			"What the what?",
			"Downloading more RAM..",
			"Deleting System32 folder",
			"Debugging Debugger...",
			"Still faster than Windows update",
			"We're working very Hard .... Really",
			"Our premium plan is faster",
			"When nothing is going right, go left",
			"↑↑↓↓←→←→BA Start",
			"ly full homo -Rexi",
			"Making more meme strings...",
			"Go ahead -- hold your breath",
			"Stan approved Celery",
			"while true do while true do end end",
			"Also Try Misako!",
			"am pro",
			"POV : IllIlllIllIlllIlllIlllIIIl",
			"C++ gives me cancer",
			"const std::atomic_int > const auto > const std::uintptr_t",
			"H++ rocks",
			"synap x crack workign 2021 ",
			"SoloDev was here"
		};

		internal static class IconUtilities
		{
			[DllImport("gdi32.dll", SetLastError = true)]
			private static extern bool DeleteObject(IntPtr hObject);

			public static ImageSource ToImageSource(Icon icon)
			{
				Bitmap bitmap = icon.ToBitmap();
				IntPtr hbitmap = bitmap.GetHbitmap();
				MessageBox.Show(string.Concat(new string[]
				{
					"Icon width: ",
					bitmap.Width.ToString(),
					", height: ",
					bitmap.Height.ToString(),
					"."
				}));
				ImageSource result = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
				bool flag = !Splash.IconUtilities.DeleteObject(hbitmap);
				if (flag)
				{
					throw new Win32Exception();
				}
				return result;
			}
		}
	}
}
