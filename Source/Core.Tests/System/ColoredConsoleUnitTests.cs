#if NET40
namespace System
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="ColoredConsole"/>
    /// </summary>
    /// <threadsafety static="true" instance="false">
    /// Instances of this type are thread safe if no other concurrent types leverage <see cref="Console.SetOut(IO.TextWriter)"/> and <see cref="Console.SetError(IO.TextWriter)"/>
    /// </threadsafety>
    [TestClass]
    public sealed class ColoredConsoleUnitTests
    {
        /// <summary>
        /// The <see cref="object"/> that we will lock on to ensure each test is synchronous
        /// </summary>
        private static readonly object TestLock = new object();

        /// <summary>
        /// Writes messages to the console and ensure the correct message and color
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Writes messages to the console and ensure the correct message and color")]
        [TestMethod]
        public void Write()
        {
            NativeMethods.AllocConsole();
            lock (TestLock)
            {
                using (var standardOut = new InstrumentedTextWriter())
                using (var standardError = new InstrumentedTextWriter())
                {
                    Console.SetOut(standardOut);
                    Console.SetError(standardError);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    var consoleSettings = new ColoredConsoleSettings.Builder()
                    {
                        Color = ConsoleColor.Blue,
                        ErrorColor = ConsoleColor.Cyan,
                        WarningColor = ConsoleColor.DarkBlue,
                    }.Build();
                    var console = new ColoredConsole(consoleSettings);

                    console.Write("writing some text to the console");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.Write("writing {0} text to the console", "other");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.Write("writing {0} text to the console", null);
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    ColoredConsole.Write(ConsoleColor.DarkGray, Console.Out, "writing some text to the console");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);

                    Assert.IsFalse(standardError.Messages.Any());

                    Assert.AreEqual("writing some text to the console", standardOut.Messages.ElementAt(0).Message);
                    Assert.AreEqual(ConsoleColor.Blue, standardOut.Messages.ElementAt(0).Color);
                    Assert.AreEqual("writing other text to the console", standardOut.Messages.ElementAt(1).Message);
                    Assert.AreEqual(ConsoleColor.Blue, standardOut.Messages.ElementAt(1).Color);
                    Assert.AreEqual("writing {0} text to the console", standardOut.Messages.ElementAt(2).Message);
                    Assert.AreEqual(ConsoleColor.Blue, standardOut.Messages.ElementAt(2).Color);
                    Assert.AreEqual("writing some text to the console", standardOut.Messages.ElementAt(3).Message);
                    Assert.AreEqual(ConsoleColor.DarkGray, standardOut.Messages.ElementAt(3).Color);
                }
            }
        }

        /// <summary>
        /// Writes messages to the console and ensure the correct message and color
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Writes messages to the console and ensure the correct message and color")]
        [TestMethod]
        public void WriteLine()
        {
            NativeMethods.AllocConsole();
            lock (TestLock)
            {
                using (var standardOut = new InstrumentedTextWriter())
                using (var standardError = new InstrumentedTextWriter())
                {
                    Console.SetOut(standardOut);
                    Console.SetError(standardError);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    var consoleSettings = new ColoredConsoleSettings.Builder()
                    {
                        Color = ConsoleColor.Blue,
                        ErrorColor = ConsoleColor.Cyan,
                        WarningColor = ConsoleColor.DarkBlue,
                    }.Build();
                    var console = new ColoredConsole(consoleSettings);

                    console.WriteLine("writing some text to the console");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteLine("writing {0} text to the console", "other");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteLine("writing {0} text to the console", null);
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    ColoredConsole.WriteLine(ConsoleColor.DarkGray, Console.Out, "writing some text to the console");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);

                    Assert.IsFalse(standardError.Messages.Any());

                    Assert.AreEqual("writing some text to the console", standardOut.Messages.ElementAt(0).Message);
                    Assert.AreEqual(ConsoleColor.Blue, standardOut.Messages.ElementAt(0).Color);
                    Assert.AreEqual("writing other text to the console", standardOut.Messages.ElementAt(1).Message);
                    Assert.AreEqual(ConsoleColor.Blue, standardOut.Messages.ElementAt(1).Color);
                    Assert.AreEqual("writing {0} text to the console", standardOut.Messages.ElementAt(2).Message);
                    Assert.AreEqual(ConsoleColor.Blue, standardOut.Messages.ElementAt(2).Color);
                    Assert.AreEqual("writing some text to the console", standardOut.Messages.ElementAt(3).Message);
                    Assert.AreEqual(ConsoleColor.DarkGray, standardOut.Messages.ElementAt(3).Color);
                }
            }
        }

        /// <summary>
        /// Writes messages to the console and ensure the correct message and color
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Writes messages to the console and ensure the correct message and color")]
        [TestMethod]
        public void WriteWarning()
        {
            NativeMethods.AllocConsole();
            lock (TestLock)
            {
                using (var standardOut = new InstrumentedTextWriter())
                using (var standardError = new InstrumentedTextWriter())
                {
                    Console.SetOut(standardOut);
                    Console.SetError(standardError);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    var consoleSettings = new ColoredConsoleSettings.Builder()
                    {
                        Color = ConsoleColor.Blue,
                        ErrorColor = ConsoleColor.Cyan,
                        WarningColor = ConsoleColor.DarkBlue,
                    }.Build();
                    var console = new ColoredConsole(consoleSettings);

                    console.WriteWarning("writing some text to the console");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteWarning("writing {0} text to the console", "other");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteWarning("writing {0} text to the console", null);
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);

                    Assert.IsFalse(standardError.Messages.Any());

                    Assert.AreEqual("writing some text to the console", standardOut.Messages.ElementAt(0).Message);
                    Assert.AreEqual(ConsoleColor.DarkBlue, standardOut.Messages.ElementAt(0).Color);
                    Assert.AreEqual("writing other text to the console", standardOut.Messages.ElementAt(1).Message);
                    Assert.AreEqual(ConsoleColor.DarkBlue, standardOut.Messages.ElementAt(1).Color);
                    Assert.AreEqual("writing {0} text to the console", standardOut.Messages.ElementAt(2).Message);
                    Assert.AreEqual(ConsoleColor.DarkBlue, standardOut.Messages.ElementAt(2).Color);
                }
            }
        }

        /// <summary>
        /// Writes messages to the console and ensure the correct message and color
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Writes messages to the console and ensure the correct message and color")]
        [TestMethod]
        public void WriteWarningLine()
        {
            NativeMethods.AllocConsole();
            lock (TestLock)
            {
                using (var standardOut = new InstrumentedTextWriter())
                using (var standardError = new InstrumentedTextWriter())
                {
                    Console.SetOut(standardOut);
                    Console.SetError(standardError);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    var consoleSettings = new ColoredConsoleSettings.Builder()
                    {
                        Color = ConsoleColor.Blue,
                        ErrorColor = ConsoleColor.Cyan,
                        WarningColor = ConsoleColor.DarkBlue,
                    }.Build();
                    var console = new ColoredConsole(consoleSettings);

                    console.WriteWarningLine("writing some text to the console");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteWarningLine("writing {0} text to the console", "other");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteWarningLine("writing {0} text to the console", null);
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);

                    Assert.IsFalse(standardError.Messages.Any());

                    Assert.AreEqual("writing some text to the console", standardOut.Messages.ElementAt(0).Message);
                    Assert.AreEqual(ConsoleColor.DarkBlue, standardOut.Messages.ElementAt(0).Color);
                    Assert.AreEqual("writing other text to the console", standardOut.Messages.ElementAt(1).Message);
                    Assert.AreEqual(ConsoleColor.DarkBlue, standardOut.Messages.ElementAt(1).Color);
                    Assert.AreEqual("writing {0} text to the console", standardOut.Messages.ElementAt(2).Message);
                    Assert.AreEqual(ConsoleColor.DarkBlue, standardOut.Messages.ElementAt(2).Color);
                }
            }
        }

        /// <summary>
        /// Writes messages to the console and ensure the correct message and color
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Writes messages to the console and ensure the correct message and color")]
        [TestMethod]
        public void WriteError()
        {
            NativeMethods.AllocConsole();
            lock (TestLock)
            {
                using (var standardOut = new InstrumentedTextWriter())
                using (var standardError = new InstrumentedTextWriter())
                {
                    Console.SetOut(standardOut);
                    Console.SetError(standardError);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    var consoleSettings = new ColoredConsoleSettings.Builder()
                    {
                        Color = ConsoleColor.Blue,
                        ErrorColor = ConsoleColor.Cyan,
                        WarningColor = ConsoleColor.DarkBlue,
                    }.Build();
                    var console = new ColoredConsole(consoleSettings);

                    console.WriteError("writing some text to the console");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteError("writing {0} text to the console", "other");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteError("writing {0} text to the console", null);
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);

                    Assert.IsFalse(standardOut.Messages.Any());

                    Assert.AreEqual("writing some text to the console", standardError.Messages.ElementAt(0).Message);
                    Assert.AreEqual(ConsoleColor.Cyan, standardError.Messages.ElementAt(0).Color);
                    Assert.AreEqual("writing other text to the console", standardError.Messages.ElementAt(1).Message);
                    Assert.AreEqual(ConsoleColor.Cyan, standardError.Messages.ElementAt(1).Color);
                    Assert.AreEqual("writing {0} text to the console", standardError.Messages.ElementAt(2).Message);
                    Assert.AreEqual(ConsoleColor.Cyan, standardError.Messages.ElementAt(2).Color);
                }
            }
        }

        /// <summary>
        /// Writes messages to the console and ensure the correct message and color
        /// </summary>
        [TestCategory("Unit")]
        [Priority(2)]
        [Description("Writes messages to the console and ensure the correct message and color")]
        [TestMethod]
        public void WriteErrorLine()
        {
            NativeMethods.AllocConsole();
            lock (TestLock)
            {
                using (var standardOut = new InstrumentedTextWriter())
                using (var standardError = new InstrumentedTextWriter())
                {
                    Console.SetOut(standardOut);
                    Console.SetError(standardError);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    var consoleSettings = new ColoredConsoleSettings.Builder()
                    {
                        Color = ConsoleColor.Blue,
                        ErrorColor = ConsoleColor.Cyan,
                        WarningColor = ConsoleColor.DarkBlue,
                    }.Build();
                    var console = new ColoredConsole(consoleSettings);

                    console.WriteErrorLine("writing some text to the console");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteErrorLine("writing {0} text to the console", "other");
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);
                    console.WriteErrorLine("writing {0} text to the console", null);
                    Assert.AreEqual(ConsoleColor.DarkCyan, Console.ForegroundColor);

                    Assert.IsFalse(standardOut.Messages.Any());

                    Assert.AreEqual("writing some text to the console", standardError.Messages.ElementAt(0).Message);
                    Assert.AreEqual(ConsoleColor.Cyan, standardError.Messages.ElementAt(0).Color);
                    Assert.AreEqual("writing other text to the console", standardError.Messages.ElementAt(1).Message);
                    Assert.AreEqual(ConsoleColor.Cyan, standardError.Messages.ElementAt(1).Color);
                    Assert.AreEqual("writing {0} text to the console", standardError.Messages.ElementAt(2).Message);
                    Assert.AreEqual(ConsoleColor.Cyan, standardError.Messages.ElementAt(2).Color);
                }
            }
        }

        /// <summary>
        /// Unmanaged methods that are used for interacting with console windows
        /// </summary>
        private static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool AllocConsole();
        }
        
        /// <summary>
        /// A <see cref="TextWriter"/> implementation that keeps a record of the color on the console when values are written to it
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private sealed class InstrumentedTextWriter : TextWriter
        {
            /// <summary>
            /// The <see cref="ConsoleMessage"/>s that have been written to this <see cref="TextWriter"/>
            /// </summary>
            private readonly ConcurrentQueue<ConsoleMessage> messages;

            /// <summary>
            /// Initializes a new instance of the <see cref="InstrumentedTextWriter"/> class
            /// </summary>
            public InstrumentedTextWriter()
                : base()
            {
                this.messages = new ConcurrentQueue<ConsoleMessage>();
            }

            /// <summary>
            /// Gets the <see cref="ConsoleMessage"/>s that have been written to this <see cref="TextWriter"/>
            /// </summary>
            public IEnumerable<ConsoleMessage> Messages
            {
                get
                {
                    foreach (var message in this.messages)
                    {
                        yield return message;
                    }
                }
            }

            /// <summary>
            /// Gets that character encoding in which the output is written
            /// </summary>
            public override Encoding Encoding
            {
                get
                {
                    return Encoding.ASCII;
                }
            }

            /// <summary>
            /// Writes a string to the stream
            /// </summary>
            /// <param name="value">The string to write</param>
            public override void Write(string value)
            {
                this.messages.Enqueue(new ConsoleMessage(value, Console.ForegroundColor));
            }

            /// <summary>
            /// Writes a string to the stream
            /// </summary>
            /// <param name="value">The string to write</param>
            public override void WriteLine(string value)
            {
                this.Write(value);
            }
        }

        /// <summary>
        /// A message that has been emitted to the console
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private sealed class ConsoleMessage
        {
            /// <summary>
            /// The message that was written to the console
            /// </summary>
            private readonly string message;

            /// <summary>
            /// The color that the message was written in
            /// </summary>
            private readonly ConsoleColor color;

            /// <summary>
            /// Initializes a new instance of the <see cref="ConsoleMessage"/> class
            /// </summary>
            /// <param name="message">The message that was written to the console</param>
            /// <param name="color">The color that the message was written in</param>
            public ConsoleMessage(string message, ConsoleColor color)
            {
                this.message = message;
                this.color = color;
            }

            /// <summary>
            /// Gets the message that was written to the console
            /// </summary>
            public string Message
            {
                get
                {
                    return this.message;
                }
            }

            /// <summary>
            /// Gets the color that the message was written in
            /// </summary>
            public ConsoleColor Color
            {
                get
                {
                    return this.color;
                }
            }
        }
    }
}
#endif