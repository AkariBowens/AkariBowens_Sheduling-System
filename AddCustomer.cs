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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private string AddCustomerName;
        private string AddCustomerAddress;
        private string AddCustomerPhone;


        public bool isNewCustomer = true;
        //private string ExceptionMessage;
        private bool ValidTextBoxes()
        {
            return (!string.IsNullOrWhiteSpace(name_textBox.Text) && !string.IsNullOrWhiteSpace(phone_textBox.Text) && !string.IsNullOrWhiteSpace(address_textBox.Text));
        }

        private void ToggleSave()
        {
            if (ValidTextBoxes())
            {
                save_button.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(phone_textBox.Text))
                {
                    AddCustomerPhone = phone_textBox.Text;
                    ToggleSave();
                }
                else
                {
                    throw new ArgumentException("tb1");
                }
            }
            catch (Exception ArgumentException)
            {
                if (phone_textBox.Text == "")
                {
                    MessageBox.Show(ArgumentException.Message.ToString());
                }

                phone_textBox.BackColor = Color.Tomato;
                phone_textBox.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if (!string.IsNullOrWhiteSpace(name_textBox.Text)) 
                {
                    AddCustomerName = name_textBox.Text;
                    ToggleSave();
                } else
                {
                    
                    throw new ArgumentException("tb2");
                }
            } 
            catch (Exception ArgumentException)
            {
                if (name_textBox.Text == "")
                {
                    MessageBox.Show(ArgumentException.Message.ToString());
                }

                name_textBox.BackColor = Color.Tomato;
                name_textBox.Clear();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(address_textBox.Text))
                {
                    AddCustomerAddress = address_textBox.Text;
                    ToggleSave();
                }
                else
                {

                    throw new ArgumentException("tb3");
                }
            }
            catch (Exception ArgumentException)
            {
                if (address_textBox.Text == "")
                {
                    MessageBox.Show(ArgumentException.Message.ToString());
                }

                address_textBox.BackColor = Color.Tomato;
                address_textBox.Clear();
            }
        }

        private void address_label_Click(object sender, EventArgs e)
        {

        }

        private void phone_label_Click(object sender, EventArgs e)
        {

        }

        private void name_label_Click(object sender, EventArgs e)
        {

        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            
            if (!isNewCustomer)
            {
                //  load with modify/update label and prefilled date from list w/ all customers related to {CurrentUser.UserId}

                // -- Changes title -- //
                variable_text_label.Text = "Update";

                // -- Prefills textboxes -- //
                name_textBox.Text = Customer.SelectedCustomer.CustomerName;
                address_textBox.Text = Customer.SelectedCustomer.AddressID;
                phone_textBox.Text = Customer.SelectedCustomer.Contact.ToString();
            }

            // Changes after input detected in all 3 fields
            save_button.Enabled = false;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            
            // Customer NewCustomer = new Customer(AddCustomerName, AddCustomerAddress, AddCustomerPhone);
            if (Customer.AddCustomer(new Customer(AddCustomerName, AddCustomerAddress, AddCustomerPhone)))
            {
                Console.WriteLine("Save successful");
                Close();
            } else
            {
                Console.WriteLine("Save unsuccessful. Try again");
                MessageBox.Show("Save unsuccessful. Try again.");
            }
        }
    }
}
