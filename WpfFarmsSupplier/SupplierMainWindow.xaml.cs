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

namespace WpfFarmsSupplier
{
    /// <summary>
    /// SupplierMainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class SupplierMainWindow : Window
    {
        public SupplierMainWindow()
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

        private void MenuItemVedioCRUDMulti_Click(object sender, RoutedEventArgs e)
        {
            SuppliersVedioCRUDMulti vedioCRUD = new SuppliersVedioCRUDMulti();

            vedioCRUD.Show();
        }

      
    }
}
