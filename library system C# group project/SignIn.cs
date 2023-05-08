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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text == "UserName")
            {
                txtUserName.Clear();
            }
        }

        private void txtPaasword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPaasword.Text == "Password")
            {
                txtPaasword.Clear();
                txtPaasword.PasswordChar = '*';
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from loginTable where username = '"+txtUserName.Text+"' and password = '"+txtPaasword.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0 )
            {
                this.Hide();
                dashbord dsa = new dashbord();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("wrong Username OR Password" , "Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
           
            
                this.Hide();
                SignUp su = new SignUp();
                su.Show();
            
        }
    }
}
