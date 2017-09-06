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
            suppliersVideoViewSource.Source = context.Suppliers.ToList();
        }
    }
}
