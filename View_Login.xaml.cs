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

namespace SignUp_GUI
{
    /// <summary>
    /// View_Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class View_Login : Window
    {
        public View_Login()
        {
            InitializeComponent();
            btn_login.Click += btn_login_Click;
            btn_signup.Click += btn_signup_Click;
        }

        public void btn_login_Click(object sender, RoutedEventArgs e)
        {
            View_Main view_Main = new View_Main();
            this.Hide();
            view_Main.Show();
        }

        public void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            View_SignUp view_SignUp = new View_SignUp();

            this.Hide();
            view_SignUp.Show();
        }
    }
}
