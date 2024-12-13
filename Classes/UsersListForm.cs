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

namespace AkariBowens_Sheduling_System.Classes
{
    public partial class UsersListForm : Form
    {
        public UsersListForm()
        {
            InitializeComponent();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UsersListForm_Load(object sender, EventArgs e)
        {
            UsersDGV.DataSource = User.GetUsers();

            UsersDGV.MultiSelect = false;
            UsersDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UsersDGV.ReadOnly = true;
            UsersDGV.AllowUserToAddRows = false;
        }

        private void select_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UsersDGV.CurrentRow.Selected)
                {
                    MessageBox.Show("Please select a user!");
                    throw new ArgumentException("No user selected.");
                }

                User.SelectedUser = new User((int)UsersDGV.CurrentRow.Cells["userId"].Value, UsersDGV.CurrentRow.Cells["userName"].Value.ToString());

                Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void users_label_Click(object sender, EventArgs e)
        {

        }

        private void UsersDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UsersDGV.ClearSelection();
        }
    }
}
