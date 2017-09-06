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

namespace WpfMarketing
{
    /// <summary>
    /// WindowSaleEventNow.xaml 的互動邏輯
    /// </summary>
    public partial class WindowSaleEventNow : Window
    {
        public WindowSaleEventNow()
        {
            InitializeComponent();
        }
        AllFarmsDBEntities db = new AllFarmsDBEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSaleEventListBox();
        }
        private void LoadSaleEventListBox()
        {
            var t = from d in db.SaleEvents.AsEnumerable()
                    join s in db.Suppliers on d.SupplierID equals s.SupplierID
                    join q in db.SaleEventQuotas on d.SaleEventID equals q.SaleEventID
                    join sp in db.SaleEventSingleProducts on d.SaleEventID equals sp.SaleEventID
                    join p in db.Products on sp.ProductID equals p.ProductID
                    join cp in db.SaleEventComboes on d.SaleEventID equals cp.SaleEventID
                    join pa1 in db.Products on cp.AProductID equals pa1.ProductID
                    join pa2 in db.Products on cp.BProductID equals pa2.ProductID

                    where d.SaleEventStart <= DateTime.Now && d.SaleEventEnd >= DateTime.Now
                    select new {
                        SupplierName = s.SupplierName,
                        SaleEventTitle = d.SaleEventTitle,
                        SaleEventStart = $"{d.SaleEventStart:d}",
                        SaleEventEnd = "至  " + $"{d.SaleEventEnd:d}",
                        Quota = "滿" + $"{q.Quota:C}",
                        QuotaDiscount = "打" + q.Discount * 10 + "折",
                        SingleProductName = p.ProductName,
                        SingleProductDiscount = "打" + sp.Discount * 10 + "折",
                        AProductName = pa1.ProductName,
                        BProductName=" + "+pa2.ProductName,
                        ComboDiscount= "打" + cp.Discount*10+"折"

                    };
            lstNow.ItemsSource = t.ToArray();
        }
    }
}
