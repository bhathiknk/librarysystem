using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system_C__group_project
{
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtStudentIdSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtStudentIdSearch.Text != "")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from NewStudent where studentid LIKE '" + txtStudentIdSearch.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from NewStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel1.Visible = true;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from NewStudent where stuid ="+ bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtStudentId.Text = ds.Tables[0].Rows[0][2].ToString();
            txtStudentDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
            txtContactNumber.Text = ds.Tables[0].Rows[0][4].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string studentname = txtStudentName.Text;
                string studentid = txtStudentId.Text;
                string studentdepartment = txtStudentDepartment.Text;
                Int64 contactnumber = Int64.Parse(txtContactNumber.Text);
                string studentemail = txtEmail.Text;
                
               


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update Newstudent set studentname ='" + studentname + "' ,studentid='" + studentid + "',studentdepartment='" + studentdepartment + "',studentcontactnumber=" + contactnumber + ",studentemail='" + studentemail + "' where stuid=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudentInformation_Load(this, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewStudentInformation_Load(this, null);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will Deleted. Confirm", "confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "delete from NewStudent where stuid=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudentInformation_Load(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Unsaved Data Will be Lost","Are you sure?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
        }
    }
  
}

