namespace Fx.Clock
{
    using System;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class ManualClock : IClock //// TODO need better name
    {
        private long current;

        public ManualClock(DateTime start)
        {
            this.current = start.Ticks;
        }

        public DateTime UtcNow
        {
            get
            {
                return new DateTime(this.current);
            }
        }

        public void Increment(TimeSpan delta)
        {
            Interlocked.Add(ref this.current, delta.Ticks);
        }
    }
}
