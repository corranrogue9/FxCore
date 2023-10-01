namespace Fx.Linq.V2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.V2;

    public sealed class GarrettEnumerable<T> : IV2Enumerable<T>, IConcatEnumerable<T>
    {
        private readonly IV2Enumerable<T> source;

        public GarrettEnumerable(IV2Enumerable<T> source)
        {
            this.source = source;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.source.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IV2Enumerable<T> Concat(IV2Enumerable<T> second)
        {
            return new ConcatedEnumerable(this.source, second);
        }

        private sealed class ConcatedEnumerable : IV2Enumerable<T>, IWhereEnumerable<T>
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

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public IV2Enumerable<T> Where(Func<T, bool> predicate)
            {
                return new ConcatedWheredEnumerable(this.first, this.second, predicate);
            }

            private sealed class ConcatedWheredEnumerable : IV2Enumerable<T>
            {
                private readonly IV2Enumerable<T> first;

                private readonly IV2Enumerable<T> second;

                private readonly Func<T, bool> predicate;

                public ConcatedWheredEnumerable(IV2Enumerable<T> first, IV2Enumerable<T> second, Func<T, bool> predicate)
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
        }
    }
}
