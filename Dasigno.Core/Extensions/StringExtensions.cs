using Dasigno.Core.Helpers;
using System;
using System.Linq;

namespace Dasigno.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        public static string FirstCharToUpper(this string str)
        {
            try
            {
                string input = str.ToString().ToLower() ?? throw new Exception();
                return input.First().ToString().ToUpper() + input.Substring(1);
            }
            catch { return string.Empty; }
        }

        public static string ConcatNames(string name, string firstName = "", string secondName = "", string secondSurname = "")
        {
            string names = name ?? "";
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                names += " " + firstName;
            }
            names += " " + (secondName ?? "");
            if (!string.IsNullOrWhiteSpace(secondSurname))
            {
                names += " " + secondSurname;
            }
            return names;
        }

        public static string Encrypt(this string str)
        {
            return CipherHelper.Encrypt(str);
        }

        public static string Decrypt(this string str)
        {
            return CipherHelper.Decrypt(str);
        }

        public static object ToDbNullable(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? (object)DBNull.Value : str;
        }

        public static string RemoveFromAtSymbol(this string input)
        {
            int atIndex = input.IndexOf('@');
            if (atIndex >= 0)
            {
                return input.Substring(0, atIndex);
            }
            else
            {
                return input;
            }
        }
    }
}
