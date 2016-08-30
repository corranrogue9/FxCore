namespace Fx.Serialization
{
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="WcfSerializer"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class WcfSerializerUnitTests
    {
        #region Default

        /// <summary>
        /// Serializes and deserializes an object to bytes and asserts that they are equivalent
        /// </summary>
        [TestCategory("Unit")]
        [Description("Serializes and deserializes an object to bytes and asserts that they are equivalent")]
        [Priority(1)]
        [TestMethod]
        public void SerializeBytes()
        {
            SerializerUnitTests.SerializeBytes(WcfSerializer.Default);
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
            SerializerUnitTests.SerializeStream(WcfSerializer.Default);
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
            SerializerUnitTests.SerializeString(WcfSerializer.Default);
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
            SerializerUnitTests.StringSerialization(WcfSerializer.Default);
        }

        #endregion

        #region ASCII

        /// <summary>
        /// Serializes and deserializes an object to bytes and asserts that they are equivalent
        /// </summary>
        [TestCategory("Unit")]
        [Description("Serializes and deserializes an object to bytes and asserts that they are equivalent")]
        [Priority(1)]
        [TestMethod]
        public void AsciiSerializeBytes()
        {
            SerializerUnitTests.SerializeBytes(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Serializes and deserializes an object to a stream and asserts that they are equivalent
        /// </summary>
        [TestCategory("Unit")]
        [Description("Serializes and deserializes an object to a stream and asserts that they are equivalent")]
        [Priority(1)]
        [TestMethod]
        public void AsciiSerializeStream()
        {
            SerializerUnitTests.SerializeStream(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Serializes and deserializes an object to a string and asserts that they are equivalent
        /// </summary>
        [TestCategory("Unit")]
        [Description("Serializes and deserializes an object to a string and asserts that they are equivalent")]
        [Priority(1)]
        [TestMethod]
        public void AsciiSerializeString()
        {
            SerializerUnitTests.SerializeString(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Serializes and deserializes a string and asserts that they are equivalent
        /// </summary>
        [TestCategory("Unit")]
        [Description("Serializes and deserializes a string and asserts that they are equivalent")]
        [Priority(1)]
        [TestMethod]
        public void AsciiStringSerialization()
        {
            SerializerUnitTests.StringSerialization(WcfSerializer.Create(Encoding.ASCII));
        }

        #endregion

        /// <summary>
        /// Creates the default instance of the serializer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates the default instance of the serializer")]
        [Priority(1)]
        [TestMethod]
        public void DefaultCreation()
        {
            Assert.AreEqual(WcfSerializer.Default, WcfSerializer.Create(Encoding.UTF8));
        }
    }
}
