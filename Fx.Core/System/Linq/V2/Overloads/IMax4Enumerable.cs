namespace System.Linq.V2
{
    using System;

    public interface IMax4Enumerable<TSource> : IV2Enumerable<TSource>
    {
        int Max(Func<TSource, int> selector);
    }
}