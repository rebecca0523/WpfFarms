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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfFarmsProducts
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        farmsDBEntities farmsDBEntities = new farmsDBEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ProductsDataGrid.ItemsSource = farmsDBEntities.Products.ToList();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.ShowDialog();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
