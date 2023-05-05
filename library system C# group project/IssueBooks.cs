using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system_C__group_project
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void txtStudentContact_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand("select bookname from NewBook",con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for (int i = 0; i< Sdr.FieldCount; i++)
                {
                    txtBookName.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();


        }

        int count;
        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            if(txtStudentId.Text !="")
            {
                string sid = txtStudentId.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where studentid = '" + sid + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                //------------------------------------------------------------------------------------------------------------------------

                //code to count how many book has been issued on this student number

                cmd.CommandText = "select count (student_id) from IssueBook where student_id = '" + sid + "' and book_return_date is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1);

                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());


                //--------------------------------------------------------------------------------------------------------------------------------


                if (DS.Tables[0].Rows.Count !=0)
                {
                    txtStudentName.Text = DS.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = DS.Tables[0].Rows[0][3].ToString();
                    txtStudentContact.Text = DS.Tables[0].Rows[0][4].ToString();
                    txtStudentEmail.Text = DS.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    txtStudentName.Clear();
                    txtDepartment.Clear();
                    txtStudentContact.Clear();
                    txtStudentEmail.Clear();
                    MessageBox.Show("Invalid Student ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                 
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {
                if (txtBookName.SelectedIndex != -1 && count <= 1)
                {
                    string studentid = txtStudentId.Text;
                    string studentname = txtStudentName.Text;
                    string department = txtDepartment.Text;
                    Int64 contact = Int64.Parse(txtStudentContact.Text);
                    string email = txtStudentEmail.Text;
                    string bookname = txtBookName.Text;
                    string bookIssueDate = dateTimePicker1.Text;

                    string sid = txtStudentId.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "Insert into IssueBook (student_id,student_name,student_department,student_contact,student_email,book_name,book_issue_date) values ('" + studentid + "','" + studentname + "','" + department + "'," + contact + ",'" + email + "','" + bookname + "','" + bookIssueDate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                }
                else
                {
                    MessageBox.Show("Select Book. OR Maximum number of Book Has been ISSUED", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Enter Valid Student ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {
            if(txtStudentId.Text =="")
            {
                txtStudentName.Clear();
                txtDepartment.Clear();
                txtStudentContact.Clear();
                txtStudentEmail.Clear(); 
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure want to Exit?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

