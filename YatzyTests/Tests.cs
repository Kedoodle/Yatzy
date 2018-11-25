using Xunit;
using Yatzy;

namespace YatzyTests {
    public class ScoreCalculatorShould {
        [Theory]
        [InlineData(new[] {1, 1, 3, 3, 6}, 14)]
        [InlineData(new[] {4, 5, 5, 6, 1}, 21)]
        public void TakeIntArrayAndReturnScoreForChance(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.CalculateChanceScore(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] {1, 1, 1, 1, 1}, 50)]
        [InlineData(new[] {2, 2, 2, 2, 2}, 50)]
        [InlineData(new[] {1, 1, 1, 2, 1}, 0)]
        public void TakeIntArrayAndReturnScoreForYatzy(int[] input, int expected) {
            var scoreCalculator = new ScoreCalculator();
            var actual = scoreCalculator.CalculateYatzyScore(input);
            Assert.Equal(expected, actual);
        }
    }
}