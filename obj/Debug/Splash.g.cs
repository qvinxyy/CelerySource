#pragma checksum "..\..\Splash.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "195DE429211DDC9163926ACAE90CA15C9D9787AB5D628DFA2606F5714E2210E2"

using CeleryApp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CeleryApp {
    
    
    /// <summary>
    /// Splash
    /// </summary>
    public partial class Splash : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 3 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CeleryApp.Splash Splashs;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LoadingGrid;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border FirstTimeSetup;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FirstTimeLabel;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border MainBorder;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ScaleTransform MainScale;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CeleryLogo;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label WelcomeLabel;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label WelcomeLabel1;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar LoadBar;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label RandomizedText;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label InfoLabel;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\Splash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label WelcomeLabel2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CeleryApp;component/splash.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Splash.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Splashs = ((CeleryApp.Splash)(target));
            
            #line 15 "..\..\Splash.xaml"
            this.Splashs.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LoadingGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.FirstTimeSetup = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.FirstTimeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.MainBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.MainScale = ((System.Windows.Media.ScaleTransform)(target));
            return;
            case 7:
            this.CeleryLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.WelcomeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.WelcomeLabel1 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.LoadBar = ((System.Windows.Controls.ProgressBar)(target));
            
            #line 136 "..\..\Splash.xaml"
            this.LoadBar.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Init);
            
            #line default
            #line hidden
            return;
            case 11:
            this.RandomizedText = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.InfoLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.WelcomeLabel2 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

