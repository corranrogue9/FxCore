namespace System.Linq
{
    using System.Collections;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableFailureTests
    {
        /// <summary>
        /// Gets the elements of the specified type when the sequence is null
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the elements of the specified type when the sequence is null")]
        [Priority(1)]
        [TestMethod]
        public void OfTypeNullSequence()
        {
            IEnumerable data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.OfType<string>());
        }
    }
}
