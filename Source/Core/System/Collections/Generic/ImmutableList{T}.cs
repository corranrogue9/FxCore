namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// A list that can only be read from after instantiation
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in this list</typeparam>
    /// <threadsafety static="true" instance="true"/>
    public sealed class ImmutableList<T> : IReadOnlyList<T>
    {
        /// <summary>
        /// The list whose data will be used when we delegate each of our calls to it
        /// </summary>
        private readonly IReadOnlyList<T> list;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImmutableList{T}"/> class
        /// </summary>
        /// <param name="list">The list whose data will be used when we delegate each of our calls to it</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="list"/> is null</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1002:SemicolonsMustBeSpacedCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:ClosingParenthesisMustBeSpacedCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1111:ClosingParenthesisMustBeOnLineOfLastParameter")]
        public ImmutableList(IEnumerable<T> list)
        {
            Ensure.NotNull(list, nameof(list));

            this.list =
#if !NET45
                new ReadOnlyList<T>(
#endif
                    new List<T>(list)
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
                return this.list.Count;
            }
        }

        /// <summary>
        /// Gets the element at the specified index in the read-only list
        /// </summary>
        /// <param name="index">The zero-based index of the element to get</param>
        /// <returns>The element at the specified index in the read-only list</returns>
        public T this[int index]
        {
            get
            {
                return this.list[index];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
    }
}
