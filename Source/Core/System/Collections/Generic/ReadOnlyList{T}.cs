namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// An adapter which leverages data in a <see cref="IList{T}"/> to implement a <see cref="IReadOnlyList{T}"/> 
    /// </summary>
    /// <typeparam name="T">The type of the elements store in this list</typeparam>
    /// <threadsafety static="true" instance="false"/>
    /// <remarks>This type is not immutable</remarks>
    public sealed class ReadOnlyList<T> : IReadOnlyList<T>
    {
        /// <summary>
        /// the <see cref="IList{T}"/> whose data will be used when we delegate each of our <see cref="IReadOnlyList{T}"/> calls to it
        /// </summary>
        private readonly IList<T> list;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyList{T}"/> class
        /// </summary>
        /// <param name="list">
        /// The <see cref="IList{T}"/> that we will delegate each of our <see cref="IReadOnlyList{T}"/> calls to and will serve as the data source for our implementation
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="list"/> is null</exception>
        public ReadOnlyList(IList<T> list)
        {
            Ensure.NotNull(list, nameof(list));

            this.list = list;
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
            return ((IEnumerable)this.list).GetEnumerator();
        }
    }
}
