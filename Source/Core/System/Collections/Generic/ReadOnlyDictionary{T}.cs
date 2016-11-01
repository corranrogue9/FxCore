namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// An adapter which leverages the data in a <see cref="IDictionary{TKey, TValue}"/> to implement a <see cref="IReadOnlyDictionary{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TKey">The type of the keys stored in this dictionary</typeparam>
    /// <typeparam name="TValue">The type of the values stored in this dictionary</typeparam>
    /// <threadsafety static="true" instance="false"/>
    /// <remarks>This type is not immutable</remarks>
    public sealed class ReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        /// <summary>
        /// The <see cref="IDictionary{TKey, TValue}"/> whose data will be used when we delegate each of our <see cref="IReadOnlyDictionary{TKey, TValue}"/> calls to it
        /// </summary>
        private readonly IDictionary<TKey, TValue> dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyDictionary{TKey, TValue}"/> class
        /// </summary>
        /// <param name="dictionary">
        /// The <see cref="IDictionary{TKey, TValue}"/> that we will delegate each of our <see cref="IReadOnlyDictionary{TKey, TValue}"/> calls to and will serve as the data source for our implementation
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dictionary"/> is null</exception>
        public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary)
        {
            Ensure.NotNull(dictionary, nameof(dictionary));

            this.dictionary = dictionary;
        }
        
        /// <summary>
        /// Gets the number of elements in the collection
        /// </summary>
        public int Count
        {
            get
            {
                return this.dictionary.Count;
            }
        }

        /// <summary>
        /// Gets an enumerable collection that contains the keys in the read-only dictionary
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.dictionary.Keys;
            }
        }

        /// <summary>
        /// Gets an enumerable collection that contains the values in the read-only dictionary
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                return this.dictionary.Values;
            }
        }

        /// <summary>
        /// Gets the element that has the specified key in the read-only dictionary
        /// </summary>
        /// <param name="key">The key to locate</param>
        /// <returns>The element that has the specified key in the read-only dictionary</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is null</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the property is retrieved and <paramref name="key"/> is not found</exception>
        public TValue this[TKey key]
        {
            get
            {
                return this.dictionary[key];
            }
        }

        /// <summary>
        /// Determines whether the read-only dictionary contains an element that has the specified key
        /// </summary>
        /// <param name="key">The key to locate</param>
        /// <returns>true if the read-only dictionary contains an element that has the specified key; otherwise, false</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is null</exception>
        public bool ContainsKey(TKey key)
        {
            return this.dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }

        /// <summary>
        /// Gets the value that is associated with the specified key
        /// </summary>
        /// <param name="key">The key to locate</param>
        /// <param name="value">
        /// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized
        /// </param>
        /// <returns>
        /// true if the object that implements the <see cref="IReadOnlyDictionary{TKey, TValue}"/> interface contains an element that has the specified key; otherwise, false
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> is null</exception>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.dictionary).GetEnumerator();
        }
    }
}
