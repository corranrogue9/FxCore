#if NET40
namespace Fx.Logging
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="MemoryLogger"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class MemoryLoggerUnitTests
    {
        /// <summary>
        /// Emits a detail event to a log existing in memory
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits a detail event to a log existing in memory")]
        [Priority(1)]
        [TestMethod]
        public void EmitDetail()
        {
            var logger = new MemoryLogger();
            logger.EmitDetail(100, "this is a message");
            logger.EmitDetail(101, "this is another message");
            logger.EmitDetail(102, "this is yet another message");

            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.DetailEvent));
            Assert.AreEqual(100, (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Message);
            Assert.IsInstanceOfType(logger.Events.ElementAt(1), typeof(MemoryEvent.DetailEvent));
            Assert.AreEqual(101, (logger.Events.ElementAt(1) as MemoryEvent.DetailEvent).Id);
            Assert.AreEqual("this is another message", (logger.Events.ElementAt(1) as MemoryEvent.DetailEvent).Message);
            Assert.IsInstanceOfType(logger.Events.ElementAt(2), typeof(MemoryEvent.DetailEvent));
            Assert.AreEqual(102, (logger.Events.ElementAt(2) as MemoryEvent.DetailEvent).Id);
            Assert.AreEqual("this is yet another message", (logger.Events.ElementAt(2) as MemoryEvent.DetailEvent).Message);
        }

        /// <summary>
        /// Emits an information event to a log existing in memory
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits an information event to a log existing in memory")]
        [Priority(1)]
        [TestMethod]
        public void EmitInformation()
        {
            var logger = new MemoryLogger();
            logger.EmitInformation(100, "this is a message");
            logger.EmitInformation(101, "this is another message");
            logger.EmitInformation(102, "this is yet another message");

            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.InformationEvent));
            Assert.AreEqual(100, (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Message);
            Assert.IsInstanceOfType(logger.Events.ElementAt(1), typeof(MemoryEvent.InformationEvent));
            Assert.AreEqual(101, (logger.Events.ElementAt(1) as MemoryEvent.InformationEvent).Id);
            Assert.AreEqual("this is another message", (logger.Events.ElementAt(1) as MemoryEvent.InformationEvent).Message);
            Assert.IsInstanceOfType(logger.Events.ElementAt(2), typeof(MemoryEvent.InformationEvent));
            Assert.AreEqual(102, (logger.Events.ElementAt(2) as MemoryEvent.InformationEvent).Id);
            Assert.AreEqual("this is yet another message", (logger.Events.ElementAt(2) as MemoryEvent.InformationEvent).Message);
        }

        /// <summary>
        /// Emits a warning event to a log existing in memory
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits a warning event to a log existing in memory")]
        [Priority(1)]
        [TestMethod]
        public void EmitWarning()
        {
            var logger = new MemoryLogger();
            logger.EmitWarning(100, "this is a message");
            logger.EmitWarning(101, "this is another message");
            logger.EmitWarning(102, "this is yet another message");

            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.WarningEvent));
            Assert.AreEqual(100, (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Message);
            Assert.IsInstanceOfType(logger.Events.ElementAt(1), typeof(MemoryEvent.WarningEvent));
            Assert.AreEqual(101, (logger.Events.ElementAt(1) as MemoryEvent.WarningEvent).Id);
            Assert.AreEqual("this is another message", (logger.Events.ElementAt(1) as MemoryEvent.WarningEvent).Message);
            Assert.IsInstanceOfType(logger.Events.ElementAt(2), typeof(MemoryEvent.WarningEvent));
            Assert.AreEqual(102, (logger.Events.ElementAt(2) as MemoryEvent.WarningEvent).Id);
            Assert.AreEqual("this is yet another message", (logger.Events.ElementAt(2) as MemoryEvent.WarningEvent).Message);
        }

        /// <summary>
        /// Emits an error event to a log existing in memory
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits an error event to a log existing in memory")]
        [Priority(1)]
        [TestMethod]
        public void EmitError()
        {
            var logger = new MemoryLogger();
            logger.EmitError(100, "this is a message");
            logger.EmitError(101, "this is another message");
            logger.EmitError(102, "this is yet another message");

            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.ErrorEvent));
            Assert.AreEqual(100, (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Message);
            Assert.IsInstanceOfType(logger.Events.ElementAt(1), typeof(MemoryEvent.ErrorEvent));
            Assert.AreEqual(101, (logger.Events.ElementAt(1) as MemoryEvent.ErrorEvent).Id);
            Assert.AreEqual("this is another message", (logger.Events.ElementAt(1) as MemoryEvent.ErrorEvent).Message);
            Assert.IsInstanceOfType(logger.Events.ElementAt(2), typeof(MemoryEvent.ErrorEvent));
            Assert.AreEqual(102, (logger.Events.ElementAt(2) as MemoryEvent.ErrorEvent).Id);
            Assert.AreEqual("this is yet another message", (logger.Events.ElementAt(2) as MemoryEvent.ErrorEvent).Message);
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