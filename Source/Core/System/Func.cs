#if !NET35
namespace System
{
    /// <summary>
    /// Encapsulates a method that has no parameters and returns a value of type <typeparamref name="TResult"/>
    /// </summary>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates</typeparam>
    /// <returns>The return value of the method that this delegate encapsulates</returns>
    internal delegate TResult Func<out TResult>();
}
#endif
