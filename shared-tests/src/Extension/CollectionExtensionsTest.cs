// Copyright 2021-2022 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System;
using System.Collections.Generic;

using Amber.Shared.Extension;

using NUnit.Framework;

namespace Amber.Shared.Tests.Extension;

/// <summary>
/// Tests for <see cref="Shared.Extension.CollectionExtensions"/>
/// </summary>
[TestFixture]
public class CollectionExtensionsTest {
    [Test]
    public void ForEach() {
        int[] array = { 1, 2, 3 };
        var list = new List<int>();

        array.ForEach(list.Add);
        Assert.That(list, Is.EquivalentTo(array));

        list.Clear();
        Array.Empty<int>().ForEach(list.Add);
        Assert.That(list, Is.Empty);
    }

    [Test]
    public void NonNull() {
        int?[] intArrayWithNull = { 1, 2, null, 3 };
        int?[] emptyArray = Array.Empty<int?>();
        int?[] intArray = { 1, 2, 3 };

        Assert.That(intArrayWithNull.NonNull(), Is.EquivalentTo(intArray));
        Assert.That(intArray.NonNull(), Is.EquivalentTo(intArray));
        Assert.That(emptyArray.NonNull(), Is.Empty);

        Type?[] typeArrayWithNull = { typeof(double), typeof(int), null, typeof(string) };
        Type[] typeArray = { typeof(double), typeof(int), typeof(string) };

        Assert.That(typeArrayWithNull.NonNull(), Is.EquivalentTo(typeArray));
        Assert.That(typeArray.NonNull(), Is.EquivalentTo(typeArray));
        Assert.That(emptyArray.NonNull(), Is.Empty);
    }

    [Test]
    public void IsEmpty() {
        var emptyList = new List<int>();
        var list = new List<int>(new[] { 1, 2 });
        int[] emptyArray = Array.Empty<int>();
        int[] array = { 1, 2 };

        Assert.IsTrue(emptyList.IsEmpty());
        Assert.IsTrue(emptyArray.IsEmpty());

        Assert.IsFalse(list.IsEmpty());
        Assert.IsFalse(array.IsEmpty());
    }

    [Test]
    public void RemoveFirst() {
        LinkedList<int> list = Create(0, 1, 2, 3);

        Assert.IsNull(list.RemoveFirst(i => i == 10));

        int? value = list.RemoveFirst(i => i == 2)?.Value;
        Assert.That(value, Is.EqualTo(2));
        Assert.That(list, Is.EqualTo(new[] { 0, 1, 3 }));
    }

    /// <summary>
    /// Create a linked list with the given items
    /// </summary>
    /// <param name="items">Items</param>
    /// <typeparam name="T">Item type</typeparam>
    /// <returns>Linked list</returns>
    private static LinkedList<T> Create<T>(params T[] items) => new(items);
}