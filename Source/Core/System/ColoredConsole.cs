namespace System
{
    using System.IO;

    using Fx;

    /// <summary>
    /// A class which allows synchronized colorization of output to the console
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class ColoredConsole
    {
        /// <summary>
        /// The <see cref="object"/> that we will lock on in order to synchronize color changes on the console
        /// </summary>
        private static readonly object ColorLock = new object();

        /// <summary>
        /// The singleton instance of the <see cref="ColoredConsole"/> that uses the default colorization
        /// </summary>
        private static readonly ColoredConsole Singleton = new ColoredConsole(new ColoredConsoleSettings.Builder().Build());

        /// <summary>
        /// The default color to use when emitting strings to the console
        /// </summary>
        private readonly ConsoleColor color;

        /// <summary>
        /// The color to use when emitting warnings to the console
        /// </summary>
        private readonly ConsoleColor warningColor;

        /// <summary>
        /// The color to use when emitting errors to the console
        /// </summary>
        private readonly ConsoleColor errorColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColoredConsole"/> class
        /// </summary>
        /// <param name="settings">The <see cref="ColoredConsoleSettings"/> that will configure the new instance</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="settings"/> is null</exception>
        public ColoredConsole(ColoredConsoleSettings settings)
        {
            Ensure.NotNull(settings, nameof(settings));

            this.color = settings.Color;
            this.warningColor = settings.WarningColor;
            this.errorColor = settings.ErrorColor;
        }

        /// <summary>
        /// Gets the singleton instance of the <see cref="ColoredConsole"/> that uses the default colorization
        /// </summary>
        public static ColoredConsole Default
        {
            get
            {
                return Singleton;
            }
        }

        /// <summary>
        /// Writes the specified string value to <paramref name="output"/>
        /// </summary>
        /// <param name="color">The color that <paramref name="value"/> should be written to the console in</param>
        /// <param name="output">The <see cref="TextWriter"/> where <paramref name="value"/> will be written</param>
        /// <param name="value">The value to write</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="output"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="color"/> is not a valid <see cref="ConsoleColor"/></exception>
        /// <exception cref="IOException">Thrown if an I/O error occurred</exception>
        /// <exception cref="ObjectDisposedException">Thrown if <paramref name="output"/> is disposed</exception>
        public static void Write(ConsoleColor color, TextWriter output, string value)
        {
            Ensure.IsDefinedEnum(color, nameof(color));
            Ensure.NotNull(output, nameof(output));

            lock (ColorLock)
            {
                var oldColor = Console.ForegroundColor;
                try
                {
                    Console.ForegroundColor = color;
                    output.Write(value);
                }
                finally
                {
                    Console.ForegroundColor = oldColor;
                }
            }
        }

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to <paramref name="output"/>
        /// </summary>
        /// <param name="color">The color that <paramref name="value"/> should be written to the console in</param>
        /// <param name="output">The <see cref="TextWriter"/> where <paramref name="value"/> will be written</param>
        /// <param name="value">The value to write</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="output"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="color"/> is not a valid <see cref="ConsoleColor"/></exception>
        /// <exception cref="IOException">Thrown if an I/O error occurred</exception>
        /// <exception cref="ObjectDisposedException">Thrown if <paramref name="output"/> is disposed</exception>
        public static void WriteLine(ConsoleColor color, TextWriter output, string value)
        {
            Ensure.IsDefinedEnum(color, nameof(color));
            Ensure.NotNull(output, nameof(output));

            lock (ColorLock)
            {
                var oldColor = Console.ForegroundColor;
                try
                {
                    Console.ForegroundColor = color;
                    output.WriteLine(value);
                }
                finally
                {
                    Console.ForegroundColor = oldColor;
                }
            }
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects to the standard output stream using the specified format information and the default colorization
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="arg">An array of objects to write using <paramref name="format"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="format"/> is null</exception>
        /// <exception cref="FormatException">
        /// Thrown if <paramref name="format"/> is invalid, or the index of a format item is less than zero, or greater than or equal to the length of the <paramref name="arg"/> array
        /// </exception>
        /// <exception cref="IOException">Thrown if an I/O error occurred</exception>
        /// <remarks>If <paramref name="arg"/> is null, format will be written to the standard output stream</remarks>
        public void Write(string format, params object[] arg)
        {
            Ensure.NotNull(format, nameof(format));

            Write(this.color, Console.Out, arg == null ? format : string.Format(Console.Out.FormatProvider, format, arg));
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects, followed by the current line terminator, to the standard output stream using the specified format information and the default colorization
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="arg">An array of objects to write using <paramref name="format"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="format"/> is null</exception>
        /// <exception cref="FormatException">
        /// Thrown if <paramref name="format"/> is invalid, or the index of a format item is less than zero, or greater than or equal to the length of the <paramref name="arg"/> array
        /// </exception>
        /// <exception cref="IOException">Thrown if an I/O error occurred</exception>
        /// <remarks>If <paramref name="arg"/> is null, format will be written to the standard output stream</remarks>
        public void WriteLine(string format, params object[] arg)
        {
            Ensure.NotNull(format, nameof(format));

            WriteLine(this.color, Console.Out, arg == null ? format : string.Format(Console.Out.FormatProvider, format, arg));
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects to the standard output stream using the specified format information and the configured warning colorization
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="arg">An array of objects to write using <paramref name="format"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="format"/> is null</exception>
        /// <exception cref="FormatException">
        /// Thrown if <paramref name="format"/> is invalid, or the index of a format item is less than zero, or greater than or equal to the length of the <paramref name="arg"/> array
        /// </exception>
        /// <exception cref="IOException">Thrown if an I/O error occurred</exception>
        /// <remarks>If <paramref name="arg"/> is null, format will be written to the standard output stream</remarks>
        public void WriteWarning(string format, params object[] arg)
        {
            Ensure.NotNull(format, nameof(format));

            Write(this.warningColor, Console.Out, arg == null ? format : string.Format(Console.Out.FormatProvider, format, arg));
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects, followed by the current line terminator, to the standard output stream using the specified format information and the configured warning colorization
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="arg">An array of objects to write using <paramref name="format"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="format"/> is null</exception>
        /// <exception cref="FormatException">
        /// Thrown if <paramref name="format"/> is invalid, or the index of a format item is less than zero, or greater than or equal to the length of the <paramref name="arg"/> array
        /// </exception>
        /// <exception cref="IOException">Thrown if an I/O error occurred</exception>
        /// <remarks>If <paramref name="arg"/> is null, format will be written to the standard output stream</remarks>
        public void WriteWarningLine(string format, params object[] arg)
        {
            Ensure.NotNull(format, nameof(format));

            WriteLine(this.warningColor, Console.Out, arg == null ? format : string.Format(Console.Out.FormatProvider, format, arg));
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects to the standard error stream using the specified format information and the configured error colorization
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="arg">An array of objects to write using <paramref name="format"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="format"/> is null</exception>
        /// <exception cref="FormatException">
        /// Thrown if <paramref name="format"/> is invalid, or the index of a format item is less than zero, or greater than or equal to the length of the <paramref name="arg"/> array
        /// </exception>
        /// <exception cref="IOException">Thrown if an I/O error occurred</exception>
        /// <remarks>If <paramref name="arg"/> is null, format will be written to the standard error stream</remarks>
        public void WriteError(string format, params object[] arg)
        {
            Ensure.NotNull(format, nameof(format));

            Write(this.errorColor, Console.Error, arg == null ? format : string.Format(Console.Error.FormatProvider, format, arg));
        }

        /// <summary>
        /// Writes the text representation of the specified array of objects, followed by the current line terminator, to the standard error stream using the specified format information and the default colorization
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="arg">An array of objects to write using <paramref name="format"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="format"/> is null</exception>
        /// <exception cref="FormatException">
        /// Thrown if <paramref name="format"/> is invalid, or the index of a format item is less than zero, or greater than or equal to the length of the <paramref name="arg"/> array
        /// </exception>
        /// <exception cref="IOException">Thrown if an I/O error occurred</exception>
        /// <remarks>If <paramref name="arg"/> is null, format will be written to the standard error stream</remarks>
        public void WriteErrorLine(string format, params object[] arg)
        {
            Ensure.NotNull(format, nameof(format));

            WriteLine(this.errorColor, Console.Error, arg == null ? format : string.Format(Console.Error.FormatProvider, format, arg));
        }
    }
}
