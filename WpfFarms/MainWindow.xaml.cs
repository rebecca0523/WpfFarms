﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfFarmsSupplier;

namespace WpfFarms
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

       
        private void miSuppliersCRUD_Click(object sender, RoutedEventArgs e)
        {
            SuppliersMainCRUD SuppliersCRUD = new SuppliersMainCRUD();

            SuppliersCRUD.ShowDialog();

        }

        private void miCustomersCRUD_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void miProducts_Click(object sender, RoutedEventArgs e)
        {
            //MainWindowProducts mainWindowProducts = new MainWindowProducts();
            //mainWindowProducts.ShowDialog();
        }
    }
}
