using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System.DB
{
    public class DBConnection
    {
        // Makes connection
        public static MySqlConnection connect { get; set; }

        public static void OpenConnection()
        {
            try
            {
                // Gets connection string
                string connectionStr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                connect = new MySqlConnection(connectionStr);

                //Opens connection
                connect.Open();

                // ----- Change later ----- //
                MessageBox.Show("Connection is open");
            }
            catch (MySqlException ex)
            {
                // ----- Change to log later ----- //
                MessageBox.Show(ex.Message);
            }
        }

         public static void CloseConnection() {
            try
            {
                if (connect != null)
                {
                    connect.Close();
                }
                connect = null;
            }
            catch (MySqlException ex)
            {
                // ----- Change to log later ----- //
                MessageBox.Show(ex.Message);
            }
         }

        
    }   
}
