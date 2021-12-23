using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    public partial class LoggedUserForm : UserControl
    {
        private User _currentUser;
        private List<Item> _Items;
        public LoggedUserForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadItems();
            _Items = SQLprocedure.SelectAllItem(_currentUser.Id);
            SetColors();
            BalanceAmont.Text = Math.Round(_currentUser.Balance, 2).ToString() + " ₾";
            UserDataLabel.Text = $"Role: {_currentUser.Role}\nFName: {_currentUser.Name} {_currentUser.Lastname}";
        }

        public void UpdateUser()
        {
            _currentUser = SQLprocedure.GetUser(_currentUser.Mail);
            LoadItems();
            _Items = SQLprocedure.SelectAllItem(_currentUser.Id);
            SetColors();
            BalanceAmont.Text = Math.Round(_currentUser.Balance, 2).ToString() + " ₾";
            UserDataLabel.Text = $"Role: {_currentUser.Role}\nFName: {_currentUser.Name} {_currentUser.Lastname}";
        }
        private void SetColors()
        {
            if (Program.ScreenMode == ScreenMode.Dark)
            {
                BackColor = Color.Black;
                NoItemsLabel.BackColor = Color.Black;
                NoItemsLabel.ForeColor = Color.White;
                WelcomeLabel.BackColor = Color.Black;
                WelcomeLabel.ForeColor = Color.White;
                UserDataLabel.BackColor = Color.Black;
                UserDataLabel.ForeColor = Color.White;
                CategoryLabel.BackColor = Color.Black;
                CategoryLabel.ForeColor = Color.White;
                MinLabel.BackColor = Color.Black;
                MinLabel.ForeColor = Color.White;
                MaxLabel.BackColor = Color.Black;
                MaxLabel.ForeColor = Color.White;
                MinimalPriceBox.BackColor = Color.Black;
                MinimalPriceBox.ForeColor = Color.White;
                MaxPriceBox.BackColor = Color.Black;
                MaxPriceBox.ForeColor = Color.White;
                JustMiddleLabel.BackColor = Color.Black;
                JustMiddleLabel.ForeColor = Color.White;
            }
            else
            {
                BackColor = Color.White;
                NoItemsLabel.BackColor = Color.White;
                NoItemsLabel.ForeColor = Color.Black;
                WelcomeLabel.BackColor = Color.White;
                WelcomeLabel.ForeColor = Color.Black;
                UserDataLabel.BackColor = Color.White;
                UserDataLabel.ForeColor = Color.Black;
                CategoryLabel.BackColor = Color.White;
                CategoryLabel.ForeColor = Color.Black;
                MinLabel.BackColor = Color.White;
                MinLabel.ForeColor = Color.Black;
                MaxLabel.BackColor = Color.White;
                MaxLabel.ForeColor = Color.Black;
                MinimalPriceBox.BackColor = Color.White;
                MinimalPriceBox.ForeColor = Color.Black;
                MaxPriceBox.BackColor = Color.White;
                MaxPriceBox.ForeColor = Color.Black;
                JustMiddleLabel.BackColor = Color.White;
                JustMiddleLabel.ForeColor = Color.Black;
            }
        }
        private void LoadItems()
        {
            _Items = SQLprocedure.SelectAllItem(_currentUser.Id);
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            Form1.mainForm.pnlContainer.Controls["LoggedUserForm"].Dispose();
            Form1.mainForm.pnlContainer.Hide();
        }

        private void ItemsLabel_Click(object sender, EventArgs e)
        {
            LoadItems();
            NoItemsLabel.Hide();
            CategoryChooser.SelectedItem = CategoryChooser.Items[0];
            CategoryLabel.Show();
            CategoryChooser.Show();
            SearchIcon.Show();
            ItemList.Hide();
            ItemViewer.Hide();
            WelcomeLabel.Hide();
            UserDataLabel.Hide();
            MinLabel.Show();
            MaxLabel.Show();
            JustMiddleLabel.Show();
            MinimalPriceBox.Show();
            MaxPriceBox.Show();
        }

        private void LoggedUserForm_Load(object sender, EventArgs e)
        {

        }

        private void Categories_Enter(object sender, EventArgs e)
        {

        }

        private void ItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ItemList.SelectedRows.Count != 0)
            {
                ItemViewer.Show();
            }
        }

        private void SearchIcon_Click(object sender, EventArgs e)
        {
            double minPrice = 0;
            double maxPrice = double.MaxValue;
            if (MinimalPriceBox.Text != "")
            {
                minPrice = double.Parse(MinimalPriceBox.Text);
            }
            if (MaxPriceBox.Text != "")
            {
                maxPrice = double.Parse(MaxPriceBox.Text);
            }
            NoItemsLabel.Hide();
            ItemList.Hide();
            ItemList.Rows.Clear();
            Category Choice = (Category)Enum.Parse(typeof(Category), CategoryChooser.Text, true);
            if (Choice == Category.All)
            {
                int amount = 0;
                if (_Items.Count == 0)
                {
                    NoItemsLabel.Show();
                    return;
                }
                foreach (Item item in _Items)
                {
                    if (item.Price >= minPrice && item.Price <= maxPrice)
                    {
                        ItemList.Rows.Add(item.Id, item.Name, item.Quantity, item.Price);
                        amount++;
                    }
                }
                if (amount == 0)
                {
                    NoItemsLabel.Show();
                    return;
                }
                ItemList.Show();
            }
            else if (Choice == Category.Undefined)
            {
                int amount = 0;
                foreach (Item item in _Items)
                {
                    if (item.Category == Category.Undefined && item.Price >= minPrice && item.Price <= maxPrice)
                    {
                        ItemList.Rows.Add(item.Id, item.Name, item.Quantity, item.Price);
                        amount++;
                    }
                }
                if (amount == 0)
                {
                    NoItemsLabel.Show();
                    return;
                }
                ItemList.Show();
            }
            else if (Choice == Category.Defined)
            {
                int amount = 0;
                foreach (Item item in _Items)
                {
                    if (item.Category == Category.Defined && item.Price >= minPrice && item.Price <= maxPrice)
                    {
                        ItemList.Rows.Add(item.Id, item.Name, item.Quantity, item.Price);
                        amount++;
                    }
                }
                if (amount == 0)
                {
                    NoItemsLabel.Show();
                    return;
                }
                ItemList.Show();
            }
            else if (Choice == Category.Other)
            {
                int amount = 0;
                foreach (Item item in _Items)
                {
                    if (item.Category == Category.Other && item.Price >= minPrice && item.Price <= maxPrice)
                    {
                        ItemList.Rows.Add(item.Id, item.Name, item.Quantity, item.Price);
                        amount++;
                    }
                }
                if (amount == 0)
                {
                    NoItemsLabel.Show();
                    return;
                }
                ItemList.Show();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BalanceIcon_Click(object sender, EventArgs e)
        {

        }

        private void BalanceAmont_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(BalanceAmont.Text);
        }

        private void HomeLabel_Click(object sender, EventArgs e)
        {
            CategoryLabel.Hide();
            CategoryChooser.Hide();
            SearchIcon.Hide();
            ItemViewer.Hide();
            ItemList.Hide();
            NoItemsLabel.Hide();
            UserDataLabel.Show();
            MinLabel.Hide();
            MaxLabel.Hide();
            JustMiddleLabel.Hide();
            MinimalPriceBox.Hide();
            MinimalPriceBox.Text = "";
            MaxPriceBox.Hide();
            MaxPriceBox.Text = "";
        }

        private void ItemViewer_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedId = int.Parse(ItemList.SelectedRows[0].Cells[0].Value.ToString());
                Item targetItem = _Items.Single(x => x.Id == selectedId);
                UpdatedLabel selectedItemForm = new UpdatedLabel(_currentUser, targetItem, this);
                selectedItemForm.Dock = DockStyle.Fill;
                Form1.mainForm.pnlContainer.Controls.Add(selectedItemForm);
                Form1.mainForm.pnlContainer.Show();
                Form1.mainForm.pnlContainer.Controls["SelectedItemForm"].BringToFront();
                HomeLabel_Click(sender, e);
            }
            catch { }

        }

        private void UserDataLabel_Click(object sender, EventArgs e)
        {

        }

        private void MinimalPriceBox_TextChanged(object sender, EventArgs e)
        {
            double maxValue = 0;
            if (MaxPriceBox.Text == "")
            {
                maxValue = int.MaxValue;
            }
            else
            {
                maxValue = double.Parse(MaxPriceBox.Text);
            }
            string newString = "";
            try
            {
                char[] chars = MinimalPriceBox.Text.ToCharArray();
                int dots = GetDotAmount(chars);
                if (dots > 1)
                {
                    chars = RemoveSecondDot(chars);
                    newString = new String(chars);
                    MinimalPriceBox.Text = newString;
                }
                double testingRat = 0;
                MinimalPriceBox.Text = MinimalPriceBox.Text.Trim();
                if (chars[0] == '0' && chars[1] != '.')
                {
                    chars = AddDotAfterZero(chars);
                    newString = new String(chars);
                    MinimalPriceBox.Text = newString;
                }
                else if (chars[0] == '.')
                {
                    chars = AddZeroAtStart(chars);
                    newString = new String(chars);
                    MinimalPriceBox.Text = newString;
                }
                bool parsed = double.TryParse(MinimalPriceBox.Text, out testingRat);
                int index = 0;
                if (parsed)
                {
                    if (testingRat > maxValue)
                    {
                        MaxPriceBox.Text = MinimalPriceBox.Text;
                    }
                    return;
                }
                foreach (char character in chars)
                {
                    parsed = double.TryParse(character.ToString(), out testingRat);
                    if (!parsed && character != '.')
                    {
                        MinimalPriceBox.Text = MinimalPriceBox.Text.Remove(index);
                        return;
                    }
                    index++;
                }
            }
            catch
            {

            }
        }

        private void MaxPriceBox_TextChanged(object sender, EventArgs e)
        {

            double minValue = 0;
            if (MinimalPriceBox.Text != "")
            {
                minValue = double.Parse(MinimalPriceBox.Text);
            }
            char[] chars = MaxPriceBox.Text.ToCharArray();
            int dots = GetDotAmount(chars);
            string newString = "";
            if (dots > 1)
            {
                chars = RemoveSecondDot(chars);
                newString = new String(chars);
                MaxPriceBox.Text = newString;
            }
            try
            {

                double testingRat = 0;
                MaxPriceBox.Text = MaxPriceBox.Text.Trim();
                if (chars[0] == '0' && chars[1] != '.')
                {
                    chars = AddDotAfterZero(chars);
                    newString = new String(chars);
                    MaxPriceBox.Text = newString;
                }
                else if (chars[0] == '.')
                {
                    chars = AddZeroAtStart(chars);
                    newString = new String(chars);
                    MaxPriceBox.Text = newString;
                }
                bool parsed = double.TryParse(MaxPriceBox.Text, out testingRat);
                int index = 0;
                if (parsed)
                {
                    if (testingRat < minValue)
                    {
                        MinimalPriceBox.Text = MaxPriceBox.Text;
                    }
                    return;
                }
                foreach (char character in chars)
                {
                    parsed = double.TryParse(character.ToString(), out testingRat);
                    if (!parsed && character != '.')
                    {
                        MaxPriceBox.Text = MaxPriceBox.Text.Remove(index);
                        return;
                    }
                    index++;
                }
            }
            catch
            {

            }
        }

        private int GetDotAmount(char[] chars)
        {
            int amount = 0;
            foreach (char character in chars)
            {
                if (character == '.')
                {
                    amount++;
                }
            }
            return amount;
        }

        private char[] RemoveSecondDot(char[] chars)
        {
            int i = 0;
            int index = 0;
            foreach(char character in chars)
            {
                if (character == '.' && i == 1)
                {
                    break;
                }
                else if(character == '.')
                {
                    i++;
                }
                index++;
            }
            string newString = chars.ToString();
            newString.Remove(index);
            return newString.ToCharArray();
        }
        private  char[] AddDotAfterZero(char[] chars)
        {
            char[] newArray = new char[chars.Length + 1];
            int i = 0;
            foreach(char character in chars)
            {
                if (i != 1)
                {
                    newArray[i] = character;
                }
                else
                {
                    newArray[i] = '.';
                    i++;
                    newArray[i] = character;
                }
            }
            return newArray;
        }
        private char[] AddZeroAtStart(char[] chars)
        {
            char[] newArray = new char[chars.Length + 1];
            int i = 1;
            newArray[0] = '0';
            foreach (char character in chars)
            {
                newArray[i] = character;
                i++;
            }
            return newArray;
        }
    }
}
