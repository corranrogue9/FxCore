namespace Fx.Logging
{
    using Fx.Serialization;

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

            var serialized = WcfSerializer.Default.ToString(identifier);
            var deserialized = WcfSerializer.Default.FromString<EventIdentifier>(serialized);

            Assert.AreEqual(identifier.Id, deserialized.Id);
            Assert.AreEqual(identifier.MessageFormat, deserialized.MessageFormat);
        }
    }
}
