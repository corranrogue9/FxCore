namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    using Fx;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Determines if there are any elements in a sequence that never has elements
        /// </summary>
        [TestCategory("Unit")]
        [Description("Determines if there are any elements in a sequence that never has elements")]
        [Priority(1)]
        [TestMethod]
        public void AsEnumerable()
        {
            var data = new Enumerable<int>(new[] { 1, 2, 3, 4 });
            Assert.IsFalse(data.Any());
            Assert.IsTrue(data.AsEnumerable().Any());
        }

        /// <summary>
        /// A <see cref="IEnumerable{T}"/> that overloads the Any method to always return false, even when there is data
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence</typeparam>
        /// <threadsafety static="true">
        /// Instances of this type will be thread safe if the input <see cref="IEnumerable{T}"/> is thread-safe.
        /// </threadsafety>
        private sealed class Enumerable<T> : IEnumerable<T>
        {
            /// <summary>
            /// The data that is stored in this <see cref="IEnumerable{T}"/>
            /// </summary>
            private readonly IEnumerable<T> data;

            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerable{T}"/> class
            /// </summary>
            /// <param name="data">The data that will be contained in the new sequence</param>
            /// <exception cref="ArgumentNullException">Thrown if <paramref name="data"/> is null</exception>
            public Enumerable(IEnumerable<T> data)
            {
                Ensure.NotNull(data, nameof(data));

                this.data = data;
            }

            /// <summary>
            /// Returns false
            /// </summary>
            /// <returns>Always returns false</returns>
            public bool Any()
            {
                return false;
            }

            /// <summary>
            /// Returns an enumerator that iterates through the collection
            /// </summary>
            /// <returns>An enumerator that can be used to iterate through the collection</returns>
            public IEnumerator<T> GetEnumerator()
            {
                return this.data.GetEnumerator();
            }

            /// <summary>
            /// Returns an enumerator that iterates through a collection
            /// </summary>
            /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this.data).GetEnumerator();
            }
        }
    }
}
