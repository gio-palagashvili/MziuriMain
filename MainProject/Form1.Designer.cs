
namespace MainProject
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(99, 168);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 25);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(99, 216);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 25);
            this.textBox2.TabIndex = 1;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.ForeColor = System.Drawing.Color.Black;
            this.Username.Location = new System.Drawing.Point(96, 152);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(55, 13);
            this.Username.TabIndex = 2;
            this.Username.Text = "Username";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.ForeColor = System.Drawing.Color.Black;
            this.password.Location = new System.Drawing.Point(96, 199);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(53, 13);
            this.password.TabIndex = 3;
            this.password.Text = "Password";
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Log.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Log.Location = new System.Drawing.Point(99, 271);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(186, 32);
            this.Log.TabIndex = 4;
            this.Log.Text = "Log in";
            this.Log.UseVisualStyleBackColor = false;
            this.Log.Click += new System.EventHandler(this.Log_Click);
            // 
            // register
            // 
            this.register.AutoSize = true;
            this.register.ForeColor = System.Drawing.Color.Blue;
            this.register.Location = new System.Drawing.Point(99, 252);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(46, 13);
            this.register.TabIndex = 5;
            this.register.Text = "Register";
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 513);
            this.Controls.Add(this.register);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (0)))), ((int) (((byte) (3)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Button Log;
        private System.Windows.Forms.Label register;
    }
}

