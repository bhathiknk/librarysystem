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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace library_system_C__group_project
{
    public partial class CompleteBookDetails : Form
    {
        private dashbord completebookParentForm;
        public CompleteBookDetails(dashbord completebookParentForm)
        {
            InitializeComponent();
            this.completebookParentForm = completebookParentForm;
        }

        private void CompleteBookDetails_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from IssueBook where book_return_date is null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            cmd.CommandText = "select * from IssueBook where book_return_date is not null";
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView2.DataSource = ds1.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text != "")

            {
                string searchTerm = textBox1.Text;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM IssueBook WHERE student_id LIKE @searchTerm AND  book_return_date is  NULL";
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
            if (textBox1.Text != "")

            {
                string searchTerm = textBox1.Text;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM IssueBook WHERE student_id LIKE @searchTerm AND  book_return_date is NOT  NULL";
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView2.DataSource = ds.Tables[0];

            }

            if  (textBox1.Text == "")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from IssueBook where book_return_date is null";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            if (textBox1.Text == "")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from IssueBook where book_return_date is not null";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView2.DataSource = ds.Tables[0];
            }

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Search Student ID")
            {
                textBox1.Clear();
            }
        }

        private void completebookpreview_Click(object sender, EventArgs e)
        {
            completebookParentForm.Show(); // Show the existing StudentDashBoard form
            this.Close(); // Close the AccountSettings form
        }
    }
}
