// Copyright 2021-2023 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System.Globalization;
using System.Text;

namespace Amber.Shared.Extension;

/// <summary>
/// Extensions for <see cref="string"/>s
/// </summary>
public static class StringExtensions {
    /// <summary>
    /// Convert a string containing letters and underscores into a title case string without underscores
    /// </summary>
    /// <param name="str">String</param>
    /// <param name="cultureInfo">Culture information used to convert characters</param>
    /// <returns>Transformed string</returns>
    public static string ToTitleCase(this string str, CultureInfo cultureInfo) {
        var builder = new StringBuilder(str.Length);

        for (int i = 0; i < str.Length; i++) {
            if (str[i] == '_') {
                continue;
            }

            builder.Append(
                i == 0 || str[i - 1] == '_'
                    ? char.ToUpper(str[i], cultureInfo)
                    : char.ToLower(str[i], cultureInfo)
            );
        }

        return builder.ToString();
    }
}