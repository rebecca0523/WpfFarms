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
    /// EditPassword.xaml 的互動邏輯
    /// </summary>
    public partial class EditPassword : Window
    {
        public EditPassword()
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

            //cmd.Parameters.AddWithValue("Email", txtEmail.Text);
            //cmd.Parameters.AddWithValue("Name", txtName.Text);

            SqlParameter pPassword = new SqlParameter("@Password", SqlDbType.NChar, 20);
            pPassword.Direction = ParameterDirection.Input;
            pPassword.Value = txtPassword.Text;
            cmd.Parameters.Add(pPassword);

        }
    }
}
