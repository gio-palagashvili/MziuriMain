using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

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
            ReadSettings();
        }

        private XMLSetting ReadSettings()
        {
            var doc = new XmlDocument();
            doc.Load("../../Settings.xml");
            if (doc.DocumentElement?.ChildNodes == null) return new XMLSetting();
            var text = string.Empty;
            
            foreach (XmlNode node in doc.DocumentElement?.ChildNodes)
            {
                text = node.InnerText;
            }

            if (text == "true")
            {
                CssDark();
            }
            else
            {
                CssLight();
            }            
            
            return new XMLSetting();
        }
        private void CssDark()
        {
            BackColor = ColorTranslator.FromHtml("#1B1C22");
            Username.ForeColor = Color.White;
            password.ForeColor = Color.White;
            textBox1.BackColor = ColorTranslator.FromHtml("#25262C");
            textBox2.BackColor = ColorTranslator.FromHtml("#25262C");
            textBox1.ForeColor = Color.White;            
            textBox2.ForeColor = Color.White;
            Log.BackColor = ColorTranslator.FromHtml("#3077E3");
            Log.FlatStyle = FlatStyle.Flat;
            Log.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#25262C");
            register.ForeColor = Color.White;
            Log.Font = new Font("Arial", 10,FontStyle.Bold);
            label1.Font = new Font("Arial", 12, FontStyle.Bold);
        }
        private void CssLight()
        {
            BackColor = ColorTranslator.FromHtml("#FAFBFD");
            textBox1.BackColor = ColorTranslator.FromHtml("#FAFAFA");
            textBox2.BackColor = ColorTranslator.FromHtml("#25262C");
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Hide();
            var settings = new Settings();
            settings.ShowDialog();
        }
    }
}