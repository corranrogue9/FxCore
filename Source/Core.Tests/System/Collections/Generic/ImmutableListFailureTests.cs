namespace System.Collections.Generic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ImmutableList{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ImmutableListFailureTests
    {
        /// <summary>
        /// Constructs a new immutable list from a null list
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new immutable list from a null list")]
        [TestMethod]
        public void ConstructWithNullList()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new ImmutableList<string>(null));
        }
    }
}
