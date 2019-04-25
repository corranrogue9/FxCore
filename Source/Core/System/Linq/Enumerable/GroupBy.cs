#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key. The elements of each group are projected by using a specified function
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TElement">The type of the elements in each <see cref="IGrouping{TKey, TElement}"/></typeparam>
        /// <typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group</param>
        /// <param name="keySelector">A function to extract the key for each element</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TElement}"/></param>
        /// <param name="resultSelector">A function to create a result value from each group</param>
        /// <returns>A collection of elements of type <typeparamref name="TResult"/> where each element represents a projection over a group and its key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> or <paramref name="resultSelector"/> is null</exception>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));
            Ensure.NotNull(elementSelector, nameof(elementSelector));
            Ensure.NotNull(resultSelector, nameof(resultSelector));

            return ToLookup(source, keySelector, elementSelector).Select(group => resultSelector(group.Key, group));
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key. Key values are compared by using a specified comparer, and the elements of each group are projected by using a specified function
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TElement">The type of the elements in each <see cref="IGrouping{TKey, TElement}"/></typeparam>
        /// <typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group</param>
        /// <param name="keySelector">A function to extract the key for each element</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TElement}"/></param>
        /// <param name="resultSelector">A function to create a result value from each group</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys with</param>
        /// <returns>A collection of elements of type <typeparamref name="TResult"/> where each element represents a projection over a group and its key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> or <paramref name="resultSelector"/> is null</exception>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));
            Ensure.NotNull(elementSelector, nameof(elementSelector));
            Ensure.NotNull(resultSelector, nameof(resultSelector));

            return ToLookup(source, keySelector, elementSelector, comparer).Select(group => resultSelector(group.Key, group));
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and projects the elements for each group by using a specified function
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TElement">The type of the elements in the <see cref="IGrouping{TKey, TElement}"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group</param>
        /// <param name="keySelector">A function to extract the key for each element</param>
        /// <param name="elementSelector">A function to map each source element to an element in the <see cref="IGrouping{TKey, TElement}"/></param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each <see cref="IGrouping{TKey, TElement}"/> object contains a collection of objects of type <typeparamref name="TElement"/> and a key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null</exception>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));
            Ensure.NotNull(elementSelector, nameof(elementSelector));

            return ToLookup(source, keySelector, elementSelector);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a key selector function. The keys are compared by using a comparer and each group's elements are projected by using a specified function
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TElement">The type of the elements in the <see cref="IGrouping{TKey, TElement}"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group</param>
        /// <param name="keySelector">A function to extract the key for each element</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TElement}"/></param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys</param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each <see cref="IGrouping{TKey, TElement}"/> object contains a collection of objects of type <typeparamref name="TElement"/> and a key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null</exception>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));
            Ensure.NotNull(elementSelector, nameof(elementSelector));

            return ToLookup(source, keySelector, elementSelector, comparer);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group</param>
        /// <param name="keySelector">A function to extract the key for each element</param>
        /// <param name="resultSelector">A function to create a result value from each group</param>
        /// <returns>A collection of elements of type <typeparamref name="TResult"/> where each element represents a projection over a group and its key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="resultSelector"/> is null</exception>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));
            Ensure.NotNull(resultSelector, nameof(resultSelector));

            return ToLookup(source, keySelector).Select(group => resultSelector(group.Key, group));
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and creates a result value from each group and its key. The keys are compared by using a specified comparer
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group</param>
        /// <param name="keySelector">A function to extract the key for each element</param>
        /// <param name="resultSelector">A function to create a result value from each group</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys with</param>
        /// <returns>A collection of elements of type <typeparamref name="TResult"/> where each element represents a projection over a group and its key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="resultSelector"/> is null</exception>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));
            Ensure.NotNull(resultSelector, nameof(resultSelector));

            return ToLookup(source, keySelector, comparer).Select(group => resultSelector(group.Key, group));
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group</param>
        /// <param name="keySelector">A function to extract the key for each element</param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each <see cref="IGrouping{TKey, TElement}"/> object contains a sequence of objects and a key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null</exception>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));

            return ToLookup(source, keySelector);
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function and compares the keys by using a specified comparer
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group</param>
        /// <param name="keySelector">A function to extract the key for each element</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys</param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each <see cref="IGrouping{TKey, TElement}"/> object contains a collection of objects and a key</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="keySelector"/> is null</exception>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(keySelector, nameof(keySelector));

            return ToLookup(source, keySelector, comparer);
        }
    }
}
#endif