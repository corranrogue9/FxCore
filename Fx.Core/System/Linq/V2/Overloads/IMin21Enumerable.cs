﻿namespace System.Linq.V2
{
    public interface IMin21Enumerable : IV2Enumerable<double>
    {
        public double Min()
        {
            return this.MinDefault();
        }
    }
}