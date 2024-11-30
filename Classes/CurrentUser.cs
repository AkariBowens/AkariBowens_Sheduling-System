using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public static int CurrentUserID { get; set; }
        public static string UserName { get; set; }
        private static string Password { get; set; }
        public static string UserLocation { get; set; }

        //"Login_History.txt"
        private static string LogFilePath { get; set; } = "C:\\Users\\LabUser\\source\\repos\\AkariBowens_Sheduling-System\\Files\\Login_History.txt";

        // ----- File Properties ----- //
        private static FileStream fileWriter;
        private static FileStream fileReader;

        public static Appointment NextAppointment;

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


        private static void FifteenMinAlert()
        {

            var query = from Appt in Appointments where Appt.StartTime > DateTime.Now select Appt;
            //NextAppointment =

            foreach (var Appt in query.AsEnumerable())
            {
                
                if (Appt.StartTime > DateTime.Now)
                {
                    //if (appt.StartTime.Year == DateTime.Now.Year && appt.StartTime.Month == DateTime.Now.Month && appt.StartTime.Day == DateTime.Now.Day) { 
                    NextAppointment = new Appointment(Appt.ApptID, Appt.CustID, Appt.StartTime, Appt.EndTime, Appt.ApptType);

                    // Console.WriteLine($"Next appointment: {NextAppointment.StartTime.Date.ToString("MM-dd-yyyy")}");
                    
                    if (NextAppointment.StartTime.Date == DateTime.Now.Date) {
                        TimeSpan TimeToNextAppointment = NextAppointment.StartTime - DateTime.Now;
                        Console.WriteLine($"Minutes until next appointment {TimeToNextAppointment.TotalMinutes}");
                        if (TimeToNextAppointment.TotalMinutes <= 15)
                        {
                            
                            // Change custID to customerName
                            // Fix minutes to single digit, rounded down
                            MessageBox.Show($"You have an appointment with {NextAppointment.CustID} in {TimeToNextAppointment.TotalMinutes} @{Appt.StartTime.TimeOfDay}!");
                            return;
                        }
                    }
                }
            }

            
        }

        // ----- Constructor ----- //
        public CurrentUser(int currentID, string username, string pass, string location)
        {
            CurrentUserID = currentID;
            UserName = username;
            Password = pass;
            UserLocation = location;
            LogLastLogin();
            FifteenMinAlert();
            Console.WriteLine($"CurrentUser - {CurrentUserID}");
        }

    }
}
