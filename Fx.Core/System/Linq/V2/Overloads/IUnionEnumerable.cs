﻿using System.Collections.Generic;

namespace System.Linq.V2
{
    public interface IUnionEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource> Union(IV2Enumerable<TSource> second);

        IV2Enumerable<TSource> Union(IV2Enumerable<TSource> second, IEqualityComparer<TSource>? comparer);
    }
}