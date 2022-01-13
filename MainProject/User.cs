#nullable enable
using System;
using System.Collections.Generic;
using System.Data;

namespace MainProject
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Mail { get; private set; }
        public Role Role { get; private set; }
        public double Balance { get; private set; }
        public DateTime Creation { get; private set; }
        public string Password { get; private set; }
        public GlobalSettings GlobalSettings { get; private set; }
        public List<Item> Items { get; private set; }

        public User(IDataRecord userData)
        {
            Id = userData.GetInt32(0);
            Name = userData.GetString(1);
            Lastname = userData.GetString(2);
            try
            {
                PhoneNumber = userData.GetString(4);
            }
            catch
            {
                PhoneNumber = "";
            }

            Creation = userData.GetDateTime(5);
            Mail = userData.GetString(6);
            Role = (Role)Enum.Parse(typeof(Role), userData.GetString(7), true);
            Balance = userData.GetDouble(8);
            Password = userData.GetString(3);
        }
        public User(string name, string lastname, string mail, string phoneNumber, string password)
        {
            Name = name;
            Lastname = lastname;
            Mail = mail;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public void GetItems()
        {
            Items = SQLprocedure.SelectUserItems(Id);
        }

        public void GetSettings()
        {
            GlobalSettings = SQLprocedure.GetSettings(Id);
        }
    }
}