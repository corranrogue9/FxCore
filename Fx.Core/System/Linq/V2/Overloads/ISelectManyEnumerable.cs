namespace System.Linq.V2
{
    using System;

    public interface ISelectManyEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> SelectMany<TResult>(Func<TSource, int, IV2Enumerable<TResult>> selector);
    }
}