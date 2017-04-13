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
        /// Aggregates an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Aggregates an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void AggregateEmpty()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<string>().Aggregate((first, second) => string.Concat(first, second)));
        }

        /// <summary>
        /// Aggregates a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Aggregates a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void AggregateNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Aggregate((first, second) => string.Concat(first, second)));
        }

        /// <summary>
        /// Aggregates a sequence with a null accumulator
        /// </summary>
        [TestCategory("Failure")]
        [Description("Aggregates a sequence with a null accumulator")]
        [Priority(1)]
        [TestMethod]
        public void AggregateNullAccumulator()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().Aggregate(null));
        }

        /// <summary>
        /// Aggregates a null sequence with a seed
        /// </summary>
        [TestCategory("Failure")]
        [Description("Aggregates a null sequence with a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSeedNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Aggregate("this is a test", (first, second) => string.Concat(first, second)));
        }

        /// <summary>
        /// Aggregates an empty sequence with a seed and a null accumulator
        /// </summary>
        [TestCategory("Failure")]
        [Description("Aggregates an empty sequence with a seed and a null accumulator")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSeedNullAccumulator()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().Aggregate("this is a test", null));
        }

        /// <summary>
        /// Aggregates a null sequence with a selector and a seed
        /// </summary>
        [TestCategory("Failure")]
        [Description("Aggregates a null sequence with a selector and a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSelectorNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(
                () => data.Aggregate("this is a test", (first, second) => string.Concat(first, second), val => val.Substring(5)));
        }

        /// <summary>
        /// Aggregates an empty sequence with a seed and a null accumulator
        /// </summary>
        [TestCategory("Failure")]
        [Description("Aggregates an empty sequence with a seed and a null accumulator")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSelectorNullAccumulator()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<string>().Aggregate("this is a test", null, val => val.Substring(5)));
        }

        /// <summary>
        /// Aggregates an empty sequence with a seed and a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Aggregates an empty sequence with a seed and a null selector")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSelectorNullSelector()
        {
            ExceptionAssert.Throws<ArgumentNullException>(
                () => Enumerable.Empty<string>().Aggregate<string, string, string>("this is a test", (first, second) => string.Concat(first, second), null));
        }
    }
}
