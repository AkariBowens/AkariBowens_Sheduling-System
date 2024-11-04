using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static bool AddAppointment(Appointment appt)
        {
            Appointment newAppointment = appt;

            // Appointmetn ID is auto_inc
            string ApptAddString = $"INSERT INTO appointment(customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdby, lastUpdate, lastUpdateBy) VALUES({newAppointment.CustID}, {newAppointment.UserID}, {newAppointment.Title}, {newAppointment.Description}, {newAppointment.Location}, {newAppointment.Contact}, {newAppointment.ApptType}, {newAppointment.URL}, {newAppointment.StartTime.ToString("yyyy-mm-dd")}, {newAppointment.EndTime.ToString("yyyy-mm-dd")}, {newAppointment.CreateDate}, {newAppointment.CreatedBy}, {newAppointment.LastUpdate}, {newAppointment.LastUpdatedBy});";

            
            MySqlCommand addAppointment = new MySqlCommand(ApptAddString, DBConnection.connect);
            DBConnection.OpenConnection();

            if (addAppointment.ExecuteNonQuery() == 0)
            {
                return false;
            }
            
            
            return true;
        }
        // RemoveAppt()

        // ----- Constructor ----- //

        public Appointment( int custId, DateTime start, DateTime end, string apptType)
        {
            
            // Get ID from selected Customer via customer object
            CustID = custId;
            UserID = CurrentUser.CurrentUserID;

            Title = "not needed";
            Description = "not needed";
            Location = "not needed";

            // Get from user input
            Contact = "not needed";
            ApptType = apptType;
            URL = "not needed";

            // Get from constructor
            StartTime =  start;
            EndTime = end;
            
            CreateDate = DateTime.Now;
            Console.WriteLine(CreateDate);

            CreatedBy = "Admin";
            LastUpdate = DateTime.Now;
            LastUpdatedBy = "Admin";
        }
        // ----- Static Class ----- //

        // Fits better in CurrentUser
        static Appointment()
        {

        }
    }
}
