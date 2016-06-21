using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Collections
{
    /// <summary>
    /// Extension call to merge sorted enumerables into a single sorted enumerable
    ///
    /// </summary>
    public static class SortedPartitionsMergeExtension
    {
        /// <summary>
        /// merge the given enumerables that have to be sorted into a single sorted enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerables">a collection of enumerables each already sorted (in repsect to comparer></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<T> Sorted<T>(this ICollection<IEnumerable<T>> enumerables, Comparer<T> comparer = null)
        {
            var enumeratorComparer = new EnumeratorComparer<T>(comparer ?? Comparer<T>.Default);
            var enumerators = GetEnumerators(enumerables, enumeratorComparer);

            while (enumerators.Count > 0)
            {
                var top = enumerators.First();
                enumerators.Remove(top);

                yield return top.Current;

                if (top.MoveNext())
                {
                    var ix = enumerators.BinarySearch(top, enumeratorComparer);
                    var i = ix < 0 ? ~ix : ix;

                    enumerators.Insert(i, top);
                }
                else
                {
                    top.Dispose();
                }
            }
        }

        /// <summary>
        /// get the list of enumerators of all the non empty Enumerables, sorted by their first (current) item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerables"></param>
        /// <returns></returns>
        private static List<IEnumerator<T>> GetEnumerators<T>(ICollection<IEnumerable<T>> enumerables, EnumeratorComparer<T> enumeratorComparer)
        {
            var enumerators = new List<IEnumerator<T>>(enumerables.Count);
            foreach (var enumerable in enumerables)
            {
                var e = enumerable.GetEnumerator();
                if (e.MoveNext())
                {
                    enumerators.Add(e);
                }
                else
                {
                    e.Dispose();
                }
            }
            enumerators.Sort(enumeratorComparer);
            return enumerators;
        }
    }

    class EnumeratorComparer<T> : IComparer<IEnumerator<T>>
    {
        private readonly IComparer<T> _comparer;

        public EnumeratorComparer(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public int Compare(IEnumerator<T> x, IEnumerator<T> y)
        {
            return _comparer.Compare(x.Current, y.Current);
        }
    }
}
