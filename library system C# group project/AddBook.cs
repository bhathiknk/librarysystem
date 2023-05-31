using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;

namespace library_system_C__group_project
{
    public partial class AddBook : Form
    {

        private dashbord addbookParentForm;
        public AddBook(dashbord addbookParentForm)
        {
            InitializeComponent();
            this.addbookParentForm = addbookParentForm;
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
                con.ConnectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
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

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewbook vb = new viewbook(this);
            this.Hide();
            vb.Show();
            
        }

        private void AddBooksPageExit_Click(object sender, EventArgs e)
        {
            addbookParentForm.Show(); // Show the existing StudentDashBoard form
            this.Close(); // Close the AccountSettings form
        }

        private void btnUploadExcel_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Select an Excel file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Read the Excel file using ExcelDataReader
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            // Read the header row to skip it
                            reader.Read();

                            while (reader.Read())
                            {
                                string bookname = reader.GetValue(0).ToString();  // Convert to string
                                string bookauthor = reader.GetValue(1).ToString();  // Convert to string
                                string bookpublication = reader.GetValue(2).ToString();  // Convert to string
                                DateTime bookdate = DateTime.Parse(reader.GetValue(3).ToString());  // Convert to DateTime
                                int bookprice = int.Parse(reader.GetValue(4).ToString());  // Convert to int
                                int bookquantity = int.Parse(reader.GetValue(5).ToString());  // Convert to int
                                // Insert the book data into the database
                                InsertBookIntoDatabase(bookname, bookauthor, bookpublication, bookdate, bookprice, bookquantity);
                            }
                        }
                    }

                    MessageBox.Show("Data from Excel file uploaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting data from Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InsertBookIntoDatabase(string bookname, string bookauthor, string bookpublication, DateTime bookdate, Int32 bookprice, Int32 bookquantity)
            {
                string connectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
                string query = "INSERT INTO NewBook (bookname, bookauthor, bookpublication, bookdate, bookprice, bookquantity) VALUES (@bookname, @bookauthor, @bookpublication, @bookdate, @bookprice, @bookquantity)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@bookname", bookname);
                        command.Parameters.AddWithValue("@bookauthor", bookauthor);
                        command.Parameters.AddWithValue("@bookpublication", bookpublication);
                        command.Parameters.AddWithValue("@bookdate", bookdate.ToString("yyyy-MM-dd")); // Convert to string in the format compatible with SQL
                        command.Parameters.AddWithValue("@bookprice", bookprice);
                        command.Parameters.AddWithValue("@bookquantity", bookquantity);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions that occur during database insertion
                            MessageBox.Show("Error inserting book data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
    }
}
