#if !NET35
namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Creates a <see cref="Lookup{TKey, TElement}"/> from an <see cref="IEnumerable{T}"/> according to a specified key selector function and key comparer
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="Lookup{TKey, TElement}"/> from</param>
        /// <param name="keySelector">A function to extract a key from each element</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys</param>
        /// <returns>A <see cref="Lookup{TKey, TElement}"/> that contains keys and values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null</exception>
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return ToLookup(source, keySelector, element => element, comparer);
        }

        /// <summary>
        /// Creates a <see cref="Lookup{TKey, TElement}"/> from an <see cref="IEnumerable{T}"/> according to a specified key selector function
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="Lookup{TKey, TElement}"/> from</param>
        /// <param name="keySelector">A function to extract a key from each element</param>
        /// <returns>A <see cref="Lookup{TKey, TElement}"/> that contains keys and values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null</exception>
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return ToLookup(source, keySelector, element => element, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Creates a <see cref="Lookup{TKey, TElement}"/> from an <see cref="IEnumerable{T}"/> according to specified key selector and element selector functions
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="Lookup{TKey, TElement}"/> from</param>
        /// <param name="keySelector">A function to extract a key from each element</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element</param>
        /// <returns>A <see cref="Lookup{TKey, TElement}"/> that contains values of type <typeparamref name="TElement"/> selected from the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null</exception>
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return ToLookup(source, keySelector, elementSelector, EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// Creates a <see cref="Lookup{TKey, TElement}"/> from an <see cref="IEnumerable{T}"/> according to a specified key selector function, a comparer and an element selector function
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the elements of <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to create a <see cref="Lookup{TKey, TElement}"/>from</param>
        /// <param name="keySelector">A function to extract a key from each element</param>
        /// <param name="elementSelector">A transform function to produce a result element value from each element</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys</param>
        /// <returns>A <see cref="Lookup{TKey, TElement}"/> that contains values of type <typeparamref name="TElement"/> selected from the input sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null</exception>
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));
            Ensure.NotNull(elementSelector, nameof(elementSelector));

            var dictionary = new Dictionary<Pointer<TKey>, List<TElement>>(new LookupComparer<TKey>(comparer ?? EqualityComparer<TKey>.Default));
            foreach (var element in source)
            {
                var key = new Pointer<TKey>(keySelector(element));
                List<TElement> values;
                if (!dictionary.TryGetValue(key, out values))
                {
                    values = new List<TElement>();
                    dictionary[key] = values;
                }

                values.Add(elementSelector(element));
            }

            return new Lookup<TKey, TElement>(dictionary.ToReadOnlyDictionary());
        }

        /// <summary>
        /// A reference to an instance of a type
        /// </summary>
        /// <typeparam name="T">The type that is being referenced</typeparam>
        /// <threadsafety static="true" instance="true"/>
        private struct Pointer<T>
        {
            /// <summary>
            /// The value of the type being referenced
            /// </summary>
            private readonly T value;

            /// <summary>
            /// Initializes a new instance of the <see cref="Pointer{T}"/> struct
            /// </summary>
            /// <param name="value">The value that should be referenced in the new instance</param>
            public Pointer(T value)
            {
                this.value = value;
            }

            /// <summary>
            /// Gets the value of the type being referenced
            /// </summary>
            public T Value
            {
                get
                {
                    return this.value;
                }
            }
        }

        /// <summary>
        /// A <see cref="IEqualityComparer{T}"/> that compares the values referenced by <see cref="Pointer{T}"/>s
        /// </summary>
        /// <typeparam name="T">The type being referenced by the <see cref="Pointer{T}"/> that should be compared</typeparam>
        /// <threadsafety static="true" instance="true"/>
        private sealed class LookupComparer<T> : IEqualityComparer<Pointer<T>>
        {
            /// <summary>
            /// The <see cref="IEqualityComparer{T}"/> which compares the values being referenced by the <see cref="Pointer{T}"/>s being compared
            /// </summary>
            private readonly IEqualityComparer<T> comparer;

            /// <summary>
            /// Initializes a new instance of the <see cref="LookupComparer{T}"/> class
            /// </summary>
            /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> which compares the values being referenced by the <see cref="Pointer{T}"/>s being compared</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null</exception>
            public LookupComparer(IEqualityComparer<T> comparer)
            {
                Ensure.NotNull(comparer, nameof(comparer));

                this.comparer = comparer;
            }

            /// <summary>
            /// Determines whether the specified objects are equal
            /// </summary>
            /// <param name="x">The first <see cref="Pointer{T}"/> to compare</param>
            /// <param name="y">The second <see cref="Pointer{T}"/> to compare</param>
            /// <returns>true if the specified objects are equal; otherwise, false</returns>
            public bool Equals(Pointer<T> x, Pointer<T> y)
            {
                return this.comparer.Equals(x.Value, y.Value);
            }

            /// <summary>
            /// Returns a hash code for the specified object
            /// </summary>
            /// <param name="obj">The <see cref="Pointer{T}"/> for which a hash code is to be returned</param>
            /// <returns>A hash code for the specified object</returns>
            public int GetHashCode(Pointer<T> obj)
            {
                if (obj.Value == null)
                {
                    return 0;
                }

                return this.comparer.GetHashCode(obj.Value);
            }
        }

        /// <summary>
        /// Represents a mapping from a key to a sequence of elements associated with that key
        /// </summary>
        /// <typeparam name="TKey">The type of the keys contained in the mapping</typeparam>
        /// <typeparam name="TElement">The type of the elements whose sequences are associated with a <typeparamref name="TKey"/></typeparam>
        /// <threadsafety static="true" instance="true"/>
        private sealed class Lookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>, ILookup<TKey, TElement>
        {
            /// <summary>
            /// The mapping from a keys to their sequences of associated elements
            /// </summary>
            private readonly IReadOnlyDictionary<Pointer<TKey>, List<TElement>> dictionary;

            /// <summary>
            /// Initializes a new instance of the <see cref="Lookup{TKey, TElement}"/> class
            /// </summary>
            /// <param name="dictionary">The mapping from keys to their sequences of associated elements</param>
            public Lookup(IReadOnlyDictionary<Pointer<TKey>, List<TElement>> dictionary)
            {
                this.dictionary = dictionary;
            }

            /// <summary>
            /// Gets the number of key/value collection pairs in the <see cref="ILookup{TKey, TElement}"/>
            /// </summary>
            public int Count
            {
                get
                {
                    return this.dictionary.Count;
                }
            }

            /// <summary>
            /// Gets the <see cref="IEnumerable{T}"/> sequence of values indexed by a specified key
            /// </summary>
            /// <param name="key">The key of the desired sequence of values</param>
            /// <returns>The <see cref="IEnumerable{T}"/> sequence of values indexed by the specified key</returns>
            public IEnumerable<TElement> this[TKey key]
            {
                get
                {
                    List<TElement> values;
                    if (!this.dictionary.TryGetValue(new Pointer<TKey>(key), out values))
                    {
                        return Empty<TElement>();
                    }

                    return Enumerate(values);
                }
            }

            /// <summary>
            /// Determines whether a specified key exists in the <see cref="ILookup{TKey, TElement}"/>
            /// </summary>
            /// <param name="key">The key to search for in the <see cref="ILookup{TKey, TElement}"/></param>
            /// <returns>true if <paramref name="key"/> is in the <see cref="ILookup{TKey, TElement}"/>; otherwise, false</returns>
            public bool Contains(TKey key)
            {
                return this.dictionary.ContainsKey(new Pointer<TKey>(key));
            }

            /// <summary>
            /// Returns an enumerator that iterates through the <see cref="Grouping"/>
            /// </summary>
            /// <returns>An enumerator for the contents of the <see cref="Grouping"/></returns>
            public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
            {
                foreach (var element in this.dictionary.Select(kvp => new Grouping(kvp.Key.Value, kvp.Value)))
                {
                    yield return element;
                }
            }

            /// <summary>
            /// Returns an enumerator that iterates through a collection
            /// </summary>
            /// <returns>An <see cref="IEnumerator"/> that can be used to iterate through the collection</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            /// <summary>
            /// Produces an iterator of the elements of <paramref name="source"/> so as to hide the underlying type of <paramref name="source"/>
            /// </summary>
            /// <typeparam name="T">The type of the elements of <paramref name="source"/></typeparam>
            /// <param name="source">The <see cref="IEnumerable{T}"/> to hide the underlying type of</param>
            /// <returns>An iterator of the elements of <paramref name="source"/> so as to hide the underlying type of <paramref name="source"/></returns>
            private static IEnumerable<T> Enumerate<T>(IEnumerable<T> source)
            {
                foreach (var element in source)
                {
                    yield return element;
                }
            }

            /// <summary>
            /// Represents a sequence of elements that all have the same key
            /// </summary>
            /// <threadsafety static="true" instance="true"/>
            private sealed class Grouping : IGrouping<TKey, TElement>
            {
                /// <summary>
                /// The key that applies to each contained element
                /// </summary>
                private readonly TKey key;

                /// <summary>
                /// The elements that all have the key <see cref="key"/>
                /// </summary>
                private readonly IEnumerable<TElement> values;

                /// <summary>
                /// Initializes a new instance of the <see cref="Grouping"/> class
                /// </summary>
                /// <param name="key">The key that applies to each contained element</param>
                /// <param name="values">The elements that all have the key <paramref name="key"/></param>
                public Grouping(TKey key, IEnumerable<TElement> values)
                {
                    this.key = key;
                    this.values = values;
                }

                /// <summary>
                /// Gets the key of the <see cref="IGrouping{TKey, TElement}"/>
                /// </summary>
                public TKey Key
                {
                    get
                    {
                        return this.key;
                    }
                }

                /// <summary>
                /// Returns an enumerator that iterates through the <see cref="Grouping"/>
                /// </summary>
                /// <returns>An enumerator for the contents of the <see cref="Grouping"/></returns>
                public IEnumerator<TElement> GetEnumerator()
                {
                    return Enumerate(this.values).GetEnumerator();
                }

                /// <summary>
                /// Returns an enumerator that iterates through a collection
                /// </summary>
                /// <returns>An <see cref="IEnumerator"/> that can be used to iterate through the collection</returns>
                IEnumerator IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
            }
        }
    }
}
#endif