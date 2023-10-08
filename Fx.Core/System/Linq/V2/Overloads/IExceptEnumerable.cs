namespace System.Linq.V2
{
    public interface IExceptEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Except(IV2Enumerable<TSource> second);
    }
}