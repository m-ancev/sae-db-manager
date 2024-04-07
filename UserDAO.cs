using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace sae_db_manager
{
    internal class UserDAO
    {
        //string connectionString = "datasource=localhost;port=3306;username=root;password=;database=user_management";
        public string ConnectionString { get; set; }


        public List<JObject> GetAllUsers(bool export)
        {
            List<JObject> returnUsers = new List<JObject>();


            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM users", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject user = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        user.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnUsers.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnUsers, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\all_users.json", json);

                MessageBox.Show("Users have been saved to all_users.json");
            }

            return returnUsers;
        }

        public List<JObject> GetAnyEntryFromUsers(String searchQuery, bool export)
        {
            List<JObject> returnUsers = new List<JObject>();


            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            String searchFuzzyQuery = "%" + searchQuery + "%";

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM users WHERE UserName LIKE @search OR Password LIKE @search OR First_Name LIKE @search OR Last_Name LIKE @search OR Email LIKE @search OR Phone LIKE @search OR Address LIKE @search OR Birth_Date LIKE @search OR Hire_Date LIKE @search OR Department_ID LIKE @search";
            command.Parameters.AddWithValue("@search", searchFuzzyQuery);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject user = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        user.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnUsers.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnUsers, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\search_users.json", json);

                MessageBox.Show("Users have been saved to search_users.json");
            }

            return returnUsers;
        }

        public List<JObject> GetAllUsersAndDepartmentName(bool export)
        {
            List<JObject> returnUsers = new List<JObject>();


            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `username`, `first_name`, `last_name`, departments.department_name FROM `users` JOIN departments ON users.department_id = departments.department_id", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject user = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        user.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnUsers.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnUsers, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\all_users_departments.json", json);

                MessageBox.Show("Users have been saved to all_users_departments.json");
            }

            return returnUsers;
        }

        public List<JObject> GetAnyEntryFromUsersAndDepartmentName(String searchQuery, bool export)
        {
            List<JObject> returnUsers = new List<JObject>();


            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            String searchFuzzyQuery = "%" + searchQuery + "%";

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT `username`, `first_name`, `last_name`, departments.department_name FROM `users` JOIN departments ON users.department_id WHERE UserName LIKE @search OR First_Name LIKE @search or Last_Name LIKE @search OR departments.department_name LIKE @search";
            command.Parameters.AddWithValue("@search", searchFuzzyQuery);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject user = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        user.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnUsers.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnUsers, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\search_users_departments.json", json);

                MessageBox.Show("Users have been saved to search_users_departments.json");
            }

            return returnUsers;
        }

        // get all users and role names
        public List<JObject> GetAllUsersAndRoleName(bool export)
        {
            List<JObject> returnUsers = new List<JObject>();


            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `username`, `first_name`, `last_name`, roles.role_name FROM `users` JOIN roles ON users.user_id = roles.role_id", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject user = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        user.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnUsers.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnUsers, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\all_users_roles.json", json);

                MessageBox.Show("Users have been saved to all_users_roles.json");
            }

            return returnUsers;
        }

        public List<JObject> GetAnyEntryFromUsersAndRoleName(String searchQuery, bool export)
        {
            List<JObject> returnUsers = new List<JObject>();


            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            String searchFuzzyQuery = "%" + searchQuery + "%";

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT `username`, `first_name`, `last_name`, roles.role_name FROM `users` JOIN roles ON users.user_id = roles.role_id WHERE UserName LIKE @search OR First_Name LIKE @search or Last_Name LIKE @search OR roles.role_name LIKE @search";
            command.Parameters.AddWithValue("@search", searchFuzzyQuery);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject user = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        user.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnUsers.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnUsers, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\search_users_roles.json", json);

                MessageBox.Show("Users have been saved to search_users_roles.json");
            }

            return returnUsers;
        }

        public int AddUser(User user)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
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

        public int UpdateUser(User user)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.Connection = connection;

            command.CommandText = "UPDATE users SET UserName = @UserName, Password = @Password, First_Name = @FirstName, Last_Name = @LastName, Email = @Email, Phone = @Phone, Address = @Address, Birth_Date = @BirthDate, Hire_Date = @HireDate, Department_ID = @DepartmentID WHERE User_ID = @UserID";
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

            command.Parameters.AddWithValue("@UserID", user.UserID);

            string userAffected = command.ExecuteNonQuery().ToString();

            connection.Close();

            return int.Parse(userAffected);
        }

        public int DeleteUser(User user)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.Connection = connection;

            command.CommandText = "DELETE FROM users WHERE User_ID = @UserID";
            command.Parameters.AddWithValue("@UserID", user.UserID);

            string userAffected = command.ExecuteNonQuery().ToString();

            connection.Close();

            return int.Parse(userAffected);
        }
    }
}
