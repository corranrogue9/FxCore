namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public sealed class ReverseUnitTests
    {
        public ReverseUnitTests()
        {
        }

        public void Reverse<TEnumerable>(Func<IEnumerable<int>, TEnumerable> factory, Func<TEnumerable, IEnumerable<int>> reverse) where TEnumerable : IEnumerable<int>
        {
            CollectionAssert.AreEqual(new[] { 5, 4, 3, 2, 1 }, reverse(factory(new[] { 1, 2, 3, 4, 5 })).ToList());
        }

        public void ReverseSingle<TEnumerable>(Func<IEnumerable<int>, TEnumerable> factory, Func<TEnumerable, IEnumerable<int>> reverse) where TEnumerable : IEnumerable<int>
        {
            CollectionAssert.AreEqual(new[] { 5 }, reverse(factory(new[] { 5 })).ToList());
        }

        public void ReverseEmpty<TEnumerable>(Func<IEnumerable<int>, TEnumerable> factory, Func<TEnumerable, IEnumerable<int>> reverse) where TEnumerable : IEnumerable<int>
        {
            CollectionAssert.AreEqual(Enumerable.Empty<int>().ToList(), reverse(factory(Enumerable.Empty<int>())).ToList());
        }
    }
}
