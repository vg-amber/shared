// Copyright 2021-2022 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System;
using System.Linq;

namespace Amber.Shared.Extension;

/// <summary>
/// Extensions for <see cref="Type"/>s
/// </summary>
public static class TypeExtensions {
    /// <summary>
    /// Generate a pretty version of the name of the given type especially for generic types
    /// </summary>
    /// <param name="type">Type</param>
    /// <returns>Pretty name</returns>
    public static string Name(this Type type) {
        var genericArguments = type.GetGenericArguments();
        if (genericArguments.IsEmpty()) {
            return type.Name;
        }

        var name = type.Name;
        var prettyName = name[..name.IndexOf("`", StringComparison.Ordinal)];
        return prettyName + "<" + string.Join(", ", genericArguments.Select(Name)) + ">";
    }
}