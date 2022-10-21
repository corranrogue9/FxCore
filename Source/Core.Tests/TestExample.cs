namespace TestProject1
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <threadsafety instance="true"/>
    public interface IDataStore<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns>the id</returns>
        string Create(T newValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DataNotFoundException"></exception>
        void Delete(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        /// <exception cref="DataNotFoundException"></exception>
        T Update(string id, T newValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="DataNotFoundException"></exception>
        T Get(string id);
    }

    public sealed class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message)
            : base(message)
        {
        }
    }

    public sealed class GarrettDataStore<T> : IDataStore<T>
    {
        public string Create(T newValue)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public T Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public T Update(string id, T newValue)
        {
            throw new System.NotImplementedException();
        }
    }

    public sealed class ClementDataStore<T> : IDataStore<T>
    {
        public string Create(T newValue)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public T Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public T Update(string id, T newValue)
        {
            throw new System.NotImplementedException();
        }
    }

    /// <summary>
    /// A test type that can be used for testing <see cref="IDataStore{T}"/>s
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    public sealed class TestType
    {
        /// <summary>
        /// An updateable property to reflect a value in the <see cref="IDataStore{T}"/>
        /// </summary>
        public int SomeProperty { get; set; }
    }

    /// <summary>
    /// A tester for the <see cref="IDataStore{T}"/> interface
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed class DataStoreTester
    {
        /// <summary>
        /// Retrieves data that doesn't exist in the <see cref="IDataStore{T}"/>
        /// </summary>
        /// <param name="dataStore">The data store instance to test; required to not have data with id "someid"</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dataStore"/> is <see langword="null"/></exception>
        /// <exception cref="AssertFailedException">Thrown if the test failed</exception>
        public void GetNonexistentData(IDataStore<TestType> dataStore)
        {
            if (dataStore == null)
            {
                throw new ArgumentNullException(nameof(dataStore));
            }

            Assert.ThrowsException<DataNotFoundException>(() => dataStore.Get("someid"));
        }

        /// <summary>
        /// Deletes data that doesn't exist in the <see cref="IDataStore{T}"/>
        /// </summary>
        /// <param name="dataStore">The data store instance to test; required to not have data with id "someid"</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dataStore"/> is <see langword="null"/></exception>
        /// <exception cref="AssertFailedException">Thrown if the test failed</exception>
        public void DeleteNonexistentData(IDataStore<TestType> dataStore)
        {
            if (dataStore == null)
            {
                throw new ArgumentNullException(nameof(dataStore));
            }

            Assert.ThrowsException<DataNotFoundException>(() => dataStore.Delete("someid"));
        }

        /// <summary>
        /// Updates data that doesn't exist in the <see cref="IDataStore{T}"/>
        /// </summary>
        /// <param name="dataStore">The data store instance to test; required to not have data with id "someid"</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dataStore"/> is <see langword="null"/></exception>
        /// <exception cref="AssertFailedException">Thrown if the test failed</exception>
        public void UpdateNonexistentData(IDataStore<TestType> dataStore)
        {
            if (dataStore == null)
            {
                throw new ArgumentNullException(nameof(dataStore));
            }

            Assert.ThrowsException<DataNotFoundException>(() => dataStore.Update("someid", new TestType()));
        }

        /// <summary>
        /// Creates data in the <see cref="IDataStore{T}"/> and then retrieves it
        /// </summary>
        /// <param name="dataStore">The data store instance to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dataStore"/> is <see langword="null"/></exception>
        /// <exception cref="AssertFailedException">Thrown if the test failed</exception>
        public void CreateAndRetrieveData(IDataStore<TestType> dataStore)
        {
            if (dataStore == null)
            {
                throw new ArgumentNullException(nameof(dataStore));
            }

            var dataToCreate = new TestType()
            {
                SomeProperty = 42,
            };
            var id = dataStore.Create(dataToCreate);
            var retrievedData = dataStore.Get(id);
            Assert.AreEqual(dataToCreate.SomeProperty, retrievedData.SomeProperty);
        }

        /// <summary>
        /// Creates data in the <see cref="IDataStore{T}"/> and retrieves it, then updates the data and retrieves the updated data, then deletes the data and ensures that the id no longer exists
        /// </summary>
        /// <param name="dataStore">The data store instance to test</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dataStore"/> is <see langword="null"/></exception>
        /// <exception cref="AssertFailedException">Thrown if the test failed</exception>
        public void CreateRetrieveUpdateDeleteData(IDataStore<TestType> dataStore)
        {
            if (dataStore == null)
            {
                throw new ArgumentNullException(nameof(dataStore));
            }

            var dataToCreate = new TestType()
            {
                SomeProperty = 42,
            };
            var id = dataStore.Create(dataToCreate);
            var retrievedData = dataStore.Get(id);
            Assert.AreEqual(dataToCreate.SomeProperty, retrievedData.SomeProperty);

            var updatedData = new TestType()
            {
                SomeProperty = 24,
            };
            dataStore.Update(id, updatedData);
            var retrievedUpdatedData = dataStore.Get(id);
            Assert.AreEqual(updatedData.SomeProperty, retrievedUpdatedData.SomeProperty);

            dataStore.Delete(id);
            Assert.ThrowsException<DataNotFoundException>(() => dataStore.Get(id));
        }
    }

    /// <summary>
    /// Tests for the <see cref="GarrettDataStore{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public class GarrettDataStoreTests
    {
        /// <summary>
        /// Creates data in the <see cref="GarrettDataStore{T}{T}"/> and then retrieves it
        /// </summary>
        [TestMethod]
        public void CreateAndRetrieveData()
        {
            var dataStore = new GarrettDataStore<TestType>();
            new DataStoreTester().CreateAndRetrieveData(dataStore);
        }

        /// <summary>
        /// Creates data in the <see cref="GarrettDataStore{T}"/> and retrieves it, then updates the data and retrieves the updated data, then deletes the data and ensures that the id no longer exists
        /// </summary>
        [TestMethod]
        public void CreateRetrieveUpdateDeleteData()
        {
            var dataStore = new GarrettDataStore<TestType>();
            new DataStoreTester().CreateRetrieveUpdateDeleteData(dataStore);
        }

        /// <summary>
        /// Deletes data that doesn't exist in the <see cref="GarrettDataStore{T}"/>
        /// </summary>
        [TestMethod]
        public void DeleteNonexistentData()
        {
            var dataStore = new GarrettDataStore<TestType>();
            new DataStoreTester().DeleteNonexistentData(dataStore);
        }

        /// <summary>
        /// Retrieves data that doesn't exist in the <see cref="GarrettDataStore{T}"/>
        /// </summary>
        [TestMethod]
        public void GetNonexistentData()
        {
            var dataStore = new GarrettDataStore<TestType>();
            new DataStoreTester().GetNonexistentData(dataStore);
        }

        /// <summary>
        /// Updates data that doesn't exist in the <see cref="GarrettDataStore{T}"/>
        /// </summary>
        [TestMethod]
        public void UpdateNonexistentData()
        {
            var dataStore = new GarrettDataStore<TestType>();
            new DataStoreTester().UpdateNonexistentData(dataStore);
        }
    }

    /// <summary>
    /// Tests for the <see cref="ClementDataStore{T}"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    [TestClass]
    public class ClementDataStoreTests
    {
        /// <summary>
        /// Creates data in the <see cref="ClementDataStore{T}{T}"/> and then retrieves it
        /// </summary>
        [TestMethod]
        public void CreateAndRetrieveData()
        {
            var dataStore = new ClementDataStore<TestType>();
            new DataStoreTester().CreateAndRetrieveData(dataStore);
        }

        /// <summary>
        /// Creates data in the <see cref="ClementDataStore{T}"/> and retrieves it, then updates the data and retrieves the updated data, then deletes the data and ensures that the id no longer exists
        /// </summary>
        [TestMethod]
        public void CreateRetrieveUpdateDeleteData()
        {
            var dataStore = new ClementDataStore<TestType>();
            new DataStoreTester().CreateRetrieveUpdateDeleteData(dataStore);
        }

        /// <summary>
        /// Deletes data that doesn't exist in the <see cref="ClementDataStore{T}"/>
        /// </summary>
        [TestMethod]
        public void DeleteNonexistentData()
        {
            var dataStore = new ClementDataStore<TestType>();
            new DataStoreTester().DeleteNonexistentData(dataStore);
        }

        /// <summary>
        /// Retrieves data that doesn't exist in the <see cref="ClementDataStore{T}"/>
        /// </summary>
        [TestMethod]
        public void GetNonexistentData()
        {
            var dataStore = new ClementDataStore<TestType>();
            new DataStoreTester().GetNonexistentData(dataStore);
        }

        /// <summary>
        /// Updates data that doesn't exist in the <see cref="ClementDataStore{T}"/>
        /// </summary>
        [TestMethod]
        public void UpdateNonexistentData()
        {
            var dataStore = new ClementDataStore<TestType>();
            new DataStoreTester().UpdateNonexistentData(dataStore);
        }
    }
}
