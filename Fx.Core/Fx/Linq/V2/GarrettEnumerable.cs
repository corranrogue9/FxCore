using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.V2;
using System.Text;
using System.Threading.Tasks;

using Fx.Linq.V2.Extensions;

namespace Fx.Linq.V2
{
    public static class EnumerableExtensions
    {
        public static IV2Enumerable<TElement> AddGarrett<TElement>(this IV2Enumerable<TElement> source) //// TODO fix the name
        {
            ////return source.Extend(FxEnumerable.Create);

            return GarrettEnumerable.Create(source);
        }

        private static class GarrettEnumerable
        {
            public static GarrettEnumerable<TElement> Create<TElement>(IV2Enumerable<TElement> source)
            {
                return new GarrettEnumerable<TElement>(source);
            }
        }

        /// <summary>
        /// TODO do you like this name?
        /// 
        /// TODO implement the rest of this garrett extension, particularly adding all of the override implementations
        /// </summary>
        private class GarrettEnumerable<TElement> : IV2Enumerable<TElement>, IConcatEnumerable<TElement>
        {
            private readonly IV2Enumerable<TElement> source;

            public GarrettEnumerable(IV2Enumerable<TElement> source)
            {
                this.source = source;
            }

            public IV2Enumerable<TElement> Concat(IV2Enumerable<TElement> second)
            {
                return new ConcatEnumerable(this.source, second);
            }

            private sealed class ConcatEnumerable : GarrettEnumerable<TElement>, IWhereEnumerable<TElement>, ICountEnumerable<TElement>
            {
                private readonly IV2Enumerable<TElement> first;

                private readonly IV2Enumerable<TElement> second;

                private readonly Func<TElement, bool>? predicate1;

                public ConcatEnumerable(IV2Enumerable<TElement> first, IV2Enumerable<TElement> second)
                    : this(first, second, null)
                {
                }

                public ConcatEnumerable(IV2Enumerable<TElement> first, IV2Enumerable<TElement> second, Func<TElement, bool>? predicate1)
                    : base(first.Concat(second)) //// TODO the argument should really be a reference to this instance...
                {
                    this.first = first;
                    this.second = second;
                    this.predicate1 = predicate1;
                }

                public IEnumerator<TElement> GetEnumerator()
                {
                    var first = this.first;
                    var second = this.second;
                    if (this.predicate1 != null)
                    {
                        first = first.Where(this.predicate1);
                        second = second.Where(this.predicate1);
                    }

                    return first.Concat(second).GetEnumerator();
                }

                public IV2Enumerable<TElement> Where(Func<TElement, bool> predicate)
                {
                    return new ConcatEnumerable(this.first, this.second, this.predicate1 == null ? predicate : CombinePredicates(this.predicate1, predicate));
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }

                private static Func<T, bool> CombinePredicates<T>(Func<T, bool> first, Func<T, bool> second)
                {
                    return _ => first(_) && second(_);
                }

                private static Func<T, int, bool> CombinePredicates<T>(Func<T, int, bool> first, Func<T, int, bool> second)
                {
                    return (_, __) => first(_, __) && second(_, __);
                }

                public int Count()
                {
                    return this.first.Count() + this.second.Count();
                }
            }

            public IEnumerator<TElement> GetEnumerator()
            {
                return this.source.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}
