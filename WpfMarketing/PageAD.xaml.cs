using System;
using System.Collections.Generic;
using System.IO;
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
using AllData;

namespace WpfMarketing
{
    /// <summary>
    /// PageAD.xaml 的互動邏輯
    /// </summary>
    public partial class PageAD : Page
    {
        public PageAD()
        {
            InitializeComponent();
        }
        AllFarmsDBEntities db = new AllFarmsDBEntities();
        int loginSupplierID = 1;
        //AD 載入既有廣告
        private void LoadAdvertisingList()
        {

            var ad = from t in db.Advertisings.AsEnumerable()
                     where t.SupplierID == loginSupplierID
                     where t.Active == true
                     select new
                     {
                         AdvertisingITitle = t.AdvertisingITitle,
                         AdvertisingStartTime = "開始時間" + $"{t.AdvertisingStartTime:d}",
                         AdvertisingEndTime = "結束時間" + $"{t.AdvertisingEndTime:d}"
                     };
            lstAdvertising.ItemsSource = ad.ToList();
        }





        //AD 新增廣告
        private void btnNewAD_Click(object sender, RoutedEventArgs e)
        {
            //圖片
            byte[] buffer;
            var bitmap = imgAD.Source as BitmapSource;
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                buffer = stream.ToArray();
            }

            Advertising ADDB = new Advertising
            {
                SupplierID = loginSupplierID,
                AdvertisingITitle = txtADTitle.Text,
                AdvertisingIContent = txtADContent.Text,
                AdvertisingStartTime = dtpADStart.SelectedDate,
                AdvertisingEndTime = dtpADEnd.SelectedDate,
                AdvertisingLink = txkADPID.Text,
                AdvertisingPhoto = buffer,
                EdditTime = DateTime.Now,
                Active = true

            };
            this.db.Advertisings.Add(ADDB);
            this.db.SaveChanges();
            LoadAdvertisingList();

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
                      where t.AdvertisingID == ADID
                      select t).FirstOrDefault();

            txtADTitle.Text = AD.AdvertisingITitle;
            dtpADStart.SelectedDate = AD.AdvertisingStartTime;
            dtpADEnd.SelectedDate = AD.AdvertisingEndTime;
            txtADContent.Text = AD.AdvertisingIContent;

            //讀取圖檔
            Stream S = new MemoryStream(AD.AdvertisingPhoto);
            BitmapImage B = new BitmapImage();
            B.BeginInit();
            B.StreamSource = S;
            B.EndInit();
            this.imgAD.Source = B;

            LoadText();
        }
        //AD 刪除
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int ADID = int.Parse(txkADID.Text);
            if (ADID <= 0) return;

            var AD = (from t in db.Advertisings
                      where t.SupplierID == loginSupplierID
                      select t).FirstOrDefault();
            AD.Active = true;
            LoadAdvertisingList();
        }
        //AD 修改
        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            int ADID = int.Parse(txkADID.Text);
            if (ADID <= 0) return;

            var AD = (from t in db.Advertisings
                      where t.AdvertisingID == ADID
                      select t).FirstOrDefault();
            AD.AdvertisingITitle = txtADTitle.Text;
            AD.AdvertisingIContent = txtADContent.Text;
            AD.AdvertisingLink = txkADPID.Text;
            AD.Active = true;

            //修改圖檔
            byte[] buffer;
            var bitmap = imgAD.Source as BitmapSource;
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                buffer = stream.ToArray();
            }
            AD.AdvertisingPhoto = buffer;

            this.db.SaveChanges();
            LoadAdvertisingList();

        }

        //AD 商品combobox
        private void cboADProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = cboADProduct.SelectedIndex;
            if (n < 0) return;

            var q = (from t in db.Products
                     where t.DeleteProduct == false
                     orderby t.ProductID
                     select t).Skip(n).FirstOrDefault();

            txkADPID.Text = q.ProductID.ToString();
        }

           //AD 對應商品預覽
        private void LoadText()
        {
            txkADTitleOnImage.Text = txtADTitle.Text;
            txkADContentOnImage.Text = txtADContent.Text;
        }
        //AD.開啟廣告圖片


        private void btnOpenDialog_Click(object sender, RoutedEventArgs e)
        {

            Stream myStream = null;
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif";


            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if ((myStream = dlg.OpenFile()) != null)
                    {
                        imgAD.Source = new BitmapImage(new Uri(dlg.FileName));

                        txtFileName.Text = dlg.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }


        private void txtADTitle_KeyDown(object sender, KeyEventArgs e)
        {
            LoadText();
        }

        private void txtADContent_KeyDown(object sender, KeyEventArgs e)
        {
            LoadText();
        }


    }
}
