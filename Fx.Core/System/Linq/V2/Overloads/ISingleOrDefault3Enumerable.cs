namespace System.Linq.V2
{
    public interface ISingleOrDefault3Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? SingleOrDefault();
    }
}