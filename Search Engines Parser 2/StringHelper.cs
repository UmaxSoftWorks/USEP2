using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Search_Engines_Parser_2
{
    static class StringHelper
    {
        public static string DecodeHtml(this string Value)
        {
            string[] parts = Value.Split(new char[] {';'}, StringSplitOptions.None);

            StringBuilder builder = new StringBuilder(Value.Length);

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Contains("&#x"))
                {
                    int index = parts[i].IndexOf("&#x");

                    builder.Append(parts[i].Substring(0, index));

                    char character = (char) int.Parse(parts[i].Substring(index + 3), System.Globalization.NumberStyles.HexNumber);

                    builder.Append(character);
                }
                else if (!string.IsNullOrEmpty(parts[i]) && parts[i] != " ")
                {
                    builder.Append(parts[i] + (Value.Contains(";") ? ";" : string.Empty));
                }
            }

            return builder.ToString().Trim(';');
        }
    }
}
