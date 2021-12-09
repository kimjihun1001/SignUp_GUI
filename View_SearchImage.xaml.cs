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
using System.Net;
using System.IO;
using System.Xml;

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
            if (box_search.Text == "")
            {

            }
            else
            {
                NaverSearchImage(box_search.Text);

                Log log = new Log();
                log.Id = View_Login.currentUser.Id;
                log.Searchword = box_search.Text;
                TreatDB_mysql.logList.Add(log);
                TreatDB_mysql treatDB_Mysql = new TreatDB_mysql();
                treatDB_Mysql.UploadLogDB();
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            View_Main view_Main = new View_Main();
            this.Hide();
            view_Main.Show();
        }

        public void NaverSearchImage(string searchWord)
        {
            const string NAVER_ID = "xQKhYDcaW4DZ5JNHdmXJ";
            const string NAVER_SECRET = "869iq_F6ep";
            const string NAVER_URL = "https://openapi.naver.com/v1/search/image.xml";

            string query = "?query=" + searchWord;
            string url = NAVER_URL + query + "&display=30";

            // 요청
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // API 접근
            request.Headers.Add("X-Naver-Client-Id", NAVER_ID);
            request.Headers.Add("X-Naver-Client-Secret", NAVER_SECRET);

            // 응답 받기
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Xml 파일 받아오기
            Stream stream = response.GetResponseStream();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(stream);

            // Xml 파일 분해하기
            XmlNode firstNode = xmlDocument.SelectSingleNode("rss");
            XmlNode secondNode = firstNode.SelectSingleNode("channel");

            XmlNodeList imageList = secondNode.SelectNodes("item");

            // 검색 화면 초기화
            wp_search.Children.Clear();

            // 이미지 출력
            foreach (XmlNode image in imageList)
            {
                XmlNode link = image.SelectSingleNode("link");
                Uri linkuri = new Uri(link.InnerText);
                BitmapImage bitmap = new BitmapImage(linkuri);
                Image image1 = new Image();
                image1.Source = bitmap;
                image1.Height = 100;
                image1.Width = 100;
                image1.MouseLeftButtonDown += Image1_MouseLeftButtonDown;
                wp_search.Children.Add(image1);
            }

        }

        private void Image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;

            Image bigImage = new Image();
            bigImage.Source = image.Source;

            ImageExtension imageExtension = new ImageExtension();
            imageExtension.grid_image.Children.Add(bigImage);
            imageExtension.Show();
        }
    }
}
