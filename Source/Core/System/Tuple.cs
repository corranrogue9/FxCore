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
    }
}
#endif