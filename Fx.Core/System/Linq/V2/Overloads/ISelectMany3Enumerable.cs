namespace System.Linq.V2
{
    using System;

    public interface ISelectMany3Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> SelectMany<TCollection, TResult>(
            Func<TSource, int, IV2Enumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector);
    }
}