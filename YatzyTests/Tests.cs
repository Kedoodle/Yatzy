using Xunit;
using Yatzy;

namespace YatzyTests {
    public class ScoreCalculatorShould {
        [Theory]
        [InlineData(new[] {1, 1, 3, 3, 6}, 14)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 21)]
        public void TakeIntArrayAndReturnScoreForChance(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.Calculate(Categories.Chance, input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {1, 1, 1, 1, 1}, 50)]
        [InlineData(new[] {2, 2, 2, 2, 2}, 50)]
        [InlineData(new[] {1, 1, 1, 2, 1}, 0)]
        public void TakeIntArrayAndReturnScoreForYatzy(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.Calculate(Categories.Yatzy, input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Categories.Ones, new[] {3, 3, 3, 4, 5}, 0)]
        [InlineData(Categories.Twos, new[] {2, 3, 2, 5, 1}, 4)]
        [InlineData(Categories.Threes, new[] {2, 3, 2, 5, 1}, 3)]
        [InlineData(Categories.Fours, new[] {1, 1, 2, 4, 4}, 8)]
        [InlineData(Categories.Fives, new[] {2, 3, 2, 5, 1}, 5)]
        [InlineData(Categories.Sixes, new[] {2, 3, 2, 5, 1}, 0)]
        public void TakeIntArrayAndReturnScoreForNums(Categories category, int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.Calculate(category, input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4})]
        [InlineData(new[] {3, 2, 1, 5, 5})]
        [InlineData(new[] {6, 6, 1, 2, 3})]
        [InlineData(new[] {6, 1, 1, 2, 3})]
        public void TakeIntArrayAndReturnsTrueIfPair(int[] input) {
            var scoreCalculator = new ScoreCalculator();
            var hasPair = scoreCalculator.HasPair(input);

            Assert.True(hasPair);
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4}, 4)]
        [InlineData(new[] {3, 3, 3, 5, 5}, 5)]
        [InlineData(new[] {3, 2, 1, 5, 6}, 0)]
        public void TakeIntArrayAndReturnHighestPair(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.GetHighestPair(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4}, 8)]
        [InlineData(new[] {3, 3, 3, 2, 2}, 6)]
        [InlineData(new[] {3, 1, 5, 6, 4}, 0)]
        public void TakeIntArrayAndReturnScoreForPair(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.Calculate(Categories.Pair, input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4}, true)]
        [InlineData(new[] {3, 3, 3, 2, 2}, true)]
        [InlineData(new[] {3, 1, 5, 6, 4}, false)]
        public void TakeIntArrayAndReturnsBoolIfHasTwoUniquePairs(int[] input, bool expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.HasTwoUniquePairs(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4}, new[] {3, 4})]
        [InlineData(new[] {3, 3, 3, 2, 2}, new[] {2, 3})]
        [InlineData(new[] {3, 1, 5, 6, 4}, new int[] { })]
        public void TakeIntArrayAndReturnsUniquePairs(int[] input, int[] expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.GetUniquePairs(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4}, 14)]
        [InlineData(new[] {3, 3, 3, 2, 2}, 10)]
        [InlineData(new[] {3, 1, 5, 6, 4}, 0)]
        public void TakeIntArrayAndReturnsScoreForTwoPairs(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.Calculate(Categories.TwoPairs, input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4}, 9)]
        [InlineData(new[] {3, 3, 2, 2, 2}, 6)]
        [InlineData(new[] {3, 1, 5, 6, 4}, 0)]
        public void TakeIntArrayAndReturnsBoolIfHasThreeOfAKind(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.Calculate(Categories.ThreeOfAKind, input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {2, 2, 2, 2, 5}, 8)]
        [InlineData(new[] {2, 2, 2, 5, 5}, 0)]
        [InlineData(new[] {2, 2, 2, 2, 2}, 8)]
        public void TakeIntArrayAndReturnsScoreForFourOfAKind(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.Calculate(Categories.FourOfAKind, input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {1,1,2,2,2}, 8)]
        [InlineData(new[] {2,2,3,3,4}, 0)]
        [InlineData(new[] {4,4,4,4,4}, 0)]
        public void TakeIntArrayAndReturnsScoreForFullHouse(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.Calculate(Categories.FullHouse, input);
            Assert.Equal(expected, actual);
        }
    }
}