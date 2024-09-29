using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.CRUD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System.DB
{
    // Holds info from logged in user
    internal class CurrentUser
    {
        // ----- Properties ----- //
        static int CurrentUserID { get; set; }
        static string UserName { get; set; }
        private static string Password { get; set; }
        static string UserLocation { get; set; }

        //"Login_History.txt"
        private static string LogFilePath { get; set; } = "C:\\Users\\LabUser\\source\\repos\\AkariBowens_Sheduling-System\\Files\\Login_History.txt";

        // ----- File Properties ----- //
        private static FileStream fileWriter; 
        private static FileStream fileReader;

        // ----- Methods ----- //

        // Logs every time a new user is logged in - called in constructor - static?
        private static void LogLastLogin()
        {

            DateTime currentTime = DateTime.Now;
            
            string logString = $"Logged in {UserName} @{currentTime} in {UserLocation}\n ";
            //Console.WriteLine(logString + " -- Console.Write");

            string data;
         
            fileWriter = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write);
            
            // Encodes logString 
            byte[] buffer = Encoding.UTF8.GetBytes(logString);
            fileWriter.Write(buffer, 0, buffer.Length);

            fileWriter.Close();

            // -- Reads back recent data that was written to the file -- //
            fileReader = new FileStream(LogFilePath, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileReader))
            {
                // make this read the very last line of the file
                data = reader.ReadLine();
            }
            Console.WriteLine(data + " -- from fileStream");
            //Console.ReadKey();

        }

        public static void LogInUser(CurrentUser user)
        {
            // 
        }

        // Login method? - CurrentUser.Login() - called in constructor(sets * static currentUser class)

        // Maybe put appointments here instead

        // This only needs to be here because I am only grabbing appointmetns for this user
        // public GrabAppointments() - $"Select * FROM appointments WHERE userId = {CurrentUserID}"


        // ----- Constructor ----- //
        public CurrentUser(int currentID, string username, string pass, string location)
        {
            CurrentUserID = currentID;
            UserName = username;
            Password = pass;
            UserLocation = location;
            LogLastLogin();
            Console.WriteLine($"CurrentUser - {CurrentUser.CurrentUserID}");

            // update {userId.lastUpdate}
        }

        // ----- Static Class ----- //
        static CurrentUser()
        {
            // Call LogLastLogin - NOW() at the time this class is instantiated, pass it back to db? and logfile
        }

    }
}
