using Student_DashBoard;
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
    public static class SessionData // this is for open settion for use unique StudentID on Student enterd StudentID
    {
        public static string StudentID { get; set; }
    }

    public partial class StudentSignin : Form
    {
        private string connectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
        private SqlConnection connection;
        private List<string> studentid { get; set; }

        public StudentSignin()
        {
            InitializeComponent();

            studentid = new List<string>(); // List to store librarian-added student IDs
         
        }

        private void btnStudentSignin_Click(object sender, EventArgs e)
        {
            string studentID = txtStudentId.Text.Trim();
            string password = txtStudentPassword.Text.Trim();
            SessionData.StudentID = studentID;

            // Check if the entered student ID is in the librarianAddedStudentIds list
            if (studentid.Contains(studentID))
            {
                // Create a SQL command to retrieve the student information from "NewStudent" table
                string query = "SELECT * FROM NewStudent WHERE studentid = @studentid";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@studentid", studentID);

                // Execute the SQL command and read the data
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string studentName = reader["studentname"].ToString();
                    string studentDepartment = reader["studentdepartment"].ToString();
                    string studentcontactnumber = reader["studentcontactnumber"].ToString();
                    string studentemail = reader["studentemail"].ToString();

                    // Close the reader
                    reader.Close();

                    // Store the student ID in the SessionData class
                    SessionData.StudentID = studentID;


                    // Create a new SQL command to retrieve the student password from "StudentLoging" table
                    query = "SELECT * FROM StudentLogin WHERE studentid = @studentID AND password = @password";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@studentID", studentID);
                    command.Parameters.AddWithValue("@password", password);

                    // Execute the SQL command and read the data
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Close the sign-in form
                        this.Hide();

                        // Load the student dashboard form and pass the student information
                        StudentDashBoard dashboardForm = new StudentDashBoard(studentName, studentDepartment, studentcontactnumber, studentemail);
                        dashboardForm.ShowDialog();



                        // Clear the sign-in form after the dashboard is closed
                        txtStudentId.Text = "";
                        txtStudentPassword.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Invalid student ID or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Student Not Found", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid student ID or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnStudentSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSignup ssu = new StudentSignup();

            // Pass the librarianAddedStudentIds list to the StudentSignup form
           
            ssu.Show();
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

        private void StudentSignin_Load(object sender, EventArgs e)
        {
            // Initialize and open the database connection
            connection = new SqlConnection(connectionString);
            connection.Open();

            // Load librarian-added student IDs from the database
            Loadstudentid();
        }


        private void Loadstudentid()
        {
            // Create a SQL command to retrieve student IDs
            string query = "SELECT studentid FROM NewStudent";
            SqlCommand command = new SqlCommand(query, connection);

            // Execute the SQL command and read the data
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string studentID = reader["studentid"].ToString();
                studentid.Add(studentID);
            }

            reader.Close();
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
