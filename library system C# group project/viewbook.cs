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
    public partial class viewbook : Form
    {
        public viewbook()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will Deleted. Confirm", "confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
               

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "delete from NewBook where bookid=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                viewbook_Load(this, null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bookname = txtBookName.Text;
                string bookauthor = txtBookAuthor.Text;
                string bookpublication = txtBookPublication.Text;
                string bookdate = txtDatePicker.Text;
                Int64 bookprice = Int64.Parse(txtBookPrice.Text);
                Int64 bookquantity = Int64.Parse(txtBookQuantity.Text);


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update NewBook set bookname ='" + bookname + "' ,bookauthor='" + bookauthor + "',bookpublication='" + bookpublication + "',bookdate='" + bookdate + "',bookprice=" + bookprice + ",bookquantity=" + bookquantity + " where bookid=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                viewbook_Load(this, null);
            }

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBookSearch.Clear();
            panel1.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewbook_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                bookid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel1.Visible=true;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from NewBook where bookid="+bookid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtBookName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtBookAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
            txtBookPublication.Text = ds.Tables[0].Rows[0][3].ToString();
            txtDatePicker.Text = ds.Tables[0].Rows[0][4].ToString();
            txtBookPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtBookQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void txtBookSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtBookSearch.Text != "")
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from NewBook where bookname LIKE '"+txtBookSearch.Text+ "%'";
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
                cmd.CommandText = "select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data Will be Lost", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
