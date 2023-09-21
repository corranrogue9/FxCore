namespace System.Linq.V2
{
    public interface IFirstOrDefaultEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource? FirstOrDefault();
    }
}