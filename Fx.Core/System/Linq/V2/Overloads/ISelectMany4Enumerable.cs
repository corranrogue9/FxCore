namespace System.Linq.V2
{
    using System;

    public interface ISelectMany4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TResult> SelectMany<TResult>(Func<TSource, IV2Enumerable<TResult>> selector);
    }
}