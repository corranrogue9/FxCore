#if NET40
namespace System
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ConcurrentRandom"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ConcurrentRandomUnitTests
    {
        /// <summary>
        /// Gets the next integer
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets the next integer")]
        [TestMethod]
        public void Next()
        {
            using (var random = new ConcurrentRandom())
            {
                random.Next();
            }
        }

        /// <summary>
        /// Gets the next integer with a maximum
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets the next integer with a maximum")]
        [TestMethod]
        public void NextMaximum()
        {
            using (var random = new ConcurrentRandom())
            {
                random.Next(100);
            }
        }

        /// <summary>
        /// Gets the next integer within a range
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets the next integer within a range")]
        [TestMethod]
        public void NextRange()
        {
            using (var random = new ConcurrentRandom())
            {
                random.Next(100, 150);
            }
        }

        /// <summary>
        /// Fills a buffer with random values
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Fills a buffer with random values")]
        [TestMethod]
        public void NextBytes()
        {
            using (var random = new ConcurrentRandom())
            {
                var buffer = new byte[100];
                random.NextBytes(buffer);
            }
        }

        /// <summary>
        /// Gets the next random double
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Gets the next random double")]
        [TestMethod]
        public void NextDouble()
        {
            using (var random = new ConcurrentRandom())
            {
                random.NextDouble();
            }
        }

        /// <summary>
        /// Disposes a ConcurrentRandom multiple times
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Disposes a ConcurrentRandom multiple times")]
        [TestMethod]
        public void Dispose()
        {
            using (var random = new ConcurrentRandom())
            {
                random.Dispose();
            }
        }
    }
}
#endif