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
    public partial class CurrentUserViewForm : Form
    {
        public CurrentUserViewForm()
        {
            InitializeComponent();
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            //Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Deletes Selected Customer
            try
            {
                //if row selected - MessageBox.Show("yes or no", select a customer);
                if (CustomerDGV.CurrentRow == null || !CustomerDGV.CurrentRow.Selected)
                {
                    //MessageBox.Show("Select a customer.", "Delete customer.");
                    throw new ArgumentNullException("No cutomer selected");
                }

               // Confirms delete selection
               DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to delete this?", "Delete Customer", MessageBoxButtons.YesNo);
               if (deleteConfirmation == DialogResult.Yes)
               {
                    //int selectedCustId = CustomerDGV.CurrentRow.Index;
                    int selectedCustId;
                    Int32.TryParse(Convert.ToString(CustomerDGV.CurrentRow.Cells[0].Value), out selectedCustId);

                    Console.WriteLine($"{selectedCustId} - selectedCustId");
                    if (!Customer.RemoveCustomer(selectedCustId))
                    {
                        throw new ArgumentException("Customer not found.");
                    }  
                        
                    CustomerDGV.ResetBindings();
                    CustomerDGV.DataSource = CurrentUser.GetCustomers();

                }
               
            }
            catch (Exception ArgumentNullException)
            {
                Console.WriteLine(ArgumentNullException.Message.ToString());
                MessageBox.Show("Select a customer.", "Delete customer.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Opens a new add customer form 
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
        }

        private void CustomerDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CustomerDGV.ClearSelection();
        }

        private void CurrentUserViewForm_Load(object sender, EventArgs e)
        {

            // ----- Customer DGV ----- //
            CustomerDGV.DataSource = CurrentUser.GetCustomers();
            CustomerDGV.MultiSelect = false;
            CustomerDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomerDGV.ReadOnly = true;
            CustomerDGV.AllowUserToAddRows = false;

            // ----- Appointment DGV ----- //
            AppointmentDGV.DataSource = CurrentUser.GetAppointments();
            AppointmentDGV.MultiSelect = false;
            AppointmentDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AppointmentDGV.ReadOnly = true;
            AppointmentDGV.AllowUserToAddRows = false;

        }

        private void AppointmentDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AppointmentDGV.ClearSelection();
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AppointmentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void appts_add_button_Click(object sender, EventArgs e)
        {
            // Opens new Add Appointment Form
            if (CustomerDGV.CurrentRow.Selected) {
                AddAppointmentForm addAppointment = new AddAppointmentForm();
                addAppointment.SelectedCustomer = CustomerDGV.CurrentRow.Cells["customerName"].Value.ToString(); 

                addAppointment.Show();
            }
            else {
                MessageBox.Show("Select or add a new customer!");
            }
        }
    }
}
