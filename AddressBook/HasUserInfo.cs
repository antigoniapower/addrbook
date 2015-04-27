using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;

namespace AddressBook
{
    //интерфейс пользователя из ad
    public abstract class HasUserInfo
    {
        public abstract Guid? GUID { get; }

        public abstract string DispName { get; }

        public abstract string GetStrProperty(string PropName);

        public DateTime GetDateProperty(string PropName)
        {
            DateTime result;
            if (DateTime.TryParse(GetStrProperty(PropName), out result))
                return result;
            else
                return CustomUser.DEFAULT_DATE;
        }

        public bool GetBoolProperty(string PropName)
        {
            return (GetStrProperty(PropName) == "1") ? true : false;
        }

        public abstract Bitmap GetPhoto();
        //индексатор
        public object this[ADpar attr]
        {
            get
            {
                LdapField field = Global.LdapFields[attr];
                if (field.FieldType == typeof(Bitmap))
                {
                    return GetPhoto();
                }
                else if (field.FieldType == typeof(Guid?))
                    return GUID;
                else if (field.FieldType == typeof(bool))
                    return this.GetBoolProperty(field.LdapName);
                else if (field.FieldType == typeof(DateTime))
                    return this.GetDateProperty(field.LdapName);
                else
                    return this.GetStrProperty(field.LdapName);
                
            }
        }

        public bool hasMailAndPhone()
        {
            bool hasMail = !this[ADpar.mail].ToString().Equals(String.Empty);
            bool hasPhone = !this[ADpar.phone].ToString().Equals(String.Empty);
            return hasMail || hasPhone;
        } 
    }
    
    
    public class DeUser : HasUserInfo
    {
        private DirectoryEntry de;

        public DeUser (DirectoryEntry de)
        {
            this.de = de;
        }

        public override Guid? GUID { get { return de.Guid; } }

        public override string DispName { get { return de.GetProperty("displayName"); } }

        public override string GetStrProperty(string PropName)
        {
            return de.GetProperty(PropName);
        }

        public override Bitmap GetPhoto()
        {
            return de.GetPhoto();
        }
    }


    public class PrUser : HasUserInfo
    {        
        private UserPrincipal userPrincipal;
 
        public PrUser(UserPrincipal userPrincipal)
        {
            this.userPrincipal = userPrincipal;
        }

        public override Guid? GUID
        {
            get { return userPrincipal.Guid; }
        }

        public override string DispName
        {
            get { return userPrincipal.Name; }
        }

        public override string GetStrProperty(string PropName)
        {
            return userPrincipal.GetProperty(PropName);
        }

        public override Bitmap GetPhoto()
        {
            return userPrincipal.GetPhoto();
        }

    }
 

}
