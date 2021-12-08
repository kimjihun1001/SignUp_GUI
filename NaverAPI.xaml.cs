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

using System.Net;
using System.IO;
using System.Xml;

namespace SignUp_GUI
{
    /// <summary>
    /// NaverAPI.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NaverAPI : UserControl
    {
        public NaverAPI()
        {
            InitializeComponent();
        }

        public void NaverSearchImage(string searchWord)
        {
            const string NAVER_ID = "xQKhYDcaW4DZ5JNHdmXJ";
            const string NAVER_SECRET = "869iq_F6ep";
            const string NAVER_URL = "https://openapi.naver.com/v1/search/image.xml";

            string query = "?query=" + searchWord;
            string url = NAVER_URL + query + "?display=1";

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
            
            //XmlNodeList imageList = secondNode.SelectNodes("item");

            //foreach (XmlNode image in imageList)
            //{
            //    XmlNode link = image.SelectSingleNode("thumbnail");
            //    Uri linkuri = new Uri(link.InnerText);
            //    BitmapImage bitmap = new BitmapImage(linkuri);
            //    Image image1 = new Image();
            //    image1.Source = bitmap;
            //    imageView.Children.Add(image1);
            //}

            XmlNode oneimage = secondNode.SelectSingleNode("item");
            XmlNode link = oneimage.SelectSingleNode("thumbnail");
            Uri linkuri = new Uri(link.InnerText);
            BitmapImage bitmap = new BitmapImage(linkuri);
            Image image1 = new Image();
            image1.Source = bitmap;
            imageView.Children.Add(image1);
        }
    }
}
