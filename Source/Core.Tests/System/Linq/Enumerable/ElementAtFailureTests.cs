namespace System.Linq
{
    using System.Collections;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableFailureTests
    {
        /// <summary>
        /// Gets the element at an index within a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the element at an index within a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ElementAtNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ElementAt(0));
        }

        /// <summary>
        /// Gets the element at an index within a list that is out of range
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the element at an index within a list that is out of range")]
        [Priority(1)]
        [TestMethod]
        public void ElementAtListOutOfRange()
        {
            var list = new OtherList();
            Assert.AreEqual(10, list.ElementAt(-1));
        }

        /// <summary>
        /// Gets the element at an index within a sequence that is out of range
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the element at an index within a sequence that is out of range")]
        [Priority(1)]
        [TestMethod]
        public void ElementAtOutOfRange()
        {
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Empty<string>().ElementAt(-1));
        }

        /// <summary>
        /// Gets the element at an index within a sequence that is out of range
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the element at an index within a sequence that is out of range")]
        [Priority(1)]
        [TestMethod]
        public void ElementAtOutOfRangeEmptyData()
        {
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Empty<string>().ElementAt(0));
        }

        /// <summary>
        /// Gets the element at an index within a sequence that is out of range
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the element at an index within a sequence that is out of range")]
        [Priority(1)]
        [TestMethod]
        public void ElementAtOutOfRange2()
        {
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => Enumerable.Range(10, 5).ElementAt(6));
        }

        /// <summary>
        /// Gets the element at an index within a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Gets the element at an index within a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void ElementAtOrDefaultNullData()
        {
            IEnumerable<string> data = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => data.ElementAtOrDefault(10));
        }

        /// <summary>
        /// A <see cref="IList{T}"/> that returns the default value when indexed into
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private sealed class OtherList : IList<int>
        {
            /// <summary>
            /// Gets 10
            /// </summary>
            public int Count
            {
                get
                {
                    return 10;
                }
            }

            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors")]
            public bool IsReadOnly
            {
                get { throw new NotImplementedException(); }
            }

            /// <summary>
            /// Gets or sets the element at <paramref name="index"/>
            /// </summary>
            /// <param name="index">The index of the element to get or set</param>
            /// <returns>Returns 10</returns>
            public int this[int index]
            {
                get
                {
                    return 10;
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            /// <param name="item">The item</param>
            /// <returns>Throws <see cref="NotImplementedException"/></returns>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted")]
            public int IndexOf(int item)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            /// <param name="index">The index of the item</param>
            /// <param name="item">The item</param>
            public void Insert(int index, int item)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            /// <param name="index">The index</param>
            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }
            
            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            /// <param name="item">The item</param>
            public void Add(int item)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            public void Clear()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            /// <param name="item">The item</param>
            /// <returns>Throws <see cref="NotImplementedException"/></returns>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted")]
            public bool Contains(int item)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            /// <param name="array">The array</param>
            /// <param name="arrayIndex">The index</param>
            public void CopyTo(int[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }
            
            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            /// <param name="item">The item</param>
            /// <returns>Throws <see cref="NotImplementedException"/></returns>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted")]
            public bool Remove(int item)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            /// <returns>Throws <see cref="NotImplementedException"/></returns>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted")]
            public IEnumerator<int> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Throws <see cref="NotImplementedException"/>
            /// </summary>
            /// <returns>Throws <see cref="NotImplementedException"/></returns>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1625:ElementDocumentationMustNotBeCopiedAndPasted")]
            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
