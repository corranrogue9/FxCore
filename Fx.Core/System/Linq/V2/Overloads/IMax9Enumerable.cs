namespace System.Linq.V2
{
    using System;

    public interface IMax9Enumerable<TSource> : IV2Enumerable<TSource>
    {
        float? Max(Func<TSource, float?> selector);
    }
}