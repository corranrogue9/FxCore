namespace System.Linq.V2
{
    public interface ILastOrDefaultEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? LastOrDefault();
    }
}