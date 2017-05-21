namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableFailureTests
    {
        /// <summary>
        /// Gets the set difference between two sequences when one of them is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the set difference between two sequences when one of them is null")]
        [Priority(1)]
        [TestMethod]
        public void ExceptNullFirst()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Except(Enumerable.Empty<string>()));
        }

        /// <summary>
        /// Gets the set difference between two sequences when one of them is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the set difference between two sequences when one of them is null")]
        [Priority(1)]
        [TestMethod]
        public void ExceptNullSecond()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().Except(data));
        }

        /// <summary>
        /// Gets the set difference between two sequences when one of them is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the set difference between two sequences when one of them is null")]
        [Priority(1)]
        [TestMethod]
        public void ExceptComparerNullFirst()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Except(Enumerable.Empty<string>(), StringComparer.Ordinal));
        }

        /// <summary>
        /// Gets the set difference between two sequences when one of them is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the set difference between two sequences when one of them is null")]
        [Priority(1)]
        [TestMethod]
        public void ExceptComparerNullSecond()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().Except(data, StringComparer.Ordinal));
        }
    }
}
