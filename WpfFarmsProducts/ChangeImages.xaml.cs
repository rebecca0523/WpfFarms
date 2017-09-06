using AllData;
using Microsoft.Win32;
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

namespace WpfFarmsProducts
{
    /// <summary>
    /// ChangeImages.xaml 的互動邏輯
    /// </summary>
    public partial class ChangeImages : Window
    {
        public ChangeImages()
        {
            InitializeComponent();
        }

        AllFarmsDBEntities allFarmsDBEntities = new AllFarmsDBEntities();
        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

        private void cmdChangeImages_Click(object sender, RoutedEventArgs e)
        {
            this.wpanelChangeImages.Children.Clear();
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
                    image.Height = 100;
                    image.Width = 100;
                    this.wpanelChangeImages.Children.Add(image);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var q = from n in allFarmsDBEntities.ProductImages
                    where n.ProductID == GetSelectProductID
                    select n;
            foreach(var n in q)
            {
                BitmapImage bitmapImage = new BitmapImage();
                Image image = new Image();
                if (n.ProductImagePath != null)
                {
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(n.ProductImagePath, UriKind.Absolute);
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bitmapImage.EndInit();
                    image.Height = 100;
                    image.Width = 100;
                    image.Source = bitmapImage;
                }
                //image.MouseEnter += Image_MouseEnter;
                //image.MouseLeave += Image_MouseLeave;
                this.wpanelChangeImages.Children.Add(image);
            }
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Height = 400;
            ((Image)sender).Width = 400;
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Height = 100;
            ((Image)sender).Width = 100;
        }

        string path = new DirectoryInfo(new DirectoryInfo(System.Windows.Forms.Application.StartupPath).Parent.FullName).Parent.FullName;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (string i in openFileDialog.FileNames)
            {
                //FileStream fileStream = new FileStream(i, FileMode.Open);
                //byte[] ImageByte = new byte[fileStream.Length];
                //fileStream.Read(ImageByte, 0, ImageByte.Length);
                //fileStream.Close();
                
                string dest = System.IO.Path.Combine(path+"/Productimages", openFileDialog.SafeFileName);//合併字串,背背背背背背
                var files = System.IO.Directory.GetFiles(path + "/Productimages");
                
                if ( files.Contains(i))
                {
                    File.Copy(i, dest);//背背背背背背
                }

                ProductImage productImage = new ProductImage
                {
                    ProductImageID = allFarmsDBEntities.ProductImages.ToList().LastOrDefault().ProductImageID + 1,
                    ProductID = GetSelectProductID,
                    ProductImagePath = i
                };
                this.allFarmsDBEntities.ProductImages.Add(productImage);
                this.allFarmsDBEntities.SaveChanges();
            }

            MessageBox.Show("新增檔案完成");
            this.DialogResult = true;
            this.Close();
        }
        
    }
}
