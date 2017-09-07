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
using System.Windows.Threading;
using System.Threading;

namespace WpfFarmsSupplier
{
    /// <summary>
    /// SuppliersVedioCRUDMulti.xaml 的互動邏輯
    /// </summary>
    public partial class SuppliersVedioCRUDMulti : Window
    {
        DispatcherTimer timer;

        public SuppliersVedioCRUDMulti()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }

        AllFarmsDBEntities context = new AllFarmsDBEntities();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource suppliersVideoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("suppliersVideoViewSource")));
            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
            suppliersVideoViewSource.Source = context.SuppliersVideos.Where(s=>s.SuppliersID==AllData.CustomerClass.loginSupplierID ).ToList();
            System.Windows.Data.CollectionViewSource supplierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("supplierViewSource")));
            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
            supplierViewSource.Source = context.Suppliers.Where(s => s.SupplierID == AllData.CustomerClass.loginSupplierID).ToList();

        }

     

        string filename;
        SuppliersVideo SuppVideo;


        private void Window_Drop(object sender, DragEventArgs e)
        {


            filename = (string)((DataObject)e.Data).GetFileDropList()[0];
            mediaElement1.Source = new Uri(filename);
            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.UnloadedBehavior = MediaState.Manual;
            mediaElement1.Volume = (double)sliderVol.Value;
            mediaElement1.Play();
            //Thread.Sleep(100);
            //mediaElement1.Pause();



        }

        private void mediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = mediaElement1.NaturalDuration.TimeSpan;
            sliderSeek.Maximum = ts.TotalSeconds;


        }

        //AllFarmsDBEntities context = new AllFarmsDBEntities();

       
        private void Timer_Tick(object sender, EventArgs e)
        {
            sliderSeek.Value = mediaElement1.Position.TotalSeconds;
        }

        private void cmdPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Play();
        }

        private void cmdPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Pause();
        }

        private void cmdStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }

        private void sliderVol_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement1.Volume = (double)sliderVol.Value;
        }

        private void sliderSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement1.Position = TimeSpan.FromSeconds(sliderSeek.Value);
        }

        private void cmdSave_Click(object sender, RoutedEventArgs e)

        {
            //MessageBox.Show(AllData.CustomerClass.loginSupplierID.ToString());


         //   filename = @"D:\99GitHub\pinball.wmv";
            if (filename != null)
            {

                SuppVideo = new SuppliersVideo();

                System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
                System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);

                long byteLength = new System.IO.FileInfo(filename).Length;


                SuppVideo.SuppliersID = 5;
                //SuppVideo.SuppliersID =AllData.CustomerClass.loginSupplierID ;
                SuppVideo.SuppliersVideoTitle = "小農5號影片";
                SuppVideo.VideoFile = binaryReader.ReadBytes((Int32)byteLength);  //This data u can save in table



                SuppVideo.CreatedUserID = AllData.CustomerClass.loginCustomerID;
                SuppVideo.LastUpdateUserID = AllData.CustomerClass.loginCustomerID;
                SuppVideo.CreatedDate = System.DateTime.Now;
                SuppVideo.LastUpdateDate = System.DateTime.Now;

                fs.Close();
                fs.Dispose();


                context.SuppliersVideos.Add(SuppVideo);
                context.SaveChanges();

                MessageBox.Show("存檔成功");

            }




        }

        private void cmdRead_Click(object sender, RoutedEventArgs e)
        {

            SuppVideo = new SuppliersVideo();
            SuppVideo = context.SuppliersVideos.Where(c => c.SuppliersVideoID == AllData.CustomerClass.loginSupplierID).FirstOrDefault();

            Byte[] video = SuppVideo.VideoFile;




            System.IO.File.WriteAllBytes("temp1.wmv", video);
            mediaElement1.Source = new Uri("temp1.wmv", UriKind.Relative);



            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.UnloadedBehavior = MediaState.Manual;
            mediaElement1.Volume = (double)sliderVol.Value;
            mediaElement1.Play();







        }

        private void suppliersVideoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {

        }

      
    }
}
