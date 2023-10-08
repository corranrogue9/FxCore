namespace System.Linq.V2
{
    using System;

    public interface IMin5Enumerable<TSource> : IV2Enumerable<TSource>
    {
        int? Min(Func<TSource, int?> selector);
    }
}