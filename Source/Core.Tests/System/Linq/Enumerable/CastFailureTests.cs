namespace System.Linq
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public interface IHttpClient
    {
        string SendRequest(string method, string url, string headers, string body);
    }

    public static class HttpClientExtensions
    {
        public static string SendRequest(this IHttpClient httpClient, string url, string payload)
        {
            var splitUrl = url.Split(' ');
            var splitPayload = payload.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return httpClient.SendRequest(splitUrl[0], splitUrl[1], splitPayload[0], splitPayload[1]);
        }
    }

    public sealed class EpmService<T> : IHttpClient
    {
        private readonly IQueryable<T> queryable;

        private readonly Uri rootUri;

        public EpmService(IQueryable<T> queryable, Uri rootUri)
        {
            if (queryable == null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (rootUri == null)
            {
                throw new ArgumentNullException(nameof(rootUri));
            }

            this.queryable = queryable;
            this.rootUri = rootUri;
        }

        public string SendRequest(string method, string url, string headers, string body)
        {
            if (string.Equals(method, "get", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Only GET requests are supported");
            }

            if (!url.StartsWith(this.rootUri.ToString()))
            {
                throw new Exception($"Only requests to {this.rootUri.ToString()} are supported");
            }

            
        }
    }

    /// <summary>
    /// Failure tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableFailureTests
    {
        /// <summary>
        /// Casts a null sequence
        /// </summary>
        [TestCategory("Failure")]
        [Description("Casts a null sequence")]
        [Priority(1)]
        [TestMethod]
        public void CastNull()
        {
            List<string> list = null;
            ExceptionAssert.Throws<ArgumentNullException>(() => list.Cast<string>());
        }
        
        /// <summary>
        /// Casts a sequence from base types to derived types
        /// </summary>
        [TestCategory("Failure")]
        [Description("Casts a sequence from base types to derived types")]
        [Priority(1)]
        [TestMethod]
        public void CastBaseToDerived()
        {
            var list = new List<Base>();
            list.Add(new Base());
            ExceptionAssert.Throws<InvalidCastException>(() => list.Cast<Derived>().Any());
        }

        /// <summary>
        /// A derived class
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private class Derived : Base
        {
        }

        /// <summary>
        /// A base class
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        private class Base
        {
        }
    }
}
