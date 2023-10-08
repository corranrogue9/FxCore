namespace Fx.Linq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.V2;

    public sealed class AggregatedOverloadEnumerable<T> : IConcatEnumerable<T>, IWhereEnumerable<T>
    {
        private readonly IV2Enumerable<T> source;

        private readonly Func<IV2Enumerable<T>, IV2Enumerable<T>> aggregatedOverloadFactory;

        public AggregatedOverloadEnumerable(IV2Enumerable<T> source, Func<IV2Enumerable<T>, IV2Enumerable<T>> aggregatedOverloadFactory)
        {
            this.source = source;
            this.aggregatedOverloadFactory = aggregatedOverloadFactory;
        }

        public IV2Enumerable<T> Concat(IV2Enumerable<T> second)
        {
            IV2Enumerable<T> result;
            if (this.source is IConcatEnumerable<T> concat)
            {
                result = concat.Concat(second);
            }
            else
            {
                result = this.aggregatedOverloadFactory(this.source).Concat(second);
            }

            return new AggregatedOverloadEnumerable<T>(result, this.aggregatedOverloadFactory);
        }

        public IV2Enumerable<T> Where(Func<T, bool> predicate)
        {
            IV2Enumerable<T> result;
            if (this.source is IWhereEnumerable<T> where)
            {
                result = where.Where(predicate);
            }
            else
            {
                result = this.aggregatedOverloadFactory(this.source).Where(predicate);
            }

            return new AggregatedOverloadEnumerable<T>(result, this.aggregatedOverloadFactory);
        }

        //// TODO add the result of the overloads here

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
