using AllData;
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
        AllFarmsDBEntities db = new AllFarmsDBEntities();
        public static int getCustomerID;
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var useridentity = from q in db.CustomerInfoes
                               where q.Useridentity==0
                               select q;
            customerInfoDataGrid.ItemsSource = useridentity.ToList();
        }

        private void customerInfoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            if(grid.SelectedItem!=null)
            {
                getCustomerID = (grid.SelectedItem as CustomerInfo).CustomerID;
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            //var changeidentity=this
        }
    }
}
