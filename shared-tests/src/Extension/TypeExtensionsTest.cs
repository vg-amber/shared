// Copyright 2021-2023 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System.Collections.Generic;

using Amber.Shared.Extension;

using NUnit.Framework;

namespace Amber.Shared.Tests.Extension;

/// <summary>
/// Tests for <see cref="Shared.Extension.TypeExtensions"/>
/// </summary>
[TestFixture]
public class TypeExtensionsTest {
    [Test]
    public void Name() => Assert.That(typeof(Dictionary<string, List<int>[][]>[,,]).Name(), Is.EqualTo("Dictionary<String, List<Int32>[][]>[,,]"));
}