// Copyright 2021-2023 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System;
using System.Threading.Tasks;

using Amber.Shared.Exception;

using NUnit.Framework;

namespace Amber.Shared.Tests.Exception;

/// <summary>
/// Tests for <see cref="UnknownEnumException{T}"/>
/// </summary>
[TestFixture]
public class UnknownEnumExceptionTest {
    [Test]
    public void Constructor() {
        const TaskCreationOptions input = TaskCreationOptions.None;
        var ex = new UnknownEnumException<TaskCreationOptions>(input);

        Assert.That(ex, Has.Message.EqualTo("Unknown TaskCreationOptions: None"));
        Assert.That(ex.Value, Is.EqualTo(input));

        ex = new UnknownEnumException<TaskCreationOptions>(input, new ApplicationException());
        Assert.That(ex.InnerException, Is.InstanceOf<ApplicationException>());
    }
}