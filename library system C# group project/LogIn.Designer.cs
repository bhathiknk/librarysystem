namespace library_system_C__group_project
{
    partial class Form1
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
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.loginbutton = new System.Windows.Forms.Button();
            this.signupbutton = new System.Windows.Forms.Button();
            this.closebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(68, 192);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(238, 22);
            this.username.TabIndex = 0;
            this.username.Text = "username";
            this.username.MouseClick += new System.Windows.Forms.MouseEventHandler(this.username_MouseClick);
            this.username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.username.MouseEnter += new System.EventHandler(this.username_MouseEnter);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(68, 247);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(238, 22);
            this.password.TabIndex = 2;
            this.password.Text = "password";
            this.password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.password_MouseClick);
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            this.password.MouseEnter += new System.EventHandler(this.password_MouseEnter);
            // 
            // loginbutton
            // 
            this.loginbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginbutton.Location = new System.Drawing.Point(122, 331);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(141, 37);
            this.loginbutton.TabIndex = 3;
            this.loginbutton.Tag = "";
            this.loginbutton.Text = "log in\r\n";
            this.loginbutton.UseVisualStyleBackColor = true;
            this.loginbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // signupbutton
            // 
            this.signupbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.signupbutton.Location = new System.Drawing.Point(122, 389);
            this.signupbutton.Name = "signupbutton";
            this.signupbutton.Size = new System.Drawing.Size(141, 37);
            this.signupbutton.TabIndex = 4;
            this.signupbutton.Text = "sign up\r\n";
            this.signupbutton.UseVisualStyleBackColor = true;
            // 
            // closebutton
            // 
            this.closebutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closebutton.Location = new System.Drawing.Point(325, 12);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(34, 40);
            this.closebutton.TabIndex = 5;
            this.closebutton.Text = "X";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 514);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.signupbutton);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button signupbutton;
        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.Button loginbutton;
    }
}

