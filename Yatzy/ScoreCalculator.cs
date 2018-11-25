using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy {
    public class ScoreCalculator {
        public int Calculate(Categories category, IEnumerable<int> input) {
            switch (category) {
                case Categories.Chance:
                    return CalculateChanceScore(input);
                case Categories.Yatzy:
                    return CalculateYatzyScore(input);
                case Categories.Ones:
                    return CalculateNumsScore(input, 1);
                case Categories.Twos:
                    return CalculateNumsScore(input, 2);
                case Categories.Threes:
                    return CalculateNumsScore(input, 3);
                case Categories.Fours:
                    return CalculateNumsScore(input, 4);
                case Categories.Fives:
                    return CalculateNumsScore(input, 5);
                case Categories.Sixes:
                    return CalculateNumsScore(input, 6);
                case Categories.Pair:
                    return CalculatePairScore(input);
                case Categories.TwoPairs:
                    return CalculateTwoPairsScore(input);
                /*case Categories.ThreeOfAKind:
                    break;
                case Categories.SmallStraight:
                    break;
                case Categories.LargeStraight:
                    break;
                case Categories.FullHouse:
                    break;
                    */
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        private int CalculateTwoPairsScore(IEnumerable<int> input) {
            if (HasTwoUniquePairs(input)) {
                var pairs = GetUniquePairs(input);
                return 2 * pairs.Sum();
            }

            return 0;
        }

        private int CalculatePairScore(IEnumerable<int> input) {
            if (HasPair(input)) {
                var highestPair = GetHighestPair(input);
                return 2 * highestPair;
            }

            return 0;
        }

        private static int CalculateNumsScore(IEnumerable<int> input, int num) {
            return input.Where(element => element == num).Sum();
        }

        private static int CalculateYatzyScore(IEnumerable<int> input) {
            var firstRoll = input.ElementAt(0);
            return input.Any(element => element != firstRoll) ? 0 : 50;
        }

        private static int CalculateChanceScore(IEnumerable<int> input) {
            return input.Sum();
        }

        public bool HasPair(IEnumerable<int> input) {
            for (var i = 1; i <= 6; i++)
                if (input.Count(element => element == i) >= 2)
                    return true;

            return false;
        }

        public int GetHighestPair(IEnumerable<int> input) {
            var currentHighestPair = -1;

            for (var i = 1; i <= 6; i++)
                if (input.Count(element => element == i) >= 2 && i > currentHighestPair)
                    currentHighestPair = i;

            return currentHighestPair;
        }

        public bool HasTwoUniquePairs(IEnumerable<int> input) {
            var counter = 0;

            for (var i = 1; i <= 6; i++)
                if (input.Count(element => element == i) >= 2)
                    counter++;

            return counter == 2;
        }

        public IEnumerable<int> GetUniquePairs(IEnumerable<int> input) {
            var pairs = new List<int>();

            for (var i = 1; i <= 6; i++)
                if (input.Count(element => element == i) >= 2)
                    pairs.Add(i);

            return pairs.ToArray();
        }

        public bool HasThreeOfAKind(int[] input) {
            for (var i = 1; i <= 6; i++)
                if (input.Count(element => element == i) >= 3)
                    return true;

            return false;
        }
    }
}