namespace Fx.Concurrency
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Ensure"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class EnsureFailureTests
    {
        /// <summary>
        /// Ensures that if a class argument is null, it will throw
        /// </summary>
        [TestCategory("Failure")]
        [Description("Ensures that if a class argument is null, it will throw")]
        [Priority(1)]
        [TestMethod]
        public void NotNullClass()
        {
            var output = new StringBuilder();
            var instructions = new[] { 1, 2, 3 }.Select(val => new IntInstruction() { Value = val });
            var permutations = instructions.Permutations();
            foreach (var permutation in permutations)
            {
                output.AppendLine("Permutation:");
                foreach (var instructionSet in permutation)
                {
                    foreach (var instruction in instructionSet)
                    {
                        output.Append($"{instruction} ");
                    }

                    output.AppendLine();
                }
            }

            var result = output.ToString();
            Trace.Write(result);
        }

        [TestMethod]
        public void Test()
        {
            var queue = new ConcurrentQueue<string>();
            ////Action action = () => queue.Enqueue("asdf");
            Func<int> action = () => 1;
            var bytes = action.Method.GetMethodBody().GetILAsByteArray();
            var generatedAction = Utilities.GenerateAction(bytes);
            var generatedBytes = generatedAction.Method.GetMethodBody().GetILAsByteArray();
            generatedAction();
        }

        [TestMethod]
        public void Test2()
        {
            var localQueue = new ConcurrentQueue<string>();
            Func<ConcurrentQueue<string>, int> action = (queue) => new ConcurrentQueue<string>().Count + 3;
            var bytes = action.Method.GetMethodBody().GetILAsByteArray();
            var generatedAction = Utilities.GenerateAction2<ConcurrentQueue<string>>(bytes);
            var result = generatedAction(localQueue);
        }

        [TestMethod]
        public void Test4()
        {
            var localQueue = new ConcurrentQueue<string>();
            Func<string, int> action = (queue) => "asdf"[0] + 3;
            var bytes = action.Method.GetMethodBody().GetILAsByteArray();
            var generatedAction = Utilities.GenerateAction2<string>(bytes);
            var result = generatedAction("asdf");
        }

        [TestMethod]
        public void Test3()
        {
            Func<int, int, int> action = (first, second) => first + second + 2;
            var bytes = action.Method.GetMethodBody().GetILAsByteArray(); //// TODO replacing 0x04 with 0x02 causes this to work correctly...
            ////bytes = new byte[] { 0x02, 0x03, 0x58, 0x2A };
            var generatedAction = Utilities.GenerateAction3(bytes);
            var result = generatedAction(10, 2);
        }
    }
}
