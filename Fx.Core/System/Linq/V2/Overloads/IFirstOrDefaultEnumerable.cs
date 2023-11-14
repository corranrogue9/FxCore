namespace System.Linq.V2
{
    public interface IFirstOrDefaultEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? FirstOrDefault();

        TSource? FirstOrDefault(Func<TSource, bool> predicate);

        TSource FirstOrDefault(Func<TSource, bool> predicate, TSource defaultValue);

        TSource FirstOrDefault(TSource defaultValue);
    }
}