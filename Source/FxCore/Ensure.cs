namespace FxCore
{
    using System;
    using System.Collections.Generic;
#if NET35
    using System.Linq;
#endif
#if NET40
    using System.Threading.Tasks;
#endif

    using Microsoft.VisualStudio.TestTools.UnitTesting;



    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test()
        {
            ////Assert.Fail();
        }
    }

#if NET40
    [TestClass]
    public class ThingyTests
    {
        [TestMethod]
        public void Test1()
        {
            var task = new Task(() => { });
            var result = Foo2(task);
            task.Start();
            result.Wait();
            Assert.Fail();
        }

        public Task Foo2(Task task)
        {
            return task.ContinueWith(init => Foo2Async().GetAwaiter().GetResult());
        }

        public async Task Foo2Async()
        {
            /*var foo = task.ContinueWith(init => Foo().Result);
            var fooer = task.ContinueWith(init => value2 = 10.0);
            return Task.WhenAll(foo, fooer);*/
            await Foo();
            await System.Threading.Tasks.Task.Factory.StartNew(() => value2 = 10.0);
        }

        public double value;

        public double value2;

            public async Task<double> Foo() {
                var n = await NumberOfDigits();
            Task.Delay(10000).Wait();
                var pi = await CalculatePi(n);
            value = pi;
                return pi;
            }

        public Task<int> NumberOfDigits()
        {
            var task = new VmTask<int>(() => 10);
            task.Start();
            return task;
        }

        private Task<double> CalculatePi(int nDigits)
        {
            var task = new VmTask<double>(() => 1.0);
            task.Start();
            return task;
        }
    }

    interface IVmTask { }

    public class VmTask<T> : Task<T>, IVmTask
    {
        private TaskCompletionSource<T> _completionSource;

        public VmTask(Func<T> func)
            : base(func)
        {
            _completionSource = new TaskCompletionSource<T>();
        }
        
        internal void SetResult(T t)
        {
            _completionSource.SetResult(t);
        }

        
    }

    public class Thing : System.Threading.Tasks.TaskScheduler
    {
        //  System.Collections.Concurrent.ConcurrentQueue<Task> tasks = new System.Collections.Concurrent.ConcurrentQueue<Task>();
        System.Collections.Concurrent.BlockingCollection<Task> tasks = new System.Collections.Concurrent.BlockingCollection<Task>();

        public Thing()
        {
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return new Task[0];
        }

        protected override void QueueTask(Task task)
        {
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            TryExecuteTask(task);
            return true;
        }
    }
#endif

    /// <summary>
    /// validates input parameters against certain preconditions
    /// </summary>
    public static class Ensure
    {
#if NET35
        public static void Thing(System.Collections.Generic.IEnumerable<uint> value)
        {
            value.Select(val => val + 1);
        }
#endif

        /// <summary>
        /// validates that <paramref name="value"/> is not null
        /// </summary>
        /// <typeparam name="T">the type of the object being validated</typeparam>
        /// <param name="value">the value being validated</param>
        /// <param name="name">the name of the parameter that <paramref name="value"/> was passed in as</param>
        /// <exception cref="ArgumentNullException">thrown if <paramref name="value"/> is null</exception>
        public static void NotNull<T>([ValidatedNotNull] T value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
