using AllData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using wpfFarmsCustomer;
using AllData;
using static AllData.CustomerClass;

namespace wpfFarmsCustomer
{
    /// <summary>
    /// LoginAndRegister.xaml 的互動邏輯
    /// </summary>
    public partial class LoginAndRegister : Window
    {
        public LoginAndRegister()
        {
            InitializeComponent();
        }
        AllData.AllFarmsDBEntities db = new AllFarmsDBEntities();
        private void btnregister_Click(object sender, RoutedEventArgs e)
        {
            CustomerRegister CustomerRegister = new CustomerRegister();
            CustomerRegister.Show();
        }

        //public static string loginEmail;
        //public static string loginPassword;
        //public static int loginSupplierID;
        //public static int loginCustomerID;

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["farmsDB"].ConnectionString;
            string strsql = "login";

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strsql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("Password", txtPassword.Text);

            SqlParameter pReturnValue = new SqlParameter("@Return_Values", SqlDbType.Int);
            pReturnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(pReturnValue);

            //取客戶代號
            var CustomerID = from p in db.CustomerInfoes
                             where p.Email == txtEmail.Text
                             select p.CustomerID;
            loginCustomerID = CustomerID.FirstOrDefault();
            MessageBox.Show(loginCustomerID.ToString());

            //取小農代號
            var SupplierID = from q in db.CustomerInfoes
                             where q.Email == txtEmail.Text
                             select q.SupplierID;
            if(SupplierID!=null)
            loginSupplierID = Convert.ToInt32( SupplierID.FirstOrDefault());
            MessageBox.Show(loginSupplierID.ToString());

            conn.Open();
            cmd.ExecuteNonQuery();
            int n = Convert.ToInt32(cmd.Parameters["@Return_Values"].Value);
            if (n == 1)
            {
                loginEmail = txtEmail.Text;
                loginPassword = txtPassword.Text;
                MessageBox.Show("登入成功！");
                CustomerAccount customerAccount = new CustomerAccount();
                customerAccount.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("電子郵件或密碼錯誤！");
            }
            conn.Close();
            conn.Dispose();
        }

        private void btnforget_Click(object sender, RoutedEventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.Show();
        }
    

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
