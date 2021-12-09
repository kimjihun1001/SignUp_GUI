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
    /// View_SignUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class View_SignUp : Window
    {
        public static bool check_idNumber = false;
        public static bool check_id = false;
        public static bool check_phone = false;


        public View_SignUp()
        {
            InitializeComponent();
            btn_id.Click += Btn_id_Click;
            btn_idNumber.Click += Btn_idNumber_Click;
            btn_phone.Click += Btn_phone_Click;
            btn_signUp.Click += Btn_signUp_Click;
            btn_back.Click += Btn_back_Click;

            box_id.TextChanged += Box_id_TextChanged;
            box_idNumber.TextChanged += Box_idNumber_TextChanged;
            box_phone.TextChanged += Box_phone_TextChanged;
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            View_Login view_Login = new View_Login();
            this.Close();
            view_Login.Show();
        }

        private void Box_phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            check_phone = false;
        }

        private void Box_idNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            check_idNumber = false;
        }

        private void Box_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            check_id = false;
        }

        private void Btn_idNumber_Click(object sender, RoutedEventArgs e)
        {
            Alert alert = new Alert();
            string input = box_idNumber.Text;

            if (Check_Empty(input))
            {
                alert.block_alert.Text = "값이 없습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (Check_Contain_Space(input))
            {
                alert.block_alert.Text = "공백이 있습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (!(Check_Number(input)))
            {
                alert.block_alert.Text = "숫자만 입력해야 합니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (input.Length != 13)
            {
                alert.block_alert.Text = "13자리를 입력해야 합니다. 다시 입력하세요.";
                alert.Show();
            }
            else
            {
                foreach (User user in TreatDB_mysql.userList)
                {
                    if (user.IDNumber == input)
                    {
                        alert.block_alert.Text = "중복된 주민등록번호가 있습니다. 다시 입력하세요.";
                        alert.Show();
                        check_idNumber = false;
                        break;
                    }
                    check_idNumber = true;
                }
            }

            if (check_idNumber == true)
            {
                alert.block_alert.Text = "중복 확인 성공";
                alert.Show();
            }
        }

        private void Btn_signUp_Click(object sender, RoutedEventArgs e)
        {
            Alert alert = new Alert();

            if (!(check_id))
            {
                alert.block_alert.Text = "ID 중복 확인하세요";
                alert.Show();
            }
            else if (!(check_idNumber))
            {
                alert.block_alert.Text = "주민등록번호 중복 확인하세요";
                alert.Show();
            }
            else if (!(check_phone))
            {
                alert.block_alert.Text = "전화번호 중복 확인하세요";
                alert.Show();
            }
            else if (Check_Empty(box_password.Text) || Check_Empty(box_mail.Text) || Check_Empty(box_address.Text) || Check_Empty(box_name.Text))
            {
                alert.block_alert.Text = "비어있는 칸이 있습니다. 값을 입력하세요.";
                alert.Show();
            }
            else if (Check_Contain_Space(box_name.Text))
            {
                alert.block_alert.Text = "이름에 공백이 있습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (Check_Contain_Space(box_mail.Text))
            {
                alert.block_alert.Text = "메일에 공백이 있습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (Check_Contain_Space(box_password.Text))
            {
                alert.block_alert.Text = "Password에 공백이 있습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (!(Check_Korean(box_name.Text)))
            {
                alert.block_alert.Text = "이름은 한글만 입력하세요. 다시 입력하세요.";
                alert.Show();
            }
            else if (!(Check_English_Number(box_password.Text)))
            {
                alert.block_alert.Text = "Password는 영어, 숫자만 입력하세요. 다시 입력하세요.";
                alert.Show();
            }
            else
            {
                User user = new User();
                user.Id = box_id.Text;
                user.Password = box_password.Text;
                user.Name = box_name.Text;
                user.IDNumber = box_idNumber.Text;
                user.Phone = box_phone.Text;
                user.Mail = box_mail.Text;
                user.Address = box_address.Text;

                TreatDB_mysql.userList.Add(user);
                TreatDB_mysql treatDB_Mysql = new TreatDB_mysql();
                treatDB_Mysql.UploadUserDB();

                alert.block_alert.Text = "회원 가입이 완료되었습니다. 로그인 화면으로 돌아가세요.";
                alert.Show();

            }
        }

        private void Btn_phone_Click(object sender, RoutedEventArgs e)
        {
            Alert alert = new Alert();
            string input = box_phone.Text;

            if (Check_Empty(input))
            {
                alert.block_alert.Text = "값이 없습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (Check_Contain_Space(input))
            {
                alert.block_alert.Text = "공백이 있습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (!(Check_Number(input)))
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

        private void Btn_id_Click(object sender, RoutedEventArgs e)
        {
            Alert alert = new Alert();
            string input = box_id.Text;

            if (Check_Empty(input))
            {
                alert.block_alert.Text = "값이 없습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (Check_Contain_Space(input))
            {
                alert.block_alert.Text = "공백이 있습니다. 다시 입력하세요.";
                alert.Show();
            }
            else if (!(Check_English_Number(input)))
            {
                alert.block_alert.Text = "영어와 숫자만 입력해야 합니다. 다시 입력하세요.";
                alert.Show();
            }
            else
            {
                foreach (User user in TreatDB_mysql.userList)
                {
                    if (user.Id == input)
                    {
                        alert.block_alert.Text = "중복된 ID가 있습니다. 다시 입력하세요.";
                        alert.Show();
                        check_id = false;
                        break;
                    }
                    check_id = true;
                }
            }

            if (check_id == true)
            {
                alert.block_alert.Text = "중복 확인 성공";
                alert.Show();
            }

        }

        public bool Check_Empty(string input)
        {
            if (input == "")
                return true;
            else
                return false;
        }

        public bool Check_Contain_Space(string input)
        {
            if (input.Contains(" "))
                return true;
            else
                return false;
        }

        public bool Check_Number(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!(input[i]>= '0' && input[i] <= '9'))
                    return false;
            }
            return true;            
        }

        public bool Check_Korean(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!(input[i] >= '가' && input[i] <= '힣'))
                    return false;
            }
            return true;
        }

        public bool Check_English_Number(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z') || (input[i] >= '0' && input[i] <= '9')))
                    return false;
            }
            return true;
        }

    }
}
