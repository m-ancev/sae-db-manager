using MySql.Data.MySqlClient;
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

        public List<Role> GetAllRoles()
        {
            List<Role> returnRoles = new List<Role>();

            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM roles", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Role role = new Role
                    {
                        RoleID = reader.GetInt32(0),
                        RoleName = reader.GetString(1),
                    };
                    returnRoles.Add(role);
                }
            }
            connection.Close();

            return returnRoles;
        }

        public List<Role> GetAnyEntryFromRoles(String searchQuery)
        {
            List<Role> returnRoles = new List<Role>();

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
                    Role role = new Role
                    {
                        RoleID = reader.GetInt32(0),
                        RoleName = reader.GetString(1),
                    };
                    returnRoles.Add(role);
                }
            }
            connection.Close();

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

        // delete role
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
