namespace System.Collections.Concurrent
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Load tests for the <see cref="ConcurrentQueue{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ConcurrentQueueLoadTests
    {
        /// <summary>
        /// Ensures that enqueueing is thread-safe
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Ensures that enqueueing is thread-safe")]
        [TestMethod]
        public void Enqueue()
        {
            var queue = new ConcurrentQueue<int>();
            
            var threads = new Thread[1000];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    foreach (var element in Enumerable.Range(0, 10000))
                    {
                        queue.Enqueue(element);
                    }
                });
            }

            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i].Join();
            }

            var counts = new Dictionary<int, int>();
            foreach (var element in queue)
            {
                int count;
                if (!counts.TryGetValue(element, out count))
                {
                    count = 0;
                }

                ++count;
                counts[element] = count;
            }

            foreach (var pair in counts)
            {
                Assert.AreEqual(1000, pair.Value);
            }

            foreach (var element in Enumerable.Range(0, 10000))
            {
                Assert.IsTrue(counts.ContainsKey(element));
            }
        }
    }
}
