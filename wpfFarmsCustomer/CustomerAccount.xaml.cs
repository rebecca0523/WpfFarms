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
using WpfFarms;
using WpfFarmsActivity;
using WpfFarmsProducts;
using WpfMarketing;

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

            cmd.Parameters.AddWithValue("@Email", LoginAndRegister.loginEmail);
            cmd.Parameters.AddWithValue("@Password", LoginAndRegister.loginPassword);

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
            labUser.Content = LoginAndRegister.loginEmail;
            //labUser.Content = n.ToString();
        }

        private void MenuItemfarmsCRUD_Click(object sender, RoutedEventArgs e)
        {
            SuppliersRegister suppRegister = new SuppliersRegister();

            suppRegister.Show();
        }

        private void MenuItemVedioCRUD_Click(object sender, RoutedEventArgs e)
        {
            SuppliersVedioCRUD vedioCRUD = new SuppliersVedioCRUD();

            vedioCRUD.Show();
        }

    }
}
