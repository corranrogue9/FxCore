#if NET40
namespace Fx.Logging
{
#if DEBUG
    using System;
#endif
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="LoggerExtensions"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class LoggerExtensionsUnitTests
    {
        #region EmitDetail

        /// <summary>
        /// Emits a detail to a logger based on a formatted message
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a detail to a logger based on a formatted message")]
        [TestMethod]
        public void EmitDetailFormat()
        {
            var logger = new MemoryLogger();
            logger.EmitDetail(0, "{0} is a message", "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.DetailEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Message);
        }

        /// <summary>
        /// Emits a detail to a logger based on a formatted message when not enough data is provided
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a detail to a logger based on a formatted message when not enough data is provided")]
        [TestMethod]
        public void EmitDetailBadFormat()
        {
            var logger = new MemoryLogger();
#if DEBUG
            ExceptionAssert.Throws<FormatException>(() => logger.EmitDetail(0, "{0} is a {1}", "this"));
#else
            logger.EmitDetail(0, "{0} is a {1}", "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.DetailEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Id);
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Message.Contains("{0} is a {1}"));
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Message.Contains("this"));
#endif
        }

        /// <summary>
        /// Emits a detail to a logger based on a formatted message which contains null data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a detail to a logger based on a formatted message which contains null data")]
        [TestMethod]
        public void EmitDetailFormatNullData()
        {
            var logger = new MemoryLogger();
            logger.EmitDetail(0, "{0} is a message", null);

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.DetailEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Id);
            Assert.AreEqual("{0} is a message", (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Message);
        }

        /// <summary>
        /// Emits a detail to a logger based on an event identifier
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a detail to a logger based on an event identifier")]
        [TestMethod]
        public void EmitDetailIdentifier()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a message");
            logger.EmitDetail(identifier, "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.DetailEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Message);
        }

        /// <summary>
        /// Emits a detail to a logger based on an event identifier when not enough data is provided
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a detail to a logger based on an event identifier when not enough data is provided")]
        [TestMethod]
        public void EmitDetailBadIdentifier()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a {1}");
#if DEBUG
            ExceptionAssert.Throws<FormatException>(() => logger.EmitDetail(identifier, "this"));
#else
            logger.EmitDetail(identifier, "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.DetailEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Id);
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Message.Contains("{0} is a {1}"));
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Message.Contains("this"));
#endif
        }

        /// <summary>
        /// Emits a detail to a logger based on an event identifier which contains null data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a detail to a logger based on an event identifier which contains null data")]
        [TestMethod]
        public void EmitDetailIdentifierNullData()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a message");
            logger.EmitDetail(identifier, null);

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.DetailEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Id);
            Assert.AreEqual("{0} is a message", (logger.Events.ElementAt(0) as MemoryEvent.DetailEvent).Message);
        }

        #endregion EmitDetail

        #region EmitInformation

        /// <summary>
        /// Emits an information to a logger based on a formatted message
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an information to a logger based on a formatted message")]
        [TestMethod]
        public void EmitInformationFormat()
        {
            var logger = new MemoryLogger();
            logger.EmitInformation(0, "{0} is a message", "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.InformationEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Message);
        }

        /// <summary>
        /// Emits an information to a logger based on a formatted message when not enough data is provided
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an information to a logger based on a formatted message when not enough data is provided")]
        [TestMethod]
        public void EmitInformationBadFormat()
        {
            var logger = new MemoryLogger();
#if DEBUG
            ExceptionAssert.Throws<FormatException>(() => logger.EmitInformation(0, "{0} is a {1}", "this"));
#else
            logger.EmitInformation(0, "{0} is a {1}", "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.InformationEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Id);
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Message.Contains("{0} is a {1}"));
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Message.Contains("this"));
#endif
        }

        /// <summary>
        /// Emits an information to a logger based on a formatted message which contains null data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an information to a logger based on a formatted message which contains null data")]
        [TestMethod]
        public void EmitInformationFormatNullData()
        {
            var logger = new MemoryLogger();
            logger.EmitInformation(0, "{0} is a message", null);

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.InformationEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Id);
            Assert.AreEqual("{0} is a message", (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Message);
        }

        /// <summary>
        /// Emits an information to a logger based on an event identifier
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an information to a logger based on an event identifier")]
        [TestMethod]
        public void EmitInformationIdentifier()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a message");
            logger.EmitInformation(identifier, "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.InformationEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Message);
        }

        /// <summary>
        /// Emits an information to a logger based on an event identifier when not enough data is provided
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an information to a logger based on an event identifier when not enough data is provided")]
        [TestMethod]
        public void EmitInformationBadIdentifier()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a {1}");
#if DEBUG
            ExceptionAssert.Throws<FormatException>(() => logger.EmitInformation(identifier, "this"));
