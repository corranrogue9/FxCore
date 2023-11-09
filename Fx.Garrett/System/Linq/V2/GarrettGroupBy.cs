using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace System.Linq.V2
{
    /// <summary>
    /// test cases:
    /// var data = new[] { "532", "21354", ... };
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Count());
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Max());
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Sum(element => int.Parse(element)));
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Sum(element => int.Parse(element)) + 1);
    /// data.GroupBy(element => element.Length);
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Select(element => int.Parse(element)));
    /// 
    /// var grouped = data.GroupBy(element => element.Length);
    /// grouped.Select(grouping => grouping.Count());
    /// grouped.Select(grouping => grouping.Max());
    /// 
    /// data.GroupBy(element => element.Length).Select((grouping, index) => index % 2 == 0 ? grouping.Sum(element => int.Parse(element)) + 1 : grouping.Count());
    /// 
    /// 
    /// 
    /// 
    /// 
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
                    private readonly Dictionary<TKey, GroupingAggregator> groupings;

                    private readonly Dictionary<TKey, TResult> results;

                    private readonly Func<TElement, TKey> keySelector;

                    private readonly Func<IV2Grouping<TKey, TElement>, TResult> selector;

                    private readonly IEnumerator<TElement> enumerator;

                    private readonly List<Action<TElement>> aggregators;

                    public GroupingAggregator(
                        TKey key, 
                        Dictionary<TKey, GarrettGroupByable<TElement>.GroupByed<TKey>.Selected<TResult>.GroupingAggregator> groupings, 
                        Dictionary<TKey, TResult> results, 
                        Func<TElement, TKey> keySelector,
                        Func<IV2Grouping<TKey, TElement>, TResult> selector, 
                        IEnumerator<TElement> enumerator)
                    {
                        this.Key = key;

                        this.groupings = groupings;
                        this.results = results;
                        this.keySelector = keySelector;
                        this.selector = selector;
                        this.enumerator = enumerator;

                        this.aggregators = new List<Action<TElement>>();
                    }

                    public TKey Key { get; }

                    public void Add(TElement element)
                    {
                        foreach (var aggregator in this.aggregators)
                        {
                            aggregator(element);
                        }
                    }

                    private sealed class Pointer<T>
                    {
                        private T value;

                        public bool HasValue { get; private set; } = false;

                        public T Value
                        {
                            get
                            {
                                if (!this.HasValue)
                                {
                                    throw new InvalidOperationException("TODO");
                                }

                                return this.value;
                            }
                            set
                            {
                                this.value = value;
                                this.HasValue = true;
                            }
                        }
                    }

                    public TElement? Max()
                    {
                        //// TODO can this aggregator accidentally be added twice? do you need an if statement somewhere?
                        var max = new Pointer<TElement?>();
                        this.aggregators.Add(element =>
                        {
                            if (max.HasValue)
                            {
                                if (Comparer<TElement?>.Default.Compare(element, max.Value) > 0)
                                {
                                    max.Value = element;
                                }
                            }
                            else
                            {
                                max.Value = element;
                            }
                        });

                        this.Add(this.enumerator.Current);
                        while (this.enumerator.MoveNext())
                        {
                            var element = this.enumerator.Current;
                            var key = this.keySelector(element);
                            if (!this.groupings.TryGetValue(key, out var grouping))
                            {
                                grouping = new GroupingAggregator(key, this.groupings, this.results, this.keySelector, this.selector, this.enumerator);
                                this.groupings[key] = grouping;
                                results[key] = this.selector(grouping);
                            }
                            else
                            {
                                grouping.Add(element);
                            }
                        }

                        if (max.HasValue)
                        {
                            return max.Value;
                        }
                        else
                        {
                            throw new InvalidOperationException("TODO no elements");
                        }
                    }

                    public IEnumerator<TElement> GetEnumerator()
                    {
                        //// TODO can this aggregator accidentally be added twice? do you need an if statement somewhere?
                        var elements = new List<TElement>();
                        this.aggregators.Add(element => elements.Add(element));

                        this.Add(this.enumerator.Current);
                        while (this.enumerator.MoveNext())
                        {
                            var element = this.enumerator.Current;
                            var key = this.keySelector(element);
                            if (!this.groupings.TryGetValue(key, out var grouping))
                            {
                                grouping = new GroupingAggregator(key, this.groupings, this.results, this.keySelector, this.selector, this.enumerator);
                                this.groupings[key] = grouping;
                                results[key] = this.selector(grouping);
                            }
                            else
                            {
                                grouping.Add(element);
                            }
                        }

                        return elements.GetEnumerator();
                    }

                    IEnumerator IEnumerable.GetEnumerator()
                    {
                        return this.GetEnumerator();
                    }
                }

                public IEnumerator<TResult> GetEnumerator()
                {
                    var groupings = new Dictionary<TKey, GroupingAggregator>();
                    var results = new Dictionary<TKey, TResult>();
                    using (var enumerator = this.source.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            var element = enumerator.Current;
                            var key = this.keySelector(element);
                            if (!groupings.TryGetValue(key, out var grouping))
                            {
                                grouping = new GroupingAggregator(key, groupings, results, this.keySelector, this.selector, enumerator);
                                groupings[key] = grouping;
                                results[key] = this.selector(grouping);
                            }
                            else
                            {
                                grouping.Add(element);
                            }
                        }
                    }

                    return results.Select(kvp => kvp.Value).GetEnumerator();
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
