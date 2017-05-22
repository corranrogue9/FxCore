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
        /// Creates a dictionary from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionary()
        {
            var dictionary = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToDictionary(tuple => tuple.Item1);
            Assert.AreEqual(4, dictionary.Count);
            Assert.IsTrue(dictionary.ContainsKey("name"));
            Assert.IsTrue(dictionary.ContainsKey("name2"));
            Assert.IsTrue(dictionary.ContainsKey("name3"));
            Assert.IsTrue(dictionary.ContainsKey("NAME"));
            Assert.AreEqual(Tuple.Create("name", 1), dictionary["name"]);
            Assert.AreEqual(Tuple.Create("name2", 2), dictionary["name2"]);
            Assert.AreEqual(Tuple.Create("name3", 3), dictionary["name3"]);
            Assert.AreEqual(Tuple.Create("NAME", 3), dictionary["NAME"]);
        }

        /// <summary>
        /// Creates a dictionary from an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryEmpty()
        {
            var dictionary = Enumerable.Empty<Tuple<string, int>>().ToDictionary(tuple => tuple.Item1);
            Assert.AreEqual(0, dictionary.Count);
        }
        
        /// <summary>
        /// Creates a dictionary from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparer()
        {
            var dictionary = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToDictionary(tuple => tuple.Item1, StringComparer.Ordinal);
            Assert.AreEqual(4, dictionary.Count);
            Assert.IsTrue(dictionary.ContainsKey("name"));
            Assert.IsTrue(dictionary.ContainsKey("name2"));
            Assert.IsTrue(dictionary.ContainsKey("name3"));
            Assert.IsTrue(dictionary.ContainsKey("NAME"));
            Assert.AreEqual(Tuple.Create("name", 1), dictionary["name"]);
            Assert.AreEqual(Tuple.Create("name2", 2), dictionary["name2"]);
            Assert.AreEqual(Tuple.Create("name3", 3), dictionary["name3"]);
            Assert.AreEqual(Tuple.Create("NAME", 3), dictionary["NAME"]);
        }

        /// <summary>
        /// Creates a dictionary from an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerEmpty()
        {
            var dictionary = Enumerable.Empty<Tuple<string, int>>().ToDictionary(tuple => tuple.Item1, StringComparer.Ordinal);
            Assert.AreEqual(0, dictionary.Count);
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from a sequence with a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerNullComparer()
        {
            var dictionary = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToDictionary(tuple => tuple.Item1, null);
            Assert.AreEqual(4, dictionary.Count);
            Assert.IsTrue(dictionary.ContainsKey("name"));
            Assert.IsTrue(dictionary.ContainsKey("name2"));
            Assert.IsTrue(dictionary.ContainsKey("name3"));
            Assert.IsTrue(dictionary.ContainsKey("NAME"));
            Assert.AreEqual(Tuple.Create("name", 1), dictionary["name"]);
            Assert.AreEqual(Tuple.Create("name2", 2), dictionary["name2"]);
            Assert.AreEqual(Tuple.Create("name3", 3), dictionary["name3"]);
            Assert.AreEqual(Tuple.Create("NAME", 3), dictionary["NAME"]);
        }
        
        /// <summary>
        /// Creates a dictionary from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionarySelector()
        {
            var dictionary = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
            Assert.AreEqual(4, dictionary.Count);
            Assert.IsTrue(dictionary.ContainsKey("name"));
            Assert.IsTrue(dictionary.ContainsKey("name2"));
            Assert.IsTrue(dictionary.ContainsKey("name3"));
            Assert.IsTrue(dictionary.ContainsKey("NAME"));
            Assert.AreEqual(1, dictionary["name"]);
            Assert.AreEqual(2, dictionary["name2"]);
            Assert.AreEqual(3, dictionary["name3"]);
            Assert.AreEqual(3, dictionary["NAME"]);
        }

        /// <summary>
        /// Creates a dictionary from an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionarySelectorEmpty()
        {
            var dictionary = Enumerable.Empty<Tuple<string, int>>().ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
            Assert.AreEqual(0, dictionary.Count);
        }
        
        /// <summary>
        /// Creates a dictionary from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerSelector()
        {
            var dictionary = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.Ordinal);
            Assert.AreEqual(4, dictionary.Count);
            Assert.IsTrue(dictionary.ContainsKey("name"));
            Assert.IsTrue(dictionary.ContainsKey("name2"));
            Assert.IsTrue(dictionary.ContainsKey("name3"));
            Assert.IsTrue(dictionary.ContainsKey("NAME"));
            Assert.AreEqual(1, dictionary["name"]);
            Assert.AreEqual(2, dictionary["name2"]);
            Assert.AreEqual(3, dictionary["name3"]);
            Assert.AreEqual(3, dictionary["NAME"]);
        }

        /// <summary>
        /// Creates a dictionary from an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerSelectorEmpty()
        {
            var dictionary = Enumerable.Empty<Tuple<string, int>>().ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.Ordinal);
            Assert.AreEqual(0, dictionary.Count);
        }

        /// <summary>
        /// Creates a dictionary from a sequence with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a dictionary from a sequence with a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void ToDictionaryComparerSelectorNullComparer()
        {
            var dictionary = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2, null);
            Assert.AreEqual(4, dictionary.Count);
            Assert.IsTrue(dictionary.ContainsKey("name"));
            Assert.IsTrue(dictionary.ContainsKey("name2"));
            Assert.IsTrue(dictionary.ContainsKey("name3"));
            Assert.IsTrue(dictionary.ContainsKey("NAME"));
            Assert.AreEqual(1, dictionary["name"]);
            Assert.AreEqual(2, dictionary["name2"]);
            Assert.AreEqual(3, dictionary["name3"]);
            Assert.AreEqual(3, dictionary["NAME"]);
        }
    }
}
