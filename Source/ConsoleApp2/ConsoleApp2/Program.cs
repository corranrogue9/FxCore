using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //// TODO console.readline
            Integer.TryParse(args[0])
                .Select(value => value * value, error => new List<string>(new[] { error }))
                .Apply(value => Console.WriteLine($"The square of the input is {value}"), errors => Console.WriteLine($"The following errors occurred: {string.Join(Environment.NewLine, errors)}"));

            Class1.DoWork(Console.ReadLine());
        }
    }

    public static class Integer
    {
        public static Either<int, string> TryParse(string input)
        {
            //// TODO
            //// factory from "try" variants to either
            return (out int left, out string right) => TryParse(input, out left, out right);
        }

        public static bool TryParse(string input, out int value, out string error)
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

    public delegate bool Either<TLeft, TRight>(out TLeft left, out TRight right);

    public static class Extensions
    {
        public static Either<TLeftOut, TRightIn> LeftSelect<TLeftIn, TRightIn, TLeftOut>(
            this Either<TLeftIn, TRightIn> either,
            Func<TLeftIn, TLeftOut> leftSelector)
        {
            return either.Select(leftSelector, _ => _);
        }

        public static Either<TLeftOut, TRightOut> Select<TLeftIn, TRightIn, TLeftOut, TRightOut>(
            this Either<TLeftIn, TRightIn> either,
            Func<TLeftIn, TLeftOut> leftSelector, 
            Func<TRightIn, TRightOut> rightSelector)
        {
            return (out TLeftOut leftOut, out TRightOut rightOut) =>
            {
                if (either(out var left, out var right))
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

        public static void Apply<TLeft, TRight>(
            this Either<TLeft, TRight> either, 
            Action<TLeft> leftAction, 
            Action<TRight> rightAction)
        {
            if (either(out var left, out var right))
            {
                leftAction(left);
            }
            else
            {
                rightAction(right);
            }
        }
    }
}
