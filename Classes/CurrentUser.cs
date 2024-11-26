using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Tls;
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

        public static Appointment NextAppointment;

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

        private static void FifteenMinAlert()
        {

            var query = from appt in Appointments where appt.StartTime > DateTime.Now select appt;
            //NextAppointment =

            foreach (var appt in query.AsEnumerable())
            {
                
                if (appt.StartTime > DateTime.Now)
                {
                    //if (appt.StartTime.Year == DateTime.Now.Year && appt.StartTime.Month == DateTime.Now.Month && appt.StartTime.Day == DateTime.Now.Day) { 
                    NextAppointment = new Appointment(appt.ApptID, appt.CustID, appt.StartTime, appt.EndTime, appt.ApptType);

                    Console.WriteLine($"Next appointment: {NextAppointment.StartTime.Date.ToString("MM-dd-yyyy")}");

                    if (appt.StartTime.Date == DateTime.Now.Date) {
                        TimeSpan TimeToNextAppointment = appt.StartTime - DateTime.Now;
                        Console.WriteLine($"Minutes until next appointment {TimeToNextAppointment.TotalMinutes}");
                        if (TimeToNextAppointment.TotalMinutes <= 15)
                        {
                            // Change custID to customerName
                            MessageBox.Show($"You have an appointment with {appt.CustID} in {TimeToNextAppointment} @{appt.StartTime.TimeOfDay}!");
                            return;
                        }
                    }
                }
            }

            
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

            DataTable ApptQueryResult; 

            DataTable AppointmentTable = new DataTable();

            // Only display what's necessary
            string allAppointmentsQuery = $"SELECT appointmentId, customerId, userId, type, start, end FROM appointment WHERE userId = {CurrentUserID};";
            MySqlCommand apptsQuery = new MySqlCommand(allAppointmentsQuery, DBConnection.connect);
            DBConnection.OpenConnection();
            using (DBConnection.connect)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(allAppointmentsQuery, DBConnection.connect);
                ApptQueryResult = new DataTable();

                dataAdapter.Fill(ApptQueryResult);
            }

           
            //Processes data from AppointmentTable 
            var query = 
                    from row in ApptQueryResult.AsEnumerable()
                    select new 
                    {ApptID = row.Field<int>("appointmentId"),
                    CustID = row.Field<int>("customerId"),
                    UserID = row.Field<int>("userId"),
                    ApptType = row.Field<string>("type"),
                    StartTime = row.Field<DateTime>("start"),
                    EndTime = row.Field<DateTime>("end")
                    };

            // Change the appearance for the DataTable here vv
            // i.e. AppointmentTable.Columns.Add("Customer")
            AppointmentTable = ApptQueryResult.Clone();
            foreach (var item in query)
            {
                // Initializes a new appointment converted to Local time 
                Appointment newAppt = new Appointment(item.ApptID,item.CustID, TimeZoneInfo.ConvertTimeFromUtc(item.StartTime, TimeZoneInfo.Local), TimeZoneInfo.ConvertTimeFromUtc(item.EndTime, TimeZoneInfo.Local), item.ApptType);

                Appointments.Add(newAppt);
                
                AppointmentTable.Rows.Add(item.ApptID, item.CustID, item.ApptID, item.ApptType, TimeZoneInfo.ConvertTimeFromUtc(item.StartTime, TimeZoneInfo.Local), TimeZoneInfo.ConvertTimeFromUtc(item.EndTime, TimeZoneInfo.Local));
            }

            // Change the appearance for the DataTable here vv
            FifteenMinAlert();
            //Appointments;
            return AppointmentTable;

        }

        public static DataTable GetAppointmentsByDate(DateTime date)
        {
            //DataTable AppointmentTable;

            DateTime pickedDate = date;
            DataTable ApptsTable = new DataTable();
            DataTable ApptsQueryResult;

            // added customerId after it was working already
            string getbyDate = $"SELECT customerName, customerId, appointmentId, TIME(start), TIME(end), type FROM customer INNER JOIN appointment ON customer.customerId = appointment.customerId WHERE DATE(start) = '{pickedDate.Date.ToString("yyyy-MM-dd")}' AND userId = {CurrentUserID};";

            DBConnection.OpenConnection();

            MySqlConnection connection = DBConnection.connect;


            using (connection)
            {

                MySqlDataAdapter mySqlCommand = new MySqlDataAdapter(getbyDate, connection);

                ApptsQueryResult = new DataTable();

                mySqlCommand.Fill(ApptsQueryResult);
            }

            //Processes data from AppointmentTable 
            var query =
                    from row in ApptsQueryResult.AsEnumerable()
                    select new
                    {
                        CustomerName = row.Field<int>("customerName"),
                        CustID = row.Field<int>("customerId"),
                        ApptID = row.Field<int>("appointmentId"),
                        UserID = row.Field<int>("userId"),
                        ApptType = row.Field<string>("type"),
                        StartTime = row.Field<DateTime>("start"),
                        EndTime = row.Field<DateTime>("end")
                    };

            // Change the appearance for the DataTable here vv
            // i.e. ApptsTable.Columns.Add("Customer")

            foreach (var item in query)
            {
                // Local time changes in here
                ApptsTable.Rows.Add(item.CustomerName, item.CustID, item.ApptID, TimeZoneInfo.ConvertTimeFromUtc(item.StartTime, TimeZoneInfo.Local), TimeZoneInfo.ConvertTimeFromUtc(item.EndTime, TimeZoneInfo.Local), item.ApptType);
            }
            
            return ApptsTable;
        }

        public static DataTable GetCustomers()
        {

            DataTable CustomerList;

            // Rewrite this to return address, city, country instead of addressId & where appointmentId is the source of the customer
            //string allCustomersQuery = $"SELECT customerId, customerName, address, city, country FROM customer INNER JOIN address ON customer.addressId = address.addressId INNER JOIN address INNER JOIN city ON address.cityId = city.cityId INNER JOIN country ON city.countryId = country.countryId;"

            // addressId


            string allCustomersQuery = $"SELECT customerId, customerName, address FROM customer INNER JOIN address WHERE customer.addressId = address.addressId;";

            //string allCustsQuery = $"SELECT customername, customerId, address, addressId, city, country FROM customer INNER JOIN address ON customer.customerId = address.customerId WHERE appointment.userId = {CurrentUserID}";
            //$"WHERE userId = {CurrentUserID};";
            MySqlCommand customersQuery = new MySqlCommand(allCustomersQuery, DBConnection.connect);
            DBConnection.OpenConnection();
            // Only display what's necessary
            using (DBConnection.connect)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(allCustomersQuery, DBConnection.connect);
                CustomerList = new DataTable();

                dataAdapter.Fill(CustomerList);
            }

            return CustomerList;
        }

        //public static List<Appointment> Appointments { get { GetAppointments(); return Appointments; } set { GetAppointments(); } }
        public static List<Appointment> Appointments { get; set; } = new List<Appointment>();

        //public static List<Appointment> Appointments = new List<Appointment>();
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

        //public static MessageBox FifteenMinAlert() { }
    }
}
