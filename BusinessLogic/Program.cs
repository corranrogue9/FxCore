namespace BusinessLogic
{
    using Fx.Linq;
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
                var concatable = data.AddGarrett();
                Print(concatable);
                var concated = concatable
                    .Concat(new[] { "1234" }.ToV2Enumerable())
                    .Where(_ => true);
                Print(concated);
            }

            {
                var data = GetData2();
                Print(data);
                var concatable = data.AddGarrett();
                Print(concatable);
                var concated = concatable
                    .Concat(new[] { "1234" }.ToV2Enumerable())
                    .Concat(new[] { "!@#$" }.ToV2Enumerable())
                    .Where(_ => true)
                    .Concat(new[] { "ASDF" }.ToV2Enumerable());
                Print(concated);
            }

            {
                var data = GetData2();
                Print(data);
                var garretted = data.AddGarrett();
                Print(garretted);
                var whered = garretted.Where(_ => true);
                Print(whered);
            }

            {
                var data = GetDuplicatable();
                Print(data);
                var duplicated = data.Duplicate();
                Print(duplicated);
            }

            {
                var data = GetDuplicatable();
                Print(data);
                var garretted = data.AddGarrett();
                Print(garretted);
                var duplicated = garretted.Duplicate();
                Print(duplicated);
            }
        }

        public static IV2Enumerable<string> GetDuplicatable()
        {
            return new GetDuplicatableEnumerable();
        }

        private sealed class GetDuplicatableEnumerable : IDuplicateEnumerable<string>
        {
            private readonly bool isDuplicated;

            public GetDuplicatableEnumerable()
                : this(false)
            {
            }

            private GetDuplicatableEnumerable(bool isDuplicated)
            {
                this.isDuplicated = isDuplicated;
            }

            public IV2Enumerable<string> Duplicate()
            {
                return new GetDuplicatableEnumerable(true);
            }

            public IEnumerator<string> GetEnumerator()
            {
                if (this.isDuplicated)
                {
                    return new[] { "6789", "6789" }.AsEnumerable().GetEnumerator();
                }
                else
                {
                    return new[] { "hjkl" }.AsEnumerable().GetEnumerator();
                }
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
            private readonly bool isWhered;

            public GetDataEnumerable()
                : this(false)
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