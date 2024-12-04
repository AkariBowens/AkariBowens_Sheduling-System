using AkariBowens_Sheduling_System.DB;
using MySql.Data.MySqlClient;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AkariBowens_Sheduling_System.Classes
{
    internal class Address
    {
        // ----- Properties ----- //
        public int AddressID { get; set; }
        public string AddressName { get; set; }

        public string AddressName2 { get; set; } = null;
        public int CityId {get; set; }
        public string PostalCode { get; set; }
        public static int GlobalPostalCode { get; set; } = 22222;

        public string Phone {get; set;}
        public DateTime CreateDate { get; set; }
        public static string dateFormat = @"yyyy-MM-dd hh:mm:ss";
        // Hard-code this
        public string CreatedBy { get; set; }
        // is TIMESTAMP() - numbers

        public DateTime LastUpdate { get; set; }
        // Hard-code this
        public string LastUpdatedBy { get; set; }

        // ----- Methods ----- //
        public static bool AddAddress(string addrName, string phone) 
        {

            Address tempAddress = new Address(addrName, phone);
            string addressAddString = $"INSERT INTO address VALUES(null, {tempAddress.AddressName}, null, {tempAddress.CityId}, 11114, '{tempAddress.Phone}')";

            MySqlCommand insertAddress = new MySqlCommand(addressAddString, DBConnection.connect);
            DBConnection.OpenConnection();

            MySqlConnection connection = DBConnection.connect;
            using (connection)
            {
                if (insertAddress.ExecuteNonQuery() == 0)
                {
                    Console.WriteLine($"Adding address failed!");
                    throw new Exception("Insert Failed!");
                }
            }

            return true;
        }
        public static string FindAddress(int addrID) { return ""; }
        
        //Delete
        public static int FindAddressId(string addrName)
        {
            try
            {
                //string address = addrName;
                string address = "123 Main";
                object queryResult;

                string getAddressIdString = $"SELECT addressId, address FROM address WHERE UPPER(address) = '{address.ToUpper()}';";
                MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localdb"].ConnectionString);
                MySqlCommand addressIDQuery = new MySqlCommand(getAddressIdString, connection);

                DBConnection.OpenConnection();

                using (connection)
                {
                    DBConnection.OpenConnection();
                    queryResult = addressIDQuery.ExecuteScalar();

                    if (queryResult.GetType() != null || queryResult != DBNull.Value)
                    {
                        // return address here
                        return Convert.ToInt32(queryResult);
                    }
                    else
                    {

                        Console.WriteLine("Query result null");
                        return -1;
                    }
                }
                // Console.WriteLine("AddressId query result" + queryResult);

                // If the query returns a null result
                
            } catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                return -1;
            }
        }

        // ----- Constructor ----- //

        // get id on creation?/

        // , int cityId, string postalCode
        // int addressId,
        public Address(string addressName, string phone)
        {
            //AddressID = 4;       
            AddressName = addressName;

            // Update later
            //CityId = cityId;
            
            // ---------- //
            CityId = 1;

            //PostalCode = postalCode;
            PostalCode = GlobalPostalCode++.ToString();
            Phone = phone;

            // ----- //
            CreateDate = DateTime.Now;
            CreatedBy = "Admin";
            LastUpdate = DateTime.Now;
            LastUpdatedBy = "Admin";
        }

        //public static Address SelectedAddress { get; set; }
    }




}
