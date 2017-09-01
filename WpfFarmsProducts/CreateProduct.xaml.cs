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
            //try
            //{
            Product product = new Product
            {
                ProductID = farmsDBEntities.Products.ToList().LastOrDefault().ProductID + 1,//0筆資料時會錯誤
                ProductName = this.txtProductName.Text,
                SellStartDate = this.dtpkSellStartDate.DisplayDate,
                SellEndDate = this.dtpkSellEndDate.DisplayDate,
                MarkPrice = decimal.Parse(this.txtMarkPrice.Text),
                UnitPrice = decimal.Parse(this.txtUnitPrice.Text),
                PreOrder = this.chkPreOrder.IsChecked,
                ShippedDate=this.dtpkShippedDate.DisplayDate,
                TotalQTY=int.Parse(this.txtTotalQTY.Text),
                CanSaleQTY=int.Parse(this.txtCanSaleQTY.Text),
                QuantitySold=int.Parse(this.txtQuantitySold.Text),
                Discounted=this.chkDiscounted.IsChecked,
                DiscountedAB=this.chkDiscountedAB.IsChecked,
                DiscountedQuota=this.chkDiscountedQuota.IsChecked,
                DiscountedPoint=this.chkDiscountedPoint.IsChecked,
                CreatedDate = DateTime.Now,
                LastUpdateDate=DateTime.Now
            };

            this.farmsDBEntities.Products.Add(product);
            this.farmsDBEntities.SaveChanges();

            MessageBox.Show("新增檔案完成");
            this.DialogResult = true;
            this.Close();



            //}
            //catch(System.FormatException ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.txtbCreatedDate.Text = DateTime.Now.ToShortDateString();
            //this.txtbLastUpdateDate.Text= DateTime.Now.ToShortDateString();
        }

        private void cmdInsertImages_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

        }
    }
}
