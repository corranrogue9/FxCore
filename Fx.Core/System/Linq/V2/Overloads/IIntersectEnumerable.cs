﻿namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IIntersectEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Intersect(IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer);

        IV2Enumerable<TSource> Intersect(IV2Enumerable<TSource> second);
    }
}