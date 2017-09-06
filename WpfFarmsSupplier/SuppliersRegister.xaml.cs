using AllData;
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

namespace WpfFarmsSupplier
{
    /// <summary>
    /// SuppliersRegister.xaml 的互動邏輯
    /// </summary>
    public partial class SuppliersRegister : Window
    {
        public SuppliersRegister()
        {
            InitializeComponent();
        }
        
        AllFarmsDBEntities context = new AllFarmsDBEntities();


        string Email ="testselina66@ms68.hinet.net";






        System.Windows.Data.CollectionViewSource supplierViewSource;
        Supplier SupplierTable;
        int count;





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           


             supplierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("supplierViewSource")));
            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
             count = context.Suppliers.Where(s => s.email1 == Email).Count();
            if (count > 0)
            {
                
                supplierViewSource.Source = context.Suppliers.Where(s => s.email1 == Email).ToList();

                //createdUserNMLabel.Content=
                //lastUpdateUserNMLabel=

                cmdSave.IsEnabled = false;
                
            }
            else {
                cmdEditSave.IsEnabled = false;
                
            }
        }

        private void cmdAdd_Click(object sender, RoutedEventArgs e)
        {
            SupplierTable = new Supplier();

            SupplierTable.SupplierName = supplierNameTextBox.Text;
            SupplierTable.email1 = email1TextBox.Text;


            if (email1TextBox.Text==null || email1TextBox.Text =="")
            {
                MessageBox.Show("email1,不可為空值");
                return ;
            }


            SupplierTable.ContactName1 = contactName1TextBox.Text;
            SupplierTable.ContactName2 = contactName2TextBox.Text;
            SupplierTable.Phone1 = phone1TextBox.Text;
            SupplierTable.Phone2 = phone2TextBox.Text;
            SupplierTable.LineID = lineIDTextBox.Text;
            SupplierTable.email2 = email2TextBox.Text;
            SupplierTable.PostalCode = postalCodeTextBox.Text;
            SupplierTable.Address = addressTextBox.Text;
            SupplierTable.CreatedUserID = context.CustomerInfoes.Where(c => c.Email == Email).Select(c => c.CustomerID).FirstOrDefault();

            SupplierTable.CreatedDate = System.DateTime.Now;

            SupplierTable.LastUpdateUserID = context.CustomerInfoes.Where(c => c.Email == Email).Select(c => c.CustomerID).FirstOrDefault();
            SupplierTable.LastUpdateDate = System.DateTime.Now;
            
            context.Suppliers.Add(SupplierTable);
            context.SaveChanges();

            count = context.Suppliers.Where(s => s.email1 == Email).Count();

            if (count > 0)
            {
                supplierViewSource.Source = context.Suppliers.Where(s => s.email1 == Email).ToList();
                MessageBox.Show("註冊成功");
                cmdSave.IsEnabled = false;
                cmdEditSave.IsEnabled = true;
            }
        }

        private void cmdEditSave_Click(object sender, RoutedEventArgs e)
        {

            SupplierTable = new Supplier();
            SupplierTable = context.Suppliers.Where(s => s.email1 == Email).FirstOrDefault();

            int cust = context.CustomerInfoes.Where(c => c.Email == Email).Select(c => c.CustomerID).FirstOrDefault();
            SupplierTable.LastUpdateUserID =cust;
            SupplierTable.LastUpdateDate = System.DateTime.Now;

            context.SaveChanges();
            supplierViewSource.Source = context.Suppliers.Where(s => s.email1 == Email).ToList();
            
            MessageBox.Show("存檔成功");
        }
    }
}
