// Copyright 2021-2022 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System;

namespace Amber.Shared.Utility; 

/// <summary>
/// Utility class for <see cref="Enum"/>s
/// </summary>
public static class EnumerationUtilities {
    /// <summary>
    /// Get values of the given enumeration
    /// </summary>
    /// <typeparam name="T">Enumeration type</typeparam>
    /// <returns>Values</returns>
    public static T[] Values<T>() where T : Enum => (T[])Enum.GetValues(typeof(T));
}