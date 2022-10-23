namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System.Collections.Generic;
    using Collections;

    public static class InPlaceExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable, Random random)
        {
            //// TODO
            //// need count | need to modify collection | use-case
            //// T          | T                         | shuffle
            //// T          | F                         | binary search
            //// F          | T                         | TODO
            //// F          | F                         | TODO
            using (var enumerator = enumerable.GetEnumerator())
            {
                return new InPlaceList<T>(enumerator).Shuffle(random);
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IList<T> list, Random random)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                var next = random.Next(i, list.Count);
                var temp = list[next];
                list[next] = list[i];
                list[i] = temp;
                yield return list[i];
            }
        }

        private sealed class InPlaceList<T> : IList<T>
        {
            private readonly IEnumerator<T> enumerator;

            private readonly IDictionary<int, T> delta;

            private readonly IList<T> enumerated;

            public InPlaceList(IEnumerator<T> enumerator)
            {
                this.enumerator = enumerator; //// TODO probably we need the count in the sequence

                this.delta = new Dictionary<int, T>();
                this.enumerated = new List<T>();
            }

            public T this[int index]
            {
                get
                {
                    if (index < this.enumerated.Count)
                    {
                        return this.enumerated[index];
                    }

                    T value;
                    if (this.delta.TryGetValue(index, out value))
                    {
                        return value;
                    }

                    while (index >= this.enumerated.Count && this.enumerator.MoveNext())
                    {
                        if (this.delta.TryGetValue(this.enumerated.Count - 1, out value))
                        {
                            this.enumerated.Add(value);
                            this.delta.Remove(this.enumerated.Count);
                        }
                        else
                        {
                            this.enumerated.Add(this.enumerator.Current);
                        }
                    }

                    return this.enumerated[index];
                }

                set
                {
                    if (index < this.enumerated.Count)
                    {
                        this.enumerated[index] = value;
                    }
                    else
                    {
                        this.delta[index] = value;
                    }
                }
            }

            public int Count
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void Add(T item)
            {
                if (this.enumerated.Count == this.count)
                {
                    this.enumerated.Add(item);
                }
                else
                {
                    this.delta.Add(this.count, item);
                    ++this.count;
                }
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(T item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public int IndexOf(T item)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, T item)
            {
                throw new NotImplementedException();
            }

            public bool Remove(T item)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Determines if there are any elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void AnyEmpty()
        {
            Assert.AreEqual(false, Enumerable.Empty<string>().Any());
        }

        /// <summary>
        /// Determines if there are any elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void AnyPredicateEmpty()
        {
            Assert.AreEqual(false, Enumerable.Empty<string>().Any(val => true));
        }

        /// <summary>
        /// Determines if there are any elements in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void AnySingle()
        {
            Assert.AreEqual(true, new[] { 1 }.Any());
        }

        /// <summary>
        /// Determines if there are any elements in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void AnySingleFalsePredicate()
        {
            Assert.AreEqual(false, new[] { 1 }.Any(val => false));
        }

        /// <summary>
        /// Determines if there are any elements in a sequence with one element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence with one element")]
        [Priority(1)]
        [TestMethod]
        public void AnySingleTruePredicate()
        {
            Assert.AreEqual(true, new[] { 1 }.Any(val => true)); 
        }

        /// <summary>
        /// Determines if there are any elements in a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Any()
        {
            Assert.AreEqual(true, new[] { 1, 2, 3, 4, 5, 6 }.Any());
        }

        /// <summary>
        /// Determines if there are any elements in a sequence that match a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence that match a condition")]
        [Priority(1)]
        [TestMethod]
        public void AnyPredicateTrue()
        {
            Assert.AreEqual(true, new[] { 1, 2, 3, 4, 5, 6 }.Any(val => val > 4));
        }

        /// <summary>
        /// Determines if there are any elements in a sequence that match a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence that match a condition")]
        [Priority(1)]
        [TestMethod]
        public void AnyPredicateFalse()
        {
            Assert.AreEqual(false, new[] { 1, 2, 3, 4, 5, 6 }.Any(val => val < 0));
        }
    }
}
