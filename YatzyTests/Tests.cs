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
        
        
    }
}