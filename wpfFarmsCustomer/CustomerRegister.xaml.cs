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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace wpfFarmsCustomer
{
    /// <summary>
    /// CustomerRegister.xaml 的互動邏輯
    /// </summary>
    public partial class CustomerRegister : Window
    {
        public CustomerRegister()
        {
            InitializeComponent();
            
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

            string strConn = ConfigurationManager.ConnectionStrings["farmsDB"].ConnectionString;
            string strSql = "Insert";

            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter pCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int);
            pCustomerID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pCustomerID);

            SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            pEmail.Direction = ParameterDirection.Input;
            pEmail.Value = txtEmail.Text;
            cmd.Parameters.Add(pEmail);

            SqlParameter pName = new SqlParameter("@Name", SqlDbType.NChar, 10);
            pName.Direction = ParameterDirection.Input;
            pName.Value = txtName.Text;
            cmd.Parameters.Add(pName);

            SqlParameter pPassword = new SqlParameter("@Password", SqlDbType.NChar, 20);
            pPassword.Direction = ParameterDirection.Input;
            pPassword.Value = txtPassword.Text;
            cmd.Parameters.Add(pPassword);

            SqlParameter pGender = new SqlParameter("@Gender", SqlDbType.NChar,10);
            pGender.Direction = ParameterDirection.Input;
            pGender.Value = txtGender.Text;
            cmd.Parameters.Add(pGender);

            SqlParameter pPhone = new SqlParameter("@Phone", SqlDbType.NVarChar, 15);
            pPhone.Direction = ParameterDirection.Input;
            pPhone.Value = txtPhone.Text;
            cmd.Parameters.Add(pPhone);

            SqlParameter pMobile = new SqlParameter("@Mobile", SqlDbType.NVarChar, 15);
            pMobile.Direction = ParameterDirection.Input;
            pMobile.Value = txtMobile.Text;
            cmd.Parameters.Add(pMobile);

            SqlParameter pAddressID = new SqlParameter("@AddressID", SqlDbType.NVarChar, 80);
            pAddressID.Direction = ParameterDirection.Input;
            pAddressID.Value = txtAddress.Text;
            cmd.Parameters.Add(pAddressID);

            SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime);
            pCreationDate.Direction = ParameterDirection.Input;
            pCreationDate.Value = DateTime.Now;
            cmd.Parameters.Add(pCreationDate);

            SqlParameter pLastUpdate = new SqlParameter("@LastUpdate", SqlDbType.DateTime);
            pLastUpdate.Direction = ParameterDirection.Input;
            pLastUpdate.Value = DateTime.Now;
            cmd.Parameters.Add(pLastUpdate);

            SqlParameter pEvaluation = new SqlParameter("@Evaluation", SqlDbType.Int);
            pEvaluation.Direction = ParameterDirection.Input;
            pEvaluation.Value = 0;
            cmd.Parameters.Add(pEvaluation);

            SqlParameter pUseridentity = new SqlParameter("@Useridentity", SqlDbType.Int);
            pUseridentity.Direction = ParameterDirection.Input;
            pUseridentity.Value = 0;
            cmd.Parameters.Add(pUseridentity);

            conn.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("註冊成功！");
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            this.Close();

        }
    }
}
