﻿#if !NET40
namespace System
{
    using System.Collections.Generic;

    /// <summary>
    /// A 3-ple
    /// </summary>
    /// <typeparam name="T1">The type of the first item</typeparam>
    /// <typeparam name="T2">The type of the second item</typeparam>
    /// <typeparam name="T3">The type of the third item</typeparam>
    /// <threadsafety static="true" instance="true"/>
    internal sealed class Tuple<T1, T2, T3>
    {
        /// <summary>
        /// The first item
        /// </summary>
        private readonly T1 item1;

        /// <summary>
        /// The second item
        /// </summary>
        private readonly T2 item2;

        /// <summary>
        /// The third item
        /// </summary>
        private readonly T3 item3;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tuple{T1, T2, T3}"/> class
        /// </summary>
        /// <param name="item1">The first item</param>
        /// <param name="item2">The second item</param>
        /// <param name="item3">The third item</param>
        public Tuple(T1 item1, T2 item2, T3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
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
        /// Gets the second item
        /// </summary>
        public T2 Item2
        {
            get
            {
                return this.item2;
            }
        }

        /// <summary>
        /// Gets the third item
        /// </summary>
        public T3 Item3
        {
            get
            {
                return this.item3;
            }
        }

        /// <summary>
        /// Determines if two objects are equal
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>True if they are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            var tuple = obj as Tuple<T1, T2, T3>;
            if (tuple == null)
            {
                return false;
            }

            var comparer1 = Comparer<T1>.Default;
            var comparer2 = Comparer<T2>.Default;
            var comparer3 = Comparer<T3>.Default;
            return comparer1.Compare(this.item1, tuple.item1) == 0 && comparer2.Compare(this.item2, tuple.item2) == 0 && comparer3.Compare(this.item3, tuple.item3) == 0;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            return this.item1.GetHashCode() ^ this.item2.GetHashCode() ^ this.item3.GetHashCode();
        }
    }
}
#endif