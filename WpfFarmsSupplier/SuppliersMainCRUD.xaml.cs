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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource supplierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("supplierViewSource")));
            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
            // supplierViewSource.Source = [泛用資料來源]
        }
    }
}
