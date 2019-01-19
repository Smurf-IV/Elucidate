#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="StringUtil.cs" company="Smurf-IV">
// 
//  Copyright (C) 2010-2019 Simon Coghlan (Aka Smurf-IV)
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 2 of the License, or
//   any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see http://www.gnu.org/licenses/.
//  </copyright>
//  <summary>
//  Url: https://github.com/Smurf-IV/Elucidate
//  Email: https://github.com/Smurf-IV
//  </summary>
// --------------------------------------------------------------------------------------------------------------------
#endregion

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
            {
                throw new ArgumentException(@"the string to find may not be empty", nameof(value));
            }

            List<int> indexList = Regex.Matches(str, value).Cast<Match>()
                .Select(m => m.Index)
                .ToList();
            return indexList;
        }

        public static IEnumerable<int> AllIndexesOf(this string str, string value, StringComparison stringComparison)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(@"the string to find may not be empty", nameof(value));
            }

            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index, stringComparison);
                if (index == -1)
                {
                    break;
                }

                yield return index;
            }
        }
    }
}
