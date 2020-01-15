using System;
using System.Collections.ObjectModel;

namespace AddUser
{
    public class User
    {
        public static ObservableCollection<string> itemList;
        public string mUserName;
        public ObservableCollection<string> getUserList()
        {
            { return itemList; }
        }
        public static void addItemList(string user)
        {
            if (itemList == null)
            {
                itemList = new ObservableCollection<string>();
            }
            itemList.Add(user);

        }

    }
}
