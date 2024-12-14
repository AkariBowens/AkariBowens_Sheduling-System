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
    public partial class UpdateAppointmentForm : Form
    {
        private string AddApptType;
        private DateTime AddApptStart;
        private DateTime AddApptEnd;
        //private string AddCustomerName;
        //private DateTime AddApptDate;

        private DateTime OpenTime = new DateTime(2000, 12, 31, 9, 0, 0);
        private DateTime CloseTime = new DateTime(2000, 12, 31, 17, 0, 0);

        //private static Appointment currentAppointment = Appointment.SelectedAppointment;

        public UpdateAppointmentForm()
        {
            InitializeComponent();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Customer.SelectedCustomer = null;
            Close();
        }

        private void UpdateAppointmentForm_Load(object sender, EventArgs e)
        {
            ApptType_textBox.Text = Appointment.SelectedAppointment.ApptType;
            Start_DateTimePicker.Value = Appointment.SelectedAppointment.StartTime;
            End_DateTimePicker.Value = Appointment.SelectedAppointment.EndTime;

            Customer_textBox.Text = Customer.SelectedCustomer.CustomerName;
            Customer_textBox.Enabled = false;

            //save_button.Enabled = false;
            
        }

        private void ToggleSave()
        {
            if (AddApptStart != Appointment.SelectedAppointment.StartTime && AddApptEnd != Appointment.SelectedAppointment.StartTime)
            {
                save_button.Enabled = true;
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            // New Appointment
            AddApptEnd = new DateTime(AddApptStart.Year, AddApptStart.Month, AddApptStart.Day, AddApptEnd.Hour, AddApptEnd.Minute, AddApptEnd.Second);
            Console.WriteLine(AddApptEnd);
            Appointment newAppointment = new Appointment(Appointment.SelectedAppointment.ApptID, Customer.SelectedCustomer.CustomerID, AddApptStart, AddApptEnd, AddApptType);

            Console.WriteLine(newAppointment.ApptID + " -- newAppointment ApptID");
            if (Appointment.SelectedAppointment != null && Appointment.UpdateAppt(Appointment.SelectedAppointment, newAppointment))
            {
                //After Update called
                Customer.SelectedCustomer = null;
                Appointment.SelectedAppointment = null;

                // Then..
                Close();
            } else
            {
                MessageBox.Show("Update unsuccessful!");
            }
        }

        private void Start_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime tempStartTime = Start_DateTimePicker.Value;
                Console.WriteLine($"Chosen: {Start_DateTimePicker.Value}, Now: {DateTime.Now}");
                // if the values of selected and new are different - then.. allowSave();
                if (Appointment.SelectedAppointment.StartTime != Start_DateTimePicker.Value)
                {
                    if (tempStartTime >= DateTime.Now)
                    {
                        if (tempStartTime.DayOfWeek != DayOfWeek.Saturday && tempStartTime.DayOfWeek != DayOfWeek.Sunday)
                        {
                            if (tempStartTime.Hour >= OpenTime.Hour && tempStartTime.Hour <= CloseTime.Hour)
                            {
                                // Checks if selected times overlap
                                DataTable Appointments = Appointment.GetAppointments();
                                foreach (DataRow row in Appointments.Rows)
                                {
                                    // Only check appointments with a different ID from current Appointment
                                    if ((int)row["appointmentId"] != Appointment.SelectedAppointment.ApptID)
                                    {
                                        if (tempStartTime.Date == (DateTime)row["start"])
                                        {
                                            if (tempStartTime >= (DateTime)row["start"] && tempStartTime <= (DateTime)row["end"])
                                            {
                                                // Edit wording later
                                                throw new ArgumentException("Times cannot over lap!");
                                            }
                                            //else
                                            //{
                                            //    AddApptStart = tempStartTime;
                                            //    Console.WriteLine($"It works! {AddApptStart}");
                                            //    ToggleSave();
                                            //}
                                        }
                                    }

                                }
                                AddApptStart = tempStartTime;
                                Console.WriteLine($"It works! {AddApptStart}");
                                ToggleSave();
                            }
                            else
                            {
                                Console.WriteLine("Time picked was outside of business hours.");
                                throw new Exception("Pick a time between 9AM & 5PM!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Date picked was on the weekend.");
                            throw new Exception("Pick a day M-F!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Input a time in the past.");
                        throw new Exception("Cannot add an appointment in the past.");
                    }
                }


            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                MessageBox.Show(exc.Message.ToString());
                //start_textBox.BackColor = Color.Tomato;
                //start_textBox.Clear();

            }
        }

        private void End_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                DateTime tempEndTime = new DateTime(AddApptStart.Year, AddApptStart.Month, AddApptStart.Day, End_DateTimePicker.Value.Hour, End_DateTimePicker.Value.Minute, End_DateTimePicker.Value.Second);
                Console.WriteLine($"Chosen: {Start_DateTimePicker.Value}, Now: {DateTime.Now}");
                if (Appointment.SelectedAppointment.EndTime != End_DateTimePicker.Value)
                {
                    if (tempEndTime >= AddApptStart)
                    {
                        // Checks if chosen time is within business hours
                        if (tempEndTime.Hour >= OpenTime.Hour && tempEndTime.Hour <= CloseTime.Hour)
                        {
                            // Checks if end time over laps with any appointments
                            DataTable Appointments = Appointment.GetAppointments();
                            foreach (DataRow row in Appointments.Rows)
                            {
                                // Only check appointments with a different ID from current Appointment
                                if ((int)row["appointmentId"] != Appointment.SelectedAppointment.ApptID)
                                {
                                    // Checks for appointments on the same day
                                    if (tempEndTime.Date == (DateTime)row["start"])
                                    {

                                        // same hour, but before
                                        if (tempEndTime >= (DateTime)row["start"] && tempEndTime <= (DateTime)row["end"])
                                        //DateTime.Compare(tempStartTime, (DateTime)row["start"]);
                                        {
                                            // Edit wording later
                                            throw new ArgumentException("Ending overlaps with another appointment!");
                                        }
                                    }
                                }

                            }
                            AddApptEnd = tempEndTime;
                            Console.WriteLine($"It works! {AddApptStart}");
                            ToggleSave();
                        }
                        else
                        {
                            Console.WriteLine("Appointment's end is earlier than its start.");
                            throw new Exception("Pick a time after the appointed end.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Chose a time and/or date in the past.");
                        throw new Exception("Cannot add an appointment in the past.");
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                MessageBox.Show(exc.Message.ToString());
                //start_textBox.BackColor = Color.Tomato;
                //start_textBox.Clear();
            }
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
    }
}
