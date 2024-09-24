using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkariBowens_Sheduling_System.DB
{
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string AddressID { get; set; }

        // Cast as bool
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        // Hard-code this
        public string CreatedBy { get; set; }
        // is TIMESTAMP() - numbers
        public Timestamp LastUpdate { get; set; }
        // Hard-code this
        public string LastUpdatedBy { get; set; }

    }
}
