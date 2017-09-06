using AllData;
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
using static WpfFarmsProducts.MainWindowProducts;
using static AllData.CustomerClass;


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

        AllFarmsDBEntities allFarmsDBEntities = new AllFarmsDBEntities();

        private void CreateDataButton_Click(object sender, RoutedEventArgs e)
        {            
            //try
            //{
            Product product = new Product
            {
                ProductID = allFarmsDBEntities.Products.ToList().LastOrDefault().ProductID + 1,//0筆資料時會錯誤
                //SupplierID= SupplierID,
                SupplierID = loginCustomerID,
                ProductName = this.txtProductName.Text,
                SellStartDate = this.dtpkSellStartDate.SelectedDate,
                SellEndDate = this.dtpkSellEndDate.SelectedDate,
                MarkPrice = decimal.Parse(this.txtMarkPrice.Text),//要防輸入型別的錯誤
                UnitPrice = decimal.Parse(this.txtUnitPrice.Text),//要防輸入型別的錯誤
                PreOrder = this.chkPreOrder.IsChecked,
                ShippedDate = this.dtpkShippedDate.SelectedDate,
                ProductDescription =this.txtProductDescription.Text,
                TotalQTY = int.Parse(this.txtTotalQTY.Text),//要防輸入型別的錯誤
                CanSaleQTY = int.Parse(this.txtCanSaleQTY.Text),//要防輸入型別的錯誤
                QuantitySold = int.Parse(this.txtQuantitySold.Text),//要防輸入型別的錯誤
                Discounted = this.chkDiscounted.IsChecked,
                DiscountedCombo = this.chkDiscountedCombo.IsChecked,               
                DiscountedPoint = this.chkDiscountedPoint.IsChecked,
                CreatedDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,     
                DeleteProduct=false
            };

            this.allFarmsDBEntities.Products.Add(product);
            this.allFarmsDBEntities.SaveChanges();

            string path = new DirectoryInfo(new DirectoryInfo(System.Windows.Forms.Application.StartupPath).Parent.FullName).Parent.FullName;//移到上上層,發布後應該會有錯誤

            foreach (string i in openFileDialog.FileNames)
            {
                //FileStream fileStream = new FileStream(i, FileMode.Open);
                //byte[] ImageByte = new byte[fileStream.Length];
                //fileStream.Read(ImageByte, 0, ImageByte.Length);
                //fileStream.Close();

                string dest = System.IO.Path.Combine(path + "/Productimages", openFileDialog.SafeFileName);//合併字串,背背背背背背
                var files = System.IO.Directory.GetFiles(path + "/Productimages");

                if (files.Contains(i))
                {
                    File.Copy(i, dest);//背背背背背背
                }

                ProductImage productImage = new ProductImage
                {
                    ProductImageID = allFarmsDBEntities.ProductImages.ToList().LastOrDefault().ProductImageID + 1,
                    ProductID = product.ProductID,
                    ProductImagePath = i
                };
                this.allFarmsDBEntities.ProductImages.Add(productImage);
                this.allFarmsDBEntities.SaveChanges();
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
       
        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

        private void cmdInsertImages_Click(object sender, RoutedEventArgs e)
        {
            //this.FishEyePanel.Children.Clear();
            this.wpanelInsertImage.Children.Clear();

            openFileDialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            openFileDialog.Multiselect = true;            

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                             
                foreach (string i in openFileDialog.FileNames)//選取的檔案名子  
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
                    //Console.WriteLine(i);
                    //this.FishEyePanel.RenderTransformOrigin = new Point(0.5, 0.5);
                    //this.FishEyePanel.RenderTransform = new RotateTransform(90);                                     
                    //this.FishEyePanel.Children.Add(image);                        
                }               
            }
        }
    }
}
