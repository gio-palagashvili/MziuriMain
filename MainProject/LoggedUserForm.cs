using System;
using System.Collections.Generic;
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
        private List<Item> _items;
        private List<Item> _temporarySaver;
        private List<User> _friends;
        private User _selectedFriend;
        public LoggedUserForm(User user)
        {
            InitializeComponent();
            Name = "LoggedUserForm";
            _currentUser = user;
            ReloadFriends();
            LoadItems();
            _items = SQLprocedure.SelectAllItem(_currentUser.Id);

            SetColors();
            BalanceAmont.Text = Math.Round(_currentUser.Balance, 2).ToString() + " ₾";
            UserDataLabel.Text = $"Role: {_currentUser.Role}\nFName: {_currentUser.Name} {_currentUser.Lastname}\nID: {_currentUser.Id}";
        }

        public void UpdateUser()
        {
            _currentUser = SQLprocedure.GetUser(_currentUser.Mail);
            LoadItems();
            _items = SQLprocedure.SelectAllItem(_currentUser.Id);
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
            _items = SQLprocedure.SelectAllItem(_currentUser.Id);
        }
        private void ReloadFriends()
        {
            _friends = SQLprocedure.GetFriends(_currentUser.Id);
            FriendListTable.Rows.Clear();
            foreach(User friend in _friends)
            {
                FriendListTable.Rows.Add(friend.Id, friend.Name, friend.Lastname);
            }
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
            ItemViewerButton.Hide();
            WelcomeLabel.Hide();
            UserDataLabel.Hide();
            MinLabel.Show();
            MaxLabel.Show();
            JustMiddleLabel.Show();
            MinimalPriceBox.Show();
            MaxPriceBox.Show();
            FriendSearchLabel.Hide();
            FriendFilterTextBox.Hide();
            FriendListTable.Hide();
            TakenRequestViewer.Hide();
            PendingRequestViewer.Hide();
            TakenRequestViewer.Text = "View friend requests";
            PendingRequestViewer.Text = "View sent requests";
            SentFriendRequestList.Hide();
            TakenFriendRequestList.Hide();
            FriendRequestSender.Hide();
            FriendAddingTutorialLabel.Hide();
            FriendToAddTextousBox.Hide();
            FriendToAddTextousBox.Text = "";
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
                ItemViewerButton.Show();
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
                if (_items.Count == 0)
                {
                    NoItemsLabel.Show();
                    return;
                }
                foreach (Item item in _items)
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
                foreach (Item item in _items)
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
                foreach (Item item in _items)
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
                foreach (Item item in _items)
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
            ItemViewerButton.Hide();
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
            FriendSearchLabel.Hide();
            FriendFilterTextBox.Hide();
            FriendListTable.Hide();
            TakenRequestViewer.Hide();
            PendingRequestViewer.Hide();
            TakenRequestViewer.Text = "View friend requests";
            PendingRequestViewer.Text = "View sent requests";
            SentFriendRequestList.Hide();
            TakenFriendRequestList.Hide();
            FriendRequestSender.Hide();
            ReturnToFriendInteractionButton.Hide();
            FriendAddingTutorialLabel.Hide();
            FriendToAddTextousBox.Hide();
            FriendToAddTextousBox.Text = "";
        }

        private void ItemViewer_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedId = int.Parse(ItemList.SelectedRows[0].Cells[0].Value.ToString());
                Item targetItem = _items.Single(x => x.Id == selectedId);
                UpdatedLabel selectedItemForm = new UpdatedLabel(_currentUser, targetItem, this);
                selectedItemForm.Dock = DockStyle.Fill;
                Form1.mainForm.pnlContainer.Controls.Add(selectedItemForm);
                Form1.mainForm.pnlContainer.Show();
                Form1.mainForm.pnlContainer.Controls["SelectedItemForm"].BringToFront();
                HomeLabel_Click(sender, e);
                if(_temporarySaver != null)
                {
                    _items = _temporarySaver;
                }
                ItemList.Rows.Clear();
            }
            catch { }

        }

        private void UserDataLabel_Click(object sender, EventArgs e)
        {

        }

        private void MinimalPriceBox_TextChanged(object sender, EventArgs e)
        {
            double maxValue;
            if (MaxPriceBox.Text == "")
            {
                maxValue = int.MaxValue;
            }
            else
            {
                maxValue = double.Parse(MaxPriceBox.Text);
            }
            string newString;
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
            foreach (char character in chars)
            {
                if (character == '.' && i == 1)
                {
                    break;
                }
                else if (character == '.')
                {
                    i++;
                }
                index++;
            }
            string newString = chars.ToString();
            newString.Remove(index);
            return newString.ToCharArray();
        }
        private char[] AddDotAfterZero(char[] chars)
        {
            char[] newArray = new char[chars.Length + 1];
            int i = 0;
            foreach (char character in chars)
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

        private void CommunityLabel_Click_2(object sender, EventArgs e)
        {
            FriendInteractionBox.Hide();
            StartInteractionWithFriendButton.Show();
            SelectedUserNameLabel.Hide();
            SelectedUserNameValueLabel.Hide();
            SelectedUserLastnameLabel.Hide();
            SelectedUserLastnameValueLabel.Hide();
            SelectedUserMailLabel.Hide();
            SelectedUserPhoneLabel.Hide();
            SelectedUserMailLabel.Hide();
            SelectedUsermailValueLabel.Hide();
            SelectedUserPhoneLabel.Hide();
            SelectedUserPhoneValueLabel.Hide();
            CheckPersonsItemsButton.Hide();
            ChatWithPersonButton.Hide();

            CategoryLabel.Hide();
            WelcomeLabel.Hide();
            CategoryChooser.Hide();
            SearchIcon.Hide();
            ItemViewerButton.Hide();
            ItemList.Hide();
            NoItemsLabel.Hide();
            UserDataLabel.Hide();
            MinLabel.Hide();
            MaxLabel.Hide();
            JustMiddleLabel.Hide();
            MinimalPriceBox.Hide();
            MinimalPriceBox.Text = "";
            MaxPriceBox.Hide();
            MaxPriceBox.Text = "";
            FriendSearchLabel.Show();
            FriendFilterTextBox.Show();
            FriendListTable.Show();
            TakenRequestViewer.Show();
            PendingRequestViewer.Show();
            SentFriendRequestList.Hide();
            TakenFriendRequestList.Hide();
            FriendRequestSender.Show();
            TakenRequestViewer.Text = "View friend requests";
            PendingRequestViewer.Text = "View sent requests";
            FriendAddingTutorialLabel.Hide();
            FriendToAddTextousBox.Hide();
            FriendToAddTextousBox.Text = "";
        }

        private void FriendFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            FriendListTable.Rows.Clear();
            string target = FriendFilterTextBox.Text.Trim();
            StringBuilder sb = new StringBuilder();
            foreach (User user in _friends)
            {
                sb.Append($"{user.Name} {user.Lastname}");

                if (user.Name.Contains(target) || user.Lastname.Contains(target) || sb.ToString().Contains(target))
                {
                    FriendListTable.Rows.Add(user.Id, user.Name, user.Lastname);
                }
                sb.Clear();
            }
        }

        private void PendingRequestViewer_Click(object sender, EventArgs e)
        {
            if (PendingRequestViewer.Text == "View sent requests")
            {
                PendingRequestViewer.Text = "Hide sent requests";
                ReloadSentFriendRequestList();
            }
            else
            {
                SentFriendRequestList.Hide();
                CancelButtonForRequest.Hide();
                PendingRequestViewer.Text = "View sent requests";
            }

        }
        private void ReloadSentFriendRequestList()
        {
            var users = SQLprocedure.GetRequestsSent(_currentUser.Id);
            SentFriendRequestList.Rows.Clear();
            foreach (User user in users)
            {
                SentFriendRequestList.Rows.Add(user.Id, user.Name, user.Lastname);
            }
            if (SentFriendRequestList.Rows.Count == 0)
            {
                PendingRequestViewer.Text = "View sent requests";
                SentFriendRequestList.Hide();
                ShowAndHideControlAfterTwoAndHalfSecond(NoFriendRequestSentLabel);
            }
            else
            {
                SentFriendRequestList.Show();
                PendingRequestViewer.Text = "Hide sent requests";
            }
        }

        private async void ShowAndHideControlAfterTwoAndHalfSecond(Control target)
        {
            target.Show();
            await Task.Delay(2500);
            target.Hide();
        }
        private async void HideAndShowControlAfterTwoAndHalfSecond(Control target)
        {
            target.Hide();
            await Task.Delay(2500);
            target.Show();
        }

        private void TakenRequestViewer_Click(object sender, EventArgs e)
        {
            TakenFriendRequestList.Show();
            if (TakenRequestViewer.Text == "View friend requests")
            {
                TakenRequestViewer.Text = "Hide friend requests";
                ReloadTakenFriendRequestList();
            }
            else
            {
                TakenFriendRequestList.Hide();
                FriendAcceptOrRejectBox.Hide();
                TakenRequestViewer.Text = "View friend requests";
            }
        }
        private void ReloadTakenFriendRequestList()
        {
            var users = SQLprocedure.GetRequestsTaken(_currentUser.Id);
            TakenFriendRequestList.Rows.Clear();
            foreach (User user in users)
            {
                TakenFriendRequestList.Rows.Add(user.Id, user.Name, user.Lastname);
            }
            if (TakenFriendRequestList.Rows.Count == 0)
            {
                TakenRequestViewer.Text = "View friend requests";
                TakenFriendRequestList.Hide();
                ShowAndHideControlAfterTwoAndHalfSecond(NoFriendRequestTakenLabel);
            }
            else
            {
                TakenFriendRequestList.Show();
            }
        }

        private void SentFriendRequestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SentFriendRequestList.SelectedRows.Count == 0)
            {
                CancelButtonForRequest.Hide();
            }
            else
            {
                CancelButtonForRequest.Show();
            }
        }

        private void CancelButtonForRequest_Click(object sender, EventArgs e)
        {
            bool requestStillValid = SQLprocedure.CheckRequest(_currentUser.Id, (int)SentFriendRequestList.SelectedRows[0].Cells[0].Value);
            if (requestStillValid)
            {
                SQLprocedure.CancelSentFriendRequest(_currentUser.Id, (int)SentFriendRequestList.SelectedRows[0].Cells[0].Value);
                CancelButtonForRequest.Hide();
                ReloadSentFriendRequestList();
            }
            else
            {
                CancelButtonForRequest.Hide();
                ReloadSentFriendRequestList();

            }

        }

        private void TakenFriendRequestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FriendAcceptOrRejectBox.Hide();
            try
            {
                FriendAcceptOrRejectBox.Text = TakenFriendRequestList.SelectedRows[0].Cells[1].Value.ToString() + " " + TakenFriendRequestList.SelectedRows[0].Cells[2].Value.ToString();
                FriendAcceptOrRejectBox.Show();
            }
            catch
            {

            }
        }

        private void FriendAcceptButton_Click(object sender, EventArgs e)
        {
            bool requestStillValid = SQLprocedure.CheckRequest(_currentUser.Id, (int)TakenFriendRequestList.SelectedRows[0].Cells[0].Value);
            if (requestStillValid)
            {
                SQLprocedure.AddFriend(_currentUser.Id, (int)TakenFriendRequestList.SelectedRows[0].Cells[0].Value);
                ReloadFriends();
                FriendAcceptOrRejectBox.Hide();
                ReloadTakenFriendRequestList();
            }
            else
            {
                ShowAndHideControlAfterTwoAndHalfSecond(FriendRequestIsInvalidLabel);
                FriendAcceptOrRejectBox.Hide();
                ReloadTakenFriendRequestList();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FriendListTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FriendInteractionBox.Hide();
            try
            {
                _selectedFriend = _friends.Single(x => x.Id == (int)FriendListTable.SelectedRows[0].Cells[0].Value);
                FriendInteractionBox.Text = _selectedFriend.Name + " " + _selectedFriend.Lastname;
                FriendInteractionBox.Show();
            }
            catch
            {

            }
        }

        private void CheckPersonsItems_Click(object sender, EventArgs e)
        {
            _selectedFriend.GetItems();
            _temporarySaver = _items;
            _items = _selectedFriend.Items;
            foreach (Item item in _items)
            {
                    ItemList.Rows.Add(item.Id, item.Name, item.Quantity, item.Price);
            }
            if (_items.Count == 0)
            {
                NoItemsLabel.Show();
                HideAndShowControlAfterTwoAndHalfSecond(FriendInteractionBox);
                ShowAndHideControlAfterTwoAndHalfSecond(NoItemsLabel);
                return;
            }
            ItemList.Show();
            CategoryLabel.Show();
            CategoryChooser.Show();
            MaxLabel.Show();
            MinLabel.Show();
            MaxPriceBox.Show();
            MinimalPriceBox.Show();
            FriendInteractionBox.Hide();
            JustMiddleLabel.Show();
            SearchIcon.Show();
            ReturnToFriendInteractionButton.Show();
        }

        private void StartInteractionWithFriendButton_Click(object sender, EventArgs e)
        {
            PendingRequestViewer.Hide();
            FriendSearchLabel.Hide();
            FriendFilterTextBox.Hide();
            TakenRequestViewer.Hide();
            SentFriendRequestList.Hide();
            FriendListTable.Hide();
            TakenFriendRequestList.Hide();
            CancelButtonForRequest.Hide();
            FriendRequestSender.Hide();
            FriendToAddTextousBox.Hide();
            FriendAcceptOrRejectBox.Hide();
            FriendAddingTutorialLabel.Hide();
            FriendToAddTextousBox.Hide();
            FriendToAddTextousBox.Text = "";


            _selectedFriend.GetSettings();
            StartInteractionWithFriendButton.Hide();
            SelectedUserNameLabel.Show();
            SelectedUserNameValueLabel.Text = _selectedFriend.Name;
            SelectedUserNameValueLabel.Show();
            SelectedUserLastnameLabel.Show();
            SelectedUserLastnameValueLabel.Text = _selectedFriend.Lastname;
            SelectedUserLastnameValueLabel.Show();
            SelectedUserMailLabel.Show();
            SelectedUserPhoneLabel.Show();
            if (_selectedFriend.GlobalSettings.FriendMailView)
            {
                SelectedUsermailValueLabel.Text = _selectedFriend.Mail;
            }
            else
            {
                SelectedUsermailValueLabel.Text = $"{_selectedFriend.Name} {_selectedFriend.Lastname} don't want to reveal their mail.";
            }
            SelectedUsermailValueLabel.Show();
            if (_selectedFriend.GlobalSettings.FriendPhoneView)
            {
                SelectedUserPhoneValueLabel.Text = _selectedFriend.PhoneNumber;
            }
            else
            {
                SelectedUserPhoneValueLabel.Text = $"{_selectedFriend.Name} {_selectedFriend.Lastname} don't want to reveal their number.";
            }
            SelectedUserPhoneValueLabel.Show();
            if (_selectedFriend.GlobalSettings.FriendChat)
            {
                ChatWithPersonButton.Show();
            }
            CheckPersonsItemsButton.Show();
        }

        private void ReturnToFriendInteractionButton_Click(object sender, EventArgs e)
        {
            ItemList.Hide();
            CategoryLabel.Hide();
            CategoryChooser.Hide();
            MaxLabel.Hide();
            MinLabel.Hide();
            MaxPriceBox.Hide();
            MinimalPriceBox.Hide();
            FriendInteractionBox.Show();
            JustMiddleLabel.Hide();
            SearchIcon.Hide();
            ReturnToFriendInteractionButton.Hide();
            ItemViewerButton.Hide();
            _items = _temporarySaver;
            ItemList.Rows.Clear();
        }

        private void FriendRequestSender_Click(object sender, EventArgs e)
        {
            
            if (!FriendToAddTextousBox.Visible)
            {
                FriendToAddTextousBox.Show();
                FriendAddingTutorialLabel.Show();
            }
            else
            {
                bool parsed = int.TryParse(FriendToAddTextousBox.Text, out int userId);
                User target = null;
                if (parsed)
                {
                    target = SQLprocedure.GetUser(userId);
                }
                else
                {
                    target = SQLprocedure.GetUser(FriendToAddTextousBox.Text);
                }
                if (target == null)
                {
                    FriendToAddTextousBox.Hide();
                    FriendToAddTextousBox.Text = "";
                    FriendAddingTutorialLabel.Hide();
                    ShowAndHideControlAfterTwoAndHalfSecond(InvalidMailOrIdWarningLabel);
                    return;
                }
                if (_currentUser.Id == target.Id)
                {
                    FriendToAddTextousBox.Hide();
                    FriendToAddTextousBox.Text = "";
                    FriendAddingTutorialLabel.Hide();
                    ShowAndHideControlAfterTwoAndHalfSecond(FriendshipWithYourselfWarningLabel);
                    return;
                }
                bool requestAlreadyExist = SQLprocedure.CheckRequest(_currentUser.Id, target.Id);
                if (requestAlreadyExist)
                {
                    int requestSenderId = SQLprocedure.GetRequestSenderId(_currentUser.Id, target.Id);
                    if (requestSenderId == target.Id)
                    {
                        SQLprocedure.AddFriend(_currentUser.Id, target.Id);
                        ReloadFriends();
                        ReloadSentFriendRequestList();
                        FriendToAddTextousBox.Hide();
                        FriendToAddTextousBox.Text = "";
                        FriendAddingTutorialLabel.Hide();
                        ShowAndHideControlAfterTwoAndHalfSecond(FriendHaveBeenAddedLabel);
                        return;
                    }
                    else
                    {
                        FriendToAddTextousBox.Hide();
                        FriendToAddTextousBox.Text = "";
                        FriendAddingTutorialLabel.Hide();
                        ShowAndHideControlAfterTwoAndHalfSecond(BroWaitLabel);
                        return;
                    }
                }
                else
                {
                    SQLprocedure.SendFriendRequest(_currentUser.Id, target.Id);
                    ReloadFriends();
                    ReloadSentFriendRequestList();
                    FriendToAddTextousBox.Hide();
                    FriendToAddTextousBox.Text = "";
                    FriendAddingTutorialLabel.Hide();
                    ShowAndHideControlAfterTwoAndHalfSecond(RequestSentSuccessfulyLabel);
                }
            }
        }
    }
}
