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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMarketing
{
    /// <summary>
    /// PageMarketing.xaml 的互動邏輯
    /// </summary>
    public partial class PageMarketing : Page
    {
        public PageMarketing()
        {
            InitializeComponent();
        }
        AllFarmsDBEntities db = new AllFarmsDBEntities();
        
        int loginSupplierID = 1;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TabItemSE.Content = new Frame
            {
                Source = new Uri("PageDiscount.xaml", UriKind.RelativeOrAbsolute)
            };
            TabItemAD.Content = new Frame
            {
                Source = new Uri("PageAD.xaml", UriKind.RelativeOrAbsolute)
            };
        }
    }
}
