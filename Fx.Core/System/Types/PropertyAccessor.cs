using System.Collections.Generic;
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
            var ordered = data.OrderBy(bar => bar.Frob);

            var data2 = new[] { new Bar() };
            var ordered2 = data2.OrderBy(bar => bar.Frob);


            var merged = ordered.Merge(ordered2, bar => bar.Frob);


            //// var whered = ordered.Where(bar => bar.Frob < 5);


        }

        public static IEnumerable<TSource> Merge<TSource, TCompare>(
            this IEnumerable<TSource> first, 
            IEnumerable<TSource> second,
            Func<TSource, TCompare> selector)
        {
        }
    }

    public sealed class PropertyAccessor
    {
        public PropertyAccessor()
        {
        }
    }
}
