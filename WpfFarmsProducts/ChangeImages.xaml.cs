using AllData;
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

        private void cmdChangeImages_Click(object sender, RoutedEventArgs e)
        {
            
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
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(n.ProductImagePath, UriKind.Absolute);
                //bitmapImage.CacheOption();
                //bitmapImage.
            }
        }
    }
}
