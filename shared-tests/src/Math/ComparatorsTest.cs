// Copyright 2021-2023 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using Amber.Shared.Math;

using NUnit.Framework;

namespace Amber.Shared.Tests.Math;

/// <summary>
/// Tests for <see cref="Comparators"/>
/// </summary>
[TestFixture]
public class ComparatorsTest {
    [Test]
    public void Compare() {
        int[] integers = { 1, 2, 3 };

        for (int i = 0; i < integers.Length; i++) {
            int integer = integers[i];
            for (int j = 0; j < integers.Length; j++) {
                int otherInteger = integers[j];

                if (i == j) {
                    Assert.IsTrue(Comparators.Compare(integer, ComparisonSymbol.Equal, otherInteger));
                    Assert.IsTrue(Comparators.Compare(integer, ComparisonSymbol.LessOrEqual, otherInteger));
                    Assert.IsTrue(Comparators.Compare(integer, ComparisonSymbol.GreaterOrEqual, otherInteger));

                    Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.LessThan, otherInteger));
                    Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.GreaterThan, otherInteger));
                } else if (i < j) {
                    Assert.IsTrue(Comparators.Compare(integer, ComparisonSymbol.LessThan, otherInteger));
                    Assert.IsTrue(Comparators.Compare(integer, ComparisonSymbol.LessOrEqual, otherInteger));

                    Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.Equal, otherInteger));
                    Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.GreaterThan, otherInteger));
                    Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.GreaterOrEqual, otherInteger));
                } else {
                    Assert.IsTrue(Comparators.Compare(integer, ComparisonSymbol.GreaterThan, otherInteger));
                    Assert.IsTrue(Comparators.Compare(integer, ComparisonSymbol.GreaterOrEqual, otherInteger));

                    Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.Equal, otherInteger));
                    Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.LessThan, otherInteger));
                    Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.LessOrEqual, otherInteger));
                }
            }
        }
    }
}