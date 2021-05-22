using Amber.Shared.Maths;
using NUnit.Framework;

namespace Amber.Shared.Tests.Maths {
    /// <summary>
    /// Tests for <see cref="Comparators"/>
    /// </summary>
    [TestFixture]
    public class ComparatorsTest {
        [Test]
        public void Compare() {
            var integers = new[] { 1, 2, 3 };

            for (var i = 0; i < integers.Length; i++) {
                var integer = integers[i];
                for (var j = 0; j < integers.Length; j++) {
                    var otherInteger = integers[j];

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
                    } else if (i > j) {
                        Assert.IsTrue(Comparators.Compare(integer, ComparisonSymbol.GreaterThan, otherInteger));
                        Assert.IsTrue(Comparators.Compare(integer, ComparisonSymbol.GreaterOrEqual, otherInteger));

                        Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.Equal, otherInteger));
                        Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.LessThan, otherInteger));
                        Assert.IsFalse(Comparators.Compare(integer, ComparisonSymbol.LessOrEqual, otherInteger));
                    } else {
                        Assert.Fail($"i: {i}, j: {j} => not tested");
                    }
                }
            }
        }
    }
}