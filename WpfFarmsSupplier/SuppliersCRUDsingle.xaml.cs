using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// SuppliersCRUD.xaml 的互動邏輯
    /// </summary>
    public partial class SuppliersCRUDsingle : Window
    {
        public SuppliersCRUDsingle()
        {
            InitializeComponent();
        }

        int index = 1;
        farmsDBEntities farmdb = new farmsDBEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SupplierPanel.DataContext = farmdb.Suppliers.First();


        }

        
    }
}
