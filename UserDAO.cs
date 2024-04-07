using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sae_db_manager
{
    internal class UserDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=user_management";
        
        public List<User> GetAllUsers()
        {
            List<User> returnUsers = new List<User>();


            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        UserID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        Password = reader.GetString(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        Email = reader.GetString(5),
                        Phone = reader.GetString(6),
                        Address = reader.GetString(7),
                        BirthDate = reader.GetDateTime(8),
                        HireDate = reader.GetDateTime(9),
                        DepartmentID = reader.GetInt32(10)
                    };

                    returnUsers.Add(user);
                }
            }
            connection.Close();

            return returnUsers;
        }

        public List<User> GetUserByUserName(String searchQuery)
        {
            List<User> returnUsers = new List<User>();


            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String searchFuzzyQuery = "%" + searchQuery + "%";

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM users WHERE UserName LIKE @search";
            command.Parameters.AddWithValue("@search", searchFuzzyQuery);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        UserID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        Password = reader.GetString(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        Email = reader.GetString(5),
                        Phone = reader.GetString(6),
                        Address = reader.GetString(7),
                        BirthDate = reader.GetDateTime(8),
                        HireDate = reader.GetDateTime(9),
                        DepartmentID = reader.GetInt32(10)
                    };

                    returnUsers.Add(user);
                }
            }
            connection.Close();

            return returnUsers;
        }

        public int AddUser(User user)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.Connection = connection;

            command.CommandText = "INSERT INTO users (UserName, Password, First_Name, Last_Name, Email, Phone, Address, Birth_Date, Hire_Date, Department_ID) VALUES (@UserName, @Password, @FirstName, @LastName, @Email, @Phone, @Address, @BirthDate, @HireDate, @DepartmentID)";
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@Address", user.Address);
            command.Parameters.AddWithValue("@BirthDate", user.BirthDate);
            command.Parameters.AddWithValue("@HireDate", user.HireDate);
            command.Parameters.AddWithValue("@DepartmentID", user.DepartmentID);

            int rowsAffected = command.ExecuteNonQuery();
            
            connection.Close();

            return rowsAffected;
        }
    }
}
