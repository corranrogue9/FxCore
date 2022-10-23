namespace System.Linq
{
    using Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the <see cref="Enumerable"/>
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public sealed partial class EnumerableUnitTests
    {
        public class WeightedValue<T>
        {
            public double Weight { get; set; }

            public T Value { get; set; }
        }

        class MaxRandom : Random
        {
            public override double NextDouble()
            {
                return 1.0;
            }
        }

        public sealed class MinRandom : Random
        {
            public override double NextDouble()
            {
                return 0.0;
            }
        }

        static class Shuffle1
        {
            public static int VisitCount { get; private set; } = 0;

            public static IEnumerable<T> Shuffle<T>(System.Collections.Generic.IList<WeightedValue<T>> source, Random random)
            {
                var remainingWeight = source.Sum(_ => _.Weight);
                for (int i = 0; i < source.Count; ++i)
                {
                    var selectedWeight = random.NextDouble() * remainingWeight;
                    for (int j = i; j < source.Count; ++j)
                    {
                        ++VisitCount;
                        selectedWeight -= source[j].Weight;
                        if (selectedWeight <= 0.00001)
                        {
                            var temp = source[j];
                            source[j] = source[i];
                            source[i] = temp;

                            remainingWeight -= source[i].Weight;
                            yield return source[i].Value;
                            break;
                        }
                    }
                }
            }
        }

        static class Shuffle2
        { 
            public static IEnumerable<T> Shuffle<T>(System.Collections.Generic.IList<T> source, Random random)
            {
                for (int i = 0; i < source.Count; ++i)
                {
                    var next = random.Next(i, source.Count);
                    var temp = source[next];
                    source[next] = source[i];
                    source[i] = temp;
                }

                return source;
            }
        }

        static class Shuffle3
        {
            public static int VisitCount { get; private set; } = 0;

            public static IEnumerable<T> Shuffle<T>(System.Collections.Generic.IList<WeightedValue<T>> source, Random random)
            {
                var subweights = new double[source.Count];
                for (int i = source.Count - 1; i > 0; --i)
                {
                    subweights[i] += source[i].Weight;
                    subweights[(i - 1) / 2] += subweights[i];
                }

                subweights[0] += source[0].Weight;
                
                for (int i = 0; i < source.Count; ++i)
                {
                    var next = random.NextDouble();
                    yield return source[Visit(subweights, source, next * subweights[0], 0)].Value;
                }
            }

            private static int Visit<T>(double[] subweights, IList<WeightedValue<T>> source, double next, int currentIndex)
            {
                ++VisitCount;

                var leftIndex = currentIndex * 2 + 1;
                if (leftIndex >= subweights.Length)
                {
                    if (subweights[currentIndex] == 0)
                    {
                        ////throw new InvalidOperationException("TODO");
                    }

                    return currentIndex;
                }

                if (next < subweights[leftIndex])
                {
                    // go left
                    var toReturn = Visit(subweights, source, next, leftIndex);
                    subweights[currentIndex] -= subweights[toReturn];
                    return toReturn;
                }
                else if (next < subweights[leftIndex] + source[currentIndex].Weight)
                {
                    subweights[currentIndex] = 0;
                    return currentIndex;
                }
                else
                {
                    var rightIndex = currentIndex * 2 + 2;
                    if (rightIndex >= subweights.Length)
                    {
                        if (subweights[currentIndex] == 0)
                        {
                            ////throw new InvalidOperationException("TODO");
                        }

                        return currentIndex;
                    }

                    // go right
                    var toReturn = Visit(subweights, source, next, rightIndex);
                    subweights[currentIndex] -= subweights[toReturn];
                    return toReturn;
                }
            }
        }

        [TestMethod]
        public void Shuffle1Tests()
        {
            var settings = new ShuffleTestsSettings()
            {
                Random = new MaxRandom(),
            };
            ShuffleTest(new ShuffleTests(Shuffle1.Shuffle, settings));

            throw new Exception($"{Shuffle1.VisitCount}");
        }

        [TestMethod]
        public void Shuffle3Tests()
        {
            var settings = new ShuffleTestsSettings()
            {
                Random = new MinRandom(),
            };
            ShuffleTest(new ShuffleTests(Shuffle3.Shuffle, settings));

            throw new Exception($"{Shuffle3.VisitCount}");
        }

        [TestMethod]
        public void Shuffle2Tests()
        {
            ShuffleTest(new ShuffleTests((source, random) => Shuffle2.Shuffle(source.Select(_ => _.Value).ToList(), random)));
        }

        private static void ShuffleTest(ShuffleTests shuffleTests)
        {
            shuffleTests.UniformShuffle();
            shuffleTests.SingleComplete();
            shuffleTests.MultipleWeights();
            shuffleTests.SingleWeight();
            shuffleTests.SingleEmpty();
            shuffleTests.Distinct();
        }

        public sealed class ShuffleTestsSettings
        {
            public Random Random { get; set; } = new Random(0);

            public int Count { get; set; } = 1000000;

            public double Error { get; set; } = 0.01;
        }

        public sealed class ShuffleTests
        {
            private readonly Func<IList<WeightedValue<string>>, Random, IEnumerable<string>> shuffle;

            private readonly Random random;

            private readonly int count;

            private readonly double error;

            public ShuffleTests(Func<IList<WeightedValue<string>>, Random, IEnumerable<string>> shuffle)
                : this(shuffle, new ShuffleTestsSettings())
            {
            }

            public ShuffleTests(Func<IList<WeightedValue<string>>, Random, IEnumerable<string>> shuffle, ShuffleTestsSettings settings)
            {
                this.shuffle = shuffle;
                this.random = settings.Random;
                this.count = settings.Count;
                this.error = settings.Error;
            }

            public void UniformShuffle()
            {
                var names = new[]
                {
                    "christof",
                    "garrett",
                    "dan",
                    "mike",
                    "eric",
                };
                DoShuffle(
                    names
                        .Select(value =>
                        new WeightedValue<string>()
                        {
                            Value = value,
                            Weight = 1.0,
                        })
                        .ToList());
            }

            public void SingleWeight()
            {
                var names = new[]
                {
                    "christof",
                    "garrett",
                    "dan",
                    "mike",
                    "eric",
                };
                DoShuffle(
                    names
                        .Select(value =>
                        new WeightedValue<string>()
                        {
                            Value = value,
                            Weight = string.Equals(value, "garrett") ? 0.3 : 1.0,
                        })
                        .ToList());
            }

            public void MultipleWeights()
            {
                var names = new[]
                {
                    "christof",
                    "garrett",
                    "dan",
                    "mike",
                    "eric",
                };
                DoShuffle(
                    names
                        .Select(value =>
                        new WeightedValue<string>()
                        {
                            Value = value,
                            Weight = string.Equals(value, "garrett") ? 0.3 : string.Equals(value, "mike") ? 1.6 : 1.0,
                        })
                        .ToList());
            }

            public void SingleComplete()
            {
                var names = new[]
                {
                    "christof",
                    "garrett",
                    "dan",
                    "mike",
                    "eric",
                };
                DoShuffle(
                    names
                        .Select(value =>
                        new WeightedValue<string>()
                        {
                            Value = value,
                            Weight = string.Equals(value, "garrett") ? 1.0 : 0.0,
                        })
                        .ToList());
            }

            public void SingleEmpty()
            {
                var names = new[]
                {
                    "christof",
                    "garrett",
                    "dan",
                    "mike",
                    "eric",
                };
                DoShuffle(
                    names
                        .Select(value =>
                        new WeightedValue<string>()
                        {
                            Value = value,
                            Weight = string.Equals(value, "garrett") ? 0.0 : 1.0,
                        })
                        .ToList());
            }

            public void Distinct()
            {
                var names = new[]
                {
                    "christof",
                    "garrett",
                    "dan",
                    "mike",
                    "eric",
                };
                DoShuffle(
                    names
                        .Select((value, index) =>
                        new WeightedValue<string>()
                        {
                            Value = value,
                            Weight = index,
                        })
                        .ToList());
            }

            private void DoShuffle(IList<WeightedValue<string>> original)
            {
                var frequency = original.ToDictionary(_ => _.Value, _ => 0);
                for (int i = 0; i < this.count; ++i)
                {
                    var shuffled = this.shuffle(original.ToList(), this.random);
                    shuffled.ToList();
                    frequency[shuffled.First()]++;
                }

                var totalWeight = original.Sum(value => value.Weight);
                foreach (var element in original)
                {
                    var expected = element.Weight * this.count / totalWeight; // we expect the count to be proportional to the weight
                    /*Assert.AreEqual(
                        expected,
                        frequency[element.Value],
                        expected * this.error);*/ //// TODO
                }
            }
        }
        
        /// <summary>
        /// Reverses a sequence
        /// </summary>
        [TestCategory("Unit")]
        [Description("Reverses a sequence")]
        [Priority(1)]
        [TestMethod]
        public void Reverse()
        {
            new ReverseUnitTests().Reverse(data => data.AsEnumerable(), Enumerable.Reverse);
        }

        /// <summary>
        /// Reverses a sequence with a single element
        /// </summary>
        [TestCategory("Unit")]
        [Description("Reverses a sequence with a single element")]
        [Priority(1)]
        [TestMethod]
        public void ReverseSinge()
        {
            new ReverseUnitTests().ReverseSingle(data => data.AsEnumerable(), Enumerable.Reverse);
        }

        /// <summary>
        /// Reverses a sequence that is empty
        /// </summary>
        [TestCategory("Unit")]
        [Description("Reverses a sequence that is empty")]
        [Priority(1)]
        [TestMethod]
        public void ReverseEmpty()
        {
            new ReverseUnitTests().ReverseEmpty(data => data.AsEnumerable(), Enumerable.Reverse);
        }
    }
}
