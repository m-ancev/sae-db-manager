using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sae_db_manager
{
    internal class UserRoleDAO
    {
        //string connectionString = "datasource=localhost;port=3306;username=root;password=;database=user_management";
        public string ConnectionString { get; set; }


        public List<JObject> GetAllUserRoles(bool export)
        {
            List<JObject> returnUserRoles = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM user_roles", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject user = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        user.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnUserRoles.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnUserRoles, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\all_userroles.json", json);

                MessageBox.Show("Users have been saved to all_userroles.json");
            }

            return returnUserRoles;
        }

        public List<JObject> GetAnyEntryFromUserRoles(String searchQuery, bool export)
        {
            List<JObject> returnUserRoles = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            String searchFuzzyQuery = "%" + searchQuery + "%";

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM user_roles WHERE User_ID LIKE @search OR Role_ID LIKE @search";
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
                    returnUserRoles.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnUserRoles, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\search_userroles.json", json);

                MessageBox.Show("Users have been saved to search_userroles.json");
            }

            return returnUserRoles;
        }

        public int UpdateUserRole(UserRole userRole)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "UPDATE user_roles SET Role_ID = @roleID WHERE User_ID = @userID";
            command.Parameters.AddWithValue("@roleID", userRole.RoleID);
            command.Parameters.AddWithValue("@userID", userRole.UserID);
            command.Connection = connection;

            int result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }
    }
}
