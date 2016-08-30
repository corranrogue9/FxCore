namespace Fx.Serialization
{
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="XmlSerializer"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class XmlSerializerUnitTests
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
            SerializerUnitTests.SerializeBytes(XmlSerializer.Default);
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
            SerializerUnitTests.SerializeStream(XmlSerializer.Default);
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
            SerializerUnitTests.SerializeString(XmlSerializer.Default);
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
            SerializerUnitTests.StringSerialization(XmlSerializer.Default);
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
            SerializerUnitTests.SerializeBytes(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerUnitTests.SerializeStream(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerUnitTests.SerializeString(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerUnitTests.StringSerialization(XmlSerializer.Create(Encoding.ASCII));
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
            Assert.AreEqual(XmlSerializer.Default, XmlSerializer.Create(Encoding.UTF8));
        }
    }
}
