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
    /// SuppliersMainCRUD.xaml 的互動邏輯
    /// </summary>
    public partial class SuppliersMainCRUD : Window
    {
        public SuppliersMainCRUD()
        {
            InitializeComponent();
            
        }
        System.Windows.Data.CollectionViewSource supplierViewSource;
        farmsDBEntities context = new farmsDBEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //    System.Windows.Data.CollectionViewSource supplierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("supplierViewSource")));
            supplierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("supplierViewSource")));

            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
            supplierViewSource.Source = context.Suppliers.ToList();
        }

        Supplier SupplierTable = new Supplier();
        private void cmdAdd_Click(object sender, RoutedEventArgs e)
        {
            //SupplierTable.SupplierName = supplierDataGrid.sup


            //context.SaveChanges();
            //supplierViewSource.Source = context.Suppliers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            supplierViewSource.Source = context.Suppliers.ToList();
        }

        int suppID;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            supplierViewSource.Source = context.Suppliers.ToList();
        }
    }
}
