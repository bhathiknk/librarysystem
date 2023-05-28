﻿using System;
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
    public partial class AddStudent : Form
    {
        private dashbord addstudentParentForm;
        public AddStudent(dashbord addstudentParentForm)
        {
            InitializeComponent();
            this.addstudentParentForm = addstudentParentForm;
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtStudentId.Clear();
            txtDepatment.Clear();
            txtContactNumber.Clear();
            //txtEmail.Clear();
            txtEmail.Text = "";
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text!="" &&  txtStudentId.Text!="" && txtDepatment.Text!="" && txtContactNumber.Text!="" && txtEmail.Text!="")
            {
                string name = txtStudentName.Text;
                string id = txtStudentId.Text;
                string department = txtDepatment.Text;
                Int64 contactnumber = Int64.Parse(txtContactNumber.Text);
                string email = txtEmail.Text;


                // Validate email format using regular expressions
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (studentname,studentid,studentdepartment,studentcontactnumber,studentemail) values ('" + name + "','" + id + "','" + department + "'," + contactnumber + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear all text fields
                txtStudentName.Clear();
                txtStudentId.Clear();
                txtDepatment.Clear();
                txtContactNumber.Clear();
                txtEmail.Clear();
            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields", "Suggest",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                // Regular expression pattern for email validation
                string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudentInformation vsi = new ViewStudentInformation(this);
            this.Hide();
            vsi.Show();
            
        }

        private void AddStudentExitToDashBoard_Click(object sender, EventArgs e)
        {
            addstudentParentForm.Show(); // Show the existing StudentDashBoard form
            this.Close(); // Close the AccountSettings form
        }
    }
}
