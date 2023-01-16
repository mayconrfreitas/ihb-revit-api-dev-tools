﻿#pragma checksum "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1669FF9CE5D19441BDE3F80D0218DB821037826F4DFC9D3A3C28D8F823F9C6FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Search;
using IHB_RevitApiDevTools.Helpers.UI;
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


namespace IHB_RevitApiDevTools.CodeEditor.Views {
    
    
    /// <summary>
    /// CodeEditor_UI
    /// </summary>
    public partial class CodeEditor_UI : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 92 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Header;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image logo;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Header_Menu;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAbout;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHelp;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Header_Close;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ListBxTitle;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel DockList;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor textEditor;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DockButtons;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMain;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
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
            System.Uri resourceLocater = new System.Uri("/IHB_RevitApiDevTools;component/codeeditor/views/codeeditor_ui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
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
            
            #line 98 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
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
            this.btnAbout = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
            this.btnAbout.Click += new System.Windows.RoutedEventHandler(this.btnAbout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnHelp = ((System.Windows.Controls.Button)(target));
            
            #line 136 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
            this.btnHelp.Click += new System.Windows.RoutedEventHandler(this.btnHelp_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Header_Close = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 7:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 153 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ListBxTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.DockList = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 10:
            this.textEditor = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            return;
            case 11:
            this.DockButtons = ((System.Windows.Controls.Grid)(target));
            return;
            case 12:
            this.btnMain = ((System.Windows.Controls.Button)(target));
            
            #line 222 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
            this.btnMain.Click += new System.Windows.RoutedEventHandler(this.btnMain_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 240 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnReset = ((System.Windows.Controls.Button)(target));
            
            #line 258 "..\..\..\..\CodeEditor\Views\CodeEditor_UI.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.btnReset_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

