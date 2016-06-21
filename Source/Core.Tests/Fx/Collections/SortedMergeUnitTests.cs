namespace Fx
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Collections;

    /// <summary>
    /// Unit tests for the <see cref="Ensure"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class SortedMergeUnitTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestCategory("Unit")]
        [Description("Ensures that a simple sample data set gets sorted")]
        [Priority(1)]
        [TestMethod]
        public void SampleDataTest1()

        {
            ICollection<IEnumerable<int>> x = new List<IEnumerable<int>>
            {
                new List<int> { 5, 7, 9 },
                new List<int> { 1, 2 ,3 },
                new List<int> { 4, 6, 8 }
            };

            var actual = x.Sorted(Comparer<int>.Default).ToList();
       
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, actual);
        }
    }
}