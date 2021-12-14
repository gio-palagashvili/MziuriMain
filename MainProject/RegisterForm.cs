using System;
using System.Drawing;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.String;

namespace MainProject
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, System.EventArgs e)
        {
            label3.Hide();
        }
        private bool EmailValidation(string pEmail)
        {
            return Regex.IsMatch(pEmail,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        private void log_Click(object sender, System.EventArgs e)
        {
            Hide();
            var form1 = new Form1();
            form1.ShowDialog();
        }

        private void register_Click_1(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
            var name = textBox1.Text;
            var lastname = textBox2.Text;
            var phoneNumber = textBox3.Text.Length > 0 && textBox3.Text.Length < 15? textBox3.Text : "";
            var email = textBox4.Text;
            var password = textBox5.Text;
            var rPassword = textBox6.Text;
           
            if (name.Length == 0 || lastname.Length  == 0 || email.Length == 0 || password.Length == 0 || rPassword.Length == 0)
            {
                label3.Show();
                label3.Text = "only phone number field can be empty";
            }

            if (!EmailValidation(email))
            {
                label3.Text = "invalid email";label3.Show();
            }
            else
            {
                label3.Text = Empty;
                if (password == rPassword)
                {
                    label3.Text = Empty;
                }
                label3.Text = "passwords don't match";label3.Show();
            }
           
        }
    }

}