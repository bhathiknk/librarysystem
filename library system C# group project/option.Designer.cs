﻿namespace library_system_C__group_project
{
    partial class option
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(option));
            this.btnLibrarian = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnStudent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLibrarian
            // 
            this.btnLibrarian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLibrarian.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLibrarian.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibrarian.ForeColor = System.Drawing.Color.Black;
            this.btnLibrarian.Location = new System.Drawing.Point(97, 214);
            this.btnLibrarian.Name = "btnLibrarian";
            this.btnLibrarian.Size = new System.Drawing.Size(254, 62);
            this.btnLibrarian.TabIndex = 0;
            this.btnLibrarian.Text = "Librarian";
            this.btnLibrarian.UseVisualStyleBackColor = false;
            this.btnLibrarian.Click += new System.EventHandler(this.btnLibrarian_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.ForeColor = System.Drawing.Color.Black;
            this.btnStudent.Location = new System.Drawing.Point(97, 339);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(254, 62);
            this.btnStudent.TabIndex = 1;
            this.btnStudent.Text = "Student";
            this.btnStudent.UseVisualStyleBackColor = false;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Select Who You Are?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(422, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStudent);
            this.Controls.Add(this.btnLibrarian);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "option";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "option";
            this.Load += new System.EventHandler(this.option_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLibrarian;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Label label1;
    }
}