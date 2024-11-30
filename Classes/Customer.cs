using AkariBowens_Sheduling_System.Classes;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System.DB
{
    internal class Customer
    {
        // ----- Properties ----- //
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int AddressID { get; set; }

        // Cast as bool
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public static string dateFormat = @"yyyy-MM-dd hh:mm:ss";

        public string CreatedBy { get; set; }

        public DateTime LastUpdate { get; set; } 
        // Hard-code this
        public string LastUpdatedBy { get; set; }

        public static Customer SelectedCustomer { get; set; }

        // not needed
        //public static int GlobalCustomerID { get; set; } = 50;

        public static DataTable Customers
        {
            get { GetCustomers(); return Customers; }
            set { GetCustomers(); }

            //{ 
            // SQL Query result here

            // - add all to an sql query class... i.e. GetCustomers(), GetAppointments(), DeleteCustomer(), DeleteAppointment() or.. DeleteCommand(var customer/appointment, int selectedId){sql query string with 2 input options}
            // allAppointmentsQuery = $"SELECT * FROM Appointments WHERE userId = {CurrentUserID};";
            //MySqlCommand apptsQuery = new MySqlCommand()    
            //};



        }

        // List of args
        private List<string> ArgsList { get; set; }

        // ----- Methods ----- //
        public static bool AddCustomer(Customer newCust, Address newAddr) 
        {
            // if addressid == -1..Create else..
            // ----- just add everything new ----- //
            // new customer, new address, keep city and country the hard-coded
            try
            {
                // Initializes new 'Customer' instance
                Customer newCustomer = newCust;

                // Initializes new 'Address' instance
                Address address = newAddr;

                DBConnection.OpenConnection();
                MySqlConnection connection = DBConnection.connect;

                // -- Add On -- //
                // Do address ID logic
                string customerInsertstring = $"INSERT INTO customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdatedBy) VALUES({newCust.CustomerName}, {newCust.AddressID}, {newCust.Active}, {newCust.CreateDate}, {newCust.CreatedBy}, {newCust.LastUpdate}, {newCust.LastUpdatedBy});";
                
                MySqlCommand insertCustomer = new MySqlCommand(customerInsertstring, connection);

                // if this returns -1... run error
                if (insertCustomer.ExecuteNonQuery() == 0)
                {
                    Console.WriteLine($"Adding customer failed!");
                    throw new Exception("Insert Failed!");
                }

                Console.WriteLine($"Added new customer {newCust.CustomerName}");
                return true;
                
            } catch (Exception ArgumentException)
            {
                Console.WriteLine(ArgumentException.Message.ToString());
                return false;
            }

        }
        
        public static bool RemoveCustomer(int custId)
        {
            try
            {
                // -- Only for testing -- //
                //custId = 50;

                int inputCustID = custId;
                //int result;
                Console.WriteLine(custId + " -- custId");
                Console.WriteLine(inputCustID + " -- inputCustID");

                MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);

                DBConnection.OpenConnection();
                using (connection)
                { 

                    string deleteString = $"DELETE FROM customer WHERE customerId = {inputCustID};";

                    MySqlCommand deleteCustomer = new MySqlCommand(deleteString, DBConnection.connect);
                    DBConnection.OpenConnection();

                    //result = Convert.ToInt32(
                    deleteCustomer.ExecuteNonQuery();
                }

                //DBConnection.CloseConnection();

                //Console.WriteLine(result);
                return true;
               
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString() + "-- deletion error!");

                return false;
            }
        }

        // public static UpdateCustomer(){}

        public static DataTable GetCustomers()
        {

            DataTable CustomerList;

            // Rewrite this to return address, city, country instead of addressId & where appointmentId is the source of the customer
            //string allCustomersQuery = $"SELECT customerId, customerName, address, city, country FROM customer INNER JOIN address ON customer.addressId = address.addressId INNER JOIN address INNER JOIN city ON address.cityId = city.cityId INNER JOIN country ON city.countryId = country.countryId;"

            // addressId


            string allCustomersQuery = $"SELECT customerId, customerName, addressId, address FROM customer INNER JOIN address WHERE customer.addressId = address.addressId;";

            //string allCustsQuery = $"SELECT customername, customerId, address, addressId, city, country FROM customer INNER JOIN address ON customer.customerId = address.customerId WHERE appointment.userId = {CurrentUserID}";
            //$"WHERE userId = {CurrentUserID};";
            MySqlCommand customersQuery = new MySqlCommand(allCustomersQuery, DBConnection.connect);
            DBConnection.OpenConnection();
            // Only display what's necessary
            using (DBConnection.connect)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(allCustomersQuery, DBConnection.connect);
                CustomerList = new DataTable();

                dataAdapter.Fill(CustomerList);
            }

            return CustomerList;
        }

        // Reads list of arguments

        // ----- Constructor ----- //
        public Customer( int custID, string custName, int addressId) 
        {
            CustomerID = custID;
            CustomerName = custName;
            AddressID = addressId;

            // ----- //
            Active = 1;
            CreateDate = DateTime.Now;
            CreatedBy = "Admin";
            LastUpdate = DateTime.Now;
            LastUpdatedBy = "Admin";
        }
    }
}
