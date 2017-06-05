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
        /// Creates a lookup from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookup()
        {
            var lookup = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToLookup(tuple => tuple.Item1);
            Assert.AreEqual(4, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            Assert.IsTrue(lookup.Contains("name3"));
            Assert.IsTrue(lookup.Contains("NAME"));
            CollectionAssert.AreEqual(new[] { Tuple.Create("name", 1) }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name2", 2) }, lookup["name2"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name3", 3) }, lookup["name3"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("NAME", 3) }, lookup["NAME"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }
        
        /// <summary>
        /// Creates a lookup from an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupEmpty()
        {
            var lookup = Enumerable.Empty<Tuple<string, int>>().ToLookup(tuple => tuple.Item1);
            Assert.AreEqual(0, lookup.Count);

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparer()
        {
            var lookup = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToLookup(tuple => tuple.Item1, StringComparer.Ordinal);
            Assert.AreEqual(4, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            Assert.IsTrue(lookup.Contains("name3"));
            Assert.IsTrue(lookup.Contains("NAME"));
            CollectionAssert.AreEqual(new[] { Tuple.Create("name", 1) }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name2", 2) }, lookup["name2"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name3", 3) }, lookup["name3"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("NAME", 3) }, lookup["NAME"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerEmpty()
        {
            var lookup = Enumerable.Empty<Tuple<string, int>>().ToLookup(tuple => tuple.Item1, StringComparer.Ordinal);
            Assert.AreEqual(0, lookup.Count);

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerNullComparer()
        {
            var lookup = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToLookup(tuple => tuple.Item1, null);
            Assert.AreEqual(4, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            Assert.IsTrue(lookup.Contains("name3"));
            Assert.IsTrue(lookup.Contains("NAME"));
            CollectionAssert.AreEqual(new[] { Tuple.Create("name", 1) }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name2", 2) }, lookup["name2"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name3", 3) }, lookup["name3"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("NAME", 3) }, lookup["NAME"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupSelector()
        {
            var lookup = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToLookup(tuple => tuple.Item1, tuple => tuple.Item2);
            Assert.AreEqual(4, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            Assert.IsTrue(lookup.Contains("name3"));
            Assert.IsTrue(lookup.Contains("NAME"));
            CollectionAssert.AreEqual(new[] { 1 }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { 2 }, lookup["name2"].ToList());
            CollectionAssert.AreEqual(new[] { 3 }, lookup["name3"].ToList());
            CollectionAssert.AreEqual(new[] { 3 }, lookup["NAME"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupSelectorEmpty()
        {
            var lookup = Enumerable.Empty<Tuple<string, int>>().ToLookup(tuple => tuple.Item1, tuple => tuple.Item2);
            Assert.AreEqual(0, lookup.Count);

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerSelector()
        {
            var lookup = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToLookup(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.Ordinal);
            Assert.AreEqual(4, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            Assert.IsTrue(lookup.Contains("name3"));
            Assert.IsTrue(lookup.Contains("NAME"));
            CollectionAssert.AreEqual(new[] { 1 }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { 2 }, lookup["name2"].ToList());
            CollectionAssert.AreEqual(new[] { 3 }, lookup["name3"].ToList());
            CollectionAssert.AreEqual(new[] { 3 }, lookup["NAME"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerSelectorEmpty()
        {
            var lookup = Enumerable.Empty<Tuple<string, int>>().ToLookup(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.Ordinal);
            Assert.AreEqual(0, lookup.Count);

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a null comparer")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerSelectorNullComparer()
        {
            var lookup = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) }
                .ToLookup(tuple => tuple.Item1, tuple => tuple.Item2, null);
            Assert.AreEqual(4, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            Assert.IsTrue(lookup.Contains("name3"));
            Assert.IsTrue(lookup.Contains("NAME"));
            CollectionAssert.AreEqual(new[] { 1 }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { 2 }, lookup["name2"].ToList());
            CollectionAssert.AreEqual(new[] { 3 }, lookup["name3"].ToList());
            CollectionAssert.AreEqual(new[] { 3 }, lookup["NAME"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a duplicate key
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a duplicate key")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupDuplicateKey()
        {
            var lookup = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name", 3) }.ToLookup(tuple => tuple.Item1);
            Assert.AreEqual(2, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            CollectionAssert.AreEqual(new[] { Tuple.Create("name",  1), Tuple.Create("name", 3) }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name2", 2) }, lookup["name2"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null selector
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupSelectorDuplicateKey()
        {
            var lookup = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name", 3) }
                .ToLookup(tuple => tuple.Item1, tuple => tuple.Item2);
            Assert.AreEqual(2, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            CollectionAssert.AreEqual(new[] { 1, 3 }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { 2 }, lookup["name2"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a null selector
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerSelectorDuplicateKey()
        {
            var lookup = new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name", 3)
                }.ToLookup(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.Ordinal);
            Assert.AreEqual(2, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            CollectionAssert.AreEqual(new[] { 1, 3 }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { 2 }, lookup["name2"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a case insensitive comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a case insensitive comparer")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerSelectorCaseInsensitive()
        {
            var lookup = new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToLookup(tuple => tuple.Item1, tuple => tuple.Item2, StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(3, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            Assert.IsTrue(lookup.Contains("name3"));
            Assert.IsTrue(lookup.Contains("NAME"));
            Assert.IsTrue(lookup.Contains("NaMe"));
            CollectionAssert.AreEqual(new[] { 1, 3 }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { 2 }, lookup["name2"].ToList());
            CollectionAssert.AreEqual(new[] { 3 }, lookup["name3"].ToList());
            CollectionAssert.AreEqual(new[] { 1, 3 }, lookup["NAME"].ToList());
            CollectionAssert.AreEqual(new[] { 1, 3 }, lookup["NaMe"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }
        
        /// <summary>
        /// Creates a lookup from a sequence with a null selector
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a null selector")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerDuplicateKey()
        {
            var lookup = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name", 3) }
                .ToLookup(tuple => tuple.Item1, StringComparer.Ordinal);
            Assert.AreEqual(2, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            Assert.IsFalse(lookup.Contains("NAME"));
            CollectionAssert.AreEqual(new[] { Tuple.Create("name", 1), Tuple.Create("name", 3) }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name2", 2) }, lookup["name2"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a case insensitive comparer
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a case insensitive comparer")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupComparerCaseInsensitive()
        {
            var lookup = new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToLookup(tuple => tuple.Item1, StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(3, lookup.Count);
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains("name2"));
            Assert.IsTrue(lookup.Contains("name3"));
            Assert.IsTrue(lookup.Contains("NAME"));
            Assert.IsTrue(lookup.Contains("NaMe"));
            CollectionAssert.AreEqual(new[] { Tuple.Create("name", 1), Tuple.Create("NAME", 3) }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name2", 2) }, lookup["name2"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name3", 3) }, lookup["name3"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name", 1), Tuple.Create("NAME", 3) }, lookup["NAME"].ToList());
            CollectionAssert.AreEqual(new[] { Tuple.Create("name", 1), Tuple.Create("NAME", 3) }, lookup["NaMe"].ToList());

            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a key selector that returns null
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a key selector that returns null")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupKeySelectorNull()
        {
            var expected = new[] { Tuple.Create("name", 1), Tuple.Create("name2", 2), Tuple.Create("name3", 3), Tuple.Create("NAME", 3) };

            Func<Tuple<string, int>, object> keySelector = tuple => null;
            var lookup = new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToLookup(keySelector);
            Assert.AreEqual(1, lookup.Count);
            Assert.IsTrue(lookup.Contains(null));
            CollectionAssert.AreEqual(expected, lookup[null].ToList());
            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());

            lookup = new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToLookup(keySelector, EqualityComparer<object>.Default);
            Assert.AreEqual(1, lookup.Count);
            Assert.IsTrue(lookup.Contains(null));
            CollectionAssert.AreEqual(expected, lookup[null].ToList());
            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());

            lookup = new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToLookup(keySelector, value => value, EqualityComparer<object>.Default);
            Assert.AreEqual(1, lookup.Count);
            Assert.IsTrue(lookup.Contains(null));
            CollectionAssert.AreEqual(expected, lookup[null].ToList());
            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());

            lookup = new[]
                {
                    Tuple.Create("name", 1),
                    Tuple.Create("name2", 2),
                    Tuple.Create("name3", 3),
                    Tuple.Create("NAME", 3)
                }.ToLookup(keySelector, value => value);
            Assert.AreEqual(1, lookup.Count);
            Assert.IsTrue(lookup.Contains(null));
            CollectionAssert.AreEqual(expected, lookup[null].ToList());
            Assert.IsFalse(lookup.Contains("asdf"));
            CollectionAssert.AreEqual(new Tuple<string, int>[0], lookup["asdf"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a comparer that declares null equivalent to an instance object
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a comparer that declares null equivalent to an instance object")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupNullEquivalentToInstance()
        {
            var lookup = new[] { string.Empty, "name", null, "name2" }.ToLookup(element => element, NullEqualsEmptyComparer.Instance);
            Assert.AreEqual(4, lookup.Count);
            Assert.IsTrue(lookup.Contains(string.Empty));
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains(null));
            Assert.IsTrue(lookup.Contains("name2"));
            CollectionAssert.AreEqual(new[] { string.Empty }, lookup[string.Empty].ToList());
            CollectionAssert.AreEqual(new[] { "name" }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { (string)null }, lookup[null].ToList());
            CollectionAssert.AreEqual(new[] { "name2" }, lookup["name2"].ToList());
        }

        /// <summary>
        /// Creates a lookup from a sequence with a comparer that declares an instance object equivalent to null
        /// </summary>
        [TestCategory("Unit")]
        [Description("Creates a lookup from a sequence with a comparer that declares an instance object equivalent to null")]
        [Priority(1)]
        [TestMethod]
        public void ToLookupInstanceEquivalentToNull()
        {
            var lookup = new[] { string.Empty, "name", null, "name2" }.ToLookup(element => element, EmptyEqualsNullComparer.Instance);
            Assert.AreEqual(3, lookup.Count);
            Assert.IsTrue(lookup.Contains(string.Empty));
            Assert.IsTrue(lookup.Contains("name"));
            Assert.IsTrue(lookup.Contains(null));
            Assert.IsTrue(lookup.Contains("name2"));
            CollectionAssert.AreEqual(new[] { string.Empty, null }, lookup[string.Empty].ToList());
            CollectionAssert.AreEqual(new[] { "name" }, lookup["name"].ToList());
            CollectionAssert.AreEqual(new[] { string.Empty, null }, lookup[null].ToList());
            CollectionAssert.AreEqual(new[] { "name2" }, lookup["name2"].ToList());
        }

        /// <summary>
        /// A <see cref="IEqualityComparer{T}"/> which indicates that <see cref="string.Empty"/> has the same hash code as null and that they are "equal"
        /// </summary>
        private sealed class EmptyEqualsNullComparer : IEqualityComparer<string>
        {
            /// <summary>
            /// Prevents a default instance of the <see cref="EmptyEqualsNullComparer"/> class from being created
            /// </summary>
            private EmptyEqualsNullComparer()
            {
            }

            /// <summary>
            /// Gets a singleton instance of the <see cref="EmptyEqualsNullComparer"/>
            /// </summary>
            public static EmptyEqualsNullComparer Instance { get; } = new EmptyEqualsNullComparer();

            /// <summary>
            /// Determines whether the specified objects are equal
            /// </summary>
            /// <param name="x">The first <see cref="string"/> to compare</param>
            /// <param name="y">The second <see cref="string"/> to compare</param>
            /// <returns>true if the specified objects are equal; otherwise, false</returns>
            public bool Equals(string x, string y)
            {
                if (x == string.Empty && y == null)
                {
                    return true;
                }
                else if (x == null && y == string.Empty)
                {
                    return true;
                }
                else if (x == null && y == null)
                {
                    return true;
                }
                else
                {
                    return StringComparer.Ordinal.Equals(x, y);
                }
            }

            /// <summary>
            /// Returns a hash code for the specified object
            /// </summary>
            /// <param name="obj">The <see cref="string"/> for which a hash code is to be returned</param>
            /// <returns>A hash code for the specified object</returns>
            public int GetHashCode(string obj)
            {
                return string.IsNullOrEmpty(obj) ? 0 : StringComparer.Ordinal.GetHashCode(obj);
            }
        }

        /// <summary>
        /// A <see cref="IEqualityComparer{T}"/> which indicates that null has the same hash code as <see cref="string.Empty"/> and that they are "equal"
        /// </summary>
        private sealed class NullEqualsEmptyComparer : IEqualityComparer<string>
        {
            /// <summary>
            /// Prevents a default instance of the <see cref="NullEqualsEmptyComparer"/> class from being created
            /// </summary>
            private NullEqualsEmptyComparer()
            {
            }

            /// <summary>
            /// Gets a singleton instance of the <see cref="NullEqualsEmptyComparer"/>
            /// </summary>
            public static NullEqualsEmptyComparer Instance { get; } = new NullEqualsEmptyComparer();

            /// <summary>
            /// Determines whether the specified objects are equal
            /// </summary>
            /// <param name="x">The first <see cref="string"/> to compare</param>
            /// <param name="y">The second <see cref="string"/> to compare</param>
            /// <returns>true if the specified objects are equal; otherwise, false</returns>
            public bool Equals(string x, string y)
            {
                if (x == string.Empty && y == null)
                {
                    return true;
                }
                else if (x == null && y == string.Empty)
                {
                    return true;
                }
                else if (x == null && y == null)
                {
                    return true;
                }
                else
                {
                    return StringComparer.Ordinal.Equals(x, y);
                }
            }

            /// <summary>
            /// Returns a hash code for the specified object
            /// </summary>
            /// <param name="obj">The <see cref="string"/> for which a hash code is to be returned</param>
            /// <returns>A hash code for the specified object</returns>
            public int GetHashCode(string obj)
            {
                return StringComparer.Ordinal.GetHashCode(obj ?? string.Empty);
            }
        }
    }
}
