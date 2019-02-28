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
        private static List<int> customerIDList = new List<int>();
        private static string connectionString = "server=52.206.157.109;userid=U05Csd;database=U05Csd;password=53688462289";
        private static MySqlConnection conn;

        public static int getCurrentUserID()
        {
            return currentUserID;
        }

        public static string getCurrentUserName()
        {
            return currentUserName;
        }

        public static List<int> getCustomerIDList()
        {
            return customerIDList;
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

        // Build Dictionary object for customer
        public static Dictionary<string, string> getCustomerInfo(int customerID)
        {
            // Retrieve details from customer table that match customerID
            string query = $"SELECT * FROM customer WHERE customerId = '{customerID.ToString()}'";
            DBOpen();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            // Build customer dictionary object from customer table
            Dictionary<string, string> Customer = new Dictionary<string, string>();
            string addressID = reader[2].ToString();
            Customer.Add("ID", reader[0].ToString());
            Customer.Add("Name", reader[1].ToString());
            Customer.Add("Active", reader[3].ToString());
            reader.Close();

            // Obtain information from address table by address ID corresponding to customer
            query = $"SELECT * FROM address WHERE addressId = '{addressID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();

            // Add customer data from adddress table
            string cityID = reader[3].ToString();
            Customer.Add("Address", reader[1].ToString());
            Customer.Add("ZipCode", reader[4].ToString());
            Customer.Add("Phone", reader[5].ToString());
            reader.Close();

            // Obtain information from city table by corresponding cityId
            query = $"SELECT * FROM city WHERE cityId = '{cityID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();

            // Add customer data from city table
            string countryID = reader[2].ToString();
            Customer.Add("City", reader[1].ToString());
            reader.Close();

            // Obtain informatoin from country table by corresponding countryId
            query = $"SELECT * FROM country WHERE countryId = '{countryID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();

            // Add customer data from country table
            Customer.Add("Country", reader[1].ToString());
            reader.Close();
            DBClose();

            return Customer;
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

        // Create a new user
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

        // Create a new customer
        public static void createCustomer(string name, int addressID, int active, string creator)
        {
            int id = getNextCustomerID();
            string currentDateTime = getCurrentDateTime();
            String sqlString = $"INSERT INTO user(customerId, customerName, addressId, active, createDate, createBy, lastUpdatedBy) VALUES ('{id}', '{name}', '{addressID}', '{active}', '{currentDateTime}', '{creator}', '{creator}');";

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

        // Obtain next customer ID
        public static int getNextCustomerID()
        {
            int nextCustomerID = 0;
            DBOpen();
            MySqlCommand cmd = new MySqlCommand("SELECT customerId FROM customer", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customerIDList.Add(Convert.ToInt32(reader[0]));
            }
            reader.Close();
            DBClose();
            foreach (int ID in customerIDList)
            {
                if (ID > nextCustomerID)
                {
                    nextCustomerID = ID;
                }
            }
            nextCustomerID++;
            return nextCustomerID;
        }

    }
}
