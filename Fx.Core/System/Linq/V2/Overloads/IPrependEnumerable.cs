namespace System.Linq.V2
{
    public interface IPrependEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Prepend(TSource element);
    }
}