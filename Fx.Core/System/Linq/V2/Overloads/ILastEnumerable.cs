namespace System.Linq.V2
{
    public interface ILastEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource Last();
    }
}