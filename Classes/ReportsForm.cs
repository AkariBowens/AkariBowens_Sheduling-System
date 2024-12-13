using AkariBowens_Sheduling_System.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            DataTable AppointmentsPerMonthDT = new DataTable();
            //string ApptsString = $"SELECT YEAR(start), month(start), Count(ApptId), type FROM appointment GROUPBY type ORDER BY start;";
            string ApptsString = $"SELECT YEAR(start) as Year, monthname(start) as Month, Count(appointmentId) as Appointment(s), type as Type FROM appointment GROUP BY monthname(start), type ORDER BY start";
            DataTable outputTable = new DataTable();
            DBConnection.OpenConnection();

            MySqlConnection connection = DBConnection.connect;

            using (connection)
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(ApptsString, connection);

                mySqlDataAdapter.Fill(outputTable);

            }

            var query = outputTable.AsEnumerable().OrderByDescending(a => a["Year"]);

            AppointmentsPerMonthDT = outputTable.Clone();
            foreach(var item in query)
            {
                AppointmentsPerMonthDT.Rows.Add(item[0], item[1], item[2], item[3]);
            }

            ReportsDGV.DataSource = AppointmentsPerMonthDT;

        }

        private void ReportsDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void UserSchedule_Button_Click(object sender, EventArgs e)
        {
            // Opens a list of customers
            DataTable userSchedule = new DataTable();
            
            // Opens a new form with a list of users
            UsersListForm usersListForm = new UsersListForm();
            usersListForm.ShowDialog();

            // Task<int> selectedUserID() => Task.FromResult(User.SelectedUser.UserID);
            int selectedUserId = User.SelectedUser.UserID;
            Console.WriteLine(selectedUserId + " -- ReportsForm 105");
            //Task<DataTable> tempTable = Task.FromResult(User.GetUserSchedule(await selectedUserID()));
            DataTable tempTable = User.GetUserSchedule(selectedUserId);

            //tempTable = Task.FromResult(tempTable.OrderBy(c => c["start"]));
            //tempTable = tempTable.AsEnumerable().OrderBy(c => c["start"]);
            userSchedule = tempTable.Clone();
            //userSchedule = await tempTable;
            var query = tempTable.AsEnumerable().OrderBy(c => (DateTime)c["start"]);

            foreach (var item in query)
            {
                userSchedule.Rows.Add(item[0], item[1], item[2], item[3], item[4], item[5], item[6]);
                
            }
            //userSchedule = 

            ReportsDGV.DataSource = userSchedule;
        }

        private void CustomersPerCountry_Button_Click(object sender, EventArgs e)
        {
            DataTable tempDT = new DataTable();
            DataTable CustomersPerCountry = new DataTable();

            // -- DB Query -- //
            string selectString = $"SELECT customerId, customerName, country.countryId, country FROM customer INNER JOIN address ON address.addressId = customer.addressID INNER JOIN city on city.cityId = address.cityId INNER JOIN country ON country.countryId = city.countryId;";

            DBConnection.OpenConnection();

            using (DBConnection.connect)
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectString, DBConnection.connect);
                mySqlDataAdapter.Fill(tempDT);
            }

            var query = from row in tempDT.AsEnumerable()
                        select new
                        {
                            CustomerID = row.Field<int>("customerId"),
                            CustomerName = row.Field<string>("customerName"),
                            CountryID = row.Field<int>("countryId"),
                            CountryName = row.Field<string>("country")
                        };

            CustomersPerCountry = tempDT.Clone();

            var orderQuery = query.OrderBy(c => c.CountryName);

            foreach (var row in orderQuery)
            {
                CustomersPerCountry.Rows.Add(row.CustomerID, row.CustomerName, row.CountryID, row.CountryName);
            }

            // Changes DataSource to CustomersPerCountryDT
            ReportsDGV.DataSource = CustomersPerCountry;
            ReportsDGV.Columns["countryId"].Visible = false;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            ReportsDGV.MultiSelect = false;
            ReportsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReportsDGV.ReadOnly = true;
            ReportsDGV.AllowUserToAddRows = false;
        }
    }
}
