namespace Fx.Logging
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="EventIdentifier"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class EventIdentifierUnitTests
    {
        /// <summary>
        /// Serializes an EventIdentifier
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Serializes an EventIdentifier")]
        [TestMethod]
        public void EventIdentifierSerialization()
        {
            var identifier = new EventIdentifier(100, "this is a {0}");

            var serialized = Serialize(identifier);
            var deserialized = Deserialize<EventIdentifier>(serialized);

            Assert.AreEqual(identifier.Id, deserialized.Id);
            Assert.AreEqual(identifier.MessageFormat, deserialized.MessageFormat);
        }

        /// <summary>
        /// Serializes <paramref name="toSerialize"/> into its WCF representation
        /// </summary>
        /// <param name="toSerialize">The <see cref="object"/> to serialize</param>
        /// <returns>The WCF representation of <paramref name="toSerialize"/></returns>
        private static string Serialize(object toSerialize)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractSerializer(toSerialize.GetType());
                serializer.WriteObject(stream, toSerialize);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Deserializes <paramref name="toDeserialize"/> into the <see cref="object"/> that it represents
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="object"/> represented by <paramref name="toDeserialize"/></typeparam>
        /// <param name="toDeserialize">The WCF representation of an object</param>
        /// <returns>The object represented by <paramref name="toDeserialize"/></returns>
        private static T Deserialize<T>(string toDeserialize)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(toDeserialize)))
            {
                var serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}
