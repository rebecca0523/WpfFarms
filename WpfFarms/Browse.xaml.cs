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
using WpfFarmsActivity;
using wpfFarmsCustomer;
using WpfMarketing;

namespace WpfFarms
{
    /// <summary>
    /// Browse.xaml 的互動邏輯
    /// </summary>
    public partial class Browse : Window
    {
        public Browse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginAndRegister loginAndRegister = new LoginAndRegister();
            loginAndRegister.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnDiscountProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowSaleEventNow WSE = new WindowSaleEventNow();
            WSE.Show();
        }
    }
}
