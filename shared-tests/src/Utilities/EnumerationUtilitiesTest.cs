using System;
using System.Threading.Tasks;
using Amber.Shared.Utilities;
using NUnit.Framework;

namespace Amber.Shared.Tests.Utilities {
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
}