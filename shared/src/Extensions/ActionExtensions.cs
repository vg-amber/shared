// Copyright 2021-2021 Vg-Amber Project
// Licensed under Apache License 2.0 or any later version
// Refer to the LICENSE file included.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Amber.Shared.Extensions {
    /// <summary>
    /// Extensions for actions
    /// </summary>
    public static class ActionExtensions {
        /// <summary>
        /// Run asynchronously the given action
        /// </summary>
        /// <param name="action">Task taking a cancellation token in parameter</param>
        /// <param name="scheduler">Scheduler used to schedule the task</param>
        /// <param name="options">Task creation options</param>
        /// <returns>Cancellation token and the started task</returns>
        public static (CancellationTokenSource, Task) RunAsync(this Action<CancellationTokenSource> action, TaskScheduler scheduler,
                                                               TaskCreationOptions options) {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            return (tokenSource, Task.Factory.StartNew(() => {
                try {
                    action(tokenSource);
                } finally {
                    tokenSource.Dispose();
                }
            }, tokenSource.Token, options, scheduler));
        }

        /// <summary>
        /// Run asynchronously the given action with the default scheduler and long running creation options
        /// </summary>
        /// <param name="action">Task taking a cancellation token in parameter</param>
        /// <returns></returns>
        public static (CancellationTokenSource, Task) RunAsync(this Action<CancellationTokenSource> action) {
            return RunAsync(action, TaskScheduler.Default, TaskCreationOptions.LongRunning);
        }
    }
}