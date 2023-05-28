using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system_C__group_project
{
    public partial class StudentSignup : Form
    {
        public StudentSignup()
        {
            InitializeComponent();
        }

        private void btnStudentSignup_Click(object sender, EventArgs e)
        {
            string studentid = txtStudentId.Text;
            string password = txtStudentPassword.Text;

            // Validate the password
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Invalid password. Password should contain at least one uppercase letter, one lowercase letter, one digit, and have a minimum length of 6 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new connection to the database
            string connectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Check if the student ID exists in the NewStudent table
                SqlCommand checkStudentIdCommand = new SqlCommand("SELECT COUNT(*) FROM NewStudent WHERE studentid = @studentid", connection);
                checkStudentIdCommand.Parameters.AddWithValue("@studentid", studentid);
                int studentIdCount = (int)checkStudentIdCommand.ExecuteScalar();

                if (studentIdCount == 0)
                {
                    MessageBox.Show("You are not register with the Library.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the student ID already exists in the StudentLogin table
                SqlCommand checkUsernameCommand = new SqlCommand("SELECT COUNT(*) FROM StudentLogin WHERE studentid = @studentid", connection);
                checkUsernameCommand.Parameters.AddWithValue("@studentid", studentid);
                int usernameCount = (int)checkUsernameCommand.ExecuteScalar();

                if (usernameCount > 0)
                {
                    MessageBox.Show("Your Username Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insert the data into the StudentLogin table
                SqlCommand insertCommand = new SqlCommand("INSERT INTO StudentLogin(studentid, password) VALUES (@studentid, @password)", connection);
                insertCommand.Parameters.AddWithValue("@studentid", studentid);
                insertCommand.Parameters.AddWithValue("@password", password);
                insertCommand.ExecuteNonQuery();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStudentId.Clear();
                txtStudentPassword.Clear();

                this.Hide();
                StudentSignin ssi = new StudentSignin();
                ssi.Show();

                // Close the connection
                connection.Close();
            }
        }

        private bool IsValidPassword(string password)
        {
            // Password should contain at least one uppercase letter, one lowercase letter, one digit, and have a minimum length of 6 characters
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$";
            return Regex.IsMatch(password, pattern);
        }

        private void txtStudentId_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtStudentId.Text == "Student ID")
            {
                txtStudentId.Clear();
            }
        }

        private void txtStudentPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtStudentPassword.Text == "Password")
            {
                txtStudentPassword.Clear();
                txtStudentPassword.PasswordChar = '*';
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
