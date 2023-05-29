using library_system_C__group_project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Student_DashBoard
{
    public partial class StudentDashBoard : Form
    {
        string studentName;
        string studentDepartment;
        string studentcontactnumber;
        string studentemail;
        string studentID = SessionData.StudentID; // Retrieve the logged-in student ID


        public StudentDashBoard()
        {
            InitializeComponent();
        }
        public StudentDashBoard( string name , string studentdepartment, string contactnumber,string email)
        {
            InitializeComponent();

            // Assign the passed student information to the variables
            studentName = name;
            studentDepartment = studentdepartment;
            studentcontactnumber = contactnumber;
            studentemail = email;

        }

        public void UpdateStudentInformation(string email, string contactNumber, string department, string name)
        {
            // Update the student information in the form
            studentemail = email;
            studentcontactnumber = contactNumber;
            studentDepartment = department;
            studentName = name;

            // Update the text boxes or labels in the form
            txtStudentName.Text = studentName;
            txtStudentDepartment.Text = studentDepartment;
            txtStudentContact.Text = studentcontactnumber;
            txtStudentEmail.Text = studentemail;
        }

        private void StudentDashBoard_Load(object sender, EventArgs e)
        {
            txtStudentName.Text = studentName;
            txtStudentDepartment.Text = studentDepartment;
            txtStudentContact.Text= studentcontactnumber;
            txtStudentEmail.Text= studentemail;
           
        }

        private void StudentAccountSettings_Click(object sender, EventArgs e)
        {
            AccountSettings objAS = new AccountSettings(studentemail, studentcontactnumber, studentDepartment, studentName, this);
            this.Hide();
            objAS.Show();
        }

        private void StudentBorrowedbooks_Click(object sender, EventArgs e)
        {
            Borrowedbooks bb = new Borrowedbooks(this);
            this.Hide();
            bb.Show();
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentBookSearch sbs = new StudentBookSearch(this);
            this.Hide();
            sbs.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentFeedbackForm sfbf = new StudentFeedbackForm(studentemail,studentName,this);
            this.Hide();
            sfbf.Show();
            
        }
    }
}
