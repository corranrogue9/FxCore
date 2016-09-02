#if NET40
namespace System
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ConcurrentRandom"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ConcurrentRandomFailureTests
    {
        /// <summary>
        /// Gets the next integer with a maximum when the maximum is negative
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Gets the next integer with a maximum when the maximum is negative")]
        [TestMethod]
        public void NextMaximum()
        {
            using (var random = new ConcurrentRandom())
            {
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => random.Next(-1));
            }
        }

        /// <summary>
        /// Gets the next integer within a range when the range is invalid
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Gets the next integer within a range when the range is invalid")]
        [TestMethod]
        public void NextRange()
        {
            using (var random = new ConcurrentRandom())
            {
                ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => random.Next(-100, -110));
            }
        }

        /// <summary>
        /// Fills a null buffer with random values
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Fills a null buffer with random values")]
        [TestMethod]
        public void NextBytes()
        {
            using (var random = new ConcurrentRandom())
            {
                ExceptionAssert.Throws<ArgumentNullException>(() => random.NextBytes(null));
            }
        }
    }
}
#endif