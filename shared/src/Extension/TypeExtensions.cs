// Copyright 2021-2023 Vg-Amber Project
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
        string typeName = type.Name;

        // Treat arrays
        Type? elementType = type.GetElementType();
        if (elementType != null) {
            return $"{elementType.Name()}{typeName[elementType.Name.Length..]}";
        }

        // Treat generic arguments
        Type[] genericArguments = type.GetGenericArguments();
        return genericArguments.IsEmpty() ?
            typeName
            :
            $"{typeName[..typeName.IndexOf("`", StringComparison.Ordinal)]}<{string.Join(", ", genericArguments.Select(Name))}>";
    }
}