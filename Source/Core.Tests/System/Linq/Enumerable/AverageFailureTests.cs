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
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalAverageNullData()
        {
            IEnumerable<decimal> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<decimal>().Average()); 
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void DecimalAverageOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(() => new[] { decimal.MaxValue, decimal.MaxValue }.Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleAverageNullData()
        {
            IEnumerable<double> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<double>().Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntAverageNullData()
        {
            IEnumerable<int> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<int>().Average());
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void IntAverageOverflow()
        {
            Assert.AreEqual(int.MaxValue, new[] { int.MaxValue, int.MaxValue }.Average());
            ExceptionAssert.Throws<OverflowException>(() => Enumerable
                .Repeat(int.MaxValue, int.MaxValue)
                .Concat(Enumerable.Repeat(int.MaxValue, int.MaxValue))
                .Concat(Enumerable.Repeat(int.MaxValue, int.MaxValue))
                .Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongAverageNullData()
        {
            IEnumerable<long> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<long>().Average());
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void LongAverageOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(() => new[] { long.MaxValue, long.MaxValue }.Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatAverageNullData()
        {
            IEnumerable<float> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<float>().Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableAverageNullData()
        {
            IEnumerable<decimal?> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableAverageOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(() => new decimal?[] { decimal.MaxValue, decimal.MaxValue }.Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableAverageNullData()
        {
            IEnumerable<double?> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableAverageNullData()
        {
            IEnumerable<int?> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableAverageOverflow()
        {
            Assert.AreEqual(int.MaxValue, new int?[] { int.MaxValue, int.MaxValue }.Average());
            ExceptionAssert.Throws<OverflowException>(() => Enumerable
                .Repeat<int?>(int.MaxValue, int.MaxValue)
                .Concat(Enumerable.Repeat<int?>(int.MaxValue, int.MaxValue))
                .Concat(Enumerable.Repeat<int?>(int.MaxValue, int.MaxValue))
                .Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableAverageNullData()
        {
            IEnumerable<long?> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableAverageOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(() => new long?[] { long.MaxValue, long.MaxValue }.Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableAverageNullData()
        {
            IEnumerable<float?> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average());
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalSelectorAverageNullData()
        {
            IEnumerable<Wrapper<decimal>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalSelectorAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Wrapper<decimal>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DecimalSelectorAverageNullSelector()
        {
            Func<Wrapper<decimal>, decimal> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 6m }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void DecimalSelectorAverageOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(
                () => new[] { decimal.MaxValue, decimal.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleSelectorAverageNullData()
        {
            IEnumerable<Wrapper<double>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleSelectorAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Wrapper<double>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DoubleSelectorAverageNullSelector()
        {
            Func<Wrapper<double>, double> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 6d }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntSelectorAverageNullData()
        {
            IEnumerable<Wrapper<int>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntSelectorAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Wrapper<int>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void IntSelectorAverageNullSelector()
        {
            Func<Wrapper<int>, int> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 6 }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void IntSelectorAverageOverflow()
        {
            Assert.AreEqual(int.MaxValue, new[] { int.MaxValue, int.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
            ExceptionAssert.Throws<OverflowException>(() => Enumerable
                .Repeat(int.MaxValue, int.MaxValue)
                .Concat(Enumerable.Repeat(int.MaxValue, int.MaxValue))
                .Concat(Enumerable.Repeat(int.MaxValue, int.MaxValue))
                .Select(val => Wrapper.Create(val))
                .Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongSelectorAverageNullData()
        {
            IEnumerable<Wrapper<long>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongSelectorAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Wrapper<long>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void LongSelectorAverageNullSelector()
        {
            Func<Wrapper<long>, long> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 6L }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void LongSelectorAverageOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(() => new[] { long.MaxValue, long.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatSelectorAverageNullData()
        {
            IEnumerable<Wrapper<float>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatSelectorAverageEmptyData()
        {
            ExceptionAssert.Throws<InvalidOperationException>(() => Enumerable.Empty<Wrapper<float>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void FloatSelectorAverageNullSelector()
        {
            Func<Wrapper<float>, float> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new[] { 6f }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableSelectorAverageNullData()
        {
            IEnumerable<Wrapper<decimal?>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableSelectorAverageNullSelector()
        {
            Func<Wrapper<decimal?>, decimal?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new decimal?[] { 6m }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableSelectorAverageOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(
                () => new decimal?[] { decimal.MaxValue, decimal.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableSelectorAverageNullData()
        {
            IEnumerable<Wrapper<double?>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableSelectorAverageNullSelector()
        {
            Func<Wrapper<double?>, double?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new double?[] { 6d }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableSelectorAverageNullData()
        {
            IEnumerable<Wrapper<int?>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableSelectorAverageNullSelector()
        {
            Func<Wrapper<int?>, int?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new int?[] { 6 }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure"), TestCategory("LongRunning")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableSelectorAverageOverflow()
        {
            Assert.AreEqual(int.MaxValue, new int?[] { int.MaxValue, int.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
            ExceptionAssert.Throws<OverflowException>(() => Enumerable
                .Repeat<int?>(int.MaxValue, int.MaxValue)
                .Concat(Enumerable.Repeat<int?>(int.MaxValue, int.MaxValue))
                .Concat(Enumerable.Repeat<int?>(int.MaxValue, int.MaxValue))
                .Select(val => Wrapper.Create(val))
                .Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableSelectorAverageNullData()
        {
            IEnumerable<Wrapper<long?>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableSelectorAverageNullSelector()
        {
            Func<Wrapper<long?>, long?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new long?[] { 6L }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableSelectorAverageOverflow()
        {
            ExceptionAssert.Throws<OverflowException>(
                () => new long?[] { long.MaxValue, long.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableSelectorAverageNullData()
        {
            IEnumerable<Wrapper<float?>> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableSelectorAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<Wrapper<float?>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Failure")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableSelectorAverageNullSelector()
        {
            Func<Wrapper<float?>, float?> selector = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => new float?[] { 6f }.Select(val => Wrapper.Create(val)).Average(selector));
        }

        /// <summary>
        /// A static holder class for a factory method of <see cref="Wrapper{T}"/>
        /// </summary>
        /// <threadsafety static="true"/>
        private static class Wrapper
        {
            /// <summary>
            /// Creates a new instance of the <see cref="Wrapper{T}"/> class
            /// </summary>
            /// <typeparam name="T">The type of the value being wrapped</typeparam>
            /// <param name="value">The value being wrapped</param>
            /// <returns>A new instance of <see cref="Wrapper{T}"/></returns>
            public static Wrapper<T> Create<T>(T value)
            {
                return new Wrapper<T>(value);
            }
        }

        /// <summary>
        /// Wraps a value
        /// </summary>
        /// <typeparam name="T">The type of the value being wrapped</typeparam>
        /// <threadsafety static="true" instance="true"/>
        private sealed class Wrapper<T>
        {
            /// <summary>
            /// The value that is being wrapped
            /// </summary>
            private readonly T value;

            /// <summary>
            /// Initializes a new instance of the <see cref="Wrapper{T}"/> class
            /// </summary>
            /// <param name="value">The value that is being wrapped</param>
            public Wrapper(T value)
            {
                this.value = value;
            }

            /// <summary>
            /// Gets the value that is being wrapped
            /// </summary>
            public T Value
            {
                get
                {
                    return this.value;
                }
            }
        }
    }
}
