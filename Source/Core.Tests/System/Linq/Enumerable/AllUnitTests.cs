namespace System.Linq
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System.Collections.Generic;
    using Collections;

    public static class SideEffectExtensions
    {
        public static IEnumerable<T> AttachSideEffect<T>(this IEnumerable<T> source, Func<T, bool> applySideEffect, Action<T> sideEffect)
        {
            return new AttachSideEffectEnumerable<T>(source, applySideEffect, sideEffect);
        }

        private sealed class AttachSideEffectEnumerable<T> : IEnumerable<T>
        {
            IEnumerable<T> source;
            Func<T, bool> applySideEffect;
            Action<T> sideEffect;

            private int furthestEnumeratedIndex;

            public AttachSideEffectEnumerable(IEnumerable<T> source, Func<T, bool> applySideEffect, Action<T> sideEffect)
            {
                this.source = source;
                this.applySideEffect = applySideEffect;
                this.sideEffect = sideEffect;

                this.furthestEnumeratedIndex = -1;
            }

            public IEnumerator<T> GetEnumerator()
            {
                //// TODO make this configurable? also, what are the implications of something like .any() calling dispose after getting only one element, but them maybe select is called or something
                return new EnumerateOnDispose<T>(this.GetEnumerable());
            }

            private IEnumerator<T> GetEnumerable()
            {
                var index = 0;
                foreach (var element in this.source)
                {
                    if (this.applySideEffect(element) && index > this.furthestEnumeratedIndex)
                    {
                        this.furthestEnumeratedIndex = index;
                        this.sideEffect(element);
                    }

                    yield return element;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        private sealed class EnumerateOnDispose<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> enumerator;

            public EnumerateOnDispose(IEnumerator<T> enumerator)
            {
                this.enumerator = enumerator;
            }

            public T Current
            {
                get
                {
                    return this.enumerator.Current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public void Dispose()
            {
                while (enumerator.MoveNext())
                {
                }

                this.enumerator.Dispose();
            }

            public bool MoveNext()
            {
                return this.enumerator.MoveNext();
            }

            public void Reset()
            {
                throw new NotImplementedException();
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
        /// Ensures that all elements of an empty sequence meet a condition
        /// </summary>
        [TestMethod]
        public void SideEffects()
        {
            var data = new int[10];
            var result = data
                .Select(value =>
                {
                    try
                    {
                        return new Union<int, Exception>(Operation(value));
                    }
                    catch (Exception e)
                    {
                        return new Union<int, Exception>(e);
                    }
                })
                .AttachSideEffect(union => union.Second.HasValue, union => Console.WriteLine(union.Second.Value.Message))
                .Where(union => union.First.HasValue)
                .Select(union => union.First);

            data
                .AttachSideEffect(value => true, value => Console.WriteLine(value))
                .Where(value => value % 2 == 0 /*something like, where appaddress is replyurl*/); //// TODO other interesting question here is about heterogeneous collections where we want to treat the different types differently, but only enumerate once
        }

        private T Operation<T>(T value)
        {
            return value;
        }

        private sealed class Union<TFirst, TSecond>
        {
            public Union(TFirst first)
            {
                this.First = new Nullable<TFirst>(first);
            }

            public Union(TSecond second)
            {
                this.Second = new Nullable<TSecond>(second);
            }

            public Nullable<TFirst> First { get; }

            public Nullable<TSecond> Second { get; }
        }

        private struct Nullable<T>
        {
            private readonly T value;

            public Nullable(T value)
            {
                this.HasValue = true;
                this.value = value;
            }

            public bool HasValue { get; }

            public T Value
            {
                get
                {
                    if (!this.HasValue)
                    {
                        throw new InvalidOperationException("TODO");
                    }

                    return this.value;
                }
            }
        }

        /// <summary>
        /// Ensures that all elements of an empty sequence meet a condition
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that all elements of an empty sequence meet a condition")]
        [Priority(1)]
        [TestMethod]
        public void AllEmpty()
        {
            Assert.AreEqual(true, Enumerable.Empty<string>().All(val => false)); 
        }

        /// <summary>
        /// Ensures that if all elements match a condition, true is returned
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if all elements match a condition, true is returned")]
        [Priority(1)]
        [TestMethod]
        public void AllTrue()
        {
            Assert.AreEqual(true, new[] { 1, 2, 3, 4, 5 }.All(val => val > 0));
        }

        /// <summary>
        /// Ensures that if only some elements match a condition, false is returned
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that if only some elements match a condition, false is returned")]
        [Priority(1)]
        [TestMethod]
        public void AllFalse()
        {
            Assert.AreEqual(false, new[] { 1, 2, 3, 4, 5 }.All(val => val < 4));
        }
    }
}
