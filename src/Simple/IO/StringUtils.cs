﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;

namespace Simple.IO
{
    public class StringUtils
    {
        public static string RemoveDiacritics(string s)
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder(s.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        public static IEnumerable<string> Split(string s, string charSelectorRegex)
        {
            var regex = new Regex(charSelectorRegex);
            return Split(s, x => regex.IsMatch(x.ToString()));
        }

        public static IEnumerable<string> Split(string s, Func<char, bool> charSelector)
        {
            StringBuilder buffer = new StringBuilder(s.Length);
            foreach(char c in s)
            {
                if (charSelector(c))
                    buffer.Append(c);
                else
                    if (buffer.Length > 0)
                    {
                        yield return buffer.ToString();
                        buffer.Length = 0;
                    }
            }
            if (buffer.Length > 0)
                yield return buffer.ToString();

            yield break;
        }
    }
}