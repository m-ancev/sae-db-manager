namespace sae_db_manager
{
    public partial class Form1 : Form
    {
        BindingSource usersBindingSource = new BindingSource();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsersDAO usersDAO = new UsersDAO();

            usersBindingSource.DataSource = usersDAO.GetAllUsers();

            dataGridView1.DataSource = usersBindingSource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsersDAO usersDAO = new UsersDAO();

            usersBindingSource.DataSource = usersDAO.GetUserByUserName(textBox1.Text);

            dataGridView1.DataSource = usersBindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Users user = new Users
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

            UsersDAO usersDAO = new UsersDAO();
            int result = usersDAO.AddUser(user);
            MessageBox.Show(result + " record(s) inserted.");

        }
    }
}
