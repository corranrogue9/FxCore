namespace System.Linq.V2
{
    public interface ITakeLastEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> TakeLast(int count);
    }
}