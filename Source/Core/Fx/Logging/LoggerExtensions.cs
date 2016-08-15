#if NET40
namespace Fx.Logging
{
    using System;

    /// <summary>
    /// Extension methods for <see cref="ILogger"/>s
    /// </summary>
    /// <threadsafety static="true"/>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Emits a formatted detail event to a log
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> that we will delegate that actual event emission to</param>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="messageFormat">The format that the message of the emitted event should use</param>
        /// <param name="data">The data to use to complete the message of the emitted event</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger"/> or <paramref name="messageFormat"/> is null</exception>
        public static void EmitDetail(this ILogger logger, int id, string messageFormat, params object[] data)
        {
            Ensure.NotNull(logger, nameof(logger));
            Ensure.NotNull(messageFormat, nameof(messageFormat));
            
            logger.EmitDetail(id, GetMessage(messageFormat, data));
        }

        /// <summary>
        /// Emits a formatted detail event to a log
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> that we will delegate that actual event emission to</param>
        /// <param name="eventIdentifier">The <see cref="EventIdentifier"/> that represents the kind of event being emitted</param>
        /// <param name="data">The data to use to complete the message of the emitted event</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger"/> or <paramref name="eventIdentifier"/> is null</exception>
        public static void EmitDetail(this ILogger logger, EventIdentifier eventIdentifier, params object[] data)
        {
            Ensure.NotNull(logger, nameof(logger));
            Ensure.NotNull(eventIdentifier, nameof(eventIdentifier));

            logger.EmitDetail(eventIdentifier.Id, eventIdentifier.MessageFormat, data);
        }

        /// <summary>
        /// Emits a formatted information event to a log
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> that we will delegate that actual event emission to</param>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="messageFormat">The format that the message of the emitted event should use</param>
        /// <param name="data">The data to use to complete the message of the emitted event</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger"/> or <paramref name="messageFormat"/> is null</exception>
        public static void EmitInformation(this ILogger logger, int id, string messageFormat, params object[] data)
        {
            Ensure.NotNull(logger, nameof(logger));
            Ensure.NotNull(messageFormat, nameof(messageFormat));

            logger.EmitInformation(id, GetMessage(messageFormat, data));
        }

        /// <summary>
        /// Emits a formatted information event to a log
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> that we will delegate that actual event emission to</param>
        /// <param name="eventIdentifier">The <see cref="EventIdentifier"/> that represents the kind of event being emitted</param>
        /// <param name="data">The data to use to complete the message of the emitted event</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger"/> or <paramref name="eventIdentifier"/> is null</exception>
        public static void EmitInformation(this ILogger logger, EventIdentifier eventIdentifier, params object[] data)
        {
            Ensure.NotNull(logger, nameof(logger));
            Ensure.NotNull(eventIdentifier, nameof(eventIdentifier));

            logger.EmitInformation(eventIdentifier.Id, eventIdentifier.MessageFormat, data);
        }

        /// <summary>
        /// Emits a formatted warning event to a log
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> that we will delegate that actual event emission to</param>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="messageFormat">The format that the message of the emitted event should use</param>
        /// <param name="data">The data to use to complete the message of the emitted event</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger"/> or <paramref name="messageFormat"/> is null</exception>
        public static void EmitWarning(this ILogger logger, int id, string messageFormat, params object[] data)
        {
            Ensure.NotNull(logger, nameof(logger));
            Ensure.NotNull(messageFormat, nameof(messageFormat));

            logger.EmitWarning(id, GetMessage(messageFormat, data));
        }

        /// <summary>
        /// Emits a formatted warning event to a log
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> that we will delegate that actual event emission to</param>
        /// <param name="eventIdentifier">The <see cref="EventIdentifier"/> that represents the kind of event being emitted</param>
        /// <param name="data">The data to use to complete the message of the emitted event</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger"/> or <paramref name="eventIdentifier"/> is null</exception>
        public static void EmitWarning(this ILogger logger, EventIdentifier eventIdentifier, params object[] data)
        {
            Ensure.NotNull(logger, nameof(logger));
            Ensure.NotNull(eventIdentifier, nameof(eventIdentifier));

            logger.EmitWarning(eventIdentifier.Id, eventIdentifier.MessageFormat, data);
        }

        /// <summary>
        /// Emits a formatted error event to a log
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> that we will delegate that actual event emission to</param>
        /// <param name="id">The ID of the event that is being emitted</param>
        /// <param name="messageFormat">The format that the message of the emitted event should use</param>
        /// <param name="data">The data to use to complete the message of the emitted event</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger"/> or <paramref name="messageFormat"/> is null</exception>
        public static void EmitError(this ILogger logger, int id, string messageFormat, params object[] data)
        {
            Ensure.NotNull(logger, nameof(logger));
            Ensure.NotNull(messageFormat, nameof(messageFormat));

            logger.EmitError(id, GetMessage(messageFormat, data));
        }

        /// <summary>
        /// Emits a formatted error event to a log
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> that we will delegate that actual event emission to</param>
        /// <param name="eventIdentifier">The <see cref="EventIdentifier"/> that represents the kind of event being emitted</param>
        /// <param name="data">The data to use to complete the message of the emitted event</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger"/> or <paramref name="eventIdentifier"/> is null</exception>
        public static void EmitError(this ILogger logger, EventIdentifier eventIdentifier, params object[] data)
        {
            Ensure.NotNull(logger, nameof(logger));
            Ensure.NotNull(eventIdentifier, nameof(eventIdentifier));

            logger.EmitError(eventIdentifier.Id, eventIdentifier.MessageFormat, data);
        }

        /// <summary>
        /// Creates the message that should be emitted for the given string format, and data that it should contain
        /// </summary>
        /// <param name="format">The format that the resulting message should have</param>
        /// <param name="data">The data that should be included in the resulting message</param>
        /// <returns>A message based on <paramref name="format"/> and <paramref name="data"/> that handles different error cases in an attempt to provide as much data as possible in the event of a failure</returns>
        private static string GetMessage(string format, params object[] data)
        {
            if (data == null)
            {
                return format;
            }
            else
            {
                try
                {
                    return string.Format(format, data);
                }
                catch
                {
#if DEBUG
                    throw;
#else
                    return string.Format(Strings.LoggerExtensionsFormat, format, string.Join(",", data));
#endif
                }
            }
        }
    }
}
#endif