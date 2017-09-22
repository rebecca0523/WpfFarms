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

namespace WpfFrontpage
{
    /// <summary>
    /// ProductButton.xaml 的互動邏輯
    /// </summary>
    public partial class ProductButton : UserControl
    {
        public ProductButton()
        {
            InitializeComponent();
        }

        //商品名字
        public string ProductButtonName
        {
            get { return txkName.Text; }
            set { txkName.Text = value; }
        }

        //商品價格
        public string ProductButtonPrice
        {
            get { return txkPrice.Text; }
            set { txkPrice.Text = value; }
        }
        //商品圖片
        public ImageSource ImageLocation
        {
            get { return ImageProduct.Source; }
            set { ImageProduct.Source = value; }
            

        }
    }
}

  
