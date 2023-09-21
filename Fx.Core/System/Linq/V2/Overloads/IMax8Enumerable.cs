namespace System.Linq.V2
{
    using System;

    public interface IMax8Enumerable<TSource> : IV2Enumerable<TSource>
    {
        long? Max(Func<TSource, long?> selector);
    }
}