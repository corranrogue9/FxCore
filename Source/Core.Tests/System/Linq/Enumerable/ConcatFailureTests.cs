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
        /// Concatenates two sequences when the first is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Concatenates two sequences when the first is null")]
        [Priority(1)]
        [TestMethod]
        public void ConcatNullFirst()
        {
            List<string> first = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => first.Concat(Enumerable.Empty<string>()));
        }

        /// <summary>
        /// Concatenates two sequences when the second is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Concatenates two sequences when the second is null")]
        [Priority(1)]
        [TestMethod]
        public void ConcatNullSecond()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().Concat(null));
        }
    }
}
