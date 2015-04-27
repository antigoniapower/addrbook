using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook
{
    //сравнение строк регистронезависимое
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }

    //новое письмо на адрес
    public static class MailTo
    {
        public static void Send(string MailAddress)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "mailto:" + MailAddress;
            proc.Start();
        }
    }
    
}
