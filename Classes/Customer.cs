using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AkariBowens_Sheduling_System.DB
{
    internal class Customer
    {
        // ----- Properties ----- //
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string AddressID { get; set; }

        public string Contact { get; set; }

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

        public static int GlobalCustomerID { get; set; } = 50;

        // List of args
        private List<string> ArgsList { get; set; }

        // ----- Methods ----- //
        public static bool AddCustomer(Customer newCust) 
        {
            try
            {

                // when in SQL return based on if the operation was succesful
                int CustomerCount;

                using (DBConnection.connect)
                {
                    // Returns current row count of customer table
                    string ReadRows = $"SELECT COUNT(customerName) FROM customer GROUP BY customerId;";
                    MySqlCommand customerCount = new MySqlCommand(ReadRows, DBConnection.connect);

                    Console.WriteLine(newCust.CreateDate.ToString(dateFormat));
                    
                    // loop argsList? - map function + '*here*'
                    string SQLInsertString = $"INSERT INTO customer VALUES('{newCust.CustomerID}', '{newCust.CustomerName}', '{newCust.AddressID}', '{newCust.Active}', '{ newCust.CreateDate.ToString(dateFormat)}', '{newCust.CreatedBy}', '{newCust.LastUpdate.ToString(dateFormat)}', '{newCust.LastUpdatedBy}');";
                    MySqlCommand addCustomer = new MySqlCommand(SQLInsertString, DBConnection.connect);

                    DBConnection.OpenConnection();

                    int InitialCustomerCount = Convert.ToInt32(customerCount.ExecuteScalar().ToString());
                    Console.WriteLine(InitialCustomerCount + " --Beginning count");
                    addCustomer.ExecuteNonQuery();

                    // reconfigure later
                    customerCount = new MySqlCommand(ReadRows, DBConnection.connect);
                    CustomerCount = Convert.ToInt32(customerCount.ExecuteScalar().ToString());
                    Console.WriteLine(CustomerCount + " --Ending count");

                    if (InitialCustomerCount < CustomerCount)
                    {
                        throw new ArgumentException("Insert unsuccessful.");
                        //return false;
                    }
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
                string deleteString = $"DELETE FROM customer WHERE customerId = {custId};";
                MySqlCommand deleteCustomerCommand = new MySqlCommand(deleteString, DBConnection.connect);

                deleteCustomerCommand.ExecuteNonQuery();
                //if ()
                //{
                return true;
                //}
            }
            catch
            {
                return false;
            }
        }
        // public static UpdateCustomer(){}

        // Reads list of arguments

            // ----- Constructor ----- //
        public Customer( string custName, string custAddr, string contact) 
        {
            CustomerID = GlobalCustomerID++;
            CustomerName = custName;
            AddressID = custAddr;
            // if (active.ToLower() = "false") { Active = 0 } elif (active.ToLower() == "true") { Active = 1 }
            Contact = contact;
            Active = 1;
            //DateTime formattedDate;
            //DateTime.TryParse(DateTime.Now.ToString(dateFormat), out formattedDate);
            CreateDate = DateTime.Now;
            Console.WriteLine(CreateDate);
            
            CreatedBy = "Admin";
            LastUpdate = DateTime.Now;
            LastUpdatedBy = "Admin";
        }
    }
}
