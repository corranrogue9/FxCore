namespace System.Linq.V2
{
    public interface IContains2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        bool Contains(TSource value);
    }
}