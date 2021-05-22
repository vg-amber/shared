// Copyright 2021-2021 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

namespace Amber.Shared.Functions {
    /// <summary>
    /// Predicate for a <typeparamref name="T"/> object
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public interface IPredicate<in T> {
        /// <summary>
        /// Test whether <paramref name="obj"/> satisfies this predicate
        /// </summary>
        /// <param name="obj">Value to test</param>
        /// <returns>true if <paramref name="obj"/> satisfies this predicate, false otherwise</returns>
        public bool Test(T obj);
    }

    /// <summary>
    /// Predicate for a <typeparamref name="T0"/> and <typeparamref name="T1"/> objects
    /// </summary>
    /// <typeparam name="T0">First object type</typeparam>
    /// <typeparam name="T1">Second object type</typeparam>
    public interface IPredicate<in T0, in T1> {
        /// <summary>
        /// Test whether <paramref name="first"/>, <paramref name="second"/> satisfy this predicate
        /// </summary>
        /// <param name="first">First value to test</param>
        /// <param name="second">Second value to test</param>
        /// <returns>true if <paramref name="first"/>, <paramref name="second"/> satisfy this predicate, false otherwise</returns>
        public bool Test(T0 first, T1 second);
    }
}