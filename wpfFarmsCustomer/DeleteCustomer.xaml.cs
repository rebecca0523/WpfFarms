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

namespace wpfFarmsCustomer
{
    /// <summary>
    /// DeleteCustomer.xaml 的互動邏輯
    /// </summary>
    public partial class DeleteCustomer : Window
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            farmsDBEntities dc = new farmsDBEntities();
            CustomerInfoDataGrid.ItemsSource = dc.CustomerInfo.ToArray();
        }
    }
}
