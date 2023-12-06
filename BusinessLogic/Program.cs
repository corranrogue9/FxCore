namespace BusinessLogic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.V2;
    using System.Numerics;

    public sealed class Dimension<T>
    {
        public Dimension(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
    }

    //// TODO can you define an alias for 2d and 3d points? it seems you can't have generic type parameters in aliases
    public abstract class Point<T> where T : INumber<T>
    {
        private Point(Dimension<T> dimension)
        {
            this.Dimension = dimension;
        }

        public Dimension<T> Dimension { get; }

        public sealed class SingleDimensionalPoint : Point<T>
        {
            public SingleDimensionalPoint(Dimension<T> dimension)
                : base (dimension)
            {
            }
        }

        public sealed class MultidimensionalPoint<TPoint> : Point<T> where TPoint : Point<T>
        {
            public MultidimensionalPoint(TPoint point, Dimension<T> dimension)
                : base(dimension)
            {
                this.Point = point;
            }

            public TPoint Point { get; }

            //// TODO have an implicit operator from lower dimensional types to higher dimensional types

            public static implicit operator MultidimensionalPoint<TPoint>(SingleDimensionalPoint point)
            {
                ////return new MultidimensionalPoint<TPoint>(point, new Dimension<T>(T.Zero));
                return null;
            }


            public static implicit operator MultidimensionalPoint<MultidimensionalPoint<TPoint>>(Point<T>.MultidimensionalPoint<TPoint> point)
            {
                return point.Generalize();
            }
        }
    }

    public static class Point
    {
        public static Point<T>.MultidimensionalPoint<TPoint> MultidimensionalPoint<TPoint, T>(TPoint point, Dimension<T> dimension) where TPoint : Point<T> where T : INumber<T>
        {
            return new Point<T>.MultidimensionalPoint<TPoint>(point, dimension);
        }

        public static Point<T>.SingleDimensionalPoint SingleDimensionalPoint<T>(Dimension<T> dimension) where T : INumber<T>
        {
            return new Point<T>.SingleDimensionalPoint(dimension);
        }

        public static Dimension<T> Dimension<T>(T value)
        {
            return new Dimension<T>(value);
        }
    }

    public static class Extensions
    {
        public static Point<T>.MultidimensionalPoint<Point<T>.MultidimensionalPoint<TPoint>> Generalize<TPoint, T>(
            this Point<T>.MultidimensionalPoint<TPoint> self) where TPoint : Point<T> where T : INumber<T>
        {
            return Point.MultidimensionalPoint(self, Point.Dimension(T.Zero));
        }

        public static void DoWork()
        {
            var point1 = Point.MultidimensionalPoint(Point.SingleDimensionalPoint(Point.Dimension(0)), Point.Dimension(3));
            var point2 = Point.MultidimensionalPoint(Point.SingleDimensionalPoint(Point.Dimension(4)), Point.Dimension(0));
            var distaince = point1.Distance(point2);
            if (distaince != 5)
            {
                throw new Exception("TODO");
            }
        }

        public static double Distance<T>(
            this Point<T>.MultidimensionalPoint<Point<T>.SingleDimensionalPoint> point1, 
            Point<T>.MultidimensionalPoint<Point<T>.SingleDimensionalPoint> point2) where T : INumber<T>
        {
            ////return point1.Generalize().Distance(point2);
            return point1.Generalize().Distance(point2.Generalize());
        }

        public static double Distance<T>(
            this Point<T>.MultidimensionalPoint<Point<T>.MultidimensionalPoint<Point<T>.SingleDimensionalPoint>> point1,
            Point<T>.MultidimensionalPoint<Point<T>.MultidimensionalPoint<Point<T>.SingleDimensionalPoint>> point2) where T : INumber<T>
        {
            var xes = point2.Dimension.Value - point1.Dimension.Value;
            var yes = point2.Point.Dimension.Value - point1.Point.Dimension.Value;
            var zes = point2.Point.Point.Dimension.Value - point1.Point.Point.Dimension.Value;

            var summedSquares = xes * xes + yes * yes + zes * zes;

            //// TODO cast to something suqare rootable
            var @double = double.CreateChecked(summedSquares);
            return Math.Sqrt(@double);
        }
    }

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

        private static void Print(IV2Enumerable<int> data)
        {
            foreach (var element in data)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Extensions.DoWork();

            //// Personas:
            //// person who is writing optimized "business logic" (series calendar events e.g.)
            //// person who is writing an optimized linq call (overloading groupby)
            //// person who is writing an optmization for linq where context of previous linq calls is imperative (e.g. where'ing after concat'ing)
            //// person who is adding a new linq query (e.g. duplicate)
            //// person who is writing an optmization for linq where context of previous linq calls is imperative (e.g. where'ing after duplating'ing)



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

            {
                var data = GetDuplicatable();
                Print(data);
                var garretted = data.AddGarrett();
                Print(garretted);
                var duplicated = garretted
                    .Duplicate()
                    .Concat(new[] { "1234"}.ToV2Enumerable());
                Print(duplicated);
            }

            {
                var data = GetDuplicatable();
                Print(data);
                var garretted = data.AddGarrett();
                Print(garretted);
                var duplicated = garretted
                    .Concat(new[] { "1234" }.ToV2Enumerable())
                    .Duplicate();
                Print(duplicated);
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
                Console.WriteLine("without append:");
                Print(concated);

                Console.WriteLine("with append:");
                var appended = concatable
                    .Concat(new[] { "1234" }.ToV2Enumerable())
                    .Concat(new[] { "!@#$" }.ToV2Enumerable())
                    .Where(_ => true)
                    .Append("appended")
                    .Concat(data)
                    .Where(_ => true);
                Print(appended);
            }

            //// TODO plus what happens if linq introduces a new extension "foo"?
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

            public IV2Enumerable<string> Where(Func<string, int, bool> predicate)
            {
                throw new NotImplementedException();
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