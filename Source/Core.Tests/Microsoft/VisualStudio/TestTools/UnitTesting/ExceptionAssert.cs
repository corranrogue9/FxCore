namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    using System;

    using Fx;

    /// <summary>
    /// Utilities for asserting when exceptions are thrown and what kind of exceptions are beings thrown
    /// </summary>
    /// <threadsafety static="true"/>
    internal static class ExceptionAssert
    {
        /// <summary>
        /// Asserts that <paramref name="action"/> throws a <see cref="Exception"/> of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Exception"/> that <paramref name="action"/> is being expected to throw</typeparam>
        /// <param name="action">The <see cref="Action"/> that is expected to throw an exception of type <typeparamref name="T"/></param>
        /// <returns>The exception that was thrown by <paramref name="action"/></returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="action"/> is null</exception>
        /// <exception cref="AssertFailedException">Thrown if <paramref name="action"/> does not thrown a <see cref="Exception"/> of type <typeparamref name="T"/></exception>
        public static T Throws<T>(Action action) where T : Exception
        {
            return Throws<T>(action, string.Empty);
        }

        /// <summary>
        /// Asserts that <paramref name="action"/> throws a <see cref="Exception"/> of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Exception"/> that <paramref name="action"/> is being expected to throw</typeparam>
        /// <param name="action">The <see cref="Action"/> that is expected to throw an exception of type <typeparamref name="T"/></param>
        /// <param name="message">
        /// The message that should be included in the <see cref="AssertFailedException"/> message in the event that <paramref name="action"/> does not thrown a 
        /// <see cref="Exception"/> of type <typeparamref name="T"/>
        /// </param>
        /// <returns>The exception that was thrown by <paramref name="action"/></returns>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="action"/> is null</exception>
        /// <exception cref="AssertFailedException">Thrown if <paramref name="action"/> does not thrown a <see cref="Exception"/> of type <typeparamref name="T"/></exception>
        public static T Throws<T>(Action action, string message) where T : Exception
        {
            Ensure.NotNull(action, nameof(action));

            Exception exception = null;
            try
            {
                action();
            }
            catch (Exception e)
            {
                exception = e;
            }

            var expectedType = typeof(T);
            if (exception == null)
            {
                throw new AssertFailedException(string.Format(TestStrings.ExceptionAssertThrows, expectedType.ToString(), "null", message));
            }

            var actualType = exception.GetType();
            if (expectedType != actualType)
            {
                throw new AssertFailedException(string.Format(TestStrings.ExceptionAssertThrows, expectedType.ToString(), actualType.ToString(), message));
            }

            return exception as T;
        }
    }
}
