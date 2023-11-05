﻿namespace System.Linq.V2
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Reflection.Metadata.Ecma335;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Xml.Linq;

    public static partial class V2Enumerable
    {
        public static IV2Enumerable<TElement> ToV2Enumerable<TElement>(this IEnumerable<TElement> self)
        {
            return new DefaultV2Enumerable<TElement>(self);
        }

        private sealed class DefaultV2Enumerable<TElement> : IV2Enumerable<TElement>
        {
            private readonly IEnumerable<TElement> self;

            public DefaultV2Enumerable(IEnumerable<TElement> self)
            {
                this.self = self;
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                return this.self.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        private static IV2Grouping<TKey, TElement> ToV2Grouping<TKey, TElement>(this IGrouping<TKey, TElement> grouping)
        {
            return new DefaultV2Grouping<TKey, TElement>(grouping);
        }

        private sealed class DefaultV2Grouping<TKey, TElement> : IV2Grouping<TKey, TElement>
        {
            private readonly IGrouping<TKey, TElement> grouping;

            public DefaultV2Grouping(IGrouping<TKey, TElement> grouping)
            {
                this.grouping = grouping;
            }

            public TKey Key
            {
                get
                {
                    return this.grouping.Key;
                }
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                return this.grouping.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        private static IV2OrderedEnumerable<TElement> ToV2OrderedEnumerable<TElement>(this IOrderedEnumerable<TElement> orderedEnumerable)
        {
            return new DefaultV2OrderedEnumerable<TElement>(orderedEnumerable);
        }

        private sealed class DefaultV2OrderedEnumerable<TElement> : IV2OrderedEnumerable<TElement>
        {
            private readonly IOrderedEnumerable<TElement> orderedEnumerable;

            public DefaultV2OrderedEnumerable(IOrderedEnumerable<TElement> orderedEnumerable)
            {
                this.orderedEnumerable = orderedEnumerable;
            }

            public IV2OrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey>? comparer, bool descending)
            {
                return this.orderedEnumerable.CreateOrderedEnumerable(keySelector, comparer, descending).ToV2OrderedEnumerable();
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                return this.orderedEnumerable.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        private static IV2Lookup<TKey, TElement> ToV2Lookup<TKey, TElement>(this ILookup<TKey, TElement> lookup)
        {
            return new DefaultV2Lookup<TKey, TElement>(lookup);
        }

        private sealed class DefaultV2Lookup<TKey, TElement> : IV2Lookup<TKey, TElement>
        {
            private readonly ILookup<TKey, TElement> lookup;

            public DefaultV2Lookup(ILookup<TKey, TElement> lookup)
            {
                this.lookup = lookup;
            }

            public IV2Enumerable<TElement> this[TKey key]
            {
                get
                {
                    return this.lookup[key].ToV2Enumerable();
                }
            }

            public int Count
            {
                get
                {
                    return this.lookup.Count;
                }
            }

            public bool Contains(TKey key)
            {
                return this.lookup.Contains(key);
            }

            public IEnumerator<IV2Grouping<TKey, TElement>> GetEnumerator()
            {
                return this.lookup.Select(ToV2Grouping).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }

    public static partial class V2Enumerable
    {
        public static TSource Aggregate<TSource>(this IV2Enumerable<TSource> self, Func<TSource, TSource, TSource> func)
        {
            if (self is IAggregateEnumerable<TSource> aggregate)
            {
                return aggregate.Aggregate(func);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Aggregate(func);
            }

            return self.AsEnumerable().Aggregate(func);
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this IV2Enumerable<TSource> self, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (self is IAggregate2Enumerable<TSource> aggregate)
            {
                return aggregate.Aggregate(seed, func);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Aggregate(seed, func);
            }

            return self.AsEnumerable().Aggregate(seed, func);
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(
            this IV2Enumerable<TSource> self,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
        {
            if (self is IAggregate3Enumerable<TSource> aggregate)
            {
                return aggregate.Aggregate(seed, func, resultSelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Aggregate(seed, func, resultSelector);
            }

            return self.AsEnumerable().Aggregate(seed, func, resultSelector);
        }

        public static bool All<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is IAllEnumerable<TSource> all)
            {
                return all.All(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.All(predicate);
            }

            return self.AsEnumerable().All(predicate);
        }

        public static bool Any<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IAnyEnumerable<TSource> any)
            {
                return any.Any();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Any();
            }

            return self.AsEnumerable().Any();
        }

        public static bool Any<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is IAny2Enumerable<TSource> any)
            {
                return any.Any(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Any(predicate);
            }

            return self.AsEnumerable().Any(predicate);
        }

        public static IV2Enumerable<TSource> Append<TSource>(this IV2Enumerable<TSource> self, TSource element)
        {
            if (self is IAppendEnumerable<TSource> append)
            {
                return append.Append(element);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Append(element));
            }

            return self.AsEnumerable().Append(element).ToV2Enumerable();
        }

        /*public static IV2Enumerable<TSource> AsEnumerable<TSource>(this IV2Enumerable<TSource> self)
        {
            //// TODO
            throw new System.NotImplementedException();
        }*/

        public static double Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static double Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long> selector)
        {
            if (self is IAverage2Enumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static double? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double?> selector)
        {
            if (self is IAverage3Enumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static float Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float> selector)
        {
            if (self is IAverage4Enumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static double? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long?> selector)
        {
            if (self is IAverage5Enumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static float? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float?> selector)
        {
            if (self is IAverage6Enumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static double Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double> selector)
        {
            if (self is IAverage7Enumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static double? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int?> selector)
        {
            if (self is IAverage8Enumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static decimal Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal> selector)
        {
            if (self is IAverage9Enumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static decimal? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal?> selector)
        {
            if (self is IAverage10Enumerable<TSource> average)
            {
                return average.Average(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average(selector);
            }

            return self.AsEnumerable().Average(selector);
        }

        public static float? Average(this IV2Enumerable<float?> self)
        {
            if (self is IAverage11Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<float?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        public static double? Average(this IV2Enumerable<long?> self)
        {
            if (self is IAverage12Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<long?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        public static double? Average(this IV2Enumerable<int?> self)
        {
            if (self is IAverage13Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<int?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        public static double? Average(this IV2Enumerable<double?> self)
        {
            if (self is IAverage14Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<double?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        public static decimal? Average(this IV2Enumerable<decimal?> self)
        {
            if (self is IAverage15Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<decimal?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        public static double Average(this IV2Enumerable<long> self)
        {
            if (self is IAverage16Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<long> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        public static double Average(this IV2Enumerable<int> self)
        {
            if (self is IAverage17Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<int> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        public static double Average(this IV2Enumerable<double> self)
        {
            if (self is IAverage18Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<double> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        public static decimal Average(this IV2Enumerable<decimal> self)
        {
            if (self is IAverage19Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<decimal> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        public static float Average(this IV2Enumerable<float> self)
        {
            if (self is IAverage20Enumerable average)
            {
                return average.Average();
            }

            if (self is IAggregatedOverloadEnumerable<float> aggregatedOverload)
            {
                return aggregatedOverload.Source.Average();
            }

            return self.AsEnumerable().Average();
        }

        /*public static IV2Enumerable<TResult> Cast<TResult>(this IV2Enumerable self)
        {
            //// TODO
            throw new System.NotImplementedException();
        }*/

        public static IV2Enumerable<TSource[]> Chunk<TSource>(this IV2Enumerable<TSource> self, int size)
        {
            if (self is IChunkEnumerable<TSource> chunk)
            {
                return chunk.Chunk(size);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Chunk(size));
            }

            return self.AsEnumerable().Chunk(size).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Concat<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second)
        {
            if (first is IConcatEnumerable<TSource> concat)
            {
                return concat.Concat(second);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Concat(second));
            }

            return first.AsEnumerable().Concat(second).ToV2Enumerable();
        }

        public static bool Contains<TSource>(this IV2Enumerable<TSource> self, TSource value, IEqualityComparer<TSource>? comparer)
        {
            if (self is IContainsEnumerable<TSource> contains)
            {
                return contains.Contains(value, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Contains(value, comparer);
            }

            return self.AsEnumerable().Contains(value, comparer);
        }

        public static bool Contains<TSource>(this IV2Enumerable<TSource> self, TSource value)
        {
            if (self is IContains2Enumerable<TSource> contains)
            {
                return contains.Contains(value);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Contains(value);
            }

            return self.AsEnumerable().Contains(value);
        }

        public static int Count<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ICountEnumerable<TSource> count)
            {
                return count.Count();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Count();
            }

            return self.AsEnumerable().Count();
        }

        public static int Count<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ICount2Enumerable<TSource> count)
            {
                return count.Count(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Count(predicate);
            }

            return self.AsEnumerable().Count(predicate);
        }

        public static IV2Enumerable<TSource?> DefaultIfEmpty<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IDefaultIfEmptyEnumerable<TSource> defaultIfEmpty)
            {
                return defaultIfEmpty.DefaultIfEmpty();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.DefaultIfEmpty());
            }

            return self.AsEnumerable().DefaultIfEmpty().ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> DefaultIfEmpty<TSource>(this IV2Enumerable<TSource> self, TSource defaultValue)
        {
            if (self is IDefaultIfEmpty2Enumerable<TSource> defaultIfEmpty)
            {
                return defaultIfEmpty.DefaultIfEmpty(defaultValue);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.DefaultIfEmpty(defaultValue));
            }

            return self.AsEnumerable().DefaultIfEmpty(defaultValue).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Distinct<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IDistinctEnumerable<TSource> distinct)
            {
                return distinct.Distinct();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Distinct());
            }

            return self.AsEnumerable().Distinct().ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Distinct<TSource>(this IV2Enumerable<TSource> self, IEqualityComparer<TSource>? comparer)
        {
            if (self is IDistinct2Enumerable<TSource> distinct)
            {
                return distinct.Distinct(comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Distinct(comparer));
            }

            return self.AsEnumerable().Distinct(comparer).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> DistinctBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            if (self is IDistinctByEnumerable<TSource> distinctBy)
            {
                return distinctBy.DistinctBy(keySelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.DistinctBy(keySelector));
            }

            return self.AsEnumerable().DistinctBy(keySelector).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> DistinctBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
        {
            if (self is IDistinctBy2Enumerable<TSource> distinctBy)
            {
                return distinctBy.DistinctBy(keySelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.DistinctBy(keySelector, comparer));
            }

            return self.AsEnumerable().DistinctBy(keySelector, comparer).ToV2Enumerable();
        }

        public static TSource ElementAt<TSource>(this IV2Enumerable<TSource> self, Index index)
        {
            if (self is IElementAtEnumerable<TSource> elementAt)
            {
                return elementAt.ElementAt(index);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ElementAt(index);
            }

            return self.AsEnumerable().ElementAt(index);
        }

        public static TSource ElementAt<TSource>(this IV2Enumerable<TSource> self, int index)
        {
            if (self is IElementAt2Enumerable<TSource> elementAt)
            {
                return elementAt.ElementAt(index);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ElementAt(index);
            }

            return self.AsEnumerable().ElementAt(index);
        }

        public static TSource? ElementAtOrDefault<TSource>(this IV2Enumerable<TSource> self, Index index)
        {
            if (self is IElementAtOrDefaultEnumerable<TSource> elementAtOrDefault)
            {
                return elementAtOrDefault.ElementAtOrDefault(index);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ElementAtOrDefault(index);
            }

            return self.AsEnumerable().ElementAtOrDefault(index);
        }

        public static TSource? ElementAtOrDefault<TSource>(this IV2Enumerable<TSource> self, int index)
        {
            if (self is IElementAtOrDefault2Enumerable<TSource> elementAtOrDefault)
            {
                return elementAtOrDefault.ElementAtOrDefault(index);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ElementAtOrDefault(index);
            }

            return self.AsEnumerable().ElementAtOrDefault(index);
        }

        public static IV2Enumerable<TResult> Empty<TResult>()
        {
            //// TODO
            throw new System.NotImplementedException();
        }

        public static IV2Enumerable<TSource> Except<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second)
        {
            if (first is IExceptEnumerable<TSource> except)
            {
                return except.Except(second);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Except(second));
            }

            return first.AsEnumerable().Except(second).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Except<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            if (first is IExcept2Enumerable<TSource> except)
            {
                return except.Except(second, comparer);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Except(second, comparer));
            }

            return first.AsEnumerable().Except(second, comparer).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> ExceptBy<TSource, TKey>(this IV2Enumerable<TSource> first, IV2Enumerable<TKey> second, Func<TSource, TKey> keySelector)
        {
            if (first is IExceptByEnumerable<TSource> exceptBy)
            {
                return exceptBy.ExceptBy(second, keySelector);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.ExceptBy(second, keySelector));
            }

            return first.AsEnumerable().ExceptBy(second, keySelector).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> ExceptBy<TSource, TKey>(
            this IV2Enumerable<TSource> first,
            IV2Enumerable<TKey> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (first is IExceptBy2Enumerable<TSource> exceptBy)
            {
                return exceptBy.ExceptBy(second, keySelector, comparer);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.ExceptBy(second, keySelector, comparer));
            }

            return first.AsEnumerable().ExceptBy(second, keySelector, comparer).ToV2Enumerable();
        }

        public static TSource First<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IFirstEnumerable<TSource> first)
            {
                return first.First();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.First();
            }

            return self.AsEnumerable().First();
        }

        public static TSource First<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is IFirst2Enumerable<TSource> first)
            {
                return first.First(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.First(predicate);
            }

            return self.AsEnumerable().First(predicate);
        }

        public static TSource? FirstOrDefault<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IFirstOrDefaultEnumerable<TSource> firstOrDefault)
            {
                return firstOrDefault.FirstOrDefault();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.FirstOrDefault();
            }

            return self.AsEnumerable().FirstOrDefault();
        }

        public static TSource FirstOrDefault<TSource>(this IV2Enumerable<TSource> self, TSource defaultValue)
        {
            if (self is IFirstOrDefault2Enumerable<TSource> firstOrDefault)
            {
                return firstOrDefault.FirstOrDefault(defaultValue);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.FirstOrDefault(defaultValue);
            }

            return self.AsEnumerable().FirstOrDefault(defaultValue);
        }

        public static TSource? FirstOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is IFirstOrDefault3Enumerable<TSource> firstOrDefault)
            {
                return firstOrDefault.FirstOrDefault(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.FirstOrDefault(predicate);
            }

            return self.AsEnumerable().FirstOrDefault(predicate);
        }

        public static TSource FirstOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (self is IFirstOrDefault4Enumerable<TSource> firstOrDefault)
            {
                return firstOrDefault.FirstOrDefault(predicate, defaultValue);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.FirstOrDefault(predicate, defaultValue);
            }

            return self.AsEnumerable().FirstOrDefault(predicate, defaultValue);
        }

        public static IV2Enumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IV2Enumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (self is IGroupByEnumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, elementSelector, resultSelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupBy(keySelector, elementSelector, resultSelector, comparer));
            }

            return self.AsEnumerable().GroupBy(keySelector, elementSelector, (key, enumerable) => resultSelector(key, enumerable.ToV2Enumerable()), comparer).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IV2Enumerable<TElement>, TResult> resultSelector)
        {
            if (self is IGroupBy2Enumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, elementSelector, resultSelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupBy(keySelector, elementSelector, resultSelector));
            }

            return self.AsEnumerable().GroupBy(keySelector, elementSelector, (key, enumerable) => resultSelector(key, enumerable.ToV2Enumerable())).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> GroupBy<TSource, TKey, TResult>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TKey, IV2Enumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (self is IGroupBy3Enumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, resultSelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupBy(keySelector, resultSelector, comparer));
            }

            return self.AsEnumerable().GroupBy(keySelector, (key, enumerable) => resultSelector(key, enumerable.ToV2Enumerable()), comparer).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> GroupBy<TSource, TKey, TResult>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TKey, IV2Enumerable<TSource>, TResult> resultSelector)
        {
            if (self is IGroupBy4Enumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, resultSelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupBy(keySelector, resultSelector));
            }

            return self.AsEnumerable().GroupBy(keySelector, (key, enumerable) => resultSelector(key, enumerable.ToV2Enumerable())).ToV2Enumerable();
        }

        public static IV2Enumerable<IV2Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            if (self is IGroupBy5Enumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupBy(keySelector));
            }

            return self.AsEnumerable().GroupBy(keySelector).Select(ToV2Grouping).ToV2Enumerable();
        }

        public static IV2Enumerable<IV2Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            if (self is IGroupBy6Enumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, elementSelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupBy(keySelector, elementSelector));
            }

            return self.AsEnumerable().GroupBy(keySelector, elementSelector).Select(ToV2Grouping).ToV2Enumerable();
        }

        public static IV2Enumerable<IV2Grouping<TKey, TSource>> GroupBy<TSource, TKey>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (self is IGroupBy7Enumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupBy(keySelector, comparer));
            }

            return self.AsEnumerable().GroupBy(keySelector, comparer).Select(ToV2Grouping).ToV2Enumerable();
        }

        public static IV2Enumerable<IV2Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (self is IGroupBy8Enumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, elementSelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupBy(keySelector, elementSelector, comparer));
            }

            return self.AsEnumerable().GroupBy(keySelector, elementSelector, comparer).Select(ToV2Grouping).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
            this IV2Enumerable<TOuter> outer,
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IV2Enumerable<TInner>, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (outer is IGroupJoinEnumerable<TOuter> groupJoin)
            {
                return groupJoin.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
            }

            if (outer is IAggregatedOverloadEnumerable<TOuter> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer));
            }

            return outer.AsEnumerable().GroupJoin(inner, outerKeySelector, innerKeySelector, (element, sequence) => resultSelector(element, sequence.ToV2Enumerable()), comparer).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
            this IV2Enumerable<TOuter> outer,
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IV2Enumerable<TInner>, TResult> resultSelector)
        {
            if (outer is IGroupJoin2Enumerable<TOuter> groupJoin)
            {
                return groupJoin.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector);
            }

            if (outer is IAggregatedOverloadEnumerable<TOuter> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector));
            }

            return outer.AsEnumerable().GroupJoin(inner, outerKeySelector, innerKeySelector, (element, sequence) => resultSelector(element, sequence.ToV2Enumerable())).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Intersect<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            if (first is IIntersectEnumerable<TSource> intersect)
            {
                return intersect.Intersect(second, comparer);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Intersect(second, comparer));
            }

            return first.AsEnumerable().Intersect(second, comparer).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Intersect<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second)
        {
            if (first is IIntersect2Enumerable<TSource> intersect)
            {
                return intersect.Intersect(second);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Intersect(second));
            }

            return first.AsEnumerable().Intersect(second).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> IntersectBy<TSource, TKey>(this IV2Enumerable<TSource> first, IV2Enumerable<TKey> second, Func<TSource, TKey> keySelector)
        {
            if (first is IIntersectByEnumerable<TSource> intersectBy)
            {
                return intersectBy.IntersectBy(second, keySelector);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.IntersectBy(second, keySelector));
            }

            return first.AsEnumerable().IntersectBy(second, keySelector).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> IntersectBy<TSource, TKey>(
            this IV2Enumerable<TSource> first,
            IV2Enumerable<TKey> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (first is IIntersectBy2Enumerable<TSource> intersectBy)
            {
                return intersectBy.IntersectBy(second, keySelector, comparer);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.IntersectBy(second, keySelector, comparer));
            }

            return first.AsEnumerable().IntersectBy(second, keySelector, comparer).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IV2Enumerable<TOuter> outer,
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            if (outer is IJoinEnumerable<TOuter> join)
            {
                return join.Join(inner, outerKeySelector, innerKeySelector, resultSelector);
            }

            if (outer is IAggregatedOverloadEnumerable<TOuter> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Join(inner, outerKeySelector, innerKeySelector, resultSelector));
            }

            return outer.AsEnumerable().Join(inner, outerKeySelector, innerKeySelector, resultSelector).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IV2Enumerable<TOuter> outer,
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (outer is IJoin2Enumerable<TOuter> join)
            {
                return join.Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
            }

            if (outer is IAggregatedOverloadEnumerable<TOuter> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer));
            }

            return outer.AsEnumerable().Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer).ToV2Enumerable();
        }

        public static TSource Last<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ILastEnumerable<TSource> last)
            {
                return last.Last();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Last();
            }

            return self.AsEnumerable().Last();
        }

        public static TSource Last<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ILast2Enumerable<TSource> last)
            {
                return last.Last(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Last(predicate);
            }

            return self.AsEnumerable().Last(predicate);
        }

        public static TSource? LastOrDefault<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ILastOrDefaultEnumerable<TSource> lastOrDefault)
            {
                return lastOrDefault.LastOrDefault();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.LastOrDefault();
            }

            return self.AsEnumerable().LastOrDefault();
        }

        public static TSource LastOrDefault<TSource>(this IV2Enumerable<TSource> self, TSource defaultValue)
        {
            if (self is ILastOrDefault2Enumerable<TSource> lastOrDefault)
            {
                return lastOrDefault.LastOrDefault(defaultValue);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.LastOrDefault(defaultValue);
            }

            return self.AsEnumerable().LastOrDefault(defaultValue);
        }

        public static TSource? LastOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ILastOrDefault3Enumerable<TSource> lastOrDefault)
            {
                return lastOrDefault.LastOrDefault(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.LastOrDefault(predicate);
            }

            return self.AsEnumerable().LastOrDefault(predicate);
        }

        public static TSource LastOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (self is ILastOrDefault4Enumerable<TSource> lastOrDefault)
            {
                return lastOrDefault.LastOrDefault(predicate, defaultValue);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.LastOrDefault(predicate, defaultValue);
            }

            return self.AsEnumerable().LastOrDefault(predicate, defaultValue);
        }

        public static long LongCount<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ILongCountEnumerable<TSource> longCount)
            {
                return longCount.LongCount(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.LongCount(predicate);
            }

            return self.AsEnumerable().LongCount(predicate);
        }

        public static long LongCount<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ILongCount2Enumerable<TSource> longCount)
            {
                return longCount.LongCount();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.LongCount();
            }

            return self.AsEnumerable().LongCount();
        }

        public static long Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static decimal Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal> selector)
        {
            if (self is IMax2Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static double Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double> selector)
        {
            if (self is IMax3Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static int Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int> selector)
        {
            if (self is IMax4Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static decimal? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal?> selector)
        {
            if (self is IMax5Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static TSource? Max<TSource>(this IV2Enumerable<TSource> self, IComparer<TSource>? comparer)
        {
            if (self is IMax6Enumerable<TSource> max)
            {
                return max.Max(comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(comparer);
            }

            return self.AsEnumerable().Max(comparer);
        }

        public static int? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int?> selector)
        {
            if (self is IMax7Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static long? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long?> selector)
        {
            if (self is IMax8Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static float? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float?> selector)
        {
            if (self is IMax9Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static TResult? Max<TSource, TResult>(this IV2Enumerable<TSource> self, Func<TSource, TResult> selector)
        {
            if (self is IMax10Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static double? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double?> selector)
        {
            if (self is IMax11Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static TSource? Max<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IMax12Enumerable<TSource> max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static float Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float> selector)
        {
            if (self is IMax13Enumerable<TSource> max)
            {
                return max.Max(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max(selector);
            }

            return self.AsEnumerable().Max(selector);
        }

        public static float Max(this IV2Enumerable<float> self)
        {
            if (self is IMax14Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<float> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static float? Max(this IV2Enumerable<float?> self)
        {
            if (self is IMax15Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<float?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static long? Max(this IV2Enumerable<long?> self)
        {
            if (self is IMax16Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<long?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static int? Max(this IV2Enumerable<int?> self)
        {
            if (self is IMax17Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<int?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static double? Max(this IV2Enumerable<double?> self)
        {
            if (self is IMax18Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<double?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static decimal? Max(this IV2Enumerable<decimal?> self)
        {
            if (self is IMax19Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<decimal?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static long Max(this IV2Enumerable<long> self)
        {
            if (self is IMax20Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<long> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static int Max(this IV2Enumerable<int> self)
        {
            if (self is IMax21Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<int> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static double Max(this IV2Enumerable<double> self)
        {
            if (self is IMax22Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<double> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static decimal Max(this IV2Enumerable<decimal> self)
        {
            if (self is IMax23Enumerable max)
            {
                return max.Max();
            }

            if (self is IAggregatedOverloadEnumerable<decimal> aggregatedOverload)
            {
                return aggregatedOverload.Source.Max();
            }

            return self.AsEnumerable().Max();
        }

        public static TSource? MaxBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            if (self is IMaxByEnumerable<TSource> maxBy)
            {
                return maxBy.MaxBy(keySelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.MaxBy(keySelector);
            }

            return self.AsEnumerable().MaxBy(keySelector);
        }

        public static TSource? MaxBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
        {
            if (self is IMaxBy2Enumerable<TSource> maxBy)
            {
                return maxBy.MaxBy(keySelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.MaxBy(keySelector, comparer);
            }

            return self.AsEnumerable().MaxBy(keySelector, comparer);
        }

        public static decimal Min(this IV2Enumerable<decimal> self)
        {
            if (self is IMinEnumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<decimal> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static TResult? Min<TSource, TResult>(this IV2Enumerable<TSource> self, Func<TSource, TResult> selector)
        {
            if (self is IMin2Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static float Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float> selector)
        {
            if (self is IMin3Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static float? Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float?> selector)
        {
            if (self is IMin4Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static int? Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int?> selector)
        {
            if (self is IMin5Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static double? Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double?> selector)
        {
            if (self is IMin6Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static decimal? Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal?> selector)
        {
            if (self is IMin7Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static long Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long> selector)
        {
            if (self is IMin8Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static int Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int> selector)
        {
            if (self is IMin9Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static decimal Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal> selector)
        {
            if (self is IMin10Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static TSource? Min<TSource>(this IV2Enumerable<TSource> self, IComparer<TSource>? comparer)
        {
            if (self is IMin11Enumerable<TSource> min)
            {
                return min.Min(comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(comparer);
            }

            return self.AsEnumerable().Min(comparer);
        }

        public static TSource? Min<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IMin12Enumerable<TSource> min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static long? Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long?> selector)
        {
            if (self is IMin13Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static double Min<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double> selector)
        {
            if (self is IMin14Enumerable<TSource> min)
            {
                return min.Min(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min(selector);
            }

            return self.AsEnumerable().Min(selector);
        }

        public static float Min(this IV2Enumerable<float> self)
        {
            if (self is IMin15Enumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<float> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static float? Min(this IV2Enumerable<float?> self)
        {
            if (self is IMin16Enumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<float?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static long? Min(this IV2Enumerable<long?> self)
        {
            if (self is IMin17Enumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<long?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static int? Min(this IV2Enumerable<int?> self)
        {
            if (self is IMin18Enumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<int?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static double? Min(this IV2Enumerable<double?> self)
        {
            if (self is IMin19Enumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<double?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static decimal? Min(this IV2Enumerable<decimal?> self)
        {
            if (self is IMin20Enumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<decimal?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static double Min(this IV2Enumerable<double> self)
        {
            if (self is IMin21Enumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<double> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static long Min(this IV2Enumerable<long> self)
        {
            if (self is IMin22Enumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<long> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static int Min(this IV2Enumerable<int> self)
        {
            if (self is IMin23Enumerable min)
            {
                return min.Min();
            }

            if (self is IAggregatedOverloadEnumerable<int> aggregatedOverload)
            {
                return aggregatedOverload.Source.Min();
            }

            return self.AsEnumerable().Min();
        }

        public static TSource? MinBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
        {
            if (self is IMinByEnumerable<TSource> minBy)
            {
                return minBy.MinBy(keySelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.MinBy(keySelector, comparer);
            }

            return self.AsEnumerable().MinBy(keySelector, comparer);
        }

        public static TSource? MinBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            if (self is IMinBy2Enumerable<TSource> minBy)
            {
                return minBy.MinBy(keySelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.MinBy(keySelector);
            }

            return self.AsEnumerable().MinBy(keySelector);
        }

        /*public static IV2Enumerable<TResult> OfType<TResult>(this IV2Enumerable self)
        {
            //// TODO
            throw new System.NotImplementedException();
        }*/

        public static IV2OrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
        {
            if (self is IOrderByEnumerable<TSource> orderBy)
            {
                return orderBy.OrderBy(keySelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                var ordered = aggregatedOverload.Source.OrderBy(keySelector, comparer);
                var aggregated = aggregatedOverload.Create(ordered);
                return new V2OrderedEnumerableAggregatedEnumerable<TSource>(ordered, aggregated);
            }

            return self.AsEnumerable().OrderBy(keySelector, comparer).ToV2OrderedEnumerable();
        }

        private sealed class V2OrderedEnumerableAggregatedEnumerable<TElement> : IV2OrderedEnumerable<TElement>, IAggregatedOverloadEnumerable<TElement>
        {
            private readonly IV2OrderedEnumerable<TElement> ordered;

            private readonly IAggregatedOverloadEnumerable<TElement> aggregated;

            public V2OrderedEnumerableAggregatedEnumerable(IV2OrderedEnumerable<TElement> ordered, IAggregatedOverloadEnumerable<TElement> aggregated)
            {
                this.ordered = ordered;
                this.aggregated = aggregated;
            }

            public IV2Enumerable<TElement> Source => this.ordered;

            public IAggregatedOverloadEnumerable<TSource> Create<TSource>(IV2Enumerable<TSource> source)
            {
                return this.aggregated.Create(source);
            }

            public IV2OrderedEnumerable<TElement> CreateOrderedEnumerable<TKey>(Func<TElement, TKey> keySelector, IComparer<TKey>? comparer, bool descending)
            {
                return this.ordered.CreateOrderedEnumerable(keySelector, comparer, descending);
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                return this.aggregated.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public static IV2OrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            if (self is IOrderBy2Enumerable<TSource> orderBy)
            {
                return orderBy.OrderBy(keySelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                var ordered = aggregatedOverload.Source.OrderBy(keySelector);
                var aggregated = aggregatedOverload.Create(ordered);
                return new V2OrderedEnumerableAggregatedEnumerable<TSource>(ordered, aggregated);
            }

            return self.AsEnumerable().OrderBy(keySelector).ToV2OrderedEnumerable();
        }

        public static IV2OrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            if (self is IOrderByDescendingEnumerable<TSource> orderByDescending)
            {
                return orderByDescending.OrderByDescending(keySelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                var ordered = aggregatedOverload.Source.OrderByDescending(keySelector);
                var aggregated = aggregatedOverload.Create(ordered);
                return new V2OrderedEnumerableAggregatedEnumerable<TSource>(ordered, aggregated);
            }

            return self.AsEnumerable().OrderByDescending(keySelector).ToV2OrderedEnumerable();
        }

        public static IV2OrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            IComparer<TKey>? comparer)
        {
            if (self is IOrderByDescending2Enumerable<TSource> orderByDescending)
            {
                return orderByDescending.OrderByDescending(keySelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                var ordered = aggregatedOverload.Source.OrderByDescending(keySelector, comparer);
                var aggregated = aggregatedOverload.Create(ordered);
                return new V2OrderedEnumerableAggregatedEnumerable<TSource>(ordered, aggregated);
            }

            return self.AsEnumerable().OrderByDescending(keySelector, comparer).ToV2OrderedEnumerable();
        }

        public static IV2Enumerable<TSource> Prepend<TSource>(this IV2Enumerable<TSource> self, TSource element)
        {
            if (self is IPrependEnumerable<TSource> prepend)
            {
                return prepend.Prepend(element);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Prepend(element));
            }

            return self.AsEnumerable().Prepend(element).ToV2Enumerable();
        }

        /*public static IV2Enumerable<int> Range(int start, int count)
        {
            //// TODO
            throw new System.NotImplementedException();
        }*/

        /*public static IV2Enumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            //// TODO
            throw new System.NotImplementedException();
        }*/

        public static IV2Enumerable<TSource> Reverse<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IReverseEnumerable<TSource> reverse)
            {
                return reverse.Reverse();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Reverse());
            }

            return self.AsEnumerable().Reverse().ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> Select<TSource, TResult>(this IV2Enumerable<TSource> self, Func<TSource, int, TResult> selector)
        {
            if (self is ISelectEnumerable<TSource> select)
            {
                return select.Select(selector);            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Select(selector));
            }

            return self.AsEnumerable().Select(selector).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> Select<TSource, TResult>(this IV2Enumerable<TSource> self, Func<TSource, TResult> selector)
        {
            if (self is ISelect2Enumerable<TSource> select)
            {
                return select.Select(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Select(selector));
            }

            return self.AsEnumerable().Select(selector).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> SelectMany<TSource, TResult>(this IV2Enumerable<TSource> self, Func<TSource, int, IV2Enumerable<TResult>> selector)
        {
            if (self is ISelectManyEnumerable<TSource> selectMany)
            {
                return selectMany.SelectMany(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.SelectMany(selector));
            }

            return self.AsEnumerable().SelectMany(selector).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> SelectMany<TSource, TCollection, TResult>(
            this IV2Enumerable<TSource> self,
            Func<TSource, IV2Enumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            if (self is ISelectMany2Enumerable<TSource> selectMany)
            {
                return selectMany.SelectMany(collectionSelector, resultSelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.SelectMany(collectionSelector, resultSelector));
            }

            return self.AsEnumerable().SelectMany(collectionSelector, resultSelector).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> SelectMany<TSource, TCollection, TResult>(
            this IV2Enumerable<TSource> self,
            Func<TSource, int, IV2Enumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            if (self is ISelectMany3Enumerable<TSource> selectMany)
            {
                return selectMany.SelectMany(collectionSelector, resultSelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.SelectMany(collectionSelector, resultSelector));
            }

            return self.AsEnumerable().SelectMany(collectionSelector, resultSelector).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> SelectMany<TSource, TResult>(this IV2Enumerable<TSource> self, Func<TSource, IV2Enumerable<TResult>> selector)
        {
            if (self is ISelectMany4Enumerable<TSource> selectMany)
            {
                return selectMany.SelectMany(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.SelectMany(selector));
            }

            return self.AsEnumerable().SelectMany(selector).ToV2Enumerable();
        }

        public static bool SequenceEqual<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second)
        {
            if (first is ISequenceEqualEnumerable<TSource> sequenceEqual)
            {
                return sequenceEqual.SequenceEqual(second);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.SequenceEqual(second);
            }

            return first.AsEnumerable().SequenceEqual(second);
        }

        public static bool SequenceEqual<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            if (first is ISequenceEqual2Enumerable<TSource> sequenceEqual)
            {
                return sequenceEqual.SequenceEqual(second, comparer);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.SequenceEqual(second, comparer);
            }

            return first.AsEnumerable().SequenceEqual(second, comparer);
        }

        public static TSource Single<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ISingleEnumerable<TSource> single)
            {
                return single.Single();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Single();
            }

            return self.AsEnumerable().Single();
        }

        public static TSource Single<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ISingle2Enumerable<TSource> single)
            {
                return single.Single(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Single(predicate);
            }

            return self.AsEnumerable().Single(predicate);
        }

        public static TSource SingleOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (self is ISingleOrDefaultEnumerable<TSource> singleOrDefault)
            {
                return singleOrDefault.SingleOrDefault(predicate, defaultValue);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.SingleOrDefault(predicate, defaultValue);
            }

            return self.AsEnumerable().SingleOrDefault(predicate, defaultValue);
        }

        public static TSource SingleOrDefault<TSource>(this IV2Enumerable<TSource> self, TSource defaultValue)
        {
            if (self is ISingleOrDefault2Enumerable<TSource> singleOrDefault)
            {
                return singleOrDefault.SingleOrDefault(defaultValue);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.SingleOrDefault(defaultValue);
            }

            return self.AsEnumerable().SingleOrDefault(defaultValue);
        }

        public static TSource? SingleOrDefault<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ISingleOrDefault3Enumerable<TSource> singleOrDefault)
            {
                return singleOrDefault.SingleOrDefault();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.SingleOrDefault();
            }

            return self.AsEnumerable().SingleOrDefault();
        }

        public static TSource? SingleOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ISingleOrDefault4Enumerable<TSource> singleOrDefault)
            {
                return singleOrDefault.SingleOrDefault(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.SingleOrDefault(predicate);
            }

            return self.AsEnumerable().SingleOrDefault(predicate);
        }

        public static IV2Enumerable<TSource> Skip<TSource>(this IV2Enumerable<TSource> self, int count)
        {
            if (self is ISkipEnumerable<TSource> skip)
            {
                return skip.Skip(count);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Skip(count));
            }

            return self.AsEnumerable().Skip(count).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> SkipLast<TSource>(this IV2Enumerable<TSource> self, int count)
        {
            if (self is ISkipLastEnumerable<TSource> skipLast)
            {
                return skipLast.SkipLast(count);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.SkipLast(count));
            }

            return self.AsEnumerable().SkipLast(count).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> SkipWhile<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ISkipWhileEnumerable<TSource> skipWhile)
            {
                return skipWhile.SkipWhile(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.SkipWhile(predicate));
            }

            return self.AsEnumerable().SkipWhile(predicate).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> SkipWhile<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int, bool> predicate)
        {
            if (self is ISkipWhile2Enumerable<TSource> skipWhile)
            {
                return skipWhile.SkipWhile(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.SkipWhile(predicate));
            }

            return self.AsEnumerable().SkipWhile(predicate).ToV2Enumerable();
        }

        public static int Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int> selector)
        {
            if (self is ISumEnumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static long Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long> selector)
        {
            if (self is ISum2Enumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static decimal? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal?> selector)
        {
            if (self is ISum3Enumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static long? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long?> selector)
        {
            if (self is ISum4Enumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static int? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int?> selector)
        {
            if (self is ISum5Enumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static double Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double> selector)
        {
            if (self is ISum6Enumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static float? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float?> selector)
        {
            if (self is ISum7Enumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static float Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float> selector)
        {
            if (self is ISum8Enumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static double? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double?> selector)
        {
            if (self is ISum9Enumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static decimal Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal> selector)
        {
            if (self is ISum10Enumerable<TSource> sum)
            {
                return sum.Sum(selector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum(selector);
            }

            return self.AsEnumerable().Sum(selector);
        }

        public static long? Sum(this IV2Enumerable<long?> self)
        {
            if (self is ISum11Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<long?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static float? Sum(this IV2Enumerable<float?> self)
        {
            if (self is ISum12Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<float?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static int? Sum(this IV2Enumerable<int?> self)
        {
            if (self is ISum13Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<int?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static double? Sum(this IV2Enumerable<double?> self)
        {
            if (self is ISum14Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<double?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static decimal? Sum(this IV2Enumerable<decimal?> self)
        {
            if (self is ISum15Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<decimal?> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static long Sum(this IV2Enumerable<long> self)
        {
            if (self is ISum16Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<long> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static int Sum(this IV2Enumerable<int> self)
        {
            if (self is ISum17Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<int> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static double Sum(this IV2Enumerable<double> self)
        {
            if (self is ISum18Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<double> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static decimal Sum(this IV2Enumerable<decimal> self)
        {
            if (self is ISum19Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<decimal> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static float Sum(this IV2Enumerable<float> self)
        {
            if (self is ISum20Enumerable sum)
            {
                return sum.Sum();
            }

            if (self is IAggregatedOverloadEnumerable<float> aggregatedOverload)
            {
                return aggregatedOverload.Source.Sum();
            }

            return self.AsEnumerable().Sum();
        }

        public static IV2Enumerable<TSource> Take<TSource>(this IV2Enumerable<TSource> self, Range range)
        {
            if (self is ITakeEnumerable<TSource> take)
            {
                return take.Take(range);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Take(range));
            }

            return self.AsEnumerable().Take(range).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Take<TSource>(this IV2Enumerable<TSource> self, int count)
        {
            if (self is ITake2Enumerable<TSource> take)
            {
                return take.Take(count);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Take(count));
            }

            return self.AsEnumerable().Take(count).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> TakeLast<TSource>(this IV2Enumerable<TSource> self, int count)
        {
            if (self is ITakeLastEnumerable<TSource> takeLast)
            {
                return takeLast.TakeLast(count);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.TakeLast(count));
            }

            return self.AsEnumerable().TakeLast(count).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> TakeWhile<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ITakeWhileEnumerable<TSource> takeWhile)
            {
                return takeWhile.TakeWhile(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.TakeWhile(predicate));
            }

            return self.AsEnumerable().TakeWhile(predicate).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> TakeWhile<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int, bool> predicate)
        {
            if (self is ITakeWhile2Enumerable<TSource> takeWhile)
            {
                return takeWhile.TakeWhile(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.TakeWhile(predicate));
            }

            return self.AsEnumerable().TakeWhile(predicate).ToV2Enumerable();
        }

        /*public static IV2OrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IV2OrderedEnumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            //// TODO
            throw new System.NotImplementedException();
        }

        public static IV2OrderedEnumerable<TSource> ThenBy<TSource, TKey>(this IV2OrderedEnumerable<TSource> self, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
        {
            //// TODO
            throw new System.NotImplementedException();
        }

        public static IV2OrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(this IV2OrderedEnumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            //// TODO
            throw new System.NotImplementedException();
        }

        public static IV2OrderedEnumerable<TSource> ThenByDescending<TSource, TKey>(
            this IV2OrderedEnumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            IComparer<TKey>? comparer)
        {
            //// TODO
            throw new System.NotImplementedException();
        }*/

        public static TSource[] ToArray<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IToArrayEnumerable<TSource> toArray)
            {
                return toArray.ToArray();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ToArray();
            }

            return self.AsEnumerable().ToArray();
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
            where TKey : notnull
        {
            if (self is IToDictionaryEnumerable<TSource> toDictionary)
            {
                return toDictionary.ToDictionary(keySelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ToDictionary(keySelector);
            }

            return self.AsEnumerable().ToDictionary(keySelector);
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
            where TKey : notnull
        {
            if (self is IToDictionary2Enumerable<TSource> toDictionary)
            {
                return toDictionary.ToDictionary(keySelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ToDictionary(keySelector, comparer);
            }

            return self.AsEnumerable().ToDictionary(keySelector, comparer);
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
            where TKey : notnull
        {
            if (self is IToDictionary3Enumerable<TSource> toDictionary)
            {
                return toDictionary.ToDictionary(keySelector, elementSelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ToDictionary(keySelector, elementSelector);
            }

            return self.AsEnumerable().ToDictionary(keySelector, elementSelector);
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer)
            where TKey : notnull
        {
            if (self is IToDictionary4Enumerable<TSource> toDictionary)
            {
                return toDictionary.ToDictionary(keySelector, elementSelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ToDictionary(keySelector, elementSelector, comparer);
            }

            return self.AsEnumerable().ToDictionary(keySelector, elementSelector, comparer);
        }

        public static HashSet<TSource> ToHashSet<TSource>(this IV2Enumerable<TSource> self, IEqualityComparer<TSource>? comparer)
        {
            if (self is IToHashSetEnumerable<TSource> toHashSet)
            {
                return toHashSet.ToHashSet(comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ToHashSet(comparer);
            }

            return self.AsEnumerable().ToHashSet(comparer);
        }

        public static HashSet<TSource> ToHashSet<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IToHashSet2Enumerable<TSource> toHashSet)
            {
                return toHashSet.ToHashSet();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ToHashSet();
            }

            return self.AsEnumerable().ToHashSet();
        }

        public static List<TSource> ToList<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IToListEnumerable<TSource> toList)
            {
                return toList.ToList();
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.ToList();
            }

            return self.AsEnumerable().ToList();
        }

        public static IV2Lookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (self is IToLookupEnumerable<TSource> toLookup)
            {
                return toLookup.ToLookup(keySelector, elementSelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                var lookup = aggregatedOverload.Source.ToLookup(keySelector, elementSelector, comparer);
                var aggregated = aggregatedOverload.Create(lookup);
                return new V2LookupAggregatedOverload<TKey, TElement>(lookup, aggregated);
            }

            return self.AsEnumerable().ToLookup(keySelector, elementSelector, comparer).ToV2Lookup();
        }

        private sealed class V2LookupAggregatedOverload<TKey, TElement> : IV2Lookup<TKey, TElement>, IAggregatedOverloadEnumerable<IV2Grouping<TKey, TElement>>
        {
            private readonly IV2Lookup<TKey, TElement> lookup;

            private readonly IAggregatedOverloadEnumerable<IV2Grouping<TKey, TElement>> aggregated;

            public V2LookupAggregatedOverload(IV2Lookup<TKey, TElement> lookup, IAggregatedOverloadEnumerable<IV2Grouping<TKey, TElement>> aggregated)
            {
                this.lookup = lookup;
                this.aggregated = aggregated;
            }

            public IV2Enumerable<TElement> this[TKey key] => this.lookup[key];

            public IV2Enumerable<IV2Grouping<TKey, TElement>> Source => this.lookup;

            public int Count => this.lookup.Count;

            public bool Contains(TKey key)
            {
                return this.lookup.Contains(key);
            }

            public IAggregatedOverloadEnumerable<TSource> Create<TSource>(IV2Enumerable<TSource> source)
            {
                return this.aggregated.Create(source);
            }

            public IEnumerator<IV2Grouping<TKey, TElement>> GetEnumerator()
            {
                return this.aggregated.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public static IV2Lookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            if (self is IToLookup2Enumerable<TSource> toLookup)
            {
                return toLookup.ToLookup(keySelector, elementSelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                var lookup = aggregatedOverload.Source.ToLookup(keySelector, elementSelector);
                var aggregated = aggregatedOverload.Create(lookup);
                return new V2LookupAggregatedOverload<TKey, TElement>(lookup, aggregated);
            }

            return self.AsEnumerable().ToLookup(keySelector, elementSelector).ToV2Lookup();
        }

        public static IV2Lookup<TKey, TSource> ToLookup<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            if (self is IToLookup3Enumerable<TSource> toLookup)
            {
                return toLookup.ToLookup(keySelector);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                var lookup = aggregatedOverload.Source.ToLookup(keySelector);
                var aggregated = aggregatedOverload.Create(lookup);
                return new V2LookupAggregatedOverload<TKey, TSource>(lookup, aggregated);
            }

            return self.AsEnumerable().ToLookup(keySelector).ToV2Lookup();
        }

        public static IV2Lookup<TKey, TSource> ToLookup<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
        {
            if (self is IToLookup4Enumerable<TSource> toLookup)
            {
                return toLookup.ToLookup(keySelector, comparer);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                var lookup = aggregatedOverload.Source.ToLookup(keySelector, comparer);
                var aggregated = aggregatedOverload.Create(lookup);
                return new V2LookupAggregatedOverload<TKey, TSource>(lookup, aggregated);
            }

            return self.AsEnumerable().ToLookup(keySelector, comparer).ToV2Lookup();
        }

        public static bool TryGetNonEnumeratedCount<TSource>(this IV2Enumerable<TSource> self, out int count)
        {
            if (self is ITryGetNonEnumeratedCountEnumerable<TSource> tryGetNonEnumeratedCount)
            {
                return tryGetNonEnumeratedCount.TryGetNonEnumeratedCount(out count);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Source.TryGetNonEnumeratedCount(out count);
            }

            return self.AsEnumerable().TryGetNonEnumeratedCount(out count);
        }

        public static IV2Enumerable<TSource> Union<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second)
        {
            if (first is IUnionEnumerable<TSource> union)
            {
                return union.Union(second);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Union(second));
            }

            return first.AsEnumerable().Union(second).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Union<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            if (first is IUnion2Enumerable<TSource> union)
            {
                return union.Union(second, comparer);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Union(second, comparer));
            }

            return first.AsEnumerable().Union(second, comparer).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> UnionBy<TSource, TKey>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second, Func<TSource, TKey> keySelector)
        {
            if (first is IUnionByEnumerable<TSource> unionBy)
            {
                return unionBy.UnionBy(second, keySelector);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.UnionBy(second, keySelector));
            }

            return first.AsEnumerable().UnionBy(second, keySelector).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> UnionBy<TSource, TKey>(
            this IV2Enumerable<TSource> first,
            IV2Enumerable<TSource> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (first is IUnionBy2Enumerable<TSource> unionBy)
            {
                return unionBy.UnionBy(second, keySelector, comparer);
            }

            if (first is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.UnionBy(second, keySelector, comparer));
            }

            return first.AsEnumerable().UnionBy(second, keySelector, comparer).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Where<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is IWhereEnumerable<TSource> where)
            {
                return where.Where(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Where(predicate));
            }

            return self.AsEnumerable().Where(predicate).ToV2Enumerable();
        }

        public static IV2Enumerable<TSource> Where<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int, bool> predicate)
        {
            if (self is IWhere2Enumerable<TSource> where)
            {
                return where.Where(predicate);
            }

            if (self is IAggregatedOverloadEnumerable<TSource> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Where(predicate));
            }

            return self.AsEnumerable().Where(predicate).ToV2Enumerable();
        }

        public static IV2Enumerable<(TFirst First, TSecond Second, TThird Third)> Zip<TFirst, TSecond, TThird>(
            this IV2Enumerable<TFirst> first,
            IV2Enumerable<TSecond> second,
            IV2Enumerable<TThird> third)
        {
            if (first is IZipEnumerable<TFirst> zip)
            {
                return zip.Zip(second, third);
            }

            if (first is IAggregatedOverloadEnumerable<TFirst> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Zip(second, third));
            }

            return first.AsEnumerable().Zip(second, third).ToV2Enumerable();
        }

        public static IV2Enumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(this IV2Enumerable<TFirst> first, IV2Enumerable<TSecond> second)
        {
            if (first is IZip2Enumerable<TFirst> zip)
            {
                return zip.Zip(second);
            }

            if (first is IAggregatedOverloadEnumerable<TFirst> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Zip(second));
            }

            return first.AsEnumerable().Zip(second).ToV2Enumerable();
        }

        public static IV2Enumerable<TResult> Zip<TFirst, TSecond, TResult>(
            this IV2Enumerable<TFirst> first,
            IV2Enumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first is IZip3Enumerable<TFirst> zip)
            {
                return zip.Zip(second, resultSelector);
            }

            if (first is IAggregatedOverloadEnumerable<TFirst> aggregatedOverload)
            {
                return aggregatedOverload.Create(aggregatedOverload.Source.Zip(second, resultSelector));
            }

            return first.AsEnumerable().Zip(second, resultSelector).ToV2Enumerable();
        }
    }
}
