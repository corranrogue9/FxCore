namespace System.Test
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class ConcatedEnumerable<TEnumerable, TElement> : IEnumerable<TElement> where TEnumerable : IEnumerable<TElement>
    {
        private readonly Func<ConcatedEnumerable<TEnumerable, TElement>, IEnumerator<TElement>> getEnumerator;

        public ConcatedEnumerable(TEnumerable first, IEnumerable<TElement> second, Func<ConcatedEnumerable<TEnumerable, TElement>, IEnumerator<TElement>> getEnumerator)
        {
            this.First = first;
            this.Second = second;
            this.getEnumerator = getEnumerator;
        }

        public TEnumerable First { get; }

        public IEnumerable<TElement> Second { get; }

        public IEnumerator<TElement> GetEnumerator()
        {
            return this.getEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public sealed class WheredEnumerable<TEnumerable, TElement> : IEnumerable<TElement> where TEnumerable : IEnumerable<TElement>
    {
        private readonly Func<WheredEnumerable<TEnumerable, TElement>, IEnumerator<TElement>> getEnumerator; //// TODO it might make more sense to return ienumerable so that you don't have to have a dynamic func in the extension method

        public WheredEnumerable(TEnumerable source, Func<TElement, bool> predicate, Func<WheredEnumerable<TEnumerable, TElement>, IEnumerator<TElement>> getEnumerator)
        {
            this.Source = source;
            this.predicate = predicate;
            this.getEnumerator = getEnumerator;
        }

        public TEnumerable Source { get; }

        public Func<TElement, bool> predicate { get; }

        public IEnumerator<TElement> GetEnumerator()
        {
            // TODO can you use a generic to avoid the ienumerator interface?
            return this.getEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public sealed class SelectedEnumerable<TEnumerable, TSource, TResult> : IEnumerable<TResult> where TEnumerable : IEnumerable<TSource>
    {
        private readonly Func<SelectedEnumerable<TEnumerable, TSource, TResult>, IEnumerator<TResult>> getEnumerator; //// TODO it might make more sense to return ienumerable so that you don't have to have a dynamic func in the extension method

        public SelectedEnumerable(TEnumerable source, Func<TSource, TResult> selector, Func<SelectedEnumerable<TEnumerable, TSource, TResult>, IEnumerator<TResult>> getEnumerator)
        {
            this.Source = source;
            this.Selector = selector;
            this.getEnumerator = getEnumerator;
        }

        public TEnumerable Source { get; }

        public Func<TSource, TResult> Selector { get; }

        public IEnumerator<TResult> GetEnumerator()
        {
            // TODO can you use a generic to avoid the ienumerator interface?
            return this.getEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public static class Extensions
    {
        public static SelectedEnumerable<TEnumerable, TSource, TResult> Select<TEnumerable, TSource, TResult>(this TEnumerable self, Func<TSource, TResult> selector)
            where TEnumerable : IEnumerable<TSource>
        {
            return new SelectedEnumerable<TEnumerable, TSource, TResult>(
                self,
                selector,
                enumerable => SelectIterator(self, selector).GetEnumerator());
        }

        private static IEnumerable<TResult> SelectIterator<TSource, TResult>(this IEnumerable<TSource> self, Func<TSource, TResult> selector)
        {
            foreach (var element in self)
            {
                yield return selector(element);
            }
        }

        public static ConcatedEnumerable<TEnumerable, TElement> Concat<TEnumerable, TElement>(this TEnumerable first, IEnumerable<TElement> second) where TEnumerable : IEnumerable<TElement>
        {
            return new ConcatedEnumerable<TEnumerable, TElement>(
                first,
                second,
                enumerable => ConcatIterator(enumerable.First, enumerable.Second).GetEnumerator());
        }

        private static IEnumerable<T> ConcatIterator<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            foreach (var element in first)
            {
                yield return element;
            }

            foreach (var element in second)
            {
                yield return element;
            }
        }

        public static WheredEnumerable<TEnumerable, TElement> Where<TEnumerable, TElement>(this TEnumerable self, Func<TElement, bool> predicate) where TEnumerable : IEnumerable<TElement>
        {
            return new WheredEnumerable<TEnumerable, TElement>(self, predicate, enumerable => WhereIterator(enumerable, predicate).GetEnumerator());
        }

        private static IEnumerable<T> WhereIterator<T>(IEnumerable<T> self, Func<T, bool> predicate)
        {
            foreach (var element in self)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }
    }

    public static class Program
    {
        public static WheredEnumerable<ConcatedEnumerable<TEnumerable, TElement>, TElement> Where<TEnumerable, TElement>(
            this ConcatedEnumerable<TEnumerable, TElement> concatedEnumerable,
            Func<TElement, bool> predicate)
            where TEnumerable : IEnumerable<TElement>
        {
            return new WheredEnumerable<ConcatedEnumerable<TEnumerable, TElement>, TElement>(
                concatedEnumerable,
                predicate,
                // TODO the where call on first doesn't end up recursing on this method though *because* it's strongly typed
                enumerable => enumerable.Source.First.Where(enumerable.predicate).Concat(enumerable.Source.Second.Where(enumerable.predicate)).GetEnumerator());
        }

        public static void DoWork()
        {
            var data = new[] { "AsdF" };
            var result = data
                .Concat(data)
                .Concat(data)
                .Where(element => element.Length > 4)
                .Select(element => element.Length);
        }
    }
}
