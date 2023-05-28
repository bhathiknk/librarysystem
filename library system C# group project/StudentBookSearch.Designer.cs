using System;

namespace library_system_C__group_project
{
    partial class StudentBookSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentBookSearch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Refreshbtn = new System.Windows.Forms.Button();
            this.TxtBooksearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.StudentBookSearchPrevioustoStudentDashBoard = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1520, 59);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(761, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Books";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(294, 188);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1195, 416);
            this.dataGridView1.TabIndex = 4;
            // 
            // Refreshbtn
            // 
            this.Refreshbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(157)))));
            this.Refreshbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Refreshbtn.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold);
            this.Refreshbtn.ForeColor = System.Drawing.SystemColors.Control;
            this.Refreshbtn.Location = new System.Drawing.Point(1008, 98);
            this.Refreshbtn.Name = "Refreshbtn";
            this.Refreshbtn.Size = new System.Drawing.Size(127, 33);
            this.Refreshbtn.TabIndex = 8;
            this.Refreshbtn.Text = "Refresh";
            this.Refreshbtn.UseVisualStyleBackColor = false;
            this.Refreshbtn.Click += new System.EventHandler(this.Refreshbtn_Click_1);
            // 
            // TxtBooksearch
            // 
            this.TxtBooksearch.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBooksearch.Location = new System.Drawing.Point(710, 93);
            this.TxtBooksearch.Name = "TxtBooksearch";
            this.TxtBooksearch.Size = new System.Drawing.Size(266, 39);
            this.TxtBooksearch.TabIndex = 7;
            this.TxtBooksearch.TextChanged += new System.EventHandler(this.TxtBooksearch_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(551, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 36);
            this.label2.TabIndex = 6;
            this.label2.Text = "Book Name:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.panel3.Controls.Add(this.StudentBookSearchPrevioustoStudentDashBoard);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 677);
            this.panel3.TabIndex = 9;
            // 
            // StudentBookSearchPrevioustoStudentDashBoard
            // 
            this.StudentBookSearchPrevioustoStudentDashBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.StudentBookSearchPrevioustoStudentDashBoard.FlatAppearance.BorderSize = 0;
            this.StudentBookSearchPrevioustoStudentDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StudentBookSearchPrevioustoStudentDashBoard.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentBookSearchPrevioustoStudentDashBoard.ForeColor = System.Drawing.Color.White;
            this.StudentBookSearchPrevioustoStudentDashBoard.Image = ((System.Drawing.Image)(resources.GetObject("StudentBookSearchPrevioustoStudentDashBoard.Image")));
            this.StudentBookSearchPrevioustoStudentDashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StudentBookSearchPrevioustoStudentDashBoard.Location = new System.Drawing.Point(0, 0);
            this.StudentBookSearchPrevioustoStudentDashBoard.Margin = new System.Windows.Forms.Padding(4);
            this.StudentBookSearchPrevioustoStudentDashBoard.Name = "StudentBookSearchPrevioustoStudentDashBoard";
            this.StudentBookSearchPrevioustoStudentDashBoard.Size = new System.Drawing.Size(237, 95);
            this.StudentBookSearchPrevioustoStudentDashBoard.TabIndex = 5;
            this.StudentBookSearchPrevioustoStudentDashBoard.Text = "      Previous";
            this.StudentBookSearchPrevioustoStudentDashBoard.UseVisualStyleBackColor = true;
            this.StudentBookSearchPrevioustoStudentDashBoard.Click += new System.EventHandler(this.StudentBookSearchPrevioustoStudentDashBoard_Click);
            // 
            // StudentBookSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1520, 736);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Refreshbtn);
            this.Controls.Add(this.TxtBooksearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentBookSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentBookSearch";
            this.Load += new System.EventHandler(this.StudentBookSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ViewBookExitToDashBoard_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtBookSearch_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Refreshbtn;
        private System.Windows.Forms.TextBox TxtBooksearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button StudentBookSearchPrevioustoStudentDashBoard;
    }
}