using AllData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;



namespace WpfFarmsSupplier
{
    /// <summary>
    /// SuppliersVideoCRUD.xaml 的互動邏輯
    /// </summary>
    public partial class SuppliersVideoCRUD : Window
    {
        DispatcherTimer timer;
        public SuppliersVideoCRUD()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }

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

        string filename;

        private void Window_Drop(object sender, DragEventArgs e)
        {


            filename = (string)((DataObject)e.Data).GetFileDropList()[0];

        //    MessageBox.Show(filename);


            mediaElement1.Source = new Uri(filename);
            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.UnloadedBehavior = MediaState.Manual;
            mediaElement1.Volume = (double)sliderVol.Value;
            mediaElement1.Play();

            

                }

        private void mediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = mediaElement1.NaturalDuration.TimeSpan;
            sliderSeek.Maximum = ts.TotalSeconds;


        }

        AllFarmsDBEntities context = new AllFarmsDBEntities();
        
        SuppliersVideo SuppVideo;


        private void cmdSave_Click(object sender, RoutedEventArgs e)
            
        {
            filename = @"D:\99GitHub\pinball.wmv";
            if (filename!=null)
            {

                SuppVideo = new SuppliersVideo();

                 System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
                 System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);

                long byteLength = new System.IO.FileInfo(filename).Length;






                SuppVideo.SuppliersID = 5;
                SuppVideo.SuppliersStoryTitle = "小農5號影片";
                SuppVideo.VideoFile = binaryReader.ReadBytes((Int32)byteLength);  //This data u can save in table

                fs.Close();
                fs.Dispose();
 

                context.SuppliersVideos.Add(SuppVideo);
                context.SaveChanges();

            }




        }

        private void cmdRead_Click(object sender, RoutedEventArgs e)
        {
            
            SuppVideo = new SuppliersVideo();
            SuppVideo = context.SuppliersVideos.Where(c => c.SuppliersVideoID == 5).FirstOrDefault();

            Byte[] video = SuppVideo.VideoFile;


                       

            System.IO.File.WriteAllBytes("temp1.wmv", video);
            mediaElement1.Source = new Uri("temp1.wmv", UriKind.Relative);

            

            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.UnloadedBehavior = MediaState.Manual;
            mediaElement1.Volume = (double)sliderVol.Value;
            mediaElement1.Play();



            



        }
    }
}
