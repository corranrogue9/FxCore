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
            return null;
        }
    }

    public static class OrderedExtension
    {
        public static IBetterOrderedEnumerable<TSource, TCompare> BetterOrderBy<TSource, TCompare>(this IEnumerable<TSource> self, Func<TSource, TCompare> selector)
        {
            return null;
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
