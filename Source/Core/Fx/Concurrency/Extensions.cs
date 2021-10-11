namespace Fx.Concurrency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<IEnumerable<Instruction>>> Permutations<T>(this IEnumerable<T> instructions) where T : IInstruction
        {
            var splitted = instructions.SplitBy(instruction => instruction.IsSharedMemoryAccess).ToList();
            return splitted.Select(x => x.Select(y => new Instruction(y, 1))).ToList().Interleave(splitted.Select(x => x.Select(y => new Instruction(y, 2))).ToList());
        }

        public static IEnumerable<IEnumerable<T>> SplitBy<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            // this implies that the thing you split on will only have on element that matches the predicate

            using (var enumerator = source.GetEnumerator())
            {
                var list = new List<T>();
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                    {
                        yield return list;
                        list = new List<T>();
                        yield return new[] { enumerator.Current };
                    }
                    else
                    {
                        list.Add(enumerator.Current);
                    }
                }

                if (list.Count != 0)
                {
                    yield return list;
                }
            }
        }

        public static IEnumerable<IEnumerable<T>> Interleave<T>(this IReadOnlyCollection<T> first, IReadOnlyCollection<T> second)
        {
            var length = first.Count + second.Count;

            //// TODO use bitvector instead?
            var firstOrSecond = new bool[length]; // true means first, false means second
            foreach (var interleave in Interleaves(firstOrSecond, 0, 0, first.Count - 1, length))
            {
                yield return InterleaveIterator(first, second, interleave);
            }
        }

        private static IEnumerable<bool[]> Interleaves(bool[] firstOrSecond, int start, int current, int total, int length)
        {
            for (int i = start; i < length; ++i)
            {
                if (i != start)
                {
                    firstOrSecond[i - 1] = false;
                }

                firstOrSecond[i] = true;
                for (int j = i + 1; j < length; ++j)
                {
                    firstOrSecond[j] = false;
                }

                if (current == total)
                {
                    yield return firstOrSecond;
                }
                else
                {
                    foreach (var combination in Interleaves(firstOrSecond, i + 1, current + 1, total, length))
                    {
                        yield return combination;
                    }
                }
            }
        }

        private static IEnumerable<T> InterleaveIterator<T>(IReadOnlyCollection<T> first, IReadOnlyCollection<T> second, bool[] firstOrSecond)
        {
            using (var firstEnumerator = first.GetEnumerator())
            using (var secondEnumerator = second.GetEnumerator())
            {
                for (int i = 0; i < firstOrSecond.Length; ++i)
                {
                    if (firstOrSecond[i])
                    {
                        if (firstEnumerator.MoveNext())
                        {
                            yield return firstEnumerator.Current;
                        }
                        else
                        {
                            if (secondEnumerator.MoveNext())
                            {
                                yield return secondEnumerator.Current;
                            }
                        }
                    }
                    else
                    {
                        if (secondEnumerator.MoveNext())
                        {
                            yield return secondEnumerator.Current;
                        }
                        else
                        {
                            if (firstEnumerator.MoveNext())
                            {
                                yield return firstEnumerator.Current;
                            }
                        }
                    }
                }
            }
        }
    }
}
