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
    /// WindowSalEvent.xaml 的互動邏輯
    /// </summary>
    public partial class WindowSalEvent : Window
    {
        public WindowSalEvent()
        {
            InitializeComponent();
        }

        int loginSupplierID = 1;
        farmsDBEntities db = new farmsDBEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          


            //listbox加入登入賣家的特賣會
            var t = from d in db.SaleEvent
                    where d.SupplierID == loginSupplierID
                    select new { SaleEventTitle = d.SaleEventTitle, SaleEventStar = d.SaleEventStart, SaleEventEnd = d.SaleEventEnd };
            lstSaleEvent.ItemsSource = t.ToList();

           
                   
        }

        //listbox選取改變時
        private void lstSaleEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //選取的index
            int n = int.Parse(lstSaleEvent.SelectedIndex.ToString());

            //選取listbox item的活動ID
            var EVID = (from t in db.SaleEvent
                               where t.SupplierID == loginSupplierID
                               orderby t.SaleEventID
                               select t.SaleEventID).Skip(n).FirstOrDefault();
            // 改變特賣會內容
            var c = (from t in db.SaleEvent
                    where t.SaleEventID == EVID
                    select t.SaleEventContent).FirstOrDefault();
            txtSEContent.Text = c + "           " + n;

            //顯示既有的滿額折扣

            var qu = from t in db.SaleEventQuota.AsEnumerable()
                    where t.SaleEventID == EVID
                    select new { Quota =$"{ t.Quota:C}", Discount=$"{t.Discount:N2}" };
            lstSaleEventQuota.ItemsSource = qu.ToList();

            //顯示既有的單品折扣
            var si = from t in db.SaleEventSingleProducts.AsEnumerable()
                    where t.SaleEventID == EVID
                    join p in db.Products on t.ProductID equals p.ProductID
                    select new { ProductName = p.ProductName, UnitPrice =$"{p.UnitPrice:C}", Discount = $"{t.Discount:N2}" , DiscountPrice =$"{p.UnitPrice * (decimal)t.Discount:N2}" };
            lstSaleEventSingle.ItemsSource = si.ToList();

            //顯示既有的組合商品

            var co = from t in db.SaleEventComboes.AsEnumerable()
                     where t.SaleEventID == EVID
                     join p in db.Products on t.AProductID equals p.ProductID
                     join p2 in db.Products on t.BProductID equals p2.ProductID
                     select new { AProductName = p.ProductName, AProductPrice=p.UnitPrice,
                                  BProductName = p2.ProductName, BProductPrice=p2.UnitPrice,
                                  SUMPrice =$"{p.UnitPrice + p2.UnitPrice:C}" ,
                         Discount=$"{t.Discount:N2}",
                         DiscountPrice=$"{ (p.UnitPrice + p2.UnitPrice) * (decimal)t.Discount:C}"
                     };


            lstSaleEventCombo.ItemsSource = co.ToList();
           
        }
    }
}
