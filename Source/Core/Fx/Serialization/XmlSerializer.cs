namespace Fx.Serialization
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// A <see cref="ISerializer"/> implementation that leverages the XML standard to serialize and deserialize objects
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class XmlSerializer : ISerializer
    {
        /// <summary>
        /// The singleton instance of the <see cref="XmlSerializer"/> that uses the default UTF8 encoding
        /// </summary>
        private static readonly XmlSerializer Singleton = new XmlSerializer(Encoding.UTF8);

        /// <summary>
        /// The <see cref="Encoding"/> that should be used when this <see cref="ISerializer"/> interacts with <see cref="string"/>s
        /// </summary>
        private readonly Encoding encoding;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerializer"/> class
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding"/> that should be used when the resulting <see cref="XmlSerializer"/> interacts with <see cref="string"/>s</param>
        private XmlSerializer(Encoding encoding)
        {
            this.encoding = encoding;
        }

        /// <summary>
        /// Gets the singleton instance of the <see cref="XmlSerializer"/> that uses the UTF8 encoding
        /// </summary>
        public static XmlSerializer Default
        {
            get
            {
                return Singleton;
            }
        }
        
        /// <summary>
        /// Generates an instance of the <see cref="XmlSerializer"/> that uses the <see cref="Encoding"/> <paramref name="encoding"/> when interacting with <see cref="string"/>s
        /// </summary>
        /// <param name="encoding">The <see cref="Encoding"/> to use when the resulting <see cref="XmlSerializer"/> interacts with <see cref="string"/>s</param>
        /// <returns>An instance of the <see cref="XmlSerializer"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="encoding"/> is null</exception>
        public static XmlSerializer Create(Encoding encoding)
        {
            Ensure.NotNull(encoding, nameof(encoding));

            if (encoding == Default.encoding)
            {
                return Default;
            }

            return new XmlSerializer(encoding);
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

            return GenericXmlSerializer<T>.Default.FromBytes(toDeserialize);
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

            return GenericXmlSerializer<T>.Default.FromStream(toDeserialize);
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

            return GenericXmlSerializer<T>.Default.FromString(toDeserialize, this.encoding.Clone() as Encoding);
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

            return GenericXmlSerializer<T>.Default.ToBytes(toSerialize);
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

            return GenericXmlSerializer<T>.Default.ToStream(toSerialize);
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

            return GenericXmlSerializer<T>.Default.ToString(toSerialize, this.encoding.Clone() as Encoding);
        }

        /// <summary>
        /// A generic implementation of the XML serializer
        /// </summary>
        /// <typeparam name="T">The type of objects that this <see cref="GenericXmlSerializer{T}"/> can serialize</typeparam>
        /// <threadsafety static="true" instance="true"/>
        private sealed class GenericXmlSerializer<T>
        {
            /// <summary>
            /// A singleton instance of the <see cref="GenericXmlSerializer{T}"/>
            /// </summary>
            private static readonly GenericXmlSerializer<T> Singleton = new GenericXmlSerializer<T>();

            /// <summary>
            /// The <see cref="System.Xml.Serialization.XmlSerializer"/> that should be used when actually performing serializations for the <typeparamref name="T"/> type
            /// </summary>
            private readonly System.Xml.Serialization.XmlSerializer serializer;

            /// <summary>
            /// Prevents a default instance of the <see cref="GenericXmlSerializer{T}"/> class from being created
            /// </summary>
            private GenericXmlSerializer()
            {
                this.serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            }

            /// <summary>
            /// Gets a singleton instance of the <see cref="GenericXmlSerializer{T}"/>
            /// </summary>
            public static GenericXmlSerializer<T> Default
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
            /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred during deserialization of <paramref name="toDeserialize"/></exception>
            public T FromBytes(byte[] toDeserialize)
            {
                using (var stream = new ChunkedMemoryStream(toDeserialize, true))
                {
                    return this.FromStream(stream);
                }
            }

            /// <summary>
            /// Deserializes <paramref name="toDeserialize"/> into the object that it represents
            /// </summary>
            /// <param name="toDeserialize">The <see cref="Stream"/> to deserialize</param>
            /// <returns>The object represented by <paramref name="toDeserialize"/></returns>
            /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred during deserialization of <paramref name="toDeserialize"/></exception>
            public T FromStream(Stream toDeserialize)
            {
                try
                {
                    return (T)this.serializer.Deserialize(toDeserialize);
                }
                catch (InvalidOperationException e)
                {
                    throw new SerializationException(Strings.XmlSerializerDeserialization, e);
                }
            }

            /// <summary>
            /// Deserializes <paramref name="toDeserialize"/> into the object that it represents
            /// </summary>
            /// <param name="toDeserialize">The <see cref="string"/> to deserialize</param>
            /// <param name="encoding">The <see cref="Encoding"/> to use to interact with <paramref name="toDeserialize"/></param>
            /// <returns>The object represented by <paramref name="toDeserialize"/></returns>
            /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred during deserialization of <paramref name="toDeserialize"/></exception>
            public T FromString(string toDeserialize, Encoding encoding)
            {
                return this.FromBytes(encoding.GetBytes(toDeserialize));
            }

            /// <summary>
            /// Serializes <paramref name="toSerialize"/> into its <see cref="T:byte[]"/> representation
            /// </summary>
            /// <param name="toSerialize">The object to serialize</param>
            /// <returns>The <see cref="T:byte[]"/> representation of <paramref name="toSerialize"/></returns>
            /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while serializing <paramref name="toSerialize"/></exception>
            public byte[] ToBytes(T toSerialize)
            {
                using (var stream = this.ToStreamImpl(toSerialize))
                {
                    return stream.ToArray();
                }
            }

            /// <summary>
            /// Serializes <paramref name="toSerialize"/> into its <see cref="Stream"/> representation
            /// </summary>
            /// <param name="toSerialize">The object to serialize</param>
            /// <returns>The <see cref="Stream"/> representation of <paramref name="toSerialize"/></returns>
            /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while serializing <paramref name="toSerialize"/></exception>
            public Stream ToStream(T toSerialize)
            {
                return this.ToStreamImpl(toSerialize);
            }

            /// <summary>
            /// Serializes <paramref name="toSerialize"/> into its <see cref="string"/> representation
            /// </summary>
            /// <param name="toSerialize">The object to serialize</param>
            /// <param name="encoding">The <see cref="Encoding"/> to use when generating the resulting <see cref="string"/> representation</param>
            /// <returns>The <see cref="string"/> representation of <paramref name="toSerialize"/></returns>
            /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while serializing <paramref name="toSerialize"/></exception>
            public string ToString(T toSerialize, Encoding encoding)
            {
                return encoding.GetString(this.ToBytes(toSerialize));
            }

            /// <summary>
            /// Serializes <paramref name="toSerialize"/> into its <see cref="ChunkedMemoryStream"/> representation
            /// </summary>
            /// <param name="toSerialize">The object to serialize</param>
            /// <returns>The <see cref="ChunkedMemoryStream"/> representation of <paramref name="toSerialize"/></returns>
            /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while serializing <paramref name="toSerialize"/></exception>
            private ChunkedMemoryStream ToStreamImpl(T toSerialize)
            {
                ChunkedMemoryStream stream = null;
                try
                {
                    stream = new ChunkedMemoryStream();
                    try
                    { 
                        this.serializer.Serialize(stream, toSerialize);
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new SerializationException(Strings.XmlSerializerSerialization, e);
                    }

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
}
