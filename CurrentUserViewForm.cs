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
                    

                }
               
            }
            catch (Exception ArgumentNullException)
            {
                Console.WriteLine(ArgumentNullException.Message.ToString());
                MessageBox.Show("Select a customer.", "Delete customer.");
            }
            finally
            {
                CustomerDGV.DataSource = Customer.GetCustomers();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(CustomerDGV.CurrentRow == null || !CustomerDGV.CurrentRow.Selected)
            { 
                MessageBox.Show("Please select a customer to update!");
            }

            Customer.SelectedCustomer = new Customer((int)CustomerDGV.CurrentRow.Cells["customerId"].Value, CustomerDGV.CurrentRow.Cells["customerName"].Value.ToString(), (int)CustomerDGV.CurrentRow.Cells["addressId"].Value);

            Address.SelectedAddress = new Address((int)CustomerDGV.CurrentRow.Cells["addressId"].Value, CustomerDGV.CurrentRow.Cells["address"].Value.ToString(), CustomerDGV.CurrentRow.Cells["phone"].Value.ToString());
            // Copy AddCustomerForm, update with update labels
            //Address.SelectedAddress = new Address();
            UpdateCustomerForm updateCustomer = new UpdateCustomerForm();
            updateCustomer.Show();
            Close();

            CustomerDGV.DataSource = Customer.GetCustomers();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Opens a new add customer form 
            AddCustomer addCustomer = new AddCustomer();
            addCustomer.Show();
            Close();
            CustomerDGV.ResetBindings();

            CustomerDGV.DataSource = Customer.GetCustomers();
            
        }

        private void CustomerDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CustomerDGV.ClearSelection();
        }

        private void CurrentUserViewForm_Load(object sender, EventArgs e)
        {

            // ----- Customer DGV ----- //
            CustomerDGV.DataSource = Customer.GetCustomers();
            CustomerDGV.MultiSelect = false;
            CustomerDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomerDGV.ReadOnly = true;
            CustomerDGV.AllowUserToAddRows = false;

            // Change after I fix address
            // Hide customerId, addressId, cityId, countryId
            CustomerDGV.Columns["customerId"].Visible = false;
            CustomerDGV.Columns["addressId"].Visible = false;
            CustomerDGV.Columns["cityId"].Visible = false;
            CustomerDGV.Columns["countryId"].Visible = false;


            // ----- Appointment DGV ----- //
            AppointmentDGV.DataSource = Appointment.GetAppointments();
            AppointmentDGV.MultiSelect = false;
            AppointmentDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AppointmentDGV.ReadOnly = true;
            AppointmentDGV.AllowUserToAddRows = false;

            AppointmentDGV.Columns["userId"].Visible = false;


            //Console.WriteLine(Customer.GetCustomers().AsEnumerable().Where(cust => (int)cust[columnName: "customerId"] == 1);
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
            
            
            try
            {
                // Opens new Add Appointment Form
                if (!CustomerDGV.CurrentRow.Selected)
                {
                    throw new Exception("No customer selected!");
                }

                AddAppointmentForm addAppointment = new AddAppointmentForm();

                Customer.SelectedCustomer = new Customer((int)CustomerDGV.CurrentRow.Cells["customerId"].Value, CustomerDGV.CurrentRow.Cells["customerName"].Value.ToString(), (int)CustomerDGV.CurrentRow.Cells["addressId"].Value);

                addAppointment.Show();
                Close();
                //Customer.SelectedCustomer = null;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Select or add a new customer!");
                Console.WriteLine(exc.Message.ToString());
            }
        }

        private void appts_delete_button_Click(object sender, EventArgs e)
        {
            if (AppointmentDGV.CurrentRow.Selected)
            {
                DialogResult = MessageBox.Show("Delete appointment", "Are you sure you want to delete this?", MessageBoxButtons.YesNoCancel);

                if (DialogResult == DialogResult.Yes)
                {
                    Appointment.RemoveAppt(Convert.ToInt32(AppointmentDGV.CurrentRow.Cells["appointmentId"].Value));
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment!");
            }

            AppointmentDGV.DataSource = Appointment.GetAppointments();
        }

        private void appts_update_button_Click(object sender, EventArgs e)
        {
            
            if (AppointmentDGV.CurrentRow.Selected) 
            {

                UpdateAppointmentForm updateAppointmentForm = new UpdateAppointmentForm();
                Console.WriteLine((int)AppointmentDGV.CurrentRow.Cells["appointmentId"].Value + " -- appointmentID");

                DataTable appointments = Appointment.GetAppointments();

                Appointment.SelectedAppointment = new Appointment((int)AppointmentDGV.CurrentRow.Cells["appointmentId"].Value, (int)AppointmentDGV.CurrentRow.Cells["customerId"].Value, (DateTime)AppointmentDGV.CurrentRow.Cells["start"].Value, (DateTime)AppointmentDGV.CurrentRow.Cells["end"].Value, AppointmentDGV.CurrentRow.Cells["type"].Value.ToString());

                DataTable tempCustomerList = Customer.GetCustomers();
                DataTable tempAppointmentList = Appointment.GetAppointments();

                foreach (DataRow row in tempCustomerList.Rows)
                {
                    foreach (DataRow apptRow in tempAppointmentList.Rows)
                    {
                        if ((int)row["customerID"] == (int)apptRow["customerId"])
                        {
                            Console.WriteLine(row["customerName"].ToString() + " --custName");

                            Customer.SelectedCustomer = new Customer((int)row["customerId"], row["customerName"].ToString(), (int)row["addressId"]);
                        }
                    }
                }

                updateAppointmentForm.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Please select an appointment!");
            }

            // Resets source for Appointment DataGridView
            AppointmentDGV.DataSource = Appointment.GetAppointments();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Opens a new AppointmentsCalendar form
            AllAppointmentsCalendar allAppointmentsCalendar = new AllAppointmentsCalendar();
            allAppointmentsCalendar.Show();
        }

        private void reports_button_Click(object sender, EventArgs e)
        {
            ReportsForm reports = new ReportsForm();
            reports.Show();

            Close();
        }
    }
}
