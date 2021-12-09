using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SignUp_GUI
{
    public class TreatDB_mysql
    {
        public static List<User> userList = new List<User>();
        public static List<Log> logList = new List<Log>();

        public void LoadUserDB()
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=signup_gui;Uid=root;Pwd=36671726;");
            connection.Open();

            string query = "SELECT * FROM user";
            MySqlCommand command = new MySqlCommand(query, connection);

            // MySqlDataReader는 연결모드로 데이타를 서버에서 가져오는 반면, MySqlDataAdapter는 한꺼번에 클라이언트 메모리로 데이타를 가져온후 연결을 끊는다.
            MySqlDataReader rdr = command.ExecuteReader();

            // DB에서 데이터를 읽는 동안 새로운 회원 객체에 추가함 
            while (rdr.Read())
            {
                User user = new User();

                user.Index = int.Parse(rdr["index"].ToString());
                user.Id = rdr["id"].ToString();
                user.Password = rdr["password"].ToString();
                user.Name = rdr["name"].ToString();
                user.IDNumber = rdr["idNumber"].ToString();
                user.Phone = rdr["phone"].ToString();
                user.Mail = rdr["mail"].ToString();
                user.Address = rdr["address"].ToString();

                userList.Add(user);
            }
            rdr.Close();
            connection.Close();
        }

        public void UploadUserDB()
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=signup_gui;Uid=root;Pwd=36671726;");
            connection.Open();

            // 빈 테이블로 초기화 
            MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM user where id != ''", connection);
            deleteCommand.ExecuteNonQuery();

            // 리스트에 있는 회원 객체 MySQL DB로 보내기 
            foreach (User user in userList)
            {
                string userInformationString = "VALUES(" + user.Index + ",'" + user.Id + "', '" + user.Password + "', '" + user.Name + "', '" + user.IDNumber + "', '" + user.Phone + "', '" + user.Mail + "', '" + user.Address + "')";

                MySqlCommand command = new MySqlCommand("INSERT INTO user (index, id, password, name, idNumber, phone, mail, address)" + userInformationString, connection);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void LoadLogDB()
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=signup_gui;Uid=root;Pwd=36671726;");
            connection.Open();

            string query = "SELECT * FROM log";
            MySqlCommand command = new MySqlCommand(query, connection);

            // MySqlDataReader는 연결모드로 데이타를 서버에서 가져오는 반면, MySqlDataAdapter는 한꺼번에 클라이언트 메모리로 데이타를 가져온후 연결을 끊는다.
            MySqlDataReader rdr = command.ExecuteReader();

            // DB에서 데이터를 읽는 동안 새로운 회원 객체에 추가함 
            while (rdr.Read())
            {
                Log log = new Log();

                log.Index = int.Parse(rdr["index"].ToString());
                log.Id = rdr["id"].ToString();
                log.Searchword = rdr["searchword"].ToString();

                logList.Add(log);
            }
            rdr.Close();
            connection.Close();
        }

        public void UploadLogDB()
        {
            MySqlConnection connection = new MySqlConnection("Server=localhost;Database=signup_gui;Uid=root;Pwd=36671726;");
            connection.Open();

            // 빈 테이블로 초기화 
            MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM log where id != ''", connection);
            deleteCommand.ExecuteNonQuery();

            // 리스트에 있는 회원 객체 MySQL DB로 보내기 
            foreach (Log log in logList)
            {
                string logInformationString = "VALUES(" + log.Index + ", '" + log.Id + "', '" + log.Searchword + "')";

                MySqlCommand command = new MySqlCommand("INSERT INTO log (index, id, searchword)" + logInformationString, connection);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

    }
}
