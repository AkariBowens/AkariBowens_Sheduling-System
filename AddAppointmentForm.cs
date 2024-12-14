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
    public partial class AddAppointmentForm : Form
    {
        private string AddApptType;
        private DateTime AddApptStart;
        private DateTime AddApptEnd;
        //private string AddCustomerName;
        //private DateTime AddApptDate;

        private DateTime OpenTime = new DateTime(2000, 12, 31, 9, 0, 0);
        private DateTime CloseTime = new DateTime(2000, 12, 31, 17, 0, 0);

        public bool isNewAppt = true;
        private static Appointment currentAppointment = Appointment.SelectedAppointment;
        public AddAppointmentForm()
        {
            InitializeComponent();
        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            // Fill in later with data from DGV
            
            if (isNewAppt == false) 
            {
                //foreach(DataRow row in CurrentUser.Appointments.Rows)
                //{
                //    if (Convert.ToInt32(row["customerId"]) == Appointment.SelectedAppointment.CustID)
                //    {
                //        Customer_textBox.Text = row["customerName"].ToString();
                //        return;
                //    }
                //}
                ApptType_textBox.Text = currentAppointment.ApptType;
                Start_DateTimePicker.Value = currentAppointment.StartTime;
                End_DateTimePicker.Value = currentAppointment.EndTime;

            } 
            else 
            {
                Customer_textBox.Text = Customer.SelectedCustomer.CustomerName;
            }
            Customer_textBox.Enabled = false;
            save_button.Enabled = false;
        }

        private void ToggleSave()
        {
            //AddApptEnd = new DateTime(AddApptStart.Year, AddApptStart.Month, AddApptStart.Day);
            Console.WriteLine($"{AddApptEnd} --ToggleSave()..62");
            if(AddApptStart != null && AddApptEnd != null && AddApptEnd > AddApptStart && !string.IsNullOrWhiteSpace(ApptType_textBox.Text))
            {
                save_button.Enabled = true;
            }
            
        }
        // returns bool
        // checks validity after conversions & when type != empty

        // TextBoxesValid();
        //

        // save_button_clicked();
        //

        private void ApptType_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ApptType_textBox.Text))
                {
                    throw new ArgumentException("Type field cannot be empty.");
                }

                AddApptType = ApptType_textBox.Text;
                ToggleSave();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                ApptType_textBox.BackColor = Color.Tomato;
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Customer.SelectedCustomer = null;
            Appointment.SelectedAppointment = null;
            CurrentUserViewForm currentUserViewForm = new CurrentUserViewForm();
            currentUserViewForm.Show();
            Close();
        }

        private void Customer_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void start_textBox_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!string.IsNullOrWhiteSpace(start_textBox.Text))
            //    {
            //        // when char == 2 add ':' 
            //        // This-v- && more than 3 chars?
            //        while (start_textBox.Text != "" && start_textBox.Text.Length >= 3)
            //        {
                        
            //            // ToggleSaveButton();
                        
            //            if (start_textBox.Text.Length == 4)
            //            {
            //                //start_textBox.Text;
            //                if (!DateTime.TryParse(start_textBox.Text.Insert(2, ":"), out AddApptStart))
            //                {
            //                    throw new Exception("Not a possible time");
            //                }
            //                Console.WriteLine("It works!");
                            
            //            } 
            //            else 
            //            // if (start_textBox.Text.Length == 3) 
            //            {
            //                //start_textBox.Text;
            //                if (!DateTime.TryParse(start_textBox.Text.Insert(1, ":"), out AddApptStart))
            //                {
            //                    throw new Exception("Not a possible time");
            //                }
            //                Console.WriteLine("It works!");
                            
            //            }
            //            break;
            //        }   
            //    }
            //    // handling when time is in wrong formatt 12h vs 24H
            //    else 
            //    {
            //        throw new Exception("End time cannot be empty!");
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Console.WriteLine(exc.Message.ToString());
            //    MessageBox.Show(exc.Message.ToString());
            //    start_textBox.BackColor = Color.Tomato;
            //    start_textBox.Clear();

            //}
        }

        private void end_textBox_TextChanged(object sender, EventArgs e)
        {
            //try {
            //    if (!string.IsNullOrWhiteSpace(end_textBox.Text))
            //    {
            //    // when char == 2 add ':' 
            //    // This-v- && more than 3 chars?
            //        while (end_textBox.Text != "" && end_textBox.Text.Length >= 3)
            //        {

            //        // ToggleSaveButton();
            //            if (end_textBox.Text.Length == 4)
            //            {
            //            //start_textBox.Text;
            //                if (!DateTime.TryParse(end_textBox.Text.Insert(2, ":"), out AddApptEnd))
            //                {
            //                    throw new Exception("Not a possible time");
            //                }
            //                Console.WriteLine("It works!");
            //            }
            //            else
                         
            //            {
                        
            //                if (!DateTime.TryParse(end_textBox.Text.Insert(1, ":"), out AddApptEnd))
            //                {
            //                    throw new Exception("Not a possible time");
            //                }
            //                Console.WriteLine("It works!");

            //            }
            //        break;
            //        }
            //    }
            //// handling when time is in wrong formatt 12h vs 24H
            //    else
            //    {
            //        throw new Exception("Start time cannot be empty!");
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Console.WriteLine(exc.Message.ToString());
            //    MessageBox.Show(exc.Message.ToString());
            //    end_textBox.BackColor = Color.Tomato;
            //    end_textBox.Clear();

            //}
}

        private void save_button_Click(object sender, EventArgs e)
        {
            try
            {

                Console.WriteLine(Customer.SelectedCustomer.CustomerID + " -- Customer Id");
                // Instantiates new Appointment to be added
                Appointment SavedAppt = new Appointment(-1, Customer.SelectedCustomer.CustomerID, AddApptStart, AddApptEnd, AddApptType);
                Console.WriteLine($"{AddApptStart},  {AddApptEnd}  -- AddApptForm.. 220");
                Customer savedCustomer = Customer.SelectedCustomer;
                Console.WriteLine("Save button..");
                if (SavedAppt.StartTime >= DateTime.Now && SavedAppt.EndTime >= DateTime.Now) 
                {
                    
                    if (Appointment.AddAppointment(SavedAppt, savedCustomer))
                    {
                        //Customer.SelectedCustomer = null;
                        //Appointment.SelectedAppointment = null;
                        Console.WriteLine("Save successful");
                        CurrentUserViewForm currentUserViewForm = new CurrentUserViewForm();
                        currentUserViewForm.Show();

                        Close();
                    }
                    else
                    {
                        throw new Exception("Something went wrong during Add operation.");
                    }
                }
                else
                {
                    throw new ArgumentException("Something went wrong. Try again!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }

        private void start_label_Click(object sender, EventArgs e)
        {

        }

        private void Start_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
             
                // Only run error message when you Start_DateTimePicker is out of focus

                DateTime tempStartTime = Start_DateTimePicker.Value;
                Console.WriteLine($"Chosen: {Start_DateTimePicker.Value}, Now: {DateTime.Now}");
                if (tempStartTime >= DateTime.Now)
                {
                    if (tempStartTime.DayOfWeek != DayOfWeek.Saturday && tempStartTime.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (tempStartTime.Hour >= OpenTime.Hour && tempStartTime.Hour <= CloseTime.Hour)
                        {
                            // Checks if selected times overlap
                            DataTable Appointments = Appointment.GetAppointments();
                            foreach(DataRow row in Appointments.Rows)
                            {
                                
                                if(tempStartTime.Date == (DateTime)row["start"]) 
                                {
                                    if (tempStartTime >= (DateTime)row["start"] && tempStartTime <= (DateTime)row["end"])
                                    {
                                        // Edit wording later
                                        throw new ArgumentException("Times cannot over lap!");
                                    }
                                }
                                
                            }
                            AddApptStart = tempStartTime;
                            Console.WriteLine($"It works! {AddApptStart} -- Start time");
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
                    Console.WriteLine("Chose a time and/or date in the past.");
                    throw new Exception("Cannot add an appointment in the past.");
                }

    
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                MessageBox.Show(exc.Message.ToString());
      

            }
        }

        private void End_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"{End_DateTimePicker.Value.ToString("yyyy-mm-dd hh:mm:ss")} --end"); 

            try
            {

                // DateTime tempEndTime = new DateTime(Start_DateTimePicker.Value.Year, Start_DateTimePicker.Value.Month, Start_DateTimePicker.Value.Day, End_DateTimePicker.Value.Hour, End_DateTimePicker.Value.Minute, End_DateTimePicker.Value.Second);

                DateTime endTimePicker = End_DateTimePicker.Value;
                
                Console.WriteLine($"Chosen: {End_DateTimePicker.Value}, Now: {DateTime.Now} -- End..331");
                if (End_DateTimePicker.Value >= DateTime.Now)
                {
                    // Checks if chosen time is within business hours
                     if (End_DateTimePicker.Value.Hour >= OpenTime.Hour && End_DateTimePicker.Value.Hour <= CloseTime.Hour)
                        {
                            Console.WriteLine("Within business hours.");
                            // Checks if end time over laps with any appointments
                            DataTable Appointments = Appointment.GetAppointments();
                            foreach (DataRow row in Appointments.Rows)
                            {
                                // Checks for appointments on the same day
                                DateTime appointmentDateStart = (DateTime)row["start"];
                                DateTime appointmentDateEnd = (DateTime)row["end"];

                                Console.WriteLine($"{appointmentDateStart} -- AddApptForm..342");
                                if (endTimePicker.Date == appointmentDateStart.Date)
                                {
                                    // same hour, but before
                                    
                                    //rewrite this
                                    if (endTimePicker.Date >= appointmentDateStart.Date && endTimePicker.Date <= appointmentDateEnd.Date)
                                    // DateTime.Compare(tempStartTime, (DateTime)row["start"]);
                                    {
                                    // Edit wording later

                                        AddApptEnd = endTimePicker;
                                        Console.WriteLine($"It works! {AddApptEnd} -- ApptEnd");
                                        ToggleSave();
                                    }
                                    else
                                    {
                                        throw new ArgumentException("Appointment end overlaps with another appointment!");
                                    }
                                }
                                else
                                {
                                    AddApptEnd = endTimePicker;
                                    Console.WriteLine($"It works! {AddApptEnd} -- ApptEnd");
                                    ToggleSave();
                            }

                            }
                            
                     }
                     else
                     {
                            Console.WriteLine("Appointment was not within business hours.");
                            throw new Exception("Appointment end must be within business hours.");
                     }
                }
                else
                {
                    if (endTimePicker.Date != AddApptStart.Date)
                    {
                        Console.WriteLine("Picked an end time earlier than the start time.");
                        throw new Exception("Cannot end an appointment before it starts.");
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                MessageBox.Show(exc.Message.ToString());
               
            }
        }
    }
}
