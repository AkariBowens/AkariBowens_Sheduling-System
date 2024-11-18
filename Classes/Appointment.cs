using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        // Hard-code this
        public string CreatedBy { get; set; }
        // is TIMESTAMP() - numbers
        public DateTime LastUpdate { get; set; }
        // Hard-code this
        public string LastUpdatedBy { get; set; }
        
        public static Appointment SelectedAppointment;

        // ----- Properties ----- //
        public static bool AddAppointment(Appointment appt, string customerName)
        {
            try
            {

                Appointment newAppointment = appt;
                string custName = customerName;
               
                Console.WriteLine(custName + " -- in AppAppointment()");
                int? customerID;
                
                if (newAppointment != null) 
                { 
                    DBConnection.OpenConnection();

                    string CustomerIDString = $"SELECT customerId FROM customer WHERE customerName = '{custName}';";

                    MySqlCommand findCustomerID = new MySqlCommand(CustomerIDString, DBConnection.connect);

                    customerID = Convert.ToInt32(findCustomerID.ExecuteScalar());

                    string ApptAddString = $"INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdby, lastUpdate, lastUpdateBy) VALUES( {customerID}, {newAppointment.UserID}, '{newAppointment.Title}', '{newAppointment.Description}', '{newAppointment.Location}', '{newAppointment.Contact}', '{newAppointment.ApptType}', '{newAppointment.URL}', '{newAppointment.StartTime.ToString("yyyy-MM-dd hh:mm:ss")}', '{newAppointment.EndTime.ToString("yyyy-MM-dd hh:mm:ss")}', '{newAppointment.CreateDate.ToString("yyyy-MM-dd hh:mm:ss")}', '{newAppointment.CreatedBy}', '{newAppointment.LastUpdate.ToString("yyyy-MM-dd hh:mm:ss")}', '{newAppointment.LastUpdatedBy}');";

                    MySqlCommand addAppointment = new MySqlCommand(ApptAddString, DBConnection.connect);
                    if (addAppointment.ExecuteNonQuery() == 0)
                    {
                        return false;
                        throw new Exception();
                    }
                    Console.WriteLine($"Added new appointment with {custName} on {newAppointment.StartTime.Date} @{newAppointment.StartTime.TimeOfDay}");
                }

                return true;
            }
            catch (Exception exc)
            {
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
                Console.WriteLine(Appt.ApptID);
                Appointment appointment = Appt;

                string start = $"start = '{appointment.StartTime.ToString("yyyy-MM-dd hh:mm:ss")}'";
                string end = $"end = '{appointment.EndTime.ToString("yyyy-MM-dd hh:mm:ss")}'";
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

        // ----- Constructor ----- //

        public Appointment( int custId, DateTime start, DateTime end, string apptType)
        {
            
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
            
            CreateDate = DateTime.Now;
            Console.WriteLine(CreateDate);

            CreatedBy = CurrentUser.UserName.Trim();
            LastUpdate = DateTime.Now;
            LastUpdatedBy = CurrentUser.UserName.Trim();
        }
        // ----- Static Class ----- //

        // Fits better in CurrentUser
        static Appointment()
        {

        }
    }
}
