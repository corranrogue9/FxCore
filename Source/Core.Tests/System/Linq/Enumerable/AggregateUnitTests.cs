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
        /// Aggregates a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSingle()
        {
            Assert.AreEqual(1, new[] { 1 }.Aggregate((first, second) => first + second));
        }

        /// <summary>
        /// Aggregates a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Aggregate()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual(21, data.Aggregate((first, second) => first + second));
        }

        /// <summary>
        /// Aggregates an empty sequence with a seed
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates an empty sequence with a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSeedEmpty()
        {
            Assert.AreEqual("this is a test", Enumerable.Empty<string>().Aggregate("this is a test", (first, second) => string.Concat(first, second)));
        }

        /// <summary>
        /// Aggregates a sequence with a single element with a seed
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a single element with a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSeedSingle()
        {
            Assert.AreEqual(2, new[] { 1 }.Aggregate(1, (first, second) => first + second));
        }

        /// <summary>
        /// Aggregates a sequence with a seed
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSeed()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual(31, data.Aggregate(10, (first, second) => first + second));
        }

        /// <summary>
        /// Aggregates an empty sequence with a selector and a seed
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates an empty sequence with a selector and a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSelectorEmpty()
        {
            Assert.AreEqual(
                "is a test",
                Enumerable.Empty<string>().Aggregate("this is a test", (first, second) => string.Concat(first, second), val => val.Substring(5)));
        }

        /// <summary>
        /// Aggregates a sequence with a single element using a seed and a selector
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a single element using a seed and a selector")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSelectorSingle()
        {
            Assert.AreEqual(3, new[] { 1 }.Aggregate(1, (first, second) => first + second, val => val + 1));
        }

        /// <summary>
        /// Aggregates a sequence with a selector
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a selector")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSelector()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual(32, data.Aggregate(10, (first, second) => first + second, val => val + 1));
        }
    }
}
