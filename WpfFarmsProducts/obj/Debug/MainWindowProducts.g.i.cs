﻿#pragma checksum "..\..\MainWindowProducts.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CD6C472CD15AF6E8A4C50D087AC1EA65"
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
using WpfFarmsProducts;


namespace WpfFarmsProducts {
    
    
    /// <summary>
    /// MainWindowProducts
    /// </summary>
    public partial class MainWindowProducts : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\MainWindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdShowCreateProducts;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MainWindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdDeleteProducts;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdSaveProducts;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MainWindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdChangeProductDescription;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MainWindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdChangeImages;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindowProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProductsDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfFarmsProducts;component/mainwindowproducts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindowProducts.xaml"
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
            
            #line 8 "..\..\MainWindowProducts.xaml"
            ((WpfFarmsProducts.MainWindowProducts)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmdShowCreateProducts = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\MainWindowProducts.xaml"
            this.cmdShowCreateProducts.Click += new System.Windows.RoutedEventHandler(this.CreateButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmdDeleteProducts = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\MainWindowProducts.xaml"
            this.cmdDeleteProducts.Click += new System.Windows.RoutedEventHandler(this.cmdDeleteProducts_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmdSaveProducts = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\MainWindowProducts.xaml"
            this.cmdSaveProducts.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmdChangeProductDescription = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\MainWindowProducts.xaml"
            this.cmdChangeProductDescription.Click += new System.Windows.RoutedEventHandler(this.cmdChangeProductDescription_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmdChangeImages = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\MainWindowProducts.xaml"
            this.cmdChangeImages.Click += new System.Windows.RoutedEventHandler(this.cmdChangeImages_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ProductsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 22 "..\..\MainWindowProducts.xaml"
            this.ProductsDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ProductsDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

