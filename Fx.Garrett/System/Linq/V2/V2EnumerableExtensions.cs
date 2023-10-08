namespace System.Linq.V2
{
    using System.Collections.Generic;

    public static class V2EnumerableExtensions
    {
        public static GarrettAggregatedOverloadEnumerable<T> AddGarrett<T>(this IV2Enumerable<T> self)
        {
            return new GarrettAggregatedOverloadEnumerable<T>(self);
        }
    }
}
