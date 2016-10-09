#if !NET40
namespace System.Collections.Concurrent
{
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Represents a thread-safe, FIFO collection
    /// </summary>
    /// <typeparam name="T">The type of the elements contained in the queue</typeparam>
    /// <threadsafety static="true" instance="true"/>
    internal sealed class ConcurrentQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// The first element of the collection
        /// </summary>
        private Node first;

        /// <summary>
        /// The last element of the collection
        /// </summary>
        private Node last;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcurrentQueue{T}"/> class
        /// </summary>
        public ConcurrentQueue()
        {
            this.first = new Node();
            this.last = this.first;
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="ConcurrentQueue{T}"/>
        /// </summary>
        /// <param name="item">
        /// The object to add to the end of the <see cref="ConcurrentQueue{T}"/>. The value can be a null reference for reference types
        /// </param>
        public void Enqueue(T item)
        {
            var newLast = new Node(item);
            var previousLast = Interlocked.Exchange(ref this.last, newLast);
            previousLast.Next = newLast;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ConcurrentQueue{T}"/>
        /// </summary>
        /// <returns>An enumerator for the contents of the <see cref="ConcurrentQueue{T}"/></returns>
        /// <remarks>
        /// The enumeration represents a moment-in-time snapshot of the contents of the queue. It does not reflect any updates to the collection after <see cref="GetEnumerator"/> was called. The enumerator is safe to use concurrently with reads from and writes to the queue.
        /// <para/>
        /// The enumerator returns the collection elements in the order in which they were added, which is FIFO order(first-in, first-out).
        /// </remarks>
        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumeratorIterator(this.first, this.last);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> that can be used to iterate through the collection</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns a <see cref="IEnumerator{T}"/> that iterates through all of the elements between <paramref name="initialNode"/> and <paramref name="terminalNode"/>, inclusive
        /// </summary>
        /// <param name="initialNode">The <see cref="Node"/> to begin enumeration at</param>
        /// <param name="terminalNode">The <see cref="Node"/> to stop enumeration at</param>
        /// <returns>A <see cref="IEnumerator{T}"/> that iterates through all of the elements between <paramref name="initialNode"/> and <paramref name="terminalNode"/>, inclusive</returns>
        private static IEnumerator<T> GetEnumeratorIterator(Node initialNode, Node terminalNode)
        {
            if (initialNode.Next == null)
            {
                yield break;
            }

            for (var current = initialNode.Next; current != null && current != terminalNode.Next; current = current.Next)
            {
                yield return current.Value;
            }
        }

        /// <summary>
        /// A node within a linked-list that represents the value at that node's element within the list, as well as a pointer to the next node in the list
        /// </summary>
        /// <threadsafety static="true" instance="false"/>
        private sealed class Node
        {
            /// <summary>
            /// The value at the element of this node within the linked list
            /// </summary>
            private readonly T value;

            /// <summary>
            /// Initializes a new instance of the <see cref="Node"/> class
            /// </summary>
            public Node()
            {
                this.Next = null;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Node"/> class
            /// </summary>
            /// <param name="value">The value at the element of this node within the linked list</param>
            public Node(T value)
                : this()
            {
                this.value = value;
            }
            
            /// <summary>
            /// Gets the value at the element of this node within the linked list
            /// </summary>
            public T Value
            {
                get
                {
                    return this.value;
                }
            }

            /// <summary>
            /// Gets or sets the next node within the linked list
            /// </summary>
            public Node Next { get; set; }
        }
    }
}
#endif