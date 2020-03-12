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
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableNullSource()
        {
            IEnumerable<float?> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullSource()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinIntEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableNullSource()
        {
            IEnumerable<long?> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullSource()
        {
            IEnumerable<float> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<float>().Min());
        }
        
        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableNullSource()
        {
            IEnumerable<int?> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullSource()
        {
            IEnumerable<decimal> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<decimal>().Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableNullSource()
        {
            IEnumerable<decimal?> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullSource()
        {
            IEnumerable<long> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<long>().Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullSource()
        {
            IEnumerable<double> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<double>().Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableNullSource()
        {
            IEnumerable<double?> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinNullSource()
        {
            IEnumerable<Tuple<int>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that doesn't contain comparable types
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that doesn't contain comparable types")]
        [Priority(1)]
        [TestMethod]
        public void MinNotComparable()
        {
            var notComparable = new NotComparable();
            Assert.AreEqual(notComparable, new NotComparable[] { notComparable }.Min());
            ExceptionAssert.Throws<ArgumentException>(() => new NotComparable[] { new NotComparable(), new NotComparable() }.Min());
            ExceptionAssert.Throws<ArgumentException>(() => new object[] { Tuple.Create(1), new NotComparable() }.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinEmptySourceValueType()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<KeyValuePair<int, int>>().Min());
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSelectorNullSource()
        {
            IEnumerable<Tuple<float>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSelectorNullSelector()
        {
            Func<Tuple<float>, float> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<float>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<float>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorNullSource()
        {
            IEnumerable<Tuple<float?>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorNullSelector()
        {
            Func<Tuple<float?>, float?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<float?>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableSelectorNullSource()
        {
            IEnumerable<Tuple<long?>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableSelectorNullSelector()
        {
            Func<Tuple<long?>, long?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<long?>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableSelectorNullSource()
        {
            IEnumerable<Tuple<int?>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableSelectorNullSelector()
        {
            Func<Tuple<int?>, int?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<int?>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorNullSource()
        {
            IEnumerable<Tuple<double?>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorNullSelector()
        {
            Func<Tuple<double?>, double?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<double?>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongSelectorNullSource()
        {
            IEnumerable<Tuple<long>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<long>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinLongSelectorNullSelector()
        {
            Func<Tuple<long>, long> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<long>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinIntSelectorNullSource()
        {
            IEnumerable<Tuple<int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinIntSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<int>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinIntSelectorNullSelector()
        {
            Func<Tuple<int>, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<int>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorNullSource()
        {
            IEnumerable<Tuple<double>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<double>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorNullSelector()
        {
            Func<Tuple<double>, double> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<double>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalSelectorNullSource()
        {
            IEnumerable<Tuple<decimal>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalSelectorEmptySource()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<decimal>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalSelectorNullSelector()
        {
            Func<Tuple<decimal>, decimal> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<decimal>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorNullSource()
        {
            IEnumerable<Tuple<int>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min(tuple => tuple));
        }

        /// <summary>
        /// Gets the min of a sequence that doesn't contain comparable types
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that doesn't contain comparable types")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorNotComparable()
        {
            var notComparable = new NotComparable();
            Assert.AreEqual(notComparable, new Tuple<NotComparable>[] { Tuple.Create(notComparable) }.Min(tuple => tuple.Item1));
            ExceptionAssert.Throws<ArgumentException>(() => new Tuple<NotComparable>[] { Tuple.Create(new NotComparable()), Tuple.Create(new NotComparable()) }.Min(tuple => tuple.Item1));
            ExceptionAssert.Throws<ArgumentException>(() => new object[] { Tuple.Create(1), new NotComparable() }.Min(@object => @object));
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorEmptySourceValueType()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Tuple<KeyValuePair<int, int>>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorNullSelector()
        {
            Func<Tuple<KeyValuePair<int, int>>, KeyValuePair<int, int>> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<KeyValuePair<int, int>>>().Min(selector));
        }

        /// <summary>
        /// Gets the min of a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableSelectorNullSource()
        {
            IEnumerable<Tuple<decimal?>> source = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => source.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that uses a null selector
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the min of a sequence that uses a null selector")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableSelectorNullSelector()
        {
            Func<Tuple<decimal?>, decimal?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => Enumerable.Empty<Tuple<decimal?>>().Min(selector));
        }
    }
}
