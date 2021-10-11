namespace Fx.Concurrency
{
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
    }
}
