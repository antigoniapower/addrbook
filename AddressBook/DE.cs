using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Text.RegularExpressions;

namespace AddressBook
{
    public enum LdapType
    {
        Writable,
        ReadOnly
    }

    public static class DE
    {
        //загрузка всех пользователей
        public static CustomUserList GetUsers(string Filter = "")
        {
            CustomUserList users = new CustomUserList();

            var directoryEntry = new DirectoryEntry();
            directoryEntry.AuthenticationType = AuthenticationTypes.ReadonlyServer;
            var dirSearcher = new DirectorySearcher(directoryEntry);
            try
            {
                dirSearcher.SearchScope = SearchScope.Subtree;
                dirSearcher.Filter = Filter == "" ? Properties.Settings.Default.filter : Filter;

                var searchResults = dirSearcher.FindAll();
                foreach (SearchResult sr in searchResults)
                {
                    DirectoryEntry de = sr.GetDirectoryEntry();
                    HasUserInfo ifUser = new DeUser(de);

                    CustomUser user = new CustomUser(ifUser);
                    
                    users.Add(user);
                }

            }
            finally
            {
                directoryEntry.Dispose();
                dirSearcher.Dispose();
            }
            return users;
        }
               
        public static CustomUserList SearchUsers(string SearchName)
        {
            string SearchFilter = "(&(objectClass=user)(cn=*" + SearchName + "*))";
            return GetUsers(SearchFilter);
        }

        public static LdapType ObtainRODC()
        {
            DirectoryContext domainContext = new DirectoryContext(DirectoryContextType.Domain);
            string DCname = "";
            using (var domain = System.DirectoryServices.ActiveDirectory.Domain.GetDomain(domainContext))
            using (var controller = domain.FindDomainController())
            {
                DCname = controller.Name.Replace("." + controller.Domain.Name, "");
            }
            //MessageBox.Show(DCname);
            //string DCname = Properties.Settings.Default.DC;
            var directoryEntry = new DirectoryEntry();
            directoryEntry.AuthenticationType = AuthenticationTypes.ReadonlyServer;
            var dirSearcher = new DirectorySearcher(directoryEntry);
            try
            {
                dirSearcher.SearchScope = SearchScope.Subtree;
                //MessageBox.Show("Начало поиска");
                dirSearcher.Filter = "(&(&(sAMAccountType=805306369)(name=" + DCname + "*)))";

                SearchResult result1 = dirSearcher.FindOne();
                var dc = result1.GetDirectoryEntry();
                if (dc.GetProperty("primaryGroupID") == "516")
                {
                    return LdapType.Writable;
                    //MessageBox.Show(CurLDAP.ToString());
                }
                else
                    return LdapType.ReadOnly;

                //MessageBox.Show(dc.Name + '\t' + dc.GetProperty("primaryGroupID"));
                //MessageBox.Show("Конец поиска");
                //НЕ ИСПОЛЬЗУЙ ЭТУ КОНСТРУКЦИЮ!!!
                /*using (DirectoryEntry DC = new DirectoryEntry(result1.Path))
                {
                    MessageBox.Show(DCname + '\t' + DC.GetProperty("primaryGroupID"));
                }*/

            }
            finally
            {
                directoryEntry.Dispose();
                dirSearcher.Dispose();
            }
        }

        public static bool ChangeCn(CustomUser ChangesHolder)
        {
            string OUpath = "";
            Regex reg = new Regex(@"(=((\w+(\s)?)+(\w+)?))");
            string NewDistName = reg.Replace(ChangesHolder.DistName, "=" + ChangesHolder.Cn, 1);
            try
            {            
                using (DirectorySearcher dsSearcher = new DirectorySearcher())
                {
                    dsSearcher.Filter = InputLDAP.SearchFilter(ChangesHolder.SAMAccountName);
                    SearchResult result = dsSearcher.FindOne();

                    using (DirectoryEntry user = new DirectoryEntry(result.Path))
                    {
                        OUpath = user.Parent.GetProperty("distinguishedName");
                    }
                }            
                using (var companyOU = new DirectoryEntry("LDAP://" + OUpath))
                {
                    companyOU.Invoke("MoveHere", "LDAP://" + ChangesHolder.DistName, NewDistName);
                }
                return true;
            }
            catch (Exception e)
            {
                RefreshUser(ChangesHolder);
                if (!ChangesHolder.DistName.Equals(NewDistName,StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Не удалось изменить cn пользователя методом MoveHere"
                     + e.Message,
                         "Ошибка загрузки из AD",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    return false;
                }
                return true;
            }
        }
   
        public static void RefreshUser(CustomUser UserForChange)
        {
            using (DirectorySearcher dsSearcher = new DirectorySearcher())
            {
                dsSearcher.Filter = InputLDAP.SearchFilter(UserForChange.SAMAccountName);
                SearchResult result = dsSearcher.FindOne();
                DirectoryEntry de = result.GetDirectoryEntry();

                HasUserInfo ifUser = new DeUser(de);

                CustomUser NewUser = new CustomUser(ifUser);

                UserForChange.Copy(NewUser);

            }
        }
    }


    public static class DirectoryExtensions
    {
        //извлечение реквизитов пользователя DirectoryEntry
        public static string GetProperty(this DirectoryEntry de, string property)
        {
            string result = string.Empty;
            if (de.Properties[property].Count > 0)
            {
                result = de.Properties[property][0].ToString();
            }
            return result;
        }
        
        public static Bitmap GetPhoto(this DirectoryEntry de)
        {
            Bitmap result = CustomUser.DEFAULT_PHOTO;
            try
            {
                if (de.Properties.Contains("jpegPhoto"))
                {
                    byte[] data = de.Properties["jpegPhoto"].Value as byte[];
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
                MessageBox.Show("Ошибка во время загрузки фотографии пользователя " + de.Name + "\n"
                    + e.Message,
                         "Ошибка загрузки из AD",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                return CustomUser.DEFAULT_PHOTO;
            }
            return result;
        }
    }  

    public static class InputLDAP
    {
        //запись реквизитов в AD
        public static void InsertStringProperty(string SAMAccountName, string PropName, string PropValue)
        {
            using (DirectorySearcher dsSearcher = new DirectorySearcher())
            {
                dsSearcher.Filter = SearchFilter(SAMAccountName);
                SearchResult result = dsSearcher.FindOne();

                using (DirectoryEntry user = new DirectoryEntry(result.Path))
                {
                    user.Properties[PropName].Clear();
                    if (PropValue != string.Empty )
                      user.Properties[PropName].Add(PropValue);
                    user.CommitChanges();
                }
            }
        }
        
        public static void InsertPicture(string SAMAccountName, bool clearONly, byte[] data = null)
        {
            using (DirectorySearcher dsSearcher = new DirectorySearcher())
            {
                dsSearcher.Filter = SearchFilter(SAMAccountName);
                SearchResult result = dsSearcher.FindOne();

                using (DirectoryEntry user = new DirectoryEntry(result.Path))
                {
                    user.Properties["jpegPhoto"].Clear();
                    if (!clearONly)
                        user.Properties["jpegPhoto"].Add(data);
                    user.CommitChanges();
                }
            }
        }
        //фильтр для поиска 1 человека
        public static string SearchFilter(string SAMAccountName)
        {
            return "(&(objectClass=user) (sAMAccountName=" + SAMAccountName + "))";
        }
    }

    
}
