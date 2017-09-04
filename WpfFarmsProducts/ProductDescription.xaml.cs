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

        farmsDBEntities farmsDBEntities = new farmsDBEntities();

        private void cmdSaveProductDescription_Click(object sender, RoutedEventArgs e)
        {
            var deleteProduct = this.farmsDBEntities.Products.Where(n => n.ProductID == GetSelectProductID).FirstOrDefault();//(機車)還要用.FirstOrDefault(),不能用LastOrDefault()或ToList(),才能在deleteProduct後面點到DeleteProduct        
            deleteProduct.ProductDescription = txtProductDescription.Text;
            this.farmsDBEntities.SaveChanges();

            MessageBox.Show("產品描述新增完成");
            this.DialogResult = true;
            this.Close();
        }
    }
}
