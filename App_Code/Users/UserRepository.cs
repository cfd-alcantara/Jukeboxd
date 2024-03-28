using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services.Description;
using System.Xml.Linq;

namespace MP2_IT114L.App_Code.Users
{
    public class UserRepository
    {
        private readonly string connectionString;
        public UserRepository() 
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }
        public void CreateUser(string name, string email, string password, string type)
        {
            
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "INSERT INTO Account (Account_Id, Name, Email, Password, Address, Type) " +
                    "VALUES (@Account_Id, @Name, @Email, @Password, @Address, @Type)";

                string accountId;

                if (type == "Admin")
                {
                    accountId = GenerateAccountIdAdmin();
                    command.Parameters.AddWithValue("@Address", "N/A");
                }
                else
                {
                    accountId = GenerateAccountIdCustomer();
                }

                command.Parameters.AddWithValue("@Account_Id", accountId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Address", "nfkjdbfkabsdfkjbsdafj");
                command.Parameters.AddWithValue("@Type", type);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public bool CheckUser(string email, string password)
        {
            
            bool userExists = false;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT COUNT(*) FROM Account WHERE Email = @Email AND Password = @Password";
                    //"SELECT COUNT(*) FROM Account WHERE Email = @Email AND Password = @Password AND Type = @Type";

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                //command.Parameters.AddWithValue("@Type", type);

                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    userExists = true;
                }
            }
            return userExists;
        }

        public string CheckUserType(string email, string password)
        {
            string UserType;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT Type FROM Account WHERE Email = @Email AND Password = @Password";

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                object result = command.ExecuteScalar();
                UserType = result.ToString();
            }
            return UserType;
        }

        public bool CheckExistingUser(string email)
        {
            
            bool userExists = false;
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT COUNT(*) FROM Account WHERE Email = @Email";

                command.Parameters.AddWithValue("@Email", email);

                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    userExists = true;
                }
            }
            return userExists;
        }

        private string GenerateAccountIdAdmin()
        {
            int latestAccountId = GetLatestAccountId();
            int newAccountId = latestAccountId + 1;
            string accountIdString = "AD" + newAccountId.ToString("D7");

            return accountIdString;
        }

        private string GenerateAccountIdCustomer()
        {
            int latestAccountId = GetLatestAccountId();
            int newAccountId = latestAccountId + 1;
            string accountIdString = "CU" + newAccountId.ToString("D7");

            return accountIdString;
        } 

        private int GetLatestAccountId()
        {
            int latestAccountId = 0;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(Account_Id) FROM Account";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string accountId = result.ToString();
                        string numericPart = accountId.Substring(2);
                        latestAccountId = int.Parse(numericPart);
                    }
                }
            }

            return latestAccountId;
        }
    }
}