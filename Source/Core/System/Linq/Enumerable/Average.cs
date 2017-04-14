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
        /// Computes the average of a sequence of <see cref="Decimal"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="Decimal"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        /// <exception cref="OverflowException">Thrown if the sum of the elements in <paramref name="source"/> is larger than <see cref="decimal.MaxValue"/></exception>
        public static decimal Average(this IEnumerable<decimal> source)
        {
            Ensure.NotNull(source, nameof(source));

            var count = 0;
            var total = 0m;
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException(Strings.AverageEmpty);
                }

                do
                {
                    ++count;
                    total += enumerator.Current;
                }
                while (enumerator.MoveNext());
            }

            return total / count;
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="Double"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="Double"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static double Average(this IEnumerable<double> source)
        {
            Ensure.NotNull(source, nameof(source));

            var count = 0;
            var total = 0d;
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException(Strings.AverageEmpty);
                }

                do
                {
                    ++count;
                    total += enumerator.Current;
                }
                while (enumerator.MoveNext());
            }

            return total / count;
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="Int32"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="Int32"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static double Average(this IEnumerable<int> source)
        {
            Ensure.NotNull(source, nameof(source));

            var count = 0L;
            var total = 0L;
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException(Strings.AverageEmpty);
                }

                checked
                {
                    do
                    {
                        ++count;
                        total += enumerator.Current;
                    }
                    while (enumerator.MoveNext());
                }
            }

            return (double)total / count;
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="Int64"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="Int64"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static double Average(this IEnumerable<long> source)
        {
            Ensure.NotNull(source, nameof(source));

            var count = 0L;
            var total = 0L;
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException(Strings.AverageEmpty);
                }

                checked
                {
                    do
                    {
                        ++count;
                        total += enumerator.Current;
                    }
                    while (enumerator.MoveNext());
                }
            }

            return (double)total / count;
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="Single"/> values
        /// </summary>
        /// <param name="source">A sequence of <see cref="Single"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static float Average(this IEnumerable<float> source)
        {
            Ensure.NotNull(source, nameof(source));

            var count = 0L;
            var total = 0d;
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException(Strings.AverageEmpty);
                }

                do
                {
                    ++count;
                    total += enumerator.Current;
                }
                while (enumerator.MoveNext());
            }

            return (float)(total / count);
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Decimal"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="Decimal"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="OverflowException">The sum of the elements in the sequence is larger than <see cref="decimal.MaxValue"/></exception>
        public static decimal? Average(this IEnumerable<decimal?> source)
        {
            Ensure.NotNull(source, nameof(source));

            try
            {
                return Average(SelectIterator(WhereIterator(source, val => val != null), val => val.GetValueOrDefault()));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Double"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="Double"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static double? Average(this IEnumerable<double?> source)
        {
            Ensure.NotNull(source, nameof(source));

            try
            {
                return Average(SelectIterator(WhereIterator(source, val => val != null), val => val.GetValueOrDefault()));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Int32"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="Int32"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="OverflowException">The sum of the elements in the sequence is larger than <see cref="long.MaxValue"/></exception>
        public static double? Average(this IEnumerable<int?> source)
        {
            Ensure.NotNull(source, nameof(source));

            try
            {
                return Average(SelectIterator(WhereIterator(source, val => val != null), val => val.GetValueOrDefault()));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Int64"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="Int64"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        /// <exception cref="OverflowException">The sum of the elements in the sequence is larger than <see cref="long.MaxValue"/></exception>
        public static double? Average(this IEnumerable<long?> source)
        {
            Ensure.NotNull(source, nameof(source));

            try
            {
                return Average(SelectIterator(WhereIterator(source, val => val != null), val => val.GetValueOrDefault()));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Single"/> values
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="Single"/> values to calculate the average of</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is null</exception>
        public static float? Average(this IEnumerable<float?> source)
        {
            Ensure.NotNull(source, nameof(source));

            try
            {
                return Average(SelectIterator(WhereIterator(source, val => val != null), val => val.GetValueOrDefault()));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="Decimal"/> values that are obtained by invoking a transform function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values that are used to calculate an average</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        /// <exception cref="OverflowException">Thrown if the sum of the elements in the sequence is larger than <see cref="decimal.MaxValue"/></exception>
        public static decimal Average<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="Double"/> values that are obtained by invoking a transform function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values that are used to calculate an average</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="Int32"/> values that are obtained by invoking a transform function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values that are used to calculate an average</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        /// <exception cref="OverflowException">Thrown if the sum of the elements in the sequence is larger than <see cref="long.MaxValue"/></exception>
        public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="Int64"/> values that are obtained by invoking a transform function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values that are used to calculate an average</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        /// <exception cref="OverflowException">Thrown if the sum of the elements in the sequence is larger than <see cref="long.MaxValue"/></exception>
        public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }

        /// <summary>
        /// Computes the average of a sequence of <see cref="Single"/> values that are obtained by invoking a transform function on each element of the input sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values that are used to calculate an average</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="source"/> contains no elements</exception>
        public static float Average<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Decimal"/> values that are obtained by invoking a transform function on each element of the input 
        /// sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to calculate the average of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if The sum of the elements in the sequence is larger than <see cref="decimal.MaxValue"/></exception>
        public static decimal? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Double"/> values that are obtained by invoking a transform function on each element of the input 
        /// sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to calculate the average of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Int32"/> values that are obtained by invoking a transform function on each element of the input 
        /// sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to calculate the average of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if The sum of the elements in the sequence is larger than <see cref="long.MaxValue"/></exception>
        public static double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Int64"/> values that are obtained by invoking a transform function on each element of the input 
        /// sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to calculate the average of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        /// <exception cref="OverflowException">Thrown if The sum of the elements in the sequence is larger than <see cref="long.MaxValue"/></exception>
        public static double? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }

        /// <summary>
        /// Computes the average of a sequence of nullable <see cref="Single"/> values that are obtained by invoking a transform function on each element of the input 
        /// sequence
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">A sequence of values to calculate the average of</param>
        /// <param name="selector">A transform function to apply to each element</param>
        /// <returns>The average of the sequence of values, or null if the source sequence is empty or contains only values that are null</returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="source"/> or <paramref name="selector"/> is null</exception>
        public static float? Average<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            Ensure.NotNull(source, nameof(source));
            Ensure.NotNull(selector, nameof(selector));

            return Average(SelectIterator(source, selector));
        }
    }
}
#endif