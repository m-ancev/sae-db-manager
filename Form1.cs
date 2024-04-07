using Newtonsoft.Json.Linq;

namespace sae_db_manager
{
    public partial class Form1 : Form
    {
        BindingSource usersBindingSource = new BindingSource();
        BindingSource departmentsBindingSource = new BindingSource();
        BindingSource rolesBindingSource = new BindingSource();
        BindingSource userRolesBindingSource = new BindingSource();

        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=user_management";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            usersBindingSource.DataSource = userDAO.GetAllUsers(false);

            dataGridView1.DataSource = usersBindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            usersBindingSource.DataSource = userDAO.GetAnyEntryFromUsers(textBox1.Text, false);

            dataGridView1.DataSource = usersBindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                UserName = txt_UserName.Text,
                Password = txt_Password.Text,
                FirstName = txt_FirstName.Text,
                LastName = txt_LastName.Text,
                Email = txt_Email.Text,
                Phone = txt_Phone.Text,
                Address = txt_Address.Text,
                BirthDate = DateTime.ParseExact(txt_BirthDate.Text, "dd.MM.yyyy", null),
                HireDate = DateTime.ParseExact(txt_HireDate.Text, "dd.MM.yyyy", null),
                DepartmentID = int.Parse(txt_DepartmentID.Text)
            };

            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;
            int result = userDAO.AddUser(user);
            MessageBox.Show(result + " record(s) inserted.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DepartmentDAO departmentDAO = new DepartmentDAO();
            departmentDAO.ConnectionString = connectionString;

            departmentsBindingSource.DataSource = departmentDAO.GetAllDepartments(false);

            dataGridView1.DataSource = departmentsBindingSource;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RoleDAO roleDAO = new RoleDAO();
            roleDAO.ConnectionString = connectionString;

            rolesBindingSource.DataSource = roleDAO.GetAllRoles(false);

            dataGridView1.DataSource = rolesBindingSource;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DepartmentDAO departmentDAO = new DepartmentDAO();
            departmentDAO.ConnectionString = connectionString;

            departmentsBindingSource.DataSource = departmentDAO.GetAnyEntryFromDepartments(textBox2.Text, false);

            dataGridView1.DataSource = departmentsBindingSource;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RoleDAO roleDAO = new RoleDAO();
            roleDAO.ConnectionString = connectionString;

            rolesBindingSource.DataSource = roleDAO.GetAnyEntryFromRoles(textBox3.Text, false);

            dataGridView1.DataSource = rolesBindingSource;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Department department = new Department
            {
                DepartmentName = txt_DepartmentName.Text
            };

            DepartmentDAO departmentDAO = new DepartmentDAO();
            departmentDAO.ConnectionString = connectionString;

            int result = departmentDAO.AddDepartment(department);
            MessageBox.Show(result + " record(s) inserted.");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Role role = new Role
            {
                RoleName = txt_RoleName.Text
            };

            RoleDAO roleDAO = new RoleDAO();
            roleDAO.ConnectionString = connectionString;

            int result = roleDAO.AddRole(role);
            MessageBox.Show(result + " record(s) inserted.");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                UserID = int.Parse(txt_UserID.Text),
                UserName = txt_UserName2.Text,
                Password = txt_Password2.Text,
                FirstName = txt_FirstName2.Text,
                LastName = txt_LastName2.Text,
                Email = txt_Email2.Text,
                Phone = txt_Phone2.Text,
                Address = txt_Address2.Text,
                BirthDate = DateTime.ParseExact(txt_BirthDate2.Text, "dd.MM.yyyy", null),
                HireDate = DateTime.ParseExact(txt_HireDate2.Text, "dd.MM.yyyy", null),
                DepartmentID = int.Parse(txt_DepartmentID2.Text)
            };

            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;
            int result = userDAO.UpdateUser(user);
            MessageBox.Show(result + " record(s) updated.");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            UserRoleDAO userRoleDAO = new UserRoleDAO();
            userRoleDAO.ConnectionString = connectionString;

