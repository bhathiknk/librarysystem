using Student_DashBoard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace library_system_C__group_project
{

    public partial class AccountSettings : Form
    {

        private string studentEmail;
        private string studentContactNumber;
        private string studentDepartment;
        private string studentName;
        string studentID = SessionData.StudentID; // Retrieve the logged-in student ID
        private StudentDashBoard accountsettingParentForm;

        //this is for backword information auto clear solution
       

        public AccountSettings(string email, string contactNumber, string department, string studentName, StudentDashBoard parentForm)
        {
            InitializeComponent();
            // Assign the passed student information to the variables
            studentEmail = email;
            studentContactNumber = contactNumber;
            studentDepartment = department;
            this.studentName = studentName;
            accountsettingParentForm = parentForm; // Assign the reference to the parent form
        }


        private void AccountSettings_Load(object sender, EventArgs e)
        {
            // Use the retrieved student information to populate the corresponding text boxes or labels in the AccountSettings form
            studentEmailUpdateTextBox.Text = studentEmail;
            studentMobileNumberUpdatetxtBox.Text = studentContactNumber;
            DepartmentNameUpdatetxtBox.Text = studentDepartment;
            txtname.Text = studentName;


        }
        private void AccountSettingsPeviousButtons_Click(object sender, EventArgs e)
        {

            accountsettingParentForm.Show(); // Show the existing StudentDashBoard form
            this.Close(); // Close the AccountSettings form
        }

        private void StudentAccountSettingsUpdatebtn_Click(object sender, EventArgs e)
        {
            

            // Check if any of the required textboxes are empty
            if (string.IsNullOrEmpty(studentEmailUpdateTextBox.Text) || string.IsNullOrEmpty(studentMobileNumberUpdatetxtBox.Text) || string.IsNullOrEmpty(DepartmentNameUpdatetxtBox.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string email = studentEmailUpdateTextBox.Text;
                string contactNumber = studentMobileNumberUpdatetxtBox.Text;
                string department = DepartmentNameUpdatetxtBox.Text;


                if (string.IsNullOrEmpty(studentID))
                {
                    MessageBox.Show("No logged-in student found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the NewStudent table in the database
                string connectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Update the student record in the NewStudent table
                    string updateQuery = "UPDATE NewStudent SET studentemail = @Email, studentcontactnumber = @ContactNumber, studentdepartment = @Department WHERE studentid = @StudentID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@ContactNumber", contactNumber);
                        command.Parameters.AddWithValue("@Department", department);
                        command.Parameters.AddWithValue("@StudentID", studentID);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account settings updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update account settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating account settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnupdatepassword_Click(object sender, EventArgs e)
        {
            string studentID = SessionData.StudentID; // Retrieve the logged-in student ID
            string oldPassword = studentOldPasswordUpdatetxtBox.Text;
            string newPassword = studentnewPasswordUpdatetxtbox.Text;
            string confirmPassword = studentConfirmpasswordtxtBox.Text;

            // Check if any of the password fields are empty
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all the password fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Verify if the entered old password matches the one stored in the database for the student
                string connectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT password FROM StudentLogin WHERE studentid = @StudentID";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", studentID);

                        string storedPassword = command.ExecuteScalar()?.ToString();

                        // Check if the stored password is null or empty
                        if (string.IsNullOrEmpty(storedPassword))
                        {
                            MessageBox.Show("Invalid student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Check if the entered old password matches the stored password
                        if (storedPassword != oldPassword)
                        {
                            MessageBox.Show("Invalid old password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // Check if the new password and confirm password match
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("New password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the password in the StudentLogin table
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE StudentLogin SET password = @NewPassword WHERE studentid = @StudentID";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@StudentID", studentID);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
 }
 
    






