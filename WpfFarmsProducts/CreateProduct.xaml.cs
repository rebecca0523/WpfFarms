using System;
using System.Collections.Generic;
using System.IO;
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
                MarkPrice = decimal.Parse(this.txtMarkPrice.Text),//型別要再判斷
                UnitPrice = decimal.Parse(this.txtUnitPrice.Text),//型別要再判斷
                PreOrder = this.chkPreOrder.IsChecked,
                ShippedDate = this.dtpkShippedDate.DisplayDate,
                TotalQTY = int.Parse(this.txtTotalQTY.Text),//型別要再判斷
                CanSaleQTY = int.Parse(this.txtCanSaleQTY.Text),//型別要再判斷
                QuantitySold = int.Parse(this.txtQuantitySold.Text),//型別要再判斷
                Discounted = this.chkDiscounted.IsChecked,
                DiscountedAB = this.chkDiscountedAB.IsChecked,
                DiscountedQuota = this.chkDiscountedQuota.IsChecked,
                DiscountedPoint = this.chkDiscountedPoint.IsChecked,
                CreatedDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
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
            openFileDialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            openFileDialog.Multiselect = true;
            List<string> allowableFileTypes = new List<string>();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                allowableFileTypes.AddRange(openFileDialog.FileNames);//把要的檔案放進allowableFileTypes

                foreach (string i in allowableFileTypes)
                {
                    Image image = new Image();
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(i, UriKind.Absolute);
                    bitmapImage.EndInit();
                    image.Source = bitmapImage;
                    this.wpanelInsertImage.Children.Add(image);
                }
                //    //if (!openFileDialog.FileName.Equals(String.Empty))
                //    //{
                //    //    FileInfo f = new FileInfo(openFileDialog.FileName);
                //    //    if (allowableFileTypes.Contains(f.Extension.ToLower()))
                //    //    {
                //    //        Image image = new Image();
                //    //        image.Source = f.FullName;
                //    //    }
                //    //    else
                //    //    {
                //    //        MessageBox.Show("Invalid file type");
                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    MessageBox.Show("You did pick a file to use");
                //    //}
            }
        }
    }
}
