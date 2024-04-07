using MySql.Data.MySqlClient;
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

        public List<UserRole> GetAllUserRoles()
        {
            List<UserRole> returnUserRoles = new List<UserRole>();

            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM user_roles", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    UserRole userRole = new UserRole
                    {
                        UserID = reader.GetInt32(0),
                        RoleID = reader.GetInt32(1),
                    };
                    returnUserRoles.Add(userRole);
                }
            }
            connection.Close();

            return returnUserRoles;
        }

        public List<UserRole> GetAnyEntryFromUserRoles(String searchQuery)
        {
            List<UserRole> returnUserRoles = new List<UserRole>();

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
                    UserRole userRole = new UserRole
                    {
                        UserID = reader.GetInt32(0),
                        RoleID = reader.GetInt32(1),
                    };
                    returnUserRoles.Add(userRole);
                }
            }
            connection.Close();

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
