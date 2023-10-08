namespace System.Linq.V2
{
    public interface ISkipEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Skip(int count);
    }
}