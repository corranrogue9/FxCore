namespace Fx.Linq
{
    using System;
    using System.Linq.V2;

    public static class AggregatedOverloadEnumableExtensions
    {
        public static AggregatedOverloadEnumerable<T> Extend<T>(this IV2Enumerable<T> self, Func<IV2Enumerable<T>, IV2Enumerable<T>> aggregatedOverloadFactory)
        {
            return new AggregatedOverloadEnumerable<T>(self, aggregatedOverloadFactory);
        }
    }
}
