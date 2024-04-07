namespace sae_db_manager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            button3 = new Button();
            txt_DepartmentID = new TextBox();
            txt_HireDate = new TextBox();
            txt_BirthDate = new TextBox();
            txt_Address = new TextBox();
            txt_Phone = new TextBox();
            txt_Email = new TextBox();
            txt_LastName = new TextBox();
            txt_FirstName = new TextBox();
            txt_Password = new TextBox();
            txt_UserName = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(111, 23);
            button1.TabIndex = 0;
            button1.Text = "Show All Users";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1178, 150);
            dataGridView1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(578, 12);
            button2.Name = "button2";
            button2.Size = new Size(111, 23);
            button2.TabIndex = 2;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(129, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(443, 23);
            textBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(txt_DepartmentID);
            groupBox1.Controls.Add(txt_HireDate);
            groupBox1.Controls.Add(txt_BirthDate);
            groupBox1.Controls.Add(txt_Address);
            groupBox1.Controls.Add(txt_Phone);
            groupBox1.Controls.Add(txt_Email);
            groupBox1.Controls.Add(txt_LastName);
            groupBox1.Controls.Add(txt_FirstName);
            groupBox1.Controls.Add(txt_Password);
            groupBox1.Controls.Add(txt_UserName);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 197);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(298, 331);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add User";
            // 
            // button3
            // 
            button3.Location = new Point(117, 303);
            button3.Name = "button3";
            button3.Size = new Size(175, 23);
            button3.TabIndex = 22;
            button3.Text = "Add";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txt_DepartmentID
            // 
            txt_DepartmentID.Location = new Point(117, 274);
            txt_DepartmentID.Name = "txt_DepartmentID";
            txt_DepartmentID.Size = new Size(173, 23);
            txt_DepartmentID.TabIndex = 21;
            // 
            // txt_HireDate
            // 
            txt_HireDate.Location = new Point(117, 246);
            txt_HireDate.Name = "txt_HireDate";
            txt_HireDate.Size = new Size(173, 23);
            txt_HireDate.TabIndex = 20;
            // 
            // txt_BirthDate
            // 
            txt_BirthDate.Location = new Point(117, 218);
            txt_BirthDate.Name = "txt_BirthDate";
            txt_BirthDate.Size = new Size(173, 23);
            txt_BirthDate.TabIndex = 19;
            // 
            // txt_Address
            // 
            txt_Address.Location = new Point(117, 190);
            txt_Address.Name = "txt_Address";
            txt_Address.Size = new Size(173, 23);
            txt_Address.TabIndex = 18;
            // 
            // txt_Phone
            // 
            txt_Phone.Location = new Point(117, 162);
            txt_Phone.Name = "txt_Phone";
            txt_Phone.Size = new Size(173, 23);
            txt_Phone.TabIndex = 17;
            // 
            // txt_Email
            // 
            txt_Email.Location = new Point(117, 134);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(173, 23);
            txt_Email.TabIndex = 16;
            // 
            // txt_LastName
            // 
            txt_LastName.Location = new Point(117, 106);
            txt_LastName.Name = "txt_LastName";
            txt_LastName.Size = new Size(173, 23);
            txt_LastName.TabIndex = 15;
            // 
            // txt_FirstName
            // 
            txt_FirstName.Location = new Point(117, 78);
            txt_FirstName.Name = "txt_FirstName";
            txt_FirstName.Size = new Size(173, 23);
            txt_FirstName.TabIndex = 14;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(117, 50);
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(173, 23);
            txt_Password.TabIndex = 13;
            // 
            // txt_UserName
            // 
            txt_UserName.Location = new Point(117, 22);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Size = new Size(173, 23);
            txt_UserName.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 282);
            label11.Name = "label11";
            label11.Size = new Size(81, 15);
            label11.TabIndex = 10;
            label11.Text = "DepartmentID";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 254);
            label10.Name = "label10";
            label10.Size = new Size(53, 15);
            label10.TabIndex = 9;
            label10.Text = "HireDate";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 226);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 8;
            label9.Text = "BirthDate";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 198);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 7;
            label8.Text = "Address";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 170);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 6;
            label7.Text = "Phone";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 142);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 114);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 4;
            label5.Text = "LastName";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 86);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 3;
            label4.Text = "FirstName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 58);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 30);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 1;
            label2.Text = "UserName";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 587);
            Controls.Add(groupBox1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label11;
        private TextBox txt_FirstName;
        private TextBox txt_Password;
        private TextBox txt_UserName;
        private TextBox txt_LastName;
        private TextBox txt_Email;
        private TextBox txt_Phone;
        private TextBox txt_Address;
        private TextBox txt_BirthDate;
        private TextBox txt_HireDate;
        private TextBox txt_DepartmentID;
        private Button button3;
    }
}
