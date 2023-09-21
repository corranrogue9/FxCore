namespace System.Linq.V2
{
    public interface IDefaultIfEmpty2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> DefaultIfEmpty(TSource defaultValue);
    }
}