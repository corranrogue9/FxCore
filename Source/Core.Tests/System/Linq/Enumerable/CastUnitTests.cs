namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        /// <summary>
        /// Casts a sequence that is already an enumerable
        /// </summary>
        [TestCategory("Unit")]
        [Description("Casts a sequence that is already an enumerable")]
        [Priority(1)]
        [TestMethod]
        public void CastIdentity()
        {
            var list = new List<string>();
            list.Add("test");
            var casted = list.Cast<string>();
            Assert.IsTrue(list == casted);
        }

        /// <summary>
        /// Casts an empty sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Casts an empty sequence")]
        [Priority(1)]
        [TestMethod]
        public void CastEmpty()
        {
            var original = Enumerable.Empty<object>();
            var casted = original.Cast<string>();
            Assert.IsFalse(original == casted);
            Assert.IsFalse(casted.Any());
        }

        /// <summary>
        /// Casts a sequence from derived types to base types
        /// </summary>
        [TestCategory("Unit")]
        [Description("Casts a sequence from derived types to base types")]
        [Priority(1)]
        [TestMethod]
        public void CastDerivedToBase()
        {
            var list = new List<Derived>();
            list.Add(new Derived());
            Assert.IsTrue(list.Cast<Base>().Any());
        }

        /// <summary>
        /// Casts a sequence from derived types to derived types
        /// </summary>
        [TestCategory("Unit")]
        [Description("Casts a sequence from derived types to derived types")]
        [Priority(1)]
        [TestMethod]
        public void CastDerivedToDerived()
        {
            var list = new List<Base>();
            list.Add(new Derived());
            Assert.IsTrue(list.Cast<Derived>().Any());
        }

        /// <summary>
        /// A derived class
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private class Derived : Base
        {
        }

        /// <summary>
        /// A base class
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private class Base
        {
        }
    }
}
