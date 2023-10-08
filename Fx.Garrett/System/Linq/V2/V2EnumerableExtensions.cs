namespace System.Linq.V2
{
    public static class V2EnumerableExtensions
    {
        public static GarrettAggregatedOverloadEnumerable<T> AddGarrett<T>(this IV2Enumerable<T> self)
        {
            return new GarrettAggregatedOverloadEnumerable<T>(self);
        }
    }
}
