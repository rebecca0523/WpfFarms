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
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            farmsDBEntities db = new farmsDBEntities();
            DataGrid1.ItemsSource = db.SaleEvents.ToArray();




            TextBox1.Text = (from t in db.SaleEvents
                             where t.SaleEventID == 3
                             select t.SaleEventContent).FirstOrDefault();
            



        }
    }
}
