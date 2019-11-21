using System.Text.RegularExpressions;

namespace MicrowaveOvenClasses
{
    //This class was created using an answer by Dmitri Bychenko on Stack Overflow on May 18 '15
    //Link: https://stackoverflow.com/a/30300521
    public static class RegexHelper
    {
        public static bool MatchWithWildCard(string value, string pattern)
        {
            return Regex.IsMatch(value, WildCardToRegular(pattern));
        }

        private static string WildCardToRegular(string pattern)
        {
            return "^" + Regex.Escape(pattern).Replace("\\*", ".*") + "$";
        }
    }
}