namespace System.Linq.V2
{
    public interface IAggregatedOverloadEnumerable<T> : IV2Enumerable<T>
    {
        IV2Enumerable<T> Source { get; }

        Func<IV2Enumerable<T>, IAggregatedOverloadEnumerable<T>> AggregatedOverloadFactory { get; }
    }
}
