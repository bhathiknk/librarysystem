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
    public partial class LibrarianFeedbackForm : Form
    {
        private dashbord feedbackParentForm;
        private SqlConnection connection;
        private string connectionString = "data source = 168.138.188.44,1434;database = LMS;user id = sa;password = P4ssword;";
        public LibrarianFeedbackForm(dashbord feedbackParentForm)
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            connection.Open();
            this.feedbackParentForm = feedbackParentForm;
        }

        private void LibrarianFeedbackForm_Load(object sender, EventArgs e)
        {
            LoadFeedbackData();
        }

        private void LoadFeedbackData()
        {
            string query = "SELECT studentId AS 'Student ID' , studentName AS 'Student Name', studentEmail AS 'Student Email', studentFeedback AS 'Feedback Message', feedback_date AS 'Date' FROM Feedback ORDER BY feedback_date DESC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            List<MyFeedbackData> feedbackDataList = dataTable.AsEnumerable().Select(row => new MyFeedbackData
            {
                studentId = row.Field<string>("Student ID"),
                studentName = row.Field<string>("Student Name"),
                studentEmail = row.Field<string>("Student Email"),
                studentFeedback = row.Field<string>("Feedback Message"),
                feedback_date = row.Field<DateTime>("Date")
            }).ToList();

            dataGridView1.Columns.Clear();

            dataGridView1.VirtualMode = true;
            dataGridView1.CellValueNeeded += DataGridView1_CellValueNeeded;
            dataGridView1.RowCount = feedbackDataList.Count;
            dataGridView1.DataSource = feedbackDataList;

            // Set the AutoSizeMode property after binding the data
            dataGridView1.AutoResizeColumns();

           
        }

        private void DataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            List<MyFeedbackData> feedbackDataList = (List<MyFeedbackData>)dataGridView1.DataSource;

            if (e.RowIndex >= 1 && e.RowIndex < feedbackDataList.Count)
            {
                MyFeedbackData dataItem = feedbackDataList[e.RowIndex];

                // Populate the cell value based on the column index
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = dataItem.studentId;
                        break;
                    case 1:
                        e.Value = dataItem.studentName;
                        break;
                    case 2:
                        e.Value = dataItem.studentEmail;
                        break;
                    case 3:
                        e.Value = dataItem.studentFeedback;
                        break;
                    case 4:
                        e.Value = dataItem.feedback_date.ToString("yyyy-MM-dd");
                        break;
                }
            }
        }

        public class MyFeedbackData
        {
            public string studentId { get; set; }
            public string studentName { get; set; }
            public string studentEmail { get; set; }
            public string studentFeedback { get; set; }
            public DateTime feedback_date { get; set; }
        }

        private void feedbackpreview_Click(object sender, EventArgs e)
        {
            feedbackParentForm.Show(); // Show the existing StudentDashBoard form
            this.Close(); // Close the AccountSettings form
        }
    }
}
