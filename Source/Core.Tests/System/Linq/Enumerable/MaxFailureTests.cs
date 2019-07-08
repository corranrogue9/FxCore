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
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableNullSource()
        {
            IEnumerable<float?> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullSource()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableNullSource()
        {
            IEnumerable<long?> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullSource()
        {
            IEnumerable<float> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<float>().Max());
        }
        
        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableNullSource()
        {
            IEnumerable<int?> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullSource()
        {
            IEnumerable<decimal> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<decimal>().Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableNullSource()
        {
            IEnumerable<decimal?> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullSource()
        {
            IEnumerable<long> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<long>().Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullSource()
        {
            IEnumerable<double> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<double>().Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableNullSource()
        {
            IEnumerable<double?> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxNullSource()
        {
            IEnumerable<Tuple<int>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that doesn't contain comparable types
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that doesn't contain comparable types")]
        [Priority(1)]
        [TestMethod]
        public void MaxNotComparable()
        {
            var notComparable = new NotComparable();
            Assert.AreEqual(notComparable, new NotComparable[] { notComparable }.Max());
            ExceptionAssert.Throws<ArgumentException>(() => new NotComparable[] { new NotComparable(), new NotComparable() }.Max());
            ExceptionAssert.Throws<ArgumentException>(() => new object[] { Tuple.Create(1), new NotComparable() }.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxEmptySourceValueType()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<KeyValuePair<int, int>>().Max());
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSelectorNullSource()
        {
            IEnumerable<Tuple<float>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSelectorNullSelector()
        {
            Func<Tuple<float>, float> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<float>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<float>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorNullSource()
        {
            IEnumerable<Tuple<float?>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorNullSelector()
        {
            Func<Tuple<float?>, float?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<float?>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableSelectorNullSource()
        {
            IEnumerable<Tuple<long?>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableSelectorNullSelector()
        {
            Func<Tuple<long?>, long?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<long?>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableSelectorNullSource()
        {
            IEnumerable<Tuple<int?>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableSelectorNullSelector()
        {
            Func<Tuple<int?>, int?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<int?>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorNullSource()
        {
            IEnumerable<Tuple<double?>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorNullSelector()
        {
            Func<Tuple<double?>, double?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<double?>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongSelectorNullSource()
        {
            IEnumerable<Tuple<long>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<long>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongSelectorNullSelector()
        {
            Func<Tuple<long>, long> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<long>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntSelectorNullSource()
        {
            IEnumerable<Tuple<int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<int>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntSelectorNullSelector()
        {
            Func<Tuple<int>, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<int>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorNullSource()
        {
            IEnumerable<Tuple<double>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<double>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorNullSelector()
        {
            Func<Tuple<double>, double> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<double>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalSelectorNullSource()
        {
            IEnumerable<Tuple<decimal>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<decimal>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalSelectorNullSelector()
        {
            Func<Tuple<decimal>, decimal> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<decimal>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorNullSource()
        {
            IEnumerable<Tuple<int>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max(tuple => tuple));
        }

        /// <summary>
        /// Gets the max of a sequence that doesn't contain comparable types
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that doesn't contain comparable types")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorNotComparable()
        {
            var notComparable = new NotComparable();
            Assert.AreEqual(notComparable, new Tuple<NotComparable>[] { Tuple.Create(notComparable) }.Max(tuple => tuple.Item1));
            ExceptionAssert.Throws<ArgumentException>(() => new Tuple<NotComparable>[] { Tuple.Create(new NotComparable()), Tuple.Create(new NotComparable()) }.Max(tuple => tuple.Item1));
            ExceptionAssert.Throws<ArgumentException>(() => new object[] { Tuple.Create(1), new NotComparable() }.Max(@object => @object));
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorEmptySourceValueType()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<KeyValuePair<int, int>>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorNullSelector()
        {
            Func<Tuple<KeyValuePair<int, int>>, KeyValuePair<int, int>> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<KeyValuePair<int, int>>>().Max(selector));
        }

        /// <summary>
        /// Gets the max of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableSelectorNullSource()
        {
            IEnumerable<Tuple<decimal?>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the max of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableSelectorNullSelector()
        {
            Func<Tuple<decimal?>, decimal?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<decimal?>>().Max(selector));
        }

        /// <summary>
        /// A type that does not implement <see cref="IComparable{T}"/> or <see cref="IComparable"/>
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private sealed class NotComparable
        {
        }
    }
}
