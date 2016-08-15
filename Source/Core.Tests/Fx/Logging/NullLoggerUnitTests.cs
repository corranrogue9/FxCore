namespace Fx.Logging
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="NullLogger"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class NullLoggerUnitTests
    {
        /// <summary>
        /// Emits a detail event to a ILogger when that event uses a negative ID
        /// </summary>
        [TestCategory("Unit")]
        [Description("Emits a detail event to a ILogger when that event uses a negative ID")]
        [Priority(1)]
        [TestMethod]
        public void EmitDetailNegativeEventId()
        {
            var logger = NullLogger.Instance;
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
            var logger = NullLogger.Instance;
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
            var logger = NullLogger.Instance;
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
            var logger = NullLogger.Instance;
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
            var logger = NullLogger.Instance;
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
            var logger = NullLogger.Instance;
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
            var logger = NullLogger.Instance;
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
            var logger = NullLogger.Instance;
            logger.EmitError(50, null);
        }
    }
}
