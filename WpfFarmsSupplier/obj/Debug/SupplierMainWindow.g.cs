﻿#pragma checksum "..\..\SupplierMainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD4AF12802E7C6895864A62BEA8F26A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
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
using WpfFarmsSupplier;


namespace WpfFarmsSupplier {
    
    
    /// <summary>
    /// SupplierMainWindow
    /// </summary>
    public partial class SupplierMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\SupplierMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemfarmsCRUDMulti;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\SupplierMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemfarmsCRUD;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\SupplierMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemVedioCRUD;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfFarmsSupplier;component/suppliermainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SupplierMainWindow.xaml"
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
            this.MenuItemfarmsCRUDMulti = ((System.Windows.Controls.MenuItem)(target));
            
            #line 11 "..\..\SupplierMainWindow.xaml"
            this.MenuItemfarmsCRUDMulti.Click += new System.Windows.RoutedEventHandler(this.MenuItemfarmsCRUDMulti_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MenuItemfarmsCRUD = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\SupplierMainWindow.xaml"
            this.MenuItemfarmsCRUD.Click += new System.Windows.RoutedEventHandler(this.MenuItemfarmsCRUD_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MenuItemVedioCRUD = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\SupplierMainWindow.xaml"
            this.MenuItemVedioCRUD.Click += new System.Windows.RoutedEventHandler(this.MenuItemVedioCRUD_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

