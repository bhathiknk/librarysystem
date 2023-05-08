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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace library_system_C__group_project
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
    
            string username = txtUserName.Text;
            string password = txtPassword.Text;


            // create a new connection to the database
            string connectionString = "data source = BNK;database = LMS;integrated security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))

            if (txtUserName.Text != "" && txtPassword.Text != "")
            
            {
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
                else if (count == 0) 
                {
      
                    command.CommandText = "insert into loginTable(username,password) values ('" + username + "','" + password + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Clear();
                    txtPassword.Clear();

                        this.Hide();
                        SignIn si = new SignIn();
                        si.Show();


                    }
              

                    // close the connection
                    connection.Close();
            }
                else
                {
                    MessageBox.Show("Empty Field Not Allowed", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

        }
    }
}

