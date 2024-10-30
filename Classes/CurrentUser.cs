using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.CRUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System.DB
{
    // Holds info from logged in user
    internal class CurrentUser
    {
        // ----- Properties ----- //
        public static int CurrentUserID { get; set; }
        public static string UserName { get; set; }
        private static string Password { get; set; }
        public static string UserLocation { get; set; }

        //"Login_History.txt"
        private static string LogFilePath { get; set; } = "C:\\Users\\LabUser\\source\\repos\\AkariBowens_Sheduling-System\\Files\\Login_History.txt";

        // ----- File Properties ----- //
        private static FileStream fileWriter;
        private static FileStream fileReader;

        // ----- Methods ----- //

        // Logs every time a new user is logged in - called in constructor - static?
        private static void LogLastLogin()
        {

            DateTime currentTime = DateTime.Now;

            string logString = $"Logged in {UserName} @{currentTime} in {UserLocation}\n ";
            //Console.WriteLine(logString + " -- Console.Write");

            string data;

            fileWriter = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write);

            // Encodes logString 
            byte[] buffer = Encoding.UTF8.GetBytes(logString);
            fileWriter.Write(buffer, 0, buffer.Length);

            fileWriter.Close();

            // -- Reads back recent data that was written to the file -- //
            fileReader = new FileStream(LogFilePath, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileReader))
            {
                // make this read the very last line of the file
                data = reader.ReadLine();
            }
            Console.WriteLine(data + " -- from fileStream");
            //Console.ReadKey();

        }

        public static void LogInUser(CurrentUser user)
        {
            // 
        }

        // ----- Constructor ----- //
        public CurrentUser(int currentID, string username, string pass, string location)
        {
            CurrentUserID = currentID;
            UserName = username;
            Password = pass;
            UserLocation = location;
            LogLastLogin();
            Console.WriteLine($"CurrentUser - {CurrentUserID}");
        }

        // ----- Static Class ----- //

        public static DataTable GetAppointments()
        {

            DataTable AppointmentList;

            string allAppointmentsQuery = $"SELECT appointmentId, customerId, userId, type FROM appointment WHERE userId = {CurrentUserID};";
            MySqlCommand apptsQuery = new MySqlCommand(allAppointmentsQuery, DBConnection.connect);
            DBConnection.OpenConnection();
            using (DBConnection.connect)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(allAppointmentsQuery, DBConnection.connect);
                AppointmentList = new DataTable();

                dataAdapter.Fill(AppointmentList);
            }

            return AppointmentList;

        }

        public static DataTable GetCustomers()
        {

            DataTable CustomerList;

            // Rewrite this to return address, city, country instead of addressId & where appointmentId is the source of the customer
            //string allCustomersQuery = $"SELECT customerId, customerName, address, city, country FROM customer INNER JOIN address ON customer.addressId = address.addressId INNER JOIN address INNER JOIN city ON address.cityId = city.cityId INNER JOIN country ON city.countryId = country.countryId;"
           
            string allCustomersQuery = $"SELECT customerId, customerName, addressId FROM customer;";
            //$"WHERE userId = {CurrentUserID};";
            MySqlCommand customersQuery = new MySqlCommand(allCustomersQuery, DBConnection.connect);
            DBConnection.OpenConnection();
            using (DBConnection.connect)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(allCustomersQuery, DBConnection.connect);
                CustomerList = new DataTable();

                dataAdapter.Fill(CustomerList);
            }

            return CustomerList;
        }

        public static DataTable Appointments { get { GetAppointments(); return Appointments; } set { GetAppointments(); } }
        public static DataTable Customers
        {
            get { GetCustomers(); return Customers; }
            set { GetCustomers(); }

            //{ 
            // SQL Query result here

            // - add all to an sql query class... i.e. GetCustomers(), GetAppointments(), DeleteCustomer(), DeleteAppointment() or.. DeleteCommand(var customer/appointment, int selectedId){sql query string with 2 input options}
            // allAppointmentsQuery = $"SELECT * FROM Appointments WHERE userId = {CurrentUserID};";
            //MySqlCommand apptsQuery = new MySqlCommand()    
            //};

           

        }
    }
}
