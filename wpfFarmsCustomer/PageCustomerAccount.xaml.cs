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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AllData;
using WpfFarmsSupplier;
using WpfFarmsProducts;
using WpfMarketing;

namespace wpfFarmsCustomer
{
    /// <summary>
    /// PageCustomerAccount.xaml 的互動邏輯
    /// </summary>
    public partial class PageCustomerAccount : Page
    {
        public PageCustomerAccount()
        {
            InitializeComponent();
        }

        private void MenuItemfarmsCRUDMulti_Click(object sender, RoutedEventArgs e)
        {
            SuppliersMainCRUD suppRegisterM = new SuppliersMainCRUD();

            suppRegisterM.Show();
        }

        private void MenuItemfarmsCRUD_Click(object sender, RoutedEventArgs e)
        {

            SuppliersRegister suppRegisterM = new SuppliersRegister();

            suppRegisterM.Show();
        }


        private void MenuItemVedioCRUD_Click(object sender, RoutedEventArgs e)
        {
            SuppliersVideoCRUD vedioCRUD = new SuppliersVideoCRUD();

            vedioCRUD.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindowProducts mainWindowProducts = new MainWindowProducts();
            mainWindowProducts.ShowDialog();
        }

        private void MenuItemMarketing_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void MenuItemVedioCRUDMulti_Click(object sender, RoutedEventArgs e)
        {
            SuppliersVedioCRUDMulti vedioCRUD = new SuppliersVedioCRUDMulti();

            vedioCRUD.Show();
        }

        private void MenuItemVedioCRUDMulti_Click_1(object sender, RoutedEventArgs e)
        {
            SuppliersVedioCRUDMulti vedioCRUD = new SuppliersVedioCRUDMulti();

            vedioCRUD.Show();
        }
    }
}
