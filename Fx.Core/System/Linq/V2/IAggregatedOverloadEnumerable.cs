namespace System.Linq.V2
{
    public interface IAggregatedOverloadEnumerable<T> : IV2Enumerable<T>
    {
        IV2Enumerable<T> Source { get; }
    }
}
