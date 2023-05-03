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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                string bookname = txtBookName.Text;
                string bookauthor = txtAuthor.Text;
                string bookpublication = txtPublication.Text;
                string bookdate = dateTimePicker1.Text;
                Int64 bookprice = Int64.Parse(txtPrice.Text);
                Int64 bookquantity = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = BNK;database = LMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook(bookname,bookauthor,bookpublication,bookdate,bookprice,bookquantity) values ('" + bookname + "','" + bookauthor + "','" + bookpublication + "','" + bookdate + "','" + bookprice + "','" + bookquantity + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublication.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty Field Not Allowed", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will DELETE your Unsaved DATA.","Area you sure?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void AddBook_Load(object sender, EventArgs e)
        {

        }
    }
}
