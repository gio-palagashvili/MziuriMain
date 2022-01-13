using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    public partial class UpdatedLabel : UserControl
    {
        private readonly User _currentUser;
        private Item _item;
        private User _itemOwner;
        private LoggedUserForm _loggedForm;
        private Item _itemAfterCheck;
        public UpdatedLabel(User user, Item item, LoggedUserForm previousForm)
        {
            _loggedForm = previousForm;
            _currentUser = user;
            _item = item;
            _itemOwner = item.GetSeller();
            _itemOwner.GetSettings();
            InitializeComponent();
            ReloadWarningLabel.Hide();
            Name = "SelectedItemForm";
            ItemNameLabel.Text = _item.Name;
            ItemDescriptionBox.Text = _item.Description;
            NameValueLabel.Text = _itemOwner.Name + " " + _itemOwner.Lastname;
            bool areFriends = SQLprocedure.AreFriends(_currentUser.Id, _itemOwner.Id);
            if (_itemOwner.PhoneNumber != "")
            {
                if (_itemOwner.GlobalSettings.GlobalPhoneView && !areFriends || _itemOwner.GlobalSettings.FriendPhoneView && areFriends)
                {
                    PhoneNumValueLabel.Text = _itemOwner.PhoneNumber;
                }
                else
                {
                    PhoneNumValueLabel.Text = "Seller don't want to reveal their number.";
                }
            }
            else
            {
                PhoneNumValueLabel.Text = "Not set";
            }
            if (_itemOwner.GlobalSettings.GlobalMailView && !areFriends || _itemOwner.GlobalSettings.FriendMailView && areFriends)
            {
                MailValueLabel.Text = _itemOwner.Mail;
            }
            else
            {
                MailValueLabel.Text = "Seller don't want to reveal their mail.";
            }

            //if(_itemOwner.GlobalSettings.GlobalChat && !areFriends || _itemOwner.GlobalSettings.FriendChat && areFriends)
            //{
            //    ContactSellerButton.Show();
            //}


            QuantityAmountLabel.Text = _item.Quantity.ToString();
            PriceAmountLabel.Text = _item.Price.ToString() + " ₾";

            if (Program.ScreenMode == ScreenMode.Dark)
            {
                BackColor = Color.Black;
                ItemNameLabel.BackColor = Color.Black;
                ItemNameLabel.ForeColor = Color.White;
                ItemDescriptionBox.BackColor = Color.Black;
                ItemDescriptionBox.ForeColor = Color.White;
                PhoneNumLabel.BackColor = Color.Black;
                PhoneNumLabel.ForeColor = Color.White;
                PhoneNumValueLabel.BackColor = Color.Black;
                PhoneNumValueLabel.ForeColor = Color.White;
                MailLabel.BackColor = Color.Black;
                MailLabel.ForeColor = Color.White;
                MailValueLabel.BackColor = Color.Black;
                MailValueLabel.ForeColor = Color.White;
                QuantityLabel.BackColor = Color.Black;
                QuantityLabel.ForeColor = Color.White;
                QuantityAmountLabel.BackColor = Color.Black;
                QuantityAmountLabel.ForeColor = Color.White;
                PriceLabel.BackColor = Color.Black;
                PriceLabel.ForeColor = Color.White;
                PriceAmountLabel.BackColor = Color.Black;
                PriceAmountLabel.ForeColor = Color.White;
                QuestioningLabel.BackColor = Color.Black;
                QuestioningLabel.ForeColor = Color.White;
                AmountTextbox.BackColor = Color.Black;
                AmountTextbox.ForeColor = Color.White;
                NameLabel.BackColor = Color.Black;
                NameLabel.ForeColor = Color.White;
                NameValueLabel.BackColor = Color.Black;
                NameValueLabel.ForeColor = Color.White;
                CostLabel.BackColor = Color.Black;
                CostLabel.ForeColor = Color.White;
                CostValueLabel.BackColor = Color.Black;
                CostValueLabel.ForeColor = Color.White;
                AftermathLabel.BackColor = Color.Black;
                AftermathLabel.ForeColor = Color.White;
                AftermathValueLabel.BackColor = Color.Black;
                AftermathValueLabel.ForeColor = Color.White;
            }
            else
            {
                BackColor = Color.White;
                ItemNameLabel.BackColor = Color.White;
                ItemNameLabel.ForeColor = Color.Black;
                ItemDescriptionBox.BackColor = Color.White;
                ItemDescriptionBox.ForeColor = Color.Black;
                PhoneNumLabel.BackColor = Color.White;
                PhoneNumLabel.ForeColor = Color.Black;
                PhoneNumValueLabel.BackColor = Color.White;
                PhoneNumValueLabel.ForeColor = Color.Black;
                MailLabel.BackColor = Color.White;
                MailLabel.ForeColor = Color.Black;
                MailValueLabel.BackColor = Color.White;
                MailValueLabel.ForeColor = Color.Black;
                QuantityLabel.BackColor = Color.White;
                QuantityLabel.ForeColor = Color.Black;
                QuantityAmountLabel.BackColor = Color.White;
                QuantityAmountLabel.ForeColor = Color.Black;
                PriceLabel.BackColor = Color.White;
                PriceLabel.ForeColor = Color.Black;
                PriceAmountLabel.BackColor = Color.White;
                PriceAmountLabel.ForeColor = Color.Black;
                QuestioningLabel.BackColor = Color.White;
                QuestioningLabel.ForeColor = Color.Black;
                AmountTextbox.BackColor = Color.White;
                AmountTextbox.ForeColor = Color.Black;
                NameLabel.BackColor = Color.White;
                NameLabel.ForeColor = Color.Black;
                NameValueLabel.BackColor = Color.White;
                NameValueLabel.ForeColor = Color.Black;
                CostLabel.BackColor = Color.White;
                CostLabel.ForeColor = Color.Black;
                CostValueLabel.BackColor = Color.White;
                CostValueLabel.ForeColor = Color.Black;
                AftermathLabel.BackColor = Color.White;
                AftermathLabel.ForeColor = Color.Black;
                AftermathValueLabel.BackColor = Color.White;
                AftermathValueLabel.ForeColor = Color.Black;
            }
        }

        private void CoolButton_Click(object sender, EventArgs e)
        {
            Form1.mainForm.pnlContainer.Controls["SelectedItemForm"].Dispose();
        }

        private void PriceAmountLabel_Click(object sender, EventArgs e)
        {

        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            ConfirmButton.Show();
            BuyButton.Hide();
            AmountTextbox.Show();
        }

        private void AmountTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                char[] chars = AmountTextbox.Text.ToCharArray();
                int testingRat = 0;
                AmountTextbox.Text = AmountTextbox.Text.Trim();
                bool isInteger = int.TryParse(chars[0].ToString(), out int reallyUselessThingPleaseDelete);
                if (chars[0] == '0' || !isInteger)
                {
                    chars[0] = ' ';
                    string newText = new string(chars);
                    AmountTextbox.Text = newText.Trim();
                    ShowCostAndAftermath();
                    return;
                }
                bool parsed = int.TryParse(AmountTextbox.Text, out testingRat);
                if (parsed)
                {
                    if (testingRat > _item.Quantity)
                    {
                        AmountTextbox.Text = AmountTextbox.Text.Remove(AmountTextbox.Text.Length - 1);
                        ShowCostAndAftermath();
                        return;
                    }
                    else
                    {
                        ShowCostAndAftermath();
                        return;
                    }
                }
                int index = 0;
                foreach (char character in chars)
                {
                    parsed = int.TryParse(character.ToString(), out testingRat);
                    if (!parsed)
                    {
                        AmountTextbox.Text = AmountTextbox.Text.Remove(index);
                        ShowCostAndAftermath();
                        return;
                    }
                    index++;
                }
            }
            catch
            {
                ShowCostAndAftermath();
            }
        }

        private void ShowCostAndAftermath()
        {
            CostLabel.Show();
            CostValueLabel.Show();
            AftermathLabel.Show();
            AftermathValueLabel.Show();

            if (AmountTextbox.Text.Trim() == "")
            {
                CostValueLabel.Text = "0 ₾";
                AftermathValueLabel.Text = _currentUser.Balance.ToString() + " ₾";
                return;
            }
            int amount = int.Parse(AmountTextbox.Text.Trim());
            double cost = Math.Round(amount * _item.Price, 2);
            CostValueLabel.Text = cost.ToString() + " ₾";
            AftermathValueLabel.Text = Math.Round(_currentUser.Balance - cost, 2).ToString() + " ₾";
        }

        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            ConfirmButton.Hide();
            AmountTextbox.Hide();
            _itemAfterCheck = SQLprocedure.GetItemById(_item.Id);
            bool isNotSame = _item.Quantity != _itemAfterCheck.Quantity && _itemAfterCheck.Quantity < int.Parse(AmountTextbox.Text) || _item.Price != _itemAfterCheck.Price;
            if (isNotSame)
            {
                ReloadWarningLabel.Show();
                await Task.Delay(1500);
                Program.UpdateItemForm(_currentUser, _itemAfterCheck, _loggedForm);
                CoolButton_Click(sender, e);
            }
            int quantityBought = 0;
            string pricePaidCorrectString = CostValueLabel.Text.Remove(CostValueLabel.Text.Length - 1);
            double pricePaid = double.Parse(pricePaidCorrectString);
            try
            {
                quantityBought = int.Parse(AmountTextbox.Text);
            }
            catch
            {
                return;
            }


            bool AbleToPay = 0 <= double.Parse(AftermathValueLabel.Text.Remove(AftermathValueLabel.Text.Length - 1));

            if (AbleToPay)
            {
                BoughtSuccessfulyLabel.Show();
                SQLprocedure.ChangeItemQuantity(_item.Id, -quantityBought);
                SQLprocedure.ChangeBalance(_currentUser.Id, -pricePaid);
                SQLprocedure.ChangeBalance(_item.SellerId, pricePaid);
                _loggedForm.UpdateUser();
                HideAfterTwoSecondAndHalf(BoughtSuccessfulyLabel, true);
            }
            else
            {
                CanNotAffordLabel.Show();
                BuyButton.Show();
                HideAfterTwoSecondAndHalf(CanNotAffordLabel);
            }
        }

        private async void HideAfterTwoSecondAndHalf(Control target, bool CloseAfter = false)
        {
            await Task.Delay(2500);
            target.Hide();

            if (CloseAfter)
            {
                CoolButton_Click("fake", null);
            }
        }

        private void UpdatedLabel_Load(object sender, EventArgs e)
        {

        }
    }
}
