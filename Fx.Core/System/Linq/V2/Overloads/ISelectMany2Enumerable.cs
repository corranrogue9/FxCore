namespace System.Linq.V2
{
    using System;

    public interface ISelectMany2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> SelectMany<TCollection, TResult>(
            Func<TSource, IV2Enumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector);
    }
}