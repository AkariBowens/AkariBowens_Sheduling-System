using AkariBowens_Sheduling_System.DB;
using MySql.Data.MySqlClient;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkariBowens_Sheduling_System.Classes
{
    internal class Address
    {
        // ----- Properties ----- //
        public int AddressID { get; set; }
        public string AddressName { get; set; }

        public string AddressName2 { get; set; } 
        public int CityId {get; set; }
       
        public string PostalCode { get; set; }
        public static int GlobalPostalCode { get; set; } = 22222;

        public string Phone {get; set;}
        public DateTime CreateDate { get; set; }
        public static string dateFormat = @"yyyy-MM-dd hh:mm:ss";

        public string CreatedBy { get; set; }

        public DateTime LastUpdate { get; set; }

        public string LastUpdatedBy { get; set; }

        public static Address SelectedAddress { get; set; }

        // ----- Methods ----- //

        public static bool AddAddress(Address address) 
        {
            
            Address tempAddress = new Address(-1, address.AddressName, address.Phone);

            
            tempAddress.CityId = 1;
            // change ZipCode and CityId
            // address and phone are swapped
            string addressAddString = $"INSERT INTO address(address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) VALUES('{tempAddress.AddressName}', '{tempAddress.AddressName2}', {tempAddress.CityId}, '{tempAddress.PostalCode}', '{tempAddress.Phone}', '{tempAddress.CreateDate.Date.ToString("yyyy-MM-dd HH:mm:ss")}', '{tempAddress.CreatedBy}','{tempAddress.LastUpdate.Date.ToString("yyyy-MM-dd HH:mm:ss")}', '{tempAddress.LastUpdatedBy}')";

            DBConnection.OpenConnection();
            MySqlCommand insertAddress = new MySqlCommand(addressAddString, DBConnection.connect);

            MySqlConnection connection = DBConnection.connect;
            using (connection)
            {
                if (insertAddress.ExecuteNonQuery() == 0)
                {
                    Console.WriteLine($"Adding address failed!");
                    throw new Exception("Insert Failed!");
                }
            }

            Customer.GetCustomers();
            return true;
        }
        public static string FindAddress(int addrID) { return ""; }

        public static bool UpdateAddress(Address address)
        {
            try 
            {
                Console.WriteLine($"UpdateAddress: Phone-{address.Phone}; ID:{address.AddressID}");

                string phoneString = $"phone = '{address.Phone}'";
                string addressString = $"address = '{address.AddressName}'";

                string fullString = string.Empty;

                if (address.Phone != SelectedAddress.Phone)
                {

                    fullString = phoneString;

                }

                if (address.AddressName != SelectedAddress.AddressName)
                {
                    if (fullString == string.Empty)
                    {
                        fullString = addressString;
                    }
                    else if(fullString != string.Empty)
                    {
                        fullString = fullString + $", {addressString}";
                    }
                }

                Console.WriteLine($"FullString: {fullString}");

                string updateString
                    = $" UPDATE address SET {fullString} WHERE addressId = {address.AddressID};";

                Console.WriteLine($"UpdateString: {updateString}");

                DBConnection.OpenConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(updateString, DBConnection.connect);

                if (mySqlCommand.ExecuteNonQuery() == 0)
                {
                    throw new Exception("Update address failed.");
                }

                return true;
            }
            catch (Exception exc) 
            { 
                Console.WriteLine(exc.Message.ToString());
                return false;
            }

        }
        //Delete
        public static int FindAddressId(string addrName, string phone)
        {
            try
            {
                DataTable AddressList = GetAddresses();
                
                string addressName = addrName;
                string AddrPhone = phone;
                Console.WriteLine($"Phone: {AddrPhone}; Address: {addressName}; FindAddressID...89");

                string addressIDQuery = $"SELECT addressId FROM address WHERE address = '{addressName}' and phone = '{AddrPhone}'";

                DBConnection.OpenConnection();
                MySqlCommand getAddressID = new MySqlCommand(addressIDQuery, DBConnection.connect);

                int AddrId;

                using (DBConnection.connect)
                {
                    var result = getAddressID.ExecuteScalar();
                    AddrId = Convert.ToInt32(result);
                }

                Console.WriteLine(AddrId + " -- AddressID in Find ID");
                return AddrId;

            } catch (Exception exc)
            {
                Console.WriteLine(exc.Message.ToString());
                return -1;
            }
        }

        // ----- Constructor ----- //

        public Address(int addressId, string addressName, string phone)
        {
            AddressID = addressId;       
            AddressName = addressName;

            
            AddressName2 = string.Empty;

            // ---------- //

            // Update later
            //CityId = cityId;
            CityId = 1;
            PostalCode = Convert.ToString(GlobalPostalCode++);
            Phone = phone;

            // ----- //
            CreateDate = DateTime.Now;
            CreatedBy = "Admin";
            LastUpdate = DateTime.Now;
            LastUpdatedBy = "Admin";
        }


        public static DataTable GetAddresses()
        {
            DataTable result = new DataTable();
            DataTable AddressTable = new DataTable();

            string addressQuery =  $"SELECT addressId, address, cityId, postalCode, phone from address";

            DBConnection.OpenConnection();
            MySqlCommand getAddresses = new MySqlCommand(addressQuery, DBConnection.connect);

            using (DBConnection.connect)
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(addressQuery, DBConnection.connect);
                mySqlDataAdapter.Fill(result);
                
            }

            AddressTable = result.Clone();

            var query = from row in result.AsEnumerable()
                        select new
                        {
                            
                            AddressID = row.Field<int>("addressId"),
                            AddressName = row.Field<string>("address"),
                            CityId = row.Field<int>("cityId"),
                            PostalCode = row.Field<string>("postalCode"),
                            Phone = row.Field<string>("phone")
                        };


            foreach(var item in query)
            {
                AddressTable.Rows.Add(item.AddressID, item.AddressName, item.CityId, item.PostalCode, item.Phone);
            }

            return AddressTable;
        }
    }




}
