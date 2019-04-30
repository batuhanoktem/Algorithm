using System;
using System.Linq;

namespace Algorithm.Helper
{
    public static class StringHelper
    {
        public static string EditUrl(this string str)
        {
            try
            {
                return str.Trim().ToLower().Replace('ı', 'i').Replace('ğ', 'g').Replace('ş', 's')
                             .Replace('ö', 'o').Replace('ü', 'u').Replace(' ', '-').Replace('ç', 'c');
            }
            catch
            {
                return str;
            }
        }
        public static string CleanHtml(this string str)
        {
            try
            {
                var cleanContent = System.Text.RegularExpressions.Regex.Replace(str, "<.*?>", String.Empty);
                cleanContent = System.Text.RegularExpressions.Regex.Replace(cleanContent, "&r.quo;", String.Empty);
                return System.Text.RegularExpressions.Regex.Replace(cleanContent, "&nbsp;", String.Empty);
            }
            catch
            {
                return str;
            }
        }
        public static string FirstCharToUpper(this string input)
        {
            return input.GetString().First().ToString().ToUpper() + input.GetString().Substring(1);
        }
    }
}
