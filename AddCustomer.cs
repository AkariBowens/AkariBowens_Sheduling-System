using AkariBowens_Sheduling_System.Classes;
using AkariBowens_Sheduling_System.DB;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
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
                    }else
                    {
                        throw new ArgumentException("Phone can only contain numbers or hypens!");
                    }

                }
                AddCustomerPhone = phone_textBox.Text.Trim();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if (!string.IsNullOrWhiteSpace(name_textBox.Text)) 
                {
                    AddCustomerName = name_textBox.Text.Trim();
                    ToggleSave();
                } else
                {
                    
                    throw new ArgumentException("tb2");
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(address_textBox.Text))
                {

                    //Runs only after formatting
                    AddCustomerAddress = address_textBox.Text.Trim();
                    ToggleSave();
                }
                else
                {

                    throw new ArgumentException("Address cannot be empty!");
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
            // Changes after input detected in all 3 fields
            save_button.Enabled = false;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Save button. {AddCustomerName} {AddCustomerPhone} {AddCustomerAddress}");

            // Address.GetAddressIDByPhoneAndAddressName(string phone, string addressname);
            // - returns int
            // -- put this^ in customer declaration

            // add address, get id 
            Address NewAddress = new Address(-1, AddCustomerAddress, AddCustomerPhone);
            if (!Address.AddAddress(NewAddress))
            {
                Console.WriteLine("Adding Adress Failed");
            }



            Console.WriteLine($" Address: {NewAddress.AddressName}; Phone: {NewAddress.Phone}; --AddCustomer..174");
             
            int addressId = Address.FindAddressId(NewAddress.AddressName, NewAddress.Phone);

            NewAddress.AddressID = addressId;
            // add AddressID as NewAddress.AddressID
            Console.WriteLine(addressId + " --Address ID...180");
            
            Customer NewCustomer = new Customer(-1, AddCustomerName, addressId);

            if (Customer.AddCustomer(NewCustomer, NewAddress))
            {
                Console.WriteLine($"Added new customer: {NewCustomer.CustomerName}");
                Close();
            }

            //if (Customer.AddCustomer(new Customer(AddCustomerName, AddCustomerAddress), new Address(AddCustomerAddress
            //    , AddCustomerPhone)))
            //{
            //    Console.WriteLine("Save successful");

            //    Close();
            //}
            //else
            //{
            //    Console.WriteLine("Save unsuccessful. Try again");
            //    MessageBox.Show("Save unsuccessful. Try again.");
            //}
        }

        
    }
}
