namespace System.Linq.V2
{
    using System;

    public interface IExceptByEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> ExceptBy<TKey>(IV2Enumerable<TKey> second, Func<TSource, TKey> keySelector);
    }
}