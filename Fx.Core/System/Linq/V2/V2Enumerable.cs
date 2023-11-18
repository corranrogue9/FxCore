namespace System.Linq.V2
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

            return self.AggregateDefault(func);
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this IV2Enumerable<TSource> self, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (self is IAggregateEnumerable<TSource> aggregate)
            {
                return aggregate.Aggregate(seed, func);
            }

            return self.AggregateDefault(seed, func);
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(
            this IV2Enumerable<TSource> self,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
        {
            if (self is IAggregateEnumerable<TSource> aggregate)
            {
                return aggregate.Aggregate(seed, func, resultSelector);
            }

            return self.AggregateDefault(seed, func, resultSelector);
        }

        public static bool All<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is IAllEnumerable<TSource> all)
            {
                return all.All(predicate);
            }

            return self.AllDefault(predicate);
        }

        public static bool Any<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IAnyEnumerable<TSource> any)
            {
                return any.Any();
            }

            return self.AnyDefault();
        }

        public static bool Any<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is IAnyEnumerable<TSource> any)
            {
                return any.Any(predicate);
            }

            return self.AnyDefault(predicate);
        }

        public static IV2Enumerable<TSource> Append<TSource>(this IV2Enumerable<TSource> self, TSource element)
        {
            if (self is IAppendEnumerable<TSource> append)
            {
                return append.Append(element);
            }

            return self.AppendDefault(element);
        }

        public static IV2Enumerable<TSource> AsV2Enumerable<TSource>(this IV2Enumerable<TSource> self)
        {
            //// TODO this extension is named differently than v1 linq; this is *probably* a good thing
            return self;
        }

        public static double Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static double Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static double? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double?> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static float Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static double? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long?> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static float? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float?> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static double Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static double? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int?> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static decimal Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static decimal? Average<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal?> selector)
        {
            if (self is IAverageEnumerable<TSource> average)
            {
                return average.Average(selector);
            }

            return self.AverageDefault(selector);
        }

        public static float? Average(this IV2Enumerable<float?> self)
        {
            if (self is IAverage11Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
        }

        public static double? Average(this IV2Enumerable<long?> self)
        {
            if (self is IAverage12Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
        }

        public static double? Average(this IV2Enumerable<int?> self)
        {
            if (self is IAverage13Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
        }

        public static double? Average(this IV2Enumerable<double?> self)
        {
            if (self is IAverage14Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
        }

        public static decimal? Average(this IV2Enumerable<decimal?> self)
        {
            if (self is IAverage15Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
        }

        public static double Average(this IV2Enumerable<long> self)
        {
            if (self is IAverage16Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
        }

        public static double Average(this IV2Enumerable<int> self)
        {
            if (self is IAverage17Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
        }

        public static double Average(this IV2Enumerable<double> self)
        {
            if (self is IAverage18Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
        }

        public static decimal Average(this IV2Enumerable<decimal> self)
        {
            if (self is IAverage19Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
        }

        public static float Average(this IV2Enumerable<float> self)
        {
            if (self is IAverage20Enumerable average)
            {
                return average.Average();
            }

            return self.AverageDefault();
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

            return self.ChunkDefault(size);
        }

        public static IV2Enumerable<TSource> Concat<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second)
        {
            if (first is IConcatEnumerable<TSource> concat)
            {
                return concat.Concat(second);
            }

            return first.ConcatDefault(second);
        }

        public static bool Contains<TSource>(this IV2Enumerable<TSource> self, TSource value, IEqualityComparer<TSource>? comparer)
        {
            if (self is IContainsEnumerable<TSource> contains)
            {
                return contains.Contains(value, comparer);
            }

            return self.ContainsDefault(value, comparer);
        }

        public static bool Contains<TSource>(this IV2Enumerable<TSource> self, TSource value)
        {
            if (self is IContainsEnumerable<TSource> contains)
            {
                return contains.Contains(value);
            }

            return self.ContainsDefault(value);
        }

        public static int Count<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ICountEnumerable<TSource> count)
            {
                return count.Count();
            }

            return self.CountDefault();
        }

        public static int Count<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ICountEnumerable<TSource> count)
            {
                return count.Count(predicate);
            }

            return self.CountDefault(predicate);
        }

        public static IV2Enumerable<TSource?> DefaultIfEmpty<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IDefaultIfEmptyEnumerable<TSource> defaultIfEmpty)
            {
                return defaultIfEmpty.DefaultIfEmpty();
            }

            return self.DefaultIfEmptyDefault();
        }

        public static IV2Enumerable<TSource> DefaultIfEmpty<TSource>(this IV2Enumerable<TSource> self, TSource defaultValue)
        {
            if (self is IDefaultIfEmptyEnumerable<TSource> defaultIfEmpty)
            {
                return defaultIfEmpty.DefaultIfEmpty(defaultValue);
            }

            return self.DefaultIfEmptyDefault(defaultValue);
        }

        public static IV2Enumerable<TSource> Distinct<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IDistinctEnumerable<TSource> distinct)
            {
                return distinct.Distinct();
            }

            return self.DistinctDefault();
        }

        public static IV2Enumerable<TSource> Distinct<TSource>(this IV2Enumerable<TSource> self, IEqualityComparer<TSource>? comparer)
        {
            if (self is IDistinctEnumerable<TSource> distinct)
            {
                return distinct.Distinct(comparer);
            }

            return self.DistinctDefault(comparer);
        }

        public static IV2Enumerable<TSource> DistinctBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            if (self is IDistinctByEnumerable<TSource> distinctBy)
            {
                return distinctBy.DistinctBy(keySelector);
            }

            return self.DistinctByDefault(keySelector);
        }

        public static IV2Enumerable<TSource> DistinctBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
        {
            if (self is IDistinctByEnumerable<TSource> distinctBy)
            {
                return distinctBy.DistinctBy(keySelector, comparer);
            }

            return self.DistinctByDefault(keySelector, comparer);
        }

        public static TSource ElementAt<TSource>(this IV2Enumerable<TSource> self, Index index)
        {
            if (self is IElementAtEnumerable<TSource> elementAt)
            {
                return elementAt.ElementAt(index);
            }

            return self.ElementAtDefault(index);
        }

        public static TSource ElementAt<TSource>(this IV2Enumerable<TSource> self, int index)
        {
            if (self is IElementAtEnumerable<TSource> elementAt)
            {
                return elementAt.ElementAt(index);
            }

            return self.ElementAtDefault(index);
        }

        public static TSource? ElementAtOrDefault<TSource>(this IV2Enumerable<TSource> self, Index index)
        {
            if (self is IElementAtOrDefaultEnumerable<TSource> elementAtOrDefault)
            {
                return elementAtOrDefault.ElementAtOrDefault(index);
            }

            return self.ElementAtOrDefaultDefault(index);
        }

        public static TSource? ElementAtOrDefault<TSource>(this IV2Enumerable<TSource> self, int index)
        {
            if (self is IElementAtOrDefaultEnumerable<TSource> elementAtOrDefault)
            {
                return elementAtOrDefault.ElementAtOrDefault(index);
            }

            return self.ElementAtOrDefaultDefault(index);
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

            return first.ExceptDefault(second);
        }

        public static IV2Enumerable<TSource> Except<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            if (first is IExceptEnumerable<TSource> except)
            {
                return except.Except(second, comparer);
            }

            return first.ExceptDefault(second, comparer);
        }

        public static IV2Enumerable<TSource> ExceptBy<TSource, TKey>(this IV2Enumerable<TSource> first, IV2Enumerable<TKey> second, Func<TSource, TKey> keySelector)
        {
            if (first is IExceptByEnumerable<TSource> exceptBy)
            {
                return exceptBy.ExceptBy(second, keySelector);
            }

            return first.ExceptByDefault(second, keySelector);
        }

        public static IV2Enumerable<TSource> ExceptBy<TSource, TKey>(
            this IV2Enumerable<TSource> first,
            IV2Enumerable<TKey> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (first is IExceptByEnumerable<TSource> exceptBy)
            {
                return exceptBy.ExceptBy(second, keySelector, comparer);
            }

            return first.ExceptByDefault(second, keySelector);
        }

        public static TSource First<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IFirstEnumerable<TSource> first)
            {
                return first.First();
            }

            return self.FirstDefault();
        }

        public static TSource First<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is IFirstEnumerable<TSource> first)
            {
                return first.First(predicate);
            }

            return self.FirstDefault(predicate);
        }

        public static TSource? FirstOrDefault<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IFirstOrDefaultEnumerable<TSource> firstOrDefault)
            {
                return firstOrDefault.FirstOrDefault();
            }

            return self.FirstOrDefaultDefault();
        }

        public static TSource FirstOrDefault<TSource>(this IV2Enumerable<TSource> self, TSource defaultValue)
        {
            if (self is IFirstOrDefaultEnumerable<TSource> firstOrDefault)
            {
                return firstOrDefault.FirstOrDefault(defaultValue);
            }

            return self.FirstOrDefaultDefault(defaultValue);
        }

        public static TSource? FirstOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is IFirstOrDefaultEnumerable<TSource> firstOrDefault)
            {
                return firstOrDefault.FirstOrDefault(predicate);
            }

            return self.FirstOrDefaultDefault(predicate);
        }

        public static TSource FirstOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (self is IFirstOrDefaultEnumerable<TSource> firstOrDefault)
            {
                return firstOrDefault.FirstOrDefault(predicate, defaultValue);
            }

            return self.FirstOrDefaultDefault(predicate, defaultValue);
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

            return self.GroupByDefault(keySelector, elementSelector, resultSelector, comparer);
        }

        public static IV2Enumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IV2Enumerable<TElement>, TResult> resultSelector)
        {
            if (self is IGroupByEnumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, elementSelector, resultSelector);
            }

            return self.GroupByDefault(keySelector, elementSelector, resultSelector);
        }

        public static IV2Enumerable<TResult> GroupBy<TSource, TKey, TResult>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TKey, IV2Enumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (self is IGroupByEnumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, resultSelector, comparer);
            }

            return self.GroupByDefault(keySelector, resultSelector, comparer);
        }

        public static IV2Enumerable<TResult> GroupBy<TSource, TKey, TResult>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TKey, IV2Enumerable<TSource>, TResult> resultSelector)
        {
            if (self is IGroupByEnumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, resultSelector);
            }

            return self.GroupByDefault(keySelector, resultSelector);
        }

        public static IV2Enumerable<IV2Grouping<TKey, TSource>> GroupBy<TSource, TKey>(this IV2Enumerable<TSource> self, Func<TSource, TKey> keySelector)
        {
            if (self is IGroupByEnumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector);
            }

            return self.GroupByDefault(keySelector);
        }

        public static IV2Enumerable<IV2Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            if (self is IGroupByEnumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, elementSelector);
            }

            return self.GroupByDefault(keySelector, elementSelector);
        }

        public static IV2Enumerable<IV2Grouping<TKey, TSource>> GroupBy<TSource, TKey>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (self is IGroupByEnumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, comparer);
            }

            return self.GroupByDefault(keySelector, comparer);
        }

        public static IV2Enumerable<IV2Grouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this IV2Enumerable<TSource> self,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (self is IGroupByEnumerable<TSource> groupBy)
            {
                return groupBy.GroupBy(keySelector, elementSelector, comparer);
            }

            return self.GroupByDefault(keySelector, elementSelector, comparer);
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

            return outer.GroupJoinDefault(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static IV2Enumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
            this IV2Enumerable<TOuter> outer,
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IV2Enumerable<TInner>, TResult> resultSelector)
        {
            if (outer is IGroupJoinEnumerable<TOuter> groupJoin)
            {
                return groupJoin.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector);
            }

            return outer.GroupJoinDefault(inner, outerKeySelector, innerKeySelector, resultSelector);
        }

        public static IV2Enumerable<TSource> Intersect<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            if (first is IIntersectEnumerable<TSource> intersect)
            {
                return intersect.Intersect(second, comparer);
            }

            return first.IntersectDefault(second, comparer);
        }

        public static IV2Enumerable<TSource> Intersect<TSource>(this IV2Enumerable<TSource> first, IV2Enumerable<TSource> second)
        {
            if (first is IIntersectEnumerable<TSource> intersect)
            {
                return intersect.Intersect(second);
            }

            return first.IntersectDefault(second);
        }

        public static IV2Enumerable<TSource> IntersectBy<TSource, TKey>(this IV2Enumerable<TSource> first, IV2Enumerable<TKey> second, Func<TSource, TKey> keySelector)
        {
            if (first is IIntersectByEnumerable<TSource> intersectBy)
            {
                return intersectBy.IntersectBy(second, keySelector);
            }

            return first.IntersectByDefault(second, keySelector);
        }

        public static IV2Enumerable<TSource> IntersectBy<TSource, TKey>(
            this IV2Enumerable<TSource> first,
            IV2Enumerable<TKey> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (first is IIntersectByEnumerable<TSource> intersectBy)
            {
                return intersectBy.IntersectBy(second, keySelector, comparer);
            }

            return first.IntersectByDefault(second, keySelector, comparer);
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

            return outer.JoinDefault(inner, outerKeySelector, innerKeySelector, resultSelector);
        }

        public static IV2Enumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IV2Enumerable<TOuter> outer,
            IV2Enumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey>? comparer)
        {
            if (outer is IJoinEnumerable<TOuter> join)
            {
                return join.Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
            }

            return outer.JoinDefault(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static TSource Last<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ILastEnumerable<TSource> last)
            {
                return last.Last();
            }

            return self.LastDefault();
        }

        public static TSource Last<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ILastEnumerable<TSource> last)
            {
                return last.Last(predicate);
            }

            return self.LastDefault(predicate);
        }

        public static TSource? LastOrDefault<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ILastOrDefaultEnumerable<TSource> lastOrDefault)
            {
                return lastOrDefault.LastOrDefault();
            }

            return self.LastOrDefaultDefault();
        }

        public static TSource LastOrDefault<TSource>(this IV2Enumerable<TSource> self, TSource defaultValue)
        {
            if (self is ILastOrDefaultEnumerable<TSource> lastOrDefault)
            {
                return lastOrDefault.LastOrDefault(defaultValue);
            }

            return self.LastOrDefaultDefault(defaultValue);
        }

        public static TSource? LastOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ILastOrDefaultEnumerable<TSource> lastOrDefault)
            {
                return lastOrDefault.LastOrDefault(predicate);
            }

            return self.LastOrDefaultDefault(predicate);
        }

        public static TSource LastOrDefault<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (self is ILastOrDefaultEnumerable<TSource> lastOrDefault)
            {
                return lastOrDefault.LastOrDefault(predicate, defaultValue);
            }

            return self.LastOrDefaultDefault(predicate, defaultValue);
        }

        public static long LongCount<TSource>(this IV2Enumerable<TSource> self, Func<TSource, bool> predicate)
        {
            if (self is ILongCountEnumerable<TSource> longCount)
            {
                return longCount.LongCount(predicate);
            }

            return self.LongCountDefault(predicate);
        }

        public static long LongCount<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is ILongCountEnumerable<TSource> longCount)
            {
                return longCount.LongCount();
            }

            return self.LongCountDefault();
        }

        public static long Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static decimal Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static double Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static int Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static decimal? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal?> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static TSource? Max<TSource>(this IV2Enumerable<TSource> self, IComparer<TSource>? comparer)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(comparer);
            }

            return self.MaxDefault(comparer);
        }

        public static int? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int?> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static long? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long?> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static float? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float?> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static TResult? Max<TSource, TResult>(this IV2Enumerable<TSource> self, Func<TSource, TResult> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static double? Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double?> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static TSource? Max<TSource>(this IV2Enumerable<TSource> self)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max();
            }

            return self.MaxDefault();
        }

        public static float Max<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float> selector)
        {
            if (self is IMaxEnumerable<TSource> max)
            {
                return max.Max(selector);
            }

            return self.MaxDefault(selector);
        }

        public static float Max(this IV2Enumerable<float> self)
        {
            if (self is IMax14Enumerable max)
            {
                return max.Max();
            }

            return self.MaxDefault();
        }

        public static float? Max(this IV2Enumerable<float?> self)
        {
            if (self is IMax15Enumerable max)
            {
                return max.Max();
            }

            return self.MaxDefault();
        }

        public static long? Max(this IV2Enumerable<long?> self)
        {
            if (self is IMax16Enumerable max)
            {
                return max.Max();
            }

            return self.MaxDefault();
        }

        public static int? Max(this IV2Enumerable<int?> self)
        {
            if (self is IMax17Enumerable max)
            {
                return max.Max();
            }

            return self.MaxDefault();
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
            if (self is IMaxByEnumerable<TSource> maxBy)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinEnumerable<TSource> min)
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
            if (self is IMinByEnumerable<TSource> minBy)
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
            if (self is IOrderByEnumerable<TSource> orderBy)
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
            if (self is IOrderByDescendingEnumerable<TSource> orderByDescending)
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
            if (self is ISelectEnumerable<TSource> select)
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
            if (self is ISelectManyEnumerable<TSource> selectMany)
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
            if (self is ISelectManyEnumerable<TSource> selectMany)
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
            if (first is ISequenceEqualEnumerable<TSource> sequenceEqual)
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
            if (self is ISingleEnumerable<TSource> single)
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
            if (self is ISingleOrDefaultEnumerable<TSource> singleOrDefault)
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
            if (self is ISingleOrDefaultEnumerable<TSource> singleOrDefault)
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
            if (self is ISingleOrDefaultEnumerable<TSource> singleOrDefault)
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

        public static decimal? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal?> selector)
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

        public static long? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, long?> selector)
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

        public static int? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, int?> selector)
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

        public static double Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double> selector)
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

        public static float? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float?> selector)
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

        public static float Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, float> selector)
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

        public static double? Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, double?> selector)
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

        public static decimal Sum<TSource>(this IV2Enumerable<TSource> self, Func<TSource, decimal> selector)
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
            if (self is ITakeEnumerable<TSource> take)
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
            if (self is IToDictionaryEnumerable<TSource> toDictionary)
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
            if (self is IToDictionaryEnumerable<TSource> toDictionary)
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
            if (self is IToDictionaryEnumerable<TSource> toDictionary)
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
            if (self is IToHashSetEnumerable<TSource> toHashSet)
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
            if (self is IToLookupEnumerable<TSource> toLookup)
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
            if (self is IToLookupEnumerable<TSource> toLookup)
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
            if (self is IToLookupEnumerable<TSource> toLookup)
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
            if (first is IUnionEnumerable<TSource> union)
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
            if (first is IUnionByEnumerable<TSource> unionBy)
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
            if (first is IZipEnumerable<TFirst> zip)
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
            if (first is IZipEnumerable<TFirst> zip)
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
