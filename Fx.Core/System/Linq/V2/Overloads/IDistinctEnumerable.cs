namespace System.Linq.V2
{
    public interface IDistinctEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Distinct();
    }
}