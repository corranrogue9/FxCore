#if !NET35
namespace System.Linq
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        /// <summary>
        /// Returns an empty <see cref="IEnumerable{T}"/> that has the specified type argument
        /// </summary>
        /// <typeparam name="TResult">The type to assign to the type parameter of the returned generic <see cref="IEnumerable{T}"/></typeparam>
        /// <returns>An empty <see cref="IEnumerable{T}"/> whose type argument is <typeparamref name="TResult"/></returns>
        public static IEnumerable<TResult> Empty<TResult>()
        {
            return Internal<TResult>.Empty;
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T">The  generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T>
        {
            /// <summary>
            /// A singleton empty <see cref="T:T[]"/>
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate")]
            public static T[] Empty = new T[0];
        }
    }
}
#endif