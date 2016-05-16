#if !NET46
namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a strongly-typed, read-only collection of elements
    /// </summary>
    /// <typeparam name="T">The type of the elements</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1014:OpeningGenericBracketsMustBeSpacedCorrectly")]
    public interface IReadOnlyCollection
#if NET40
        <out T> 
#else
        <T>
#endif
        : IEnumerable<T>, IEnumerable
    {
        /// <summary>
        /// Gets the number of elements in the collection
        /// </summary>
        int Count { get; }
    }
}
#endif