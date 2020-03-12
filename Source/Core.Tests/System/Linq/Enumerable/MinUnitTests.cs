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
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<float?>().Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new float?[] { null, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSourceWithNulls()
        {
            Assert.AreEqual(1, new float?[] { null, 4, 2, null, 1, 3, null }.Min());
        }
        
        /// <summary>
        /// Gets the min of a sequence that contains null and NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains null and NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSourceWithNullsAndNan()
        {
            Assert.AreEqual(float.NaN, new float?[] { null, float.NaN, float.MinValue, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullable()
        {
            Assert.AreEqual(1, new float?[] { 4, 2, 1, 3 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSourceWithNan()
        {
            Assert.AreEqual(float.NaN, new float?[] { float.NaN, float.MinValue }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains only NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSourceWithOnlyNan()
        {
            Assert.IsTrue(float.IsNaN(new float?[] { float.NaN }.Min().Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSourceWithNegativeInfinity()
        {
            Assert.IsTrue(float.IsNegativeInfinity(new float?[] { float.NegativeInfinity, float.MaxValue }.Min().Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSourceWithPositiveInfinity()
        {
            Assert.AreEqual(float.MaxValue, new float?[] { float.PositiveInfinity, float.MaxValue }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains one element")]
        [Priority(1)]
        [TestMethod]
        public void MinIntSingleElement()
        {
            Assert.AreEqual(10, new int[] { 10 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinInt()
        {
            Assert.AreEqual(3, new int[] { 5, 3, 11, 10 }.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<long?>().Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new long?[] { null, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableSourceWithNulls()
        {
            Assert.AreEqual(1, new long?[] { null, 4, 2, null, 1, 3, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullable()
        {
            Assert.AreEqual(1, new long?[] { 4, 2, 1, 3 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloat()
        {
            Assert.AreEqual(1, new float[] { 4, 2, 1, 3 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSingleElement()
        {
            Assert.AreEqual(3, new float[] { 3 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSourceWithNan()
        {
            Assert.AreEqual(float.NaN, new float[] { 3, float.NaN }.Min());
            Assert.AreEqual(float.NaN, new float[] { float.NaN, 3 }.Min());
            Assert.AreEqual(float.NaN, new float[] { float.NaN, 3, float.NaN }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSourceWithOnlyNan()
        {
            Assert.IsTrue(float.IsNaN(new float[] { float.NaN }.Min()));
            Assert.IsTrue(float.IsNaN(new float[] { float.NaN, float.NaN }.Min()));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSourceWithNegativeInfinity()
        {
            Assert.IsTrue(float.IsNegativeInfinity(new float[] { float.MaxValue, float.NegativeInfinity }.Min()));
        }

        /// <summary>
        /// Gets the min of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSourceWithPositiveInfinity()
        {
            Assert.AreEqual(float.MaxValue, new float[] { float.MaxValue, float.PositiveInfinity }.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<int?>().Min());
        }

        /// <summary>
        /// Gets the min of a sequence that only contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that only contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new int?[] { null, null, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableSourceWithNulls()
        {
            Assert.AreEqual(2, new int?[] { null, 3, 10, 2, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullable()
        {
            Assert.AreEqual(2, new int?[] { 3, 10, 2 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimal()
        {
            Assert.AreEqual(2, new decimal[] { 5, 2, 3 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalSingleElement()
        {
            Assert.AreEqual(5, new decimal[] { 5 }.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<decimal?>().Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableSourceWithNulls()
        {
            Assert.AreEqual(4, new decimal?[] { null, 6, 14, 10, null, 4, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new decimal?[] { null, null, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableSourceWithoutNulls()
        {
            Assert.AreEqual(4, new decimal?[] { 4, 10, 6 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains one element")]
        [Priority(1)]
        [TestMethod]
        public void MinLongSingleElement()
        {
            Assert.AreEqual(10, new long[] { 10 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLong()
        {
            Assert.AreEqual(3, new long[] { 5, 3, 11, 10 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDouble()
        {
            Assert.AreEqual(1, new double[] { 4, 2, 1, 3 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSingleElement()
        {
            Assert.AreEqual(3, new double[] { 3 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSourceWithNan()
        {
            Assert.AreEqual(double.NaN, new double[] { 3, double.NaN }.Min());
            Assert.AreEqual(double.NaN, new double[] { double.NaN, 3 }.Min());
            Assert.AreEqual(double.NaN, new double[] { double.NaN, 3, double.NaN }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSourceWithNanAndFloatNan()
        {
            Assert.AreEqual(double.NaN, new double[] { 3, double.NaN, float.NaN }.Min());
            Assert.AreEqual(double.NaN, new double[] { double.NaN, float.NaN, 3 }.Min());
            Assert.AreEqual(double.NaN, new double[] { double.NaN, 3, double.NaN, float.NaN }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSourceWithOnlyNan()
        {
            Assert.IsTrue(double.IsNaN(new double[] { double.NaN }.Min()));
            Assert.IsTrue(double.IsNaN(new double[] { double.NaN, double.NaN }.Min()));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSourceWithOnlyNanAndFloatNan()
        {
            Assert.IsTrue(double.IsNaN(new double[] { double.NaN, float.NaN }.Min()));
            Assert.IsTrue(double.IsNaN(new double[] { float.NaN, double.NaN, float.NaN }.Min()));
            Assert.IsTrue(double.IsNaN(new double[] { double.NaN, float.NaN, double.NaN }.Min()));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSourceWithNegativeInfinity()
        {
            Assert.IsTrue(double.IsNegativeInfinity(new double[] { double.MaxValue, double.NegativeInfinity }.Min()));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSourceWithNegativeInfinityAndFloatNegativeInfinity()
        {
            Assert.IsTrue(double.IsNegativeInfinity(new double[] { double.MaxValue, float.NegativeInfinity, double.NegativeInfinity }.Min()));
            Assert.IsTrue(double.IsNegativeInfinity(new double[] { double.MaxValue, double.NegativeInfinity, float.NegativeInfinity }.Min()));
        }

        /// <summary>
        /// Gets the min of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSourceWithPositiveInfinity()
        {
            Assert.AreEqual(double.MaxValue, new double[] { double.MaxValue, double.PositiveInfinity }.Min());
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<double?>().Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new double?[] { null, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithNulls()
        {
            Assert.AreEqual(1, new double?[] { null, 4, 2, null, 1, 3, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains null and NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains null and NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithNullsAndNan()
        {
            Assert.AreEqual(double.NaN, new double?[] { null, double.NaN, double.MinValue, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullable()
        {
            Assert.AreEqual(1, new double?[] { 4, 2, 1, 3 }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithNan()
        {
            Assert.AreEqual(double.NaN, new double?[] { double.NaN, double.MinValue }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithNanAndFloatNan()
        {
            Assert.AreEqual(double.NaN, new double?[] { 3, double.NaN, float.NaN }.Min());
            Assert.AreEqual(double.NaN, new double?[] { double.NaN, float.NaN, 3 }.Min());
            Assert.AreEqual(double.NaN, new double?[] { double.NaN, 3, double.NaN, float.NaN }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains only NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithOnlyNan()
        {
            Assert.IsTrue(double.IsNaN(new double?[] { double.NaN }.Min().Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithOnlyNanAndFloatNan()
        {
            Assert.IsTrue(double.IsNaN(new double?[] { double.NaN, float.NaN }.Min().Value));
            Assert.IsTrue(double.IsNaN(new double?[] { float.NaN, double.NaN, float.NaN }.Min().Value));
            Assert.IsTrue(double.IsNaN(new double?[] { double.NaN, float.NaN, double.NaN }.Min().Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithNegativeInfinity()
        {
            Assert.IsTrue(double.IsNegativeInfinity(new double?[] { double.NegativeInfinity, double.MaxValue }.Min().Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithNegativeInfinityAndFloatNegativeInfinity()
        {
            Assert.IsTrue(double.IsNegativeInfinity(new double?[] { double.MaxValue, float.NegativeInfinity, double.NegativeInfinity }.Min().Value));
            Assert.IsTrue(double.IsNegativeInfinity(new double?[] { double.MaxValue, double.NegativeInfinity, float.NegativeInfinity }.Min().Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSourceWithPositiveInfinity()
        {
            Assert.AreEqual(double.MaxValue, new double?[] { double.PositiveInfinity, double.MaxValue }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains IComparable{T} elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains IComparable{T} elements")]
        [Priority(1)]
        [TestMethod]
        public void MinGenericComparable()
        {
            Assert.AreEqual(1, new GenericComparable[] { new GenericComparable(4), new GenericComparable(1), new GenericComparable(3) }.Min().Value);
        }

        /// <summary>
        /// Gets the min of a sequence that contains IComparable elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains IComparable elements")]
        [Priority(1)]
        [TestMethod]
        public void MinNonGenericComparable()
        {
            Assert.AreEqual(4, new NonGenericComparable[] { new NonGenericComparable(4), new NonGenericComparable(1), new NonGenericComparable(3) }.Min().Value);
        }

        /// <summary>
        /// Gets the min of a sequence that contains IComparable elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains IComparable elements")]
        [Priority(1)]
        [TestMethod]
        public void MinComparable()
        {
            Assert.AreEqual(1, new Comparable[] { new Comparable(4), new Comparable(1), new Comparable(3) }.Min().Value);
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinEmptySourceReferenceType()
        {
            Assert.AreEqual(null, Enumerable.Empty<object>().Min());
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new object[] { null, null, null }.Min());
        }

        /// <summary>
        /// Gets the min of a sequence 
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinReferenceType()
        {
            Assert.AreEqual(2, new ReferenceType[] { new ReferenceType(3), new ReferenceType(2), new ReferenceType(4) }.Min().Value);
        }

        /// <summary>
        /// Gets the min of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinReferenceTypeSingleElement()
        {
            Assert.AreEqual(3, new ReferenceType[] { new ReferenceType(3) }.Min().Value);
        }

        /// <summary>
        /// Gets the min of a sequence that contains null
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains null")]
        [Priority(1)]
        [TestMethod]
        public void MinReferenceTypeWithNulls()
        {
            Assert.AreEqual(2, new ReferenceType[] { null, new ReferenceType(3), new ReferenceType(2), null, new ReferenceType(4), null }.Min().Value);
        }

        /// <summary>
        /// Gets the min of a sequence 
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinValueType()
        {
            Assert.AreEqual(2, new ValueType[] { new ValueType(3), new ValueType(2), new ValueType(4) }.Min().Value);
        }

        /// <summary>
        /// Gets the min of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinValueTypeSingleElement()
        {
            Assert.AreEqual(3, new ValueType[] { new ValueType(3) }.Min().Value);
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSelector()
        {
            Assert.AreEqual(1, new Tuple<float>[] { Tuple.Create<float>(4), Tuple.Create<float>(2), Tuple.Create<float>(1), Tuple.Create<float>(3) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSelectorSingleElement()
        {
            Assert.AreEqual(3, new Tuple<float>[] { Tuple.Create<float>(3) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSelectorSourceWithNan()
        {
            Assert.AreEqual(float.NaN, new Tuple<float>[] { Tuple.Create<float>(3), Tuple.Create<float>(float.NaN) }.Min(tuple => tuple.Item1));
            Assert.AreEqual(float.NaN, new Tuple<float>[] { Tuple.Create<float>(float.NaN), Tuple.Create<float>(3) }.Min(tuple => tuple.Item1));
            Assert.AreEqual(float.NaN, new Tuple<float>[] { Tuple.Create<float>(float.NaN), Tuple.Create<float>(3), Tuple.Create<float>(float.NaN) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSelectorSourceWithOnlyNan()
        {
            Assert.IsTrue(float.IsNaN(new Tuple<float>[] { Tuple.Create<float>(float.NaN) }.Min(tuple => tuple.Item1)));
            Assert.IsTrue(float.IsNaN(new Tuple<float>[] { Tuple.Create<float>(float.NaN), Tuple.Create<float>(float.NaN) }.Min(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSelectorSourceWithNegativeInfinity()
        {
            Assert.IsTrue(float.IsNegativeInfinity(new Tuple<float>[] { Tuple.Create<float>(float.MaxValue), Tuple.Create<float>(float.NegativeInfinity) }.Min(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the min of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatSelectorSourceWithPositiveInfinity()
        {
            Assert.AreEqual(float.MaxValue, new Tuple<float>[] { Tuple.Create<float>(float.MaxValue), Tuple.Create<float>(float.PositiveInfinity) }.Min(tuple => tuple.Item1));
        }
        
        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<float?>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<float?>[] { Tuple.Create<float?>(null), Tuple.Create<float?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(1, new Tuple<float?>[] { Tuple.Create<float?>(null), Tuple.Create<float?>(4), Tuple.Create<float?>(2), Tuple.Create<float?>(null), Tuple.Create<float?>(1), Tuple.Create<float?>(3), Tuple.Create<float?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains null and NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains null and NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorSourceWithNullsAndNan()
        {
            Assert.AreEqual(float.NaN, new Tuple<float?>[] { Tuple.Create<float?>(null), Tuple.Create<float?>(float.NaN), Tuple.Create<float?>(float.MinValue), Tuple.Create<float?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelector()
        {
            Assert.AreEqual(1, new Tuple<float?>[] { Tuple.Create<float?>(4), Tuple.Create<float?>(2), Tuple.Create<float?>(1), Tuple.Create<float?>(3) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorSourceWithNan()
        {
            Assert.AreEqual(float.NaN, new Tuple<float?>[] { Tuple.Create<float?>(float.NaN), Tuple.Create<float?>(float.MinValue) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorSourceWithOnlyNan()
        {
            Assert.IsTrue(float.IsNaN(new Tuple<float?>[] { Tuple.Create<float?>(float.NaN) }.Min(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorSourceWithNegativeInfinity()
        {
            Assert.IsTrue(float.IsNegativeInfinity(new Tuple<float?>[] { Tuple.Create<float?>(float.NegativeInfinity), Tuple.Create<float?>(float.MaxValue) }.Min(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinFloatNullableSelectorSourceWithPositiveInfinity()
        {
            Assert.AreEqual(float.MaxValue, new Tuple<float?>[] { Tuple.Create<float?>(float.PositiveInfinity), Tuple.Create<float?>(float.MaxValue) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<long?>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<long?>[] { Tuple.Create<long?>(null), Tuple.Create<long?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(1, new Tuple<long?>[] { Tuple.Create<long?>(null), Tuple.Create<long?>(4), Tuple.Create<long?>(2), Tuple.Create<long?>(null), Tuple.Create<long?>(1), Tuple.Create<long?>(3), Tuple.Create<long?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongNullableSelector()
        {
            Assert.AreEqual(1, new Tuple<long?>[] { Tuple.Create<long?>(4), Tuple.Create<long?>(2), Tuple.Create<long?>(1), Tuple.Create<long?>(3) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<int?>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that only contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that only contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<int?>[] { Tuple.Create<int?>(null), Tuple.Create<int?>(null), Tuple.Create<int?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(2, new Tuple<int?>[] { Tuple.Create<int?>(null), Tuple.Create<int?>(3), Tuple.Create<int?>(10), Tuple.Create<int?>(2), Tuple.Create<int?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinIntNullableSelector()
        {
            Assert.AreEqual(2, new Tuple<int?>[] { Tuple.Create<int?>(3), Tuple.Create<int?>(10), Tuple.Create<int?>(2) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<double?>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<double?>[] { Tuple.Create<double?>(null), Tuple.Create<double?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(1, new Tuple<double?>[] { Tuple.Create<double?>(null), Tuple.Create<double?>(4), Tuple.Create<double?>(2), Tuple.Create<double?>(null), Tuple.Create<double?>(1), Tuple.Create<double?>(3), Tuple.Create<double?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains null and NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains null and NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithNullsAndNan()
        {
            Assert.AreEqual(double.NaN, new Tuple<double?>[] { Tuple.Create<double?>(null), Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(double.MinValue), Tuple.Create<double?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelector()
        {
            Assert.AreEqual(1, new Tuple<double?>[] { Tuple.Create<double?>(4), Tuple.Create<double?>(2), Tuple.Create<double?>(1), Tuple.Create<double?>(3) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithNan()
        {
            Assert.AreEqual(double.NaN, new Tuple<double?>[] { Tuple.Create<double?>(double.MinValue), Tuple.Create<double?>(double.NaN) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithNanAndFloatNan()
        {
            Assert.AreEqual(double.NaN, new Tuple<double?>[] { Tuple.Create<double?>(3), Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN) }.Min(tuple => tuple.Item1));
            Assert.AreEqual(double.NaN, new Tuple<double?>[] { Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN), Tuple.Create<double?>(3) }.Min(tuple => tuple.Item1));
            Assert.AreEqual(double.NaN, new Tuple<double?>[] { Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(3), Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only NaN values
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only NaN values")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithOnlyNan()
        {
            Assert.IsTrue(double.IsNaN(new Tuple<double?>[] { Tuple.Create<double?>(double.NaN) }.Min(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithOnlyNanAndFloatNan()
        {
            Assert.IsTrue(double.IsNaN(new Tuple<double?>[] { Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN) }.Min(tuple => tuple.Item1).Value));
            Assert.IsTrue(double.IsNaN(new Tuple<double?>[] { Tuple.Create<double?>(float.NaN), Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN) }.Min(tuple => tuple.Item1).Value));
            Assert.IsTrue(double.IsNaN(new Tuple<double?>[] { Tuple.Create<double?>(double.NaN), Tuple.Create<double?>(float.NaN), Tuple.Create<double?>(double.NaN) }.Min(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithNegativeInfinity()
        {
            Assert.IsTrue(double.IsNegativeInfinity(new Tuple<double?>[] { Tuple.Create<double?>(double.NegativeInfinity), Tuple.Create<double?>(double.MaxValue) }.Min(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithNegativeInfinityAndFloatNegativeInfinity()
        {
            Assert.IsTrue(double.IsNegativeInfinity(new Tuple<double?>[] { Tuple.Create<double?>(double.MaxValue), Tuple.Create<double?>(float.NegativeInfinity), Tuple.Create<double?>(double.PositiveInfinity) }.Min(tuple => tuple.Item1).Value));
            Assert.IsTrue(double.IsNegativeInfinity(new Tuple<double?>[] { Tuple.Create<double?>(double.MaxValue), Tuple.Create<double?>(double.NegativeInfinity), Tuple.Create<double?>(float.PositiveInfinity) }.Min(tuple => tuple.Item1).Value));
        }

        /// <summary>
        /// Gets the min of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleNullableSelectorSourceWithPositiveInfinity()
        {
            Assert.AreEqual(double.MaxValue, new Tuple<double?>[] { Tuple.Create<double?>(double.PositiveInfinity), Tuple.Create<double?>(double.MaxValue) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains one element")]
        [Priority(1)]
        [TestMethod]
        public void MinLongSelectorSingleElement()
        {
            Assert.AreEqual(10, new Tuple<long>[] { Tuple.Create<long>(10) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinLongSelector()
        {
            Assert.AreEqual(3, new Tuple<long>[] { Tuple.Create<long>(5), Tuple.Create<long>(3), Tuple.Create<long>(11), Tuple.Create<long>(10) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains one element")]
        [Priority(1)]
        [TestMethod]
        public void MinIntSelectorSingleElement()
        {
            Assert.AreEqual(10, new Tuple<int>[] { Tuple.Create(10) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinIntSelector()
        {
            Assert.AreEqual(3, new Tuple<int>[] { Tuple.Create(5), Tuple.Create(3), Tuple.Create(11), Tuple.Create(10) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelector()
        {
            Assert.AreEqual(1, new Tuple<double>[] { Tuple.Create<double>(4), Tuple.Create<double>(2), Tuple.Create<double>(1), Tuple.Create<double>(3) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorSingleElement()
        {
            Assert.AreEqual(3, new Tuple<double>[] { Tuple.Create<double>(3) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorSourceWithNan()
        {
            Assert.AreEqual(double.NaN, new Tuple<double>[] { Tuple.Create<double>(3), Tuple.Create<double>(double.NaN) }.Min(tuple => tuple.Item1));
            Assert.AreEqual(double.NaN, new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(3) }.Min(tuple => tuple.Item1));
            Assert.AreEqual(double.NaN, new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(3), Tuple.Create<double>(double.NaN) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorSourceWithNanAndFloatNan()
        {
            Assert.AreEqual(double.NaN, new Tuple<double>[] { Tuple.Create<double>(3), Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN) }.Min(tuple => tuple.Item1));
            Assert.AreEqual(double.NaN, new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN), Tuple.Create<double>(3) }.Min(tuple => tuple.Item1));
            Assert.AreEqual(double.NaN, new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(3), Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorSourceWithOnlyNan()
        {
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(double.NaN) }.Min(tuple => tuple.Item1)));
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(double.NaN) }.Min(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nans
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nans")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorSourceWithOnlyNanAndFloatNan()
        {
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN) }.Min(tuple => tuple.Item1)));
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(float.NaN), Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN) }.Min(tuple => tuple.Item1)));
            Assert.IsTrue(double.IsNaN(new Tuple<double>[] { Tuple.Create<double>(double.NaN), Tuple.Create<double>(float.NaN), Tuple.Create<double>(double.NaN) }.Min(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorSourceWithNegativeInfinity()
        {
            Assert.IsTrue(double.IsNegativeInfinity(new Tuple<double>[] { Tuple.Create<double>(double.MaxValue), Tuple.Create<double>(double.NegativeInfinity) }.Min(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the min of a sequence that contains negative infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains negative infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorSourceWithNegativeInfinityAndFloatNegativeInfinity()
        {
            Assert.IsTrue(double.IsNegativeInfinity(new Tuple<double>[] { Tuple.Create<double>(double.MaxValue), Tuple.Create<double>(float.NegativeInfinity), Tuple.Create<double>(double.NegativeInfinity) }.Min(tuple => tuple.Item1)));
            Assert.IsTrue(double.IsNegativeInfinity(new Tuple<double>[] { Tuple.Create<double>(double.MaxValue), Tuple.Create<double>(double.NegativeInfinity), Tuple.Create<double>(float.NegativeInfinity) }.Min(tuple => tuple.Item1)));
        }

        /// <summary>
        /// Gets the min of a sequence that contains positive infinity
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains positive infinity")]
        [Priority(1)]
        [TestMethod]
        public void MinDoubleSelectorSourceWithPositiveInfinity()
        {
            Assert.AreEqual(double.MaxValue, new Tuple<double>[] { Tuple.Create<double>(double.MaxValue), Tuple.Create<double>(double.PositiveInfinity) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalSelector()
        {
            Assert.AreEqual(2, new Tuple<decimal>[] { Tuple.Create<decimal>(5), Tuple.Create<decimal>(2), Tuple.Create<decimal>(3) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalSingleElementSelector()
        {
            Assert.AreEqual(5, new Tuple<decimal>[] { Tuple.Create<decimal>(5) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains IComparable{T} elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains IComparable{T} elements")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorGenericComparable()
        {
            Assert.AreEqual(1, new Tuple<GenericComparable>[] { Tuple.Create(new GenericComparable(4)), Tuple.Create(new GenericComparable(1)), Tuple.Create(new GenericComparable(3)) }.Min(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the min of a sequence that contains IComparable elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains IComparable elements")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorNonGenericComparable()
        {
            Assert.AreEqual(4, new Tuple<NonGenericComparable>[] { Tuple.Create(new NonGenericComparable(4)), Tuple.Create(new NonGenericComparable(1)), Tuple.Create(new NonGenericComparable(3)) }.Min(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the min of a sequence that contains IComparable elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains IComparable elements")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorComparable()
        {
            Assert.AreEqual(1, new Tuple<Comparable>[] { Tuple.Create(new Comparable(4)), Tuple.Create(new Comparable(1)), Tuple.Create(new Comparable(3)) }.Min(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorEmptySourceReferenceType()
        {
            Assert.AreEqual(null, Enumerable.Empty<object>().Min(@object => @object));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new object[] { null, null, null }.Min(@object => @object));
        }

        /// <summary>
        /// Gets the min of a sequence 
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorReferenceType()
        {
            Assert.AreEqual(2, new Tuple<ReferenceType>[] { Tuple.Create(new ReferenceType(3)), Tuple.Create(new ReferenceType(2)), Tuple.Create(new ReferenceType(4)) }.Min(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the min of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorReferenceTypeSingleElement()
        {
            Assert.AreEqual(3, new Tuple<ReferenceType>[] { Tuple.Create(new ReferenceType(3)) }.Min(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the min of a sequence that contains null
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains null")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorReferenceTypeWithNulls()
        {
            Assert.AreEqual(2, new Tuple<ReferenceType>[] { Tuple.Create<ReferenceType>(null), Tuple.Create(new ReferenceType(3)), Tuple.Create(new ReferenceType(2)), Tuple.Create<ReferenceType>(null), Tuple.Create(new ReferenceType(4)), Tuple.Create<ReferenceType>(null) }.Min(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the min of a sequence 
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorValueType()
        {
            Assert.AreEqual(2, new Tuple<ValueType>[] { Tuple.Create(new ValueType(3)), Tuple.Create(new ValueType(2)), Tuple.Create(new ValueType(4)) }.Min(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the min of a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void MinSelectorValueTypeSingleElement()
        {
            Assert.AreEqual(3, new Tuple<ValueType>[] { Tuple.Create(new ValueType(3)) }.Min(tuple => tuple.Item1).Value);
        }

        /// <summary>
        /// Gets the min of an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableSelectorEmptySource()
        {
            Assert.AreEqual(null, Enumerable.Empty<Tuple<decimal?>>().Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableSelectorSourceWithNulls()
        {
            Assert.AreEqual(4, new Tuple<decimal?>[] { Tuple.Create<decimal?>(null), Tuple.Create<decimal?>(6), Tuple.Create<decimal?>(14), Tuple.Create<decimal?>(10), Tuple.Create<decimal?>(null), Tuple.Create<decimal?>(4), Tuple.Create<decimal?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence that contains only nulls
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence that contains only nulls")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableSelectorSourceWithOnlyNulls()
        {
            Assert.AreEqual(null, new Tuple<decimal?>[] { Tuple.Create<decimal?>(null), Tuple.Create<decimal?>(null), Tuple.Create<decimal?>(null) }.Min(tuple => tuple.Item1));
        }

        /// <summary>
        /// Gets the min of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Gets the min of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void MinDecimalNullableSelectorSourceWithoutNulls()
        {
            Assert.AreEqual(4, new Tuple<decimal?>[] { Tuple.Create<decimal?>(4), Tuple.Create<decimal?>(10), Tuple.Create<decimal?>(6) }.Min(tuple => tuple.Item1));
        }
    }
}
