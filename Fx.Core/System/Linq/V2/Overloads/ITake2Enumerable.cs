namespace System.Linq.V2
{
    public interface ITake2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Take(int count);
    }
}