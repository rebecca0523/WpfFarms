using AllData;
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

namespace WpfMarketing
{
    /// <summary>
    /// AdvertisingButton.xaml 的互動邏輯
    /// </summary>
    public partial class AdvertisingButton : UserControl
    {
        public AdvertisingButton()
        {
            InitializeComponent();
        }
        AllFarmsDBEntities db = new AllFarmsDBEntities();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            var AD = (from t in db.Advertisings
                     where t.AdvertisingID == 1
                     select t).FirstOrDefault();
            txkTitle.Text = AD.AdvertisingITitle.ToString();
            txkContent.Text = AD.AdvertisingIContent.ToString();

            Stream S = new MemoryStream(AD.AdvertisingPhoto);
            BitmapImage B = new BitmapImage();
            B.BeginInit();
            B.StreamSource = S;
            B.EndInit();
            this.ButtonImage.Source = B;

        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            var AD = (from t in db.Advertisings
                      where t.AdvertisingID == 1
                      select t).FirstOrDefault();
            int ADLink = int.Parse(AD.AdvertisingLink);
            MessageBox.Show(ADLink+"");
        }
    }
}
