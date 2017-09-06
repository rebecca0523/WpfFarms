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
using AllData;

namespace WpfFarmsSupplier
{
    /// <summary>
    /// SuppliersVedioCRUDMulti.xaml 的互動邏輯
    /// </summary>
    public partial class SuppliersVedioCRUDMulti : Window
    {
        public SuppliersVedioCRUDMulti()
        {
            InitializeComponent();
        }

        AllFarmsDBEntities context = new AllFarmsDBEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource suppliersVideoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("suppliersVideoViewSource")));
            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
            suppliersVideoViewSource.Source = context.SuppliersVideos.Where(s=>s.SuppliersID==AllData.CustomerClass.loginSupplierID ).ToList();
            System.Windows.Data.CollectionViewSource supplierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("supplierViewSource")));
            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
            supplierViewSource.Source = context.Suppliers.Where(s => s.SupplierID == AllData.CustomerClass.loginSupplierID).ToList();

        }

        private void suppliersVideoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
