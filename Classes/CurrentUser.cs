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

        // ----- Methods ----- //

        private static void LogLastLogin()
        {

            DateTime currentTime = DateTime.Now;

            string logString = $"Logged in {UserName} @{currentTime} in {UserLocation}\n ";
            
            //string data;

            fileWriter = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write);

            // Encodes logString 
            byte[] buffer = Encoding.UTF8.GetBytes(logString);
            
            fileWriter.Write(buffer, 0, buffer.Length);

            fileWriter.Close();

            // -- Reads back recent data that was written to the file -- //
            
            //fileReader = new FileStream(LogFilePath, FileMode.Open);
            //using (StreamReader reader = new StreamReader(fileReader))
            //{
            //    data = reader.ReadLine();
            //}

            Console.WriteLine(logString);

        }



        // ----- Constructor ----- //
        public CurrentUser(int currentID, string username, string pass, string location)
        {
            CurrentUserID = currentID;
            UserName = username;
            Password = pass;
            UserLocation = location;
            
            LogLastLogin();
            Console.WriteLine($"CurrentUser - {CurrentUserID}");
        }

    }
}
