namespace System.Linq.V2
{
    public interface IFirstEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource First();
    }
}