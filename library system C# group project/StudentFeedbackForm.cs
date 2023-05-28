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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace library_system_C__group_project
{
    public partial class StudentFeedbackForm : Form
    {
        private SqlConnection connection;
        private string connectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
        string studentID = SessionData.StudentID; // Retrieve the logged-in student ID
        private string studentName;
        private string studentEmail;

        //this is for backword information auto clear solution
        private StudentDashBoard studentfeedbackParentForm;
        private int maxFeedbackLength = 400; // Maximum allowed feedback length
        public StudentFeedbackForm(string email, string name, StudentDashBoard parentForm)
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            connection.Open();

            studentName = name;
            studentEmail = email;
            studentfeedbackParentForm = parentForm;
          
        }
        public StudentFeedbackForm()
        {
            InitializeComponent();
        }

        private void StudentBookSearchPrevioustoStudentDashBoard_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void StudentFeedbackForm_Load(object sender, EventArgs e)
        {
            txtStudentName.Text = studentName;
            txtStudentEmail.Text = studentEmail;
            txtFeedbackMessage.TextChanged += txtFeedbackMessage_TextChanged;

        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFeedbackMessage_TextChanged(object sender, EventArgs e)
        {
            // Check if the feedback message exceeds the maximum length
            if (txtFeedbackMessage.Text.Length > maxFeedbackLength)
            {
                // Truncate the text to the maximum length
                txtFeedbackMessage.Text = txtFeedbackMessage.Text.Substring(0, maxFeedbackLength);
                txtFeedbackMessage.SelectionStart = maxFeedbackLength; // Set the cursor position at the end
                txtFeedbackMessage.SelectionLength = 0;

                // Show a message to the user
                MessageBox.Show("Maximum feedback length exceeded. Only 400 characters allowed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

            private void btnSubmit_Click(object sender, EventArgs e)
        {
            
     
            string feedbackMessage = txtFeedbackMessage.Text.Trim();

            // Save the feedback to the database
            SaveFeedback(studentID, studentName, studentEmail, feedbackMessage);

            MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the form fields
            txtFeedbackMessage.Text = "";
        }

        private void SaveFeedback(string studentID, string studentName, string studentEmail, string feedbackMessage)
        {
            // Create a SQL command to insert the feedback into the "Feedback" table
            string query = "INSERT INTO Feedback (studentId, studentName, studentEmail, studentFeedback,feedback_date) " +
                           "VALUES (@studentId, @studentName, @studentEmail, @feedbackMessage,@feedbackDate)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentID", studentID);
            command.Parameters.AddWithValue("@studentName", studentName);
            command.Parameters.AddWithValue("@studentEmail", studentEmail);
            command.Parameters.AddWithValue("@feedbackMessage", feedbackMessage);
            command.Parameters.AddWithValue("@feedbackDate", DateTime.Now); // Add current date and time

            // Execute the SQL command
            command.ExecuteNonQuery();
        }

        private void StudentBookSearchPrevioustoStudentDashBoard_Click_1(object sender, EventArgs e)
        {
            studentfeedbackParentForm.Show(); // Show the existing StudentDashBoard form
            this.Close(); // Close the AccountSettings form
        }
    }
}
