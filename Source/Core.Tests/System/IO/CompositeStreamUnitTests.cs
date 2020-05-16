namespace System.IO
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="CompositeStream"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public sealed class CompositeStreamUnitTests
    {
        [TestMethod]
        public void Read()
        {
            using (var stream1 = new MemoryStream(Enumerable.Range(0, 128).Select(val => (byte)val).ToArray()))
            using (var stream2 = new MemoryStream(Enumerable.Range(1, 127).Select(val => (byte)val).ToArray()))
            {
                using (var compositeStream = new CompositeStream(new[] { stream1, stream2 }))
                {
                    var buffer = new byte[100];
                    Assert.AreEqual(100, compositeStream.Read(buffer, 0, buffer.Length));
                    CollectionAssert.AreEqual(Enumerable.Range(0, 100).Select(val => (byte)val).ToArray(), buffer);

                    Assert.AreEqual(28, compositeStream.Read(buffer, 0, buffer.Length));
                    CollectionAssert.AreEqual(Enumerable.Range(100, 28).Select(val => (byte)val).ToArray(), buffer.Take(28).ToArray());

                    Assert.AreEqual(100, compositeStream.Read(buffer, 0, buffer.Length));
                    CollectionAssert.AreEqual(Enumerable.Range(1, 100).Select(val => (byte)val).ToArray(), buffer);

                    Assert.AreEqual(27, compositeStream.Read(buffer, 0, buffer.Length));
                    CollectionAssert.AreEqual(Enumerable.Range(101, 27).Select(val => (byte)val).ToArray(), buffer.Take(27).ToArray());

                    Assert.AreEqual(0, compositeStream.Read(buffer, 0, buffer.Length));
                }
            }
        }

        [TestMethod]
        public void EmptySequence()
        {
            using (var compositeStream = new CompositeStream(Enumerable.Empty<Stream>()))
            {
                var buffer = new byte[100];
                Assert.AreEqual(0, compositeStream.Read(buffer, 0, buffer.Length));
            }
        }
    }
}
