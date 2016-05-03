#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Extensions methods <see cref="IEnumerable{T}"/> that mimic the behavior of <see cref="System.Linq.Enumerable"/> introduced in .NET 3.5
    /// </summary>
    /// <threadsafety static="true"/>
    public static class Enumerable
    {
        /// <summary>
        /// Returns an empty <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements that would be contained in the <see cref="IEnumerable{T}"/> if it were not empty</typeparam>
        /// <returns>An empty <see cref="IEnumerable{T}"/> whose type argument is <typeparamref name="T"/></returns>
        public static IEnumerable<T> Empty<T>()
        {
            return GenericEnumerable<T>.Empty;
        }

        /// <summary>
        /// Determines if <paramref name="source"/> has any elements in it
        /// </summary>
        /// <typeparam name="T">The type of the elements contained in <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to determine whether it has any elements</param>
        /// <returns>false if <paramref name="source"/> contains no elements, true otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        internal static bool Any<T>(IEnumerable<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// A helper class which uses a strongly-typed generic type on the class for caching purposes
        /// </summary>
        /// <typeparam name="T">The type of the elements in the <see cref="IEnumerable{T}"/>s that are cached in this helper</typeparam>
        /// <threadsafety static="true"/>
        private static class GenericEnumerable<T>
        {
            /// <summary>
            /// A <see cref="IEnumerable{T}"/> that contains no elements and is cached per type
            /// </summary>
            public static readonly IEnumerable<T> Empty = new T[0];
        }
    }
}
#endif
