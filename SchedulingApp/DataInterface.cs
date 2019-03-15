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
        // Initialize Variables
        // Hold current userID and userName
        private static int currentUserID;
        private static string currentUserName;
        // Lists for determining next available ID
        private static List<int> userIDList = new List<int>();
        private static List<int> customerIDList = new List<int>();
        private static List<int> countryIDList = new List<int>();
        private static List<int> cityIDList = new List<int>();
        private static List<int> addressIDList = new List<int>();
        private static List<int> appointmentIDList = new List<int>();
        // Connection to DB
        public static string connectionString = "server=52.206.157.109;userid=U05Csd;database=U05Csd;password=53688462289;convert zero datetime=true;";
        // Variables for Database Interaction
        public static MySqlConnection conn = new MySqlConnection(connectionString);
        public static MySqlCommand cmd;
        public static MySqlDataReader reader;

        // Getter functions
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

        // Get next available user ID
        public static int getNextUserID()
        {
            // Set to 0
            int nextUserID = 0;
            DBOpen();
            // Execute query to get userId's from user table
            cmd = new MySqlCommand("SELECT userId FROM user", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Add ID for each row
                userIDList.Add(Convert.ToInt32(reader[0]));
            }
            reader.Close();
            DBClose();
            // Iterate over IDList
            foreach (int ID in userIDList)
            {
                // Locate highest ID
                if (ID > nextUserID)
                {
                    // Set ID to highest if higher
                    nextUserID = ID;
                }
            }
            // Add one to highest ID in list
            nextUserID++;
            return nextUserID;
        }

        // Get current local DateTime
        public static string getCurrentDateTime()
        {
            var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
            string currentDateTime = DateTime.Now.ToString(isoDateTimeFormat.SortableDateTimePattern);
            return currentDateTime;
        }

        // Function to open database
        public static void DBOpen()
        {
            // If connection is not open, obtain string and open connection
            if (conn.State != ConnectionState.Open)
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
            }
            else
            {
                // If connection is open, close connection and re-open
                DBClose();
                DBOpen();
            }
        }

        // Close Database connection
        public static void DBClose()
        {
            conn.Close();
        }

        // General function for filling DataGridViews
        public static void displayDGV(String query, DataGridView DGV)
        {
            // Execute query passed and fill DataTable, set the passed DGV DataSource to new DataTable
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            DGV.DataSource = dt;
            DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // Populate's Customer CombBox
        public static void populateComboBox(ComboBox comboBox)
        {
            String query = "SELECT customerId, customerName FROM customer";
            DBOpen();
            // Execute query to selected customerId, and customerName from customer table
            MySqlDataAdapter adp = new MySqlDataAdapter(query, conn);
            // Create new DataTable and fill with data returned from query
            DataTable dt = new DataTable("Customer");
            adp.Fill(dt);
            // Set ComboxBox DataSource to new DataTable and set DisplayMember to CustomerName so Name is shown and ValueMember to the ID so it is associated
            comboBox.DataSource = dt;
            comboBox.DisplayMember = "customerName";
            comboBox.ValueMember = "customerId";
            DBClose();
        }

        // Convert Times in DataTable to local time based on user's machine
        public static void convertToLocal(DataTable table, string columnName)
        {
            // Iterate through the rows in the datatable passed
            foreach (DataRow row in table.Rows)
            {
                // Obtain timezone for user
                TimeZoneInfo currentZone = TimeZoneInfo.Local;
                // Obtain DateTime from DataTable
                DateTime returnedDateTime = row.Field<DateTime>(columnName);
                // Convert DateTime in table to local time
                DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(returnedDateTime, currentZone);
                // Set DateTime in DataTable to converted DateTime
                row.SetField(columnName, localDateTime);
            }
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
                // foreach row, add ID, Name, and Active status for customer from customer table
                addressID = reader[2].ToString();
                Customer.Add("ID", reader[0].ToString());
                Customer.Add("Name", reader[1].ToString());
                Customer.Add("Active", (bool) reader[3]);
            }
            else
            {
                // If unable to obtain data, throw exception
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
            // Obtain next available ID
            int id = getNextUserID();
            string currentDateTime = getCurrentDateTime();
            String sqlString = $"INSERT INTO user(userId, userName, password, active, createBy, createDate, lastUpdatedBy) VALUES ('{id}', '{username}', '{password}', '{active}', '{creator}', '{currentDateTime}', '{creator}');";

            // Establish and open database connection and execute add user information
            DBOpen();
            cmd = new MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        // Create a new customer
        public static void createCustomer(string name, string address, string city, string country, string zipcode, string phoneNumber, bool active, string creator, string secondAddress = " ")
        {
            // Get next available ID
            int id = getNextID("customerId", "customer", customerIDList);
            // Variables for holding ID's to reference between tables
            int addressID;
            int cityID;
            int countryID;
            int activeInt;
            String currentDateTime = getCurrentDateTime();

            // Set active based on active status passed from form
            if (active == true)
            {
                activeInt = 1;
            }
            else
            {
                activeInt = 0;
            }

            DBOpen();

            // Check if country exists, if not, create a new one
            String query = $"SELECT countryId FROM country WHERE country = '{country}';";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                // If country exists, set countryID for reference
                countryID = Convert.ToInt32(reader[0]);
                reader.Close();
            }
            else
            {
                // If country doesn't exist, create new
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
                // If exists, set cityID for reference
                cityID = Convert.ToInt32(reader[0]);
            }
            else
            {
                // If it doesn't exist, create a new city
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
                // If exists, record addressID for reference
                addressID = Convert.ToInt32(reader[0]);
            }
            else
            {
                // If it doesn't, create new address
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

        // Update Customer based on data from form
        public static void updateCustomer(int ID, string name, string address, string city, string country, string zipcode, string phoneNumber, bool active, string secondAddress = " ")
        {
            // TODO Refactor
            // TODO Implement ability to check if other customers use address, city, country and create new as necessary

            // Initialize ID's to invalid numbers to ensure they are obtained correctly
            int addressID = -1;
            int cityID = -1;
            int countryID = -1;
            int activeInt;
            String currentDateTime = getCurrentDateTime();

            DBOpen();

            // Get ID's for references
            // addressId
            String query = $"SELECT addressId FROM customer WHERE customerId = '{ID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                addressID = Convert.ToInt32(reader[0]);
            }
            reader.Close();

            // cityId
            query = $"SELECT cityId FROM address WHERE addressId = '{addressID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                cityID = Convert.ToInt32(reader[0]);
            }
            reader.Close();

            // countryId
            query = $"SELECT countryId FROM city WHERE cityId = '{cityID}'";
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                countryID = Convert.ToInt32(reader[0]);
            }
            reader.Close();

            // Check if any ID's were not obtained, if not, throw exception
            if (addressID == -1 || cityID == -1 || countryID == -1)
            {
                throw new Exception("Unable to obtain ID's for associated customer data. Please try again.");
            }

            // Set active status to valid mysql format
            if (active == true)
            {
                activeInt = 1;
            }
            else
            {
                activeInt = 0;
            }

            // Update each table associated with customer
            // Update customer
            query = $"UPDATE customer SET customerName = '{name}', active = '{activeInt}',  lastUpdateBy = '{currentUserName}' WHERE customerId = '{ID}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            // Update address
            query = $"UPDATE address SET address = '{address}', address2 = '{secondAddress}', postalCode = '{zipcode}', phone = '{phoneNumber}', lastUpdateBy = '{currentUserName}' WHERE addressId = '{addressID}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            // Update city
            query = $"UPDATE city SET city = '{city}', lastUpdateBy = '{currentUserName}' WHERE cityId = '{cityID}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            // Update country
            query = $"UPDATE country SET country = '{country}', lastUpdateBy = '{currentUserName}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            DBClose();
        }

        // Delete Customer from customer table
        public static void deleteCustomer(int customerID)
        {
            DBOpen();
            String query = $"DELETE FROM customer WHERE customerId = '{customerID}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        // Obtain next ID available
        public static int getNextID(string nameOfID, string table, List<int> list)
        {
            // Set initial ID to 0
            int nextID = 0;
            string query = $"SELECT {nameOfID} FROM {table}";
            DBOpen();
            // Execute query to obtain existing ID's
            cmd = new MySqlCommand(query, conn);
            reader.Close();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Add ID's to appropriate list
                list.Add(Convert.ToInt32(reader[0]));
            }
            reader.Close();
            DBClose();
            // Iterate through ID's
            foreach (int ID in list)
            {
                // If ID iterated is greater than nextID, set as nextID
                if (ID > nextID)
                {
                    nextID = ID;
                }
            }
            // Add one to highest ID found
            nextID++;
            // Clear list for future use
            list.Clear();
            return nextID;
        }

        // Create Appointments
        public static void createAppointment(int customerId, string title, string description, string location, string contact, string url, string startTime, string endTime, string creator)
        {
            // Obtain next available ID
            int id = getNextID("appointmentId", "appointment", appointmentIDList);
            string currentDateTime = getCurrentDateTime();
            //  Insert data into appointment table based on data passed from form
            String sqlString = $"INSERT INTO appointment(appointmentId, customerId, title, description, location, contact, url, start, end, createDate, createdBy, lastUpdateBy) VALUES ('{id}', '{customerId}', '{title}', '{description}', '{location}', '{contact}', '{url}', '{startTime}', '{endTime}', '{currentDateTime}', '{creator}', '{creator}');";

            // Execute query
            DBOpen();
            cmd = new MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        // Update Appointments
        public static void updateAppointment(int appointmentId, int customerId, string title, string description, string location, string contact, string url, string startTime, string endTime)
        {
            string currentDateTime = getCurrentDateTime();
            // Update appointment table based on data passed from form
            String sqlString = $"UPDATE appointment SET customerId = '{customerId}', title = '{title}', description = '{description}', location = '{location}', contact = '{contact}', url = '{url}', start = '{startTime}', end = '{endTime}', lastUpdateBy = '{getCurrentUserName()}' WHERE appointmentId = '{appointmentId}'";

            // Execute query
            DBOpen();
            cmd = new MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        // Delete Appointments
        public static void deleteAppoinment(int appointmentID)
        {
            DBOpen();
            // Remove entry from appointment where appointmentId matches the passed appointmentID from form
            String query = $"DELETE FROM appointment WHERE appointmentId = '{appointmentID}'";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            DBClose();
        }

        // Obtain DataTable of appointments based on userName
        public static DataTable getAppointments(string userName)
        {
            // Create new DataTable
            DataTable appointments = new DataTable();
            // Select times from appointment table where the creator matches the username passed
            String query = $"SELECT start, end FROM appointment WHERE createdBy = '{userName}'";
            DBOpen();
            // Execute query and fill DataTable
            MySqlDataAdapter adp = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(adp);
            adp.Fill(appointments);
            DBClose();
            // Return DataTable
            return appointments;
        }

        // OVERRIDE: Obtain all appointments
        public static DataTable getAppointments()
        {
            // Create new DataTable of appointments
            DataTable appointments = new DataTable();
            // Select ID, customerId, title, times, and creator from appointment table
            String query = $"SELECT appointmentId, customerId, title, start, end, createdBy FROM appointment";
            DBOpen();
            // Execute query and fill DataTable
            MySqlDataAdapter adp = new MySqlDataAdapter(query, conn);
            MySqlCommandBuilder cmd = new MySqlCommandBuilder(adp);
            adp.Fill(appointments);
            DBClose();
            // Return DataTable
            return appointments;
        }

        // Obtain Dictionary containing a specific appointment's information
        public static Dictionary<string, string> getAppointmentInfo(int appointmentID)
        {
            Dictionary<string, string> Appointment = new Dictionary<string, string>();

            // Retrieve details from appointment table that match appointmentID
            string query = $"SELECT * FROM appointment WHERE appointmentId = '{appointmentID.ToString()}'";
            DBOpen();
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                // If there is a row, add data from that row into Dictionary
                Appointment.Add("ID", reader[0].ToString());
                Appointment.Add("customerID", reader[1].ToString());
                Appointment.Add("Title", reader[2].ToString());
                Appointment.Add("Description", reader[3].ToString());
                Appointment.Add("Location", reader[4].ToString());
                Appointment.Add("Contact", reader[5].ToString());
                Appointment.Add("URL", reader[6].ToString());
                Appointment.Add("Start", reader[7].ToString());
                Appointment.Add("End", reader[8].ToString());
            }
            else
            {
                // If no data is found matching that appointmentID, thow exception
                throw new DataNotFoundException("Unable to obtain appointment information. Please select an appointment and try again.");
            }
            reader.Close();
            DBClose();

            // Return dictionary of appointment
            return Appointment;
        }

        // Obtain appointments by month
        public static List<int> getAppointmentsByMonth(int month)
        {
            // Create list for holding appointmentIDs
            List<int> appointmentIDs = new List<int>();
            // Select appointmentId's from appointment table where the start Date's month matches month passed to function
            String query = $"SELECT appointmentId FROM appointment WHERE MONTH(start) = '{month}'";
            DBOpen();
            // Execute query
            cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // For each row returned, add ID to list
                appointmentIDs.Add(Convert.ToInt32(reader[0]));
            }
            reader.Close();
            DBClose();

            // return list of appointmentId's
            return appointmentIDs;
        }

        // Create psuedo data if it hasn't been populated
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

            DBClose();
        }

    }
}
