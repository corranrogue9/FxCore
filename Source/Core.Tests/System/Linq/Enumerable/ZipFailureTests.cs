#if NET40 || !NET35
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
        /// Zips a sequence with a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Zips a sequence with a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ZipNullSecond()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4 }.Zip(data, (first, second) => first + second));
        }

        /// <summary>
        /// Zips a null sequence with another sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Zips a null sequence with another sequence")]
        [Priority(1)]
        [TestMethod]
        public void ZipNullFirst()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Zip(new[] { -1, -2, -3, -4 }, (first, second) => first + second));
        }

        /// <summary>
        /// Zips a sequence with another sequence using a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Zips a sequence with another sequence using a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ZipNullSelector()
        {
            Func<int, int, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 1, 2, 3, 4 }.Zip(new[] { -1, -2, -3, -4 }, selector));
        }
    }
}
#endif