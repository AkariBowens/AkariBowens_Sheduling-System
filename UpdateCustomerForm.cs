using AkariBowens_Sheduling_System.Classes;
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
    public partial class UpdateCustomerForm : Form
    {
        public UpdateCustomerForm()
        {
            InitializeComponent();
        }

        private string UpdateCustomerName;
        private string UpdateCustomerPhone;
        private string UpdateCustomerAddress;

        

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Customer.SelectedCustomer = null;
            Address.SelectedAddress = null;
            CurrentUserViewForm currentUserViewForm = new CurrentUserViewForm();
            currentUserViewForm.Show();
            Close();
        }

        

        private void UpdateCustomerForm_Load(object sender, EventArgs e)
        {
            save_button.Enabled = false;

            name_textBox.Text = Customer.SelectedCustomer.CustomerName;
            phone_textBox.Text = Address.SelectedAddress.Phone;
            address_textBox.Text = Address.SelectedAddress.AddressName;
        }


        private bool ValidTextBoxes()
        {
            return ( !string.IsNullOrWhiteSpace(name_textBox.Text) && !string.IsNullOrWhiteSpace( phone_textBox.Text) && !string.IsNullOrWhiteSpace(name_textBox.Text));
        }

        private void ToggleSave()
        {
            if (ValidTextBoxes())
            {
                save_button.Enabled = true;
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            try
            {

                //Address
                //Address.AddAddress();

                Customer newCust = new Customer(Customer.SelectedCustomer.CustomerID, UpdateCustomerName, Customer.SelectedCustomer.AddressID);
                Address newAddr = new Address(Address.SelectedAddress.AddressID, UpdateCustomerAddress, UpdateCustomerPhone);
                // only run updates based-on changed boxes

                if (UpdateCustomerAddress != Address.SelectedAddress.AddressName || UpdateCustomerPhone != Address.SelectedAddress.Phone)
                {
                    if (newAddr != null && Address.SelectedAddress != null)
                    {
                        if (!Address.UpdateAddress(newAddr))
                        {
                            throw new Exception("Error in address");
                        }
                    }
                }

                if (UpdateCustomerName != Customer.SelectedCustomer.CustomerName )
                {
                    if (newCust != null && Customer.SelectedCustomer != null) 
                    {
                        if (!Customer.UpdateCustomer(newCust))
                        {
                            Console.WriteLine("Update failed");
                            throw new Exception("Could not update Customer!");
                        }
                    }

                }

                Console.WriteLine("Update customer successful.");

                Customer.SelectedCustomer = null;
                Address.SelectedAddress = null;
                CurrentUserViewForm currentUserViewForm = new CurrentUserViewForm();
                currentUserViewForm.Show();
                Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                MessageBox.Show("Could not update customer!");

            }
        }
        private void name_textBox_TextChanged(object sender, EventArgs e)
        {
            if (name_textBox.Text != Customer.SelectedCustomer.CustomerName)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(name_textBox.Text))
                    {
                        UpdateCustomerName = name_textBox.Text.Trim();
                        ToggleSave();
                    }
                    else
                    {
                        throw new ArgumentException("Name cannot be empty!");
                    }
                }
                catch (Exception ArgumentException)
                {
                    if (name_textBox.Text != "")
                    {
                        MessageBox.Show(ArgumentException.Message.ToString());
                    }

                    name_textBox.BackColor = Color.Tomato;
                    name_textBox.Clear();
                }
            }
        }

        private void phone_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (phone_textBox.Text != Address.SelectedAddress.Phone)
                {
                    if (string.IsNullOrWhiteSpace(phone_textBox.Text))
                    {
                        throw new ArgumentException("Phone number cannot be empty!");
                    }

                    // test if it only contains dashes or dashes
                    foreach (char item in phone_textBox.Text)
                    {
                        if ((item >= '0' && item <= '9') || item == (char)45)
                        {
                            continue;
                        }
                        else
                        {
                            throw new ArgumentException("Phone can only contain numbers or hypens!");
                        }
                    }
                    UpdateCustomerPhone = phone_textBox.Text.Trim();
                    ToggleSave();

                }
            }
            catch (Exception ArgumentException)
            {
                if (phone_textBox.Text != "")
                {
                    MessageBox.Show(ArgumentException.Message.ToString());
                }

                phone_textBox.BackColor = Color.Tomato;
                phone_textBox.Clear();
            }
            
        }

        private void address_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (address_textBox.Text != Address.SelectedAddress.AddressName)
                {
                    if (string.IsNullOrWhiteSpace(address_textBox.Text))
                    {
                        throw new ArgumentException("Address cannot be empty!");
                    }
                    //Runs only after formatting
                    UpdateCustomerAddress = address_textBox.Text.Trim();
                    ToggleSave();

                }
            }

            catch (Exception ArgumentException)
            {
                if (address_textBox.Text != "")
                {
                    MessageBox.Show(ArgumentException.Message.ToString());
                }

                address_textBox.BackColor = Color.Tomato;
                address_textBox.Clear();
            }
        }
    }
}
