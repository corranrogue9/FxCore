namespace Fx.Logging
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="MemoryEvent"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class MemoryEventUnitTests
    {
        /// <summary>
        /// Serializes a DetailEvent
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Serializes a DetailEvent")]
        [TestMethod]
        public void DetailEventSerialization()
        {
            var @event = new MemoryEvent.DetailEvent(100, "this is a message");

            var serialized = Serialize(@event);
            var deserialized = Deserialize<MemoryEvent.DetailEvent>(serialized);

            Assert.AreEqual(@event.Id, deserialized.Id);
            Assert.AreEqual(@event.Message, deserialized.Message);
        }

        /// <summary>
        /// Serializes a InformationEvent
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Serializes a InformationEvent")]
        [TestMethod]
        public void InformationEventSerialization()
        {
            var @event = new MemoryEvent.InformationEvent(100, "this is a message");

            var serialized = Serialize(@event);
            var deserialized = Deserialize<MemoryEvent.InformationEvent>(serialized);

            Assert.AreEqual(@event.Id, deserialized.Id);
            Assert.AreEqual(@event.Message, deserialized.Message);
        }

        /// <summary>
        /// Serializes a WarningEvent
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Serializes a WarningEvent")]
        [TestMethod]
        public void WarningEventSerialization()
        {
            var @event = new MemoryEvent.WarningEvent(100, "this is a message");

            var serialized = Serialize(@event);
            var deserialized = Deserialize<MemoryEvent.WarningEvent>(serialized);

            Assert.AreEqual(@event.Id, deserialized.Id);
            Assert.AreEqual(@event.Message, deserialized.Message);
        }

        /// <summary>
        /// Serializes a ErrorEvent
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Serializes a ErrorEvent")]
        [TestMethod]
        public void ErrorEventSerialization()
        {
            var @event = new MemoryEvent.ErrorEvent(100, "this is a message");

            var serialized = Serialize(@event);
            var deserialized = Deserialize<MemoryEvent.ErrorEvent>(serialized);

            Assert.AreEqual(@event.Id, deserialized.Id);
            Assert.AreEqual(@event.Message, deserialized.Message);
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
