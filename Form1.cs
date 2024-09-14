using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gets connection string
            string connectionStr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

            // Makes connection
            MySqlConnection connect = null;

            try
            {
                connect = new MySqlConnection(connectionStr);

                //Opens connection
                connect.Open();

                // ----- Change later ----- //
                MessageBox.Show("Connection is open");
            } catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }
    }
}
