using System.Collections.Generic;
using Amber.Shared.Extensions;
using NUnit.Framework;

namespace Amber.Shared.Tests.Extensions {
    /// <summary>
    /// Tests for <see cref="Shared.Extensions.CollectionExtensions"/>
    /// </summary>
    [TestFixture]
    public class CollectionExtensionsTest {
        [Test]
        public void ForEach() {
            var array = new[] { 1, 2, 3 };
            var list = new List<int>();

            array.ForEach(list.Add);
            Assert.That(list, Is.EquivalentTo(array));

            list.Clear();
            new int[0].ForEach(list.Add);
            Assert.That(list, Is.Empty);
        }

        [Test]
        public void NonNull() {
            var intArrayWithNull = new int?[] { 1, 2, null, 3 };
            var intArray = new int?[] { 1, 2, 3 };

            Assert.That(intArrayWithNull.NonNull(), Is.EquivalentTo(intArray));
            Assert.That(intArray.NonNull(), Is.EquivalentTo(intArray));
            Assert.That(new int?[0].NonNull(), Is.Empty);

            var typeArrayWithNull = new[] { typeof(double), typeof(int), null, typeof(string) };
            var typeArray = new[] { typeof(double), typeof(int), typeof(string) };

            Assert.That(typeArrayWithNull.NonNull(), Is.EquivalentTo(typeArray));
            Assert.That(typeArray.NonNull(), Is.EquivalentTo(typeArray));
            Assert.That(new int?[0].NonNull(), Is.Empty);
        }

        [Test]
        public void IsEmpty() {
            var emptyList = new List<int>();
            var list = new List<int>(new[] { 1, 2 });
            var emptyArray = new int[0];
            var array = new[] { 1, 2 };

            Assert.IsTrue(emptyList.IsEmpty());
            Assert.IsTrue(emptyArray.IsEmpty());

            Assert.IsFalse(list.IsEmpty());
            Assert.IsFalse(array.IsEmpty());
        }

        [Test]
        public void RemoveFirst() {
            var list = Create(0, 1, 2, 3);

            Assert.IsNull(list.RemoveFirst(i => i == 10));

            var value = list.RemoveFirst(i => i == 2)?.Value;
            Assert.That(value, Is.EqualTo(2));
            Assert.That(list, Is.EqualTo(new[] { 0, 1, 3 }));
        }

        /// <summary>
        /// Create a linked list with the given items
        /// </summary>
        /// <param name="items">Items</param>
        /// <typeparam name="T">Item type</typeparam>
        /// <returns>Linked list</returns>
        private static LinkedList<T> Create<T>(params T[] items) => new LinkedList<T>(items);
    }
}