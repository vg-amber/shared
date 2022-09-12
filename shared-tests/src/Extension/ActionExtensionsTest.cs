// Copyright 2021-2022 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System;
using System.Threading;
using System.Threading.Tasks;
using Amber.Shared.Extension;
using NUnit.Framework;

namespace Amber.Shared.Tests.Extension; 

/// <summary>
/// Tests for <see cref="ActionExtensions"/>
/// </summary>
[TestFixture]
public class ActionExtensionsTest {
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(5);

    [Test]
    public void RunAsync() {
        var startEvent = new CountdownEvent(1);
        Thread? thread = null;

        void WaitUntilCancellation(CancellationTokenSource cancelToken) {
            thread = Thread.CurrentThread;
            startEvent.Signal();

            while (!cancelToken.Token.IsCancellationRequested) {
                Thread.Yield();
            }
        }

        var (token, task) = ((Action<CancellationTokenSource>) WaitUntilCancellation).RunAsync();
        Wait(startEvent, Timeout);
        token.Cancel();
        Wait(task, Timeout);

        Assert.AreEqual(task.Status, TaskStatus.RanToCompletion);
        Assert.That(thread, Is.Not.Null.And.Not.EqualTo(Thread.CurrentThread));
    }

    /// <summary>
    /// Wait the given count down event
    /// </summary>
    /// <param name="countdownEvent">Count down event</param>
    /// <param name="timeout">Time to wait</param>
    /// <exception cref="TimeoutException">Exception thrown if timeout is elapsed</exception>
    private static void Wait(CountdownEvent countdownEvent, TimeSpan timeout) {
        if (!countdownEvent.Wait(timeout)) {
            throw new TimeoutException();
        }
    }

    /// <summary>
    /// Wait the given task
    /// </summary>
    /// <param name="task">Task</param>
    /// <param name="timeout">Time to wait</param>
    /// <exception cref="TimeoutException">Exception thrown if timeout is elapsed</exception>
    private static void Wait(Task task, TimeSpan timeout) {
        if (!task.Wait(timeout)) {
            throw new TimeoutException();
        }
    }
}