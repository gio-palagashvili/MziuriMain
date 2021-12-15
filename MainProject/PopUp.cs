using System.Windows.Forms;

namespace MainProject
{
    public partial class PopUp : Form
    {
        public string text { get; set; }
        public string route { get; set; }
        public PopUp()
        {
            InitializeComponent();
            label2.Text = text;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            switch (route)
            {
                case "login":
                    Hide();
                    var form1 = new Form1();
                    form1.ShowDialog();
                    break;
            }
        }
    }
}