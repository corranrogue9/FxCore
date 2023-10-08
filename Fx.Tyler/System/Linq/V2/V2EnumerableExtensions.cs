namespace System.Linq.V2
{
    using System.Collections.Generic;

    public interface IDuplicateEnumerable<T> : IV2Enumerable<T>
    {
        IV2Enumerable<T> Duplicate();
    }

    public static class V2EnumerableExtensions
    {
        public static IV2Enumerable<T> Duplicate<T>(this IV2Enumerable<T> self)
        {
            if (self is IDuplicateEnumerable<T> duplicate)
            {
                return duplicate.Duplicate();
            }

            return DuplicateIterator(self).ToV2Enumerable();
        }

        private static IEnumerable<T> DuplicateIterator<T>(IV2Enumerable<T> self)
        {
            foreach (var element in self)
            {
                yield return element;
                yield return element;
            }
        }
    }
}
