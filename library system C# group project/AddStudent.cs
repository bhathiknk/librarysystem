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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
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

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (studentname,studentid,studentdepartment,studentcontactnumber,studentemail) values ('" + name + "','" + id + "','" + department + "'," + contactnumber + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields", "Suggest",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
