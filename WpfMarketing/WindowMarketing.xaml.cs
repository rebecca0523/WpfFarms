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
using AllData;
using Microsoft.Win32;
using System.IO;

namespace WpfMarketing
{
    /// <summary>
    /// WindowMarketing.xaml 的互動邏輯
    /// </summary>
    public partial class WindowMarketing : Window
    {
        public WindowMarketing()
        {
            InitializeComponent();
        }
        //測試用supplierID
        int loginSupplierID = 1;

        AllFarmsDBEntities db = new AllFarmsDBEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSaleEventListBox();

            //登入者既有商品
            var p = from t in db.Products
                    where t.SupplierID == loginSupplierID
                    where t.DeleteProduct == false
                    select t.ProductName;
            cboProducts.ItemsSource = p.ToArray();
            cboAProduct.ItemsSource = p.ToArray();
            cboBProduct.ItemsSource = p.ToArray();

            //廣告

            LoadAdvertisingList();
        }
        //listbox加入登入賣家的特賣會
        private void LoadSaleEventListBox()
        {
            var t = from d in db.SaleEvents.AsEnumerable()
                    where d.SupplierID == loginSupplierID
                    select new { SaleEventTitle = d.SaleEventTitle, SaleEventStart = $"{d.SaleEventStart:d}", SaleEventEnd = $"{d.SaleEventEnd:d}" };
            lstSaleEvent.ItemsSource = t.ToList();
        }

        //C1.顯示既有的滿額折扣
        private void LoadQuotaListBox()
        {

            int EVID = int.Parse(txkEVID.Text);
            var qu = from t in db.SaleEventQuotas.AsEnumerable()
                     where t.SaleEventID == EVID
                     where t.Active == true
                     select new { Quota = $"{ t.Quota:C}", Discount = $"{t.Discount:N2}" };
            lstSaleEventQuota.ItemsSource = qu.ToList();
        }
        //C2.顯示既有的單品折扣
        private void LoadSingleListBox()
        {
            int EVID = int.Parse(txkEVID.Text);
            var si = from t in db.SaleEventSingleProducts.AsEnumerable()
                     where t.SaleEventID == EVID
                     where t.Active == true
                     join p in db.Products on t.ProductID equals p.ProductID
                     select new
                     {
                         ProductID = p.ProductID,
                         ProductName = p.ProductName,
                         UnitPrice = $"{p.UnitPrice:C0}",
                         Discount = $"{t.Discount:N2}",
                         DiscountPrice = $"{p.UnitPrice * (decimal)t.Discount:N2}"
                     };
            lstSaleEventSingle.ItemsSource = si.ToList();
        }
        //C3.顯示既有的組合商品
        private void LoadComboListBox()
        {
            int EVID = int.Parse(txkEVID.Text);
            var co = from t in db.SaleEventComboes.AsEnumerable()
                     where t.SaleEventID == EVID
                     where t.Active == true
                     join p in db.Products on t.AProductID equals p.ProductID
                     join p2 in db.Products on t.BProductID equals p2.ProductID
                     select new
                     {
                         SaleEventComboID = t.SaleEventComboID,
                         AProductID = p.ProductID,
                         AProductName = p.ProductName,
                         AProductPrice = $"{p.UnitPrice:F0}",
                         BProductID = p2.ProductID,
                         BProductName = p2.ProductName,
                         BProductPrice = $"{p2.UnitPrice:F0}",
                         SUMPrice = $"{p.UnitPrice + p2.UnitPrice:F0}",
                         Discount = $"{t.Discount:N2}",
                         DiscountPrice = $"{ (p.UnitPrice + p2.UnitPrice) * (decimal)t.Discount:N2}"
                     };

            lstSaleEventCombo.ItemsSource = co.ToList();
        }

        //S1.listbox選取改變時
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
            dtpSEStart.SelectedDate = se.SaleEventStart;
            //顯示日期 
            dtpSEEnd.SelectedDate = se.SaleEventEnd;
            //顯示內容
            txtSEContent.Text = se.SaleEventContent;

            LoadQuotaListBox();

            LoadSingleListBox();

