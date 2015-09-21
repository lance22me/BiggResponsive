using System;
using System.Text.RegularExpressions;

namespace BiggResponsive.Domain.Extensions
{
    public static class ExtensionMethods
    {

        public static bool HasUpperCase(this string s)
        {
            var re = new Regex(@"[A-Z]");
            return re.IsMatch(s);
        }

        public static bool HasLowerCase(this string s)
        {
            var re = new Regex(@"[a-z]");
            return re.IsMatch(s);
        }

        /// <summary>
        /// Cuz we hates special characters in strings.  We hates them, my precious.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static bool HasSpecialCharacter(this string s)
        {
            var re = new Regex(@"[~/@/$/ /^/&/*/(/)/-/_/+/=/`/!]");
            return re.IsMatch(s);
        }

        /// <summary>
        /// Formats phone numbers
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>string phonenumber (123) 123-1234</returns>
        public static string FormatPhoneNumber(this string s)
        {
            if (s == null)
            {
                return string.Empty;
            }
            string contactNumber = StripPhoneString(s);
            if (contactNumber.Length > 8)
            {
                return String.Format("{0:(###) ###-####}", double.Parse(contactNumber));
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Strips the phone string.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>unformatted string</returns>
        public static string StripPhoneString(this string s)
        {
            string newValue = string.Empty;
            foreach (char ch in s)
            {
                if (ch != ' ' && ch != '(' && ch != ')' && ch != '-' && ch != '.')
                {
                    if (char.IsNumber(ch))
                    {
                        newValue += ch;
                    }
                }
            }
            return newValue;
        }

    }
}
