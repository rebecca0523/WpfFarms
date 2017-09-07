using AllData;
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
using static WpfFarmsProducts.ProductDescription;
using static AllData.CustomerClass;

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

        AllFarmsDBEntities allFarmsDBEntities = new AllFarmsDBEntities();
        //public static int SupplierID =1; //暫定抓1號小農
        public static int GetSelectProductID;
        public static string  SendProductDescription;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loginCustomerID = 1;

            //var q = from n in allFarmsDBEntities.Products.ToList()
            //        where n.SupplierID == loginCustomerID && n.DeleteProduct == false
            //        group n by n.ProductImages into g
            //        select g;

            //this.ProductsDataGrid.ItemsSource = q.ToList();

            //this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.ToList().Where(n => n.SupplierID == loginCustomerID && n.DeleteProduct == false).GroupBy(n => n.ProductImages).ToList();

            this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == loginCustomerID && n.DeleteProduct == false).ToList();

            //this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == SupplierID && n.DeleteProduct == false).ToList();

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
                  
            if (createProduct.ShowDialog() == true)
            {
                //this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == SupplierID && n.DeleteProduct == false).ToList();
                this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == loginCustomerID && n.DeleteProduct == false).ToList();

            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            (this.allFarmsDBEntities.Products.Where(n => n.ProductID == GetSelectProductID).FirstOrDefault()).LastUpdateDate = DateTime.Now;
            this.allFarmsDBEntities.SaveChanges();
            this.ProductsDataGrid.ItemsSource = null;
            //this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == SupplierID && n.DeleteProduct == false).ToList();
            this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == loginCustomerID && n.DeleteProduct == false).ToList();
        }

        private void cmdDeleteProducts_Click(object sender, RoutedEventArgs e)
        {
            var deleteProduct = this.allFarmsDBEntities.Products.Where(n => n.ProductID == GetSelectProductID).FirstOrDefault();//(機車)還要用.FirstOrDefault(),不能用LastOrDefault()或ToList(),才能在deleteProduct後面點到DeleteProduct        
            deleteProduct.DeleteProduct = true;
            this.allFarmsDBEntities.SaveChanges();
            
            //this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == SupplierID && n.DeleteProduct == false).ToList();
            this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == loginCustomerID && n.DeleteProduct == false).ToList();
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = sender as DataGrid;//背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背
            if (grid.SelectedItem != null)//背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背背
            {
                GetSelectProductID = (grid.SelectedItem as Product).ProductID;//DataGrid的SelectionUnit要設為FullRow才抓的到ProductID
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
                SendProductDescription = (this.allFarmsDBEntities.Products.Where(n => n.ProductID == GetSelectProductID).FirstOrDefault()).ProductDescription;

                ProductDescription productDescription = new ProductDescription();
                if (productDescription.ShowDialog() == true)
                {                    
                    (this.allFarmsDBEntities.Products.Where(n => n.ProductID == GetSelectProductID).FirstOrDefault()).ProductDescription= AddProductDescription;//(機車)還要用.FirstOrDefault(),不能用LastOrDefault()或ToList(),才能在SaveProductDescriptiont後面點到ProductDescription        
                    (this.allFarmsDBEntities.Products.Where(n => n.ProductID == GetSelectProductID).FirstOrDefault()).LastUpdateDate = DateTime.Now;
                    this.allFarmsDBEntities.SaveChanges();
                    this.ProductsDataGrid.ItemsSource = null;
                    //this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == SupplierID && n.DeleteProduct == false).ToList();
                    this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == loginCustomerID && n.DeleteProduct == false).ToList();

                }
            }
        }

        private void cmdChangeImages_Click(object sender, RoutedEventArgs e)
        {
            if (GetSelectProductID == 0)
            {
                MessageBox.Show("請選擇修改哪筆資料");
            }
            else
            {
                ChangeImages changeImages = new ChangeImages();
                changeImages.ShowDialog();
                (this.allFarmsDBEntities.Products.Where(n => n.ProductID == GetSelectProductID).FirstOrDefault()).LastUpdateDate = DateTime.Now;
                this.allFarmsDBEntities.SaveChanges();
                this.ProductsDataGrid.ItemsSource = null;
                this.ProductsDataGrid.ItemsSource = allFarmsDBEntities.Products.Where(n => n.SupplierID == loginCustomerID && n.DeleteProduct == false).ToList();
            }


        }
    }
}
