#if !NET35
namespace System.Linq
{
    using System;
    using System.Collections.Generic;

    using Fx;

    /// <summary>
    /// Provides a set of static methods for querying objects that implement <see cref="IEnumerable{T}"/>
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class Enumerable
    {
        //// TODO fix implementation documentation
        //// TODO double check that documentation matches behavior
        //// TODO refactor extremum method?
        //// TODO singletons for inversecomparers?

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="System.Single"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="System.Single"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Single}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static float? Min(this IEnumerable<float?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Extremum<float?>(source, new InverseComparer<float?>(FloatComparer.Instance));
        }
        
        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="Int32"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="Int32"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static int Min(this IEnumerable<int> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Min<int>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="Int64"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="Int64"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Int64}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static long? Min(this IEnumerable<long?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Min<long?>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="System.Single"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="System.Single"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="source"/> contains no elements</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static float Min(this IEnumerable<float> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Extremum<float>(source, new InverseComparer<float>(FloatComparer.Instance));
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="System.Int32"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="System.Int32"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Int32}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static int? Min(this IEnumerable<int?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Min<int?>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="System.Decimal"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="System.Decimal"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static decimal Min(this IEnumerable<decimal> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Min<decimal>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="System.Decimal"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="System.Decimal"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Decimal}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static decimal? Min(this IEnumerable<decimal?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Min<decimal?>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="System.Int64"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="System.Int64"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static long Min(this IEnumerable<long> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Min<long>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="System.Double"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="System.Double"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static double Min(this IEnumerable<double> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Min<double>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="System.Double"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="System.Double"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Double}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static double? Min(this IEnumerable<double?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Min<double?>(source);
        }

        /// <summary>
        /// Invokes a transform function on each element of a generic sequence and returns the maximum resulting value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if no object in <paramref name="source"/> implements the <see cref="IComparable"/> or <see cref="IComparable{T}"/> interface when projected by <paramref name="selector"/> into <typeparamref name="TResult"/></exception>
        /// <exception cref="InvalidOperationException">Thrown if <typeparamref name="TResult"/> is a value type and there are no elements in <paramref name="source"/></exception>
        public static TResult Min<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }
        
        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum <see cref="System.Single"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static float Min<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Single"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Single}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static float? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Int64"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Int64}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static long? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Int32"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Int32}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static int? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Double"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Double}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static double? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum <see cref="System.Int64"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static long Min<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum <see cref="System.Int32"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static int Min<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum <see cref="System.Double"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static double Min<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum <see cref="System.Decimal"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static decimal Min<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }

        /// <summary>
        /// Returns the maximum value in a generic sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if no object in <paramref name="source"/> implements the <see cref="IComparable"/> or <see cref="IComparable{T}"/> interface</exception>
        /// <exception cref="InvalidOperationException">Thrown if <typeparamref name="TSource"/> is a value type and there are no elements in <paramref name="source"/></exception>
        public static TSource Min<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Extremum(source, new InverseComparer<TSource>(Comparer<TSource>.Default));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Decimal"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Decimal}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static decimal? Min<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Min(source.Select(selector));
        }
    }
}
#endif