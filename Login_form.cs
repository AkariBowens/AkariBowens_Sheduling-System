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
using System.Security.Authentication;
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
        private static string userPass { get; set; }
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
                if (userPass == "")
                {
                     Console.WriteLine("Password empty!");
                     throw new AuthenticationException("Input a password!");
                }

                using (DBConnection.connect)
                {
                     
                    string searchString = $"SELECT userId, userName, password FROM user WHERE userName = '{userName}';";
                    MySqlCommand testPass = new MySqlCommand(searchString, DBConnection.connect);
                    DBConnection.OpenConnection();

                    using (MySqlDataReader dataReader = testPass.ExecuteReader())
                    {
                        // If this fails because no user found, raises exception
                        if (dataReader.HasRows)
                        {
                            // Returns password and id of user Where userName == username_textBox.Text
                            while (dataReader.Read())
                            {
                                //DBUser = Convert.ToString(dataReader["userName"]);
                                //Console.WriteLine(DBUser + " user");
                                
                                DBPass = Convert.ToString(dataReader["password"]);
                                //Console.WriteLine(DBPass + " pass");
                                if (userPass != DBPass)
                                {
                                    Console.WriteLine("Password incorrect!");
                                    throw new AuthenticationException("Password incorrect!");
                                }

                                userID = Convert.ToInt32(dataReader["userId"]);
                                Console.WriteLine("User ID: " + userID );
                            }
                        }
                        else
                        {
                            Console.WriteLine("User not found");
                            throw new AuthenticationException("Username Incorrect!");
                        }
                    }
                }
                return true;
            } catch (Exception AuthenticationException)
            {
                MessageBox.Show(AuthenticationException.Message.ToString());
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Password does not match and user not found
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
            try
            {
                if(!string.IsNullOrWhiteSpace(username_textBox.Text))
                {
                    userName = username_textBox.Text;
                    LoginButton();
                } else
                {
                    throw new ArgumentException("Username must not be empty!");
                }
            } catch (Exception ArgumentException)
            {
                if (username_textBox.Text != "")
                {
                    MessageBox.Show(ArgumentException.Message.ToString());
                }
                username_textBox.BackColor = Color.Tomato;
                username_textBox.Clear();
            }
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(password_textBox.Text))
                {
                    userPass = password_textBox.Text;
                    LoginButton();
                } else if (password_textBox.Text == "")
                {
                    throw new ArgumentException("Input a passsword!");
                } else
                {
                    throw new ArgumentException("Password must not be empty!");
                }
            } catch (Exception ArgumentException)
            {
                //if (password_textBox.Text != "")
                //{
                MessageBox.Show(ArgumentException.Message.ToString());
                //}
                password_textBox.BackColor = Color.Tomato;
                password_textBox.Clear();    
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
