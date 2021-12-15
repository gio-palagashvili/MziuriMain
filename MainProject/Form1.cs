using System;
using System.Windows.Forms;

namespace MainProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void register_Click(object sender, EventArgs e)
        {
            Hide();
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void Log_Click(object sender, EventArgs e)
        {
            var mail = textBox1.Text;
            var password = textBox2.Text;
            
            if (password.Length > 0 && mail.Length > 0)
            {
                if (SQLprocedure.LogIn(mail, password))
                {
                    textBox1.Text = "logged in";
                }
            }
        }
    }
}