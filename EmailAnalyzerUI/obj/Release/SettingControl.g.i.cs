﻿#pragma checksum "..\..\SettingControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "14B126D515E7F1DFED9C4FE06A6E4715"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace EmailAnalyzerUI {
    
    
    /// <summary>
    /// SettingControl
    /// </summary>
    public partial class SettingControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\SettingControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBx_Text;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\SettingControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBx_Subject;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SettingControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBx_To;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\SettingControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBx_DenyDepartment;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\SettingControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBx_DenyBodyTag;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\SettingControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBx_DenySubject;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\SettingControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSetRules;
        
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
            System.Uri resourceLocater = new System.Uri("/EmailAnalyzerUI;component/settingcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SettingControl.xaml"
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
            this.txtBx_Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtBx_Subject = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtBx_To = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtBx_DenyDepartment = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtBx_DenyBodyTag = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtBx_DenySubject = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BtnSetRules = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\SettingControl.xaml"
            this.BtnSetRules.Click += new System.Windows.RoutedEventHandler(this.BtnSetRules_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
