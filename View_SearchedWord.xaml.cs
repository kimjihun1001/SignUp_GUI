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
    /// View_SearchedWord.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class View_SearchedWord : Window
    {
        public View_SearchedWord()
        {
            InitializeComponent();
            btn_back.Click += Btn_back_Click;
            btn_delete.Click += Btn_delete_Click;

            wp_searchedWord.Children.Clear();

            foreach (Log log in TreatDB_mysql.logList)
            {
                if (View_Login.currentUser.Id == log.Id)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = log.Searchword;

                    wp_searchedWord.Children.Add(textBlock);
                }
            }
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (Log log in TreatDB_mysql.logList)
            {
                if (View_Login.currentUser.Id == log.Id)
                {
                    TreatDB_mysql.logList.Remove(log);
                }
            }
            TreatDB_mysql treatDB_Mysql = new TreatDB_mysql();
            treatDB_Mysql.UploadLogDB();
            wp_searchedWord.Children.Clear();

        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            View_Main view_Main = new View_Main();
            view_Main.Show();
        }
    }
}
