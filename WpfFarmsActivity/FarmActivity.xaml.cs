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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfFarmsActivity
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class FarmActivity : Window
    {
        public FarmActivity()
        {
            InitializeComponent();
        }



        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            ActivityManagement Activity = new ActivityManagement();
            global::WpfFarmsActivity.UserControl1 x = new UserControl1();
            x.addActivity.Click += AddActivity_Click;
            x.ActivityName.Content = NametextBox.Text;
            Activity.ListWrapPanel.Children.Add(x);
            Activity.Show();
        }

        private void ActivityWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void AddActivity_Click(object sender, RoutedEventArgs e)
        {
            ActivityList activity = new ActivityList();
            activity.Show();
            for (int i = 0; i < VisualChildrenCount; i++)
            {
                global::WpfFarmsActivity.ActivityListItem x = new ActivityListItem();
                activity.ListPanel.Children.Add(x);
            }
        }
    }
}
