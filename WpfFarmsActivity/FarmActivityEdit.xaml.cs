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
    /// FarmActivityEdit.xaml 的互動邏輯
    /// </summary>
    public partial class FarmActivityEdit : Window
    {
        public FarmActivityEdit()
        {
            InitializeComponent();
        }
        FarmActivity FA = new FarmActivity();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActivityNameInput.Text = FA.ActivityNameInput.Text;
            CityComboBox.Text = FA.CityComboBox.SelectedIndex.ToString();
            MaxQuantityInput.Text = FA.MaxQuantityInput.Text;
            GroupQuantityInput.Text = FA.GroupQuantityInput.Text;
            PriceInput.Text = FA.PriceInput.Text;
            ActivityDate.Text = FA.ActivityDate.Text;
            ActivityAddressInput.Text = FA.ActivityAddressInput.Text;
            PhoneInput.Text = FA.PhoneInput.Text;
            EmailInput.Text = FA.EmailInput.Text;
            ATMBankInput.Text = FA.ATMBankInput.Text;
            ATMAccountInput.Text = FA.ATMAccountInput.Text;
            ActivityContentInput.Selection.Text=FA.ActivityContentInput.Selection.Text;
        }
    }
}
