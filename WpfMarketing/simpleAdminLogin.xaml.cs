using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfMarketing
{
    /// <summary>
    /// simpleAdminLogin.xaml 的互動邏輯
    /// </summary>
    public partial class simpleAdminLogin : Window
    {
        public simpleAdminLogin()
        {
            InitializeComponent();
        }
        public static bool simpleadmin = false;
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            int code;
            if(int.TryParse(txtCode.Text,out code))
            {
                if(code == 12345)
                {
                    txkState.Text = "密碼正確";
                    simpleadmin = true;
                    this.Close();
                }
                else {
                    txkState.Text = "密碼錯誤";
                   
                }

            }
            else { return; }
         
           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtCode);
        }
    }
   

}
