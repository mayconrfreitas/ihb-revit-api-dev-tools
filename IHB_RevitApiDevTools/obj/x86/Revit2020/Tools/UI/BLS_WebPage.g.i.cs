﻿#pragma checksum "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "543227F09307075DE388D9E49F00D8D3932F9FDD34F15A7AFDC2C5C8FD2EA57D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BLS_PDI_RevitAddin_2020.Tools.UI;
using CefSharp.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace BLS_PDI_RevitAddin_2020.Tools.UI {
    
    
    /// <summary>
    /// BLS_WebPage
    /// </summary>
    public partial class BLS_WebPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Header;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logo;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Header_Menu;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSobre;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAjuda;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Header_Close;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabControl;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CefSharp.Wpf.ChromiumWebBrowser webBrowser;
        
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
            System.Uri resourceLocater = new System.Uri("/BLS_PDI_RevitAddin_2020;component/tools/ui/bls_webpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
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
            this.Header = ((System.Windows.Controls.DockPanel)(target));
            
            #line 47 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
            this.Header.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.move_window);
            
            #line default
            #line hidden
            return;
            case 2:
            this.logo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.Header_Menu = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 4:
            this.btnSobre = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
            this.btnSobre.Click += new System.Windows.RoutedEventHandler(this.btnSobre_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAjuda = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
            this.btnAjuda.Click += new System.Windows.RoutedEventHandler(this.btnAjuda_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Header_Close = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 7:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 9:
            
            #line 116 "..\..\..\..\..\Tools\UI\BLS_WebPage.xaml"
            ((System.Windows.Controls.TabItem)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TabItem_Loaded);
            
            #line default
            #line hidden
            return;
            case 10:
            this.webBrowser = ((CefSharp.Wpf.ChromiumWebBrowser)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
