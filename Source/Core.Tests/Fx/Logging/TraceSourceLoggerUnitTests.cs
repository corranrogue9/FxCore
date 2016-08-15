#if NET40
namespace Fx.Logging
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="TraceSourceLogger"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class TraceSourceLoggerUnitTests
    {
        /// <summary>
        /// Emits a detail event to a trace source
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits a detail event to a trace source")]
        [Priority(1)]
        [TestMethod]
        public void EmitDetail()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);
            var logger = new TraceSourceLogger(traceSource);
            logger.EmitDetail(100, "this is a message");
            logger.EmitDetail(101, "this is another message");
            logger.EmitDetail(102, "this is yet another message");

            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(0), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Verbose, (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(100, (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is a message", (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).Message);
            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(1), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Verbose, (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(101, (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is another message", (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).Message);
            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(2), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Verbose, (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(102, (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is yet another message", (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).Message);
        }

        /// <summary>
        /// Emits an information event to a trace source
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits an information event to a trace source")]
        [Priority(1)]
        [TestMethod]
        public void EmitInformation()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);
            var logger = new TraceSourceLogger(traceSource);
            logger.EmitInformation(100, "this is a message");
            logger.EmitInformation(101, "this is another message");
            logger.EmitInformation(102, "this is yet another message");

            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(0), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Information, (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(100, (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is a message", (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).Message);
            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(1), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Information, (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(101, (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is another message", (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).Message);
            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(2), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Information, (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(102, (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is yet another message", (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).Message);
        }

        /// <summary>
        /// Emits a warning event to a trace source
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits a warning event to a trace source")]
        [Priority(1)]
        [TestMethod]
        public void EmitWarning()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);
            var logger = new TraceSourceLogger(traceSource);
            logger.EmitWarning(100, "this is a message");
            logger.EmitWarning(101, "this is another message");
            logger.EmitWarning(102, "this is yet another message");

            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(0), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Warning, (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(100, (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is a message", (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).Message);
            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(1), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Warning, (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(101, (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is another message", (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).Message);
            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(2), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Warning, (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(102, (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is yet another message", (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).Message);
        }

        /// <summary>
        /// Emits an error event to a trace source
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits an error event to a trace source")]
        [Priority(1)]
        [TestMethod]
        public void EmitError()
        {
            MemoryTraceListener listener;
            var traceSource = MemoryTraceListener.Create(out listener);
            var logger = new TraceSourceLogger(traceSource);
            logger.EmitError(100, "this is a message");
            logger.EmitError(101, "this is another message");
            logger.EmitError(102, "this is yet another message");

            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(0), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Error, (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(100, (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is a message", (listener.TraceEvents.ElementAt(0) as TraceEvent.MessageEvent).Message);
            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(1), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Error, (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(101, (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is another message", (listener.TraceEvents.ElementAt(1) as TraceEvent.MessageEvent).Message);
            Assert.IsInstanceOfType(listener.TraceEvents.ElementAt(2), typeof(TraceEvent.MessageEvent));
            Assert.AreEqual(TraceEventType.Error, (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).EventType);
            Assert.AreEqual(102, (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).Id);
            Assert.AreEqual("this is yet another message", (listener.TraceEvents.ElementAt(2) as TraceEvent.MessageEvent).Message);
        }

        /// <summary>
        /// Emits a detail event to a ILogger when that event uses a negative ID
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits a detail event to a ILogger when that event uses a negative ID")]
        [Priority(1)]
        [TestMethod]
        public void EmitDetailNegativeEventId()
        {
            var logger = new MemoryLogger();
            logger.EmitDetail(-1, "this is a message");
        }

        /// <summary>
        /// Emits an information event to a ILogger when that event uses a negative ID
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits an information event to a ILogger when that event uses a negative ID")]
        [Priority(1)]
        [TestMethod]
        public void EmitInformationNegativeEventId()
        {
            var logger = new MemoryLogger();
            logger.EmitInformation(-1, "this is a message");
        }

        /// <summary>
        /// Emits a warning event to a ILogger when that event uses a negative ID
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits a warning event to a ILogger when that event uses a negative ID")]
        [Priority(1)]
        [TestMethod]
        public void EmitWarningNegativeEventId()
        {
            var logger = new MemoryLogger();
            logger.EmitWarning(-1, "this is a message");
        }

        /// <summary>
        /// Emits an error event to a ILogger when that event uses a negative ID
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits an error event to a ILogger when that event uses a negative ID")]
        [Priority(1)]
        [TestMethod]
        public void EmitErrorNegativeEventId()
        {
            var logger = new MemoryLogger();
            logger.EmitError(-1, "this is a message");
        }

        /// <summary>
        /// Emits a detail event to a ILogger when that event uses a null message
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits a detail event to a ILogger when that event uses a null message")]
        [Priority(1)]
        [TestMethod]
        public void EmitDetailNullMessage()
        {
            var logger = new MemoryLogger();
            logger.EmitDetail(50, null);
        }

        /// <summary>
        /// Emits an information event to a ILogger when that event uses a null message
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits an information event to a ILogger when that event uses a null message")]
        [Priority(1)]
        [TestMethod]
        public void EmitInformationNullMessage()
        {
            var logger = new MemoryLogger();
            logger.EmitInformation(50, null);
        }

        /// <summary>
        /// Emits a warning event to a ILogger when that event uses a null message
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits a warning event to a ILogger when that event uses a null message")]
        [Priority(1)]
        [TestMethod]
        public void EmitWarningNullMessage()
        {
            var logger = new MemoryLogger();
            logger.EmitWarning(50, null);
        }

        /// <summary>
        /// Emits an error event to a ILogger when that event uses a null message
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits an error event to a ILogger when that event uses a null message")]
        [Priority(1)]
        [TestMethod]
        public void EmitErrorNullMessage()
        {
            var logger = new MemoryLogger();
            logger.EmitError(50, null);
        }
    }
}
#endif