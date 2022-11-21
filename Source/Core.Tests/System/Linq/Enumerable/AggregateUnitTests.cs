namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class NeededForExtensions
    {
        public interface INewEnumerable<TValue>
        {
            INewEnumerator<TValue> GetEnumerator();
        }

        public interface INewEnumerator<TValue>
        {
            TValue Current { get; }

            /// <summary>
            /// TODO does an out parameter use the stack or the heap? maybe defeats the purpose if it uses the heap; also, you no longer have a generic type for the enumerator, so this really defeats the purpose...
            /// </summary>
            /// <param name="next"></param>
            /// <returns></returns>
            bool MoveNext(out INewEnumerator<TValue> next);
        }

        public static IEnumerable<TValue> Enumerate<TValue>(this INewEnumerable<TValue> source)
        {
            INewEnumerator<TValue> enumerator = source.GetEnumerator();
            while (enumerator.MoveNext(out enumerator))
            {
                yield return enumerator.Current;
            }
        }

        public static INewEnumerable<TResult> Select<TValue, TResult>(this INewEnumerable<TValue> source, Func<TValue, TResult> selector)
        {
            return new EnumerableImplementation<TResult>(source.Enumerate().Select(selector));
        }

        public static INewEnumerable<TValue> Skip<TValue>(this INewEnumerable<TValue> source, int count)
        {
            //// TODO not lazily evaluated, but illustrates the point that you don't have to continue to realize the first "count" elements over and over
            INewEnumerator<TValue> enumerator = source.GetEnumerator();
            while (count-- > 0 && enumerator.MoveNext(out enumerator))
            {
            }

            return new Enumerator<TValue>(enumerator);
        }

        private sealed class Enumerator<TValue> : INewEnumerable<TValue>
        {
            private readonly INewEnumerator<TValue> enumerator;

            public Enumerator(INewEnumerator<TValue> enumerator)
            {
                this.enumerator = enumerator;
            }

            public INewEnumerator<TValue> GetEnumerator()
            {
                return this.enumerator;
            }
        }

        /// <summary>
        /// private because it doesn't actually allow the enumerator to be re-used like it should, only used for out LINQ equivalents
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        private sealed class EnumerableImplementation<TValue> : INewEnumerable<TValue>
        {
            private readonly IEnumerable<TValue> source;

            public EnumerableImplementation(IEnumerable<TValue> source)
            {
                this.source = source;
            }

            public INewEnumerator<TValue> GetEnumerator()
            {
                return new Enumerator(this.source);
            }

            public struct Enumerator : INewEnumerator<TValue>
            {
                private readonly IEnumerator<TValue> source;

                public Enumerator(IEnumerable<TValue> source)
                {
                    this.source = source.GetEnumerator();
                }

                public TValue Current
                {
                    get
                    {
                        return this.source.Current;
                    }
                }

                public bool MoveNext(out INewEnumerator<TValue> next)
                {
                    next = this;
                    return this.source.MoveNext();
                }
            }
        }

        public static void DoWork()
        {
            var list = new NewList<string>(new[] { "Asdf", "qwer", "1234" });
            var firstCharacters = list.Select(foo => foo[0]);

            var range = new NewList<int>(Enumerable.Range(0, 100000).ToList());
            var skipped = range.Skip(99998);
            var isTrue = skipped.Enumerate().ElementAt(0) == 99999;
        }

        public sealed class NewList<TValue> : INewEnumerable<TValue>
        {
            private readonly IReadOnlyList<TValue> values;

            public NewList(IReadOnlyList<TValue> values)
            {
                this.values = values;
            }

            public INewEnumerator<TValue> GetEnumerator()
            {
                return new Enumerator(this.values, -1);
            }

            public sealed class Enumerator : INewEnumerator<TValue>
            {
                private readonly IReadOnlyList<TValue> values;

                private readonly int index;

                public Enumerator(IReadOnlyList<TValue> values, int index)
                {
                    this.values = values;
                    this.index = index;
                }

                public TValue Current
                {
                    get
                    {
                        //// TODO this is really bad when instantiated with index = -1
                        return this.values[this.index];
                    }
                }

                public bool MoveNext(out INewEnumerator<TValue> next)
                {
                    if (this.index < this.values.Count - 1)
                    {
                        next = new Enumerator(this.values, this.index + 1);
                        return true;
                    }
                    else
                    {
                        next = default(Enumerator);
                        return false;
                    }
                }
            }
        }
    }
     
    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Aggregates a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSingle()
        {
            Assert.AreEqual(1, new[] { 1 }.Aggregate((first, second) => first + second));
        }

        /// <summary>
        /// Aggregates a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Aggregate()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual(21, data.Aggregate((first, second) => first + second));
        }

        /// <summary>
        /// Aggregates an empty sequence with a seed
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates an empty sequence with a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSeedEmpty()
        {
            Assert.AreEqual("this is a test", Enumerable.Empty<string>().Aggregate("this is a test", (first, second) => string.Concat(first, second)));
        }

        /// <summary>
        /// Aggregates a sequence with a single element with a seed
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a single element with a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSeedSingle()
        {
            Assert.AreEqual(2, new[] { 1 }.Aggregate(1, (first, second) => first + second));
        }

        /// <summary>
        /// Aggregates a sequence with a seed
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSeed()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual(31, data.Aggregate(10, (first, second) => first + second));
        }

        /// <summary>
        /// Aggregates an empty sequence with a selector and a seed
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates an empty sequence with a selector and a seed")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSelectorEmpty()
        {
            Assert.AreEqual(
                "is a test",
                Enumerable.Empty<string>().Aggregate("this is a test", (first, second) => string.Concat(first, second), val => val.Substring(5)));
        }

        /// <summary>
        /// Aggregates a sequence with a single element using a seed and a selector
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a single element using a seed and a selector")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSelectorSingle()
        {
            Assert.AreEqual(3, new[] { 1 }.Aggregate(1, (first, second) => first + second, val => val + 1));
        }

        /// <summary>
        /// Aggregates a sequence with a selector
        /// </summary>
        [TestCategory("Unit")]
        [Description("Aggregates a sequence with a selector")]
        [Priority(1)]
        [TestMethod]
        public void AggregateSelector()
        {
            var data = new[] { 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual(32, data.Aggregate(10, (first, second) => first + second, val => val + 1));
        }
    }
}
