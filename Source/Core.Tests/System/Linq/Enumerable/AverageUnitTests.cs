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
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DecimalAverageSingleElement()
        {
            Assert.AreEqual(6m, new[] { 6m }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalAverage()
        {
            Assert.AreEqual(8m, new[] { 6m, 7m, 8m, 9m, 10m }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DoubleAverageSingleElement()
        {
            Assert.AreEqual(6d, new[] { 6d }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleAverage()
        {
            Assert.AreEqual(8d, new[] { 6d, 7d, 8d, 9d, 10d }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void DoubleAverageOverflow()
        {
            Assert.AreEqual(double.PositiveInfinity, new[] { double.MaxValue, double.MaxValue }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void IntAverageSingleElement()
        {
            Assert.AreEqual(6d, new[] { 6 }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntAverage()
        {
            Assert.AreEqual(8d, new[] { 6, 7, 8, 9, 10 }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void LongAverageSingleElement()
        {
            Assert.AreEqual(6L, new[] { 6L }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongAverage()
        {
            Assert.AreEqual(8L, new[] { 6L, 7L, 8L, 9L, 10L }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void FloatAverageSingleElement()
        {
            Assert.AreEqual(6f, new[] { 6f }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatAverage()
        {
            Assert.AreEqual(8f, new[] { 6f, 7f, 8f, 9f, 10f }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void FloatAverageOverflow()
        {
            Assert.AreEqual(float.MaxValue, new[] { float.MaxValue, float.MaxValue }.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<decimal?>().Average());
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableAverageNulls()
        {
            Assert.IsNull(new decimal?[] { null, null }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableAverageSingleElement()
        {
            Assert.AreEqual(6m, new decimal?[] { 6m }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableAverage()
        {
            Assert.AreEqual(8m, new decimal?[] { 6m, 7m, 8m, 9m, 10m }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableAverageNull()
        {
            Assert.AreEqual(8m, new decimal?[] { null, 6m, 7m, null, 8m, 9m, 10m }.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<double?>().Average());
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableAverageNulls()
        {
            Assert.IsNull(new double?[] { null, null }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableAverageSingleElement()
        {
            Assert.AreEqual(6d, new double?[] { 6d }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableAverage()
        {
            Assert.AreEqual(8d, new double?[] { 6d, 7d, 8d, 9d, 10d }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableAverageNull()
        {
            Assert.AreEqual(8d, new double?[] { null, 6d, 7d, null, 8d, 9d, 10d }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableAverageOverflow()
        {
            Assert.AreEqual(double.PositiveInfinity, new double?[] { double.MaxValue, double.MaxValue }.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<int?>().Average());
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableAverageNulls()
        {
            Assert.IsNull(new int?[] { null, null }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableAverageSingleElement()
        {
            Assert.AreEqual(6, new int?[] { 6 }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableAverage()
        {
            Assert.AreEqual(8, new int?[] { 6, 7, 8, 9, 10 }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableAverageNull()
        {
            Assert.AreEqual(8, new int?[] { null, 6, 7, null, 8, 9, 10 }.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<long?>().Average());
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableAverageNulls()
        {
            Assert.IsNull(new long?[] { null, null }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableAverageSingleElement()
        {
            Assert.AreEqual(6L, new long?[] { 6L }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableAverage()
        {
            Assert.AreEqual(8L, new long?[] { 6L, 7L, 8L, 9L, 10L }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableAverageNull()
        {
            Assert.AreEqual(8L, new long?[] { null, 6L, 7L, null, 8L, 9L, 10L }.Average());
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<float?>().Average());
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableAverageNulls()
        {
            Assert.IsNull(new float?[] { null, null }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableAverageSingleElement()
        {
            Assert.AreEqual(6f, new float?[] { 6f }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableAverage()
        {
            Assert.AreEqual(8f, new float?[] { 6f, 7f, 8f, 9f, 10f }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableAverageNull()
        {
            Assert.AreEqual(8f, new float?[] { null, 6f, 7f, null, 8f, 9f, 10f }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableAverageOverflow()
        {
            Assert.AreEqual(float.MaxValue, new float?[] { float.MaxValue, float.MaxValue }.Average());
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DecimalSelectorAverageSingleElement()
        {
            Assert.AreEqual(6m, new[] { 6m }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalSelectorAverage()
        {
            Assert.AreEqual(8m, new[] { 6m, 7m, 8m, 9m, 10m }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DoubleSelectorAverageSingleElement()
        {
            Assert.AreEqual(6d, new[] { 6d }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleSelectorAverage()
        {
            Assert.AreEqual(8d, new[] { 6d, 7d, 8d, 9d, 10d }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void DoubleSelectorAverageOverflow()
        {
            Assert.AreEqual(double.PositiveInfinity, new[] { double.MaxValue, double.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void IntSelectorAverageSingleElement()
        {
            Assert.AreEqual(6d, new[] { 6 }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntSelectorAverage()
        {
            Assert.AreEqual(8d, new[] { 6, 7, 8, 9, 10 }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void LongSelectorAverageSingleElement()
        {
            Assert.AreEqual(6L, new[] { 6L }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongSelectorAverage()
        {
            Assert.AreEqual(8L, new[] { 6L, 7L, 8L, 9L, 10L }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void FloatSelectorAverageSingleElement()
        {
            Assert.AreEqual(6f, new[] { 6f }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatSelectorAverage()
        {
            Assert.AreEqual(8f, new[] { 6f, 7f, 8f, 9f, 10f }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void FloatSelectorAverageOverflow()
        {
            Assert.AreEqual(float.MaxValue, new[] { float.MaxValue, float.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableSelectorAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<Wrapper<decimal?>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableSelectorAverageNulls()
        {
            Assert.IsNull(new decimal?[] { null, null }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableSelectorAverageSingleElement()
        {
            Assert.AreEqual(6m, new decimal?[] { 6m }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableSelectorAverage()
        {
            Assert.AreEqual(8m, new decimal?[] { 6m, 7m, 8m, 9m, 10m }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DecimalNullableSelectorAverageNull()
        {
            Assert.AreEqual(8m, new decimal?[] { null, 6m, 7m, null, 8m, 9m, 10m }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableSelectorAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<Wrapper<double?>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableSelectorAverageNulls()
        {
            Assert.IsNull(new double?[] { null, null }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableSelectorAverageSingleElement()
        {
            Assert.AreEqual(6d, new double?[] { 6d }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableSelectorAverage()
        {
            Assert.AreEqual(8d, new double?[] { 6d, 7d, 8d, 9d, 10d }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableSelectorAverageNull()
        {
            Assert.AreEqual(8d, new double?[] { null, 6d, 7d, null, 8d, 9d, 10d }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void DoubleNullableSelectorAverageOverflow()
        {
            Assert.AreEqual(
                double.PositiveInfinity,
                new double?[] { double.MaxValue, double.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableSelectorAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<Wrapper<int?>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableSelectorAverageNulls()
        {
            Assert.IsNull(new int?[] { null, null }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableSelectorAverageSingleElement()
        {
            Assert.AreEqual(6, new int?[] { 6 }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableSelectorAverage()
        {
            Assert.AreEqual(8, new int?[] { 6, 7, 8, 9, 10 }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void IntNullableSelectorAverageNull()
        {
            Assert.AreEqual(8, new int?[] { null, 6, 7, null, 8, 9, 10 }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableSelectorAverageEmptyData()
        {
            Assert.IsNull(Enumerable.Empty<Wrapper<long?>>().Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableSelectorAverageNulls()
        {
            Assert.IsNull(new long?[] { null, null }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableSelectorAverageSingleElement()
        {
            Assert.AreEqual(6L, new long?[] { 6L }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableSelectorAverage()
        {
            Assert.AreEqual(8L, new long?[] { 6L, 7L, 8L, 9L, 10L }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongNullableSelectorAverageNull()
        {
            Assert.AreEqual(8L, new long?[] { null, 6L, 7L, null, 8L, 9L, 10L }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with only nulls")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableSelectorAverageNulls()
        {
            Assert.IsNull(new float?[] { null, null }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableSelectorAverageSingleElement()
        {
            Assert.AreEqual(6f, new float?[] { 6f }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableSelectorAverage()
        {
            Assert.AreEqual(8f, new float?[] { 6f, 7f, 8f, 9f, 10f }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableSelectorAverageNull()
        {
            Assert.AreEqual(8f, new float?[] { null, 6f, 7f, null, 8f, 9f, 10f }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
        }

        /// <summary>
        /// Averages the data in a sequence when the sum is too large
        /// </summary>
        [TestCategory("Unit")]
        [Description("Averages the data in a sequence when the sum is too large")]
        [Priority(1)]
        [TestMethod]
        public void FloatNullableSelectorAverageOverflow()
        {
            Assert.AreEqual(float.MaxValue, new float?[] { float.MaxValue, float.MaxValue }.Select(val => Wrapper.Create(val)).Average(wrapper => wrapper.Value));
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
