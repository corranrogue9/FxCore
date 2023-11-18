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
            var data = new[] { new Bar() };
            var ordered = data.BetterOrderBy(bar => bar.Fizz);

            var data2 = new[] { new Bar() };
            var ordered2 = data2.BetterOrderBy(bar => bar.Buzz);


            var merged = ordered.Merge(ordered2);


            //// var whered = ordered.Where(bar => bar.Frob < 5);


        }

        public static IEnumerable<TSource> Merge<TSource, TCompare>(
            this IBetterOrderedEnumerable<TSource, TCompare> first,
            IBetterOrderedEnumerable<TSource, TCompare> second)
        {
            if (first.Selector != second.Selector)
            {
                throw new ArgumentException();
            }

            var comparer = Comparer<TSource>.Default;

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

                return MergeIterator(firstEnumerator, secondEnumerator, comparer);
            }
        }

        private static IEnumerable<T> MergeIterator<T>(IEnumerator<T> firstEnumerator, IEnumerator<T> secondEnumerator, IComparer<T> comparer)
        {
            var firstElement = firstEnumerator.Current;
            var secondElement = secondEnumerator.Current;
            var firstHasMoved = true; // this *has* moved in the caller, hence the default to true
            var secondHasMoved = true; // this *has* moved in the caller, hence the default to true

            while (firstHasMoved && secondHasMoved)
            {
                if (comparer.Compare(firstElement, secondElement) < 0)
                {
                    yield return firstElement;
                    firstHasMoved = firstEnumerator.MoveNext();
                }
                else
                {
                    yield return secondElement;
                    secondHasMoved = secondEnumerator.MoveNext();
                }
            }

            // *at least* one of firstHasMoved and secondHasMoved is false; they cannot both be true; Enumerate returns the current element, so calling it on an
            // enumerator that has moved past the end will throw for most enumerators
            if (firstHasMoved)
            {
                firstEnumerator.Enumerate();
            }
            else if (secondHasMoved)
            {
                secondEnumerator.Enumerate();
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
