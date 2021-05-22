// Copyright 2021-2021 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System;

namespace Amber.Shared.Utilities {
    /// <summary>
    /// Utility class for enumerations
    /// </summary>
    public static class EnumerationUtilities {
        /// <summary>
        /// Get values of the given enumeration
        /// </summary>
        /// <typeparam name="T">Enumeration type</typeparam>
        /// <returns>Values</returns>
        public static T[] Values<T>() where T : Enum {
            return (T[]) Enum.GetValues(typeof(T));
        }
    }
}