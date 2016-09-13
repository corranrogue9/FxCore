namespace System
{
    /// <summary>
    /// Contains singletons for pre-defined <see cref="Predicate{T}"/>s
    /// </summary>
    /// <threadsafety static="true"/>
    public static class DefaultPredicate
    {
        /// <summary>
        /// A singleton <see cref="Predicate{T}"/> where the input value always matches the criteria
        /// </summary>
        /// <typeparam name="T">The type of the objects that are being matched against some criteria</typeparam>
        /// <returns>The singleton <see cref="Predicate{T}"/> where the input value always matches the criteria</returns>
        public static Predicate<T> True<T>()
        {
            return Internal<T>.True;
        }

        /// <summary>
        /// A singleton <see cref="Predicate{T}"/> where the input value never matches the criteria
        /// </summary>
        /// <typeparam name="T">The type of the objects that are being matched against some criteria</typeparam>
        /// <returns>The singleton <see cref="Predicate{T}"/> where the input value never matches the criteria</returns>
        public static Predicate<T> False<T>()
        {
            return Internal<T>.False;
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T">The generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T>
        {
            /// <summary>
            /// A singleton <see cref="Predicate{T}"/> where the input value always matches the criteria
            /// </summary>
            public static readonly Predicate<T> True = (value) => true;

            /// <summary>
            /// A singleton <see cref="Predicate{T}"/> where the input value never matches the criteria
            /// </summary>
            public static readonly Predicate<T> False = (value) => false;
        }
    }
}
