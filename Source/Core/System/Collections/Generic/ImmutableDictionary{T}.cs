namespace System.Collections.Generic
{
    using Fx;

    /// <summary>
    /// A dictionary that can only be read from after instantiation
    /// </summary>
    /// <typeparam name="TKey">The type of the keys stored in this dictionary</typeparam>
    /// <typeparam name="TValue">The type of the values stored in this dictionary</typeparam>
    /// <threadsafety static="true" instance="true"/>
    public sealed class ImmutableDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        /// <summary>
        /// The dictionary whose data will be used when we delegate each of our calls to it
        /// </summary>
        private readonly IReadOnlyDictionary<TKey, TValue> dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImmutableDictionary{TKey, TValue}"/> class
        /// </summary>
        /// <param name="dictionary">The dictionary whose data will be used when we delegate each of our calls to it</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dictionary"/> is null or one of the elements of <paramref name="dictionary"/> contains a null key</exception>
        /// <exception cref="ArgumentException">Thrown if two or more elements of <paramref name="dictionary"/> contain the same key</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1002:SemicolonsMustBeSpacedCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:ClosingParenthesisMustBeSpacedCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1111:ClosingParenthesisMustBeOnLineOfLastParameter")]
        public ImmutableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> dictionary)
        {
            Ensure.NotNull(dictionary, nameof(dictionary));

            var copy = new Dictionary<TKey, TValue>();
            foreach (var element in dictionary)
            {
                copy.Add(element.Key, element.Value);
            }

            this.dictionary =
#if !NET45
                new ReadOnlyDictionary<TKey, TValue>(
#endif
                    copy
#if !NET45
                )
#endif
                ;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImmutableDictionary{TKey, TValue}"/> class
        /// </summary>
        /// <param name="dictionary">The dictionary whose data will be used when we delegate each of our calls to it</param>
        /// <param name="equalityComparer">
        /// The comparer that should be used when determining if two keys with the new <see cref="ImmutableDictionary{TKey, TValue}"/> are the same
        /// </param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dictionary"/> or <paramref name="equalityComparer"/> is null or one of the elements of <paramref name="dictionary"/> contains a null key</exception>
        /// <exception cref="ArgumentException">Thrown if two or more elements of <paramref name="dictionary"/> contain the same key</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1002:SemicolonsMustBeSpacedCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:ClosingParenthesisMustBeSpacedCorrectly")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1111:ClosingParenthesisMustBeOnLineOfLastParameter")]
        public ImmutableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> dictionary, IEqualityComparer<TKey> equalityComparer)
        {
            Ensure.NotNull(dictionary, nameof(dictionary));
            Ensure.NotNull(equalityComparer, nameof(equalityComparer));

            var copy = new Dictionary<TKey, TValue>(equalityComparer);
            foreach (var element in dictionary)
            {
                copy.Add(element.Key, element.Value);
            }

            this.dictionary =
#if !NET45
                new ReadOnlyDictionary<TKey, TValue>(
#endif
                    copy
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
