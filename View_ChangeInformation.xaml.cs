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
    /// View_ChangeInformation.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class View_ChangeInformation : Window
    {
        public static bool check_phone = false;

        public View_ChangeInformation()
        {
            InitializeComponent();
            box_address.Text = View_Login.currentUser.Address;
            box_mail.Text = View_Login.currentUser.Mail;
            box_phone.Text = View_Login.currentUser.Phone;

            btn_back.Click += Btn_back_Click;

            btn_phone.Click += Btn_phone_Click;
            btn_signUp.Click += Btn_signUp_Click;
            box_phone.TextChanged += Box_phone_TextChanged;

        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            View_Main view_Main = new View_Main();
            this.Close();
            view_Main.Show();
        }

        private void Box_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            check_phone = false;
        }

        private void Btn_phone_Click(object sender, RoutedEventArgs e)
        {
            Alert alert = new Alert();
            View_SignUp view_SignUp = new View_SignUp();

            string input = box_phone.Text;
             
            if (view_SignUp.Check_Empty(input))
            {
                alert.block_alert.Text = "값이 없습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (view_SignUp.Check_Contain_Space(input))
            {
                alert.block_alert.Text = "공백이 있습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (!(view_SignUp.Check_Number(input)))
            {
                alert.block_alert.Text = "숫자만 입력해야 합니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (input.Length != 11)
            {
                alert.block_alert.Text = "11자리를 입력해야 합니다. 다시 입력하세요.";
                alert.Show();
            }
            else
            {
                foreach (User user in TreatDB_mysql.userList)
                {
                    if (user.Phone == input)
                    {
                        alert.block_alert.Text = "중복된 전화번호가 있습니다. 다시 입력하세요.";
                        alert.Show();
                        check_phone = false;
                        break;
                    }
                    check_phone = true;
                }
              
            }

            if (check_phone == true)
            {
                alert.block_alert.Text = "중복 확인 성공";
                alert.Show();
            }
        }

        private void Btn_signUp_Click(object sender, RoutedEventArgs e)
        {
            Alert alert = new Alert();
            View_SignUp view_SignUp = new View_SignUp();

            if (!(check_phone))
            {
                alert.block_alert.Text = "전화번호 중복 확인하세요";
                alert.Show();
            }
            else if (view_SignUp.Check_Empty(box_mail.Text) || view_SignUp.Check_Empty(box_address.Text))
            {
                alert.block_alert.Text = "비어있는 칸이 있습니다. 값을 입력하세요.";
                alert.Show();
            }
            else if (view_SignUp.Check_Contain_Space(box_mail.Text))
            {
                alert.block_alert.Text = "메일에 공백이 있습니다. 다시 입력하세요.";
                alert.Show();
            }
            else
            {
                foreach (User user1 in TreatDB_mysql.userList)
                {
                    if (user1.Id == View_Login.currentUser.Id)
                    {
                        user1.Phone = box_phone.Text;
                        user1.Mail = box_mail.Text;
                        user1.Address = box_address.Text;

                        View_Login.currentUser = user1;

                        TreatDB_mysql treatDB_Mysql = new TreatDB_mysql();
                        treatDB_Mysql.UploadUserDB();
                    }
                }

                alert.block_alert.Text = "회원 정보 수정이 완료되었습니다. 메인 화면으로 돌아가세요.";
                alert.Show();

            }
        }
    }
}
