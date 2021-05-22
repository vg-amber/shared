using System.Collections.Generic;
using Amber.Shared.Extensions;
using NUnit.Framework;

namespace Amber.Shared.Tests.Extensions {
    /// <summary>
    /// Tests for <see cref="Shared.Extensions.TypeExtensions"/>
    /// </summary>
    [TestFixture]
    public class TypeExtensionsTest {
        [Test]
        public void Name() {
            Assert.That(typeof(Dictionary<string, List<int>>).Name(), Is.EqualTo("Dictionary<String, List<Int32>>"));
        }
    }
}