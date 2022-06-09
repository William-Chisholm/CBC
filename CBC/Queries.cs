using CBC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CBC
{
    public class Queries
    {
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

        public  static List<PackageList> GetAllPackages()
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
    }
}
