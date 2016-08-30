namespace Fx.Serialization
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    /// <summary>
    /// A <see cref="ISerializer"/> implementation that leverages the <see cref="BinaryFormatter"/> to serialize and deserialize objects
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class BinarySerializer : ISerializer
    {
        /// <summary>
        /// The singleton instance of the <see cref="BinarySerializer"/>
        /// </summary>
        private static readonly BinarySerializer Singleton = new BinarySerializer();
        
        /// <summary>
        /// Prevents a default instance of the <see cref="BinarySerializer"/> class from being created
        /// </summary>
        private BinarySerializer()
        {
        }

        /// <summary>
        /// Gets the singleton instance of the <see cref="BinarySerializer"/> that uses the UTF8 encoding
        /// </summary>
        public static BinarySerializer Default
        {
            get
            {
                return Singleton;
            }
        }
        
        /// <summary>
        /// Deserializes <paramref name="toDeserialize"/> into the object that it represents
        /// </summary>
        /// <param name="toDeserialize">The <see cref="T:byte[]"/> to deserialize</param>
        /// <returns>The object represented by <paramref name="toDeserialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toDeserialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while deserializing <paramref name="toDeserialize"/></exception>
        /// <typeparam name="T">The type of the object be deserialized</typeparam>
        public T FromBytes<T>(byte[] toDeserialize)
        {
            Ensure.NotNull(toDeserialize, nameof(toDeserialize));

            using (var stream = new ChunkedMemoryStream(toDeserialize, true))
            {
                return this.FromStream<T>(stream);
            }
        }

        /// <summary>
        /// Deserializes <paramref name="toDeserialize"/> into the object that it represents
        /// </summary>
        /// <param name="toDeserialize">The <see cref="Stream"/> to deserialize</param>
        /// <returns>The object represented by <paramref name="toDeserialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toDeserialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while deserializing <paramref name="toDeserialize"/></exception>
        /// <typeparam name="T">The type of the object be deserialized</typeparam>
        public T FromStream<T>(Stream toDeserialize)
        {
            Ensure.NotNull(toDeserialize, nameof(toDeserialize));

            var serializer = new BinaryFormatter();
            return (T)serializer.Deserialize(toDeserialize);
        }

        /// <summary>
        /// Deserializes <paramref name="toDeserialize"/> into the object that it represents
        /// </summary>
        /// <param name="toDeserialize">The <see cref="string"/> to deserialize</param>
        /// <returns>The object represented by <paramref name="toDeserialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toDeserialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while deserializing <paramref name="toDeserialize"/></exception>
        /// <typeparam name="T">The type of the object be deserialized</typeparam>
        public T FromString<T>(string toDeserialize)
        {
            Ensure.NotNull(toDeserialize, nameof(toDeserialize));

            return this.FromBytes<T>((Encoding.ASCII.Clone() as Encoding).GetBytes(toDeserialize));
        }

        /// <summary>
        /// Serializes <paramref name="toSerialize"/> into its <see cref="T:byte[]"/> representation
        /// </summary>
        /// <param name="toSerialize">The object to serialize</param>
        /// <returns>The <see cref="T:byte[]"/> representation of <paramref name="toSerialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toSerialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occured while serializing <paramref name="toSerialize"/></exception>
        /// <typeparam name="T">The type of the object be serialized</typeparam>
        public byte[] ToBytes<T>(T toSerialize)
        {
            Ensure.NotNull(toSerialize, nameof(toSerialize));

            using (var stream = ToStreamImpl(toSerialize))
            {
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Serializes <paramref name="toSerialize"/> into its <see cref="Stream"/> representation
        /// </summary>
        /// <param name="toSerialize">The object to serialize</param>
        /// <returns>The <see cref="Stream"/> representation of <paramref name="toSerialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toSerialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occured while serializing <paramref name="toSerialize"/></exception>
        /// <typeparam name="T">The type of the object be serialized</typeparam>
        public Stream ToStream<T>(T toSerialize)
        {
            Ensure.NotNull(toSerialize, nameof(toSerialize));

            return ToStreamImpl(toSerialize);
        }

        /// <summary>
        /// Serializes <paramref name="toSerialize"/> into its <see cref="string"/> representation
        /// </summary>
        /// <param name="toSerialize">The object to serialize</param>
        /// <returns>The <see cref="string"/> representation of <paramref name="toSerialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toSerialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occured while serializing <paramref name="toSerialize"/></exception>
        /// <typeparam name="T">The type of the object be serialized</typeparam>
        public string ToString<T>(T toSerialize)
        {
            Ensure.NotNull(toSerialize, nameof(toSerialize));

            var bytes = this.ToBytes(toSerialize);
            return (Encoding.ASCII.Clone() as Encoding).GetString(bytes);
        }

        /// <summary>
        /// Serializes <paramref name="toSerialize"/> into its <see cref="ChunkedMemoryStream"/> representation
        /// </summary>
        /// <param name="toSerialize">The object to serialize</param>
        /// <returns>The <see cref="ChunkedMemoryStream"/> representation of <paramref name="toSerialize"/></returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while serializing <paramref name="toSerialize"/></exception>
        /// <typeparam name="T">The type of the object be serialized</typeparam>
        private static ChunkedMemoryStream ToStreamImpl<T>(T toSerialize)
        {
            ChunkedMemoryStream stream = null;
            try
            {
                stream = new ChunkedMemoryStream();
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, toSerialize);
                stream.Position = 0;
                return stream;
            }
            catch
            {
                if (stream != null)
                {
                    stream.Dispose();
                }

                throw;
            }
        }
    }
}