#else
            logger.EmitInformation(identifier, "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.InformationEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Id);
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Message.Contains("{0} is a {1}"));
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Message.Contains("this"));
#endif
        }

        /// <summary>
        /// Emits an information to a logger based on an event identifier which contains null data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an information to a logger based on an event identifier which contains null data")]
        [TestMethod]
        public void EmitInformationIdentifierNullData()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a message");
            logger.EmitInformation(identifier, null);

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.InformationEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Id);
            Assert.AreEqual("{0} is a message", (logger.Events.ElementAt(0) as MemoryEvent.InformationEvent).Message);
        }

        #endregion EmitInformation

        #region EmitWarning

        /// <summary>
        /// Emits a warning to a logger based on a formatted message
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a warning to a logger based on a formatted message")]
        [TestMethod]
        public void EmitWarningFormat()
        {
            var logger = new MemoryLogger();
            logger.EmitWarning(0, "{0} is a message", "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.WarningEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Message);
        }

        /// <summary>
        /// Emits a warning to a logger based on a formatted message when not enough data is provided
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a warning to a logger based on a formatted message when not enough data is provided")]
        [TestMethod]
        public void EmitWarningBadFormat()
        {
            var logger = new MemoryLogger();
#if DEBUG
            ExceptionAssert.Throws<FormatException>(() => logger.EmitWarning(0, "{0} is a {1}", "this"));
#else
            logger.EmitWarning(0, "{0} is a {1}", "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.WarningEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Id);
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Message.Contains("{0} is a {1}"));
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Message.Contains("this"));
#endif
        }

        /// <summary>
        /// Emits a warning to a logger based on a formatted message which contains null data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a warning to a logger based on a formatted message which contains null data")]
        [TestMethod]
        public void EmitWarningFormatNullData()
        {
            var logger = new MemoryLogger();
            logger.EmitWarning(0, "{0} is a message", null);

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.WarningEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Id);
            Assert.AreEqual("{0} is a message", (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Message);
        }

        /// <summary>
        /// Emits a warning to a logger based on an event identifier
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a warning to a logger based on an event identifier")]
        [TestMethod]
        public void EmitWarningIdentifier()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a message");
            logger.EmitWarning(identifier, "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.WarningEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Message);
        }

        /// <summary>
        /// Emits a warning to a logger based on an event identifier when not enough data is provided
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a warning to a logger based on an event identifier when not enough data is provided")]
        [TestMethod]
        public void EmitWarningBadIdentifier()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a {1}");
#if DEBUG
            ExceptionAssert.Throws<FormatException>(() => logger.EmitWarning(identifier, "this"));
#else
            logger.EmitWarning(identifier, "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.WarningEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Id);
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Message.Contains("{0} is a {1}"));
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Message.Contains("this"));
#endif
        }

        /// <summary>
        /// Emits a warning to a logger based on an event identifier which contains null data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits a warning to a logger based on an event identifier which contains null data")]
        [TestMethod]
        public void EmitWarningIdentifierNullData()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a message");
            logger.EmitWarning(identifier, null);

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.WarningEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Id);
            Assert.AreEqual("{0} is a message", (logger.Events.ElementAt(0) as MemoryEvent.WarningEvent).Message);
        }

        #endregion EmitWarning

        #region EmitError

        /// <summary>
        /// Emits an error to a logger based on a formatted message
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an error to a logger based on a formatted message")]
        [TestMethod]
        public void EmitErrorFormat()
        {
            var logger = new MemoryLogger();
            logger.EmitError(0, "{0} is a message", "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.ErrorEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Message);
        }

        /// <summary>
        /// Emits an error to a logger based on a formatted message when not enough data is provided
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an error to a logger based on a formatted message when not enough data is provided")]
        [TestMethod]
        public void EmitErrorBadFormat()
        {
            var logger = new MemoryLogger();
#if DEBUG
            ExceptionAssert.Throws<FormatException>(() => logger.EmitError(0, "{0} is a {1}", "this"));
#else
            logger.EmitError(0, "{0} is a {1}", "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.ErrorEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Id);
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Message.Contains("{0} is a {1}"));
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Message.Contains("this"));
#endif
        }

        /// <summary>
        /// Emits an error to a logger based on a formatted message which contains null data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an error to a logger based on a formatted message which contains null data")]
        [TestMethod]
        public void EmitErrorFormatNullData()
        {
            var logger = new MemoryLogger();
            logger.EmitError(0, "{0} is a message", null);

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.ErrorEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Id);
            Assert.AreEqual("{0} is a message", (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Message);
        }

        /// <summary>
        /// Emits an error to a logger based on an event identifier
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an error to a logger based on an event identifier")]
        [TestMethod]
        public void EmitErrorIdentifier()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a message");
            logger.EmitError(identifier, "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.ErrorEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Id);
            Assert.AreEqual("this is a message", (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Message);
        }

        /// <summary>
        /// Emits an error to a logger based on an event identifier when not enough data is provided
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an error to a logger based on an event identifier when not enough data is provided")]
        [TestMethod]
        public void EmitErrorBadIdentifier()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a {1}");
#if DEBUG
            ExceptionAssert.Throws<FormatException>(() => logger.EmitError(identifier, "this"));
#else
            logger.EmitError(identifier, "this");

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.ErrorEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Id);
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Message.Contains("{0} is a {1}"));
            Assert.IsTrue((logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Message.Contains("this"));
#endif
        }

        /// <summary>
        /// Emits an error to a logger based on an event identifier which contains null data
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Emits an error to a logger based on an event identifier which contains null data")]
        [TestMethod]
        public void EmitErrorIdentifierNullData()
        {
            var logger = new MemoryLogger();
            var identifier = new EventIdentifier(0, "{0} is a message");
            logger.EmitError(identifier, null);

            Assert.AreEqual(1, logger.Events.Count());
            Assert.IsInstanceOfType(logger.Events.ElementAt(0), typeof(MemoryEvent.ErrorEvent));
            Assert.AreEqual(0, (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Id);
            Assert.AreEqual("{0} is a message", (logger.Events.ElementAt(0) as MemoryEvent.ErrorEvent).Message);
        }

        #endregion EmitWarning
    }
}
#endif