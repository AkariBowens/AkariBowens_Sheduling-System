using Google.Protobuf.WellKnownTypes;
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
            
            
            return true;
        }
        // RemoveAppt()

        // ----- Constructor ----- //

        public Appointment()
        {
            // Get from constructor?
            ApptID = -1;
            CustID = -1;
            UserID = CurrentUser.CurrentUserID;

            Title = "";
            Description = "";
            Location = CurrentUser.UserLocation;

            // Get from user input
            Contact = "";
            ApptType = "";
            URL = "";

            // Get from constructor
            StartTime =  new DateTime(12, 0, 0);
            EndTime = new DateTime(1, 0, 0);
            
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
