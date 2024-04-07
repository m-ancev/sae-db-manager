using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sae_db_manager
{
    internal class DepartmentDAO
    {
        //string connectionString = "datasource=localhost;port=3306;username=root;password=;database=user_management";
        public string ConnectionString { get; set; }
        public List<JObject> GetAllDepartments(bool export)
        {
            List<JObject> returnDepartments = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM departments", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject user = new JObject();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        user.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }
                    returnDepartments.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnDepartments, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\all_departments.json", json);

                MessageBox.Show("Users have been saved to all_departments.json");
            }
            return returnDepartments;
        }

        public List<JObject> GetAnyEntryFromDepartments(String searchQuery, bool export)
        {
            List<JObject> returnDepartments = new List<JObject>();


            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            String searchFuzzyQuery = "%" + searchQuery + "%";

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM departments WHERE Department_ID LIKE @search OR Department_Name LIKE @search";
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
                    returnDepartments.Add(user);
                }
            }
            connection.Close();

            if (export == true)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(returnDepartments, Newtonsoft.Json.Formatting.Indented);

                string directory = @"C:\DATA";
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                System.IO.File.WriteAllText(directory + @"\search_departments.json", json);

                MessageBox.Show("Users have been saved to search_departments.json");
            }

            return returnDepartments;
        }

        public int AddDepartment(Department department)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO departments (Department_Name) VALUES (@DepartmentName)";
            command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
            command.Connection = connection;

            int result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        public int DeleteDepartment(Department department)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "DELETE FROM departments WHERE Department_ID = @DepartmentID";
            command.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
            command.Connection = connection;

            int result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }
    }
}
