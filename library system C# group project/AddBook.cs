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

                    MessageBox.Show("Data from Excel file Inseeted And Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting data from Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InsertBookIntoDatabase(string bookname, string bookauthor, string bookpublication, DateTime bookdate, Int32 bookprice, Int32 bookquantity)
        {
            //this for if admin updated there book record and insert new recode
            string connectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
            string selectQuery = "SELECT COUNT(*) FROM NewBook WHERE bookname = @bookname";
            string insertQuery = "INSERT INTO NewBook (bookname, bookauthor, bookpublication, bookdate, bookprice, bookquantity) VALUES (@bookname, @bookauthor, @bookpublication, @bookdate, @bookprice, @bookquantity)";
            string updateQuery = "UPDATE NewBook SET bookauthor = @bookauthor, bookpublication = @bookpublication, bookdate = @bookdate, bookprice = @bookprice, bookquantity = @bookquantity WHERE bookname = @bookname";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the book already exists
                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@bookname", bookname);

                    int count = (int)selectCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        // Update the book details
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@bookname", bookname);
                            updateCommand.Parameters.AddWithValue("@bookauthor", bookauthor);
                            updateCommand.Parameters.AddWithValue("@bookpublication", bookpublication);
                            updateCommand.Parameters.AddWithValue("@bookdate", bookdate.ToString("yyyy-MM-dd"));
                            updateCommand.Parameters.AddWithValue("@bookprice", bookprice);
                            updateCommand.Parameters.AddWithValue("@bookquantity", bookquantity);

                            updateCommand.ExecuteNonQuery();
                        }


                    }
                    else
                    {
                        // Insert the book details
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@bookname", bookname);
                            insertCommand.Parameters.AddWithValue("@bookauthor", bookauthor);
                            insertCommand.Parameters.AddWithValue("@bookpublication", bookpublication);
                            insertCommand.Parameters.AddWithValue("@bookdate", bookdate.ToString("yyyy-MM-dd"));
                            insertCommand.Parameters.AddWithValue("@bookprice", bookprice);
                            insertCommand.Parameters.AddWithValue("@bookquantity", bookquantity);

                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
