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
    /// View_Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class View_Main : Window
    {
        public View_Main()
        {
            InitializeComponent();
            btn_back.Click += Btn_back_Click;
            btn_searchImage.Click += btn_searchImage_Click;
            btn_searchedword.Click += Btn_searchedword_Click;
            btn_changeInformation.Click += Btn_changeInformation_Click;
            btn_withdraw.Click += Btn_withdraw_Click;
            btn_logout.Click += Btn_logout_Click;

            block_welcome.Text = View_Login.currentUser.Name + "님, 안녕하세요.";
        }

        private void Btn_withdraw_Click(object sender, RoutedEventArgs e)
        {
            View_Withdraw view_Withdraw = new View_Withdraw();
            this.Hide();
            view_Withdraw.Show();
        }

        private void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            Alert alert = new Alert();
            alert.block_alert.Text = "로그아웃";
            alert.Show();

            this.Hide();
            View_Login view_Login = new View_Login();
            view_Login.Show();
        }

        private void Btn_changeInformation_Click(object sender, RoutedEventArgs e)
        {
            View_ChangeInformation view_ChangeInformation = new View_ChangeInformation();
            this.Hide();
            view_ChangeInformation.Show();
        }

        private void Btn_searchedword_Click(object sender, RoutedEventArgs e)
        {
            View_SearchedWord view_SearchedWord = new View_SearchedWord();
            this.Hide();
            view_SearchedWord.Show();
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            View_Login view_Login = new View_Login();
            view_Login.Show();
        }

        public void btn_searchImage_Click(object sender, RoutedEventArgs e)
        {
            View_SearchImage view_SearchImage = new View_SearchImage();
            this.Hide();
            view_SearchImage.Show();
        }

    }
}
