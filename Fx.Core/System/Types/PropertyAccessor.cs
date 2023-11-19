using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Types
{
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

    public sealed class PropertyAccessorComparer<TSource, TCompare> : IComparer<PropertyAccessor<TSource, TCompare>>
    {
        public int Compare(PropertyAccessor<TSource, TCompare>? x, PropertyAccessor<TSource, TCompare>? y)
        {
            throw new NotImplementedException();
        }
    }

    public static class PropertyAccessor
    {
        public static PropertyAccessor<TSource, TCompare> Create<TSource, TCompare>(Expression<Func<TSource, TCompare>> selectorExpression)
        {
            return Create(selectorExpression.Body, selectorExpression);
        }

        private static PropertyAccessor<TSource, TCompare> Create<TSource, TCompare>(Expression expression, Expression<Func<TSource, TCompare>> selectorExpression)
        {
            if (expression is MemberExpression memberExpression)
            {
                if (memberExpression.Member is PropertyInfo propertyInfo || memberExpression.Member is FieldInfo fieldInfo) //// TODO can probably opmitize with memberinfo.type flags
                {
                    if (memberExpression.Expression is ParameterExpression constantExpression)
                    {
                        return new PropertyAccessor<TSource, TCompare>.DirectPropertyAccessor<TSource, TCompare>(selectorExpression);
                    }
                    else if (memberExpression.Expression is MemberExpression nestedDereference)
                    {
                        /*var directPropertyAccessor = new DirectPropertyAccessor<TSource, string>(null);
                        var potentiallyIndirectPropertyAccessor = Create(null, null);
                        return new IndirectPropertyAccessor<TSource, string, TCompare>(directPropertyAccessor, potentiallyIndirectPropertyAccessor);

                        return new IndirectPropertyAccessor(nestedDereference.Member, Create(nestedDereference.Expression));

                        var directPropertyAccessor = new DirectPropertyAccessor<TSource, string>(null);
                        return new IndirectPropertyAccessor<TSource, string, TCompare>(directPropertyAccessor, Create(memberExpression.Expression, selectorExpression));*/
                    }
                }
            }

            throw new InvalidOperationException("TODO expression is not a chain of accessors");
        }
    }

    public abstract class PropertyAccessor<TSource, TCompare>
    {
        private protected PropertyAccessor()
        {
        }

        public Expression<Func<TSource, TCompare>> SelectorExpression { get; private set; } //// TODO this shold be set through the constructor some how

        public sealed class IndirectPropertyAccessor<TSourceIndirect, TIntermediate, TCompareIndirect> : PropertyAccessor<TSourceIndirect, TCompareIndirect>
        {
            public IndirectPropertyAccessor(DirectPropertyAccessor<TSourceIndirect, TIntermediate> directPropertyAccessor, PropertyAccessor<TIntermediate, TCompareIndirect> propertyAccessor)
            {
                DirectPropertyAccessor = directPropertyAccessor;
                PropertyAccessor = propertyAccessor;
                //// TODO set the base selectorexpression
            }

            public DirectPropertyAccessor<TSourceIndirect, TIntermediate> DirectPropertyAccessor { get; }

            public PropertyAccessor<TIntermediate, TCompareIndirect> PropertyAccessor { get; }
        }

        public sealed class DirectPropertyAccessor<TSourceDirect, TCompareDirect> : PropertyAccessor<TSourceDirect, TCompareDirect>
        {
            public DirectPropertyAccessor(Expression<Func<TSourceDirect, TCompareDirect>> selectorExpression) //// TODO make this not public
            {
                base.SelectorExpression = selectorExpression;
            }
        }
    }

    public abstract class Shared<TSource, TResult>
    {
    }

    public sealed class BaseCase<TSource> : Shared<TSource, TSource>
    {
        public BaseCase(Expression<Func<TSource, TSource>> selectorExpression) //// TODO make this not public
        {
            this.SelectorExpression = selectorExpression;
        }

        public Expression<Func<TSource, TSource>> SelectorExpression { get; }
    }

    public sealed class DirectCase<TSource, TResult> : Shared<TSource, TResult>
    {
        public DirectCase(Expression<Func<TSource, TResult>> selectorExpression)
        {
        }

        public Expression<Func<TSource, TResult>> Accessor { get; set; }

        public BaseCase<TResult> BaseCase { get; set; }
    }

    public sealed class IndirectCase<TShared, TResult, TSource, TIntermediate> : Shared<TSource, TResult> where TShared : Shared<TSource, TIntermediate>
    {
        public IndirectCase(TShared sourceToIntermediate, DirectCase<TIntermediate, TResult> intermediateToResult)
        {
            IntermediateToResult = intermediateToResult;
            SourceToIntermediate = sourceToIntermediate;
        }

        public DirectCase<TIntermediate, TResult> IntermediateToResult { get; }

        //// public TShared SourceToIntermediate { get; }

        public TShared SourceToIntermediate { get; }
    }

    public static class AccessorExtensions
    {
        public static IndirectCase<TShared, TResult, TSource, TIntermediate> And<TShared, TResult, TSource, TIntermediate>(
            this TShared shared,
            Expression<Func<TIntermediate, TResult>> func)
            where TShared : Shared<TSource, TIntermediate>
        {
            return new IndirectCase<TShared, TResult, TSource, TIntermediate>(shared, new DirectCase<TIntermediate, TResult>(func));
        }
    }

    public static class Foo
    {
        public static string Test(Bar bar)
        {
            return bar.Fizz;
        }

        public static void TestExpression(Expression<Func<Bar, string>> func)
        {
            ////   TestAccessor(func);
        }

        public static void DoWork()
        {
            var accessor = new DirectCase<Bar, Frub>(bar => bar.Frub);
            var newAccessor = accessor
                .And<DirectCase<Bar, Frub>, First, Bar, Frub>(frub => frub.First)
                .And<IndirectCase<DirectCase<Bar, Frub>, First, Bar, Frub>, Second, Bar, First>(first => first.Second);


            //// TODO make this work: new PropertyAccessor<Bar, string>.DirectPropertyAccessor(Test);

            PropertyAccessor.Create((Bar bar) => bar);
            ////            PropertyAccessor<Bar, string>.Create(bar => bar.Frub.Tazz);

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

        public First First { get; set; }
    }

    public class First
    {
        public Second Second { get; set; }
    }

    public class Second
    {
        public Third Third { get; set; }
    }

    public class Third
    {
        public byte ThirdProp { get; set; }
    }
}
