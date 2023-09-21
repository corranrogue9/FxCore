namespace System.Linq.V2
{
    public interface ISingleOrDefault2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource SingleOrDefault(TSource defaultValue);
    }
}