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
        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="System.Single"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="System.Single"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Single}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static float? Max(this IEnumerable<float?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<float?>(source, FloatComparer.Instance);
        }
        
        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="Int32"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="Int32"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static int Max(this IEnumerable<int> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<int>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="Int64"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="Int64"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Int64}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static long? Max(this IEnumerable<long?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<long?>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="System.Single"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="System.Single"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="source"/> contains no elements</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static float Max(this IEnumerable<float> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<float>(source, FloatComparer.Instance);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="System.Int32"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="System.Int32"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Int32}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static int? Max(this IEnumerable<int?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<int?>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="System.Decimal"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="System.Decimal"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static decimal Max(this IEnumerable<decimal> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<decimal>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="System.Decimal"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="System.Decimal"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Decimal}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static decimal? Max(this IEnumerable<decimal?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<decimal?>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="System.Int64"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="System.Int64"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static long Max(this IEnumerable<long> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<long>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="System.Double"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="System.Double"/> values to determine the maximum value of</param>
        /// <returns>The maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static double Max(this IEnumerable<double> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<double>(source);
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="System.Double"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="System.Double"/> values to determine the maximum value of</param>
        /// <returns>A value of type <see cref="Nullable{Double}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static double? Max(this IEnumerable<double?> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max<double?>(source);
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
        public static TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
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
        public static float Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Single"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Single}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static float? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Int64"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Int64}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static long? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Int32"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Int32}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static int? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Double"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Double}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static double? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
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
        public static long Max<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
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
        public static int Max<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
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
        public static double Max<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
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
        public static decimal Max<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
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
        public static TSource Max<TSource>(this IEnumerable<TSource> source)
        {
            Ensure.NotNull(source, nameof(source));

            return Max(source, Comparer<TSource>.Default);
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="System.Decimal"/> value
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to determine the maximum value of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The value of type <see cref="Nullable{Decimal}"/> that corresponds to the maximum value in the sequence</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static decimal? Max<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Max(source.Select(selector));
        }

        /// <summary>
        /// Finds the maximum value in <paramref name="source"/> by comparing its elements to each other using the ordering provided by <paramref name="comparer"/>
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in <paramref name="source"/></typeparam>
        /// <param name="source">The sequence to find the maximum element of, assumed to not be null</param>
        /// <param name="comparer">The <see cref="IComparer{T}"/> that will be used to compare the elements in <paramref name="source"/>, assumed to not be null</param>
        /// <returns>The maximum value in <paramref name="source"/></returns>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements and <typeparamref name="TSource"/> is a value type</exception>
        private static TSource Max<TSource>(IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            var @default = default(TSource);
            using (var enumerator = source.Where(element => element != null).GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    if (@default == null)
                    {
                        return @default;
                    }
                    else
                    {
                        throw new InvalidOperationException(Strings.MaxEmpty);
                    }
                }

                var extreme = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    if (comparer.Compare(enumerator.Current, extreme) > 0)
                    {
                        extreme = enumerator.Current;
                    }
                }

                return extreme;
            }
        }

        /// <summary>
        /// A comparer which compares two <see cref="System.Single"/>s or two <see cref="Nullable{Single}"/>
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private sealed class FloatComparer : IComparer<float>, IComparer<float?>
        {
            /// <summary>
            /// Prevents a default instance of the <see cref="FloatComparer"/> class from being created
            /// </summary>
            private FloatComparer()
            {
            }

            /// <summary>
            /// Gets the singleton instance of the <see cref="FloatComparer"/>
            /// </summary>
            public static FloatComparer Instance { get; } = new FloatComparer();

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other
            /// </summary>
            /// <param name="x">The first object to compare</param>
            /// <param name="y">The second object to compare</param>
            /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table</returns>
            public int Compare(float x, float y)
            {
                if (float.IsNaN(x) && float.IsNaN(y))
                {
                    return 0;
                }

                if (float.IsNaN(x))
                {
                    return -1;
                }

                if (float.IsNaN(y))
                {
                    return 1;
                }

                return System.Collections.Generic.Comparer<float>.Default.Compare(x, y);
            }

            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other
            /// </summary>
            /// <param name="x">The first object to compare</param>
            /// <param name="y">The second object to compare</param>
            /// <returns>A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table</returns>
            public int Compare(float? x, float? y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }

                if (x == null)
                {
                    return -1;
                }

                if (y == null)
                {
                    return 1;
                }

                return this.Compare(x.Value, y.Value);
            }
        }
    }
}
#endif