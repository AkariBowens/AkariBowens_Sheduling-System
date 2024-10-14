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
        public string CustID { get; set; }
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }

        public string ApptType { get; set; }
        public string URL { get; set; }

        // Hard code all the properties below - except LastUpdate()
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateDate { get; set; }
        // Hard-code this
        public string CreatedBy { get; set; }
        // is TIMESTAMP() - numbers
        public Timestamp LastUpdate { get; set; }
        // Hard-code this
        public string LastUpdatedBy { get; set; }


        // ----- Properties ----- //
        // AddAppt()
        // RemoveAppt()

        // ----- Constructor ----- //


        // ----- Static Class ----- //

        // Fits better in CurrentUser
        static Appointment()
        {

        }
    }
}
