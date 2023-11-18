using System.Collections;
using System.Collections.Generic;

namespace System.Linq.V2
{
    public sealed class GarrettAggregatedOverloadEnumerable<TElement> : IAggregatedOverloadEnumerable<TElement>, IConcatEnumerable<TElement>
    {
        public GarrettAggregatedOverloadEnumerable(IV2Enumerable<TElement> source)
        {
            this.Source = source;
        }

        public IV2Enumerable<TElement> Source { get; }

        public IAggregatedOverloadEnumerable<TSource> Create<TSource>(IV2Enumerable<TSource> source)
        {
            return source.AddGarrett();
        }

        public IV2Enumerable<TElement> Concat(IV2Enumerable<TElement> second)
        {
            return new ConcatedEnumerable(this.Source, second).AddGarrett();
        }

        private sealed class ConcatedEnumerable : IWhereEnumerable<TElement>
        {
            private readonly IV2Enumerable<TElement> first;

            private readonly IV2Enumerable<TElement> second;

            public ConcatedEnumerable(IV2Enumerable<TElement> first, IV2Enumerable<TElement> second)
            {
                this.first = first;
                this.second = second;
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                return this.first.Concat(this.second).GetEnumerator();
            }

            public IV2Enumerable<TElement> Where(Func<TElement, bool> predicate)
            {
                return new WheredEnumerable(this.first, this.second, predicate).AddGarrett();
            }

            public IV2Enumerable<TElement> Where(Func<TElement, int, bool> predicate)
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            private sealed class WheredEnumerable : IV2Enumerable<TElement>
            {
                private readonly IV2Enumerable<TElement> first;

                private readonly IV2Enumerable<TElement> second;

                private readonly Func<TElement, bool> predicate;

                public WheredEnumerable(IV2Enumerable<TElement> first, IV2Enumerable<TElement> second, Func<TElement, bool> predicate)
                {
                    this.first = first;
                    this.second = second;
                    this.predicate = predicate;
                }

                public IEnumerator<TElement> GetEnumerator()
                {
                    return this.first.Where(predicate).Concat(this.second.Where(predicate)).GetEnumerator();
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
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
