namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var reviewers = new (int Weight, string Name)[]
            {
                (100, "Vincenzo"),
                (20, "Shantanu"),
                (20, "Karthik"),
                (60, "Mike"),
                (20, "Eric"),
                (20, "Dulci"),
                (100, "Dan"),
                (30, "Christof"),
                (80, "Garrett"),
            };

            var distribution = WeightedDistribution.Create(reviewers, new Random());
            while (/*newReview*/true)
            {
                var assignedReviewers = distribution.SampleWithoutReplacement(2);
            }
        }
    }

    public interface IDistribution<out TValue>
    {
        TValue Sample();
    }

    public interface IDistribution<out TValue, TDistribution> : IDistribution<TValue> where TDistribution : IDistribution<TValue, TDistribution>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="remainder">
        /// The current distribution, without the returned <typeparamref name="TValue"/>; the returned <typeparamref name="TValue"/> is selected without replacement in
        /// the resulting <typeparamref name="TDistribution"/>; this will be <see langword="null"/> if the returned <typeparamref name="TValue"/> is the last value in
        /// this distribution
        /// </param>
        /// <returns></returns>
        TValue Sample(out TDistribution remainder);
    }

    public static class DistributionExtensions
    {
        public static IEnumerable<T> SampleWithReplacement<T>(this IDistribution<T> distribution, int count)
        {
            if (distribution == null)
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return SampleWithReplacementIterator(distribution, count);
        }

        private static IEnumerable<T> SampleWithReplacementIterator<T>(this IDistribution<T> distribution, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return distribution.Sample();
            }
        }

        public static IEnumerable<TValue> SampleWithoutReplacement<TValue, TDistribution>(this IDistribution<TValue, TDistribution> distribution, int count) 
            where TDistribution : IDistribution<TValue, TDistribution>
        {
            if (distribution == null)
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            //// TODO it would be really good to validate count, but that would force distributions to be finite
            return distribution.Shuffle().Take(count);
        }

        public static IEnumerable<TValue> Shuffle<TValue, TDistribution>(this IDistribution<TValue, TDistribution> distribution) 
            where TDistribution : IDistribution<TValue, TDistribution>
        {
            if (distribution == null)
            {
                throw new ArgumentNullException(nameof(distribution));
            }

            return ShuffleIterator(distribution);
        }

        private static IEnumerable<TValue> ShuffleIterator<TValue, TDistribution>(this IDistribution<TValue, TDistribution> distribution) where TDistribution : IDistribution<TValue, TDistribution>
        {
            yield return distribution.Sample(out var remainder);
            while (remainder != null)
            {
                yield return distribution.Sample(out remainder);
            }
        }
    }

    /// <summary>
    /// DONT USE THIS, ITS AN EXAMPLE, AND A BAD ONE
    /// </summary>
    public sealed class UniformDistribution : IDistribution<int>
    {
        private readonly Random random;

        public UniformDistribution(Random random)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            this.random = random;
        }

        public int Sample()
        {
            return random.Next();
        }
    }

    public static class WeightedDistribution
    {
        public static WeightedDistribution<TValue> Create<TValue>(IReadOnlyList<(int Weight, TValue Value)> values, Random random)
        {
            return new WeightedDistribution<TValue>(values, random);
        }
    }

    public sealed class WeightedDistribution<TValue> : IDistribution<TValue, WeightedDistribution<TValue>>
    {
        private readonly int[] weights;

        private readonly int remainingValueCount;

        private readonly IReadOnlyList<(int Weight, TValue Value)> values;

        private readonly Random random;

        public WeightedDistribution(IReadOnlyList<(int Weight, TValue Value)> values, Random random)
        {
            //// TODO have overload which provides random
            //// TODO values can probably be less specific that readonlylist, but doing this way for now for convenience
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            //// TODO populated sequence?
            if (values.Count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            this.weights = new int[values.Count];
            for (int i = values.Count - 1; i > 0; --i)
            {
                this.weights[i] += values[i].Weight;
                this.weights[(i - 1) / 2] += this.weights[i];
            }

            this.weights[0] += values[0].Weight;

            this.remainingValueCount = values.Count;

            this.values = values;
            this.random = random;
        }

        private WeightedDistribution(IReadOnlyList<(int Weight, TValue Value)> values, Random random, int[] weights, int remainder)
        {
            this.values = values;
            this.random = random;
            this.weights = weights;
            this.remainingValueCount = remainder;
        }

        public TValue Sample(out WeightedDistribution<TValue> remainder)
        {
            var newWeights = this.weights.Clone() as int[];
            var sampleIndex = Visit(newWeights, this.random.Next(), 0);

            if (this.remainingValueCount == 1)
            {
                remainder = null;
            }
            else
            {
                remainder = new WeightedDistribution<TValue>(this.values, this.random, newWeights, this.remainingValueCount - 1);
            }

            return this.values[sampleIndex].Value;
        }

        public TValue Sample()
        {
            return this.Sample(out var remainder);
        }

        private int Visit(int[] weights, int next, int currentIndex)
        {
            var leftIndex = currentIndex * 2 + 1;
            if (leftIndex >= weights.Length)
            {
                if (weights[currentIndex] == 0)
                {
                    throw new InvalidOperationException("TODO");
                }

                return currentIndex;
            }

            if (next < weights[leftIndex])
            {
                // traverse the left subnode of the tree
                var chosenIndex = Visit(weights, next, leftIndex);
                weights[currentIndex] -= weights[chosenIndex];
                return chosenIndex;
            }
            else if (next < weights[leftIndex] + values[currentIndex].Weight)
            {
                // take the current node of the tree
                weights[currentIndex] = 0;
                return currentIndex;
            }
            else
            {
                var rightIndex = currentIndex * 2 + 2;
                if (rightIndex >= weights.Length)
                {
                    if (weights[currentIndex] == 0)
                    {
                        throw new InvalidOperationException("TODO");
                    }

                    return currentIndex;
                }

                // traverse the right subnode of the tree
                var chosenIndex = Visit(weights, next, rightIndex);
                weights[currentIndex] -= weights[chosenIndex];
                return chosenIndex;
            }
        }
    }
}
