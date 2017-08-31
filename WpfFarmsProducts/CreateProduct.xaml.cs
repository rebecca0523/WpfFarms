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

namespace WpfFarmsProducts
{
    /// <summary>
    /// CreateProduct.xaml 的互動邏輯
    /// </summary>
    public partial class CreateProduct : Window
    {
        public CreateProduct()
        {
            InitializeComponent();
        }

        farmsDBEntities farmsDBEntities = new farmsDBEntities();

        private void CreateDataButton_Click(object sender, RoutedEventArgs e)
        {
            // int ProductID = farmsDBEntities.Products.ToList().LastOrDefault().ProductID;
            Product product = new Product {
                ProductID = farmsDBEntities.Products.ToList().LastOrDefault().ProductID + 1,
                ProductName = this.txtProductName.Text,
                CreatedDate = DateTime.Now
            };
            this.farmsDBEntities.Products.Add(product);
            this.farmsDBEntities.SaveChanges();
        }
    }
}
