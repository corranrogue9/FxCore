using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace System.Types
{
    public static class Foo
    {
        public class Bar
        {
            public string Fizz { get; set; }

            public string Buzz { get; set; }

            public int Frob { get; set; }

            public Frub Frub { get; set; }
        }

        public class Frub
        {
            public char Tazz { get; set; }
        }

        public static void DoWork()
        {
            var data = new[] { new Bar() { Frob = 1, Fizz = "a" }, new Bar() { Frob = 3, Fizz = "c" } };
            var ordered = data.BetterOrderBy(bar => bar.Fizz);

            var data2 = new[] { new Bar() { Frob = 2, Fizz = "b" } };
            var ordered2 = data2.BetterOrderBy(bar => bar.Fizz);


            var merged = ordered.Merge(ordered2).ToArray();


            //// var whered = ordered.Where(bar => bar.Frob < 5);


        }

        public static IEnumerable<TSource> Merge<TSource, TCompare>(
            this IBetterOrderedEnumerable<TSource, TCompare> first,
            IBetterOrderedEnumerable<TSource, TCompare> second)
        {
            /*if (first.Selector != second.Selector)
            {
                throw new ArgumentException();
            }*/

            var comparer = Comparer<TCompare>.Default;

            using (var firstEnumerator = first.GetEnumerator())
            using (var secondEnumerator = second.GetEnumerator())
            {
                if (!firstEnumerator.MoveNext())
                {
                    if (!secondEnumerator.MoveNext())
                    {
                        return Enumerable.Empty<TSource>();
                    }

                    return secondEnumerator.Enumerate();
                }

                if (!secondEnumerator.MoveNext())
                {
                    return firstEnumerator.Enumerate();
                }

                return MergeIterator(firstEnumerator, secondEnumerator, comparer, first.Selector);
            }
        }

        private static IEnumerable<TSource> MergeIterator<TSource, TCompare>(
            IEnumerator<TSource> firstEnumerator, 
            IEnumerator<TSource> secondEnumerator, 
            IComparer<TCompare> comparer, 
            Func<TSource, TCompare> selector)
        {
            var firstElement = firstEnumerator.Current;
            var secondElement = secondEnumerator.Current;
            var firstHasMoved = true; // this *has* moved in the caller, hence the default to true
            var secondHasMoved = true; // this *has* moved in the caller, hence the default to true

            while (firstHasMoved && secondHasMoved)
            {
                if (comparer.Compare(selector(firstElement), selector(secondElement)) < 0)
                {
                    yield return firstElement;
                    firstHasMoved = firstEnumerator.MoveNext();
                    firstElement = firstEnumerator.Current;
                }
                else
                {
                    yield return secondElement;
                    secondHasMoved = secondEnumerator.MoveNext();
                    secondElement = secondEnumerator.Current;
                }
            }

            // *at least* one of firstHasMoved and secondHasMoved is false; they cannot both be true; Enumerate returns the current element, so calling it on an
            // enumerator that has moved past the end will throw for most enumerators
            if (firstHasMoved)
            {
                foreach (var element in firstEnumerator.Enumerate())
                {
                    yield return element;
                }
            }
            else if (secondHasMoved)
            {
                foreach (var element in secondEnumerator.Enumerate())
                {
                    yield return element;
                }
            }
        }

        private static IEnumerable<T> Enumerate<T>(this IEnumerator<T> enumerator)
        {
            yield return enumerator.Current;
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }

    public static class OrderedExtension
    {
        public static IBetterOrderedEnumerable<TSource, TCompare> BetterOrderBy<TSource, TCompare>(this IEnumerable<TSource> self, Func<TSource, TCompare> selector)
        {
            return new BetterOrderedEnumerable<TSource, TCompare>(self, selector);
        }
    }

    public class BetterOrderedEnumerable<TSource, TCompare> : IBetterOrderedEnumerable<TSource, TCompare>
    {
        private readonly IEnumerable<TSource> source;

        public BetterOrderedEnumerable(IEnumerable<TSource> source, Func<TSource, TCompare> selector)
        {
            this.source = source;
            this.Selector = selector;
        }

        public Func<TSource, TCompare> Selector { get; }

        public IEnumerator<TSource> GetEnumerator()
        {
            return this.source.OrderBy(this.Selector).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public interface IBetterOrderedEnumerable<TSource, out TCompare> : IEnumerable<TSource>
    {
        public Func<TSource, TCompare> Selector { get; }
    }

    public sealed class PropertyAccessor
    {
        public PropertyAccessor()
        {
        }
    }
}
