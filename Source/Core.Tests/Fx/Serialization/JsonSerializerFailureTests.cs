#if NET40
namespace Fx.Serialization
{
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="JsonSerializer"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class JsonSerializerFailureTests
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
            SerializerFailureTests.SerializeNullBytes(JsonSerializer.Default);
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
            SerializerFailureTests.SerializeNullString(JsonSerializer.Default);
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
            SerializerFailureTests.SerializeNullStream(JsonSerializer.Default);
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
            SerializerFailureTests.DeserializeNullBytes(JsonSerializer.Default);
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
            SerializerFailureTests.DeserializeNullString(JsonSerializer.Default);
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
            SerializerFailureTests.DeserializeNullStream(JsonSerializer.Default);
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
            SerializerFailureTests.SerializeMalformedTypeStream(JsonSerializer.Default);
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
            SerializerFailureTests.SerializeMalformedTypeBytes(JsonSerializer.Default);
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
            SerializerFailureTests.SerializeMalformedTypeString(JsonSerializer.Default);
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
            SerializerFailureTests.DeserializeMalformedTypeStream(JsonSerializer.Default);
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
            SerializerFailureTests.DeserializeMalformedTypeBytes(JsonSerializer.Default);
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
            SerializerFailureTests.DeserializeMalformedTypeString(JsonSerializer.Default);
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
            SerializerFailureTests.SerializeNullBytes(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeNullString(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeNullStream(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeNullBytes(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeNullString(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeNullStream(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeMalformedTypeStream(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeMalformedTypeBytes(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.SerializeMalformedTypeString(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeMalformedTypeStream(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeMalformedTypeBytes(JsonSerializer.Create(Encoding.ASCII));
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
            SerializerFailureTests.DeserializeMalformedTypeString(JsonSerializer.Create(Encoding.ASCII));
        }

        #endregion
    }
}
#endif