namespace Fx.Logging
{
    using Fx.Serialization;

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

            var serialized = WcfSerializer.Default.ToString(@event);
            var deserialized = WcfSerializer.Default.FromString<MemoryEvent.DetailEvent>(serialized);

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

            var serialized = WcfSerializer.Default.ToString(@event);
            var deserialized = WcfSerializer.Default.FromString<MemoryEvent.InformationEvent>(serialized);

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

            var serialized = WcfSerializer.Default.ToString(@event);
            var deserialized = WcfSerializer.Default.FromString<MemoryEvent.WarningEvent>(serialized);

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

            var serialized = WcfSerializer.Default.ToString(@event);
            var deserialized = WcfSerializer.Default.FromString<MemoryEvent.ErrorEvent>(serialized);

            Assert.AreEqual(@event.Id, deserialized.Id);
            Assert.AreEqual(@event.Message, deserialized.Message);
        }
    }
}
