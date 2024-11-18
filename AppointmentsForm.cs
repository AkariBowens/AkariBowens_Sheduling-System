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
        private static DataTable ApptsByDay { get { return CurrentUser.GetAppointmentsByDate(SelectedDate); } set { CurrentUser.GetAppointmentsByDate(SelectedDate); } }
    
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
            //ApptsByDay.AcceptChanges();
            appointments_DGV.DataSource = ApptsByDay;
        }
    }
}
