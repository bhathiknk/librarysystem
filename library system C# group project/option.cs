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
    public partial class option : Form
    {
        public option()
        {
            InitializeComponent();
        }

        private void btnLibrarian_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn Si = new SignIn();
            Si.Show();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSignin Si = new StudentSignin();
            Si.Show();
        }
    }
}
