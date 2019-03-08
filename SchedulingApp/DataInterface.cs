using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace SchedulingApp
{
    class DataInterface
    {
        private static int currentUserID;
        private static string currentUserName;
        private static List<int> userIDList = new List<int>();
        private static List<int> customerIDList = new List<int>();
        private static List<int> countryIDList = new List<int>();
        private static List<int> cityIDList = new List<int>();
        private static List<int> addressIDList = new List<int>();
        private static List<int> appointmentIDList = new List<int>();
        public static string connectionString = "server=52.206.157.109;userid=U05Csd;database=U05Csd;password=53688462289;convert zero datetime=true;";
        public static MySqlConnection conn = new MySqlConnection(connectionString);
        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static DataTable appointmentTable = new DataTable("Appointments");
        public static DataColumn dtColumn;
        public static DataRow dtRow;
        public static DataSet dtSet;

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
        
        public static List<int> getAppointmentIDList()
        {
            return appointmentIDList;
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
            cmd = new MySqlCommand("SELECT userId FROM user", conn);
            reader = cmd.ExecuteReader();
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
            var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
            string currentDateTime = DateTime.Now.ToString(isoDateTimeFormat.SortableDateTimePattern);
            return currentDateTime;
        }

        public static void DBOpen()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
            }
            else
            {
                DBClose();
                DBOpen();
            }
        }

        public static void DBClose()
        {
            conn.Close();
        }

        // General function for filling DataGridViews
        public static void displayDGV(String query, DataGridView DGV)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DGV.DataSource = dt;
            DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public static void createAppointmentTable()
        {
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "ID";
            appointmentTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Customer";
            appointmentTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Title";
            appointmentTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Start";
            appointmentTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "End";
            appointmentTable.Columns.Add(dtColumn);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = appointmentTable.Columns["ID"];
            appointmentTable.PrimaryKey = PrimaryKeyColumns;

            dtSet = new DataSet();
            dtSet.Tables.Add(appointmentTable);
        }

        public static void displayAppointments(DataGridView dgv)
        {
            DBOpen();
            // Fix CONVERT_TZ(start, '+00:00', '{offset}') AS 'Start Time'    WHERE a.createBy = '{currentUserName}'
            String query = $"SELECT a.appointmentId, c.customerName, a.title, a.start, a.end FROM appointment AS a, customer AS c WHERE c.customerId = a.customerId";
            //DataInterface.displayDGV(query, appointmentsDGV);
            DBOpen();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dtRow = appointmentTable.NewRow();
                dtRow["ID"] = Convert.ToInt32(reader[0]);
                dtRow["Customer"] = reader[1].ToString();
                dtRow["Title"] = reader[2].ToString();
                dtRow["Start"] = convertToLocal(reader[3].ToString());
                dtRow["End"] = convertToLocal(reader[4].ToString());

            }
            reader.Close();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dtSet.Tables["Customers"];
            dgv.DataSource = bindingSource;
            DBClose();
        }

        public static string convertToLocal(string time)
        {
            DateTime utcDateTime = DateTime.Parse(time);
            DateTime localDateTime = utcDateTime.ToLocalTime();
            return localDateTime.ToString("MM/dd/yyyy hh:mm tt");
        }

        // Build Dictionary object for customer
        public static Dictionary<string, object> getCustomerInfo(int customerID)
        {
            Dictionary<string, object> Customer = new Dictionary<string, object>();
            string addressID;



            // Retrieve details from customer table that match customerID
            string query = $"SELECT * FROM customer WHERE customerId = '{customerID.ToString()}'";
            DBOpen();
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                // Build customer dictionary object from customer table
                addressID = reader[2].ToString();
                Customer.Add("ID", reader[0].ToString());
                Customer.Add("Name", reader[1].ToString());
                Customer.Add("Active", (bool) reader[3]);
            }
            else
            {
                throw new Exception("Unable to obtain customer inforamtion");
            }
            reader.Close();

            // Obtain information from address table by address ID corresponding to customer
            query = $"SELECT * FROM address WHERE addressId = '{addressID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();

            // Add customer data from adddress table
            string cityID = reader[3].ToString();
            Customer.Add("Address", reader[1].ToString());
            Customer.Add("Address2", reader[2].ToString());
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

        // Create a new user
        public static void createUser(string username, string password, int active, string creator)
        {
            int id = getNextUserID();
            string currentDateTime = getCurrentDateTime();
            String sqlString = $"INSERT INTO user(userId, userName, password, active, createBy, createDate, lastUpdatedBy) VALUES ('{id}', '{username}', '{password}', '{active}', '{creator}', '{currentDateTime}', '{creator}');";

            // Establish and open database connection
            DBOpen();
            cmd = new MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        // Create a new customer
        public static void createCustomer(string name, string address, string city, string country, string zipcode, string phoneNumber, bool active, string creator, string secondAddress = " ")
        {
            // TODO Refactor

            int id = getNextID("customerId", "customer", customerIDList);
            int addressID;
            int cityID;
            int countryID;
            int activeInt;
            String currentDateTime = getCurrentDateTime();

            if (active == true)
            {
                activeInt = 1;
            }
            else
            {
                activeInt = 0;
            }

            if (conn.State == ConnectionState.Open)
            {
                DBClose();
            }

            DBOpen();

            // Check if country exists, if not, create a new one
            String query = $"SELECT countryId FROM country WHERE country = '{country}';";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                countryID = Convert.ToInt32(reader[0]);
                reader.Close();
            }
            else
            {
                DBClose();
                countryID = getNextID("countryId", "country", countryIDList);
                String sqlString = $"INSERT INTO country(countryId, country, createDate, createdBy, lastUpdateBy) VALUES ('{countryID}', '{country}', '{currentDateTime}', '{creator}', '{creator}');";

                // Establish and open database connection
                DBOpen();
                cmd = new MySqlCommand(sqlString, conn);
                cmd.ExecuteNonQuery();
            }
            reader.Close();
            DBClose();

            DBOpen();
            // Check if city exists, if not, create a new one
            query = $"SELECT cityId FROM city WHERE city = '{city}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                cityID = Convert.ToInt32(reader[0]);
            }
            else
            {
                cityID = getNextID("cityId", "city", cityIDList);
                query = $"INSERT INTO city (cityId, city, countryId, createDate, createdBy, lastUpdateBy) VALUES ('{cityID}', '{city}', '{countryID}', '{currentDateTime}', '{creator}', '{creator}');";
                DBOpen();
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            reader.Close();

            // Check if address exists, if not, create a new one
            query = $"SELECT addressId FROM address WHERE address = '{address}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                addressID = Convert.ToInt32(reader[0]);
            }
            else
            {
                addressID = getNextID("addressId", "address", addressIDList);
                query = $"INSERT INTO address (addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) VALUES ('{addressID}', '{address}', '{secondAddress}', '{cityID}', '{zipcode}', '{phoneNumber}', '{currentDateTime}', '{creator}', '{creator}');";
                DBOpen();
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            reader.Close();

            // Create new customer
            query = $"INSERT INTO customer(customerId, customerName, addressId, active, createDate, createdBy, lastUpdateBy) VALUES ('{id}', '{name}', '{addressID}', '{activeInt}', '{currentDateTime}', '{creator}', '{creator}');";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        public static void updateCustomer(int ID, string name, string address, string city, string country, string zipcode, string phoneNumber, bool active, string secondAddress = " ")
        {
            // TODO Refactor
            // TODO Implement ability to check if other customers use address, city, country and create new as necessary

            int addressID = -1;
            int cityID = -1;
            int countryID = -1;
            int activeInt;
            String currentDateTime = getCurrentDateTime();

            if (conn.State == ConnectionState.Open)
            {
                DBClose();
            }

            DBOpen();

            // Get ID's
            String query = $"SELECT addressId FROM customer WHERE customerId = '{ID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                addressID = Convert.ToInt32(reader[0]);
            }
            reader.Close();

            query = $"SELECT cityId FROM address WHERE addressId = '{addressID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                cityID = Convert.ToInt32(reader[0]);
            }
            reader.Close();

            query = $"SELECT countryId FROM city WHERE cityId = '{cityID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                countryID = Convert.ToInt32(reader[0]);
            }
            reader.Close();

            if (addressID == -1 || cityID == -1 || countryID == -1)
            {
                throw new Exception("Unable to obtain ID's for associated customer data. Please try again.");
            }

            if (active == true)
            {
                activeInt = 1;
            }
            else
            {
                activeInt = 0;
            }

            // Update each table associated with customer
            query = $"UPDATE customer SET customerName = '{name}', active = '{activeInt}',  lastUpdateBy = '{currentUserName}' WHERE customerId = '{ID}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = $"UPDATE address SET address = '{address}', address2 = '{secondAddress}', postalCode = '{zipcode}', phone = '{phoneNumber}', lastUpdateBy = '{currentUserName}' WHERE addressId = '{addressID}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = $"UPDATE city SET city = '{city}', lastUpdateBy = '{currentUserName}' WHERE cityId = '{cityID}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = $"UPDATE country SET country = '{country}', lastUpdateBy = '{currentUserName}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            DBClose();
        }

        public static void deleteCustomer(int customerID)
        {
            DBOpen();
            String query = $"DELETE FROM customer WHERE customerId = '{customerID}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        // Obtain next ID
        public static int getNextID(string nameOfID, string table, List<int> list)
        {
            int nextID = 0;
            string query = $"SELECT {nameOfID} FROM {table}";
            DBOpen();
            cmd = new MySqlCommand(query, conn);
            reader.Close();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(Convert.ToInt32(reader[0]));
            }
            reader.Close();
            DBClose();
            foreach (int ID in list)
            {
                if (ID > nextID)
                {
                    nextID = ID;
                }
            }
            nextID++;
            list.Clear();
            return nextID;
        }

        public static void createAppointment(int customerId, string title, string description, string location, string contact, string url, string startTime, string endTime, string creator)
        {
            int id = getNextID("appointmentId", "appointment", appointmentIDList);
            string currentDateTime = getCurrentDateTime();
            String sqlString = $"INSERT INTO appointment(appointmentId, customerId, title, description, location, contact, url, start, end, createDate, createdBy, lastUpdateBy) VALUES ('{id}', '{customerId}', '{title}', '{description}', '{location}', '{contact}', '{url}', '{startTime}', '{endTime}', '{currentDateTime}', '{creator}', '{creator}');";

            // Establish and open database connection
            DBOpen();
            cmd = new MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        public static void generatePsuedoData()
        {
            DBOpen();
            // Create Test user
            string query = $"SELECT * FROM user WHERE userName = 'Test' OR userName = 'test'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            // check if 'Test' User already exists
            if (reader.HasRows)
            {
                // if user exists, exit function
                Console.WriteLine("User 'Test' already exists");
                reader.Close();
                DBClose();
                return;
            }
            else
            {
                // create 'Test' user
                createUser("Test", "Test", 1, "ADMIN");
            }
            reader.Close();

            // Create customers
            createCustomer("John Doe", "1111 Some St", "New York, New York", "United States", "10001", "111-111-1111", true, "ADMIN");
            createCustomer("Jane Doe", "1112 Some St", "New York, New York", "United States", "10001", "111-111-1112", true, "ADMIN");
            createAppointment(2, "Interview", "Interview for software developer position", "RM 201", "Jane Doe", "testUrl", $"{getCurrentDateTime()}" , $"{getCurrentDateTime()}", "ADMIN");

            DBClose();
        }

    }
}
