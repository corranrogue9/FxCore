﻿namespace System.Linq.V2
{
    using System;

    public interface IMax3Enumerable<TSource> : IV2Enumerable<TSource>
    {
        double Max(Func<TSource, double> selector);
    }
}