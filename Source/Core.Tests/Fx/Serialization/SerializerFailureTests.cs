namespace Fx.Serialization
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ISerializer"/> abstraction
    /// </summary>
    /// <threadsafety static="true"/>
    internal static class SerializerFailureTests
    {
        /// <summary>
        /// Attempts to serialize a null object to bytes
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void SerializeNullBytes(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<ArgumentNullException>(() => serializer.ToBytes<SerializableType>(null));
        }

        /// <summary>
        /// Attempts to serialize a null object to a string
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void SerializeNullString(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<ArgumentNullException>(() => serializer.ToString<SerializableType>(null));
        }

        /// <summary>
        /// Attempts to serialize a null object to a stream
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void SerializeNullStream(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<ArgumentNullException>(() => serializer.ToStream<SerializableType>(null));
        }

        /// <summary>
        /// Attempts to deserialize null bytes
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void DeserializeNullBytes(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<ArgumentNullException>(() => serializer.FromBytes<SerializableType>(null));
        }

        /// <summary>
        /// Attempts to deserialize a null string
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void DeserializeNullString(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<ArgumentNullException>(() => serializer.FromString<SerializableType>(null));
        }

        /// <summary>
        /// Attempts to deserialize a null stream
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void DeserializeNullStream(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<ArgumentNullException>(() => serializer.FromStream<SerializableType>(null));
        }

        /// <summary>
        /// Attempts to serialize a non-serializable object to a stream
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void SerializeMalformedTypeStream(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<SerializationException>(() => serializer.ToStream<MalformedSerializableType>(MalformedSerializableType.Instance));
        }

        /// <summary>
        /// Attempts to serialize a non-serializable object to bytes
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void SerializeMalformedTypeBytes(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<SerializationException>(() => serializer.ToBytes<MalformedSerializableType>(MalformedSerializableType.Instance));
        }

        /// <summary>
        /// Attempts to serialize a non-serializable object to a string
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void SerializeMalformedTypeString(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<SerializationException>(() => serializer.ToString<MalformedSerializableType>(MalformedSerializableType.Instance));
        }

        /// <summary>
        /// Attempts to deserialize a malformed stream
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void DeserializeMalformedTypeStream(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            using (var stream = new MemoryStream())
            {
                ExceptionAssert.Throws<SerializationException>(() => serializer.FromStream<SerializableType>(stream));
            }
        }

        /// <summary>
        /// Attempts to deserialize malformed bytes
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void DeserializeMalformedTypeBytes(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<SerializationException>(() => serializer.FromBytes<SerializableType>(new byte[0]));
        }

        /// <summary>
        /// Attempts to deserialize a malformed string
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void DeserializeMalformedTypeString(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            ExceptionAssert.Throws<SerializationException>(() => serializer.FromString<SerializableType>(string.Empty));
        }
    }
}
