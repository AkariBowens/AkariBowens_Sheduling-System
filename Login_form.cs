using AkariBowens_Sheduling_System.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System
{
    public partial class login_form : Form
    {
        public login_form()
        {
            InitializeComponent();
        }

        private readonly string clientLanguage = CultureInfo.CurrentCulture.Name;

        private void login_form_Load(object sender, EventArgs e)
        {
            // Gets client system language setting
            //string clientLanguage = CultureInfo.CurrentCulture.Name;
            Console.WriteLine(clientLanguage);

            //German
            // "de-Lu"

            if (clientLanguage == "de-LU")
            {
                // Changes text on form to Deutsch(German)
                login_label.Text = "Anmelden";
                username_label.Text = "Nutzername";
                password_label.Text = "Passwort";

                // Error messages for validations as well
            }
            //else
            //{
            // Leaves it english otherwise
            //login_label.Text = "Login";
            //username_label.Text = "Username";
            //password_label.Text = "Password";
            //}
        }

        private bool isValid = ValidateUser();

        // Modify this
        public static bool ValidateUser()
        {
            //bool isTrue = connect.CancelQueryAsync(sql);
            string dBPass;
            //string inputUser;
            //string inputPass = password_textBox.Text;

            try
            {
                using (DBConnection.connect)
                {
                    string searchString = $"SELECT username, password FROM user WHERE UserName =... ';";
                    MySqlCommand testPass = new MySqlCommand(searchString, DBConnection.connect);
                    MySqlDataReader dataReader = testPass.ExecuteReader();

                    Console.WriteLine(dataReader);
                    dBPass = dataReader.ToString();
                    Console.WriteLine(dBPass);
                }
                return true;
                // If (text of usrnm & txt of pass are valid - change isValid to true

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Change this to run test if user is validated after running ValidateUser() - then open new form
            ValidateUser();

            if (isValid)
            {
                // login currentUser
                // -- this should update the static class
                // and log the login with the time it happened
                // then it should open a new form filled with the data from the currentUser
            }
        }

        private void username_textBox_TextChanged(object sender, EventArgs e)
        {
            // Exception - Username not found
            // Exception - If username or Password is incorrect
            try
            {
                // Change to (if usernametxt in DB, then trigger a function that tests whether U&P bot fit criteria)
                if (!string.IsNullOrWhiteSpace(username_textBox.Text) && username_textBox.Text == "test")
                {
                    //compares username to one in db
                    //testUsernameInDB(username_textBox.Text) - returns true or false
                    //field is false
                    // run ValidateUser()
                }
            } catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                username_textBox.BackColor = Color.Tomato;
            }
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Change to (if usernametxt in DB, then trigger a function that tests whether U&P bot fit criteria)
                if (!string.IsNullOrWhiteSpace(password_textBox.Text) && username_textBox.Text == "test")
                {
                    //compares username to one in db
                    //testUsernameInDB(username_textBox.Text) - returns true or false
                    //field is false
                    // run ValidateUser()
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                username_textBox.BackColor = Color.Tomato;

            }
        }


        //private void login_label_Click(object sender, EventArgs e)
        //{

        //}
    }
}
