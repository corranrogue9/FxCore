namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupBy()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            var grouped = data.GroupBy(key => key[0].ToString()).ToArray();
            Assert.AreEqual(4, grouped.Length);
            Assert.AreEqual("a", grouped[0].Key);
            CollectionAssert.AreEqual(new[] { "asdf" }, grouped[0].ToArray());
            Assert.AreEqual("b", grouped[1].Key);
            CollectionAssert.AreEqual(new[] { "bsdf", "basdf" }, grouped[1].ToArray());
            Assert.AreEqual("c", grouped[2].Key);
            CollectionAssert.AreEqual(new[] { "cres", "casdf" }, grouped[2].ToArray());
            Assert.AreEqual("B", grouped[3].Key);
            CollectionAssert.AreEqual(new[] { "Bvrakj" }, grouped[3].ToArray());
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            var grouped = data.GroupBy(key => key[0].ToString(), StringComparer.OrdinalIgnoreCase).ToArray();
            Assert.AreEqual(3, grouped.Length);
            Assert.AreEqual("a", grouped[0].Key);
            CollectionAssert.AreEqual(new[] { "asdf" }, grouped[0].ToArray());
            Assert.AreEqual("b", grouped[1].Key);
            CollectionAssert.AreEqual(new[] { "bsdf", "basdf", "Bvrakj" }, grouped[1].ToArray());
            Assert.AreEqual("c", grouped[2].Key);
            CollectionAssert.AreEqual(new[] { "cres", "casdf" }, grouped[2].ToArray());
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            var grouped = data.GroupBy(key => key[0].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat))).ToArray();
            CollectionAssert.AreEqual(new[] { "aasdf", "bbsdfbasdf", "ccrescasdf", "BBvrakj" }, grouped);
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            var grouped = data.GroupBy(key => key[0].ToString(), element => element[1].ToString()).ToArray();
            Assert.AreEqual(4, grouped.Length);
            Assert.AreEqual("a", grouped[0].Key);
            CollectionAssert.AreEqual(new[] { "s" }, grouped[0].ToArray());
            Assert.AreEqual("b", grouped[1].Key);
            CollectionAssert.AreEqual(new[] { "s", "a" }, grouped[1].ToArray());
            Assert.AreEqual("c", grouped[2].Key);
            CollectionAssert.AreEqual(new[] { "r", "a" }, grouped[2].ToArray());
            Assert.AreEqual("B", grouped[3].Key);
            CollectionAssert.AreEqual(new[] { "v" }, grouped[3].ToArray());
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            var grouped = data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), StringComparer.OrdinalIgnoreCase).ToArray();
            Assert.AreEqual(3, grouped.Length);
            Assert.AreEqual("a", grouped[0].Key);
            CollectionAssert.AreEqual(new[] { "s" }, grouped[0].ToArray());
            Assert.AreEqual("b", grouped[1].Key);
            CollectionAssert.AreEqual(new[] { "s", "a", "v" }, grouped[1].ToArray());
            Assert.AreEqual("c", grouped[2].Key);
            CollectionAssert.AreEqual(new[] { "r", "a" }, grouped[2].ToArray());
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            var grouped = data.GroupBy(key => key[0].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase).ToArray();
            CollectionAssert.AreEqual(new[] { "aasdf", "bbsdfbasdfBvrakj", "ccrescasdf" }, grouped);
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelector()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            var grouped = data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)));
            CollectionAssert.AreEqual(new[] { "as", "bsa", "cra", "Bv" }, grouped.ToArray());
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            var grouped = data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), StringComparer.OrdinalIgnoreCase);
            CollectionAssert.AreEqual(new[] { "as", "bsav", "cra" }, grouped.ToArray());
        }
        
        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByComparerNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            IEqualityComparer<string> comparer = null;
            var grouped = data.GroupBy(key => key[0].ToString(), comparer).ToArray();
            Assert.AreEqual(4, grouped.Length);
            Assert.AreEqual("a", grouped[0].Key);
            CollectionAssert.AreEqual(new[] { "asdf" }, grouped[0].ToArray());
            Assert.AreEqual("b", grouped[1].Key);
            CollectionAssert.AreEqual(new[] { "bsdf", "basdf" }, grouped[1].ToArray());
            Assert.AreEqual("c", grouped[2].Key);
            CollectionAssert.AreEqual(new[] { "cres", "casdf" }, grouped[2].ToArray());
            Assert.AreEqual("B", grouped[3].Key);
            CollectionAssert.AreEqual(new[] { "Bvrakj" }, grouped[3].ToArray());
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByResultSelectorComparerNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            IEqualityComparer<string> comparer = null;
            var grouped = data.GroupBy(key => key[0].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer).ToArray();
            CollectionAssert.AreEqual(new[] { "aasdf", "bbsdfbasdf", "ccrescasdf", "BBvrakj" }, grouped);
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorResultSelectorComparerNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            IEqualityComparer<string> comparer = null;
            var grouped = data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), (key, element) => string.Concat(key, element.Aggregate(string.Concat)), comparer).ToArray();
            CollectionAssert.AreEqual(new[] { "as", "bsa", "cra", "Bv" }, grouped.ToArray());
        }

        /// <summary>
        /// Groups the elements of a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Groups the elements of a sequence")]
        [Priority(1)]
        [TestMethod]
        public void GroupByElementSelectorComparerNullComparer()
        {
            var data = new[] { "asdf", "bsdf", "cres", "basdf", "casdf", "Bvrakj" };
            IEqualityComparer<string> comparer = null;
            var grouped = data.GroupBy(key => key[0].ToString(), element => element[1].ToString(), comparer).ToArray();
            Assert.AreEqual(4, grouped.Length);
            Assert.AreEqual("a", grouped[0].Key);
            CollectionAssert.AreEqual(new[] { "s" }, grouped[0].ToArray());
            Assert.AreEqual("b", grouped[1].Key);
            CollectionAssert.AreEqual(new[] { "s", "a" }, grouped[1].ToArray());
            Assert.AreEqual("c", grouped[2].Key);
            CollectionAssert.AreEqual(new[] { "r", "a" }, grouped[2].ToArray());
            Assert.AreEqual("B", grouped[3].Key);
            CollectionAssert.AreEqual(new[] { "v" }, grouped[3].ToArray());
        }
    }
}
