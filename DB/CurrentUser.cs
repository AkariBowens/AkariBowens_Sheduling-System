using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkariBowens_Sheduling_System.DB
{
    // Holds info from logged in user
    internal class CurrentUser
    {
        // ----- Properties ----- //
        public int CurrentUserID { get; set; }
        // appointments?
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserLocation { get; set; }
        public static string LogFileName { get; set; } = "Login_History.txt";

        // ----- Methods ----- //
        
        // Logs every time a new user is logged in - called in constructor - static?
        private void LogLastLogin()
        {
            // FileStream file = new FileStream();
            // Serialize
            // - FileName.append(time, UserName)
            // For now
            Console.WriteLine("Username - 15:00 UTC");
        }
        
        // Login method? - CurrentUser.Login() - called in constructor(sets * static currentUser class)

        // Maybe put appointments here instead

        // This only needs to be here because I am only grabbing appointmetns for this user
        // public GrabAppointments() - $"Select * FROM appointments WHERE userId = {CurrentUserID}"
        
        
        // ----- Constructor ----- //
        public CurrentUser(int currentID, string username, string pass, string location)
        {
            CurrentUserID = currentID;
            // If this were a secure thing, UserName.encrypt() = username.decrypt() -- or something like this
            UserName = username;
            Password = pass;
            UserLocation = location;
            LogLastLogin();

            // Call Login() every time this is set?
        }

        // ----- Static Class ----- //
        static CurrentUser()
        {
            // Call LogLastLogin - NOW() at the time this class is instantiated, pass it back to db? and logfile
        }

        // Have a static "AddUser"?

    }
}
