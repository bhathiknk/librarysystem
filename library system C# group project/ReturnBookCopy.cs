using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system_C__group_project
{
    public partial class ReturnBook : Form
    {
        string randomCode;
        public static string to;

        public ReturnBook()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IssueBook where student_id = '" + txtStudentId.Text + "' and book_return_date is null";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count !=0)
            {
                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or No Book Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            txtStudentId.Clear();
        }
        string bname;
        string bdate;
        string email;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                email = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            txtBookName.Text = bname;
            txtBookIssueDate.Text = bdate;
            txtStudentEmail.Text = email;

        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {
            if (txtStudentId.Text=="")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
                txtEmail.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("bhathikanileshkavindya@gmail.com", "vrwyfpnvmkgsqmke");
            MailMessage mail =new MailMessage("xxxx@gmail.com",txtEmail.Text,"this is for book return notice",txtContent.Text);
            mail.Priority=MailPriority.High;
            smtp.Send(mail);

            MessageBox.Show("Mail Send.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnBook_Load(this, null);
        }

        private void btnOTP_Click(object sender, EventArgs e)
        {

            string from, pass, messagebody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtStudentEmail.Text).ToString();
            from = "bhathikanileshkavindya@gmail.com";
            pass = "vrwyfpnvmkgsqmke";
            messagebody = "Return Book OTP" + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Your book return OTP - ";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from,pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Code send Successfully");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        
        }

      
       
        private void btnVerifyReturn_Click(object sender, EventArgs e)
        {
            if(randomCode ==(txtVerify.Text).ToString())
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "update IssueBook set book_return_date ='" + dateTimePicker2.Text + "' where student_id='" + txtStudentId.Text + "' and id =" + rowid + "";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Return Succesful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReturnBook_Load(this, null);
            }
        }

        private void txtVerify_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtVerify.Text == "Enter the OTP")
            {
               txtVerify.Clear();
            }
        }
    }
}
