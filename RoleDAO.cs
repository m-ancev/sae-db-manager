using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sae_db_manager
{

    internal class RoleDAO
    {
        //string connectionString = "datasource=localhost;port=3306;username=root;password=;database=user_management";
        public string ConnectionString { get; set; }

        public List<JObject> GetAllRoles(bool export)
        {
            List<JObject> returnRoles = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM roles", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject user = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        user.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnRoles.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnRoles, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\all_roles.json", json);

                MessageBox.Show("Users have been saved to all_roles.json");
            }

            return returnRoles;
        }

        public List<JObject> GetAnyEntryFromRoles(String searchQuery, bool export)
        {
            List<JObject> returnRoles = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            String searchFuzzyQuery = "%" + searchQuery + "%";

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM roles WHERE Role_ID LIKE @search OR Role_Name LIKE @search";
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
                    returnRoles.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnRoles, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\search_roles.json", json);

                MessageBox.Show("Users have been saved to search_roles.json");
            }

            return returnRoles;
        }

        public int AddRole(Role role)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO roles (Role_Name) VALUES (@RoleName)";
            command.Parameters.AddWithValue("@RoleName", role.RoleName);
            command.Connection = connection;

            int result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        public int DeleteRole(Role role)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE FROM roles WHERE Role_ID = @RoleID";
            command.Parameters.AddWithValue("@RoleID", role.RoleID);
            command.Connection = connection;

            int result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }
    }
}
