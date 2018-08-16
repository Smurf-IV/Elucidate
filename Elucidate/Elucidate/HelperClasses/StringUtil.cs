using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Elucidate.HelperClasses
{
    public static class StringUtil
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(@"the string to find may not be empty", nameof(value));

            List<int> indexList = Regex.Matches(str, value).Cast<Match>()
                .Select(m => m.Index)
                .ToList();
            return indexList;
        }

        public static IEnumerable<int> AllIndexesOf(this string str, string value, StringComparison stringComparison)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(@"the string to find may not be empty", nameof(value));

            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index, stringComparison);
                if (index == -1)
                    break;
                yield return index;
            }
        }
    }
}
