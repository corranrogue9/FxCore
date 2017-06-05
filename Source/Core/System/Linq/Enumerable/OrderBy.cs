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
        /// Sorts the elements of a sequence in ascending order according to a key
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">A sequence of values to order</param>
        /// <param name="keySelector">A function to extract a key from an element</param>
        /// <returns>An <see cref="IOrderedEnumerable{TElement}"/> whose elements are sorted according to a key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null</exception>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return OrderBy(source, keySelector, null);
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by using a specified comparer
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">A sequence of values to order</param>
        /// <param name="keySelector">A function to extract a key from an element</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys</param>
        /// <returns>An <see cref="IOrderedEnumerable{TElement}"/> whose elements are sorted according to a key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null</exception>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));

            return new OrderedEnumerable<TSource>(source, new SelectorComparer<TSource, TKey>(keySelector, comparer ?? Comparer<TKey>.Default));
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order according to a key
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">A sequence of values to order</param>
        /// <param name="keySelector">A function to extract a key from an element</param>
        /// <returns>An <see cref="IOrderedEnumerable{TElement}"/> whose elements are sorted in descending order according to a key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null</exception>
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return OrderByDescending(source, keySelector, null);
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order by using a specified comparer
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">A sequence of values to order</param>
        /// <param name="keySelector">A function to extract a key from an element</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys</param>
        /// <returns>An <see cref="IOrderedEnumerable{TElement}"/> whose elements are sorted in descending order according to a key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null</exception>
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));

            return new OrderedEnumerable<TSource>(source, new InverseComparer<TSource>(new SelectorComparer<TSource, TKey>(keySelector, comparer ?? Comparer<TKey>.Default)));
        }

        /// <summary>
        /// This is a to do
        /// </summary>
        /// <typeparam name="T">This is another to do</typeparam>
        /// <param name="source">You need to do this</param>
        /// <param name="comparer">it is important for the to be done</param>
        /// <returns>don't forget to do this</returns>
        private static IEnumerable<T> Sort<T>(IEnumerable<T> source, IComparer<T> comparer)
        {
            var original = source.Select((value, index) => Tuple.Create(value, index)).ToList();
            return Sort(original, 0, original.Count, new StableComparer<T>(comparer)).Select(value => value.Item1);
        }

        /// <summary>
        /// Sorts the elements in <paramref name="source"/> in-place based on the ordering provided by <paramref name="comparer"/> using the quicksort algorithm
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IList{T}"/> that needs to be sorted; assumed to not be null</param>
        /// <param name="start">The index within <paramref name="source"/> to begin sorting at, inclusive; assumed to be non-negative and less than the length of <paramref name="source"/></param>
        /// <param name="end">The index within <paramref name="source"/> to end sorting at, exclusive; assumed to be non-negative, less than the length of <paramref name="source"/>, and greater than or equal to <paramref name="start"/></param>
        /// <param name="comparer">The <see cref="IComparer{T}"/> which provides the ordering that the elements in <paramref name="source"/> should end up in; assumed to not be null</param>
        /// <returns>The lazily-evaluated sorting of the elements in <paramref name="source"/></returns>
        private static IEnumerable<T> Sort<T>(IList<T> source, int start, int end, IComparer<T> comparer)
        {
            if (end - start == 0)
            {
                yield break;
            }
            else
            {
                var pivot = end - 1;
                for (int i = start; i < pivot; ++i)
                {
                    if (comparer.Compare(source[i], source[pivot]) > 0)
                    {
                        Swap(source, i, pivot - 1);
                        Swap(source, pivot, pivot - 1);
                        --pivot;
                        --i;
                    }
                }

                foreach (var element in Sort(source, start, pivot, comparer))
                {
                    yield return element;
                }

                yield return source[pivot];

                foreach (var element in Sort(source, pivot + 1, end, comparer))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Swaps the elements in <paramref name="source"/> at indices <paramref name="a"/> and <paramref name="b"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IList{T}"/> to swap to elements of; assumed to not be null</param>
        /// <param name="a">The index of an element in <paramref name="source"/> to swap with the element at <paramref name="b"/></param>
        /// <param name="b">The index of an element in <paramref name="source"/> to swap with the element at <paramref name="a"/></param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="a"/> or <paramref name="b"/> is less than 0 or greater than or equal to the number of elements in <paramref name="source"/>
        /// </exception>
        private static void Swap<T>(IList<T> source, int a, int b)
        {
            var temp = source[a];
            source[a] = source[b];
            source[b] = temp;
        }

        /// <summary>
        /// A sorted <see cref="IEnumerable{T}"/> that can be further sorted by subsequent keys
        /// </summary>
        /// <typeparam name="T">The type of the elements in this <see cref="IEnumerable{T}"/></typeparam>
        private sealed class OrderedEnumerable<T> : IOrderedEnumerable<T>
        {
            /// <summary>
            /// The <see cref="IEnumerable{T}"/> that this sequence is the ordered version of
            /// </summary>
            private readonly IEnumerable<T> source;

            /// <summary>
            /// The <see cref="IComparer{T}"/> used to inform the ordering of this sequence
            /// </summary>
            private readonly IComparer<T> comparer;

            /// <summary>
            /// Initializes a new instance of the <see cref="OrderedEnumerable{T}"/> class
            /// </summary>
            /// <param name="source">The sequence that this <see cref="IEnumerable{T}"/> will be an ordered representation of</param>
            /// <param name="comparer">The <see cref="IComparer{T}"/> that will determine the ordering of the elements of <paramref name="source"/></param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="comparer"/> is null</exception>
            public OrderedEnumerable(IEnumerable<T> source, IComparer<T> comparer)
            {
                Ensure.NotNull(source, nameof(source));
                Ensure.NotNull(comparer, nameof(comparer));

                this.source = source;
                this.comparer = comparer;
            }

            /// <summary>
            /// Performs a subsequent ordering on the elements of an <see cref="IOrderedEnumerable{TElement}"/> according to a key
            /// </summary>
            /// <typeparam name="TKey">The type of the key produced by <paramref name="keySelector"/></typeparam>
            /// <param name="keySelector">The <see cref="Func{T, TResult}"/> used to extract the key for each element</param>
            /// <param name="comparer">The <see cref="IComparer{T}"/> used to compare keys for placement in the returned sequence; null indicates that the default <see cref="IComparer{T}"/> should be used</param>
            /// <param name="descending">true to sort the elements in descending order; false to sort the elements in ascending order</param>
            /// <returns>An <see cref="IOrderedEnumerable{TElement}"/> whose elements are sorted according to a key</returns>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="keySelector"/> is null</exception>
            public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
            {
                Ensure.NotNull(keySelector, nameof(keySelector));

                IComparer<T> nestedComparer = new SelectorComparer<T, TKey>(keySelector, comparer ?? Comparer<TKey>.Default);
                if (descending)
                {
                    nestedComparer = new InverseComparer<T>(nestedComparer);
                }

                return new OrderedEnumerable<T>(this.source, new CompositeComparer<T>(new[] { this.comparer, nestedComparer }));
            }

            /// <summary>
            /// Returns an enumerator that iterates through the <see cref="OrderedEnumerable{T}"/>
            /// </summary>
            /// <returns>An enumerator for the contents of the <see cref="OrderedEnumerable{T}"/></returns>
            public IEnumerator<T> GetEnumerator()
            {
                return Sort(this.source, this.comparer).GetEnumerator();
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

        /// <summary>
        /// A <see cref="IComparer{T}"/> which reverses the ordering produced by the delegate <see cref="IComparer{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of items that can be compared</typeparam>
        private sealed class InverseComparer<T> : IComparer<T>
        {
            /// <summary>
            /// The <see cref="IComparer{T}"/> whose ordering is to be revered
            /// </summary>
            private readonly IComparer<T> comparer;

            /// <summary>
            /// Initializes a new instance of the <see cref="InverseComparer{T}"/> class
            /// </summary>
            /// <param name="comparer">The <see cref="IComparer{T}"/> to reverse the ordering of</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null</exception>
            public InverseComparer(IComparer<T> comparer)
            {
                Ensure.NotNull(comparer, nameof(comparer));

                this.comparer = comparer;
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other
            /// </summary>
            /// <param name="x">The first object to compare</param>
            /// <param name="y">The second object to compare</param>
            /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table</returns>
            public int Compare(T x, T y)
            {
                return this.comparer.Compare(y, x);
            }
        }

        /// <summary>
        /// A <see cref="IComparer{T}"/> implementation which selects <typeparamref name="TElement"/>s into <typeparamref name="TKey"/>s and then compares those keys using a delegate <see cref="IComparer{T}"/>
        /// </summary>
        /// <typeparam name="TElement">The type of items that are being compared</typeparam>
        /// <typeparam name="TKey">The key that is selected from the <typeparamref name="TElement"/> for comparison</typeparam>
        private sealed class SelectorComparer<TElement, TKey> : IComparer<TElement>
        {
            /// <summary>
            /// The selector used to extract the key from the item
            /// </summary>
            private readonly Func<TElement, TKey> selector;

            /// <summary>
            /// The <see cref="IComparer{T}"/> used to compare the selected keys
            /// </summary>
            private readonly IComparer<TKey> comparer;

            /// <summary>
            /// Initializes a new instance of the <see cref="SelectorComparer{TElement, TKey}"/> class
            /// </summary>
            /// <param name="selector">The selector used to extract the key from the item</param>
            /// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the selected keys</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="selector"/> or <paramref name="comparer"/> is null</exception>
            public SelectorComparer(Func<TElement, TKey> selector, IComparer<TKey> comparer)
            {
                Ensure.NotNull(selector, nameof(selector));
                Ensure.NotNull(comparer, nameof(comparer));

                this.selector = selector;
                this.comparer = comparer;
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other
            /// </summary>
            /// <param name="x">The first object to compare</param>
            /// <param name="y">The second object to compare</param>
            /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table</returns>
            public int Compare(TElement x, TElement y)
            {
                if (x == null && y != null)
                {
                    return -1;
                }
                else if (x != null && y == null)
                {
                    return 1;
                }
                else if (x == null && y == null)
                {
                    return 0;
                }

                return this.comparer.Compare(this.selector(x), this.selector(y));
            }
        }

        /// <summary>
        /// A <see cref="IComparer{T}"/> that chains multiple comparers together to perform nested comparisons
        /// </summary>
        /// <typeparam name="T">The type of the objects that can be compared</typeparam>
        private sealed class CompositeComparer<T> : IComparer<T>
        {
            /// <summary>
            /// The <see cref="IComparer{T}"/>s that will be chained together to produce nested comparisons
            /// </summary>
            private readonly IEnumerable<IComparer<T>> comparers;

            /// <summary>
            /// Initializes a new instance of the <see cref="CompositeComparer{T}"/> class
            /// </summary>
            /// <param name="comparers">The <see cref="IComparer{T}"/>s that will be chained together to produce nested comparisons</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparers"/> is null</exception>
            public CompositeComparer(IEnumerable<IComparer<T>> comparers)
            {
                Ensure.NotNull(comparers, nameof(comparers));

                this.comparers = comparers.ToList();
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other
            /// </summary>
            /// <param name="x">The first object to compare</param>
            /// <param name="y">The second object to compare</param>
            /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table</returns>
            public int Compare(T x, T y)
            {
                foreach (var comparer in this.comparers)
                {
                    var comparison = comparer.Compare(x, y);
                    if (comparison != 0)
                    {
                        return comparison;
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// A <see cref="IComparer{T}"/> for comparing elements in sequences, which uses the <typeparamref name="T"/> elements and a <see cref="IComparer{T}"/> to determine an ordering, and the index of each element to ensure that the any sorting of the sequence is stable
        /// </summary>
        /// <typeparam name="T">The type of the elements in a sequence that need sorting</typeparam>
        private sealed class StableComparer<T> : IComparer<Tuple<T, int>>
        {
            /// <summary>
            /// The <see cref="IComparer{T}"/> used to compare the elements, before delegating to comparing their relative indices within their source sequence
            /// </summary>
            private readonly IComparer<T> comparer;

            /// <summary>
            /// Initializes a new instance of the <see cref="StableComparer{T}"/> class
            /// </summary>
            /// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the elements, before delegating to comparing their relative indices within their source sequence</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="comparer"/> is null</exception>
            public StableComparer(IComparer<T> comparer)
            {
                Ensure.NotNull(comparer, nameof(comparer));

                this.comparer = comparer;
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other
            /// </summary>
            /// <param name="x">The first object to compare</param>
            /// <param name="y">The second object to compare</param>
            /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table</returns>
            public int Compare(Tuple<T, int> x, Tuple<T, int> y)
            {
                if (x == y)
                {
                    return 0;
                }

                if (x == null)
                {
                    return -1;
                }

                if (y == null)
                {
                    return 1;
                }

                var comparison = this.comparer.Compare(x.Item1, y.Item1);
                if (comparison == 0)
                {
                    return x.Item2.CompareTo(y.Item2);
                }

                return comparison;
            }
        }
    }
}
#endif