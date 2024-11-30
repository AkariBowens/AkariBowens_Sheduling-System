using AkariBowens_Sheduling_System.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System
{
    public partial class AppointmentsForm : Form
    {
        public static DateTime SelectedDate;
        //private static DataTable AllAppointments = CurrentUser.GetAppointments();
        private static DataTable ApptsByDay { get { return Appointment.GetAppointmentsByDate(SelectedDate); } set { Appointment.GetAppointmentsByDate(SelectedDate); } }
    
        public AppointmentsForm()
        {
            InitializeComponent();
        }

        private void AppointmentsForm1_Load(object sender, EventArgs e)
        {
            appointments_label.Text = appointments_label.Text + ": " + SelectedDate.DayOfWeek + " " + SelectedDate.ToString("MM-dd-yyyy");

            Console.WriteLine(SelectedDate.Date + " -- Selected Date");

            //appointments_DGV.DataSource = CurrentUser.GetAppointmentsByDate(SelectedDate);
            
            appointments_DGV.DataSource = ApptsByDay;
            appointments_DGV.MultiSelect = false;
            appointments_DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointments_DGV.ReadOnly = true;
            appointments_DGV.AllowUserToAddRows = false;

        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {

            if (appointments_DGV.CurrentRow.Selected)
            {
                DialogResult = MessageBox.Show("Delete appointment", "Are you sure you want to delete this?", MessageBoxButtons.YesNoCancel);

                if (DialogResult == DialogResult.Yes)
                {
                    Appointment.RemoveAppt(Convert.ToInt32(appointments_DGV.CurrentRow.Cells["appointmentId"].Value));
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment!");
            }

            // appointments_DGV.DataSource = CurrentUser.GetAppointmentsByDate(SelectedDate);
            // ApptsByDay.AcceptChanges();
            appointments_DGV.DataSource = ApptsByDay;
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            if (appointments_DGV.CurrentRow.Selected)
            {

                UpdateAppointmentForm updateAppointmentForm = new UpdateAppointmentForm();
                Console.WriteLine((int)appointments_DGV.CurrentRow.Cells["appointmentId"].Value + " -- appointmentID");

                //DataTable appointments = CurrentUser.GetAppointments();

                Appointment.SelectedAppointment = new Appointment((int)appointments_DGV.CurrentRow.Cells["appointmentId"].Value, (int)appointments_DGV.CurrentRow.Cells["customerId"].Value, (DateTime)appointments_DGV.CurrentRow.Cells["start"].Value, (DateTime)appointments_DGV.CurrentRow.Cells["end"].Value, appointments_DGV.CurrentRow.Cells["type"].Value.ToString());


                DataTable tempCustomerList = Customer.GetCustomers();
                DataTable tempAppointmentList = Appointment.GetAppointmentsByDate(SelectedDate);

                foreach (DataRow row in tempCustomerList.Rows)
                {
                    foreach (DataRow apptRow in tempAppointmentList.Rows)
                    {
                        if ((int)row["customerID"] == (int)apptRow["customerId"])
                        {
                            Console.WriteLine(row["customerName"].ToString() + " --custName");

                            // Going to have to change after Constructor update
                            Customer.SelectedCustomer = new Customer((int)row["customerID"], row["customerName"].ToString(), (int)row["addressId"]);
                        }
                    }
                }

                updateAppointmentForm.Show();

            }
            else
            {
                MessageBox.Show("Please select an appointment!");
            }

            // Resets bindings for Appointment DataGridView
            appointments_DGV.DataSource = Appointment.GetAppointments();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {

            DialogResult = MessageBox.Show( "Are you sure? \n This returns you to the Home Screen", "Adding an appointment", MessageBoxButtons.YesNoCancel);

            if (DialogResult == DialogResult.Yes)
            {
                Close();
                AllAppointmentsCalendar.ActiveForm.Close();
                MessageBox.Show("Please select a customer", "Adding an appointment");
            }
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
