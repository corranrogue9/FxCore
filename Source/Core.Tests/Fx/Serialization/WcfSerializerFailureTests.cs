namespace Fx.Serialization
{
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="WcfSerializer"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class WcfSerializerFailureTests
    {
        #region Default

        /// <summary>
        /// Attempts to serialize a null object to bytes
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a null object to bytes")]
        [Priority(1)]
        [TestMethod]
        public void SerializeNullBytes()
        {
            SerializerFailureTests.SerializeNullBytes(WcfSerializer.Default);
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
            SerializerFailureTests.SerializeNullString(WcfSerializer.Default);
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
            SerializerFailureTests.SerializeNullStream(WcfSerializer.Default);
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
            SerializerFailureTests.DeserializeNullBytes(WcfSerializer.Default);
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
            SerializerFailureTests.DeserializeNullString(WcfSerializer.Default);
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
            SerializerFailureTests.DeserializeNullStream(WcfSerializer.Default);
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
            SerializerFailureTests.SerializeMalformedTypeStream(WcfSerializer.Default);
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
            SerializerFailureTests.SerializeMalformedTypeBytes(WcfSerializer.Default);
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
            SerializerFailureTests.SerializeMalformedTypeString(WcfSerializer.Default);
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
            SerializerFailureTests.DeserializeMalformedTypeStream(WcfSerializer.Default);
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
            SerializerFailureTests.DeserializeMalformedTypeBytes(WcfSerializer.Default);
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
            SerializerFailureTests.DeserializeMalformedTypeString(WcfSerializer.Default);
        }

        #endregion

        #region ASCII

        /// <summary>
        /// Attempts to serialize a null object to bytes
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a null object to bytes")]
        [Priority(1)]
        [TestMethod]
        public void AsciiSerializeNullBytes()
        {
            SerializerFailureTests.SerializeNullBytes(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to serialize a null object to a string
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a null object to a string")]
        [Priority(1)]
        [TestMethod]
        public void AsciiSerializeNullString()
        {
            SerializerFailureTests.SerializeNullString(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to serialize a null object to a stream
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a null object to a stream")]
        [Priority(1)]
        [TestMethod]
        public void AsciiSerializeNullStream()
        {
            SerializerFailureTests.SerializeNullStream(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to deserialize null bytes
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize null bytes")]
        [Priority(1)]
        [TestMethod]
        public void AsciiDeserializeNullBytes()
        {
            SerializerFailureTests.DeserializeNullBytes(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to deserialize a null string
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize a null string")]
        [Priority(1)]
        [TestMethod]
        public void AsciiDeserializeNullString()
        {
            SerializerFailureTests.DeserializeNullString(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to deserialize a null stream
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize a null stream")]
        [Priority(1)]
        [TestMethod]
        public void AsciiDeserializeNullStream()
        {
            SerializerFailureTests.DeserializeNullStream(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to serialize a non-serializable object to a stream
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a non-serializable object to a stream")]
        [Priority(1)]
        [TestMethod]
        public void AsciiSerializeMalformedTypeStream()
        {
            SerializerFailureTests.SerializeMalformedTypeStream(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to serialize a non-serializable object to bytes
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a non-serializable object to bytes")]
        [Priority(1)]
        [TestMethod]
        public void AsciiSerializeMalformedTypeBytes()
        {
            SerializerFailureTests.SerializeMalformedTypeBytes(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to serialize a non-serializable object to a string
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to serialize a non-serializable object to a string")]
        [Priority(1)]
        [TestMethod]
        public void AsciiSerializeMalformedTypeString()
        {
            SerializerFailureTests.SerializeMalformedTypeString(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to deserialize a malformed stream
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize a malformed stream")]
        [Priority(1)]
        [TestMethod]
        public void AsciiDeserializeMalformedTypeStream()
        {
            SerializerFailureTests.DeserializeMalformedTypeStream(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to deserialize malformed bytes
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize malformed bytes")]
        [Priority(1)]
        [TestMethod]
        public void AsciiDeserializeMalformedTypeBytes()
        {
            SerializerFailureTests.DeserializeMalformedTypeBytes(WcfSerializer.Create(Encoding.ASCII));
        }

        /// <summary>
        /// Attempts to deserialize a malformed string
        /// </summary>
        [TestCategory("Failure")]
        [Description("Attempts to deserialize a malformed string")]
        [Priority(1)]
        [TestMethod]
        public void AsciiDeserializeMalformedTypeString()
        {
            SerializerFailureTests.DeserializeMalformedTypeString(WcfSerializer.Create(Encoding.ASCII));
        }

        #endregion
    }
}
