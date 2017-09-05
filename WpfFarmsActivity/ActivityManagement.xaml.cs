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
        void Activity()
        {
            addActivity = new ActivityFarmer();
            addActivity.ActivityName = FA.ActivityNameInput.Text;
            if (FA.CityComboBox.SelectionBoxItem.ToString() == city.CityName)
            { addActivity.CityID = city.CityID; };
            addActivity.MaxQuantity = int.Parse(FA.MaxQuantityInput.Text);
            addActivity.GroupQuantity = int.Parse(FA.GroupQuantityInput.Text);
            addActivity.Price = int.Parse(FA.PriceInput.Text);
            addActivity.ActivityDate = FA.ActivityDate.DisplayDate;
            addActivity.ActivityAddress = FA.ActivityAddressInput.Text;
            addActivity.Phone = FA.PhoneInput.Text;
            addActivity.Email = FA.EmailInput.Text;
            addActivity.ATMBank = FA.ATMBankInput.Text;
            addActivity.ATMAccount = FA.ATMAccountInput.Text;
            addActivity.ActivityContent = FA.ActivityContentInput.Selection.Text;
            addActivity.CreatedDate = System.DateTime.Now;
            addActivity.LastUpdateDate = System.DateTime.Now;
            addActivity.SupplierID = 1;
            DB.ActivityFarmer.Add(addActivity);
            DB.SaveChanges();
        }
        int count;
        FarmActivity FA = new FarmActivity();
        farmsDBEntities DB = new farmsDBEntities();
        ActivityFarmer addActivity = new ActivityFarmer();
        ActivityCity city = new ActivityCity();
        global::WpfFarmsActivity.UserControl1[] x = new UserControl1[50];
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FA = new FarmActivity();
            var q = from a in DB.ActivityCity select a.CityName;
            FA.ActivityAddressInput.DataContext = DB.Suppliers.First();
            FA.PhoneInput.DataContext = DB.Suppliers.First();
            FA.EmailInput.DataContext = DB.Suppliers.First();
            FA.CityComboBox.ItemsSource =q.ToList();
            FA.ActivityDate.SelectedDate = System.DateTime.Today;
            FA.Show();
            FA.Accept.Click += new RoutedEventHandler(Accept_Click);
            FA.Cancel.Click += new RoutedEventHandler(Cancel_Click);
        }
        
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            Activity();
            MessageBox.Show("活動編號"+addActivity.ActivityFarmerID+"新增成功!");
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
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ActivityWeb Web = new ActivityWeb();
            Web.Show();
        }
    }
}
