namespace System.Collections.Generic
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ReadOnlyList{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ReadOnlyListFailureTests
    {
        /// <summary>
        /// Constructs a new readonly list from a null list
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Constructs a new readonly list from a null list")]
        [TestMethod]
        public void ConstructWithNullList()
        {
            ExceptionAssert.Throws<ArgumentNullException>(() => new ReadOnlyList<string>(null));
        }
    }
}
