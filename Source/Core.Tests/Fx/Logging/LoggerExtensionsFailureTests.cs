namespace Fx.Logging
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="LoggerExtensions"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class LoggerExtensionsFailureTests
    {
        #region EmitDetail

        /// <summary>
        /// Emits a detail to a null logger
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits a detail to a null logger")]
        [TestMethod]
        public void EmitDetailNullLogger()
        {
            ILogger logger = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitDetail(0, "{0} is a message", "this"));
        }

        /// <summary>
        /// Emits a detail to a logger when the message format is null
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits a detail to a logger when the message format is null")]
        [TestMethod]
        public void EmitDetailNullFormat()
        {
            var logger = new MemoryLogger();
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitDetail(0, null, "this"));
        }

        /// <summary>
        /// Emits a detail to a logger when the event identifier is null
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits a detail to a logger when the event identifier is null")]
        [TestMethod]
        public void EmitDetailNullIdentifier()
        {
            var logger = new MemoryLogger();
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitDetail(null, "this"));
        }

        #endregion EmitDetail

        #region EmitInformation

        /// <summary>
        /// Emits an information to a null logger
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits an information to a null logger")]
        [TestMethod]
        public void EmitInformationNullLogger()
        {
            ILogger logger = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitInformation(0, "{0} is a message", "this"));
        }

        /// <summary>
        /// Emits an information to a logger when the message format is null
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits an information to a logger when the message format is null")]
        [TestMethod]
        public void EmitInformationNullFormat()
        {
            var logger = new MemoryLogger();
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitInformation(0, null, "this"));
        }

        /// <summary>
        /// Emits an information to a logger when the event identifier is null
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits an information to a logger when the event identifier is null")]
        [TestMethod]
        public void EmitInformationNullIdentifier()
        {
            var logger = new MemoryLogger();
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitInformation(null, "this"));
        }

        #endregion EmitInformation

        #region EmitWarning

        /// <summary>
        /// Emits a warning to a null logger
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits a warning to a null logger")]
        [TestMethod]
        public void EmitWarningNullLogger()
        {
            ILogger logger = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitWarning(0, "{0} is a message", "this"));
        }

        /// <summary>
        /// Emits a warning to a logger when the message format is null
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits a warning to a logger when the message format is null")]
        [TestMethod]
        public void EmitWarningNullFormat()
        {
            var logger = new MemoryLogger();
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitWarning(0, null, "this"));
        }

        /// <summary>
        /// Emits a warning to a logger when the event identifier is null
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits a warning to a logger when the event identifier is null")]
        [TestMethod]
        public void EmitWarningNullIdentifier()
        {
            var logger = new MemoryLogger();
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitWarning(null, "this"));
        }

        #endregion EmitWarning

        #region EmitError

        /// <summary>
        /// Emits an error to a null logger
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits an error to a null logger")]
        [TestMethod]
        public void EmitErrorNullLogger()
        {
            ILogger logger = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitError(0, "{0} is a message", "this"));
        }

        /// <summary>
        /// Emits an error to a logger when the message format is null
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits an error to a logger when the message format is null")]
        [TestMethod]
        public void EmitErrorNullFormat()
        {
            var logger = new MemoryLogger();
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitError(0, null, "this"));
        }

        /// <summary>
        /// Emits an error to a logger when the event identifier is null
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Emits an error to a logger when the event identifier is null")]
        [TestMethod]
        public void EmitErrorNullIdentifier()
        {
            var logger = new MemoryLogger();
            ExceptionAssert.Throws<ArgumentNullException>(() => logger.EmitError(null, "this"));
        }

        #endregion EmitError
    }
}
