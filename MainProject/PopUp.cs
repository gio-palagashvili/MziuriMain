using System.Windows.Forms;

namespace MainProject
{
    public partial class PopUp : Form
    {
        public string text { get; set; }
        public string Route { get; set; }
        public PopUp()
        {
            InitializeComponent();
            label2.Text = text;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            switch (Route)
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