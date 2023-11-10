﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace System.Linq.V2
{
    /// <summary>
    /// test cases:
    /// var data = new[] { "532", "21354", ... };
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Count()); //// TODO you can actually optimize Count(); you should pick another example of something that reifies that you cannot optimize
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Max());
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Sum(element => int.Parse(element)));
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Sum(element => int.Parse(element)) + 1);
    /// data.GroupBy(element => element.Length);
    /// data.GroupBy(element => element.Length).Select(grouping => grouping.Select(element => int.Parse(element)));
    /// 
    /// var grouped = data.GroupBy(element => element.Length);
    /// grouped.Select(grouping => grouping.Count()); //// TODO replace Count() with whatever you choose from line 10
    /// grouped.Select(grouping => grouping.Max());
    /// 
    /// data.GroupBy(element => element.Length).Select((grouping, index) => index % 2 == 0 ? grouping.Sum(element => int.Parse(element)) + 1 : grouping.Count()); //// TODO replace count with whatever you choose from line 10
    /// 
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

                private sealed class GroupingAggregator : IV2Grouping<TKey, TElement>, IMax12Enumerable<TElement>, ISumEnumerable<TElement>
                {
                    public ref struct AggregationContext //// TODO remove setters
                    {
                        public Dictionary<TKey, GroupingAggregator> Groupings { get; set; }

                        public Dictionary<TKey, TResult> Results { get; set; }

                        public Func<TElement, TKey> KeySelector { get; set; }

                        public Func<IV2Grouping<TKey, TElement>, TResult> Selector { get; set; }

                        public IEnumerator<TElement> Enumerator { get; set; }

                        public Action<TElement> Aggregator { get; set; }
                    }

                    public static void Aggregate(ref AggregationContext context)
                    {
                        context.Aggregator(context.Enumerator.Current);
                        while (context.Enumerator.MoveNext())
                        {
                            var element = context.Enumerator.Current;
                            var key = context.KeySelector(element);
                            if (!context.Groupings.TryGetValue(key, out var grouping))
                            {
                                grouping = new GroupingAggregator(key, element, context.Groupings, context.Results, context.KeySelector, context.Selector, context.Enumerator);
                                context.Groupings[key] = grouping;
                                context.Results[key] = context.Selector(grouping);
                            }
                            else
                            {
                                grouping.PushNext(element);
                            }
                        }
                    }

                    private readonly TElement firstElement;

                    private readonly Dictionary<TKey, GroupingAggregator> groupings;

                    private readonly Dictionary<TKey, TResult> results;

                    private readonly Func<TElement, TKey> keySelector;

                    private readonly Func<IV2Grouping<TKey, TElement>, TResult> selector;

                    private readonly IEnumerator<TElement> enumerator;

                    private readonly List<Action<TElement>> aggregators;

                    /// <summary>
                    /// The default behavior is to reify a list of the elements and store it, so if we get enumerated, we should do exactly that; null here
                    /// means that we are not being enumerated, non-null after the first enumeration means that we have the full list of elements
                    /// </summary>
                    private List<TElement>? elements;

                    public GroupingAggregator(
                        TKey key,
                        TElement firstElement,
                        Dictionary<TKey, GarrettGroupByable<TElement>.GroupByed<TKey>.Selected<TResult>.GroupingAggregator> groupings, 
                        Dictionary<TKey, TResult> results, 
                        Func<TElement, TKey> keySelector,
                        Func<IV2Grouping<TKey, TElement>, TResult> selector, 
                        IEnumerator<TElement> enumerator)
                    {
                        this.Key = key;

                        this.firstElement = firstElement;
                        this.groupings = groupings;
                        this.results = results;
                        this.keySelector = keySelector;
                        this.selector = selector;
                        this.enumerator = enumerator;

                        this.aggregators = new List<Action<TElement>>();
                        this.elements = null;
                    }

                    public TKey Key { get; }

                    public void PushNext(TElement element)
                    {
                        if (this.aggregators.Count == 0)
                        {
                            // we are being added to, but we have no aggregators; this means that the groupby is being evaluated, and then some non-reifying
                            // query (something that returns ienumerable and is therefore lazy) is being applied; in this case, we should use the default
                            // groupby behavior of reifying a list, so let's go ahead and add that aggregator
                            this.elements = new List<TElement>();
                            this.aggregators.Add(element => this.elements.Add(element));
                            this.PushNext(this.firstElement);
                        }

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
                        //// TODO can this aggregator accidentally be added twice? do you need an if statement somewhere? is it even reasonable for there to be 2 aggregators? wouldn't that mean you'd need to keep track of the previously aggregated elements and retroactively apply the new aggregator, thus defeating the purpose of the optimization?
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

                        var aggregationContext = new AggregationContext()
                        {
                            Aggregator = this.PushNext,
                            Enumerator = this.enumerator,
                            Groupings = this.groupings,
                            KeySelector = this.keySelector,
                            Results = this.results,
                            Selector = this.selector,
                        };
                        Aggregate(ref aggregationContext);

                        if (max.HasValue)
                        {
                            return max.Value;
                        }
                        else
                        {
                            throw new InvalidOperationException("TODO no elements");
                        }
                    }

                    public int Sum(Func<TElement, int> selector)
                    {
                        var aggregate = new Pointer<int>() { Value = 0 };
                        this.aggregators.Add(element => aggregate.Value += selector(element));

                        var aggregationContext = new AggregationContext()
                        {
                            Aggregator = this.PushNext,
                            Enumerator = this.enumerator,
                            Groupings = this.groupings,
                            KeySelector = this.keySelector,
                            Results = this.results,
                            Selector = this.selector,
                        };
                        Aggregate(ref aggregationContext);

                        if (aggregate.HasValue)
                        {
                            return aggregate.Value;
                        }
                        else
                        {
                            //// TODO does sum throw if there are no elements? i don't remember
                            throw new InvalidOperationException("TODO no elements");
                        }
                    }

                    public IEnumerator<TElement> GetEnumerator()
                    {
                        if (this.elements != null)
                        {
                            return this.elements.GetEnumerator();
                        }
                        
                        //// TODO can this aggregator accidentally be added twice? do you need an if statement somewhere?
                        this.elements = new List<TElement>();
                        this.aggregators.Add(element => this.elements.Add(element));

                        var aggregationContext = new AggregationContext()
                        {
                            Aggregator = this.PushNext,
                            Enumerator = this.enumerator,
                            Groupings = this.groupings,
                            KeySelector = this.keySelector,
                            Results = this.results,
                            Selector = this.selector,
                        };
                        Aggregate(ref aggregationContext);

                        return elements.GetEnumerator();
                    }

                    IEnumerator IEnumerable.GetEnumerator()
                    {
                        return this.GetEnumerator();
                    }
                }

                public IEnumerator<TResult> GetEnumerator()
                {
                    //// TODO refactor to use GroupingAggregator.Aggregate
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
                                grouping = new GroupingAggregator(key, element, groupings, results, this.keySelector, this.selector, enumerator);
                                groupings[key] = grouping;
                                results[key] = this.selector(grouping);
                            }
                            else
                            {
                                grouping.PushNext(element);
                            }
                        }
                    }

                    return results.Select(kvp => kvp.Value).GetEnumerator();
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
