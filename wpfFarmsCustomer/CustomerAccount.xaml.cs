using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using WpfFarmsSupplier;
using System.Data;
using wpfFarmsCustomer;
using WpfFarmsActivity;
using WpfFarmsProducts;
using WpfMarketing;
using static AllData.CustomerClass;

namespace wpfFarmsCustomer
{
    /// <summary>
    /// CustomerAccount.xaml 的互動邏輯
    /// </summary>
    public partial class CustomerAccount : Window
    {
        public CustomerAccount()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["farmsDB"].ConnectionString;
            string strSql = "findCustomer";

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Email", loginEmail);
            cmd.Parameters.AddWithValue("@Password", loginPassword);

            //SqlParameter pReturnValue = new SqlParameter("@Return_Values", SqlDbType.NChar, 10);
            //pReturnValue.Direction = ParameterDirection.ReturnValue;
            //cmd.Parameters.Add(pReturnValue);

            //conn.Open();
            //cmd.ExecuteScalar();
            //string n = Convert.ToString(cmd.Parameters["@Return_Values"].Value);
            //CustomerInfo CI = new CustomerInfo();
            //var q = from p in CI.Name
            //        where 
            //        select s;
            labUser.Content = loginEmail;
            //labUser.Content = n.ToString();
        }


        private void MenuItemfarmsCRUDMulti_Click(object sender, RoutedEventArgs e)
        {
            SuppliersMainCRUD suppRegisterM = new SuppliersMainCRUD();

            suppRegisterM.Show();
        }

        private void MenuItemfarmsCRUD_Click(object sender, RoutedEventArgs e)
        {

            SuppliersRegister suppRegisterM = new SuppliersRegister();

            suppRegisterM.Show();
        }


        private void MenuItemVedioCRUD_Click(object sender, RoutedEventArgs e)
        {
            SuppliersVideoCRUD vedioCRUD = new SuppliersVideoCRUD();

            vedioCRUD.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindowProducts mainWindowProducts = new MainWindowProducts();
            mainWindowProducts.ShowDialog();
        }

      
    }
}