            LoadComboListBox();



        }

        //S2.儲存活動名稱日期和內容
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int evID = int.Parse(txkEVID.Text);
            var ev = (from t in db.SaleEvents
                      where t.SaleEventID == evID
                      select t).FirstOrDefault();

            string evTitle = txtTitle.Text;
            var evStart = dtpSEStart.SelectedDate;
            var evEnd = dtpSEEnd.SelectedDate;
            string evContent = txtSEContent.Text;

            ev.SaleEventTitle = evTitle;
            ev.SaleEventStart = evStart;
            ev.SaleEventEnd = evEnd;
            ev.SaleEventContent = evContent;
            ev.EdditTime = DateTime.Now;
            this.db.SaveChanges();
            LoadSaleEventListBox();

        }
        //S3.新增活動
        private void btnNewSaleEvent_Click(object sender, RoutedEventArgs e)
        {
            SaleEvent se = new SaleEvent
            {
                SupplierID = loginSupplierID,
                SaleEventTitle = txtTitle.Text,
                SaleEventStart = dtpSEStart.SelectedDate,
                SaleEventEnd = dtpSEEnd.SelectedDate,
                SaleEventContent = txtSEContent.Text,
                EdditTime = DateTime.Now
            };
            this.db.SaleEvents.Add(se);
            this.db.SaveChanges();
            LoadSaleEventListBox();
        }

        //SC1.====滿額折扣======ListBox 選擇商品
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
        //SC2.修改滿額條件
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
        //SC3.新增滿額條件
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
        //SC4.刪除滿額條件
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
        //SS1.======單品折扣=======ListBox 選擇商品
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
            //找出被刪除的商品數量
            int d = (from t in db.Products
                     where t.ProductID < PID
                     where t.DeleteProduct == true
                     select t).Count();


            int Sindex = PID - d - 1;
            //指向ComboBox
            cboProducts.SelectedIndex = Sindex;

            CoculateSingleDiscount();

        }
        //SS2.ComboBox 選擇商品
        private void cboProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = cboProducts.SelectedIndex;
            if (n < 0) return;

            var q = (from t in db.Products
                     where t.DeleteProduct == false
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
        //SS3.修改單品折扣
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

            //存入SaleEventSingleProducts
            float F1;
            if (float.TryParse(txtProductDiscount.Text, out F1)) { } else { return; }
            sep.Discount = F1;
            sep.Active = true;
            sep.EdditTime = DateTime.Now;

            //存入Products
            var p = (from t in db.Products
                     where t.ProductID == PID
                     select t).FirstOrDefault();
            p.Discounted = true;

            this.db.SaveChanges();
            LoadSingleListBox();
        }
        //SS4.新增單品折扣
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
            var p = (from t in db.Products
                     where t.ProductID == PID
                     select t).FirstOrDefault();
            p.Discounted = true;

            this.db.SaleEventSingleProducts.Add(sep);
            this.db.SaveChanges();
            LoadSingleListBox();
        }
        //SS5.刪除單品折扣
        private void btnOffSingle_Click(object sender, RoutedEventArgs e)
        {
            int PID = int.Parse(txkPID.Text);
            var pd = (from t in db.SaleEventSingleProducts
                      where t.ProductID == PID
                      select t).FirstOrDefault();
            pd.Active = false;
            //更改db.Products 的狀態
            var p = (from t in db.Products
                     where t.ProductID == PID
                     select t).FirstOrDefault();
            p.Discounted = false;

            pd.EdditTime = DateTime.Now;
            this.db.SaveChanges();
            LoadSingleListBox();

        }
        //SS6.改變折扣時
        private void txtProductDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CoculateSingleDiscount();
        }
        //SSC.計算單品折扣
        public void CoculateSingleDiscount()
        {
            int f1;
            float f2;
            if (int.TryParse(txkUnitPrice.Text, out f1) && (float.TryParse(txtProductDiscount.Text, out f2)))
            {
                txkDiscountPrice.Text = (f1 * f2).ToString();
            }
            else
            { return; }
        }

        //====組合商品====
        //商品A ComboBox
        private void cboAProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = cboAProduct.SelectedIndex;
            if (n < 0) return;

            var pa = (from t in db.Products
                      where t.DeleteProduct == false
                      orderby t.ProductID
                      select t).Skip(n).FirstOrDefault();
            txkComAProductID.Text = pa.ProductID.ToString();
            txkAProductPrice.Text = $"{pa.UnitPrice:F0}";
            CaculateComboDiscount();
        }
        //商品B ComboBox
        private void cboBProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = cboBProduct.SelectedIndex;
            if (n < 0) return;

            var pb = (from t in db.Products
                      where t.DeleteProduct == false
                      orderby t.ProductID
                      select t).Skip(n).FirstOrDefault();
            txkComBProductID.Text = pb.ProductID.ToString();
            txkBProductPrice.Text = $"{pb.UnitPrice:F0}";
            CaculateComboDiscount();
        }
        //計算組合折扣
        private void CaculateComboDiscount()
        {
            int AP;
            int BP;
            float D;
            if ((int.TryParse(txkAProductPrice.Text, out AP) &&
                (int.TryParse(txkBProductPrice.Text, out BP)) &&
                (float.TryParse(txtComboDiscount.Text, out D))))
            {
            }
            else { return; }
            int ABP = AP + BP;

            txkSUMPrice.Text = ABP.ToString();

            var ABPD = (float)ABP * D;
            txkComboDiscountPrice.Text = $"{ABPD:C0}";
        }
        //商品組合ListBox選項改變
        private void lstSaleEventCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //ListBox選中的商品ID
            int n = lstSaleEventCombo.SelectedIndex;
            if (n < 0) return;
            string s = lstSaleEventCombo.SelectedItem.ToString();
            char[] delimiterChars = { '=', ',' };
            String[] substrings = s.Split(delimiterChars);



            txkLisAProductID.Text = substrings[3];
            txkLisBProductID.Text = substrings[9];

            int ListAProductID;
            int ListBProductID;
            if (int.TryParse(txkLisAProductID.Text, out ListAProductID) &&
                int.TryParse(txkLisBProductID.Text, out ListBProductID)
                ) { }
            else { return; }
            //ID小於AB商品ID 以被刪除
            int ad = (from t in db.Products
                      where t.ProductID < ListAProductID
                      where t.DeleteProduct == true
                      select t).Count();

            int bd = (from t in db.Products
                      where t.ProductID < ListBProductID
                      where t.DeleteProduct == true
                      select t).Count();
            //ListBox選中的組合特賣ID

            txkSEComboID.Text = substrings[1];
            int SECBID = int.Parse(txkSEComboID.Text);
            //特價值
            var sec = (from t in db.SaleEventComboes
                       where t.SaleEventComboID == SECBID
                       select t).FirstOrDefault();

            txtComboDiscount.Text = sec.Discount.ToString();

            //傳至ComboBox
            cboAProduct.SelectedIndex = ListAProductID - ad - 1;
            cboBProduct.SelectedIndex = ListBProductID - bd - 1;




        }
        //修改組合商品
        private void btnAlterCombo_Click(object sender, RoutedEventArgs e)
        {
            int SECBID;
            float DC;
            int APID;
            int BPID;
            if (int.TryParse(txkSEComboID.Text, out SECBID) &&
                (float.TryParse(txtComboDiscount.Text, out DC)) &&
                (int.TryParse(txkLisAProductID.Text, out APID) &&
                (int.TryParse(txkLisBProductID.Text, out BPID)
                )))
            { }
            else { return; }
            if (SECBID == 0) { return; }

            var evcb = (from t in db.SaleEventComboes
                        where t.SaleEventComboID == SECBID
                        select t).FirstOrDefault();
            evcb.Discount = DC;
            evcb.Active = true;
            evcb.EdditTime = DateTime.Now;

            var Aproduct = (from t in db.Products
                            where t.ProductID == APID
                            select t).FirstOrDefault();
            Aproduct.DiscountedCombo = true;

            var Bproduct = (from t in db.Products
                            where t.ProductID == BPID
                            select t).FirstOrDefault();
            Bproduct.DiscountedCombo = true;

            this.db.SaveChanges();
            LoadComboListBox();
        }
        //新增組合商品
        private void btnNewCombo_Click(object sender, RoutedEventArgs e)
        {
            if (cboAProduct.SelectedIndex <= 0 && cboBProduct.SelectedIndex < 0) { MessageBox.Show("請選擇要新增的商品組合"); } else { }
            int APID;
            int BPID;
            float DC;
            int EVID;
            if (int.TryParse(txkComAProductID.Text, out APID) &&
                int.TryParse(txkBProductPrice.Text, out BPID) &&
                int.TryParse(txkEVID.Text, out EVID) &&
       (float.TryParse(txtComboDiscount.Text, out DC)))
            { }
            else { return; }


            SaleEventCombo SEC = new SaleEventCombo { SaleEventID = EVID, AProductID = APID, BProductID = BPID, Discount = DC, Active = true, EdditTime = DateTime.Now };
            this.db.SaleEventComboes.Add(SEC);

            var Aproduct = (from t in db.Products
                            where t.ProductID == APID
                            select t).FirstOrDefault();
            Aproduct.DiscountedCombo = true;

            var Bproduct = (from t in db.Products
                            where t.ProductID == BPID
                            select t).FirstOrDefault();
            Bproduct.DiscountedCombo = true;

            this.db.SaveChanges();

            LoadComboListBox();

        }
        //刪除商品組合
        private void btnDeleteCombo_Click(object sender, RoutedEventArgs e)
        {
            int SECBID;
            int APID;
            int BPID;
            if ((int.TryParse(txkSEComboID.Text, out SECBID)) &&
                (int.TryParse(txkLisAProductID.Text, out APID) &&
                (int.TryParse(txkLisBProductID.Text, out BPID))))
            { }
            else { return; }
            if (SECBID == 0) { return; }

            var evcb = (from t in db.SaleEventComboes
                        where t.SaleEventComboID == SECBID
                        select t).FirstOrDefault();
            evcb.Active = false;

            var Aproduct = (from t in db.Products
                            where t.ProductID == APID
                            select t).FirstOrDefault();
            Aproduct.DiscountedCombo = false;

            var Bproduct = (from t in db.Products
                            where t.ProductID == BPID
                            select t).FirstOrDefault();
            Bproduct.DiscountedCombo = false;


            evcb.EdditTime = DateTime.Now;
            this.db.SaveChanges();

            LoadComboListBox();
        }
        //改變折扣時
        private void txtComboDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CaculateComboDiscount();
        }

        //AD 載入既有廣告
        private void LoadAdvertisingList()
        {
            
            var ad = from t in db.Advertisings.AsEnumerable()
                     where t.SupplierID == loginSupplierID
                     select new { AdvertisingITitle =t.AdvertisingITitle,
                          AdvertisingStartTime ="開始時間"+$"{t.AdvertisingStartTime:d}",
                          AdvertisingEndTime = "結束時間"+$"{t.AdvertisingEndTime:d}"
                     };
            lstAdvertising.ItemsSource = ad.ToList();
        }
        
        //AD.開啟廣告圖片
        private void btnOpenDialog_Click(object sender, RoutedEventArgs e)
        {

            Stream myStream = null;
            System.Windows.Forms.OpenFileDialog op = new System.Windows.Forms.OpenFileDialog();
            op.InitialDirectory = "c:\\";
            op.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
           

            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if ((myStream = op.OpenFile()) != null)
                    {
                        imgAD.Source = new BitmapImage(new Uri(op.FileName));
                        txtFileName.Text = op.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
        //AD 新增廣告
        private void btnNewAD_Click(object sender, RoutedEventArgs e)
        {
            
           var End = dtpADEnd.SelectedDate;
            Advertising ADDB = new Advertising {
                SupplierID = loginSupplierID,
                AdvertisingITitle = txtADTitle.Text,
                AdvertisingIContent = txtADContent.Text,
                AdvertisingStartTime = dtpADStart.SelectedDate,
                AdvertisingEndTime=dtpADEnd.SelectedDate,
                EdditTime =DateTime.Now

            };   

        }
        //AD 選取LISTBOX項目
        private void lstAdvertising_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = lstAdvertising.SelectedIndex;
            if (n < 0) return;

            var ADID = (from t in db.Advertisings
                        where t.SupplierID == loginSupplierID
                        orderby t.AdvertisingID
                        select t.AdvertisingID).Skip(n).FirstOrDefault();

            txkADID.Text = ADID.ToString();

            var AD = (from t in db.Advertisings
                      where t.SupplierID == loginSupplierID
                      select t).FirstOrDefault();
            txtADTitle.Text = AD.AdvertisingITitle;
            dtpADStart.SelectedDate = AD.AdvertisingStartTime;
            dtpADEnd.SelectedDate = AD.AdvertisingEndTime;
            txtADContent.Text = AD.AdvertisingIContent;


        }

    
    }
}
