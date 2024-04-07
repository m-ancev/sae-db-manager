namespace sae_db_manager
{
    public partial class Form1 : Form
    {
        BindingSource usersBindingSource = new BindingSource();
        BindingSource departmentsBindingSource = new BindingSource();
        BindingSource rolesBindingSource = new BindingSource();

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
    }
}
