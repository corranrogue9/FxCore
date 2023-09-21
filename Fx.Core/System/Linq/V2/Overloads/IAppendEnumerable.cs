namespace System.Linq.V2
{
    public interface IAppendEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Append(TSource element);
    }
}