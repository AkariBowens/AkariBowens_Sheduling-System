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
            try
            {
                //if row selected - MessageBox.Show("yes or no", select a customer);
                //if ()
                //{
                //    MessageBox.Show("Select a customer!", "Delete Customer", MessageBoxButtons.YesNo);
                //}
            }
            catch
            {

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

            // ----- Customers DGV -- //
            CustomerDGV.MultiSelect = false;
            CustomerDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
