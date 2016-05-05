namespace Fx
{
    using System;
    using System.Collections.Generic;
#if NET45
    using System.Runtime.CompilerServices;
#endif

    /// <summary>
    /// Provides utilities for validating the preconditions of arguments prior to their use
    /// </summary>
    /// <remarks>
    /// <para>This class can be used to validate arguments in an "inline" fashion, meaning that the value being validated is either returned from the method, or an 
    /// exception is thrown indicating in what way the value is invalid. </para>
    /// <para>This allows for doing validations where a derived class might obtain an object during construction, and a property of that object is needed to construct 
    /// the base class. The original object should be validated before accessing its property, but you must construct the base class before the derived class's 
    /// constructor can invoke any validation code. For example, say that Bar is a base class:</para>
    /// <code>
    /// public sealed class Bar
    /// {
    ///     ...
    /// 
    ///     public Bar(string name)
    ///     {
    ///         Name = name;
    ///         ...
    ///     }
    ///     
    ///     ...
    ///     
    ///     public string Name { get; set; }
    ///     
    ///     ...
    /// }
    /// </code>
    /// <para>Now say that you also have a derived class Foo which would take in some Settings in order to be fully initialized:</para>
    /// <code>
    /// public sealed class Settings
    /// {
    ///     ...
    ///     
    ///     public string Name { get; set; }
    ///     
    ///     ...
    /// }
    /// 
    /// public sealed class Foo : Bar
    /// {
    ///     ...
    ///     
    ///     public Foo(Settings settings)
    ///         : base(settings.Name)
    ///     {
    ///         ...
    ///     }
    ///     
    ///     ...
    /// }
    /// </code>
    /// <para>In this case, we have used data in the constructor before we have validated it, which may cause, for example, a NullReferenceException. In order to throw 
    /// a proper exception in the event that data is null, we could write instead:</para>
    /// <code>
    /// public sealed class Foo : Bar
    /// {
    ///     ...
    ///     
    ///     public Foo(Settings settings)
    ///         : base(EnsureInline.NotNull(settings, "settings").Name)
    ///     {
    ///         ...
    ///     }
    ///     
    ///     ...
    /// }
    /// </code>
    /// <para>Thus, we have validated data before we have used it, and we have derived from bar, and we were able to take in as a constructor parameter our own custom 
    /// data type containing all of the information needed to create a new Foo. </para>
    /// <para>Please note that there is a non-trivial cost to using these <see cref="EnsureInline"/> methods over using the <see cref="Ensure"/> methods, particularly 
    /// when the input parameter is a value-type, even if the return value is never used. Therefore, these methods should be used only in cases where the argument value
    /// is immediately required for use and must be validated before its use. These methods are not intended to supersede the <see cref="Ensure"/> methods. </para>
    /// </remarks>
    /// <threadsafety static="true"/>
    public static class EnsureInline
    {
        /// <summary>
        /// Ensures that <paramref name="value"/> is not null
        /// </summary>
        /// <typeparam name="T">The type of the value being validated</typeparam>
        /// <param name="value">The value to ensure is not null</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static T NotNull<T>([ValidatedNotNull] T value, string name)
        {
            Ensure.NotNull(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not null and is not <see cref="string.Empty"/>
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is not null and is not <see cref="string.Empty"/></param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is <see cref="string.Empty"/></exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static string NotNullOrEmptyString(string value, string name)
        {
            Ensure.NotNullOrEmptyString(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not null and contains at least one element
        /// </summary>
        /// <typeparam name="TEnumerable">The type of the <see cref="IEnumerable{T}"/> being validated</typeparam>
        /// <typeparam name="TElement">The type of the values in the <see cref="IEnumerable{T}"/> being validated</typeparam>
        /// <param name="value">The <see cref="IEnumerable{T}"/> to ensure is not null or and contains at least one element</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> contains no elements</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static TEnumerable EnumerableNotEmpty<TEnumerable, TElement>(TEnumerable value, string name) where TEnumerable : IEnumerable<TElement>
        {
            Ensure.EnumerableNotEmpty(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="byte"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static byte IsPositive(byte value, string name)
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not a negative value
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> to ensure is not a negative value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static sbyte NotNegative(sbyte value, string name)
#pragma warning restore CS3002 // Return type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            Ensure.NotNegative(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static sbyte IsPositive(sbyte value, string name)
#pragma warning restore CS3002 // Return type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not a negative value
        /// </summary>
        /// <param name="value">The <see cref="short"/> to ensure is not a negative value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static short NotNegative(short value, string name)
        {
            Ensure.NotNegative(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="short"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static short IsPositive(short value, string name)
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static ushort IsPositive(ushort value, string name)
#pragma warning restore CS3002 // Return type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not a negative value
        /// </summary>
        /// <param name="value">The <see cref="int"/> to ensure is not a negative value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static int NotNegative(int value, string name)
        {
            Ensure.NotNegative(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="int"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static int IsPositive(int value, string name)
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="uint"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static uint IsPositive(uint value, string name)
#pragma warning restore CS3002 // Return type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is not a negative value
        /// </summary>
        /// <param name="value">The <see cref="long"/> to ensure is not a negative value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static long NotNegative(long value, string name)
        {
            Ensure.NotNegative(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="long"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static long IsPositive(long value, string name)
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
#pragma warning disable CS3001 // Argument type is not CLS-compliant
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public static ulong IsPositive(ulong value, string name)
#pragma warning restore CS3002 // Return type is not CLS-compliant
#pragma warning restore CS3001 // Argument type is not CLS-compliant
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static decimal NotNegative(decimal value, string name)
        {
            Ensure.NotNegative(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static decimal IsPositive(decimal value, string name)
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="double"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static double NotNegative(double value, string name)
        {
            Ensure.NotNegative(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="double"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static double IsPositive(double value, string name)
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="float"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static float NotNegative(float value, string name)
        {
            Ensure.NotNegative(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a positive value
        /// </summary>
        /// <param name="value">The <see cref="float"/> to ensure is a positive value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not positive</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static float IsPositive(float value, string name)
        {
            Ensure.IsPositive(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid enumeration
        /// </summary>
        /// <param name="value">The enumeration value to ensure is a valid value</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is not a valid value</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static Enum IsDefinedEnum(Enum value, string name)
        {
            Ensure.IsDefinedEnum(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that the type of <paramref name="value"/> is at least as derived as <paramref name="parent"/>
        /// </summary>
        /// <typeparam name="T">The type of the value that is ensured to be at least as derived as <paramref name="parent"/></typeparam>
        /// <param name="parent">the type to ensure that <paramref name="value"/>'s type is at least as derived as</param>
        /// <param name="value">The value of the type to ensure is at least as derived as <paramref name="parent"/></param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null or <paramref name="parent"/> is null</exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the type of <paramref name="value"/> is not at least as derived as <paramref name="parent"/>
        /// </exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static T IsInstance<T>(Type parent, T value, string name)
        {
            Ensure.IsInstance(parent, value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid MAC address
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is a valid MAC address</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a valid MAC address</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static string IsValidMacAddress(string value, string name)
        {
            Ensure.IsValidMacAddress(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid SHA1
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is a valid SHA1</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a valid SHA1</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static string IsValidSha1(string value, string name)
        {
            Ensure.IsValidSha1(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid SHA2
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is a valid SHA2</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a valid SHA1</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static string IsValidSha2(string value, string name)
        {
            Ensure.IsValidSha2(value, name);

            return value;
        }

        /// <summary>
        /// Ensures that <paramref name="value"/> is a valid SHA1 or SHA2
        /// </summary>
        /// <param name="value">The <see cref="string"/> to ensure is a valid SHA1 or SHA2</param>
        /// <param name="name">The name of the parameter whose provided argument was <paramref name="value"/></param>
        /// <returns><paramref name="value"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not a valid SHA1 and not a valid SHA2</exception>
#if NET45
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static string IsValidSha1OrSha2(string value, string name)
        {
            Ensure.IsValidSha1OrSha2(value, name);

            return value;
        }
    }
}
