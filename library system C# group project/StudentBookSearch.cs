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
    public partial class StudentBookSearch : Form
    {
        //this is for backword information auto clear solution
        private StudentDashBoard studentbooksearchParentForm;
        public StudentBookSearch(StudentDashBoard parentForm)
        {
            InitializeComponent();
            studentbooksearchParentForm= parentForm;
        }

        private void StudentBookSearch_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        int bookid;
        Int64 rowid;

      

        private void StudentBookSearchPrevioustoStudentDashBoard_Click(object sender, EventArgs e)
        {
            studentbooksearchParentForm.Show(); // Show the existing StudentDashBoard form
            this.Close(); // Close the AccountSettings form 

        }

        private void Refreshbtn_Click_1(object sender, EventArgs e)
        {
            TxtBooksearch.Clear();
            
        }

        private void TxtBooksearch_TextChanged_1(object sender, EventArgs e)
        {

            if (TxtBooksearch.Text != "")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from NewBook where bookname LIKE '" + TxtBooksearch.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
