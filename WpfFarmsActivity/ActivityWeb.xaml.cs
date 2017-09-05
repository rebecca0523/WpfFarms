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
    /// ActivityWeb.xaml 的互動邏輯
    /// </summary>
    public partial class ActivityWeb : Window
    {
        public ActivityWeb()
        {
            InitializeComponent();
            
        }
        FarmActivity FA = new FarmActivity();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Label1.Content = FA.ActivityAddressLabel.Text +" "+ FA.ActivityAddressInput.Text;
            Label2.Content = FA.CityComboBoxLabel.Text + " " + FA.CityComboBox.Text + "\t" +
                FA.MaxQuantityLabel.Text + " " + FA.MaxQuantityInput.Text + "\t" 
                + FA.GroupQuantityLabel.Text+ " " + FA.GroupQuantityInput.Text;
            Label3.Content = FA.PriceLabel.Text + " " + FA.PriceInput.Text + "\t" + FA.ActivityDateLabel.Text + " " + FA.ActivityDate.Text;
            Label4.Content = FA.ActivityAddressLabel.Text + " " + FA.ActivityAddressInput.Text;
            Label5.Content = FA.PhoneLabel.Text + " " + FA.PhoneInput.Text + "\t" + FA.EmailLabel.Text + "" + FA.EmailInput.Text;
            Label6.Content = FA.ATMAccountLabel.Text + " " + FA.ATMAccountInput.Text + "\t" + FA.ATMBankLabel.Text + "" + FA.ATMBankInput.Text;
            //Label7.Content = FA.ActivityContentInput.DataContext.ToString();
        }
    }
}
