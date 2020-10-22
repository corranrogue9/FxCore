using System;

namespace Fx.Clock
{
    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class DateTimeClock : IClock
    {
        private DateTimeClock()
        {
        }

        public static DateTimeClock Instance { get; } = new DateTimeClock();

        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
