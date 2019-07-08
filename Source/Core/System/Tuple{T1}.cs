#if !NET40
namespace System
{
    using System.Collections.Generic;

    /// <summary>
    /// A 1-ple
    /// </summary>
    /// <typeparam name="T1">The type of the first item</typeparam>
    /// <threadsafety static="true" instance="true"/>
    internal sealed class Tuple<T1>
    {
        /// <summary>
        /// The first item
        /// </summary>
        private readonly T1 item1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tuple{T1}"/> class
        /// </summary>
        /// <param name="item1">The first item</param>
        public Tuple(T1 item1)
        {
            this.item1 = item1;
        }

        /// <summary>
        /// Gets the first item
        /// </summary>
        public T1 Item1
        {
            get
            {
                return this.item1;
            }
        }

        /// <summary>
        /// Determines if two objects are equal
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>True if they are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            var tuple = obj as Tuple<T1>;
            if (tuple == null)
            {
                return false;
            }

            var comparer1 = Comparer<T1>.Default;
            return comparer1.Compare(this.item1, tuple.item1) == 0;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            return this.item1.GetHashCode();
        }
    }
}
#endif