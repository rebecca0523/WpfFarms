using System;
using System.Collections.Generic;
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
    /// SuppliersVedioCRUD.xaml 的互動邏輯
    /// </summary>
    public partial class SuppliersVedioCRUD : Window
    {
        DispatcherTimer timer;
        public SuppliersVedioCRUD()
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

        private void Window_Drop(object sender, DragEventArgs e)
        {


            string filename = (string)((DataObject)e.Data).GetFileDropList()[0];
 ;          mediaElement1.Source = new Uri(filename);

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
    }
}
