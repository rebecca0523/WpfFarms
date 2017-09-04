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
using System.Data;

namespace wpfFarmsCustomer
{
    /// <summary>
    /// ForgetPassword.xaml 的互動邏輯
    /// </summary>
    public partial class ForgetPassword : Window
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string strConn = ConfigurationManager.ConnectionStrings["farmsDB"].ConnectionString;
            string strSql = "editPassword";

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql,conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("Name", txtName.Text);

            SqlParameter pReturnValue = new SqlParameter("@Return_Values", SqlDbType.Int);
            pReturnValue.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(pReturnValue);

            //if (txtPassword != txtEmail)
            //{
            //    MessageBox.Show("請輸入正確密碼");
            //}

            conn.Open();
            cmd.ExecuteNonQuery();
            int n = Convert.ToInt32(cmd.Parameters["@Return_Values"].Value);
            if(n==1)
            {
                SqlParameter pPassword = new SqlParameter("@Password", SqlDbType.NChar, 20);
                pPassword.Direction = ParameterDirection.Input;
                pPassword.Value = txtPassword.Text;
                cmd.Parameters.Add(pPassword);
            }
            else
            {
                MessageBox.Show("電子郵件或姓名錯誤！");
            }
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
