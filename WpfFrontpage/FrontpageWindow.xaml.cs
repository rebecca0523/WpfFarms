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
using wpfFarmsCustomer;

namespace WpfFarms
{
    /// <summary>
    /// FrontpageWindow.xaml 的互動邏輯
    /// </summary>
    public partial class FrontpageWindow : Window
    {
        public FrontpageWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BGmediaElement.Play();
            TableItemLoginAndRegister.Content = new Frame
            {
                Content = new PageLoginAndRegister()
            };
        }

        //重複播放
        private void BGmediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            BGmediaElement.Stop();
            BGmediaElement.Play();
        }

      
    }
}
