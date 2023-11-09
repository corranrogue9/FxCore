using System.Collections;
using System.Collections.Generic;

namespace System.Linq.V2
{
    /// <summary>
    /// Implements:
    /// 
    /// source
    ///     .GroupBy(element => keySelector(element))
    ///     .Select(grouping => grouping.Sum());
    ///     
    /// source
    ///     .GroupBy(element => keySelector(element))
    ///     .Select(grouping => grouping.Sum() + 1);
    ///     
    /// source
    ///     .GroupBy(element => keySelector(element))
    ///     .Select(groupgin => groupging.Select(element => element.AsInt()))
    ///     .Select(grouping => grouping.count() > 5 ? grouping.Sum() + 1 : goruopung.Max());
    /// 
    /// 
    /// source
    ///     .GroupBy(element => keySelector(element))
    ///     .Max()
    /// 
    /// 
    /// source
    ///     .GroupBy(element => keySelector(element))
    ///     .Select(grouping => grouping.Max());
    ///     
    /// var dictionary = new Dictionary<TKey, TElement>()
    /// foreach (var element in source)
    /// {
    ///     var key = keySelector(element);
    ///     if (!dictionary.TryGetValue(key, out var max)
    ///     {
    ///         dictionary[key] = element;
    ///     }
    ///     else   
    ///     {
    ///         dictionary[key] = Math.Max(element, max);
    ///     }
    /// }
    /// 
    /// return dictionary.Select(kvp => kvp.Value);
    ///     
    /// 
    /// 
    /// 
    /// 
    /// source
    ///     .GroupBy(element => keySelector(element))
    ///     .Select(grouping => grouping.Aggregate(0, (sum, element) => first + element.AsInt()));
    ///     
    /// source
    ///     .GroupBy(element => keySelector(element))
    ///     .Select(grouping => grouping.Aggregate(new List<string>(), (list, element) => list.Add(element.AsString())));
    ///     
    /// source
    ///     .GroupBy(element => keySelector(element))
    ///     .Select(grouping => grouping.Aggregate(null, (max, element) => Math.Max(max, element.AsInt())));
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    public sealed class GarrettGroupByable<TElement> : IAggregatedOverloadEnumerable<TElement>, IGroupBy5Enumerable<TElement>
    {
        public GarrettGroupByable(IV2Enumerable<TElement> source)
        {
            this.Source = source;
        }

        public IV2Enumerable<TElement> Source { get; }

        public IAggregatedOverloadEnumerable<TSource> Create<TSource>(IV2Enumerable<TSource> source)
        {
            return new GarrettGroupByable<TSource>(source);
        }

        public IV2Enumerable<IV2Grouping<TKey, TElement>> GroupBy<TKey>(Func<TElement, TKey> keySelector)
        {
            return new GroupByed<TKey>(this.Source, keySelector);
        }

        private sealed class GroupByed<TKey> : IV2Enumerable<IV2Grouping<TKey, TElement>>, ISelect2Enumerable<IV2Grouping<TKey, TElement>>
        {
            private readonly IV2Enumerable<TElement> source;
            
            private readonly Func<TElement, TKey> keySelector;

            public GroupByed(IV2Enumerable<TElement> source, Func<TElement, TKey> keySelector)
            {
                this.source = source;
                this.keySelector = keySelector;
            }

            public IV2Enumerable<TResult> Select<TResult>(Func<IV2Grouping<TKey, TElement>, TResult> selector)
            {
                return new Selected<TResult>(this.source, this.keySelector, selector);
            }

            private sealed class Selected<TResult> : IV2Enumerable<TResult>
            {
                private readonly IV2Enumerable<TElement> source;

                private readonly Func<TElement, TKey> keySelector;

                private readonly Func<IV2Grouping<TKey, TElement>, TResult> selector;

                public Selected(IV2Enumerable<TElement> source, Func<TElement, TKey> keySelector, Func<IV2Grouping<TKey, TElement>, TResult> selector)
                {
                    this.source = source;
                    this.keySelector = keySelector;
                    this.selector = selector;
                }

                private sealed class GroupingAggregator : IV2Grouping<TKey, TElement>, IMax12Enumerable<TElement>
                {
                    public GroupingAggregator(TKey key)
                    {
                        this.Key = key;
                    }

                    public TKey Key { get; }

                    public void Add(TElement element)
                    {
                    }

                    public TElement? Max()
                    {
                        //// TODO make sure this still works if max *isn't* called and the groupings are just enumerated after a select or something, i dunno, you figure out the scenario
                        throw new NotImplementedException();
                    }

                    public IEnumerator<TElement> GetEnumerator()
                    {
                        throw new NotImplementedException();
                    }

                    IEnumerator IEnumerable.GetEnumerator()
                    {
                        throw new NotImplementedException();
                    }
                }

                public IEnumerator<TResult> GetEnumerator()
                {
                    var dictionary = new Dictionary<TKey, GroupingAggregator>();
                    foreach (var element in this.source)
                    {
                        var key = this.keySelector(element);
                        if (!dictionary.TryGetValue(key, out var groupingAggregator))
                        {
                            groupingAggregator = new GroupingAggregator(key);
                        }

                        this.selector(groupingAggregator);

                    }


                    var grouping = new Grouping();
                    this.selector(grouping);
                    if (grouping.IsMax)
                    {
                        //// double? should be "aggregation" type, standard case is append, sum is addition, count is +1, max is compare, etc.
                        var dictionary = new Dictionary<TKey, TElement>();
                        foreach (var element in this.source)
                        {
                            var key = this.keySelector(element);
                            if (!dictionary.TryGetValue(key, out var max) || Comparer<TElement>.Default.Compare(element, max) > 0)
                            {
                                dictionary[key] = element;
                            }
                        }

                        return dictionary.Select(kvp => kvp.Value).Cast<TResult>().GetEnumerator();
                    }
                    else if (new Random().Next() == 0) //// sum
                    {
                        var dictionary = new Dictionary<TKey, double>();
                        foreach (var element in this.source)
                        {
                            var key = this.keySelector(element);
                            if (!dictionary.TryGetValue(key, out var sum))
                            {
                                sum = 0;
                            }

                            sum += element;
                            dictionary[key] = sum;
                        }
                    }
                    else if (new Random().Next() == 0) //// aggregate
                    {
                    }
                    else
                    {
                        var dictionary = new Dictionary<TKey, List<TElement>>();
                        foreach (var element in this.source)
                        {
                            var key = this.keySelector(element);
                            if (!dictionary.TryGetValue(key, out var list))
                            {
                                list = new List<TElement>();
                            }

                            list.Add(element);
                        }

                        return dictionary.Select(kvp => new GroupingAdapter(kvp.Key, kvp.Value)).Select(this.selector).GetEnumerator();
                    }
                }

                private sealed class Aggregator
                {
                    public void Add(TElement element)
                    {
                    }
                }

                private sealed class GroupingAdapter : IV2Grouping<TKey, TElement>
                {
                    private readonly IEnumerable<TElement> enumerable;

                    public GroupingAdapter(TKey key, IEnumerable<TElement> enumerable)
                    {
                        this.Key = key;
                        this.enumerable = enumerable;
                    }

                    public TKey Key { get; }

                    public IEnumerator<TElement> GetEnumerator()
                    {
                        return this.enumerable.GetEnumerator();
                    }

                    IEnumerator IEnumerable.GetEnumerator()
                    {
                        return this.GetEnumerator();
                    }
                }

                private sealed class Grouping : IV2Grouping<TKey, TElement>, IAggregate2Enumerable<TElement>
                {
                    public TKey Key => throw new NotImplementedException();

                    public TAccumulate Aggregate<TAccumulate>(TAccumulate seed, Func<TAccumulate, TElement, TAccumulate> func)
                    {
                        throw new NotImplementedException();
                    }

                    public IEnumerator<TElement> GetEnumerator()
                    {
                        throw new NotImplementedException();
                    }

                    IEnumerator IEnumerable.GetEnumerator()
                    {
                        throw new NotImplementedException();
                    }
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
            }

            public IEnumerator<IV2Grouping<TKey, TElement>> GetEnumerator()
            {
                return this.source.GroupBy(this.keySelector).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return this.Source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
