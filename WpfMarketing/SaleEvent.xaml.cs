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

namespace WpfMarketing
{
    /// <summary>
    /// SaleEvent.xaml 的互動邏輯
    /// </summary>
    public partial class SaleEvent : Window
    {
        public SaleEvent()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          

            //var q = from SE in fd.SaleEvent
            //        select new { SaleEventTitle = SE.SaleEventTitle, SaleEventStart = SE.SaleEventStart, SaleEventEnd = SE.SaleEventEnd };
            //SETitleListBox.ItemsSource = q.ToList();

        }
    }
}
