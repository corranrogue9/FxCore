﻿namespace System.Linq.V2
{
    public interface IDefaultIfEmptyEnumerable<TSource> : IV2Enumerable<TSource>
    {
        IV2Enumerable<TSource?> DefaultIfEmpty();

        IV2Enumerable<TSource> DefaultIfEmpty(TSource defaultValue);
    }
}