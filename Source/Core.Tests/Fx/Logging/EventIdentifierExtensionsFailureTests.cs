namespace Fx.Logging
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="EventIdentifierExtensions"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class EventIdentifierExtensionsFailureTests
    {
        /// <summary>
        /// Creates a regular expression from a null event identifier
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Creates a regular expression from a null event identifier")]
        [TestMethod]
        public void CreateRegularExpressionNullIdentifier()
        {
            EventIdentifier identifier = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => EventIdentifierExtensions.CreateRegularExpression(identifier));
        }

        /// <summary>
        /// Creates a regular expression from an event identifier that has unbalanced curly braces
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Creates a regular expression from an event identifier that has unbalanced curly braces")]
        [TestMethod]
        public void CreateRegularExpressionUnbalancedFormat()
        {
            var identifier = new EventIdentifier(0, "{0 is a format");
            ExceptionAssert.Throws<FormatException>(() => EventIdentifierExtensions.CreateRegularExpression(identifier));

            identifier = new EventIdentifier(1, "0} is also a format");
            ExceptionAssert.Throws<FormatException>(() => EventIdentifierExtensions.CreateRegularExpression(identifier));
        }
    }
}
