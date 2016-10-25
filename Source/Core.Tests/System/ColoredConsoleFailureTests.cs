namespace System
{
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Failure tests for the <see cref="ColoredConsole"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class ColoredConsoleFailureTests
    {
        /// <summary>
        /// Creates a new ColoredConsole with null settings
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Creates a new ColoredConsole with null settings")]
        [TestMethod]
        public void CreateNullSettings()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentNullException>(() => new ColoredConsole(null));
        }

        /// <summary>
        /// Writes to the console with a bad color
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a bad color")]
        [TestMethod]
        public void WriteBadColor()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => ColoredConsole.Write((ConsoleColor)16, Console.Out, "message"));
        }

        /// <summary>
        /// Writes to the console with a null TextWriter
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a null TextWriter")]
        [TestMethod]
        public void WriteNullWriter()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentNullException>(() => ColoredConsole.Write(ConsoleColor.Black, null, "message"));
        }

        /// <summary>
        /// Writes to the console with a disposed TextWriter
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a disposed TextWriter")]
        [TestMethod]
        public void WriteDisposedWriter()
        {
            NativeMethods.AllocConsole();

            var writer = new StringWriter();
            writer.Dispose();
            ExceptionAssert.Throws<ObjectDisposedException>(() => ColoredConsole.Write(ConsoleColor.Black, writer, "message"));
        }

        /// <summary>
        /// Writes to the console with a bad color
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a bad color")]
        [TestMethod]
        public void WriteLineBadColor()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => ColoredConsole.WriteLine((ConsoleColor)16, Console.Out, "message"));
        }

        /// <summary>
        /// Writes to the console with a null TextWriter
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a null TextWriter")]
        [TestMethod]
        public void WriteLineNullWriter()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentNullException>(() => ColoredConsole.WriteLine(ConsoleColor.Black, null, "message"));
        }

        /// <summary>
        /// Writes to the console with a disposed TextWriter
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a disposed TextWriter")]
        [TestMethod]
        public void WriteLineDisposedWriter()
        {
            NativeMethods.AllocConsole();

            var writer = new StringWriter();
            writer.Dispose();
            ExceptionAssert.Throws<ObjectDisposedException>(() => ColoredConsole.WriteLine(ConsoleColor.Black, writer, "message"));
        }

        /// <summary>
        /// Writes to the console with a null message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a null message format")]
        [TestMethod]
        public void WriteNullFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentNullException>(() => ColoredConsole.Default.Write(null));
        }

        /// <summary>
        /// Writes to the console with an invalid message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with an invalid message format")]
        [TestMethod]
        public void WriteInvalidFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.Write("this is a {{0} format"));
        }

        /// <summary>
        /// Writes to the console with a bad message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a bad message format")]
        [TestMethod]
        public void WriteBadFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.Write("this is a {1} format", "bad"));
        }

        /// <summary>
        /// Writes to the console with a null message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a null message format")]
        [TestMethod]
        public void WriteLineNullFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentNullException>(() => ColoredConsole.Default.WriteLine(null));
        }

        /// <summary>
        /// Writes to the console with an invalid message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with an invalid message format")]
        [TestMethod]
        public void WriteLineInvalidFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteLine("this is a {{0} format"));
        }

        /// <summary>
        /// Writes to the console with a bad message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a bad message format")]
        [TestMethod]
        public void WriteLineBadFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteLine("this is a {1} format", "bad"));
        }

        /// <summary>
        /// Writes to the console with a null message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a null message format")]
        [TestMethod]
        public void WriteWarningNullFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentNullException>(() => ColoredConsole.Default.WriteWarning(null));
        }

        /// <summary>
        /// Writes to the console with an invalid message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with an invalid message format")]
        [TestMethod]
        public void WriteWarningInvalidFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteWarning("this is a {{0} format"));
        }

        /// <summary>
        /// Writes to the console with a bad message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a bad message format")]
        [TestMethod]
        public void WriteWarningBadFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteWarning("this is a {1} format", "bad"));
        }

        /// <summary>
        /// Writes to the console with a null message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a null message format")]
        [TestMethod]
        public void WriteWarningLineNullFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentNullException>(() => ColoredConsole.Default.WriteWarningLine(null));
        }

        /// <summary>
        /// Writes to the console with an invalid message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with an invalid message format")]
        [TestMethod]
        public void WriteWarningLineInvalidFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteWarningLine("this is a {{0} format"));
        }

        /// <summary>
        /// Writes to the console with a bad message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a bad message format")]
        [TestMethod]
        public void WriteWarningLineBadFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteWarningLine("this is a {1} format", "bad"));
        }

        /// <summary>
        /// Writes to the console with a null message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a null message format")]
        [TestMethod]
        public void WriteErrorNullFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentNullException>(() => ColoredConsole.Default.WriteError(null));
        }

        /// <summary>
        /// Writes to the console with an invalid message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with an invalid message format")]
        [TestMethod]
        public void WriteErrorInvalidFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteError("this is a {{0} format"));
        }

        /// <summary>
        /// Writes to the console with a bad message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a bad message format")]
        [TestMethod]
        public void WriteErrorBadFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteError("this is a {1} format", "bad"));
        }

        /// <summary>
        /// Writes to the console with a null message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a null message format")]
        [TestMethod]
        public void WriteErrorLineNullFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<ArgumentNullException>(() => ColoredConsole.Default.WriteErrorLine(null));
        }

        /// <summary>
        /// Writes to the console with an invalid message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with an invalid message format")]
        [TestMethod]
        public void WriteErrorLineInvalidFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteErrorLine("this is a {{0} format"));
        }

        /// <summary>
        /// Writes to the console with a bad message format
        /// </summary>
        [TestCategory("Failure")]
        [Priority(2)]
        [Description("Writes to the console with a bad message format")]
        [TestMethod]
        public void WriteErrorLineBadFormat()
        {
            NativeMethods.AllocConsole();

            ExceptionAssert.Throws<FormatException>(() => ColoredConsole.Default.WriteErrorLine("this is a {1} format", "bad"));
        }
        
        /// <summary>
        /// Unmanaged methods that are used for interacting with console windows
        /// </summary>
        private static class NativeMethods
        {
#if !NET40
            // this message is a bug in pre-.NET 4.0 versions
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA5122:PInvokesShouldNotBeSafeCriticalFxCopRule")]
#endif
            [DllImport("kernel32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool AllocConsole();
        }
    }
}
