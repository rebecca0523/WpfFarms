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
    /// ProductDescription.xaml 的互動邏輯
    /// </summary>
    public partial class ProductDescription : Window
    {
        public ProductDescription()
        {
            InitializeComponent();
        }

        AllFarmsDBEntities allFarmsDBEntities = new AllFarmsDBEntities();
        public static string AddProductDescription;

        private void cmdSaveProductDescription_Click(object sender, RoutedEventArgs e)
        {
            AddProductDescription = txtProductDescription.Text;

            MessageBox.Show("產品描述新增完成");
            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtProductDescription.Text = SendProductDescription;
        }
    }
}
