using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class DM
    {
        private static DM SingleTone;
        private DM(): base()
        {}
        public static DM GetInstance()
        {
            if (SingleTone == null)
            {
                SingleTone = new DM();
            }
            return SingleTone;
        }
        public CustomUserList users = new CustomUserList();
        public void LoadUsers()
        {
            if (Properties.Settings.Default.useFilter == true)
                users = DE.GetUsers();
            else
                users = PU.GetGroupUsers(Properties.Settings.Default.GroupName);
        }
    }
}
