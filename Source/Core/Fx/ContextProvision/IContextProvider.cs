namespace Fx.ContextProvision
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides contextual data for tracing events
    /// </summary>
    /// <threadsafety instance="true"/>
    public interface IContextProvider
    {
        /// <summary>
        /// Adds contextual metadata represented by <paramref name="data"/> to the current logical operation
        /// </summary>
        /// <param name="data">The metadata that should be added to the current logical operation</param>
        /// <returns>The new context containing all of the current logical operation information; when disposed, this object will remove the newly added metadata from the current logical operation</returns>
        /// <remarks>Due to the nature of this functionality being critical to instrumentation, in the error case of <paramref name="data"/> being null, it should be assumed that data is an empty collection. Further, in the event that any key or value within the collection is null, the case should be handled without throwing <see cref="Exception"/>s</remarks>
        IDisposable ProvideContext(IEnumerable<KeyValuePair<string, object>> data);
    }
}
