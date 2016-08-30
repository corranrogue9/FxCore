namespace Fx.Serialization
{
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="XmlSerializer"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class XmlSerializerFailureTests
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
            SerializerFailureTests.SerializeNullBytes(XmlSerializer.Default);
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
            SerializerFailureTests.SerializeNullString(XmlSerializer.Default);
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
            SerializerFailureTests.SerializeNullStream(XmlSerializer.Default);
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
            SerializerFailureTests.DeserializeNullBytes(XmlSerializer.Default);
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
            SerializerFailureTests.DeserializeNullString(XmlSerializer.Default);
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
            SerializerFailureTests.DeserializeNullStream(XmlSerializer.Default);
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
            SerializerFailureTests.SerializeMalformedTypeStream(XmlSerializer.Default);
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
            SerializerFailureTests.SerializeMalformedTypeBytes(XmlSerializer.Default);
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
            SerializerFailureTests.SerializeMalformedTypeString(XmlSerializer.Default);
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
            SerializerFailureTests.DeserializeMalformedTypeStream(XmlSerializer.Default);
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
            SerializerFailureTests.DeserializeMalformedTypeBytes(XmlSerializer.Default);
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
            SerializerFailureTests.DeserializeMalformedTypeString(XmlSerializer.Default);
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
            SerializerFailureTests.SerializeNullBytes(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeNullString(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeNullStream(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeNullBytes(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeNullString(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeNullStream(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeMalformedTypeStream(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeMalformedTypeBytes(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeMalformedTypeString(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeMalformedTypeStream(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeMalformedTypeBytes(XmlSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeMalformedTypeString(XmlSerializer.Create(Encoding.ASCII));
        }

        #endregion
    }
}
