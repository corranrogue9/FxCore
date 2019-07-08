#if !NET40
namespace System
{
    /// <summary>
    /// Factory methods for the <see cref="Tuple{T1, T2}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    internal static class Tuple
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Tuple{T1}"/>
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="item1"/></typeparam>
        /// <param name="item1">The first item</param>
        /// <returns>The new <see cref="Tuple{T1}"/></returns>
        public static Tuple<T1> Create<T1>(T1 item1)
        {
            return new Tuple<T1>(item1);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Tuple{T1, T2}"/>
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="item1"/></typeparam>
        /// <typeparam name="T2">the type of <paramref name="item2"/></typeparam>
        /// <param name="item1">The first item</param>
        /// <param name="item2">The second item</param>
        /// <returns>The new <see cref="Tuple{T1, T2}"/></returns>
        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new Tuple<T1, T2>(item1, item2);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Tuple{T1, T2, T3}"/>
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="item1"/></typeparam>
        /// <typeparam name="T2">the type of <paramref name="item2"/></typeparam>
        /// <typeparam name="T3">the type of <paramref name="item3"/></typeparam>
        /// <param name="item1">The first item</param>
        /// <param name="item2">The second item</param>
        /// <param name="item3">The third item</param>
        /// <returns>The new <see cref="Tuple{T1, T2, T3}"/></returns>
        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }
    }
}
#endif