namespace System.Linq.V2
{
    public interface IAnyEnumerable<TSource> : IV2Enumerable<TSource>
    {
        bool Any();
    }
}