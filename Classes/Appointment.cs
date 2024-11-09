using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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


        // ----- Properties ----- //
        public static bool AddAppointment(Appointment appt, string customerName)
        {
            try
            {

                Appointment newAppointment = appt;
                string custName = customerName;
                // Appointment ID is auto_inc
               
                Console.WriteLine(custName + " -- in AppAppointment()");
                // need to work with foreign keys and their constraints
                int? customerID;
                
                if (newAppointment != null) 
                { 
                    DBConnection.OpenConnection();

                    string CustomerIDString = $"SELECT customerId FROM customer WHERE customerName = '{custName}';";

                    MySqlCommand findCustomerID = new MySqlCommand(CustomerIDString, DBConnection.connect);

                    customerID = Convert.ToInt32(findCustomerID.ExecuteScalar());

                    string ApptAddString = $"INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdby, lastUpdate, lastUpdateBy) VALUES( {customerID}, {newAppointment.UserID}, '{newAppointment.Title}', '{newAppointment.Description}', '{newAppointment.Location}', '{newAppointment.Contact}', '{newAppointment.ApptType}', '{newAppointment.URL}', '{newAppointment.StartTime.ToString("yyyy-MM-dd")}', '{newAppointment.EndTime.ToString("yyyy-MM-dd")}', '{newAppointment.CreateDate.ToString("yyyy-MM-dd")}', '{newAppointment.CreatedBy}', '{newAppointment.LastUpdate.ToString("yyyy-MM-dd")}', '{newAppointment.LastUpdatedBy}');";

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
            string deleteString = "DELETE FROM customer WHERE appointmentId = {ApptId}";

            MySqlCommand deleteAppt = new MySqlCommand(deleteString, DBConnection.connect);

            if (deleteAppt.ExecuteNonQuery() == 0)
            {
                return false;
                throw new Exception();
            }
            Console.WriteLine($"Removed appointment with ID {ApptId}");
            return true;

        }
        // UpdateAppt()

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
