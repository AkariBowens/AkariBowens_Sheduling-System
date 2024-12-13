using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System.DB
{
    internal class Appointment
    {
        // ----- Methods ----- //
        public int ApptID { get; set; }
        public int CustID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }

        public string ApptType { get; set; }
        public string URL { get; set; }

        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Hard code all the properties below - except LastUpdate()
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime LastUpdate { get; set; }
        // Hard-code this
        public string LastUpdatedBy { get; set; }
        
        public static Appointment SelectedAppointment;
        public static List<Appointment> Appointments { get; set; } = new List<Appointment>();

        // ----- Properties ----- //
        public static bool AddAppointment(Appointment appt, Customer customer)
        {
            try
            {

                Appointment newAppointment = appt;
                Console.WriteLine($"In AddAppointment(): {appt.EndTime.Date}");
                Customer customerForAppt = customer;

                // Converts Appointment start and end times to local and accounts for DST
                appt.StartTime = TimeZoneInfo.ConvertTimeToUtc(appt.StartTime, TimeZoneInfo.Local);
                appt.EndTime = TimeZoneInfo.ConvertTimeToUtc(appt.EndTime, TimeZoneInfo.Local);

                appt.CreateDate = TimeZoneInfo.ConvertTimeToUtc(appt.CreateDate, TimeZoneInfo.Local);
                appt.LastUpdate = TimeZoneInfo.ConvertTimeToUtc(appt.LastUpdate, TimeZoneInfo.Local);

                //Console.WriteLine(custName + " -- in AppAppointment()");
                //int? customerID;

                if (newAppointment != null) 
                { 
                    DBConnection.OpenConnection();

                    //string CustomerIDString = $"SELECT customerId FROM customer WHERE customerName = '{custName}';";

                    //MySqlCommand findCustomerID = new MySqlCommand(CustomerIDString, DBConnection.connect);

                    //customerID = Convert.ToInt32(findCustomerID.ExecuteScalar());

                    string ApptAddString = $"INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdby, lastUpdate, lastUpdateBy) VALUES( {customerForAppt.CustomerID}, {appt.UserID}, '{appt.Title}', '{appt.Description}', '{appt.Location}', '{appt.Contact}', '{appt.ApptType}', '{appt.URL}', '{appt.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{appt.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}', '{appt.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")}', '{appt.CreatedBy}', '{appt.LastUpdate.ToString("yyyy-MM-dd HH:mm:ss")}', '{appt.LastUpdatedBy}');";

                    MySqlCommand addAppointment = new MySqlCommand(ApptAddString, DBConnection.connect);
                    if (addAppointment.ExecuteNonQuery() == 0)
                    {
                        //return false;
                        Console.WriteLine($"Adding appointment failed!");
                        throw new Exception("Adding appointment failed!");
                    }
                    Console.WriteLine($"Added new appointment with {customerForAppt.CustomerName} on {appt.StartTime.Date.ToString("MM-dd-yyyy")} @{appt.StartTime.TimeOfDay}");
                }

                Customer.SelectedCustomer = null;
                SelectedAppointment = null;
                return true;
            }
            catch (Exception exc)
            {
                // Error message
                Console.WriteLine(exc.Message.ToString(), " --Appointment Adding");
                return false;
            }
        }
        public static bool RemoveAppt(int ApptId) {
            
            int AppointmentId = ApptId;
            string deleteString = $"DELETE FROM appointment WHERE appointmentId = {AppointmentId}";

            
            DBConnection.OpenConnection();
            MySqlConnection connection = DBConnection.connect;

            MySqlCommand deleteAppt = new MySqlCommand(deleteString, connection);
            if (deleteAppt.ExecuteNonQuery() == 0)
            {
                return false;
                throw new Exception("Could not remove!");
            }
            Console.WriteLine($"Removed appointment with ID {ApptId}");
            return true;

        }
        public static bool UpdateAppt(Appointment selectedAppointment, Appointment Appt)
        {
            try
            {
                Appointment appointment = Appt;

                // Converts Appointment start and end times to utc and accounts for DST
                appointment.StartTime = TimeZoneInfo.ConvertTimeToUtc(appointment.StartTime, TimeZoneInfo.Local);
                appointment.EndTime = TimeZoneInfo.ConvertTimeToUtc(appointment.EndTime, TimeZoneInfo.Local);

                appointment.CreateDate = TimeZoneInfo.ConvertTimeToUtc(appointment.CreateDate, TimeZoneInfo.Local);
                appointment.LastUpdate = TimeZoneInfo.ConvertTimeToUtc(appointment.LastUpdate, TimeZoneInfo.Local);

                // Added "HH" instead of hh
                string start = $"start = '{appointment.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}'";
                string end = $"end = '{appointment.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}'";
                string type = $"type = '{appointment.ApptType}'";

                string fullString = string.Empty;

                if (appointment.StartTime != selectedAppointment.StartTime)
                {
                    fullString = start;
                }

                if (appointment.EndTime != selectedAppointment.EndTime)
                {
                    if (fullString == string.Empty)
                    {
                        fullString = end;
                    }
                    else if (fullString != string.Empty)
                    {
                        fullString = fullString + $", {end}";
                    }
                }

                if (appointment.ApptType != selectedAppointment.ApptType)
                {
                    if (fullString == string.Empty)
                    {
                        fullString = type;
                    }
                    else if (fullString != string.Empty)
                    {
                        fullString = fullString + $", {type}";
                    }
                }

                string updateString =
                    $"Update appointment " +
                    $"SET {fullString} " +
                    $"WHERE appointmentId = {appointment.ApptID}";

                Console.WriteLine(updateString + " -- UpdateString");
                DBConnection.OpenConnection();
                MySqlConnection connection = DBConnection.connect;
                MySqlCommand updateCommmand = new MySqlCommand(updateString, DBConnection.connect);

                if(updateCommmand.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Update unsuccessful.");
                }

                Console.WriteLine($"Updated Appointment with ID: {appointment.ApptID}");
                
                return true;
            } catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                return false;
            }
        }

        public static Appointment NextAppointment;
        private static void FifteenMinAlert()
        {
            var query = from Appt in Appointments where Appt.StartTime > DateTime.Now select Appt;
            //NextAppointment =

            foreach (var Appt in query.AsEnumerable())
            {
                if (Appt.StartTime > DateTime.Now)
                {
                    //if (appt.StartTime.Year == DateTime.Now.Year && appt.StartTime.Month == DateTime.Now.Month && appt.StartTime.Day == DateTime.Now.Day) { 
                    NextAppointment = new Appointment(Appt.ApptID, Appt.CustID, Appt.StartTime, Appt.EndTime, Appt.ApptType);

                    // Console.WriteLine($"Next appointment: {NextAppointment.StartTime.Date.ToString("MM-dd-yyyy")}");

                    if (NextAppointment.StartTime.Date == DateTime.Now.Date)
                    {
                        TimeSpan TimeToNextAppointment = NextAppointment.StartTime - DateTime.Now;
                        Console.WriteLine($"Minutes until next appointment {TimeToNextAppointment.TotalMinutes}");
                        if (TimeToNextAppointment.TotalMinutes <= 15)
                        {

                            // Change custID to customerName
                            // Fix minutes to single digit, rounded down
                            // this isn't it
                            var wholeNumberTimeLeft = Customer.GetCustomers().AsEnumerable().Where(cust => (int)cust[columnName: "customerId"] == Appt.CustID);

                            
                            MessageBox.Show($"You have an appointment with {wholeNumberTimeLeft} in {((int)TimeToNextAppointment.TotalMinutes)} @{Appt.StartTime.TimeOfDay}!");
                            return;
                        }
                    }
                }
            }
        }
        public static DataTable GetAppointments()
        {

            DataTable ApptQueryResult;

            DataTable AppointmentTable = new DataTable();

            // Only display what's necessary
            string allAppointmentsQuery = $"SELECT appointmentId, customerId, userId, type, start, end FROM appointment WHERE userId = {CurrentUser.CurrentUserID};";
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
                    {
                        ApptID = row.Field<int>("appointmentId"),
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
                Appointment newAppt = new Appointment(item.ApptID, item.CustID, TimeZoneInfo.ConvertTimeFromUtc(item.StartTime, TimeZoneInfo.Local), TimeZoneInfo.ConvertTimeFromUtc(item.EndTime, TimeZoneInfo.Local), item.ApptType);

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
            string getbyDate = $"SELECT customerName, customerId, appointmentId, TIME(start), TIME(end), type FROM customer INNER JOIN appointment ON customer.customerId = appointment.customerId WHERE DATE(start) = '{pickedDate.Date.ToString("yyyy-MM-dd")}' AND userId = {CurrentUser.CurrentUserID};";

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

        // ----- Constructor ----- //

        public Appointment(int apptId, int custId, DateTime start, DateTime end, string apptType)
        {
            // Add 'int apptId' ^^ above

            if (apptId >= 0)
            {
                ApptID = apptId;
            }
            else
            {
                ApptID = -1;
            }

            // Get ID from selected Customer via customer object
            CustID = custId;
            UserID = CurrentUser.CurrentUserID;

            Title = @"not needed";
            Description = @"not needed";
            Location = @"not needed";

            // Get from user input
            Contact = @"not needed";
            ApptType = apptType.Trim();
            URL = @"not needed";

            // Get from constructor
            StartTime =  start;
            EndTime = end;
            
            // ----- //
            CreateDate = DateTime.Now;
            CreatedBy = CurrentUser.UserName.Trim();
            LastUpdate = DateTime.Now;
            LastUpdatedBy = CurrentUser.UserName.Trim();
        }
        // ----- Static Class ----- //

    }
}
