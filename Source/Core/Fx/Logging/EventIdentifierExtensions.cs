namespace Fx.Logging
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extension methods for <see cref="EventIdentifier"/>s
    /// </summary>
    /// <threadsafety static="true"/>
    public static class EventIdentifierExtensions
    {
        /// <summary>
        /// A regular expression that matches an argument in a format string
        /// </summary>
        private static readonly Regex FormatArgumentExpression = new Regex(@"(?<left>{*)(?<digit>\d+)(?<right>}*)", RegexOptions.Compiled);

        /// <summary>
        /// Creates a <see cref="Regex"/> that will match any message that uses the format specified by <paramref name="eventIdentifier"/>
        /// </summary>
        /// <param name="eventIdentifier">The <see cref="EventIdentifier"/> that we want to match messages from</param>
        /// <returns>A <see cref="Regex"/> that will match any message that uses the format specified by <paramref name="eventIdentifier"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="eventIdentifier"/> is null</exception>
        /// <exception cref="FormatException">Thrown if the format specified by <paramref name="eventIdentifier"/> contains an unequal number of opening and closing curly braces for a single argument</exception>
        /// <remarks>The resulting <see cref="Regex"/> uses the capture group "value" to contain the arguments that were used when formatting a message generated from <paramref name="eventIdentifier"/></remarks>
#if !NET35
        public static Regex CreateRegularExpression(EventIdentifier eventIdentifier)
#else
        public static Regex CreateRegularExpression(this EventIdentifier eventIdentifier)
#endif
        {
            Ensure.NotNull(eventIdentifier, nameof(eventIdentifier));

            var messageFormat = eventIdentifier.MessageFormat;
            var escapeCharacters = new char[] { '\\', '.', '$', '^', '[', '(', '|', ')', '*', '+', '?' };
            foreach (var character in escapeCharacters)
            {
                messageFormat = messageFormat.Replace(string.Empty + character, "\\" + character);
            }

            messageFormat = FormatArgumentExpression.Replace(
                messageFormat,
                (match) =>
                {
                    var leftCount = match.Groups["left"].Value.Length % 2;
                    var rightCount = match.Groups["right"].Value.Length % 2;
                    if (leftCount != rightCount)
                    {
                        throw new FormatException(Strings.EventIdentifierExtensionsFormat);
                    }
                    else
                    {
                        var value = match.Value;
                        if (leftCount == 1)
                        {
                            value = value.Replace(match.Groups["digit"].Value, "0");
                        }

                        return string.Format(value, "(?<value>.*)");
                    }
                });
            messageFormat = messageFormat.Replace("{", @"\{");
            return new Regex(messageFormat, RegexOptions.Singleline);
        }
    }
}
