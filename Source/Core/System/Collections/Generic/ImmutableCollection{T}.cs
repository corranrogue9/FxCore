namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// A collection that can only be read from after instantiation
    /// </summary>
    /// <typeparam name="T">They type of the elements stored in this collection</typeparam>
    /// <threadsafety static="true" instance="true"/>
    public sealed class ImmutableCollection<T> : IReadOnlyCollection<T>
    {
        /// <summary>
        /// The collection whose data will be used when we delegate each of our calls to it
        /// </summary>
        private readonly IReadOnlyCollection<T> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImmutableCollection{T}"/> class
        /// </summary>
        /// <param name="collection">The collection whose data will be used when we delegate each of our calls to it</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="collection"/> is null</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1002:SemicolonsMustBeSpacedCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:ClosingParenthesisMustBeSpacedCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1111:ClosingParenthesisMustBeOnLineOfLastParameter")]
        public ImmutableCollection(IEnumerable<T> collection)
        {
            Ensure.NotNull(collection, nameof(collection));

            this.collection =
#if !NET45
                new ReadOnlyCollection<T>(
#endif
                    new List<T>(collection)
#if !NET45
                )
#endif
                ;
        }

        /// <summary>
        /// Gets the number of elements in the collection
        /// </summary>
        public int Count
        {
            get
            {
                return this.collection.Count;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.collection).GetEnumerator();
        }
    }
}
