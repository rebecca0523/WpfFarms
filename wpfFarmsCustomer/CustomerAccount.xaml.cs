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
using System.Windows.Shapes;
using WpfFarmsSupplier;
using WpfMarketing;

namespace wpfFarmsCustomer
{
    /// <summary>
    /// CustomerAccount.xaml 的互動邏輯
    /// </summary>
    public partial class CustomerAccount : Window
    {
        public CustomerAccount()
        {
            InitializeComponent();
        }

        private void myMenuItemfarmsCRUD_Click(object sender, RoutedEventArgs e)
        {
            SuppliersRegister suppRegister = new SuppliersRegister();

            suppRegister.Show();





        }

        private void myMenuItemVedioCRUD_Click(object sender, RoutedEventArgs e)
        {
            SuppliersVedioCRUD vedioCRUD = new SuppliersVedioCRUD();

            vedioCRUD.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void mimMarketing_Click(object sender, RoutedEventArgs e)
        {
            //行銷專區
            WindowSalEvent SE = new WindowSalEvent();
            SE.Show();


        }
    }
}
