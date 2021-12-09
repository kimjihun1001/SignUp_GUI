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

namespace SignUp_GUI
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow MainWindowIns = null;

        public static MainWindow MainWindowInstance
        {
            get
            {
                if (MainWindowIns == null)
                {
                    MainWindowIns = new MainWindow();
                }
                return MainWindowIns;
            }
            
        }

        public MainWindow()
        {
            // 초기화하는 과정 - xaml과 연결하기 등
            InitializeComponent();
            btn_start.Click += btn_start_Click;
            btn_3.Click += Btn_3_Click;

        }

        private void Btn_3_Click(object sender, RoutedEventArgs e)
        {
            box_0.Text = "3";
        }

        public void btn_start_Click(object sender, RoutedEventArgs e)
        {
            TreatDB_mysql treatDB_Mysql = new TreatDB_mysql();
            treatDB_Mysql.LoadLogDB();
            treatDB_Mysql.LoadUserDB();

            View_Login view_Login = new View_Login();
            this.Hide();
            view_Login.Show();
        }
    }
    
}
