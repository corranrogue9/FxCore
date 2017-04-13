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
        /// Applies an accumulator function over a sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to aggregate over</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="func"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(func, nameof(func));

            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException(Strings.AggregateEmpty);
                }

                return Aggregate(enumerator, enumerator.Current, func);
            }
        }

        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to aggregate over</param>
        /// <param name="seed">The initial accumulator value</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="func"/> is null</exception>
        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(func, nameof(func));

            using (var enumerator = source.GetEnumerator())
            {
                return Aggregate(enumerator, seed, func);
            }
        }

        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value, and the specified function is used to 
        /// select the result value.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value</typeparam>
        /// <typeparam name="TResult">The type of the resulting value</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> to aggregate over</param>
        /// <param name="seed">The initial accumulator value</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <param name="resultSelector">A function to transform the final accumulator value into the result value</param>
        /// <returns>The transformed final accumulator value</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="source"/> or <paramref name="func"/> or <paramref name="resultSelector"/> is null
        /// </exception>
        public static TResult Aggregate<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(func, nameof(func));
            Ensure.NotNull(resultSelector, nameof(resultSelector));

            return resultSelector(Aggregate(source, seed, func));
        }

        /// <summary>
        /// Aggregates the remaining values in <paramref name="source"/> beginning with a value of <paramref name="seed"/>
        /// </summary>
        /// <typeparam name="TSource">The type of each element in <paramref name="source"/></typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulated values</typeparam>
        /// <param name="source">The values remaining to be aggregated; assumed to not be null</param>
        /// <param name="seed">The initial value</param>
        /// <param name="func">The accumulator function to be applied to each element; assumed to not be null</param>
        /// <returns>The aggregated value</returns>
        private static TAccumulate Aggregate<TSource, TAccumulate>(IEnumerator<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            while (source.MoveNext())
            {
                seed = func(seed, source.Current);
            }

            return seed;
        }
    }
}
#endif