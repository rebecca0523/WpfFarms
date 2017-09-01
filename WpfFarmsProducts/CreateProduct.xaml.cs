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

        farmsEntitiesHome farmsEntitiesHome = new farmsEntitiesHome();
        //farmsDBEntities farmsDBEntities = new farmsDBEntities();

        private void CreateDataButton_Click(object sender, RoutedEventArgs e)
        {
             //int ProductID = farmsEntitiesHome.Products.ToList().LastOrDefault(n=>n.ProductID==0).ProductID;
            Product product = new Product {

                //ProductID = farmsEntitiesHome.Products.ToList().LastOrDefault(n=>n.ProductID==0).ProductID + 1,
                ProductName = this.txtProductName.Text,
                SellStartDate = this.dtpkSellStartDate.DisplayDate,
                SellEndDate = this.dtpkSellEndDate.DisplayDate,
                MarkPrice = decimal.Parse(this.txtMarkPrice.Text),
                UnitPrice = decimal.Parse(this.txtUnitPrice.Text),
                PreOrder = this.chkPreOrder.IsChecked,
                CreatedDate = DateTime.Now

                //ProductID = farmsDBEntities.Products.ToList().LastOrDefault().ProductID + 1,
                //ProductName = this.txtProductName.Text,
                //SellStartDate = this.dtpkSellStartDate.DisplayDate,
                //SellEndDate = this.dtpkSellEndDate.DisplayDate,
                //MarkPrice = decimal.Parse(this.txtMarkPrice.Text),
                //UnitPrice = decimal.Parse(this.txtUnitPrice.Text),
                //PreOrder = this.chkPreOrder.IsChecked,
                //CreatedDate = DateTime.Now
            };

            this.farmsEntitiesHome.Products.Add(product);
            this.farmsEntitiesHome.SaveChanges();

            //this.farmsDBEntities.Products.Add(product);
            //this.farmsDBEntities.SaveChanges();
        }
    }
}
