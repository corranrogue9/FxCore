namespace System.Linq.V2
{
    public interface ILastEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource Last();

        TSource Last(Func<TSource, bool> predicate);
    }
}