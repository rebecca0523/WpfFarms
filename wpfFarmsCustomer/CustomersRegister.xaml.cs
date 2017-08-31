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

namespace wpfFarmsCustomer
{
    /// <summary>
    /// CustomersRegister.xaml 的互動邏輯
    /// </summary>
    public partial class CustomersRegister : Page
    {
        public CustomersRegister()
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

            SqlParameter pGender = new SqlParameter("@Gender", SqlDbType.Int);
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

            SqlParameter pAddress = new SqlParameter("@Address", SqlDbType.NVarChar, 80);
            pAddress.Direction = ParameterDirection.Input;
            pAddress.Value = txtAddress.Text;
            cmd.Parameters.Add(pAddress);

            SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime);
            pCreationDate.Direction = ParameterDirection.Input;
            pAddress.Value = DateTime.Now.ToString();
            cmd.Parameters.Add(pCreationDate);

            SqlParameter pLastUpdate = new SqlParameter("@LastUpdate", SqlDbType.DateTime);
            pLastUpdate.Direction = ParameterDirection.Input;
            pLastUpdate.Value = DateTime.Now.ToString();
            cmd.Parameters.Add(pLastUpdate);

            SqlParameter pEvaluation = new SqlParameter("@Evaluation", SqlDbType.Int);
            pEvaluation.Direction = ParameterDirection.Input;
            pEvaluation.Value = 0;
            cmd.Parameters.Add(pEvaluation);

            conn.Open();
            cmd.ExecuteNonQuery();

            MessageBox.Show("註冊成功！");

            cmd.Clone();
            conn.Dispose();
        }
    }
}
