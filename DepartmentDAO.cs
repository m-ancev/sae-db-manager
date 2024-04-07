using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sae_db_manager
{
    internal class DepartmentDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=user_management";
        public List<Department> GetAllDepartments()
        {
            List<Department> returnDepartments = new List<Department>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM departments", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Department department = new Department
                    {
                        DepartmentID = reader.GetInt32(0),
                        DepartmentName = reader.GetString(1),
                    };
                    returnDepartments.Add(department);
                }
            }
            connection.Close();

            return returnDepartments;
        }

        public List<Department> GetAnyEntryFromDepartments(String searchQuery)
        {
            List<Department> returnDepartments = new List<Department>();


            MySqlConnection connection = new MySqlConnection(connectionString);
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
                    Department department = new Department
                    {
                        DepartmentID = reader.GetInt32(0),
                        DepartmentName = reader.GetString(1)
                    };
                    returnDepartments.Add(department);
                }
            }
            connection.Close();

            return returnDepartments;
        }

        public int AddDepartment(Department department)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
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
            MySqlConnection connection = new MySqlConnection(connectionString);
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
