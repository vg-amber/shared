using System;
using Amber.Shared.Exceptions;

namespace Amber.Shared.Maths {
    /// <summary>
    /// Comparison symbols
    /// </summary>
    public enum ComparisonSymbol {
        LessThan,
        LessOrEqual,
        Equal,
        GreaterOrEqual,
        GreaterThan
    }

    /// <summary>
    /// Class for comparison methods
    /// </summary>
    public static class Comparators {
        /// <summary>
        /// Compare left and right based on the given comparison symbol
        /// </summary>
        /// <param name="left">Left value</param>
        /// <param name="symbol">Comparison symbol</param>
        /// <param name="right">Right value</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>true if <paramref name="left"/> <paramref name="symbol"/> <paramref name="right"/>, false otherwise</returns>
        /// <exception cref="UnknownEnumException{T}">Exception thrown when an unknown enumeration is encountered</exception>
        public static bool Compare<T>(T left, ComparisonSymbol symbol, T right) where T : IComparable<T> {
            return symbol switch {
                ComparisonSymbol.LessThan       => left.CompareTo(right) < 0,
                ComparisonSymbol.LessOrEqual    => left.CompareTo(right) <= 0,
                ComparisonSymbol.Equal          => left.CompareTo(right) == 0,
                ComparisonSymbol.GreaterOrEqual => left.CompareTo(right) >= 0,
                ComparisonSymbol.GreaterThan    => left.CompareTo(right) > 0,
                _                               => throw new UnknownEnumException<ComparisonSymbol>(symbol)
            };
        }
    }
}