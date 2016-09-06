namespace System
{
    /// <summary>
    /// Contains singletons for pre-defined <see cref="Action"/>s
    /// </summary>
    /// <threadsafety static="true"/>
    public static class DefaultAction
    {
        /// <summary>
        /// A singleton <see cref="Action"/> that has no side-effects
        /// </summary>
        /// <returns>The singleton <see cref="Action"/> that has no side-effects</returns>
        public static Action Empty()
        {
            return Internal.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T">The type used in the resulting <see cref="Action{T}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T}"/> that has no side-effects</returns>
        public static Action<T> Empty<T>()
        {
            return Internal<T>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2}"/> that has no side-effects</returns>
        public static Action<T1, T2> Empty<T1, T2>()
        {
            return Internal<T1, T2>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3> Empty<T1, T2, T3>()
        {
            return Internal<T1, T2, T3>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4> Empty<T1, T2, T3, T4>()
        {
            return Internal<T1, T2, T3, T4>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5> Empty<T1, T2, T3, T4, T5>()
        {
            return Internal<T1, T2, T3, T4, T5>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6> Empty<T1, T2, T3, T4, T5, T6>()
        {
            return Internal<T1, T2, T3, T4, T5, T6>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7> Empty<T1, T2, T3, T4, T5, T6, T7>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/></typeparam>
        /// <typeparam name="T8">The eighth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Empty<T1, T2, T3, T4, T5, T6, T7, T8>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7, T8>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/></typeparam>
        /// <typeparam name="T8">The eighth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/></typeparam>
        /// <typeparam name="T9">The ninth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Empty<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <typeparam name="T8">The eighth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <typeparam name="T9">The ninth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <typeparam name="T10">The tenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Empty<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T8">The eighth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T9">The ninth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T10">The tenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <typeparam name="T11">The eleventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Empty<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T8">The eighth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T9">The ninth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T10">The tenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T11">The eleventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <typeparam name="T12">The twelfth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Empty<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T8">The eighth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T9">The ninth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T10">The tenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T11">The eleventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T12">The twelfth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <typeparam name="T13">The thirteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Empty<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T8">The eighth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T9">The ninth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T10">The tenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T11">The eleventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T12">The twelfth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T13">The thirteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <typeparam name="T14">The fourteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Empty<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T8">The eighth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T9">The ninth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T10">The tenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T11">The eleventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T12">The twelfth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T13">The thirteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T14">The fourteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <typeparam name="T15">The fifteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Empty<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>.Empty;
        }

        /// <summary>
        /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/> that has no side-effects
        /// </summary>
        /// <typeparam name="T1">The first type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T2">The second type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T3">The third type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T4">The fourth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T5">The fifth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T6">The sixth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T7">The seventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T8">The eighth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T9">The ninth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T10">The tenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T11">The eleventh type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T12">The twelfth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T13">The thirteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T14">The fourteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T15">The fifteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <typeparam name="T16">The sixteenth type used in the resulting <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/></typeparam>
        /// <returns>The singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/> that has no side-effects</returns>
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Empty<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
        {
            return Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>.Empty;
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <threadsafety static="true"/>
        private static class Internal
        {
            /// <summary>
            /// A singleton <see cref="Action"/> that has no side-effects
            /// </summary>
            public static readonly Action Empty = () => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T">The generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T>
        {
            /// <summary>
            /// A singleton <see cref="Action{T}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T> Empty = (obj) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2> //// TODO should these have variance?
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2> Empty = (arg1, arg2) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3> Empty = (arg1, arg2, arg3) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4> Empty = (arg1, arg2, arg3, arg4) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5> Empty = (arg1, arg2, arg3, arg4, arg5) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6> Empty = (arg1, arg2, arg3, arg4, arg5, arg6) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T8">The eighth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7, T8>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7, T8> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T8">The eighth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T9">The ninth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T8">The eighth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T9">The ninth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T10">The tenth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T8">The eighth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T9">The ninth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T10">The tenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T11">The eleventh generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T8">The eighth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T9">The ninth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T10">The tenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T11">The eleventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T12">The twelfth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T8">The eighth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T9">The ninth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T10">The tenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T11">The eleventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T12">The twelfth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T13">The thirteenth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T8">The eighth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T9">The ninth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T10">The tenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T11">The eleventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T12">The twelfth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T13">The thirteenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T14">The fourteenth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T8">The eighth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T9">The ninth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T10">The tenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T11">The eleventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T12">The twelfth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T13">The thirteenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T14">The fourteenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T15">The fifteenth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15) => { };
        }

        /// <summary>
        /// A generic-type internal class that contains singleton fields
        /// </summary>
        /// <typeparam name="T1">The first generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T2">The second generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T3">The third generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T4">The fourth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T5">The fifth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T6">The sixth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T7">The seventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T8">The eighth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T9">The ninth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T10">The tenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T11">The eleventh generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T12">The twelfth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T13">The thirteenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T14">The fourteenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T15">The fifteenth generic type used by the constituent singletons</typeparam>
        /// <typeparam name="T16">The sixteenth generic type used by the constituent singletons</typeparam>
        /// <threadsafety static="true"/>
        private static class Internal<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        {
            /// <summary>
            /// A singleton <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/> that has no side-effects
            /// </summary>
            public static readonly Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Empty = (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16) => { };
        }
    }
}
