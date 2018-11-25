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
                /*
                case Categories.Pair:
                    break;
                case Categories.TwoPairs:
                    break;
                case Categories.ThreeOfAKind:
                    break;
                case Categories.SmallStraight:
                    break;
                case Categories.LargeStraight:
                    break;
                case Categories.FullHouse:
                    break;*/
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
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
    }
}