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
    public partial class signuptest : Form
    {
        public signuptest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get the username submitted from the sign-up form
            string username = textBox1.Text;
            string password = textBox2.Text;


            // create a new connection to the database
            string connectionString = "data source = BNK;database = LMS;integrated security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // open the connection
                connection.Open();

                // create a SqlCommand object with the SQL query to check for the username
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM loginTable WHERE username = @username", connection);

                // add the parameter for the username to the command
                command.Parameters.AddWithValue("@username", username);

                // execute the query and get the number of rows returned
                int count = (int)command.ExecuteScalar();

                // check if the username already exists in the table
                if (count > 0)
                {
                    MessageBox.Show("Your Username Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (count == 0)
                {
                    // add the new user to the database
                    // ...
                    command.CommandText = "insert into loginTable(username,password) values ('" + username + "','" + password + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();


                }
                else
                {
                    MessageBox.Show("Empty Field Not Allowed", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // close the connection
                connection.Close();
            }
        }
    }
}
