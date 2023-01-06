// Copyright 2021-2023 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using Amber.Shared.Extension;

using NUnit.Framework;

namespace Amber.Shared.Tests.Extension;

/// <summary>
/// Tests for <see cref="StringExtensions"/>
/// </summary>
[TestFixture]
public class StringExtensionsTest {
    [Test]
    public void ToTitleCase() {
        Assert.That("".ToTitleCase(), Is.Empty);
        Assert.That("test".ToTitleCase(), Is.EqualTo("Test"));
        Assert.That("_test".ToTitleCase(), Is.EqualTo("Test"));
        Assert.That("test_test_".ToTitleCase(), Is.EqualTo("TestTest"));
        Assert.That("TEST_TEST_".ToTitleCase(), Is.EqualTo("TestTest"));
    }
}