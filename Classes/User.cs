using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System.DB
{
    internal class User
    {
        // ----- Properties ----- //
        
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int Active { get; set; }
        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdate { get; set; }
   
        public string LastUpdatedBy { get; set; }

        public static User SelectedUser { get; set;}

        // ----- Methods ----- //

        //public static void addUser() { 
        // sql string = "INSERT INTO.."
        // set createdate
        // set createby
        //}

        //public static void removeUser() { 
            // sql string = "Remove where ID =.."
        //}

        public static DataTable GetUsers()
        {
            DataTable returnTable = new DataTable();

            string getUsers = $"SELECT userId, userName FROM user;";
            
            DBConnection.OpenConnection();

            using (DBConnection.connect)
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(getUsers, DBConnection.connect);

                mySqlDataAdapter.Fill(returnTable);
            }

            return returnTable;
        }

        public static DataTable GetUserSchedule(int userId)
        {
            DataTable queryresult = new DataTable();
            DataTable UserScheduleDataTable = new DataTable();

            string userScheduleString = $"SELECT customer.customerId, customerName, appointmentId, start, start, end, type FROM appointment INNER JOIN Customer ON appointment.customerId = customer.customerId WHERE appointment.userId = {userId};";

            DBConnection.OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(userScheduleString, DBConnection.connect);

            using (DBConnection.connect)
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(userScheduleString, DBConnection.connect);

                mySqlDataAdapter.Fill(queryresult);
            }

            //Processes data from AppointmentTable 
            var query =
                    from row in queryresult.AsEnumerable()
                    select new
                    {
                        
                        CustID = row.Field<int>("customerId"),
                        CustomerName = row.Field<string>("customerName"),
                        ApptID = row.Field<int>("appointmentId"),
                        Date = row.Field<DateTime>("start"),
                        StartTime = row.Field<DateTime>("start"),
                        EndTime = row.Field<DateTime>("end"),
                        ApptType = row.Field<string>("type")
                    };

            Console.WriteLine(query.Count());

            UserScheduleDataTable = queryresult.Clone();
            foreach (var item in query)
            {

                UserScheduleDataTable.Rows.Add(item.CustID, item.CustomerName, item.ApptID, item.Date.ToString("MM-dd-yyyy"), TimeZoneInfo.ConvertTimeFromUtc(item.StartTime, TimeZoneInfo.Local), TimeZoneInfo.ConvertTimeFromUtc(item.EndTime, TimeZoneInfo.Local), item.ApptType);
            }

            return UserScheduleDataTable;

        }

        // ----- Constructor ----- //
        public User(int userId, string username)
        {
            UserID = userId;
            UserName = username;

            Active = 1;

            CreateDate = DateTime.Now;
            CreatedBy = "Admin";
            LastUpdate = DateTime.Now;
            LastUpdatedBy = "Admin";
        }
    }
}
