﻿using AkariBowens_Sheduling_System.Classes;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
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

        public string LastUpdatedBy { get; set; }

        public static Customer SelectedCustomer { get; set; }

        public static List<Customer> Customers { get; set; } = new List<Customer>();


        // ----- Methods ----- //
        public static bool AddCustomer(Customer newCust, Address newAddr) 
        {
            try
            {
                // Initializes new 'Customer' instance
                Customer newCustomer = newCust;

                // Adding a Customer
                DBConnection.OpenConnection();
                MySqlConnection connection = DBConnection.connect;

                // -- Add On -- //
                string customerInsertstring = 
                    $"INSERT INTO customer(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    $"VALUES('{newCust.CustomerName}', " +
                    $"{newCust.AddressID}, " +
                    $"{newCust.Active}, " +
                    $"'{newCust.CreateDate.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                    $"'{newCust.CreatedBy}', " +
                    $"'{newCust.LastUpdate.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                    $"'{newCust.LastUpdatedBy}');";
                
                MySqlCommand insertCustomer = new MySqlCommand(customerInsertstring, connection);

                if (insertCustomer.ExecuteNonQuery() == 0)
                {
                    Console.WriteLine($"Adding customer failed!");
                   
                    throw new Exception("Insert Failed!");
                }

                Console.WriteLine($"Added new customer {newCust.CustomerName}.");
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
                int inputCustID = custId;
                
                Console.WriteLine(custId + " -- custId");
                Console.WriteLine(inputCustID + " -- inputCustID");

                MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);

                DBConnection.OpenConnection();
                using (connection)
                { 

                    string deleteString = $"DELETE FROM customer WHERE customerId = {inputCustID};";

                    MySqlCommand deleteCustomer = new MySqlCommand(deleteString, DBConnection.connect);
                    DBConnection.OpenConnection();

                    deleteCustomer.ExecuteNonQuery();
                }

                return true;
               
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString() + "-- deletion error!");

                return false;
            }
        }

        public static bool UpdateCustomer(Customer newCust)
        {

            try
            {

                string name = $"customerName = '{newCust.CustomerName}'";


                string fullCustomerString = string.Empty;

                if (newCust.CustomerName != SelectedCustomer.CustomerName)
                {
                    fullCustomerString = name;
                }

                string customerUpdateString
                    = $"UPDATE customer " +
                    $"SET {fullCustomerString} " +
                    $"WHERE customerId = {newCust.CustomerID};";

                DBConnection.OpenConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(customerUpdateString, DBConnection.connect);

                if (mySqlCommand.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Update customer failed.");
                }

                Console.WriteLine($"Updated customer with ID: {newCust.CustomerID}.");

                return true;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                return false;
            }
        }

        public static DataTable GetCustomers()
        {

            DataTable CustomerListQuery;

            DataTable CustomerList = new DataTable();

            string allCustomersQuery = $"SELECT customerId, customerName, phone, address, address.addressId, postalCode, city, city.cityId, country, country.countryId FROM customer INNER JOIN address ON customer.addressId = address.addressId INNER JOIN city ON address.cityId = city.cityId INNER JOIN country ON city.countryId = country.countryId;";
            
            MySqlCommand customersQuery = new MySqlCommand(allCustomersQuery, DBConnection.connect);
            DBConnection.OpenConnection();
            using (DBConnection.connect)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(allCustomersQuery, DBConnection.connect);
                CustomerListQuery = new DataTable();
                dataAdapter.Fill(CustomerListQuery);
            }
            CustomerList = CustomerListQuery.Clone();
            var query =
            from row in CustomerListQuery.AsEnumerable()
            select new
            {
                CustomerId = row.Field<int>("customerId"),
                CustomerName = row.Field<string>("customerName"),
                Phone = row.Field<string>("phone"),
                AddressName = row.Field<string>("address"),
                AddressID = row.Field<int>("addressId"),
                PostalCode = row.Field<string>("postalCode"),
                City = row.Field<string>("city"),
                CityId = row.Field<int>("cityId"),
                Country = row.Field<string>("country"),
                CountryId = row.Field<int>("countryId")
            }; 

            foreach (var item in query)
            {
                Customer newCust = new Customer(item.CustomerId, item.CustomerName, item.AddressID );
                Address newAddress = new Address(item.AddressID, item.AddressName, item.Phone);
                newAddress.Phone = item.Phone;
                newAddress.PostalCode = item.PostalCode;

                Customers.Add(newCust);
                CustomerList.Rows.Add(item.CustomerId, item.CustomerName, item.Phone, item.AddressName, item.AddressID, item.PostalCode, item.City, item.CityId, item.Country, item.CountryId);
            }
            
            return CustomerList;
        }

        public static Customer GetCustomerByID(int CustID)
        {
            DataTable tempDT = GetCustomers();

            Customer newCust = new Customer(CustID, "not found", -1);

            var query =
                from row in tempDT.AsEnumerable()
                where (int)row["customerId"] == CustID
                select new
                {
                    CustomerID = row.Field<int>("customerId"),
                    CustomerName = row.Field<string>("customerName"),
                    AddressID = row.Field<int>("addressId")
                };


            
            if (query.Count() == 1)
            {
                foreach (var item in query)
                {
                    newCust = new Customer(item.CustomerID, item.CustomerName, item.AddressID);
                }
            }
            
            return newCust;
            
        }

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
