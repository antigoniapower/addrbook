using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public enum ADpar
    {
        guid,
        photo,
        displayName,
        firstName,
        midName,
        lastName,//LastName
        distName,
        sAMAccountName,
        cn,
        birthday,
        dontShowBirthYear,
        mail,
        phone,
        link,
        mobile,
        title,
        department,
        bossAD,
        startJob
    }

    public class LdapField
    {
       // private ADpar attr;
        private string ldapName;
        private string description;
        private Type fieldType;

        public LdapField(/*ADpar attr, */string ldapName, string description, Type fieldType)
        {
           // this.attr = attr;
            this.ldapName = ldapName;
            this.description = description;
            this.fieldType = fieldType;
        }

       // public ADpar Attr { get { return attr; } }
        public string LdapName { get {return ldapName;}}
        public string Description {get{return description;}}
        public Type FieldType {get {return fieldType;}}
    }

    public static class Global
    {
        static string FirstNameDesc = "Имя" + (!Properties.Settings.Default.ShowMidName ? " и отчество" : "");
        public static Dictionary<ADpar, LdapField> LdapFields = new Dictionary<ADpar, LdapField>()
        {
            {ADpar.guid ,new LdapField(ldapName:"guid", description: "Уникальный идентификатор",fieldType: typeof(Guid?))},
            {ADpar.photo ,new LdapField(ldapName:"jpegPhoto", description: "Фотография",fieldType: typeof(System.Drawing.Bitmap))},
            {ADpar.displayName ,new LdapField(ldapName:"displayName", description:"Отображаемое имя" , fieldType:typeof(string))},
            {ADpar.firstName ,new LdapField( ldapName:"givenName", description: FirstNameDesc, fieldType: typeof(string))},
            {ADpar.distName ,new LdapField( ldapName:"DistinguishedName", description: "Имя в  AD", fieldType: typeof(string))},
            {ADpar.midName ,new LdapField( ldapName:"initials", description:"Отчество" , fieldType: typeof(string))},
            {ADpar.lastName ,new LdapField( ldapName:"sn", description:"Фамилия" , fieldType: typeof(string))},
            {ADpar.sAMAccountName ,new LdapField( ldapName:"sAMAccountName", description: "sAMAccountName", fieldType: typeof(string))},
            {ADpar.cn ,new LdapField( ldapName:"cn", description: "cn", fieldType: typeof(string))},
            {ADpar.birthday ,new LdapField( ldapName:"employeeNumber", description: "Дата рождения", fieldType: typeof(DateTime))},
            {ADpar.dontShowBirthYear ,new LdapField( ldapName:"employeeType", description: "Отображение года рождения", fieldType: typeof(bool))},
            {ADpar.mail ,new LdapField( ldapName:"mail", description: "Почта", fieldType: typeof(string))},
            {ADpar.phone ,new LdapField( ldapName:"telephoneNumber", description: "Номер телефона", fieldType: typeof(string))},
            {ADpar.link ,new LdapField( ldapName:"pager", description: "Link", fieldType: typeof(string))},
            {ADpar.mobile ,new LdapField( ldapName:"mobile", description: "Мобильный телефон", fieldType: typeof(string))},
            {ADpar.title ,new LdapField( ldapName:"title", description: "Должность", fieldType: typeof(string))},
            {ADpar.department ,new LdapField( ldapName:"department", description: "Отдел", fieldType: typeof(string))},
            {ADpar.bossAD ,new LdapField( ldapName:"manager", description: "Начальник", fieldType: typeof(string))},
            {ADpar.startJob ,new LdapField( ldapName:"employeeID", description: "Дата начала работы", fieldType: typeof(DateTime))}
        
        };       
    }
}
