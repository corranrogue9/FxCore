namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Gets the first element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the first element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void First()
        {
            Assert.AreEqual(9, new[] { 9 }.Select(value => value).First());
        }

        /// <summary>
        /// Gets the first element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the first element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstList()
        {
            Assert.AreEqual(10, new OtherList().First());
        }
        
        /// <summary>
        /// Gets the first element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the first element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstPredicate()
        {
            Assert.AreEqual(10, new[] { 9, 10 }.First(val => val > 9));
        }
        
        /// <summary>
        /// Gets the first element of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the first element of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstOrDefaultEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<string>().FirstOrDefault());
            Assert.AreEqual(0, Enumerable.Empty<int>().FirstOrDefault());
        }

        /// <summary>
        /// Gets the first element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the first element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstOrDefault()
        {
            Assert.AreEqual(9, new[] { 9 }.FirstOrDefault());
        }

        /// <summary>
        /// Gets the first element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the first element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstOrDefaultList()
        {
            Assert.AreEqual(10, new OtherList().FirstOrDefault());
        }
        
        /// <summary>
        /// Gets the first element of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the first element of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FirstOrDefaultPredicate()
        {
            Assert.AreEqual(10, new[] { 9, 10 }.FirstOrDefault(val => val > 9));
        }
    }
}
