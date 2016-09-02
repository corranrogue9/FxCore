#if NET40
namespace System
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Load tests for the <see cref="ConcurrentRandom"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ConcurrentRandomLoadTests
    {
        /// <summary>
        /// Gets the next integer in multiple threads
        /// </summary>
        [TestCategory("Load")]
        [Priority(2)]
        [Description("Gets the next integer in multiple threads")]
        [TestMethod]
        public void Next()
        {
            using (var random = new ConcurrentRandom())
            {
                var tasks = new Task[1000];
                for (int i = 0; i < tasks.Length; ++i)
                {
                    tasks[i] = Task.Factory.StartNew(() => 
                        {
                            int? previous = null;
                            for (int j = 0; j < 10000; ++j)
                            {
                                var value = random.Next();

                                // based on the MSDN page https://msdn.microsoft.com/en-us/library/system.random(v=vs.110).aspx under the section titled
                                // "The System.Random class and thread safety", this is the test used to determine if the Random instance has become compromised due to
                                // lack of thread-safety
                                if (previous != null && value == previous && value == 0)
                                {
                                    Assert.Fail();
                                }

                                previous = value;
                            }
                        });
                }

                Task.WaitAll(tasks);
            }
        }
    }
}
#endif