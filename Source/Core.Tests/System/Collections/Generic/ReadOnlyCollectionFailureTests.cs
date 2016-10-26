namespace System.Collections.Generic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ReadOnlyCollection{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ReadOnlyCollectionFailureTests
    {
        /// <summary>
        /// Constructs a new readonly collection from a null collection
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new readonly collection from a null collection")]
        [TestMethod]
        public void ConstructWithNullCollection()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new ReadOnlyCollection<string>(null));
        }
    }
}
