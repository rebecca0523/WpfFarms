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
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            pEmail.Direction = ParameterDirection.Input;
            pEmail.Value = txtEmail.Text;
            cmd.Parameters.Add(pEmail);

            SqlParameter pName = new SqlParameter("@Name", SqlDbType.NChar, 10);
            pName.Direction = ParameterDirection.Input;
            pName.Value = txtName.Text;
            cmd.Parameters.Add(pName);

            SqlParameter pPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            pPassword.Direction = ParameterDirection.Input;
            pPassword.Value = txtEmail.Text;
            cmd.Parameters.Add(pPassword);

            MessageBox.Show("修改完成");
        }

            private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
