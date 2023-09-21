namespace System.Linq.V2
{
    public interface ICountEnumerable<TSource> : IV2Enumerable<TSource>
    {
        int Count();
    }
}