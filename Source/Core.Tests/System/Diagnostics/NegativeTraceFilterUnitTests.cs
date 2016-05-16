namespace System.Diagnostics
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="NegativeTraceFilter"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class NegativeTraceFilterUnitTests
    {
        /// <summary>
        /// Ensures that the NegativeTraceFilter filters all events
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the NegativeTraceFilter filters all events")]
        [TestMethod]
        public void FilterEvents()
        {
            Assert.IsFalse(NegativeTraceFilter.Instance.ShouldTrace(null, null, TraceEventType.Critical, 0, null, null, null, null));
        }

        /// <summary>
        /// Ensures that the NegativeTraceFilter singleton always returns the same instance
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that the NegativeTraceFilter singleton always returns the same instance")]
        [TestMethod]
        public void SingletonInstance()
        {
            Assert.AreEqual(NegativeTraceFilter.Instance, NegativeTraceFilter.Instance);
        }
    }
}
