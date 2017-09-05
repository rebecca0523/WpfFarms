using System;
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
using WpfFarmsSupplier;

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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ActivityManagement ActivityManagement = new ActivityManagement();
            ActivityManagement.Show();
        }

        private void myMenuItemfarmsCRUD_Click(object sender, RoutedEventArgs e)
        {
            SuppliersRegister supreg = new SuppliersRegister();

            supreg.Show();
        }
    }
}
