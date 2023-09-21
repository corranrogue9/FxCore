namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IExcept2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Except(IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer);
    }
}