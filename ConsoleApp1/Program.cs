namespace CalendarService
{
    using Fx.Linq.V2;
    using System.Linq.V2;

    internal class Program
    {
        private static int networkCalls = 0;

        static void Main(string[] args)
        {
            var instanceEvents = GetInstanceEvents(); //// TODO apply the garrett extensions to see the difference in the network calls
            var seriesEvents = GetSeriesEvents(); //// TODO then apply the garrett extensions to see that this is broken

            var calendarEvents = instanceEvents
                .Concat(seriesEvents)
                .Where(calendarEvent => calendarEvent.Subject.Contains("another", StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var element in calendarEvents)
            {
                Console.WriteLine(element.Subject);
            }

            Console.WriteLine(networkCalls);

            Console.ReadLine();
        }

        private static IV2Enumerable<CalendarEvent> GetInstanceEvents()
        {
            return new[]
            {
                new CalendarEvent() { Subject = "an instance event"},
                new CalendarEvent() { Subject = "another instance event" },
            }.ToV2Enumerable();
        }

        private static IV2Enumerable<CalendarEvent> GetSeriesEvents()
        {
            return GetSeriesEventsIterator().ToV2Enumerable();
        }

        private static IEnumerable<CalendarEvent> GetSeriesEventsIterator()
        {
            var calendarEvents = new[]
            {
                new CalendarEvent() { Subject = "a series event" },
                new CalendarEvent() { Subject = "another series event" },
            };
            foreach (var calendarEvent in calendarEvents)
            {
                Interlocked.Increment(ref networkCalls);
                yield return calendarEvent;
            }
        }

        private sealed class CalendarEvent
        {
            public string Subject { get; set; }
        }
    }
}