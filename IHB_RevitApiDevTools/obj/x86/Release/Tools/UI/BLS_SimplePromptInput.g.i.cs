﻿#pragma checksum "..\..\..\..\..\Tools\UI\BLS_SimplePromptInput.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9836D91DDFBDD7E611CC398FE3039E8595A641EC99089DCD0FC5308343E549B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IHB_RevitApiDevTools.Tools.UI;
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


namespace IHB_RevitApiDevTools.Tools.UI {
    
    
    /// <summary>
    /// BLS_SimplePromptInput
    /// </summary>
    public partial class BLS_SimplePromptInput : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\..\Tools\UI\BLS_SimplePromptInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock message;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\Tools\UI\BLS_SimplePromptInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prompt;
        
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
            System.Uri resourceLocater = new System.Uri("/IHB_RevitApiDevTools;component/tools/ui/bls_simplepromptinput.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Tools\UI\BLS_SimplePromptInput.xaml"
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
            
            #line 17 "..\..\..\..\..\Tools\UI\BLS_SimplePromptInput.xaml"
            ((IHB_RevitApiDevTools.Tools.UI.BLS_SimplePromptInput)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\..\..\Tools\UI\BLS_SimplePromptInput.xaml"
            ((IHB_RevitApiDevTools.Tools.UI.BLS_SimplePromptInput)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.move_window);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\..\Tools\UI\BLS_SimplePromptInput.xaml"
            ((IHB_RevitApiDevTools.Tools.UI.BLS_SimplePromptInput)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.Window_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.message = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.prompt = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

