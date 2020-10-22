namespace Fx.Clock
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public static class ClockExtensions
    {
        public static DateTime Today(this IClock clock)
        {
            return clock.UtcNow.Date;
        }
    }
}
