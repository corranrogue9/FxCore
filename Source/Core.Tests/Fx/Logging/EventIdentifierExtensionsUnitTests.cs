namespace Fx.Logging
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="EventIdentifierExtensions"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class EventIdentifierExtensionsUnitTests
    {
        /// <summary>
        /// Creates a regular expression from an event identifier
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Creates a regular expression from an event identifier")]
        [TestMethod]
        public void CreateRegularExpression()
        {
            var identifier = new EventIdentifier(0, "{0} is an event format");
            var regex = EventIdentifierExtensions.CreateRegularExpression(identifier);

            Assert.IsTrue(regex.IsMatch("this is an event format"));
            Assert.IsFalse(regex.IsMatch("this is also an event format"));
        }

        /// <summary>
        /// Creates a regular expression from an event identifier that emits curly braces
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Creates a regular expression from an event identifier that emits curly braces")]
        [TestMethod]
        public void CreateRegularExpressionExtraCurlyBraces()
        {
            var identifier = new EventIdentifier(0, "{{0}} is an event format");
            var regex = EventIdentifierExtensions.CreateRegularExpression(identifier);

            Assert.IsTrue(regex.IsMatch("{0} is an event format"));
            Assert.IsFalse(regex.IsMatch("this is an event format"));
            Assert.IsFalse(regex.IsMatch("this is also an event format"));
        }

        /// <summary>
        /// Creates a regular expression from an event identifier that emits a value inside of curly braces
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Creates a regular expression from an event identifier that emits a value inside of curly braces")]
        [TestMethod]
        public void CreateRegularExpressionExtraExtraCurlyBraces()
        {
            var identifier = new EventIdentifier(0, "{{{0}}} is an event format");
            var regex = EventIdentifierExtensions.CreateRegularExpression(identifier);

            Assert.IsTrue(regex.IsMatch("{this} is an event format"));
            Assert.IsFalse(regex.IsMatch("{this} is also an event format"));
        }

        /// <summary>
        /// Creates a regular expression from an event identifier that has more than 1 argument in the format
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Creates a regular expression from an event identifier that has more than 1 argument in the format")]
        [TestMethod]
        public void CreateRegularExpressionMultipleArguments()
        {
            var identifier = new EventIdentifier(0, "{0} is a {1} format");
            var regex = EventIdentifierExtensions.CreateRegularExpression(identifier);

            Assert.IsTrue(regex.IsMatch("this is a bad format"));
            Assert.IsTrue(regex.IsMatch("this is a good format"));
            Assert.IsFalse(regex.IsMatch("this is also a good format"));
        }

        /// <summary>
        /// Creates a regular expression from an event identifier an ensures that the arguments are properly captured
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Creates a regular expression from an event identifier an ensures that the arguments are properly captured")]
        [TestMethod]
        public void CreateRegularExpressionArgumentCapture()
        {
            var identifier = new EventIdentifier(0, "{0} is a {1} format");
            var regex = EventIdentifierExtensions.CreateRegularExpression(identifier);

            var match = regex.Match("this is a good format");
            Assert.IsTrue(match.Success);
            Assert.AreEqual(2, match.Groups["value"].Captures.Count);
            Assert.AreEqual("this", match.Groups["value"].Captures[0].Value);
            Assert.AreEqual("good", match.Groups["value"].Captures[1].Value);
        }
    }
}