            userRolesBindingSource.DataSource = userRoleDAO.GetAllUserRoles(false);

            dataGridView1.DataSource = userRolesBindingSource;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UserRoleDAO userRoleDAO = new UserRoleDAO();
            userRoleDAO.ConnectionString = connectionString;

            userRolesBindingSource.DataSource = userRoleDAO.GetAnyEntryFromUserRoles(textBox4.Text, false);

            dataGridView1.DataSource = userRolesBindingSource;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            UserRole userRole = new UserRole
            {
                UserID = int.Parse(txt_UserID3.Text),
                RoleID = int.Parse(txt_RoleID2.Text)
            };

            UserRoleDAO userRoleDAO = new UserRoleDAO();
            userRoleDAO.ConnectionString = connectionString;
            int result = userRoleDAO.UpdateUserRole(userRole);
            MessageBox.Show(result + " record(s) updated.");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            User user = new User
            {
                UserID = int.Parse(txt_UserID2.Text)
            };
            userDAO.DeleteUser(user);
            MessageBox.Show("User deleted.");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DepartmentDAO departmentDAO = new DepartmentDAO();
            departmentDAO.ConnectionString = connectionString;
            Department department = new Department
            {
                DepartmentID = int.Parse(txt_DepartmentID3.Text)
            };
            departmentDAO.DeleteDepartment(department);
            MessageBox.Show("Department deleted.");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            RoleDAO roleDAO = new RoleDAO();
            roleDAO.ConnectionString = connectionString;
            Role role = new Role
            {
                RoleID = int.Parse(txt_RoleID.Text)
            };
            roleDAO.DeleteRole(role);
            MessageBox.Show("Role deleted.");
        }

        public void button17_Click(object sender, EventArgs e)
        {
            string datasource = txtDatasource.Text;
            string port = txtPort.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string database = txtDatabase.Text;

            DatabaseConnector databaseConnector = new DatabaseConnector();

            connectionString = databaseConnector.BuildConnectionString(datasource, port, username, password, database);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            usersBindingSource.DataSource = userDAO.GetAllUsersAndDepartmentName(false);

            dataGridView1.DataSource = usersBindingSource;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            usersBindingSource.DataSource = userDAO.GetAnyEntryFromUsersAndDepartmentName(textBox5.Text, false);
            dataGridView1.DataSource = usersBindingSource;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            usersBindingSource.DataSource = userDAO.GetAnyEntryFromUsersAndRoleName(textBox6.Text, false);
            dataGridView1.DataSource = usersBindingSource;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            usersBindingSource.DataSource = userDAO.GetAllUsersAndRoleName(false);
            dataGridView1.DataSource = usersBindingSource;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            usersBindingSource.DataSource = userDAO.GetAllUsers(true);

            dataGridView1.DataSource = usersBindingSource;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            usersBindingSource.DataSource = userDAO.GetAllUsersAndDepartmentName(true);

            dataGridView1.DataSource = usersBindingSource;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DepartmentDAO departmentDAO = new DepartmentDAO();
            departmentDAO.ConnectionString = connectionString;

            departmentsBindingSource.DataSource = departmentDAO.GetAllDepartments(true);

            dataGridView1.DataSource = departmentsBindingSource;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            RoleDAO roleDAO = new RoleDAO();
            roleDAO.ConnectionString = connectionString;

            rolesBindingSource.DataSource = roleDAO.GetAllRoles(true);

            dataGridView1.DataSource = rolesBindingSource;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            UserRoleDAO userRoleDAO = new UserRoleDAO();
            userRoleDAO.ConnectionString = connectionString;

            userRolesBindingSource.DataSource = userRoleDAO.GetAllUserRoles(true);

            dataGridView1.DataSource = userRolesBindingSource;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            userDAO.ConnectionString = connectionString;

            usersBindingSource.DataSource = userDAO.GetAllUsersAndRoleName(true);

            dataGridView1.DataSource = usersBindingSource;
        }
    }
}
