using Student_DashBoard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system_C__group_project
{
    public partial class Borrowedbooks : Form
    {
        //this is for backword information auto clear solution
        private StudentDashBoard borrowedbooksParentForm;

        public Borrowedbooks(StudentDashBoard parentForm)
        {
            InitializeComponent();
            borrowedbooksParentForm = parentForm;

        }

        private void BorrowedBooksPreviousBtn_Click(object sender, EventArgs e)
        {
            borrowedbooksParentForm.Show(); // Show the existing StudentDashBoard form
            this.Close(); // Close the AccountSettings form
        }

        private void Borrowedbooks_Load(object sender, EventArgs e)
        {
            string studentID = SessionData.StudentID;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            // Filter the issued books by student ID where the book_return_date is null
            cmd.CommandText = "SELECT * FROM IssueBook WHERE student_id = @student_id AND book_return_date IS NULL";
            cmd.Parameters.AddWithValue("@student_id", studentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            BorrowedBookdataGridView.DataSource = ds.Tables[0];

            // Filter the issued books by student ID where the book_return_date is not null
            cmd.CommandText = "SELECT * FROM IssueBook WHERE student_id = @student_id AND book_return_date IS NOT NULL";
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
        }
    }



}
