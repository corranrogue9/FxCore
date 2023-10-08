﻿namespace System.Linq.V2
{
    using System;

    public interface IAverage2Enumerable<TSource> : IV2Enumerable<TSource>
    {
        double Average(Func<TSource, long> selector);
    }
}