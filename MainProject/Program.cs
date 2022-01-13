using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    static class Program
    {
        public static ScreenMode ScreenMode { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static async void UpdateItemForm(User user, Item item, LoggedUserForm form)
        {
            await Task.Delay(50);
            UpdatedLabel selectedItemForm = new UpdatedLabel(user, item, form);
            selectedItemForm.Dock = DockStyle.Fill;
            Form1.mainForm.pnlContainer.Controls.Add(selectedItemForm);
            Form1.mainForm.pnlContainer.Show();
            Form1.mainForm.pnlContainer.Controls["SelectedItemForm"].BringToFront();
        }
    }

    public enum ScreenMode { Dark, Light }
    public enum Role { None, User, Trader, Moderator, Administrator }
}
