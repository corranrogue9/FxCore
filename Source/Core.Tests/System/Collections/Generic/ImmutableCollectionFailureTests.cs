namespace System.Collections.Generic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ImmutableCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ImmutableCollectionFailureTests
    {
        /// <summary>
        /// Constructs a new immutable collection from a null collection
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new immutable collection from a null collection")]
        [TestMethod]
        public void ConstructWithNullCollection()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new ImmutableCollection<string>(null));
        }
    }
}
