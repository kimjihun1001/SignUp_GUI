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
    /// View_Withdraw.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class View_Withdraw : Window
    {
        public View_Withdraw()
        {
            InitializeComponent();
            btn_back.Click += Btn_back_Click;
            btn_Yes.Click += Btn_Yes_Click;
        }

        private void Btn_Yes_Click(object sender, RoutedEventArgs e)
        {
            Alert alert = new Alert();
            alert.block_alert.Text = "탈퇴 완료";
            alert.Show();

            foreach (User user in TreatDB_mysql.userList)
            {
                if (user.Id == View_Login.currentUser.Id)
                {
                    TreatDB_mysql.userList.Remove(user);
                    break;
                }
            }
            TreatDB_mysql treatDB_Mysql = new TreatDB_mysql();
            treatDB_Mysql.UploadUserDB();

            this.Close();
            View_Login view_Login = new View_Login();
            view_Login.Show();
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            View_Main view_Main = new View_Main();  
            view_Main.Show();
        }
    }
}
