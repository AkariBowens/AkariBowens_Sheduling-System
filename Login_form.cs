using AkariBowens_Sheduling_System.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AkariBowens_Sheduling_System
{
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        // Gets client system language setting
        private readonly string clientRegion = CultureInfo.CurrentCulture.Name;
        public static string userName { get; set; }
        public static string userPass { get; set; }
        public static int userID { get; set; }

        private void login_form_Load(object sender, EventArgs e)
        {
            // German - Luxembourg
            // "de-Lu"

            if (clientRegion == "de-LU")
            {
                // Changes text on form to Deutsch(German)
                login_label.Text = "Anmelden";
                username_label.Text = "Nutzername";
                password_label.Text = "Passwort";

                // Error messages for validations as well
            }


            login_button.Enabled = false;
        }


        private void LoginButton()
        {
            if (textBoxesAreValid())
            {
                login_button.Enabled = true;
            }
        }
        private bool textBoxesAreValid()
        {
            return ((!string.IsNullOrWhiteSpace(username_textBox.Text)) && (!string.IsNullOrWhiteSpace(password_textBox.Text)));
        }


        // make this async
        public static bool GetUserAndPass()
        {
            // Redo exception-handling - needs to fail if password is incorrect
            try
            {
                //string DBUser;
                string DBPass;

                using (DBConnection.connect)
                {
                    // if this fails because no user, raise exception 
                    string searchString = $"SELECT userId, userName, password FROM user WHERE userName = '{userName}';";
                    MySqlCommand testPass = new MySqlCommand(searchString, DBConnection.connect);
                    DBConnection.OpenConnection();
                    using (MySqlDataReader dataReader = testPass.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            // returns password and id of user Where userName == username_textBox.Text
                            while (dataReader.Read())
                            {
                                
                                //DBUser = Convert.ToString(dataReader["userName"]);
                                //Console.WriteLine(DBUser + " user");
                                
                                DBPass = Convert.ToString(dataReader["password"]);
                                Console.WriteLine(DBPass + " pass");
                                
                                userID = Convert.ToInt32(dataReader["userId"]);
                                Console.WriteLine(userID + " user ID");

                                
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows to read");
                            
                            // Use the lower one
                            Console.WriteLine("User not found");
                            return false;
                        }
                    }
                }
                return true;
            } catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (GetUserAndPass())
            {
                // Calls constructor updating the static CurrentUser class and logs adds the new login to the log
                CurrentUser user = new CurrentUser(userID, userName, userPass, clientRegion);
                CurrentUserViewForm CurrentUserView = new CurrentUserViewForm();
                CurrentUserView.Show();
            }
        }

        private void username_textBox_TextChanged(object sender, EventArgs e)
        {
            // Exception - Username not found
            // Exception - If username or Password is incorrect
    
            if (string.IsNullOrWhiteSpace(username_textBox.Text))
            {  
                
                MessageBox.Show(" -- UsrnmExc");
                username_textBox.BackColor = Color.Tomato;
            } else
            {
                userName = username_textBox.Text;
                LoginButton();
            }
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(password_textBox.Text))
            {
                MessageBox.Show(" -- PsswdExc");
                username_textBox.BackColor = Color.Tomato;
            }
            else
            {
                userPass = username_textBox.Text;
                LoginButton();
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //private void login_label_Click(object sender, EventArgs e)
        //{

        //}
    }
}
