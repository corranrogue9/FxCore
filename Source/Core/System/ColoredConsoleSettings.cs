namespace System
{
    using Fx;

    /// <summary>
    /// The settings used to instantiate a <see cref="ColoredConsole"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class ColoredConsoleSettings
    {
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
        /// Initializes a new instance of the <see cref="ColoredConsoleSettings"/> class
        /// </summary>
        /// <param name="color">The default color to use when emitting strings to the console</param>
        /// <param name="warningColor">The color to use when emitting warnings to the console</param>
        /// <param name="errorColor">The color to use when emitting errors to the console</param>
        private ColoredConsoleSettings(ConsoleColor color, ConsoleColor warningColor, ConsoleColor errorColor)
        {
            this.color = color;
            this.warningColor = warningColor;
            this.errorColor = errorColor;
        }

        /// <summary>
        /// Gets the default color to use when emitting strings to the console
        /// </summary>
        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }
        }

        /// <summary>
        /// Gets the color to use when emitting warnings to the console
        /// </summary>
        public ConsoleColor WarningColor
        {
            get
            {
                return this.warningColor;
            }
        }

        /// <summary>
        /// Gets the color to use when emitting errors to the console
        /// </summary>
        public ConsoleColor ErrorColor
        {
            get
            {
                return this.errorColor;
            }
        }

        /// <summary>
        /// A builder for <see cref="ColoredConsoleSettings"/>
        /// </summary>
        /// <threadsafety static="true" instance="false"/>
        public sealed class Builder
        {
            /// <summary>
            /// Gets or sets the default color to use when emitting strings to the console
            /// </summary>
            public ConsoleColor Color { get; set; } = ConsoleColor.Gray;

            /// <summary>
            /// Gets or sets the color to use when emitting warnings to the console
            /// </summary>
            public ConsoleColor WarningColor { get; set; } = ConsoleColor.Yellow;

            /// <summary>
            /// Gets or sets the color to use when emitting errors to the console
            /// </summary>
            public ConsoleColor ErrorColor { get; set; } = ConsoleColor.Red;

            /// <summary>
            /// Creates a new instance of <see cref="ColoredConsoleSettings"/> based on the configured properties
            /// </summary>
            /// <returns>A new instance of <see cref="ColoredConsoleSettings"/> based on the configured properties</returns>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <see cref="Color"/> or <see cref="WarningColor"/> or <see cref="ErrorColor"/> is not a valid <see cref="ConsoleColor"/>
            /// </exception>
            public ColoredConsoleSettings Build()
            {
                Ensure.IsDefinedEnum(this.Color, nameof(this.Color));
                Ensure.IsDefinedEnum(this.WarningColor, nameof(this.WarningColor));
                Ensure.IsDefinedEnum(this.ErrorColor, nameof(this.ErrorColor));

                return new ColoredConsoleSettings(this.Color, this.WarningColor, this.ErrorColor);
            }
        }
    }
}
