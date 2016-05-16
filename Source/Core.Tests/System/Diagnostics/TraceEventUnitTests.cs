namespace System.Diagnostics
{
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="TraceEvent"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class TraceEventUnitTests
    {
        /// <summary>
        /// Serializes a WriteEvent
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Serializes a WriteEvent")]
        [TestMethod]
        public void WriteEventSerialization()
        {
            var @event = new TraceEvent.WriteEvent("this is a message");

            var serialized = Serialize(@event);
            var deserialized = Deserialize<TraceEvent.WriteEvent>(serialized);

            Assert.AreEqual(@event.Message, deserialized.Message);
        }

        /// <summary>
        /// Serializes a MessageEvent
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Serializes a MessageEvent")]
        [TestMethod]
        public void MessageEventSerialization()
        {
            var @event = new TraceEvent.MessageEvent(new TraceEventCache(), "the source", TraceEventType.Information, 100, "this is a message");

            var serialized = Serialize(@event);
            var deserialized = Deserialize<TraceEvent.MessageEvent>(serialized);

            Assert.AreEqual(@event.CallStack, deserialized.CallStack);
            Assert.AreEqual(@event.DateTime, deserialized.DateTime);
            Assert.AreEqual(@event.EventType, deserialized.EventType);
            Assert.AreEqual(@event.Id, deserialized.Id);
            CollectionAssert.AreEqual(@event.LogicalOperationStack, deserialized.LogicalOperationStack);
            Assert.AreEqual(@event.Message, deserialized.Message);
            Assert.AreEqual(@event.ProcessId, deserialized.ProcessId);
            Assert.AreEqual(@event.Source, deserialized.Source);
            Assert.AreEqual(@event.ThreadId, deserialized.ThreadId);
            Assert.AreEqual(@event.Timestamp, deserialized.Timestamp);
        }

        /// <summary>
        /// Serializes a DataEvent
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Serializes a DataEvent")]
        [TestMethod]
        public void DataEventSerialization()
        {
            var @event = new TraceEvent.DataEvent(new TraceEventCache(), "the source", TraceEventType.Information, 100, new[] { "asdf" });

            var serialized = Serialize(@event);
            var deserialized = Deserialize<TraceEvent.DataEvent>(serialized);

            Assert.AreEqual(@event.CallStack, deserialized.CallStack);
            CollectionAssert.AreEqual(Enumerable.ToList(@event.Data), Enumerable.ToList(deserialized.Data));
            Assert.AreEqual(@event.DateTime, deserialized.DateTime);
            Assert.AreEqual(@event.EventType, deserialized.EventType);
            Assert.AreEqual(@event.Id, deserialized.Id);
            CollectionAssert.AreEqual(@event.LogicalOperationStack, deserialized.LogicalOperationStack);
            Assert.AreEqual(@event.ProcessId, deserialized.ProcessId);
            Assert.AreEqual(@event.Source, deserialized.Source);
            Assert.AreEqual(@event.ThreadId, deserialized.ThreadId);
            Assert.AreEqual(@event.Timestamp, deserialized.Timestamp);
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
