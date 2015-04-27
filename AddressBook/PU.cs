using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

//работа с группами LDAP через UserPrincipal
namespace AddressBook
{
    public class PU
    {
        /// <summary>
        /// Пользователи, которые входят в группу
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static CustomUserList GetGroupUsers(string groupName)
        {
            var result = new CustomUserList();
            using (var ctx = new PrincipalContext(ContextType.Domain))
            using (var groupPrincipal = GroupPrincipal.FindByIdentity(ctx, groupName))
            {

                if (groupPrincipal != null)
                {
                    foreach (UserPrincipal user in groupPrincipal.GetMembers(true))
                    {
                        if (user.Enabled == true)
                        {
                            HasUserInfo ifUser = new PrUser(user);

                            var OutUser = new CustomUser(ifUser);                                                                                                          

                            result.Add(OutUser);
                        }
                    }
                }
            }
            return result;
        }     
       
        /// <summary>
        /// Группы, в которые входит пользователь
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetUserGroups(string userName)
        {
            using (var ctx = new PrincipalContext(ContextType.Domain))
            using (var userPrincipal = UserPrincipal.FindByIdentity(ctx, userName))
            {
                return userPrincipal.GetGroups().Select(d => d.SamAccountName).ToList();
            }
        }

        public static List<CustomUser> GetUsers()
        {
            using (var context = new PrincipalContext(ContextType.Domain))
            using (var user = new UserPrincipal(context))
            using (var searcher = new PrincipalSearcher(user))
            {
                List<CustomUser> result = new List<CustomUser>();
                var ds = searcher.GetUnderlyingSearcher() as DirectorySearcher;
                //searcher.QueryFilter = "(&(objectCategory=person)(objectClass=user)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))";
                ds.SizeLimit = 1000;
                //ds.Filter = "(&(objectCategory=person)(objectClass=user)(!(userAccountControl:1.2.840.113556.1.4.803:=2))(OU=ЦОД))"; - не работает
                var users = searcher.FindAll().ToList();
                foreach (var OneUser in users)
                {
                    CustomUser OutUser = new CustomUser();
                    OutUser.DislpayName = OneUser.Name;
                    result.Add(OutUser);
                    // OutUser.Department = OneUser.
                }
                return result;
            }
        }

    }

    public static class UserPrincipalExtensions
    {
        //извлечение реквизитов пользователя UserPrincipal
        public static String GetProperty(this Principal principal, String property)
        {
            DirectoryEntry directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;

            if (directoryEntry.Properties.Contains(property))
                return directoryEntry.Properties[property].Value.ToString();
            else
                return String.Empty;

        }

        public static Bitmap GetPhoto(this UserPrincipal principal)
        {
            Bitmap result = CustomUser.DEFAULT_PHOTO;
            try
            {
                DirectoryEntry directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;

                if (directoryEntry.Properties.Contains("jpegPhoto"))
                {
                    byte[] data = directoryEntry.Properties["jpegPhoto"].Value as byte[];
                    if (data != null)
                    {
                        using (MemoryStream s = new MemoryStream(data))
                        {
                            result = (Bitmap)Bitmap.FromStream(s);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка во время загрузки фотографии пользователя " + principal.Name + "\n"
                    + e.Message,
                         "Ошибка загрузки из AD",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                return CustomUser.DEFAULT_PHOTO;
            }
            return result;

        }

    }


}
