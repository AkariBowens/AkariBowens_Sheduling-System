using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkariBowens_Sheduling_System.DB
{
    internal class User
    {
        // ----- Properties ----- //
        //BindingList<Appointment> appointments = new BindingList<Appointment>;

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        // Cast as bool
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        // Hard-code this
        public string CreatedBy { get; set; }
        // is TIMESTAMP() - numbers
        public Timestamp LastUpdate { get; set; }
        // Hard-code this
        public string LastUpdatedBy { get; set; }

        // ----- Methods ----- //
        public static void addUser() { 
        // sql string = "INSERT INTO.."
        // set createdate
        // set createby
        }
        public static void removeUser() { 
        // sql string = "Remove where ID =.."
        }

        // ----- Constructor ----- //
    }
}
