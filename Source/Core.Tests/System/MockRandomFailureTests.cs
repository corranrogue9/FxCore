namespace System
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="MockRandom"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class MockRandomFailureTests
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
            var random = new MockRandom(new byte[100]);
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => random.Next(-1));
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
            var random = new MockRandom(new byte[100]);
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => random.Next(-100, -110));
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
            var random = new MockRandom(new byte[100]);
            ExceptionAssert.Throws<ArgumentNullException>(() => random.NextBytes(null));
        }

        /// <summary>
        /// Creates a new MockRandom with null data
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Creates a new MockRandom with null data")]
        [TestMethod]
        public void CreateNullData()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new MockRandom(null));
        }

        /// <summary>
        /// Creates a new MockRandom with empty data
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Creates a new MockRandom with empty data")]
        [TestMethod]
        public void CreateEmptyData()
        {
            ExceptionAssert.Throws<ArgumentException>(() => new MockRandom(new byte[0]));
        }
    }
}
