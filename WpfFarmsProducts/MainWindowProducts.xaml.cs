using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace WpfFarmsProducts
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindowProducts : Window
    {
        public MainWindowProducts()
        {
            InitializeComponent();            
        }

        farmsDBEntities farmsDBEntities = new farmsDBEntities();
        public static int SupplierID =1; //暫定抓1號小農
        public static int GetSelectProductID;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ProductsDataGrid.ItemsSource = farmsDBEntities.Products.Where(n=>n.SupplierID==SupplierID&&n.DeleteProduct==false).ToList();        
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
                  
            if (createProduct.ShowDialog() == true)
            {
                this.ProductsDataGrid.ItemsSource = farmsDBEntities.Products.Where(n => n.SupplierID == SupplierID && n.DeleteProduct == false).ToList();
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.farmsDBEntities.SaveChanges();
        }

        private void cmdDeleteProducts_Click(object sender, RoutedEventArgs e)
        {
            var deleteProduct = this.farmsDBEntities.Products.Where(n => n.ProductID == GetSelectProductID).FirstOrDefault();//(機車)還要用.FirstOrDefault(),不能用LastOrDefault()或ToList(),才能在deleteProduct後面點到DeleteProduct        
            deleteProduct.DeleteProduct = true;
            this.farmsDBEntities.SaveChanges();
            this.ProductsDataGrid.ItemsSource = farmsDBEntities.Products.Where(n => n.SupplierID == SupplierID && n.DeleteProduct == false).ToList();
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;//背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背
            if (grid.SelectedItem != null)//背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背
            {
                GetSelectProductID = (grid.SelectedItem as Product).ProductID;//抓點中欄位的ProductID
            }
        }               

        private void cmdChangeProductDescription_Click(object sender, RoutedEventArgs e)
        {
            if (GetSelectProductID ==0)
            {
                MessageBox.Show("請選擇修改哪筆資料");
            }
            else
            {
                ProductDescription productDescription = new ProductDescription();
                if (productDescription.ShowDialog() == true)
                {
                    this.ProductsDataGrid.ItemsSource = null;
                    this.ProductsDataGrid.ItemsSource = farmsDBEntities.Products.Where(n => n.SupplierID == SupplierID && n.DeleteProduct == false).ToList();
                }                
            }
        }

        private void cmdChangeImages_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
