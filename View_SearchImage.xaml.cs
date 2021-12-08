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
    /// View_SearchImage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class View_SearchImage : Window
    {
        public View_SearchImage()
        {
            InitializeComponent();
            btn_search.Click += btn_search_Click;
            btn_back.Click += btn_back_Click;
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            View_Main view_Main = new View_Main();
            this.Hide();
            view_Main.Show();
        }
    }
}
