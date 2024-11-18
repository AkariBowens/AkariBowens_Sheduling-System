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
    public partial class AllAppointmentsCalendar : Form
    {
        public AllAppointmentsCalendar()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Console.WriteLine("Date changed");
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Console.WriteLine("Date selected");
            // Opens Appointment form, with options for remove, and update
            // No it shows a list of appointments
            
        }

        private void allAppts_label_Click(object sender, EventArgs e)
        {

        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppointmentsForm form = new AppointmentsForm();
            AppointmentsForm.SelectedDate = monthCalendar1.SelectionRange.Start;
            form.Show();
        }
    }
}
