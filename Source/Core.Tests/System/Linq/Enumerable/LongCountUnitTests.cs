namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    using Fx;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountEmpty()
        {
            Assert.AreEqual(0, Enumerable.Empty<string>().LongCount());
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountPredicateEmpty()
        {
            Assert.AreEqual(0, Enumerable.Empty<string>().LongCount(value => true));
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountSingle()
        {
            Assert.AreEqual(1, new[] { 1 }.LongCount());
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountMany()
        {
            Assert.AreEqual(6, new[] { 1, 2, 3, 4, 5, 6 }.LongCount());
        }

        /// <summary>
        /// Counts the number of elements in a sequence when no elements match
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in a sequence when no elements match")]
        [Priority(1)]
        [TestMethod]
        public void LongCountPredicateNoMatches()
        {
            Assert.AreEqual(0, new[] { 1, 2, 3, 4, 5, 6 }.LongCount(value => value < 1));
        }

        /// <summary>
        /// Counts the number of elements in a sequence when some elements match
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in a sequence when some elements match")]
        [Priority(1)]
        [TestMethod]
        public void LongCountPredicateSomeMatches()
        {
            Assert.AreEqual(2, new[] { 1, 2, 3, 4, 5, 6 }.LongCount(value => value < 3));
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountGenericCollection()
        {
            var collection = new Collection<string>(Enumerable.Empty<string>());
            Assert.AreEqual(0, collection.LongCount());
        }

        /// <summary>
        /// Counts the number of elements in an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Counts the number of elements in an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void LongCountCollection()
        {
            var collection = new OtherCollection<string>(new string[0]);
            Assert.AreEqual(0, collection.LongCount());
        }

        /// <summary>
        /// A <see cref="ICollection"/> implementation that always returns 11 as its length
        /// </summary>
        /// <typeparam name="T">The type of elements within the <see cref="ICollection{T}"/></typeparam>
        /// <threadsafety static="true" instance="true"/>
        private sealed class OtherCollection<T> : ICollection, IEnumerable<T>
        {
            /// <summary>
            /// The data that is stored in this <see cref="ICollection"/>
            /// </summary>
            private readonly List<T> data;

            /// <summary>
            /// Initializes a new instance of the <see cref="OtherCollection{T}"/> class
            /// </summary>
            /// <param name="data">The data that the new <see cref="OtherCollection{T}"/> should contain</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="data"/> is null</exception>
            public OtherCollection(IEnumerable<T> data)
            {
                Ensure.NotNull(data, nameof(data));

                this.data = new List<T>(data);
            }

            /// <summary>
            /// Gets 11
            /// </summary>
            public int Count
            {
                get
                {
                    return 11;
                }
            }

            /// <summary>
            /// Gets a value indicating whether access to the <see cref="ICollection"/> is synchronized (thread safe).
            /// </summary>
            public bool IsSynchronized
            {
                get
                {
                    return ((ICollection)this.data).IsSynchronized;
                }
            }

            /// <summary>
            /// Gets an object that can be used to synchronize access to the <see cref="ICollection"/>
            /// </summary>
            public object SyncRoot
            {
                get
                {
                    return ((ICollection)this.data).SyncRoot;
                }
            }

            /// <summary>
            /// Copies the elements of the <see cref="ICollection"/> to an <see cref="Array"/>, starting at a particular <see cref="Array"/> index
            /// </summary>
            /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ICollection"/>. The <see cref="Array"/> must have zero-based indexing</param>
            /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="array"/> is null</exception>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is less than zero</exception>
            /// <exception cref="ArgumentException">Thrown if <paramref name="array"/> is multidimensional or the number of elements in the source <see cref="ICollection"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/> or the type of the source <see cref="ICollection"/> cannot be cast automatically to the type of the destination <paramref name="array"/></exception>
            public void CopyTo(Array array, int index)  
            {
                ((ICollection)this.data).CopyTo(array, index);
            }

            /// <summary>
            /// Returns an enumerator that iterates through a collection
            /// </summary>
            /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection</returns>
            public IEnumerator GetEnumerator()
            {
                return this.data.GetEnumerator();
            }

            /// <summary>
            /// Returns an enumerator that iterates through the collection
            /// </summary>
            /// <returns>An enumerator that can be used to iterate through the collection</returns>
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                return this.data.GetEnumerator();
            }
        }

        /// <summary>
        /// A <see cref="ICollection{T}"/> implementation that always returns false that an element is contained within it and always returns 10 as its length
        /// </summary>
        /// <typeparam name="T">The type of elements within the <see cref="ICollection{T}"/></typeparam>
        /// <threadsafety static="true" instance="true"/>
        private sealed class Collection<T> : ICollection<T>, ICollection
        {
            /// <summary>
            /// The data that is stored in this <see cref="ICollection{T}"/>
            /// </summary>
            private readonly List<T> data;

            /// <summary>
            /// Initializes a new instance of the <see cref="Collection{T}"/> class
            /// </summary>
            /// <param name="data">The data that is stored in the resulting <see cref="Collection{T}"/></param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="data"/> is null</exception>
            public Collection(IEnumerable<T> data)
            {
                Ensure.NotNull(data, nameof(data));

                this.data = new List<T>(data);
            }

            /// <summary>
            /// Gets 10
            /// </summary>
            public int Count
            {
                get
                {
                    return 10;
                }
            }

            /// <summary>
            /// Gets 11
            /// </summary>
            int ICollection.Count
            {
                get
                {
                    return 11;
                }
            }

            /// <summary>
            /// Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only 
            /// </summary>
            public bool IsReadOnly
            {
                get
                {
                    return this.data.AsCollection().IsReadOnly;
                }
            }

            /// <summary>
            /// Gets a value indicating whether access to the <see cref="ICollection"/> is synchronized (thread safe).
            /// </summary>
            public bool IsSynchronized
            {
                get
                {
                    return ((ICollection)this.data).IsSynchronized;
                }
            }

            /// <summary>
            /// Gets an object that can be used to synchronize access to the <see cref="ICollection"/>
            /// </summary>
            public object SyncRoot
            {
                get
                {
                    return ((ICollection)this.data).SyncRoot;
                }
            }

            /// <summary>
            /// Adds an item to the <see cref="ICollection{T}"/>
            /// </summary>
            /// <param name="item">The object to add to the <see cref="ICollection{T}"/></param>
            public void Add(T item)
            {
                this.data.Add(item);
            }

            /// <summary>
            /// Removes all items from the <see cref="ICollection{T}"/>
            /// </summary>
            public void Clear()
            {
                this.data.Clear();
            }

            /// <summary>
            /// Never contains any elements
            /// </summary>
            /// <param name="item">The item we want to determine is in the <see cref="ICollection{T}"/> or not</param>
            /// <returns>Returns false</returns>
            public bool Contains(T item)
            {
                return false;
            }

            /// <summary>
            /// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="Array"/>, starting at a particular <see cref="Array"/> index
            /// </summary>
            /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ICollection{T}"/>. The <see cref="Array"/> must have zero-based indexing</param>
            /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="array"/> is null</exception>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="arrayIndex"/> is less than 0</exception>
            /// <exception cref="ArgumentException">The number of elements in the source <see cref="ICollection{T}"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/></exception>
            public void CopyTo(T[] array, int arrayIndex)
            {
                this.data.CopyTo(array, arrayIndex);
            }

            /// <summary>
            /// Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>
            /// </summary>
            /// <param name="item">The object to remove from the <see cref="ICollection{T}"/></param>
            /// <returns>true if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="ICollection{T}"/></returns>
            public bool Remove(T item)
            {
                return this.data.Remove(item);
            }

            /// <summary>
            /// Returns an enumerator that iterates through the collection
            /// </summary>
            /// <returns>An enumerator that can be used to iterate through the collection</returns>
            public IEnumerator<T> GetEnumerator()
            {
                return this.data.GetEnumerator();
            }

            /// <summary>
            /// Returns an enumerator that iterates through a collection
            /// </summary>
            /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this.data).GetEnumerator();
            }

            /// <summary>
            /// Copies the elements of the <see cref="ICollection"/> to an <see cref="Array"/>, starting at a particular <see cref="Array"/> index
            /// </summary>
            /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ICollection"/>. The <see cref="Array"/> must have zero-based indexing</param>
            /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="array"/> is null</exception>
            /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="index"/> is less than zero</exception>
            /// <exception cref="ArgumentException">Thrown if <paramref name="array"/> is multidimensional or the number of elements in the source <see cref="ICollection"/> is greater than the available space from <paramref name="index"/> to the end of the destination <paramref name="array"/> or the type of the source <see cref="ICollection"/> cannot be cast automatically to the type of the destination <paramref name="array"/></exception>
            public void CopyTo(Array array, int index)
            {
                ((ICollection)this.data).CopyTo(array, index);
            }
        }
    }
}
