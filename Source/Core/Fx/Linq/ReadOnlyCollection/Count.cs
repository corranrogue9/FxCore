namespace Fx.Linq
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true"/>
    public static partial class ReadOnlyCollectionExtensions
    {
        public static int Count<T>(this IReadOnlyCollection<T> source)
        {
            Ensure.NotNull(source, nameof(source));

            return source.Count;
        }
    }
}
