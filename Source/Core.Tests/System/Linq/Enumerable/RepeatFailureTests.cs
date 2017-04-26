namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class RepeatFailureTests
    {
        /// <summary>
        /// Repeats a value a negative number of times
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets a range with a negative count")]
        [Priority(1)]
        [TestMethod]
        public void RepeatNegative()
        {
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Repeat(10, -1));
        }
    }
}
