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
        /// Determines whether all elements of a sequence satisfy a condition
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> that contains the elements to apply the predicate to</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>true if every element of the source sequence passes the test in the specified predicate, or if the sequence is empty; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="predicate"/> is null</exception>
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(predicate, nameof(predicate));

            foreach (var element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
#endif