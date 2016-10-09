namespace System.Collections.Concurrent
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ConcurrentQueue{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ConcurrentQueueUnitTests
    {
        /// <summary>
        /// Ensures that an empty queue has no items
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that an empty queue has no items")]
        [TestMethod]
        public void EnumerateEmpty()
        {
            var queue = new ConcurrentQueue<object>();
            Assert.IsFalse(queue.Any());
        }

        /// <summary>
        /// Ensures that null can be enqueued
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that null can be enqueued")]
        [TestMethod]
        public void EnqueueNull()
        {
            var queue = new ConcurrentQueue<object>();
            queue.Enqueue(null);

            foreach (var element in queue)
            {
                Assert.IsNull(element);
            }
        }

        /// <summary>
        /// Ensures that enumerating is a snapshot, and does not reflect future updates
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enumerating is a snapshot, and does not reflect future updates")]
        [TestMethod]
        public void EnumerationSnapshot()
        {
            var queue = new ConcurrentQueue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");

            using (var enumerator = queue.GetEnumerator())
            {
                Assert.IsTrue(enumerator.MoveNext());
                Assert.IsTrue(enumerator.MoveNext());
                Assert.IsFalse(enumerator.MoveNext());
            }

            using (var enumerator = queue.GetEnumerator())
            {
                queue.Enqueue("third");

                Assert.IsTrue(enumerator.MoveNext());
                Assert.IsTrue(enumerator.MoveNext());
                Assert.IsFalse(enumerator.MoveNext());
            }

            using (var enumerator = queue.GetEnumerator())
            {
                Assert.IsTrue(enumerator.MoveNext());
                Assert.IsTrue(enumerator.MoveNext());
                Assert.IsTrue(enumerator.MoveNext());
                Assert.IsFalse(enumerator.MoveNext());
            }
        }
    }
}
