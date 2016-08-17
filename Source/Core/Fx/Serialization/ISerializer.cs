namespace Fx.Serialization
{
    using System.IO;

    /// <summary>
    /// Serializes objects into different representations and deserializes those representations into objects
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes <paramref name="toSerialize"/> into its <see cref="string"/> representation
        /// </summary>
        /// <param name="toSerialize">The object to serialize</param>
        /// <returns>The <see cref="string"/> representation of <paramref name="toSerialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toSerialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occured while serializing <paramref name="toSerialize"/></exception>
        /// <typeparam name="T">The type of the object be serialized</typeparam>
        string ToString<T>(T toSerialize);

        /// <summary>
        /// Serializes <paramref name="toSerialize"/> into its <see cref="T:byte[]"/> representation
        /// </summary>
        /// <param name="toSerialize">The object to serialize</param>
        /// <returns>The <see cref="T:byte[]"/> representation of <paramref name="toSerialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toSerialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occured while serializing <paramref name="toSerialize"/></exception>
        /// <typeparam name="T">The type of the object be serialized</typeparam>
        byte[] ToBytes<T>(T toSerialize);

        /// <summary>
        /// Serializes <paramref name="toSerialize"/> into its <see cref="Stream"/> representation
        /// </summary>
        /// <param name="toSerialize">The object to serialize</param>
        /// <returns>The <see cref="Stream"/> representation of <paramref name="toSerialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toSerialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occured while serializing <paramref name="toSerialize"/></exception>
        /// <typeparam name="T">The type of the object be serialized</typeparam>
        Stream ToStream<T>(T toSerialize);

        /// <summary>
        /// Deserializes <paramref name="toDeserialize"/> into the object that it represents
        /// </summary>
        /// <param name="toDeserialize">The <see cref="string"/> to deserialize</param>
        /// <returns>The object represented by <paramref name="toDeserialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toDeserialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while deserializing <paramref name="toDeserialize"/></exception>
        /// <typeparam name="T">The type of the object be deserialized</typeparam>
        T FromString<T>(string toDeserialize);

        /// <summary>
        /// Deserializes <paramref name="toDeserialize"/> into the object that it represents
        /// </summary>
        /// <param name="toDeserialize">The <see cref="T:byte[]"/> to deserialize</param>
        /// <returns>The object represented by <paramref name="toDeserialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toDeserialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while deserializing <paramref name="toDeserialize"/></exception>
        /// <typeparam name="T">The type of the object be deserialized</typeparam>
        T FromBytes<T>(byte[] toDeserialize);

        /// <summary>
        /// Deserializes <paramref name="toDeserialize"/> into the object that it represents
        /// </summary>
        /// <param name="toDeserialize">The <see cref="Stream"/> to deserialize</param>
        /// <returns>The object represented by <paramref name="toDeserialize"/></returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="toDeserialize"/> is null</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown if an error occurred while deserializing <paramref name="toDeserialize"/></exception>
        /// <typeparam name="T">The type of the object be deserialized</typeparam>
        T FromStream<T>(Stream toDeserialize);
    }
}
