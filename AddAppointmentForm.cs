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
        private string AddCustomerName;
        private DateTime AddApptDate;

        // Might have to change to a Customer Object later
        public string SelectedCustomer;
        public AddAppointmentForm()
        {
            InitializeComponent();
        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            // Fill in later with data from DGV
            Customer_textBox.Text = SelectedCustomer;
            Customer_textBox.Enabled = false;

            save_button.Enabled = false;

            //start_textBox.MaxLength = 4;
            //end_textBox.MaxLength = 4;
        }

        // ToggleSave();
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

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                ApptType_textBox.BackColor = Color.Tomato;
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            SelectedCustomer = "";
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
            // Instantiates new Appointment to be added

            // chagne custId later
            // Start and end are on the same dates, must include the date as well
            AddApptEnd = new DateTime(AddApptStart.Year, AddApptStart.Month,  AddApptStart.Day, AddApptEnd.Hour, AddApptEnd.Minute, AddApptEnd.Second);
            Appointment SavedAppt = new Appointment(-1, AddApptStart, AddApptEnd, AddApptType );
            
            // Call Appointment.AddAppointment(savedAppt);
        }

        private void start_label_Click(object sender, EventArgs e)
        {

        }

        private void Start_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (!string.IsNullOrWhiteSpace(start_textBox.Text))
                //{
                //    // when char == 2 add ':' 
                //    // This-v- && more than 3 chars?
                //    while (start_textBox.Text != "" && start_textBox.Text.Length >= 3)
                //    {

                //        // ToggleSaveButton();

                //        if (start_textBox.Text.Length == 4)
                //        {
                //            //start_textBox.Text;
                //            if (!DateTime.TryParse(start_textBox.Text.Insert(2, ":"), out AddApptStart))
                //            {
                //                throw new Exception("Not a possible time");
                //            }
                //            Console.WriteLine("It works!");

                //        }
                //        else
                //        // if (start_textBox.Text.Length == 3) 
                //        {
                //            //start_textBox.Text;
                //if (DateTime.TryParse(Start_DateTimePicker.Value.ToString("yyyy-mm-dd hh:mm:ss"), out AddApptStart))
                //{
                DateTime tempStartTime = Start_DateTimePicker.Value;
                Console.WriteLine($"Chosen: {Start_DateTimePicker.Value}, Now: {DateTime.Now}");
                if (tempStartTime >= DateTime.Now)
                {
                    if (tempStartTime.DayOfWeek != DayOfWeek.Saturday && tempStartTime.DayOfWeek != DayOfWeek.Sunday)
                    {
                        //if (tempStartTime.Hour >= 9 && tempStartTime.Hour < 17)
                        //{
                            // add overlapping, place this --vvv-- in it
                            AddApptStart = tempStartTime;
                            Console.WriteLine($"It works! {AddApptStart}");
                        //}
                        //else
                        //{   
                            //Console.WriteLine("Time picked was outside of business hours.");
                            //throw new Exception("Pick a time between 9AM & 5PM!");
                        //}
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
                    
                    

                    // Overlapping
                    // basically, just query for any appointment times between times picked
                    // if start of another is between, end of another is between --
                    // if start of this is between or end of this is between
                    // this against the data table, if any fall on this day, then run above checks

                    
                    
                //} 
                //else 
                //{    
                    // why is this runing when i pick a date?
                    //throw new Exception("Not a possible date!");
                //}
                

                //        }
                //        break;
                //    }
                //}
                //// handling when time is in wrong formatt 12h vs 24H
                //else
                //{
                //    throw new Exception("End time cannot be empty!");
                //}
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                MessageBox.Show(exc.Message.ToString());
                //start_textBox.BackColor = Color.Tomato;
                //start_textBox.Clear();
                //Start_DateTimePicker
                //End_DateTimePicker
            }
        }

        private void End_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(End_DateTimePicker.Value.ToString("yyyy-mm-dd hh:mm:ss"));
        }
    }
}
