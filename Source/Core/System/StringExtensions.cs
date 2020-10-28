namespace System
{
  using Fx;

  /// <summary>
  /// extension methods for <see cref="string"/>
  /// </summary>
  public static class StringExtensions
  {
    /// <summary>
    /// Determines if <paramref name="source"/> contains <paramref name="value"/> as a substring
    /// </summary>
    /// <param name="source">The string to look for <paramref name="value"/> within</param>
    /// <param name="value"Tthe string to look for within <paramref name="source"/></param>
    /// <param name="comparison">How to compare the characters in <paramref name="value"/> with the characters in <paramref name="source"/></param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="value"/> is a substring of <paramref name="source"/>, or if <paramref name="value"/> is the empty string; <see langword="false"/> otherwise
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> or <paramref name="value"/> is <see langword="null"/></exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="comparison"/> is not a valid <see cref="StringComparison"/></exception>
    public static bool Contains(this string source, string value, StringComparison comparison)
    {
      Ensure.NotNull(source, nameof(source));
      Ensure.NotNull(value, nameof(value));
      Ensure.IsDefinedEnum(comparison, nameof(comparison));
      
      return source.IndexOf(value, comparison) >= 0;
    }
  }
}
