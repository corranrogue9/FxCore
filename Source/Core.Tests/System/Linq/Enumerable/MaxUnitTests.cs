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
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<float?>().Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new float?[] { null, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSourceWithNulls()
        {
            Assert.AreEqual(4, new float?[] { null, 1, 3, null, 4, 2, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains null and NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains null and NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSourceWithNullsAndNan()
        {
            Assert.AreEqual(float.MinValue, new float?[] { null, float.NaN, float.MinValue, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullable()
        {
            Assert.AreEqual(4, new float?[] { 1, 3, 4, 2 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSourceWithNan()
        {
            Assert.AreEqual(float.MinValue, new float?[] { float.NaN, float.MinValue }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains only NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSourceWithOnlyNan()
        {
            Assert.IsTrue(float.IsNaN(new float?[] { float.NaN }.Max().Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSourceWithPositiveInfinity()
        {
            Assert.IsTrue(float.IsPositiveInfinity(new float?[] { float.PositiveInfinity, float.MaxValue }.Max().Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSourceWithNegativeInfinity()
        {
            Assert.AreEqual(float.MinValue, new float?[] { float.NegativeInfinity, float.MinValue }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains one element")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntSingleElement()
        {
            Assert.AreEqual(10, new int[] { 10 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxInt()
        {
            Assert.AreEqual(11, new int[] { 10, 11, 3, 5 }.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<long?>().Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new long?[] { null, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableSourceWithNulls()
        {
            Assert.AreEqual(4, new long?[] { null, 1, 3, null, 4, 2, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullable()
        {
            Assert.AreEqual(4, new long?[] { 1, 3, 4, 2 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloat()
        {
            Assert.AreEqual(4, new float[] { 1, 3, 4, 2 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSingleElement()
        {
            Assert.AreEqual(3, new float[] { 3 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSourceWithNan()
        {
            Assert.AreEqual(3, new float[] { 3, float.NaN }.Max());
            Assert.AreEqual(3, new float[] { float.NaN, 3 }.Max());
            Assert.AreEqual(3, new float[] { float.NaN, 3, float.NaN }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSourceWithOnlyNan()
        {
            Assert.IsTrue(float.IsNaN(new float[] { float.NaN }.Max()));
            Assert.IsTrue(float.IsNaN(new float[] { float.NaN, float.NaN }.Max()));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSourceWithPositiveInfinity()
        {
            Assert.IsTrue(float.IsPositiveInfinity(new float[] { float.MaxValue, float.PositiveInfinity }.Max()));
        }

        /// <summary>
        /// Gets the max of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSourceWithNegativeInfinity()
        {
            Assert.AreEqual(float.MinValue, new float[] { float.MinValue, float.NegativeInfinity }.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<int?>().Max());
        }

        /// <summary>
        /// Gets the max of a sequence that only contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that only contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new int?[] { null, null, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableSourceWithNulls()
        {
            Assert.AreEqual(10, new int?[] { null, 3, 2, 10, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullable()
        {
            Assert.AreEqual(10, new int?[] { 3, 2, 10 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimal()
        {
            Assert.AreEqual(5, new decimal[] { 2, 5, 3 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalSingleElement()
        {
            Assert.AreEqual(5, new decimal[] { 5 }.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<decimal?>().Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableSourceWithNulls()
        {
            Assert.AreEqual(14, new decimal?[] { null, 10, 4, 6, null, 14, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new decimal?[] { null, null, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableSourceWithoutNulls()
        {
            Assert.AreEqual(10, new decimal?[] { 10, 4, 6 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains one element")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongSingleElement()
        {
            Assert.AreEqual(10, new long[] { 10 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLong()
        {
            Assert.AreEqual(11, new long[] { 10, 11, 3, 5 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDouble()
        {
            Assert.AreEqual(4, new double[] { 1, 3, 4, 2 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSingleElement()
        {
            Assert.AreEqual(3, new double[] { 3 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSourceWithNan()
        {
            Assert.AreEqual(3, new double[] { 3, double.NaN }.Max());
            Assert.AreEqual(3, new double[] { double.NaN, 3 }.Max());
            Assert.AreEqual(3, new double[] { double.NaN, 3, double.NaN }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSourceWithNanAndFloatNan()
        {
            Assert.AreEqual(3, new double[] { 3, double.NaN, float.NaN }.Max());
            Assert.AreEqual(3, new double[] { double.NaN, float.NaN, 3 }.Max());
            Assert.AreEqual(3, new double[] { double.NaN, 3, double.NaN, float.NaN }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSourceWithOnlyNan()
        {
            Assert.IsTrue(double.IsNaN(new double[] { double.NaN }.Max()));
            Assert.IsTrue(double.IsNaN(new double[] { double.NaN, double.NaN }.Max()));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSourceWithOnlyNanAndFloatNan()
        {
            Assert.IsTrue(double.IsNaN(new double[] { double.NaN, float.NaN }.Max()));
            Assert.IsTrue(double.IsNaN(new double[] { float.NaN, double.NaN, float.NaN }.Max()));
            Assert.IsTrue(double.IsNaN(new double[] { double.NaN, float.NaN, double.NaN }.Max()));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSourceWithPositiveInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(new double[] { double.MaxValue, double.PositiveInfinity }.Max()));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSourceWithPositiveInfinityAndFloatPositiveInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(new double[] { double.MaxValue, float.PositiveInfinity, double.PositiveInfinity }.Max()));
            Assert.IsTrue(double.IsPositiveInfinity(new double[] { double.MaxValue, double.PositiveInfinity, float.PositiveInfinity }.Max()));
        }

        /// <summary>
        /// Gets the max of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSourceWithNegativeInfinity()
        {
            Assert.AreEqual(double.MinValue, new double[] { double.MinValue, double.NegativeInfinity }.Max());
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<double?>().Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new double?[] { null, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithNulls()
        {
            Assert.AreEqual(4, new double?[] { null, 1, 3, null, 4, 2, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains null and NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains null and NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithNullsAndNan()
        {
            Assert.AreEqual(double.MinValue, new double?[] { null, double.NaN, double.MinValue, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullable()
        {
            Assert.AreEqual(4, new double?[] { 1, 3, 4, 2 }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithNan()
        {
            Assert.AreEqual(double.MinValue, new double?[] { double.NaN, double.MinValue }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithNanAndFloatNan()
        {
            Assert.AreEqual(3, new double?[] { 3, double.NaN, float.NaN }.Max());
            Assert.AreEqual(3, new double?[] { double.NaN, float.NaN, 3 }.Max());
            Assert.AreEqual(3, new double?[] { double.NaN, 3, double.NaN, float.NaN }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains only NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithOnlyNan()
        {
            Assert.IsTrue(double.IsNaN(new double?[] { double.NaN }.Max().Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithOnlyNanAndFloatNan()
        {
            Assert.IsTrue(double.IsNaN(new double?[] { double.NaN, float.NaN }.Max().Value));
            Assert.IsTrue(double.IsNaN(new double?[] { float.NaN, double.NaN, float.NaN }.Max().Value));
            Assert.IsTrue(double.IsNaN(new double?[] { double.NaN, float.NaN, double.NaN }.Max().Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithPositiveInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(new double?[] { double.PositiveInfinity, double.MaxValue }.Max().Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithPositiveInfinityAndFloatPositiveInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(new double?[] { double.MaxValue, float.PositiveInfinity, double.PositiveInfinity }.Max().Value));
            Assert.IsTrue(double.IsPositiveInfinity(new double?[] { double.MaxValue, double.PositiveInfinity, float.PositiveInfinity }.Max().Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSourceWithNegativeInfinity()
        {
            Assert.AreEqual(double.MinValue, new double?[] { double.NegativeInfinity, double.MinValue }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains IComparable{T} elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains IComparable{T} elements")]
        [Priority(1)]
        [TestMethod]
        public void MaxGenericComparable()
        {
            Assert.AreEqual(4, new GenericComparable[] { new GenericComparable(1), new GenericComparable(4), new GenericComparable(3) }.Max().Value);
        }

        /// <summary>
        /// Gets the max of a sequence that contains IComparable elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains IComparable elements")]
        [Priority(1)]
        [TestMethod]
        public void MaxNonGenericComparable()
        {
            Assert.AreEqual(1, new NonGenericComparable[] { new NonGenericComparable(1), new NonGenericComparable(4), new NonGenericComparable(3) }.Max().Value);
        }

        /// <summary>
        /// Gets the max of a sequence that contains IComparable elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains IComparable elements")]
        [Priority(1)]
        [TestMethod]
        public void MaxComparable()
        {
            Assert.AreEqual(4, new Comparable[] { new Comparable(1), new Comparable(4), new Comparable(3) }.Max().Value);
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxEmptySourceReferenceType()
        {
            Assert.AreEqual(null, Enumerable.Empty<object>().Max());
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new object[] { null, null, null }.Max());
        }

        /// <summary>
        /// Gets the max of a sequence 
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxReferenceType()
        {
            Assert.AreEqual(4, new ReferenceType[] { new ReferenceType(3), new ReferenceType(4), new ReferenceType(2) }.Max().Value);
        }

        /// <summary>
        /// Gets the max of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxReferenceTypeSingleElement()
        {
            Assert.AreEqual(3, new ReferenceType[] { new ReferenceType(3) }.Max().Value);
        }

        /// <summary>
        /// Gets the max of a sequence that contains null
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains null")]
        [Priority(1)]
        [TestMethod]
        public void MaxReferenceTypeWithNulls()
        {
            Assert.AreEqual(4, new ReferenceType[] { null, new ReferenceType(3), new ReferenceType(4), null, new ReferenceType(2), null }.Max().Value);
        }

        /// <summary>
        /// Gets the max of a sequence 
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxValueType()
        {
            Assert.AreEqual(4, new ValueType[] { new ValueType(3), new ValueType(4), new ValueType(2) }.Max().Value);
        }

        /// <summary>
        /// Gets the max of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxValueTypeSingleElement()
        {
            Assert.AreEqual(3, new ValueType[] { new ValueType(3) }.Max().Value);
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSelector()
        {
            Assert.AreEqual(4, new Tuple<float>[] { Tuple.Create<float>(1), Tuple.Create<float>(3), Tuple.Create<float>(4), Tuple.Create<float>(2) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSelectorSingleElement()
        {
            Assert.AreEqual(3, new Tuple<float>[] { Tuple.Create<float>(3) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSelectorSourceWithNan()
        {
            Assert.AreEqual(3, new Tuple<float>[] { Tuple.Create<float>(3), Tuple.Create<float>(float.NaN) }.Max(tuple => tuple.Item1));
            Assert.AreEqual(3, new Tuple<float>[] { Tuple.Create<float>(float.NaN), Tuple.Create<float>(3) }.Max(tuple => tuple.Item1));
            Assert.AreEqual(3, new Tuple<float>[] { Tuple.Create<float>(float.NaN), Tuple.Create<float>(3), Tuple.Create<float>(float.NaN) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSelectorSourceWithOnlyNan()
        {
            Assert.IsTrue(float.IsNaN(new Tuple<float>[] { Tuple.Create<float>(float.NaN) }.Max(tuple => tuple.Item1)));
            Assert.IsTrue(float.IsNaN(new Tuple<float>[] { Tuple.Create<float>(float.NaN), Tuple.Create<float>(float.NaN) }.Max(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSelectorSourceWithPositiveInfinity()
        {
            Assert.IsTrue(float.IsPositiveInfinity(new Tuple<float>[] { Tuple.Create<float>(float.MaxValue), Tuple.Create<float>(float.PositiveInfinity) }.Max(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the max of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatSelectorSourceWithNegativeInfinity()
        {
            Assert.AreEqual(float.MinValue, new Tuple<float>[] { Tuple.Create<float>(float.MinValue), Tuple.Create<float>(float.NegativeInfinity) }.Max(tuple => tuple.Item1));
        }
        
        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<float?>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<float?>[] { Tuple.Create<float?>(null), Tuple.Create<float?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(4, new Tuple<float?>[] { Tuple.Create<float?>(null), Tuple.Create<float?>(1), Tuple.Create<float?>(3), Tuple.Create<float?>(null), Tuple.Create<float?>(4), Tuple.Create<float?>(2), Tuple.Create<float?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains null and NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains null and NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorSourceWithNullsAndNan()
        {
            Assert.AreEqual(float.MinValue, new Tuple<float?>[] { Tuple.Create<float?>(null), Tuple.Create<float?>(float.NaN), Tuple.Create<float?>(float.MinValue), Tuple.Create<float?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelector()
        {
            Assert.AreEqual(4, new Tuple<float?>[] { Tuple.Create<float?>(1), Tuple.Create<float?>(3), Tuple.Create<float?>(4), Tuple.Create<float?>(2) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorSourceWithNan()
        {
            Assert.AreEqual(float.MinValue, new Tuple<float?>[] { Tuple.Create<float?>(float.NaN), Tuple.Create<float?>(float.MinValue) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorSourceWithOnlyNan()
        {
            Assert.IsTrue(float.IsNaN(new Tuple<float?>[] { Tuple.Create<float?>(float.NaN) }.Max(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorSourceWithPositiveInfinity()
        {
            Assert.IsTrue(float.IsPositiveInfinity(new Tuple<float?>[] { Tuple.Create<float?>(float.PositiveInfinity), Tuple.Create<float?>(float.MaxValue) }.Max(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxFloatNullableSelectorSourceWithNegativeInfinity()
        {
            Assert.AreEqual(float.MinValue, new Tuple<float?>[] { Tuple.Create<float?>(float.NegativeInfinity), Tuple.Create<float?>(float.MinValue) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<long?>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<long?>[] { Tuple.Create<long?>(null), Tuple.Create<long?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(4, new Tuple<long?>[] { Tuple.Create<long?>(null), Tuple.Create<long?>(1), Tuple.Create<long?>(3), Tuple.Create<long?>(null), Tuple.Create<long?>(4), Tuple.Create<long?>(2), Tuple.Create<long?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongNullableSelector()
        {
            Assert.AreEqual(4, new Tuple<long?>[] { Tuple.Create<long?>(1), Tuple.Create<long?>(3), Tuple.Create<long?>(4), Tuple.Create<long?>(2) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<int?>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that only contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that only contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<int?>[] { Tuple.Create<int?>(null), Tuple.Create<int?>(null), Tuple.Create<int?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(10, new Tuple<int?>[] { Tuple.Create<int?>(null), Tuple.Create<int?>(3), Tuple.Create<int?>(2), Tuple.Create<int?>(10), Tuple.Create<int?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntNullableSelector()
        {
            Assert.AreEqual(10, new Tuple<int?>[] { Tuple.Create<int?>(3), Tuple.Create<int?>(2), Tuple.Create<int?>(10) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<double?>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<double?>[] { Tuple.Create<double?>(null), Tuple.Create<double?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(4, new Tuple<double?>[] { Tuple.Create<double?>(null), Tuple.Create<double?>(1), Tuple.Create<double?>(3), Tuple.Create<double?>(null), Tuple.Create<double?>(4), Tuple.Create<double?>(2), Tuple.Create<double?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains null and NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains null and NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithNullsAndNan()
        {
            Assert.AreEqual(double.MinValue, new Tuple<double?>[] { Tuple.Create<double?>(null), Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(double.MinValue), Tuple.Create<double?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelector()
        {
            Assert.AreEqual(4, new Tuple<double?>[] { Tuple.Create<double?>(1), Tuple.Create<double?>(3), Tuple.Create<double?>(4), Tuple.Create<double?>(2) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithNan()
        {
            Assert.AreEqual(double.MinValue, new Tuple<double?>[] { Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(double.MinValue) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithNanAndFloatNan()
        {
            Assert.AreEqual(3, new Tuple<double?>[] { Tuple.Create<double?>(3), Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN) }.Max(tuple => tuple.Item1));
            Assert.AreEqual(3, new Tuple<double?>[] { Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN), Tuple.Create<double?>(3) }.Max(tuple => tuple.Item1));
            Assert.AreEqual(3, new Tuple<double?>[] { Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(3), Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithOnlyNan()
        {
            Assert.IsTrue(double.IsNaN(new Tuple<double?>[] { Tuple.Create<double?>(double.NaN) }.Max(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithOnlyNanAndFloatNan()
        {
            Assert.IsTrue(double.IsNaN(new Tuple<double?>[] { Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN) }.Max(tuple => tuple.Item1).Value));
            Assert.IsTrue(double.IsNaN(new Tuple<double?>[] { Tuple.Create<double?>(float.NaN), Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN) }.Max(tuple => tuple.Item1).Value));
            Assert.IsTrue(double.IsNaN(new Tuple<double?>[] { Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN), Tuple.Create<double?>(double.NaN) }.Max(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithPositiveInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(new Tuple<double?>[] { Tuple.Create<double?>(double.PositiveInfinity), Tuple.Create<double?>(double.MaxValue) }.Max(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithPositiveInfinityAndFloatPositiveInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(new Tuple<double?>[] { Tuple.Create<double?>(double.MaxValue), Tuple.Create<double?>(float.PositiveInfinity), Tuple.Create<double?>(double.PositiveInfinity) }.Max(tuple => tuple.Item1).Value));
            Assert.IsTrue(double.IsPositiveInfinity(new Tuple<double?>[] { Tuple.Create<double?>(double.MaxValue), Tuple.Create<double?>(double.PositiveInfinity), Tuple.Create<double?>(float.PositiveInfinity) }.Max(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the max of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleNullableSelectorSourceWithNegativeInfinity()
        {
            Assert.AreEqual(double.MinValue, new Tuple<double?>[] { Tuple.Create<double?>(double.NegativeInfinity), Tuple.Create<double?>(double.MinValue) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains one element")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongSelectorSingleElement()
        {
            Assert.AreEqual(10, new Tuple<long>[] { Tuple.Create<long>(10) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxLongSelector()
        {
            Assert.AreEqual(11, new Tuple<long>[] { Tuple.Create<long>(10), Tuple.Create<long>(11), Tuple.Create<long>(3), Tuple.Create<long>(5) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains one element")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntSelectorSingleElement()
        {
            Assert.AreEqual(10, new Tuple<int>[] { Tuple.Create(10) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxIntSelector()
        {
            Assert.AreEqual(11, new Tuple<int>[] { Tuple.Create(10), Tuple.Create(11), Tuple.Create(3), Tuple.Create(5) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelector()
        {
            Assert.AreEqual(4, new Tuple<double>[] { Tuple.Create<double>(1), Tuple.Create<double>(3), Tuple.Create<double>(4), Tuple.Create<double>(2) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorSingleElement()
        {
            Assert.AreEqual(3, new Tuple<double>[] { Tuple.Create<double>(3) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorSourceWithNan()
        {
            Assert.AreEqual(3, new Tuple<double>[] { Tuple.Create<double>(3), Tuple.Create<double>(double.NaN) }.Max(tuple => tuple.Item1));
            Assert.AreEqual(3, new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(3) }.Max(tuple => tuple.Item1));
            Assert.AreEqual(3, new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(3), Tuple.Create<double>(double.NaN) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorSourceWithNanAndFloatNan()
        {
            Assert.AreEqual(3, new Tuple<double>[] { Tuple.Create<double>(3), Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN) }.Max(tuple => tuple.Item1));
            Assert.AreEqual(3, new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN), Tuple.Create<double>(3) }.Max(tuple => tuple.Item1));
            Assert.AreEqual(3, new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(3), Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorSourceWithOnlyNan()
        {
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(double.NaN) }.Max(tuple => tuple.Item1)));
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(double.NaN) }.Max(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorSourceWithOnlyNanAndFloatNan()
        {
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN) }.Max(tuple => tuple.Item1)));
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(float.NaN), Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN) }.Max(tuple => tuple.Item1)));
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN), Tuple.Create<double>(double.NaN) }.Max(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorSourceWithPositiveInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(new Tuple<double>[] { Tuple.Create<double>(double.MaxValue), Tuple.Create<double>(double.PositiveInfinity) }.Max(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the max of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorSourceWithPositiveInfinityAndFloatPositiveInfinity()
        {
            Assert.IsTrue(double.IsPositiveInfinity(new Tuple<double>[] { Tuple.Create<double>(double.MaxValue), Tuple.Create<double>(float.PositiveInfinity), Tuple.Create<double>(double.PositiveInfinity) }.Max(tuple => tuple.Item1)));
            Assert.IsTrue(double.IsPositiveInfinity(new Tuple<double>[] { Tuple.Create<double>(double.MaxValue), Tuple.Create<double>(double.PositiveInfinity), Tuple.Create<double>(float.PositiveInfinity) }.Max(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the max of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MaxDoubleSelectorSourceWithNegativeInfinity()
        {
            Assert.AreEqual(double.MinValue, new Tuple<double>[] { Tuple.Create<double>(double.MinValue), Tuple.Create<double>(double.NegativeInfinity) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalSelector()
        {
            Assert.AreEqual(5, new Tuple<decimal>[] { Tuple.Create<decimal>(2), Tuple.Create<decimal>(5), Tuple.Create<decimal>(3) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalSingleElementSelector()
        {
            Assert.AreEqual(5, new Tuple<decimal>[] { Tuple.Create<decimal>(5) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains IComparable{T} elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains IComparable{T} elements")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorGenericComparable()
        {
            Assert.AreEqual(4, new Tuple<GenericComparable>[] { Tuple.Create(new GenericComparable(1)), Tuple.Create(new GenericComparable(4)), Tuple.Create(new GenericComparable(3)) }.Max(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the max of a sequence that contains IComparable elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains IComparable elements")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorNonGenericComparable()
        {
            Assert.AreEqual(1, new Tuple<NonGenericComparable>[] { Tuple.Create(new NonGenericComparable(1)), Tuple.Create(new NonGenericComparable(4)), Tuple.Create(new NonGenericComparable(3)) }.Max(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the max of a sequence that contains IComparable elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains IComparable elements")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorComparable()
        {
            Assert.AreEqual(4, new Tuple<Comparable>[] { Tuple.Create(new Comparable(1)), Tuple.Create(new Comparable(4)), Tuple.Create(new Comparable(3)) }.Max(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorEmptySourceReferenceType()
        {
            Assert.AreEqual(null, Enumerable.Empty<object>().Max(@object => @object));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new object[] { null, null, null }.Max(@object => @object));
        }

        /// <summary>
        /// Gets the max of a sequence 
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorReferenceType()
        {
            Assert.AreEqual(4, new Tuple<ReferenceType>[] { Tuple.Create(new ReferenceType(3)), Tuple.Create(new ReferenceType(4)), Tuple.Create(new ReferenceType(2)) }.Max(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the max of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorReferenceTypeSingleElement()
        {
            Assert.AreEqual(3, new Tuple<ReferenceType>[] { Tuple.Create(new ReferenceType(3)) }.Max(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the max of a sequence that contains null
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains null")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorReferenceTypeWithNulls()
        {
            Assert.AreEqual(4, new Tuple<ReferenceType>[] { Tuple.Create<ReferenceType>(null), Tuple.Create(new ReferenceType(3)), Tuple.Create(new ReferenceType(4)), Tuple.Create<ReferenceType>(null), Tuple.Create(new ReferenceType(2)), Tuple.Create<ReferenceType>(null) }.Max(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the max of a sequence 
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorValueType()
        {
            Assert.AreEqual(4, new Tuple<ValueType>[] { Tuple.Create(new ValueType(3)), Tuple.Create(new ValueType(4)), Tuple.Create(new ValueType(2)) }.Max(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the max of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MaxSelectorValueTypeSingleElement()
        {
            Assert.AreEqual(3, new Tuple<ValueType>[] { Tuple.Create(new ValueType(3)) }.Max(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the max of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<decimal?>>().Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(14, new Tuple<decimal?>[] { Tuple.Create<decimal?>(null), Tuple.Create<decimal?>(10), Tuple.Create<decimal?>(4), Tuple.Create<decimal?>(6), Tuple.Create<decimal?>(null), Tuple.Create<decimal?>(14), Tuple.Create<decimal?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence that contains only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence that contains only nulls")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<decimal?>[] { Tuple.Create<decimal?>(null), Tuple.Create<decimal?>(null), Tuple.Create<decimal?>(null) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the max of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the max of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MaxDecimalNullableSelectorSourceWithoutNulls()
        {
            Assert.AreEqual(10, new Tuple<decimal?>[] { Tuple.Create<decimal?>(10), Tuple.Create<decimal?>(4), Tuple.Create<decimal?>(6) }.Max(tuple => tuple.Item1));
        }

        /// <summary>
        /// A value type that implements <see cref="IComparable{T}"/>
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private struct ValueType : IComparable<ValueType>
        {
            /// <summary>
            /// The underlying value that is used for comparisons
            /// </summary>
            private readonly int value;

            /// <summary>
            /// Initializes a new instance of the <see cref="ValueType"/> struct
            /// </summary>
            /// <param name="value">The underlying value that is used for comparisons</param>
            public ValueType(int value)
            {
                this.value = value;
            }

            /// <summary>
            /// Gets the underlying value that is used for comparisons
            /// </summary>
            public int Value
            {
                get
                {
                    return this.value;
                }
            }

            /// <summary>
            /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object
            /// </summary>
            /// <param name="other">An object to compare with this instance</param>
            /// <returns>A value that indicates the relative order of the objects being compared</returns>
            public int CompareTo(ValueType other)
            {
                return this.value.CompareTo(other.value);
            }
        }

        /// <summary>
        /// A type that implements <see cref="IComparable{T}"/>
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private sealed class GenericComparable : IComparable<GenericComparable>
        {
            /// <summary>
            /// The underlying value that is used for comparisons
            /// </summary>
            private readonly int value;

            /// <summary>
            /// Initializes a new instance of the <see cref="GenericComparable"/> class
            /// </summary>
            /// <param name="value">The underlying value that is used for comparisons</param>
            public GenericComparable(int value)
            {
                this.value = value;
            }

            /// <summary>
            /// Gets the underlying value that is used for comparisons
            /// </summary>
            public int Value
            {
                get
                {
                    return this.value;
                }
            }

            /// <summary>
            /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object
            /// </summary>
            /// <param name="other">An object to compare with this instance</param>
            /// <returns>A value that indicates the relative order of the objects being compared</returns>
            public int CompareTo(GenericComparable other)
            {
                if (other == null)
                {
                    return 1;
                }

                return this.value.CompareTo(other.value);
            }
        }

        /// <summary>
        /// A type that implements <see cref="IComparable"/>
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private sealed class NonGenericComparable : IComparable
        {
            /// <summary>
            /// The underlying value that is used for comparisons
            /// </summary>
            private readonly int value;

            /// <summary>
            /// Initializes a new instance of the <see cref="NonGenericComparable"/> class
            /// </summary>
            /// <param name="value">The underlying value that is used for comparisons</param>
            public NonGenericComparable(int value)
            {
                this.value = value;
            }

            /// <summary>
            /// Gets the underlying value that is used for comparisons
            /// </summary>
            public int Value
            {
                get
                {
                    return this.value;
                }
            }

            /// <summary>
            /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object
            /// </summary>
            /// <param name="obj">An object to compare with this instance</param>
            /// <returns>A value that indicates the relative order of the objects being compared</returns>
            public int CompareTo(object obj)
            {
                return ((NonGenericComparable)obj).value.CompareTo(this.value);
            }
        }

        /// <summary>
        /// A type that implements both <see cref="IComparable{T}"/> and <see cref="IComparable"/>
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private sealed class Comparable : IComparable<Comparable>, IComparable
        {
            /// <summary>
            /// The underlying value that is used for comparisons
            /// </summary>
            private readonly int value;

            /// <summary>
            /// Initializes a new instance of the <see cref="Comparable"/> class
            /// </summary>
            /// <param name="value">The underlying value that is used for comparisons</param>
            public Comparable(int value)
            {
                this.value = value;
            }

            /// <summary>
            /// Gets the underlying value that is used for comparisons
            /// </summary>
            public int Value
            {
                get
                {
                    return this.value;
                }
            }

            /// <summary>
            /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object
            /// </summary>
            /// <param name="obj">An object to compare with this instance</param>
            /// <returns>A value that indicates the relative order of the objects being compared</returns>
            public int CompareTo(object obj)
            {
                return ((Comparable)obj).value.CompareTo(this.value);
            }

            /// <summary>
            /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object
            /// </summary>
            /// <param name="other">An object to compare with this instance</param>
            /// <returns>A value that indicates the relative order of the objects being compared</returns>
            public int CompareTo(Comparable other)
            {
                if (other == null)
                {
                    return 1;
                }

                return this.value.CompareTo(other.value);
            }
        }

        /// <summary>
        /// A reference type that implements <see cref="IComparable{T}"/>
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private sealed class ReferenceType : IComparable<ReferenceType>
        {
            /// <summary>
            /// The underlying value that is used for comparisons
            /// </summary>
            private readonly int value;

            /// <summary>
            /// Initializes a new instance of the <see cref="ReferenceType"/> class
            /// </summary>
            /// <param name="value">The underlying value that is used for comparisons</param>
            public ReferenceType(int value)
            {
                this.value = value;
            }

            /// <summary>
            /// Gets the underlying value that is used for comparisons
            /// </summary>
            public int Value
            {
                get
                {
                    return this.value;
                }
            }

            /// <summary>
            /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object
            /// </summary>
            /// <param name="other">An object to compare with this instance</param>
            /// <returns>A value that indicates the relative order of the objects being compared</returns>
            public int CompareTo(ReferenceType other)
            {
                if (other == null)
                {
                    return 1;
                }

                return this.value.CompareTo(other.value);
            }
        }
    }
}
