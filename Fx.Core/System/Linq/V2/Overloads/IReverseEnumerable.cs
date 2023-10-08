namespace System.Linq.V2
{
    public interface IReverseEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Reverse();
    }
}