using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        void DoWork()
        {
            Either<string, int, string> tryParse = TryParse;
            tryParse.Map(value => value * value, error => new List<string>(new[] { error }));
        }

        public bool TryParse(string input, out int value, out string error)
        {
            try
            {
                value = int.Parse(input);
                error = null;
                return true;
            }
            catch (Exception e)
            {
                value = 0;
                error = e.Message;
                return false;
            }
        }
    }

    public delegate bool Either<TIn, TLeft, TRight>(TIn @in, out TLeft left, out TRight right);

    public static class Extensions
    {
        public static Either<TIn, TLeftOut, TRightOut> Map<TIn, TLeftIn, TRightIn, TLeftOut, TRightOut>(this Either<TIn, TLeftIn, TRightIn> either, Func<TLeftIn, TLeftOut> leftSelector, Func<TRightIn, TRightOut> rightSelector)
        {
            return (TIn @in, out TLeftOut leftOut, out TRightOut rightOut) =>
            {
                if (either(@in, out var left, out var right))
                {
                    leftOut = leftSelector(left);
                    rightOut = default(TRightOut);
                    return true;
                }
                else
                {
                    leftOut = default(TLeftOut);
                    rightOut = rightSelector(right);
                    return false;
                }
            };
        }
    }
}
