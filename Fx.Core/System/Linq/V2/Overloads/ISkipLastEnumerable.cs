namespace System.Linq.V2
{
    public interface ISkipLastEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> SkipLast(int count);
    }
}