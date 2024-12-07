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

        private bool ValidTextBoxes()
        {
            return ((!string.IsNullOrWhiteSpace(name_textBox.Text) && name_textBox.Text != Customer.SelectedCustomer.CustomerName) && (!string.IsNullOrWhiteSpace(phone_textBox.Text) && phone_textBox.Text != Address.SelectedAddress.Phone) && (!string.IsNullOrWhiteSpace(address_textBox.Text) && name_textBox.Text != Address.SelectedAddress.AddressName));
        }

        private void ToggleSave()
        {
            if (ValidTextBoxes())
            {
                save_button.Enabled = true;
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Customer.SelectedCustomer = null;
            Close();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Save button. {UpdateCustomerName} {UpdateCustomerPhone} {UpdateCustomerAddress}");

            //Address
            //Address.AddAddress();

            //Customer newCust = new Customer(-1, UpdateCustomerName);
            //if (Customer.UpdateCustomer()
            //{

            //}
            Customer.SelectedCustomer = null;
        }

        private void UpdateCustomerForm_Load(object sender, EventArgs e)
        {
            save_button.Enabled = false;
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
    }
}
