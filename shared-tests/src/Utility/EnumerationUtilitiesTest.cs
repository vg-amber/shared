// Copyright 2021-2022 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System;
using System.Threading.Tasks;
using Amber.Shared.Utility;
using NUnit.Framework;

namespace Amber.Shared.Tests.Utility;

/// <summary>
/// Tests for <see cref="EnumerationUtilitiesTest"/>
/// </summary>
[TestFixture]
public class EnumerationUtilitiesTest {
    [Test]
    public void Values() {
        Assert.That(EnumerationUtilities.Values<TaskCreationOptions>(), Is.EquivalentTo(Enum.GetValues(typeof(TaskCreationOptions))));
    }
}