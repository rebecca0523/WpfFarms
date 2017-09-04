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

            LoadSaleEventListBox();

            //登入者既有商品
            var p = from t in db.Products
                    where t.SupplierID == loginSupplierID
                    select t.ProductName;
            cboProducts.ItemsSource = p.ToArray();
        }

        private void LoadSaleEventListBox()
        {
            //listbox加入登入賣家的特賣會
            var t = from d in db.SaleEvents.AsEnumerable()
                    where d.SupplierID == loginSupplierID
                    select new { SaleEventTitle = d.SaleEventTitle, SaleEventStar = $"{d.SaleEventStart:d}", SaleEventEnd = $"{d.SaleEventEnd:d}" };
            lstSaleEvent.ItemsSource = t.ToList();
        }

        //顯示既有的滿額折扣
        private void LoadQuotaListBox()
        {

            int EVID = int.Parse(txkEVID.Text);
            var qu = from t in db.SaleEventQuotas.AsEnumerable()
                     where t.SaleEventID == EVID
                     where t.Active == true
                     select new { Quota = $"{ t.Quota:C}", Discount = $"{t.Discount:N2}" };
            lstSaleEventQuota.ItemsSource = qu.ToList();
        }
        //顯示既有的單品折扣
        private void LoadSingleListBox()
        {
            int EVID = int.Parse(txkEVID.Text);
            var si = from t in db.SaleEventSingleProducts.AsEnumerable()
                     where t.SaleEventID == EVID
                     join p in db.Products on t.ProductID equals p.ProductID
                     select new { ProductID = p.ProductID, ProductName = p.ProductName, UnitPrice = $"{p.UnitPrice:C0}", Discount = $"{t.Discount:N2}", DiscountPrice = $"{p.UnitPrice * (decimal)t.Discount:N2}" };
            lstSaleEventSingle.ItemsSource = si.ToList();
        }

        //listbox選取改變時
        private void lstSaleEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //選取的index
            int n = lstSaleEvent.SelectedIndex;

            if (n < 0) return;
            //選取listbox item的活動ID
            var EVID = (from t in db.SaleEvents
                        where t.SupplierID == loginSupplierID
                        orderby t.SaleEventID
                        select t.SaleEventID).Skip(n).FirstOrDefault();
            txkEVID.Text = EVID.ToString();
            //顯示標題 日期 內容
            var se = (from t in db.SaleEvents
                      where t.SaleEventID == EVID
                      select t).FirstOrDefault();
            //顯示標題 
            txtTitle.Text = se.SaleEventTitle;
            //顯示日期
            dtpStart.SelectedDate = se.SaleEventStart;
            //顯示日期 
            dtpEnd.SelectedDate = se.SaleEventEnd;
            //顯示內容
            txtSEContent.Text = se.SaleEventContent;

            LoadQuotaListBox();

            LoadSingleListBox();
            //顯示既有的組合商品
            var co = from t in db.SaleEventComboes.AsEnumerable()
                     where t.SaleEventID == EVID
                     join p in db.Products on t.AProductID equals p.ProductID
                     join p2 in db.Products on t.BProductID equals p2.ProductID
                     select new
                     {
                         AProductName = p.ProductName,
                         AProductPrice = p.UnitPrice,
                         BProductName = p2.ProductName,
                         BProductPrice = p2.UnitPrice,
                         SUMPrice = $"{p.UnitPrice + p2.UnitPrice:C}",
                         Discount = $"{t.Discount:N2}",
                         DiscountPrice = $"{ (p.UnitPrice + p2.UnitPrice) * (decimal)t.Discount:C}"
                     };
            lstSaleEventCombo.ItemsSource = co.ToList();

        }

        //儲存活動名稱日期和內容
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int evID = int.Parse(txkEVID.Text);
            var ev = (from t in db.SaleEvents
                      where t.SaleEventID == evID
                      select t).FirstOrDefault();

            string evTitle = txtTitle.Text;
            var evStart = dtpStart.SelectedDate;
            var evEnd = dtpEnd.SelectedDate;
            string evContent = txtSEContent.Text;

            ev.SaleEventTitle = evTitle;
            ev.SaleEventStart = evStart;
            ev.SaleEventEnd = evEnd;
            ev.SaleEventContent = evContent;
            ev.EdditTime = DateTime.Now;
            this.db.SaveChanges();
            LoadSaleEventListBox();

        }
        //新增活動
        private void btnNewSaleEvent_Click(object sender, RoutedEventArgs e)
        {
            SaleEvent se = new SaleEvent
            {
                SupplierID = loginSupplierID,
                SaleEventTitle = txtTitle.Text,
                SaleEventStart = dtpStart.SelectedDate,
                SaleEventEnd = dtpEnd.SelectedDate,
                SaleEventContent = txtSEContent.Text,
                EdditTime = DateTime.Now
            };
            this.db.SaleEvents.Add(se);
            this.db.SaveChanges();
            LoadSaleEventListBox();
        }

        //====滿額折扣======
        private void lstSaleEventQuota_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //活動ID
            int EVID = int.Parse(txkEVID.Text);
            //選取的index
            int n = lstSaleEventQuota.SelectedIndex;

            if (n < 0) return;
            var EVQID = (from t in db.SaleEventQuotas
                         where t.SaleEventID == EVID
                         where t.Active == true
                         orderby t.SaleEventQuotaID
                         select t.SaleEventQuotaID).Skip(n).FirstOrDefault();
            txkQID.Text = EVQID.ToString();

            var qq = (from t in db.SaleEventQuotas.AsEnumerable()
                      where t.SaleEventQuotaID == EVQID
                      select $"{t.Quota:N0}").FirstOrDefault();
            txtQuota.Text = qq.ToString();

            var qd = (from t in db.SaleEventQuotas.AsEnumerable()
                      where t.SaleEventQuotaID == EVQID
                      select t.Discount).FirstOrDefault();
            txtQuotaDiscount.Text = qd.ToString();

        }
        //修改滿額條件
        private void btnAlterQuota_Click(object sender, RoutedEventArgs e)
        {
            int EVID;
            int QID;
            int QQuota;
            float QDiscount;

            if (int.TryParse(txkEVID.Text, out EVID) &&
                int.TryParse(txkQID.Text, out QID) &&
                int.TryParse(txtQuota.Text, out QQuota) &&
                float.TryParse(txtQuotaDiscount.Text, out QDiscount))
            {
            }
            else { return; }


            if (QID < 0) return;
            var evq = (from t in db.SaleEventQuotas
                       where t.SaleEventQuotaID == QID
                       select t).FirstOrDefault();


            evq.Quota = QQuota;
            evq.Discount = QDiscount;
            evq.Active = true;
            evq.EdditTime = DateTime.Now;
            this.db.SaveChanges();
            LoadQuotaListBox();

        }
        //新增滿額條件
        private void btnNewQuota_Click(object sender, RoutedEventArgs e)
        {
            int EVID = int.Parse(txkEVID.Text);
            var qm = Convert.ToDecimal(txtQuota.Text);
            var qd = float.Parse(txtQuotaDiscount.Text);

            SaleEventQuota SQ = new SaleEventQuota { SaleEventID = EVID, Quota = qm, Discount = qd, Active = true, EdditTime = DateTime.Now };
            this.db.SaleEventQuotas.Add(SQ);
            this.db.SaveChanges();
            LoadQuotaListBox();
        }
        //刪除滿額條件
        private void btnOffQuota_Click(object sender, RoutedEventArgs e)
        {
            int QID;
            if (int.TryParse(txkQID.Text, out QID)) { } else { return; }
            var q = (from t in db.SaleEventQuotas
                     where t.SaleEventQuotaID == QID
                     select t).FirstOrDefault();
            q.Active = false;
            q.EdditTime = DateTime.Now;
            this.db.SaveChanges();
            LoadQuotaListBox();
        }
        //======單品折扣=======
        //ListBox 選擇商品
        private void lstSaleEventSingle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //挑出ID
            int n = lstSaleEventSingle.SelectedIndex;
            if (n < 0) return;
            string s = lstSaleEventSingle.SelectedItem.ToString();
            char[] delimiterChars = { '=', ',' };
            String[] substrings = s.Split(delimiterChars);
            txkPID.Text = substrings[1];
            int PID = int.Parse(txkPID.Text);

            //指向ComboBox
            cboProducts.SelectedIndex = PID - 1;

            CoculateSingleDiscount();

        }
        //ComboBox 選擇商品
        private void cboProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = cboProducts.SelectedIndex;
            if (n < 0) return;
            //string pn =cboProducts.SelectedValue.ToString();

            var q = (from t in db.Products
                     orderby t.ProductID
                     select t).Skip(n).FirstOrDefault();

            txkcboPID.Text = q.ProductID.ToString();

            txkUnitPrice.Text = $"{q.UnitPrice:F0}";



            //顯示單品打折折扣
            var d = (from t in db.SaleEventSingleProducts
                     where t.ProductID == q.ProductID
                     select t.Discount).FirstOrDefault();

            if (d == null)
            {
                txtProductDiscount.Text = 1 + "";
            }
            else
            {
                txtProductDiscount.Text = d + "";
            }

            CoculateSingleDiscount();

        }
        //修改單品折扣
        private void btnAlterSingle_Click(object sender, RoutedEventArgs e)
        {
            //combobox商品ID
            int PID = int.Parse(txkcboPID.Text);
            var sep = (from t in db.SaleEventSingleProducts
                       where t.ProductID == PID
                       select t).FirstOrDefault();

            //未加入活動商品不能修改
            if (sep == null)
            {
                MessageBox.Show("請先新增產品");
                return;
            }
            else { }


            var p = (from t in db.Products
                     where t.ProductID == PID
                     select t).FirstOrDefault();
            //存入SaleEventSingleProducts
            float F1;
            if (float.TryParse(txtProductDiscount.Text, out F1)) { } else { return; }
            sep.Discount = F1;
            sep.Active = true;
            sep.EdditTime = DateTime.Now;
            //存入Products
            p.Discounted = true;

            this.db.SaveChanges();
            LoadSingleListBox();
        }
        //新增單品折扣
        private void btnNewSingle_Click(object sender, RoutedEventArgs e)
        {
            //combobox商品ID
            int EVID = int.Parse(txkEVID.Text);
            int PID = int.Parse(txkcboPID.Text);
            var qd = float.Parse(txtProductDiscount.Text);
            SaleEventSingleProduct sep = new SaleEventSingleProduct
            {
                SaleEventID = EVID,
                ProductID = PID,
                Discount = qd,
                Active = true,
                EdditTime = DateTime.Now
            };
            this.db.SaleEventSingleProducts.Add(sep);
            this.db.SaveChanges();
            LoadSingleListBox();
        }
        //刪除單品折扣
        private void btnOffSingle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtProductDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CoculateSingleDiscount();
        }
        //計算單品折扣
        public void CoculateSingleDiscount()
        {
            int f1 ;
            float f2 ;
            if (int.TryParse(txkUnitPrice.Text, out f1) && (float.TryParse(txtProductDiscount.Text, out f2)))
            {
                txkDiscountPrice.Text = (f1 * f2).ToString();
            }
            else
            { return; }
        }
    }

}
