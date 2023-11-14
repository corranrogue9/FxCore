namespace System.Linq.V2
{
    public interface ILastOrDefaultEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? LastOrDefault();

        TSource LastOrDefault(Func<TSource, bool> predicate, TSource defaultValue);

        TSource? LastOrDefault(Func<TSource, bool> predicate);

        TSource LastOrDefault(TSource defaultValue);
    }
}