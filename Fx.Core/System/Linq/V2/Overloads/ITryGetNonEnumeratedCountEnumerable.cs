namespace System.Linq.V2
{
    public interface ITryGetNonEnumeratedCountEnumerable<TSource> : IV2Enumerable<TSource>
    {
        bool TryGetNonEnumeratedCount(out int count);
    }
}