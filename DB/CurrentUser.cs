using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkariBowens_Sheduling_System.DB
{
    internal class CurrentUser
    {
        // Maybe this is just one single user class, since only one can be logged in anyway
        // Holds UserID from logged in user
        // I need a way to initiate a single user that exists for every form
        // Just a user class won't do it, even if I log in using certain details because where is it stored

        // ----- Properties ----- //
        public int CurrentUserID { get; set; }
        // appointments?
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string UserLocation { get; set; }
        public static string LogFileName { get; set; } = "Login_History.txt";

        // ----- Methods ----- //
        // LogLastUpdate() - maybe accept login will be on the user class, with a login() method
        // - FileName.append(time, UserName)
        // ValidateLogin()


        // ----- Static Class ----- //
        static CurrentUser()
        {
            // Call logLastUpdate - NOW() at the time this class is instantiated, pass it back to db? and logfile
        }

        // Have a static "AddUser"?

    }
}
