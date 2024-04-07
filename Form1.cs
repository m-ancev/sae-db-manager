namespace sae_db_manager
{
    public partial class Form1 : Form
    {
        BindingSource usersBindingSource = new BindingSource();
        BindingSource departmentsBindingSource = new BindingSource();
        BindingSource rolesBindingSource = new BindingSource();
        BindingSource userRolesBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();

            usersBindingSource.DataSource = userDAO.GetAllUsers();

            dataGridView1.DataSource = usersBindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();

            usersBindingSource.DataSource = userDAO.GetAnyEntryFromUsers(textBox1.Text);

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
            int result = userDAO.AddUser(user);
            MessageBox.Show(result + " record(s) inserted.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DepartmentDAO departmentDAO = new DepartmentDAO();

            departmentsBindingSource.DataSource = departmentDAO.GetAllDepartments();

            dataGridView1.DataSource = departmentsBindingSource;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RoleDAO roleDAO = new RoleDAO();

            rolesBindingSource.DataSource = roleDAO.GetAllRoles();

            dataGridView1.DataSource = rolesBindingSource;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DepartmentDAO departmentDAO = new DepartmentDAO();

            departmentsBindingSource.DataSource = departmentDAO.GetAnyEntryFromDepartments(textBox2.Text);

            dataGridView1.DataSource = departmentsBindingSource;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RoleDAO roleDAO = new RoleDAO();

            rolesBindingSource.DataSource = roleDAO.GetAnyEntryFromRoles(textBox3.Text);

            dataGridView1.DataSource = rolesBindingSource;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Department department = new Department
            {
                DepartmentName = txt_DepartmentName.Text
            };

            DepartmentDAO departmentDAO = new DepartmentDAO();

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
            int result = userDAO.UpdateUser(user);
            MessageBox.Show(result + " record(s) updated.");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            UserRoleDAO userRoleDAO = new UserRoleDAO();

            userRolesBindingSource.DataSource = userRoleDAO.GetAllUserRoles();

            dataGridView1.DataSource = userRolesBindingSource;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            UserRoleDAO userRoleDAO = new UserRoleDAO();

            userRolesBindingSource.DataSource = userRoleDAO.GetAnyEntryFromUserRoles(textBox4.Text);

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
            int result = userRoleDAO.UpdateUserRole(userRole);
            MessageBox.Show(result + " record(s) updated.");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();

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
            Role role = new Role
            {
                RoleID = int.Parse(txt_RoleID.Text)
            };
            roleDAO.DeleteRole(role);
            MessageBox.Show("Role deleted.");
        }
    }
}
