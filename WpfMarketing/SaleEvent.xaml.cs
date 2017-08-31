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

        int loginSupplierID = 1;
        farmsDBEntities db = new farmsDBEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            dtgTemp.ItemsSource = db.SaleEvents.ToArray();
         

            //listbox加入登入賣家的特賣會
            var q = from d in db.SaleEvents
                    where d.SupplierID == loginSupplierID
                    select new { SaleEventTitle =d.SaleEventTitle, SaleEventStar =d.SaleEventStart, SaleEventEnd =d.SaleEventEnd};
            lstSaleEvent.ItemsSource = q.ToList();

            //
        }


     
        private void lstSaleEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //選取的index
            int n = int.Parse(lstSaleEvent.SelectedIndex.ToString());

            //listbox選取改變時 改變特賣會內容
            var q = (from t in db.SaleEvents
                    where t.SupplierID == loginSupplierID
                    select t.SaleEventContent).OrderBy(s=>SaleEventID).Skip(n).FirstOrDefault();
                     txtSEContent.Text = q+"           "+n;
            
        }
    }
}
