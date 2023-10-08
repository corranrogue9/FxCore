namespace Fx.Linq
{
    using System.Linq.V2;

    public static class GarrettAggregatedOverloadEnumerableExtensions
    {
        public static AggregatedOverloadEnumerable<T> AddGarrett<T>(this IV2Enumerable<T> self)
        {
            return self.Extend(_ => new GarrettAggregatedOverloadEnumerable<T>(_));
        }
    }
}
