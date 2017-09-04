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
        int count;
        FarmActivity FA = new FarmActivity();
        global::WpfFarmsActivity.UserControl1[] x = new UserControl1[50];
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FA = new FarmActivity();
            FA.Show();
            FA.Accept.Click += new RoutedEventHandler(Accept_Click);
            FA.Cancel.Click += new RoutedEventHandler(Cancel_Click);
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            
            x[count] = new UserControl1();
            x[count].Name = "ActivityTable" + count;
            x[count].addActivity.Click += new RoutedEventHandler(AddActivity_Click);
            x[count].EditActivity.Click += new RoutedEventHandler(EditActivity_Click);
            x[count].ActivityName.Name = "ActivityName" + count;
            x[count].ActivityName.Content = FA.ActivityNameInput.Text;
            this.ListWrapPanel.Children.Add(x[count]);
            FA.Hide();
            count++;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            FA.Hide();
        }
        private void EditActivity_Click(object sender, RoutedEventArgs e)
        {
            FarmActivityEdit FarmEdit = new FarmActivityEdit();
            FarmEdit.Show();
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
