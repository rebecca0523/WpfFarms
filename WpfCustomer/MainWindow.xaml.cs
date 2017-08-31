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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WpfCustomer
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtlog_Click(object sender, RoutedEventArgs e)
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

                conn.Open();
                cmd.ExecuteNonQuery();
                int n = Convert.ToInt32(cmd.Parameters["@Return_Values"].Value);
                if (n == 1)
                {
                    MessageBox.Show("登入成功！");
                }
                else
                {
                    MessageBox.Show("電子郵件或密碼錯誤！");
                }
                conn.Close();
                conn.Dispose();
        }
    }
}
