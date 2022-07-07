using CBC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CBC
{
    public class Queries
    {
        #region getters
        public static List<Package> GetPackage(string package)
        {
            List<Package> packageList = new();
            string myQuery;
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader returnedReader;

            connection = new SqlConnection(DatabaseConnections.GetCBCCs());

            myQuery = @"select citem, cDescription, cPreferredVendor, mPrice, nQuantity from Package_" + package;

            using (connection)
            {
                command = new SqlCommand(myQuery, connection);
                using (command)
                {
                    connection.Open();
                    returnedReader = command.ExecuteReader();
                    using (returnedReader)
                    {
                        while (returnedReader.Read())
                        {
                            Package packageItem = new();
                            packageItem.Item = returnedReader[0].ToString();
                            packageItem.Description = returnedReader[1].ToString();
                            packageItem.PreferredVendor = returnedReader[2].ToString();
                            packageItem.Price = (decimal)returnedReader[3];
                            packageItem.Quantity = (decimal)returnedReader[4];
                            packageList.Add(packageItem);
                        }
                        return packageList;
                    }
                }
            }
        }

        public static List<PackageList> GetAllPackages()
        {
            List<PackageList> packages = new();
            string myQuery;
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader returnedReader;

            connection = new SqlConnection(DatabaseConnections.GetCBCCs());

            myQuery = "select * from Packages";

            using (connection)
            {
                command = new SqlCommand(myQuery, connection);
                using (command)
                {
                    connection.Open();
                    returnedReader = command.ExecuteReader();
                    using (returnedReader)
                    {
                        while (returnedReader.Read())
                        {
                            PackageList packageItem = new();
                            packageItem.Id = (int)returnedReader[0];
                            packageItem.Name = returnedReader[1].ToString();

                            packages.Add(packageItem);
                        }
                        return packages;
                    }
                }
            }
        }

        public static List<UserInfo> GetUserInfo(string userName)
        {
            List<UserInfo> userInfoList = new();
            
            string myQuery;
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader returnedReader;

            connection = new SqlConnection(DatabaseConnections.GetCBCCs());

            myQuery = "select * from Users where cUserName = '" + userName + "' ";

            using (connection)
            {
                command = new SqlCommand(myQuery, connection);
                using (command)
                {
                    connection.Open();
                    returnedReader = command.ExecuteReader();
                    using (returnedReader)
                    {
                        while (returnedReader.Read())
                        {
                            UserInfo user = new();
                            user.FistName = returnedReader[0].ToString();
                            user.LastName = returnedReader[1].ToString();
                            user.UserName = returnedReader[2].ToString();
                            user.Key = returnedReader[3].ToString();
                            user.Password = returnedReader[4].ToString();
                            user.Access = (int)returnedReader[5];

                            userInfoList.Add(user);
                        }
                        return userInfoList;
                    }
                }
            }
        }
        #endregion

        #region posts

        public static void AddUser(string firstName, string lastName, string userName, string key, string password, int access)
        {
            string myQuery;
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader returnedReader;

            connection = new SqlConnection(DatabaseConnections.GetCBCCs());

            myQuery = "insert into Users values('" + firstName + "', '" + lastName + "', '" + userName + "', '" + key + "', '" + password + "', " + access + ")";

            Console.WriteLine(myQuery);

            using (connection)
            {
                command = new SqlCommand(myQuery, connection);
                using (command)
                {
                    connection.Open();
                    returnedReader = command.ExecuteReader();
                }
            }
        }

        #endregion
    }
}
