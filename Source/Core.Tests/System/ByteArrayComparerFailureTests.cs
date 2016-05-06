namespace System
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ByteArrayComparer"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ByteArrayComparerFailureTests
    {
        /// <summary>
        /// Compares two null byte arrays for equality
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Gets the hash code of a null byte array")]
        [TestMethod]
        public void GetHashCodeNull()
        {
            byte[] value = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => ByteArrayComparer.Instance.GetHashCode(value));
        }
    }
}
