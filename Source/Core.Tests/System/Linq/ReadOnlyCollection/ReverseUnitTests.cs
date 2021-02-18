namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ReadOnlyCollectionExtensions"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class ReadOnlyCollectionExtensionsUnitTests
    {
        /// <summary>
        /// Reverses a sequence ensuring deferrred exeuction
        /// </summary>
        [TestCategory("Unit")]
        [Description("Reverses a sequence ensuring deferrred exeuction")]
        [Priority(1)]
        [TestMethod]
        public void ReverseDeferredExecution()
        {
            var sequence = new DeferredExecutionReadOnlyCollection<int>(new[] { 1, 2, 3, 4, 5 });
            var reversed = sequence.Reverse();

            Assert.AreEqual(sequence.Count, reversed.Count);
            Assert.AreEqual(false, sequence.EnumeratorRetrieved);
            Assert.AreEqual(false, sequence.EnumerationStarted);
            Assert.AreEqual(false, sequence.EnumerationCompleted);

            using (var enumerator = reversed.GetEnumerator())
            {
                Assert.AreEqual(true, sequence.EnumeratorRetrieved);
                Assert.AreEqual(false, sequence.EnumerationStarted);
                Assert.AreEqual(false, sequence.EnumerationCompleted);

                while (enumerator.MoveNext())
                {
                    Assert.AreEqual(true, sequence.EnumerationStarted);
                    Assert.AreEqual(false, sequence.EnumerationCompleted);
                }

                Assert.AreEqual(true, sequence.EnumerationCompleted);
            }
        }
    }
}
