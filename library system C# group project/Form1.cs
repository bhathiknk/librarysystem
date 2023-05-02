using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system_C__group_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from loginTable where username='" + username.Text + "' and password = '" + password.Text + "'";
            SqlDataAdapter da =new SqlDataAdapter(cmd);
            DataSet ds =new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0 )
            {
                this.Hide();
                dashbord dsa = new dashbord();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username OR Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void username_MouseEnter(object sender, EventArgs e)
        {
         
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void password_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void username_MouseClick(object sender, MouseEventArgs e)
        {
            if (username.Text == "username")
            {
                username.Clear();
            }
        }

        private void password_MouseClick(object sender, MouseEventArgs e)
        {
            if (password.Text == "password")
            {
                password.Clear();
                password.PasswordChar = '*';
            }
        }
    }
}
