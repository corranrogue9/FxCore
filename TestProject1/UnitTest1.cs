namespace TestProject1
{
    using System.Linq.V2;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = new GarrettGroupByable<string>(new[] { "123", "1234", "12345", "234", "2345", "23456" }.ToV2Enumerable());
            var queried = data.GroupBy(element => element.Length);
            using (var enumerator = queried.GetEnumerator())
            {
                Assert.IsTrue(enumerator.MoveNext());
                CollectionAssert.AreEqual(new[] { "123", "234" }, enumerator.Current.ToList());

                Assert.IsTrue(enumerator.MoveNext());
                CollectionAssert.AreEqual(new[] { "1234", "2345" }, enumerator.Current.ToList());

                Assert.IsTrue(enumerator.MoveNext());
                CollectionAssert.AreEqual(new[] { "12345", "23456" }, enumerator.Current.ToList());

                Assert.IsFalse(enumerator.MoveNext());
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            var data = new GarrettGroupByable<string>(new[] { "123", "1234", "12345", "234", "2345", "23456", "3456", "34567", "45678" }.ToV2Enumerable());
            var queried = data
                .GroupBy(element => element.Length)
                .Select(grouping => new KeyValuePair<int, int>(grouping.Key, grouping.Count()));
            using (var enumerator = queried.GetEnumerator())
            {
                Assert.IsTrue(enumerator.MoveNext());
                Assert.AreEqual(5, enumerator.Current.Key);
                Assert.AreEqual(4, enumerator.Current.Value);

                Assert.IsTrue(enumerator.MoveNext());
                Assert.AreEqual(4, enumerator.Current.Key);
                Assert.AreEqual(3, enumerator.Current.Value);

                Assert.IsTrue(enumerator.MoveNext());
                Assert.AreEqual(3, enumerator.Current.Key);
                Assert.AreEqual(2, enumerator.Current.Value);

                Assert.IsFalse(enumerator.MoveNext());
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            var data = new GarrettGroupByable<string>(new[] { "123", "1234", "12345", "234", "2345", "23456", "3456", "34567", "45678" }.ToV2Enumerable());
            var queried = data
                .GroupBy(element => element.Length)
                .Select(grouping => grouping.Max());
            using (var enumerator = queried.GetEnumerator())
            {
                Assert.IsTrue(enumerator.MoveNext());
                Assert.AreEqual("45678", enumerator.Current);

                Assert.IsTrue(enumerator.MoveNext());
                Assert.AreEqual("3456", enumerator.Current);

                Assert.IsTrue(enumerator.MoveNext());
                Assert.AreEqual("234", enumerator.Current);

                Assert.IsFalse(enumerator.MoveNext());
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            var data = new GarrettGroupByable<string>(new[] { "123", "1234", "12345", "234", "2345", "23456", "3456", "34567", "45678" }.ToV2Enumerable());
            var queried = data
                .GroupBy(element => element.Length)
                .Select(grouping => grouping.Max());
            using (var enumerator = queried.GetEnumerator())
            {
                Assert.IsTrue(enumerator.MoveNext());
                Assert.AreEqual("45678", enumerator.Current);

                Assert.IsTrue(enumerator.MoveNext());
                Assert.AreEqual("3456", enumerator.Current);

                Assert.IsTrue(enumerator.MoveNext());
                Assert.AreEqual("234", enumerator.Current);

                Assert.IsFalse(enumerator.MoveNext());
            }
        }
    }
}