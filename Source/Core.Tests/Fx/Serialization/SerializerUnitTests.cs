namespace Fx.Serialization
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ISerializer"/> abstraction
    /// </summary>
    /// <threadsafety static="true"/>
    internal static class SerializerUnitTests
    {
        /// <summary>
        /// Serializes and deserializes an object to bytes and asserts that they are equivalent
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="System.Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void SerializeBytes(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            var toSerialize = new SerializableType("this is a test");
            var serialized = serializer.ToBytes(toSerialize);
            var deserialized = serializer.FromBytes<SerializableType>(serialized);

            Assert.IsTrue(toSerialize.Equals(deserialized));
        }

        /// <summary>
        /// Serializes and deserializes an object to a stream and asserts that they are equivalent
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="System.Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void SerializeStream(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            var toSerialize = new SerializableType("this is a test");
            var serialized = serializer.ToStream(toSerialize);
            var deserialized = serializer.FromStream<SerializableType>(serialized);

            Assert.IsTrue(toSerialize.Equals(deserialized));
        }

        /// <summary>
        /// Serializes and deserializes an object to a string and asserts that they are equivalent
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="System.Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void SerializeString(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            var toSerialize = new SerializableType("this is a test");
            var serialized = serializer.ToString(toSerialize);
            var deserialized = serializer.FromString<SerializableType>(serialized);

            Assert.IsTrue(toSerialize.Equals(deserialized));
        }

        /// <summary>
        /// Serializes and deserializes a string and asserts that they are equivalent
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> to test</param>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="serializer"/> is null</exception>
        /// <remarks>This method will throw a <see cref="System.Exception"/> if <paramref name="serializer"/> does not pass the test</remarks>
        public static void StringSerialization(ISerializer serializer)
        {
            Ensure.NotNull(serializer, nameof(serializer));

            var toSerialize = "this is a test";

            var serializedString = serializer.ToString(toSerialize);
            var deserializedString = serializer.FromString<string>(serializedString);
            Assert.IsTrue(toSerialize.Equals(deserializedString));

            var serializedBytes = serializer.ToBytes(toSerialize);
            var deserializedBytes = serializer.FromBytes<string>(serializedBytes);
            Assert.IsTrue(toSerialize.Equals(deserializedBytes));

            var serializedStream = serializer.ToStream(toSerialize);
            var deserializedStream = serializer.FromStream<string>(serializedStream);
            Assert.IsTrue(toSerialize.Equals(deserializedStream));
        }
    }
}
