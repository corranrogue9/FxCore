namespace System
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ByteArrayComparer"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ByteArrayComparerUnitTests
    {
        /// <summary>
        /// Compares two null byte arrays for equality
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Compares two null byte arrays for equality")]
        [TestMethod]
        public void EqualsNulls()
        {
            byte[] value1 = null;
            byte[] value2 = null;
            Assert.IsTrue(ByteArrayComparer.Instance.Equals(value1, value2));
        }

        /// <summary>
        /// Compares a null byte array with a non-null byte array for equality
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Compares a null byte array with a non-null byte array for equality")]
        [TestMethod]
        public void EqualsNull()
        {
            byte[] value1 = null;
            var value2 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            Assert.IsFalse(ByteArrayComparer.Instance.Equals(value1, value2));

            var value3 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            byte[] value4 = null;
            Assert.IsFalse(ByteArrayComparer.Instance.Equals(value3, value4));
        }

        /// <summary>
        /// Compares two byte arrays that have different lengths for equality
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Compares two byte arrays that have different lengths for equality")]
        [TestMethod]
        public void EqualsDifferentLengths()
        {
            var value1 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06 };
            var value2 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            Assert.IsFalse(ByteArrayComparer.Instance.Equals(value1, value2));
        }

        /// <summary>
        /// Compares two arrays that are the same for equality
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Compares two arrays that are the same for equality")]
        [TestMethod]
        public void EqualsSameArrays()
        {
            var value1 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            var value2 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            Assert.IsTrue(ByteArrayComparer.Instance.Equals(value1, value2));
            Assert.AreEqual(ByteArrayComparer.Instance.GetHashCode(value1), ByteArrayComparer.Instance.GetHashCode(value2));
        }

        /// <summary>
        /// Compares for equality two arrays that are the same, and then compares each with a third, identical array
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Compares for equality two arrays that are the same, and then compares each with a third, identical array")]
        [TestMethod]
        public void EqualityTransitive()
        {
            var value1 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            var value2 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            var value3 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };

            Assert.IsTrue(ByteArrayComparer.Instance.Equals(value1, value2));
            Assert.AreEqual(ByteArrayComparer.Instance.GetHashCode(value1), ByteArrayComparer.Instance.GetHashCode(value2));

            Assert.IsTrue(ByteArrayComparer.Instance.Equals(value2, value3));
            Assert.AreEqual(ByteArrayComparer.Instance.GetHashCode(value2), ByteArrayComparer.Instance.GetHashCode(value3));

            Assert.IsTrue(ByteArrayComparer.Instance.Equals(value1, value3));
            Assert.AreEqual(ByteArrayComparer.Instance.GetHashCode(value1), ByteArrayComparer.Instance.GetHashCode(value3));
        }

        /// <summary>
        /// Compares for equality two arrays that are the same, and then compares them swapping order
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Compares for equality two arrays that are the same, and then compares them swapping order")]
        [TestMethod]
        public void EqualitySymmetric()
        {
            var value1 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            var value2 = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };

            Assert.IsTrue(ByteArrayComparer.Instance.Equals(value1, value2));
            Assert.AreEqual(ByteArrayComparer.Instance.GetHashCode(value1), ByteArrayComparer.Instance.GetHashCode(value2));

            Assert.IsTrue(ByteArrayComparer.Instance.Equals(value2, value1));
            Assert.AreEqual(ByteArrayComparer.Instance.GetHashCode(value2), ByteArrayComparer.Instance.GetHashCode(value1));
        }

        /// <summary>
        /// Compares an array with itself for equality
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Compares an array with itself for equality")]
        [TestMethod]
        public void EqualityReflexive()
        {
            var value = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
            Assert.IsTrue(ByteArrayComparer.Instance.Equals(value, value));
            Assert.AreEqual(ByteArrayComparer.Instance.GetHashCode(value), ByteArrayComparer.Instance.GetHashCode(value));
        }

        /// <summary>
        /// Compares two empty byte arrays for equality
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Compares two empty byte arrays for equality")]
        [TestMethod]
        public void EqualityEmptyArray()
        {
            var value1 = new byte[0];
            var value2 = new byte[0];
            Assert.IsTrue(ByteArrayComparer.Instance.Equals(value1, value2));
            Assert.AreEqual(ByteArrayComparer.Instance.GetHashCode(value1), ByteArrayComparer.Instance.GetHashCode(value2));
        }
    }
}
