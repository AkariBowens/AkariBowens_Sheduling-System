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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        // Close Button
        private void button1_Click(object sender, EventArgs e)
        {
            CurrentUserViewForm currentUserViewForm = new CurrentUserViewForm();
            currentUserViewForm.Show();
            Close();

        }

        private void ApptsPerMonth_Button_Click(object sender, EventArgs e)
        {
            string ApptsString = $"SELECT YEAR(start), month(start), Count(ApptId), type FROM appointment GROUPBY type ORDER BY start;";
        }

        

        private void ReportsDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
