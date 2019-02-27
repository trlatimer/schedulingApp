using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SchedulingApp
{
    class DataInterface
    {
        private static int currentUserID;
        private static string currentUserName;
        private static List<int> userIDList = new List<int>();
        public static string connectionString = "server=52.206.157.109;userid=U05Csd;database=U05Csd;password=53688462289";
        public static MySqlConnection conn;

        public static int getCurrentUserID()
        {
            return currentUserID;
        }

        public static string getCurrentUserName()
        {
            return currentUserName;
        }

        public static void setCurrentUserID(int userID)
        {
            currentUserID = userID;
        }

        public static void setCurrentUserName(string userName)
        {
            currentUserName = userName;
        }

        public static int getNextUserID()
        {
            int nextUserID = 0;
            DBOpen();
            MySqlCommand cmd = new MySqlCommand("SELECT userId FROM user", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userIDList.Add(Convert.ToInt32(reader[0]));
            }
            reader.Close();
            DBClose();
            foreach (int ID in userIDList)
            {
                if (ID > nextUserID)
                {
                    nextUserID = ID;
                } 
            }
            nextUserID++;
            return nextUserID;
        }

        public static string getCurrentDateTime()
        {
            string currentDateTime = DateTime.Now.ToString("u");
            return currentDateTime;
        }

        // ONLY USE TO CREATE FIRST TEST USER
        public static void createTestUser()
        {
            DBOpen();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM user WHERE userName = 'Test' OR userName = 'test'", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            // check if 'Test' User already exists
            if (reader.HasRows)
            {
                // if user exists, exit function
                Console.WriteLine("User 'Test' already exists");
            }
            else
            {
                // create 'Test' user
                createUser("Test", "Test", 1, "ADMIN", "ADMIN");
            }
            reader.Close();
            DBClose();
        }

        public static void createUser(string username, string password, int active, string creator, string lastUpdater)
        {
            int id = getNextUserID();
            string currentDateTime = getCurrentDateTime();
            String sqlString = $"INSERT INTO user(userId, userName, password, active, createBy, createDate, lastUpdatedBy) VALUES ('{id}', '{username}', '{password}', '{active}', '{creator}', '{currentDateTime}', '{lastUpdater}');";

            // Establish and open database connection
            DBOpen();
            MySqlCommand cmd = new MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        public static void DBOpen()
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }

        public static void DBClose()
        {
            conn.Close();
        }

    }
}
