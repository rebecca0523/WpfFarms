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

            foreach (string i in allowableFileTypes)
            {
                FileStream fileStream = new FileStream(i, FileMode.Open);
                byte[] ImageByte = new byte[fileStream.Length];
                fileStream.Read(ImageByte, 0, ImageByte.Length);
                fileStream.Close();
                ProductImage productImage = new ProductImage
                {
                    ProductImageID = farmsDBEntities.ProductImages.ToList().LastOrDefault().ProductImageID + 1,
                    ProductID = product.ProductID,
                    ProductImage1 = ImageByte
                };
                this.farmsDBEntities.ProductImages.Add(productImage);
                this.farmsDBEntities.SaveChanges();
            }

            MessageBox.Show("新增檔案完成");
            this.DialogResult = true;
            this.Close();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        List<string> allowableFileTypes = new List<string>();

        private void cmdInsertImages_Click(object sender, RoutedEventArgs e)
        {
            allowableFileTypes.Clear();
            //this.FishEyePanel.Children.Clear();
            this.wpanelInsertImage.Children.Clear();

            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                allowableFileTypes.AddRange(openFileDialog.FileNames);//把選取的檔案名子放進allowableFileTypes
                
                foreach (string i in allowableFileTypes)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    Image image = new Image();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(i, UriKind.Absolute);
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;//在載入時快取整個影像至記憶體。 影像資料的所有要求都會從記憶體存放區填入
                    bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;//載入影像時未使用現有的影像快取。 只有在快取中的影像需要重新整理時，才應該選取此選項
                    bitmapImage.EndInit();
                    image.Source = bitmapImage;
                    this.wpanelInsertImage.Children.Add(image);
                    //this.FishEyePanel.RenderTransformOrigin = new Point(0.5, 0.5);
                    //this.FishEyePanel.RenderTransform = new RotateTransform(90);                                     
                    //this.FishEyePanel.Children.Add(image);                        
                }               
            }
        }
    }
}
