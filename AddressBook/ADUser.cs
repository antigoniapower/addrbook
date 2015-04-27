using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AddressBook
{
    public class CustomUser : ICloneable
    {

        public static DateTime DEFAULT_DATE = new DateTime(1900, 01, 01);
        public static Bitmap DEFAULT_PHOTO = new Bitmap(100, 100);
        public static int FIELD_COUNT = 15;

        #region Закрытые члены

        //GUID
        private Guid? guid;
        //фото
        private Bitmap photo;
        //основная информация
        private string displayName;
        private string firstName;
        private string midName;
        private string lastName;
        private string sAMAccountName;
        private string cn;
        public string DistName;
        private DateTime birthday;
        private bool showBirthYear;
        //контакты
        private string mail;
        private string phone;
        private string link;
        private string mobile;
        //организация
        private string title;
        private string department;
        private string bossAD;
        private DateTime startJob;

        #endregion

        #region Публичные свойства

        //GUID
        public Guid? GUID { get { return guid; } set { guid = value; } }
        //фото
        public Bitmap Photo { get { return photo; } set { photo = value; } }
        //основная информация
        public string DislpayName { get { return displayName; } set { displayName = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string MidName { get { return midName; } set { midName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public DateTime Birthday { get { return birthday; } set { birthday = value; } }
        public bool DontShowBirthYear { get { return showBirthYear; } set { showBirthYear = value; } }
        public string SAMAccountName { get { return sAMAccountName; } set { sAMAccountName = value; } }
        public string Cn { get { return cn; } set { cn = value; } }
        //контакты
        public string Mail { get { return mail; } set { mail = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Link { get { return link; } set { link = value; } }
        public string Mobile { get { return mobile; } set { mobile = value; } }
        //организация
        public string Title { get { return title; } set { title = value; } }
        public string Department { get { return department; } set { department = value; } }
        public string Boss { get { return ExtractBoss(); } set { bossAD = value; } }
        public DateTime StartJob { get { return startJob; } set { startJob = value; } }

        #endregion

        //конструктор
        public CustomUser()
        {
            SetDefaults();
        }
        //инициализация значениями по умолчанию
        public void SetDefaults()
        {
            guid = null;
            //фото
            photo = DEFAULT_PHOTO;
            //основная информация
            displayName = string.Empty;
            firstName = string.Empty;
            midName = string.Empty;
            lastName = string.Empty;
            birthday = DEFAULT_DATE;
            showBirthYear = true;
            //контакты
            mail = string.Empty;
            phone = string.Empty;
            link = string.Empty;
            mobile = string.Empty;
            //организация
            title = string.Empty;
            department = string.Empty;
            bossAD = string.Empty;
            startJob = DEFAULT_DATE;
        }
        //конструктор из IHasUserInfo
        public CustomUser(HasUserInfo UserFromAD)
        {
            this.guid = UserFromAD.GUID;
            this.DislpayName = UserFromAD.DispName;

            foreach(ADpar attr in Enum.GetValues(typeof(ADpar)))
            {
                this[attr] = UserFromAD[attr];
            }
        }
        
        //индексатор
        public object this[ADpar attr]
        {
            get
            {
                // Возврат значения, которое определяет индекс.
                switch (attr)
                {
                    //идентификатор
                    case ADpar.guid: return guid;
                    //фото
                    case ADpar.photo: return photo;
                    //основная информация
                    case ADpar.displayName: return displayName;
                    case ADpar.firstName: return firstName;
                    case ADpar.midName: return midName;
                    case ADpar.lastName: return lastName;
                    case ADpar.sAMAccountName: return SAMAccountName;
                    case ADpar.cn: return cn;
                    case ADpar.distName: return DistName;
                    case ADpar.birthday: return birthday;
                    case ADpar.dontShowBirthYear: return showBirthYear;
                    //контакты
                    case ADpar.mail: return mail;
                    case ADpar.phone: return phone;
                    case ADpar.link: return link;
                    case ADpar.mobile: return mobile;
                    //организация
                    case ADpar.title: return title;
                    case ADpar.department: return department;
                    case ADpar.bossAD: return bossAD;
                    case ADpar.startJob: return startJob;
                    //по умолчанию
                    default: return null;
                }
            }
            // Аксессор для установки данных,
            set
            {
                switch (attr)
                {
                    //идентификатор
                    case ADpar.guid: guid = value as Guid?; break;
                    //фото
                    case ADpar.photo: photo = value as Bitmap; break;
                    //основная информация
                    case ADpar.displayName: displayName = value as string; break;
                    case ADpar.firstName: firstName = value as string; break;
                    case ADpar.midName: midName = value as string; break;
                    case ADpar.lastName: lastName = value as string; break;
                    case ADpar.sAMAccountName: sAMAccountName = value as string; break;
                    case ADpar.cn: cn = value as string; break;
                    case ADpar.distName: DistName = value as string; break;
                    case ADpar.birthday: birthday = Convert.ToDateTime(value); break;
                    case ADpar.dontShowBirthYear: showBirthYear = Convert.ToBoolean(value); break;
                    //контакты
                    case ADpar.mail: mail = value as string; break;
                    case ADpar.phone: phone = value as string; break;
                    case ADpar.link: link = value as string; break;
                    case ADpar.mobile: mobile = value as string; break;
                    //организация
                    case ADpar.title: title = value as string; break;
                    case ADpar.department: department = value as string; break;
                    case ADpar.bossAD: bossAD = value as string; break;
                    case ADpar.startJob: startJob = Convert.ToDateTime(value); break;
                }
            }
        }
        
        //клонирование и копирование
        public object Clone()
        {
            CustomUser outUser = new CustomUser();
            var ADparIndexes = Enum.GetValues(typeof(ADpar));
            for (int i = 0; i <= ADparIndexes.Length; i++)
            {
                outUser[(ADpar)i] = this[(ADpar)i];
            }
            return outUser;
        }

        public void Copy(CustomUser inUser)
        {
            CustomUser outUser = new CustomUser();
            var ADparIndexes = Enum.GetValues(typeof(ADpar));
            for (int i = 0; i <= ADparIndexes.Length; i++)
            {
                this[(ADpar)i] = inUser[(ADpar)i];
            }
        }
        
        //разбор начальник
        private string ExtractBoss()
        {
            //регулярное выражение в шаблоне используются 4 группы
            string result = string.Empty;
            string pattern = @"(^CN=)(\w+\s)+(\w+)?([,])";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            // Получаем совпадения в экземпляре класса Match
            Match match = regex.Match(bossAD);
            if (match.Success)
            {
                string bossUntrimmed = match.Groups[0].Value;
                //удаляем сначала ',' потом 'CN='
                result = (bossUntrimmed.Remove(bossUntrimmed.Length - 1)).Remove(0, 3);
            }
            return result;
        }
        //задать нового начальника
        private void SetAnotherBoss(string NewBoss)
        {
            //регулярное выражение в шаблоне используются 0-2 группы
            string pattern = @"((\w+\s)+(\w+)?)";
            bossAD = Regex.Replace(bossAD, pattern, NewBoss);            
        }

        //Active Directory
        public bool WriteStrToAD(string PropName, string PropValue)
        {
            try
            {
                InputLDAP.InsertStringProperty(SAMAccountName, PropName, PropValue);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка записи реквизита в базу Active Directory:\n" +
                    PropName.ToString() +
                    "\n" + e.Message,
                    "Ошибка записи в AD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return false;
            }
        }

        public bool WritePhotoToAD(byte[] ImageBytes)
        {
            try
            {
                InputLDAP.InsertPicture(SAMAccountName, false, ImageBytes);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка записи фотографии в базу Active Directory\n" + e.Message,
                    "Ошибка записи в AD",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Hand);
                return false;
            }
        }

        public bool ClearPhotoFromAD()
        {
            try
            {
                InputLDAP.InsertPicture(SAMAccountName, true);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка записи фотографии в базу Active Directory\n" + e.Message,
                     "Ошибка записи в AD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return false;
            }
        }

        public bool WriteShowYearToAD(bool DontShowYear)
        {
            try
            {
                string AdDontShowYear = DontShowYear ? "1" : "0";
                InputLDAP.InsertStringProperty(SAMAccountName, "employeeType", AdDontShowYear);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка записи информации о годе рождении в базу Active Directory\n"
                     + e.Message,
                         "Ошибка загрузки из AD",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                return false;
            }
        }

        public bool HaveDifferences(CustomUser inUser, out List<ADpar> DifferencesArray)
        {
            DifferencesArray = new List<ADpar>();
            bool result = false;
            foreach (ADpar attr in Enum.GetValues(typeof(ADpar)))
            {
               if (
                        (this[attr] is string) && (!this[attr].ToString().Equals(inUser[attr])) ||
                        (this[attr] is DateTime) && (!this[attr].Equals(inUser[attr])) ||
                        (this[attr] is bool) && (Convert.ToBoolean(this[attr]) != Convert.ToBoolean(inUser[attr])) ||
                        (this[attr] is Bitmap) &&(this[attr] != inUser[attr])
                   )
                {
                        DifferencesArray.Add(attr);
                        result = true;
                }
                
            }
            return result;
        }

    }

    public class CustomUserList : List<CustomUser>
    {
        public CustomUser GetUserByGuid(Guid? aGuid)
        {
            CustomUser result = new CustomUser();

            foreach (CustomUser user in this)
            {
                if (user.GUID == aGuid)
                {
                    result = user;
                    break;
                }
            }
            return result;
        }
   
    public CustomUser GetUserBySamaccountName(string SAMAccountName)
        {
            CustomUser result = new CustomUser();

            foreach (CustomUser user in this)
            {
                if (user.SAMAccountName.Equals(SAMAccountName, StringComparison.OrdinalIgnoreCase))
                {
                    result = user;
                    break;
                }
            }
            return result;
        }
    }
    
    
    //пользовательские права
    public static class CurrentUser
    {
        public static string SAMAccountName;
        public static bool isManager = false;
        public static void FindIfManager()
        {
            var UserGroups = PU.GetUserGroups(Environment.UserName);
            isManager = UserGroups.Contains(Properties.Settings.Default.ManagerGroup);
        }
        static CurrentUser()
        {
            SAMAccountName = Environment.UserName;            
        }
    }

    public static class CurrentBoss
    {
        public static CustomUser boss;

    }
     
}
