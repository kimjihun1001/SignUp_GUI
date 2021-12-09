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
        public static User currentUser;

        public View_Login()
        {
            InitializeComponent();
            btn_login.Click += btn_login_Click;
            btn_signup.Click += btn_signup_Click;
            btn_back.Click += Btn_back_Click;
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.MainWindowInstance.Show();
        }

        public void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (Check_Id(box_id.Text) && Check_Password(box_password.Password))
            {
                View_Main view_Main = new View_Main();
                this.Hide();
                view_Main.Show();
            }
            else
            {
                Alert alert = new Alert();
                alert.block_alert.Text = "로그인 실패";
                alert.Show();
            }
        }

        public void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            View_SignUp view_SignUp = new View_SignUp();
            this.Hide();
            view_SignUp.Show();
        }

        public bool Check_Id(string input)
        {
            foreach(User user in TreatDB_mysql.userList)
            {
                if(user.Id == input)
                    return true;
            }
            return false;
        }

        public bool Check_Password(string input)
        {
            foreach (User user in TreatDB_mysql.userList)
            {
                if (user.Password == input)
                {
                    currentUser = user;
                    return true;
                }                    
            }
            return false;
        }

    }
}
