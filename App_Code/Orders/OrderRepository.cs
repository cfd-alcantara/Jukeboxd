﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using MP2_IT114L.Admin;

namespace MP2_IT114L
{
    public class OrderRepository
    {
        private readonly string connectionString;
        public OrderRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public void AddOrder()
        {

        }

        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText =
                        "SELECT Date_Ordered, Account_Id, Quantity, Subtotal, p.Record_Image, p.Record_Name " +
                        "FROM OrderLog o " +
                        "INNER JOIN Record p ON o.Product_Id = p.Product_Id " +
                        "ORDER BY Date_Ordered ASC";
                    return command
                        .ExecuteReader()
                        .Cast<IDataRecord>()
                        .Select(row => new Order()
                        {
                            Date = (DateTime)row["Date_Ordered"],
                            RecordImage = row["Record_Image"] != DBNull.Value ? (byte[])row["Record_Image"] : new byte[] { 0 },
                            ProductName = (string)row["Record_Name"],
                            Account_ID = (string)row["Account_Id"],
                            Quantity = (int)row["Quantity"],
                            Subtotal = (decimal)row["Subtotal"]
                        })
                        .ToList();
                }
            }
            catch (SqlException ex)
            {
                // Log the exception or handle it as required
                // For now, returning an empty list
                Console.WriteLine("Error accessing database: " + ex.Message);
                return Enumerable.Empty<Order>();
            }
        }
        public List<string> GetUserOrders(string accountId)
        {
            List<string> orderList = new List<string>();

                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText =
                        "SELECT Date_Ordered, Account_Id, Quantity, Subtotal, Record_Image, Record_Name " +
                        "FROM OrderLog " +
                        "INNER JOIN Record ON OrderLog.Product_Id = Record.Product_Id " +
                        "WHERE Account_Id = @Account_Id " +
                        "ORDER BY Date_Ordered ASC ";
                    command.Parameters.AddWithValue("@Account_Id", accountId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            orderList.Add(reader["Date_Ordered"].ToString());
                            orderList.Add(reader["Record_Image"].ToString());
                            orderList.Add(reader["Record_Name"].ToString());
                            orderList.Add(reader["Quantity"].ToString());
                            orderList.Add(reader["Subtotal"].ToString());
                        }

                    connection.Close();
                }
                    return orderList;
                

            }
        }
    }
}