namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableFailureTests
    {
        /// <summary>
        /// Casts a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Casts a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void CastNull()
        {
            List<string> list = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => list.Cast<string>());
        }
        
        /// <summary>
        /// Casts a sequence from base types to derived types
        /// </summary>
        [TestCategory("Failure")]
        [Description("Casts a sequence from base types to derived types")]
        [Priority(1)]
        [TestMethod]
        public void CastBaseToDerived()
        {
            var list = new List<Base>();
            list.Add(new Base());
            ExceptionAssert.Throws<InvalidCastException>(() => list.Cast<Derived>().Any());
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
