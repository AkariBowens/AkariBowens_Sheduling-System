using AkariBowens_Sheduling_System.Classes;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public string AddressID { get; set; }
        

        // Cast as bool
        public int Active { get; set; }
        public DateTime CreateDate { get; set; }
        public static string dateFormat = @"yyyy-MM-dd hh:mm:ss";
        // Hard-code this
        public string CreatedBy { get; set; }
        // is TIMESTAMP() - numbers
        
        public DateTime LastUpdate { get; set; } 
        // Hard-code this
        public string LastUpdatedBy { get; set; }

        public static Customer SelectedCustomer { get; set; }

        // not needed
        //public static int GlobalCustomerID { get; set; } = 50;

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
   
                MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);

                DBConnection.OpenConnection();

                // -- Add On -- //
                // Do address ID logic
                string customerInsertstring = $"INSERT INTO customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdatedBy) VALUES({newCust.CustomerName}, {newCust.AddressID}, {newCust.Active}, {newCust.CreateDate}, {newCust.CreatedBy}, {newCust.LastUpdate}, {newCust.LastUpdatedBy});";
                
                MySqlCommand insertCustomer = new MySqlCommand(customerInsertstring, connection);

                // if this returns -1... run error
                if (insertCustomer.ExecuteNonQuery() == -1)
                { 
                    Console.WriteLine($"Added new customer {newCust.CustomerName}");
                    throw new Exception("Insert Failed!");
                }
                
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

        // Reads list of arguments

            // ----- Constructor ----- //
        public Customer( string custName, string custAddr) 
        {
            CustomerName = custName;

            // Define address id later
            AddressID = Convert.ToString(Address.FindAddressId(custAddr));
            
            // if (active.ToLower() = "false") { Active = 0 } elif (active.ToLower() == "true") { Active = 1 }
   
            Active = 1;

            CreateDate = DateTime.Now;
            Console.WriteLine(CreateDate);
            
            CreatedBy = "Admin";
            LastUpdate = DateTime.Now;
            LastUpdatedBy = "Admin";
        }
    }
}
