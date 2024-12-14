using AkariBowens_Sheduling_System.DB;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
            VarDGVLabel.Text = "Appointments Per Month";

            DataTable AppointmentsPerMonthDT = new DataTable();
            
            string ApptsString = $"SELECT YEAR(start) as Year, monthname(start) as Month, Count(appointmentId) as Appointments, type as Type FROM appointment GROUP BY monthname(start), type;";

            //ORDER BY start
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
            ReportsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void ReportsDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserSchedule_Button_Click(object sender, EventArgs e)
        {
            VarDGVLabel.Text = "User Schedule";

            // Opens a list of customers
            DataTable userSchedule = new DataTable();
            
            // Opens a new form with a list of users
            UsersListForm usersListForm = new UsersListForm();
            usersListForm.ShowDialog();
            if (User.SelectedUser != null) {
                int selectedUserId = User.SelectedUser.UserID;
                DataTable tempTable = User.GetUserSchedule(selectedUserId);

                userSchedule = tempTable.Clone();
                var query = tempTable.AsEnumerable().OrderBy(c => (DateTime)c["start"]);

                foreach (var item in query)
                {
                    userSchedule.Rows.Add(item[0], item[1], item[2], item[3], item[4], item[5], item[6]);

                }

                ReportsDGV.DataSource = userSchedule;
                ReportsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }

        private void CustomersPerCountry_Button_Click(object sender, EventArgs e)
        {
            VarDGVLabel.Text = "Customers per country";

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
            ReportsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            ReportsDGV.MultiSelect = false;
            ReportsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ReportsDGV.ReadOnly = true;
            ReportsDGV.AllowUserToAddRows = false;

            ReportsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }
    }
}
