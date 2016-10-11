namespace System.Diagnostics
{
    using System.Linq;

    using Fx.Serialization;

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

            var serialized = WcfSerializer.Default.ToString(@event);
            var deserialized = WcfSerializer.Default.FromString<TraceEvent.WriteEvent>(serialized);

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

            var serialized = WcfSerializer.Default.ToString(@event);
            var deserialized = WcfSerializer.Default.FromString<TraceEvent.MessageEvent>(serialized);

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

            var serialized = WcfSerializer.Default.ToString(@event);
            var deserialized = WcfSerializer.Default.FromString<TraceEvent.DataEvent>(serialized);

            Assert.AreEqual(@event.CallStack, deserialized.CallStack);
            CollectionAssert.AreEqual(@event.Data.ToList(), deserialized.Data.ToList());
            Assert.AreEqual(@event.DateTime, deserialized.DateTime);
            Assert.AreEqual(@event.EventType, deserialized.EventType);
            Assert.AreEqual(@event.Id, deserialized.Id);
            CollectionAssert.AreEqual(@event.LogicalOperationStack, deserialized.LogicalOperationStack);
            Assert.AreEqual(@event.ProcessId, deserialized.ProcessId);
            Assert.AreEqual(@event.Source, deserialized.Source);
            Assert.AreEqual(@event.ThreadId, deserialized.ThreadId);
            Assert.AreEqual(@event.Timestamp, deserialized.Timestamp);
        }
    }
}
