namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// An adapter which leverages the data in a <see cref="ICollection{T}"/> to implement a <see cref="IReadOnlyCollection{T}"/>
    /// </summary>
    /// <typeparam name="T">They type of the elements stored in this collection</typeparam>
    /// <threadsafety static="true" instance="false"/>
    /// <remarks>This type is not immutable</remarks>
    public sealed class ReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
        /// <summary>
        /// The <see cref="ICollection{T}"/> whose data will be used when we delegate each of our <see cref="IReadOnlyCollection{T}"/> calls to it
        /// </summary>
        private readonly ICollection<T> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyCollection{T}"/> class
        /// </summary>
        /// <param name="collection">
        /// The <see cref="ICollection{T}"/> that we will delegate each of our <see cref="IReadOnlyCollection{T}"/> calls to and will serve as the data source for our implementation
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="collection"/> is null</exception>
        public ReadOnlyCollection(ICollection<T> collection)
        {
            Ensure.NotNull(collection, nameof(collection));

            this.collection = collection;
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
