namespace Fx.Serialization
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="BinarySerializer"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class BinarySerializerUnitTests
    {
        /// <summary>
        /// Serializes and deserializes an object to bytes and asserts that they are equivalent
        /// </summary>
        [TestCategory("Unit")]
        [Description("Serializes and deserializes an object to bytes and asserts that they are equivalent")]
        [Priority(1)]
        [TestMethod]
        public void SerializeBytes()
        {
            SerializerUnitTests.SerializeBytes(BinarySerializer.Default);
        }

        /// <summary>
        /// Serializes and deserializes an object to a stream and asserts that they are equivalent
        /// </summary>
        [TestCategory("Unit")]
        [Description("Serializes and deserializes an object to a stream and asserts that they are equivalent")]
        [Priority(1)]
        [TestMethod]
        public void SerializeStream()
        {
            SerializerUnitTests.SerializeStream(BinarySerializer.Default);
        }

        /// <summary>
        /// Serializes and deserializes an object to a string and asserts that they are equivalent
        /// </summary>
        [TestCategory("Unit")]
        [Description("Serializes and deserializes an object to a string and asserts that they are equivalent")]
        [Priority(1)]
        [TestMethod]
        public void SerializeString()
        {
            SerializerUnitTests.SerializeString(BinarySerializer.Default);
        }

        /// <summary>
        /// Serializes and deserializes a string and asserts that they are equivalent
        /// </summary>
        [TestCategory("Unit")]
        [Description("Serializes and deserializes a string and asserts that they are equivalent")]
        [Priority(1)]
        [TestMethod]
        public void StringSerialization()
        {
            SerializerUnitTests.StringSerialization(BinarySerializer.Default);
        }
    }
}
