using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    static class Class1
    {
        public static void DoWork(string input)
        {
            Integer.TryParse(input)
                .Select(value => value * value, error => new List<string>(new[] { error }))
                .Select(value => value % 2 == 0 ? ReadFromDirectory() : ReadFromFusion(), errors => errors);
        }

        private static Either<IEnumerable<Application>, Exception> ReadFromDirectory()
        {
            return TryCatch.Create(ReadFromDirectoryImplementation);
        }

        private static IEnumerable<Application> ReadFromDirectoryImplementation()
        {
            yield break;
        }

        private static Either<IEnumerable<Application>, Exception> ReadFromFusion()
        {
            return TryCatch.Create(ReadFromFusionImplementation);
        }

        private static IEnumerable<Application> ReadFromFusionImplementation()
        {
            yield break;
        }

        private sealed class Application
        {
            public string Id { get; set; }
        }
    }

    public static class TryCatch
    {
        public static Either<TValue, Exception> Create<TValue>(Func<TValue> func)
        {
            return (out TValue left, out Exception right) =>
            {
                try
                {
                    left = func();
                    right = default;
                    return true;
                }
                catch (Exception e)
                {
                    left = default;
                    right = e;
                    return false;
                }
            };
        }

        public static Either<TLeft, TRightOut> Aggregate<TLeft, TRightFirst, TRightSecond, TRightOut>(
            this Either<Either<TLeft, TRightFirst>, TRightSecond> either, 
            Func<TRightFirst, TRightOut> firstAggregator,
            Func<TRightSecond, TRightOut> secondAggregator)
        {
            return (out TLeft leftOut, out TRightOut rightOut) =>
            {
                if (either(out var secondLeft, out var secondRight))
                {
                    if (secondLeft(out var firstLeft, out var firstRight))
                    {
                        leftOut = firstLeft;
                        rightOut = default;
                        return true;
                    }
                    else
                    {
                        leftOut = default;
                        rightOut = firstAggregator(firstRight);
                        return false;
                    }
                }
                else
                {
                    leftOut = default;
                    rightOut = secondAggregator(secondRight);
                    return false;
                }
            };
        }

        public static Either<TLeft, TRight> Aggregate<TLeft, TRight>(this Either<Either<TLeft, TRight>, TRight> either)
        {
            return either.Aggregate(_ => _, _ => _);
        }
    }
}
