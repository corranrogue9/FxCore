namespace Fx.Serialization
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="BinarySerializer"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class BinarySerializerFailureTests
    {
        /// <summary>
        /// Attempts to serialize a null object to bytes
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a null object to bytes")]
        [Priority(1)]
        [TestMethod]
        public void SerializeNullBytes()
        {
            SerializerFailureTests.SerializeNullBytes(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to serialize a null object to a string
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a null object to a string")]
        [Priority(1)]
        [TestMethod]
        public void SerializeNullString()
        {
            SerializerFailureTests.SerializeNullString(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to serialize a null object to a stream
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a null object to a stream")]
        [Priority(1)]
        [TestMethod]
        public void SerializeNullStream()
        {
            SerializerFailureTests.SerializeNullStream(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to deserialize null bytes
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize null bytes")]
        [Priority(1)]
        [TestMethod]
        public void DeserializeNullBytes()
        {
            SerializerFailureTests.DeserializeNullBytes(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to deserialize a null string
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize a null string")]
        [Priority(1)]
        [TestMethod]
        public void DeserializeNullString()
        {
            SerializerFailureTests.DeserializeNullString(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to deserialize a null stream
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize a null stream")]
        [Priority(1)]
        [TestMethod]
        public void DeserializeNullStream()
        {
            SerializerFailureTests.DeserializeNullStream(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to serialize a non-serializable object to a stream
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a non-serializable object to a stream")]
        [Priority(1)]
        [TestMethod]
        public void SerializeMalformedTypeStream()
        {
            SerializerFailureTests.SerializeMalformedTypeStream(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to serialize a non-serializable object to bytes
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a non-serializable object to bytes")]
        [Priority(1)]
        [TestMethod]
        public void SerializeMalformedTypeBytes()
        {
            SerializerFailureTests.SerializeMalformedTypeBytes(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to serialize a non-serializable object to a string
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a non-serializable object to a string")]
        [Priority(1)]
        [TestMethod]
        public void SerializeMalformedTypeString()
        {
            SerializerFailureTests.SerializeMalformedTypeString(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to deserialize a malformed stream
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize a malformed stream")]
        [Priority(1)]
        [TestMethod]
        public void DeserializeMalformedTypeStream()
        {
            SerializerFailureTests.DeserializeMalformedTypeStream(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to deserialize malformed bytes
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize malformed bytes")]
        [Priority(1)]
        [TestMethod]
        public void DeserializeMalformedTypeBytes()
        {
            SerializerFailureTests.DeserializeMalformedTypeBytes(BinarySerializer.Default);
        }

        /// <summary>
        /// Attempts to deserialize a malformed string
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize a malformed string")]
        [Priority(1)]
        [TestMethod]
        public void DeserializeMalformedTypeString()
        {
            SerializerFailureTests.DeserializeMalformedTypeString(BinarySerializer.Default);
        }
    }
}
