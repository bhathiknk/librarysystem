using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_system_C__group_project
{
    public partial class dashbord : Form
    {
        public dashbord()
        {
            InitializeComponent();
        }

        

        private void addNewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBook abs = new AddBook(this);
            this.Hide();
            abs.Show();
        }

        

        

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent ast =new AddStudent(this);
            this.Hide();
            ast.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        

       

       

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)// Exit finish
        {
           LibrarianFeedbackForm lff = new LibrarianFeedbackForm(this);
            this.Hide();
            lff.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)// finish
        {
            AddBook addBook =new AddBook(this);
            this.Hide();
            addBook.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStudent =new AddStudent(this);
            this.Hide();
            addStudent.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks ib = new IssueBooks(this);
            this.Hide();
            ib.Show();

        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook returnBook = new ReturnBook(this);
            this.Hide();
            returnBook.Show();
        }

        private void completeBooksDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CompleteBookDetails cbd = new CompleteBookDetails(this);
            this.Hide();
            cbd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
