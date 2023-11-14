﻿namespace System.Linq.V2
{
    using System;

    public interface ISingleOrDefaultEnumerable<TSource> : IV2Enumerable<TSource>
    {
        TSource SingleOrDefault(Func<TSource, bool> predicate, TSource defaultValue);

        TSource? SingleOrDefault(Func<TSource, bool> predicate);

        TSource? SingleOrDefault();

        TSource SingleOrDefault(TSource defaultValue);
    }
}