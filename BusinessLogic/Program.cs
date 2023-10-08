namespace BusinessLogic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.V2;

    internal class Program
    {
        private static void Print(IV2Enumerable<string> data)
        {
            foreach (var element in data)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            {
                var data = GetData();
                Print(data);
            }

            {
                var data = GetData2();
                Print(data);
                var whered = data.Where(_ => true);
                Print(whered);
            }

            {
                var data = GetData2();
                Print(data);
                var concated = data
                    .Concat(new[] { "1234" }.ToV2Enumerable())
                    .Where(_ => true);
                Print(concated);
            }

            {
                var data = GetData2();
                Print(data);
                var concatable = new ConcatableEnumerable<string>(data);
                Print(concatable);
                var concated = concatable
                    .Concat(new[] { "1234" }.ToV2Enumerable())
                    .Where(_ => true);
                Print(concated);
            }
        }

        private sealed class ConcatableEnumerable<T> : IConcatEnumerable<T>
        {
            private readonly IV2Enumerable<T> source;

            public ConcatableEnumerable(IV2Enumerable<T> source)
            {
                this.source = source;
            }

            public IV2Enumerable<T> Concat(IV2Enumerable<T> second)
            {
                return new ConcatedEnumerable(this.source, second);
            }

            private sealed class ConcatedEnumerable : IWhereEnumerable<T>
            {
                private readonly IV2Enumerable<T> first;

                private readonly IV2Enumerable<T> second;

                public ConcatedEnumerable(IV2Enumerable<T> first, IV2Enumerable<T> second)
                {
                    this.first = first;
                    this.second = second;
                }

                public IEnumerator<T> GetEnumerator()
                {
                    return this.first.Concat(this.second).GetEnumerator();
                }

                public IV2Enumerable<T> Where(Func<T, bool> predicate)
                {
                    return this.first.Where(predicate).Concat(this.second.Where(predicate));
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this.source.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public static IV2Enumerable<string> GetData2()
        {
            return new GetDataEnumerable();
        }

        private sealed class GetDataEnumerable : IWhereEnumerable<string>
        {
            private bool isWhered;

            public GetDataEnumerable()
                : this (false)
            {
            }

            private GetDataEnumerable(bool isWhered)
            {
                this.isWhered = isWhered;
            }

            public IEnumerator<string> GetEnumerator()
            {
                if (this.isWhered)
                {
                    return new[] { "asdf", "qwer" }.AsEnumerable().GetEnumerator();
                }
                else
                {
                    return new[] { "asdf", "qwer", "zxcv" }.AsEnumerable().GetEnumerator();
                }
            }

            public IV2Enumerable<string> Where(Func<string, bool> predicate)
            {
                return new GetDataEnumerable(true);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public static IV2Enumerable<string> GetData()
        {
            return new[] { "asdf", "qwer", "zxcv" }.ToV2Enumerable();
        }
    }
}