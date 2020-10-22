namespace Fx.Clock
{
    using System;

    /// <summary>
    /// Gets the current time stamp
    /// </summary>
    /// <threadsafety instance="true"/>
    public interface IClock
    {
        /// <summary>
        /// The current time in UTC
        /// </summary>
        DateTime UtcNow { get; }
    }
}
