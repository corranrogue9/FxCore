﻿namespace System.Linq.V2
{
    public interface IMinEnumerable : IV2Enumerable<decimal>
    {
        public decimal Min()
        {
            return this.MinDefault();
        }
    }
}