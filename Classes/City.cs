using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkariBowens_Sheduling_System.Classes
{
    internal class City
    {
        // ----- Properties ----- //
        public int CityId { get; set; }
        public int CityName { get; set; }
        public string CountryId { get; set; }

        public DateTime CreateDate { get; set; }
        public static string dateFormat = @"yyyy-MM-dd hh:mm:ss";

        public string CreatedBy { get; set; }


        public DateTime LastUpdate { get; set; }

        public string LastUpdatedBy { get; set; }

        // ----- Methods ----- //
        public static void AddCity() { }
        public static void FindCity() { }
    }
}
