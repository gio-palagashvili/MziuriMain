using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace MainProject
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            ReadSettings();
        }
        private XMLSetting ReadSettings()
        {
            var doc = new XmlDocument();
            doc.Load("C:/Users/Gio/source/repos/MainProject/MainProject/Settings.xml");
            if (doc.DocumentElement?.ChildNodes == null) return new XMLSetting();
            var text = String.Empty;
            foreach (XmlNode node in doc.DocumentElement?.ChildNodes)
            {
                text = node.InnerText;
            }

            if (text == "true")
            {
                CssDark();
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }            
            
            return new XMLSetting();
        }
        private void CssDark()
        {
            BackColor = ColorTranslator.FromHtml("#1B1C22");
            comboBox1.BackColor = ColorTranslator.FromHtml("#25262C");
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.ForeColor = Color.White;
            label1.ForeColor = Color.White;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            var form1 = new Form1();
            form1.ShowDialog();
        }
    }
}