namespace System.Linq.V2
{
    using System;

    public interface ISelectManyEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> SelectMany<TResult>(Func<TSource, int, IV2Enumerable<TResult>> selector);

        IV2Enumerable<TResult> SelectMany<TCollection, TResult>(
            Func<TSource, int, IV2Enumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector);

        IV2Enumerable<TResult> SelectMany<TResult>(Func<TSource, IV2Enumerable<TResult>> selector);

        IV2Enumerable<TResult> SelectMany<TCollection, TResult>(
            Func<TSource, IV2Enumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector);
    }
}