using System.Collections;
using System.Collections.Generic;

namespace System.Linq.V2
{
    public sealed class GarrettAggregatedOverloadEnumerable<T> : IAggregatedOverloadEnumerable<T>, IConcatEnumerable<T>
    {
        public GarrettAggregatedOverloadEnumerable(IV2Enumerable<T> source)
        {
            this.Source = source;
        }

        public IV2Enumerable<T> Source { get; }

        public Func<IV2Enumerable<T>, IAggregatedOverloadEnumerable<T>> AggregatedOverloadFactory { get; } = enumerable => new GarrettAggregatedOverloadEnumerable<T>(enumerable);

        public IV2Enumerable<T> Concat(IV2Enumerable<T> second)
        {
            return new ConcatedEnumerable(this.Source, second).AddGarrett();
        }

        private sealed class ConcatedEnumerable : IWhereEnumerable<T>
        {
            private readonly IV2Enumerable<T> first;

            private readonly IV2Enumerable<T> second;

            public ConcatedEnumerable(IV2Enumerable<T> first, IV2Enumerable<T> second)
            {
                this.first = first;
                this.second = second;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this.first.Concat(this.second).GetEnumerator();
            }

            public IV2Enumerable<T> Where(Func<T, bool> predicate)
            {
                return new WheredEnumerable(this.first, this.second, predicate).AddGarrett();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            private sealed class WheredEnumerable : IV2Enumerable<T>
            {
                private readonly IV2Enumerable<T> first;

                private readonly IV2Enumerable<T> second;

                private readonly Func<T, bool> predicate;

                public WheredEnumerable(IV2Enumerable<T> first, IV2Enumerable<T> second, Func<T, bool> predicate)
                {
                    this.first = first;
                    this.second = second;
                    this.predicate = predicate;
                }

                public IEnumerator<T> GetEnumerator()
                {
                    return this.first.Where(predicate).Concat(this.second.Where(predicate)).GetEnumerator();
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
