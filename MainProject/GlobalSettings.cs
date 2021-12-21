using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class GlobalSettings
    {
        public int Id { get; private set; }

        // format: Level (Global points to every user while friend is friend of user, pretty self explaining) |<^-^>| Permission (thing person on *Level* can see or not ez) 
        public bool GlobalDateView { get; private set; }
        public bool FriendDateView { get; private set; }
        public bool GlobalFriendView { get; private set; }
        public bool FriendFriendView { get; private set; }
        public bool GlobalChat { get; private set; }
        public bool FriendChat { get; private set; }
        public bool GlobalPhoneView { get; private set; }
        public bool FriendPhoneView { get; private set; }
        public bool GlobalMailView { get; private set; }
        public bool FriendMailView { get; private set; }
        

        public GlobalSettings(IDataRecord settingData)
        {
            Id = settingData.GetInt32(0);
            GlobalDateView = settingData.GetBoolean(1);
            FriendDateView = settingData.GetBoolean(2);
            GlobalFriendView = settingData.GetBoolean(3);
            FriendDateView= settingData.GetBoolean(4);
            GlobalChat = settingData.GetBoolean(5);
            FriendChat = settingData.GetBoolean(6);
            GlobalPhoneView = settingData.GetBoolean(7);
            FriendPhoneView = settingData.GetBoolean(8);
            GlobalMailView = settingData.GetBoolean(9);
            FriendMailView = settingData.GetBoolean(10);
        }
    }
}
