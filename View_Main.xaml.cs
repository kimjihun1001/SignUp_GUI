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
            btn_searchImage.Click += btn_searchImage_Click;

            block_welcome.Text = View_Login.currentUser.Name + "님, 안녕하세요.";
        }

        public void btn_searchImage_Click(object sender, RoutedEventArgs e)
        {
            View_SearchImage view_SearchImage = new View_SearchImage();
            this.Hide();
            view_SearchImage.Show();
        }

    }
}
