﻿#pragma checksum "..\..\..\WindowHistoryBooking.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D9F9BCFB989AEB75468158C0F30DD173CABC0EA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.Ribbon;
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
using project;


namespace project {
    
    
    /// <summary>
    /// WindowHistoryBooking
    /// </summary>
    public partial class WindowHistoryBooking : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvDisplay;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAssignmentId;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxAccountId;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxRoomId;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxDom;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpkstart;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpkend;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNote;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxStatus;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\WindowHistoryBooking.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Logout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/project;component/windowhistorybooking.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowHistoryBooking.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dgvDisplay = ((System.Windows.Controls.DataGrid)(target));
            
            #line 17 "..\..\..\WindowHistoryBooking.xaml"
            this.dgvDisplay.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.dgvDisplay_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtAssignmentId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbxAccountId = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbxRoomId = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbxDom = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.dpkstart = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.dpkend = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.txtNote = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.cbxStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\WindowHistoryBooking.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\WindowHistoryBooking.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.back_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Logout = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\WindowHistoryBooking.xaml"
            this.Logout.Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

