using AkariBowens_Sheduling_System.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System
{
    public partial class AddAppointmentForm : Form
    {
        private string AddApptType;
        private DateTime AddApptStart;
        private DateTime AddApptEnd;
        private string AddCustomerName;
        private DateTime AddApptDate;

        // Might have to change to a Customer Object later
        public string SelectedCustomer;
        public AddAppointmentForm()
        {
            InitializeComponent();
        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {

            // Fill in later with data from DGV
            Customer_textBox.Text = SelectedCustomer;
            Customer_textBox.Enabled = false;

            save_button.Enabled = false;

            start_textBox.MaxLength = 4;
            end_textBox.MaxLength = 4;
        }

        private void ApptType_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ApptType_textBox.Text))
                {
                    throw new ArgumentException("Type field cannot be empty.");
                }

                AddApptType = ApptType_textBox.Text;

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                ApptType_textBox.BackColor = Color.Tomato;
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            SelectedCustomer = "";
            Close();
        }

        private void Customer_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void start_textBox_TextChanged(object sender, EventArgs e)
        {
            // An actual time
            // and between hours on 9&5
            // How do I do this for time?
            try
            {
                if (!string.IsNullOrWhiteSpace(start_textBox.Text))
                {
                    // This-v- && more than 3 chars?
                    if (!DateTime.TryParse(start_textBox.Text, out AddApptStart))
                    {
                        throw new Exception("Not a possible time");
                    }

                    // ToggleSaveButton();
                    Console.WriteLine("It works!");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }
        }
    }
}
