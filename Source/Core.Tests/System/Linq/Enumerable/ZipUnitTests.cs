#if NET40 || !NET35
namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Zips a sequence with another sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Zips a sequence with another sequence")]
        [Priority(1)]
        [TestMethod]
        public void Zip()
        {
            CollectionAssert.AreEqual(new[] { 0, 0, 0, 0 }, new[] { 1, 2, 3, 4 }.Zip(new[] { -1, -2, -3, -4 }, (first, second) => first + second).ToList());
        }

        /// <summary>
        /// Zips a sequence with an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Zips a sequence with an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ZipEmptySecond()
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), new[] { 1, 2, 3, 4 }.Zip(Enumerable.Empty<int>(), (first, second) => first + second).ToList());
        }

        /// <summary>
        /// Zips a sequence with an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Zips a sequence with an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ZipEmptyFirst()
        {
            CollectionAssert.AreEqual(
                Enumerable.Empty<int>().ToList(),
                Enumerable.Empty<int>().Zip(new[] { -1, -2, -3, -4 }, (first, second) => first + second).ToList());
        }
    }
}
#endif