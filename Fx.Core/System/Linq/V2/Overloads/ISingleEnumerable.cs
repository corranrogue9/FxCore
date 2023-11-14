namespace System.Linq.V2
{
    public interface ISingleEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource Single();

        TSource Single(Func<TSource, bool> predicate);
    }
}