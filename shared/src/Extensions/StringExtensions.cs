// Copyright 2021-2021 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System.Text;

namespace Amber.Shared.Extensions {
    /// <summary>
    /// Extensions for strings
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        /// Convert a string containing letters and underscores into a title case string without underscores
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Transformed string</returns>
        public static string ToTitleCase(this string str) {
            var builder = new StringBuilder();

            for (var i = 0; i < str.Length; i++) {
                if (str[i] == '_') {
                    continue;
                }

                if (i == 0 || str[i - 1] == '_') {
                    builder.Append(char.ToUpper(str[i]));
                } else {
                    builder.Append(char.ToLower(str[i]));
                }
            }

            return builder.ToString();
        }
    }
}