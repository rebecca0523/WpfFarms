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

namespace WpfFarmsActivity
{
    /// <summary>
    /// ActivityManagement.xaml 的互動邏輯
    /// </summary>
    public partial class ActivityManagement : Window
    {
        public ActivityManagement()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            global::WpfFarmsActivity.UserControl1 x = new UserControl1();
            x.addActivity.Click += AddActivity_Click;
            this.ListWrapPanel.Children.Add(x);
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
