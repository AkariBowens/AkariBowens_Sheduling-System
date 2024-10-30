using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkariBowens_Sheduling_System.Classes
{
    internal class Country
    {
        // ----- Properties ----- //
        public string CountryId { get; set; }
        public string CountryName { get; set; }

        public DateTime CreateDate { get; set; }
        public static string dateFormat = @"yyyy-MM-dd hh:mm:ss";
        // Hard-code this
        public string CreatedBy { get; set; }
        // is TIMESTAMP() - numbers

        public DateTime LastUpdate { get; set; }
        // Hard-code this
        public string LastUpdatedBy { get; set; }

        // ----- Methods ----- //
        public static void AddCountry() { }
        public static void FindCountry() { }

        // ----- Constructor ----- //
        //public 
    }
}
