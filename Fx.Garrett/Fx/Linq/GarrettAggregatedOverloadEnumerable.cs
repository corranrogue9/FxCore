namespace Fx.Linq
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.V2;

    public sealed class GarrettAggregatedOverloadEnumerable<T> : IConcatEnumerable<T>
    {
        private readonly IV2Enumerable<T> source;

        public GarrettAggregatedOverloadEnumerable(IV2Enumerable<T> source)
        {
            this.source = source;
        }

        public IV2Enumerable<T> Concat(IV2Enumerable<T> second)
        {
            return new ConcatedEnumerable(this.source, second);
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

            public IV2Enumerable<T> Where(Func<T, bool> predicate)
            {
                return new WheredEnumerable(this.first, this.second, predicate);
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
                    return this.first.Where(this.predicate).Concat(this.second.Where(this.predicate)).GetEnumerator();
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this.first.Concat(second).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
