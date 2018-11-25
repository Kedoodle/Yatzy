using System.Collections.Generic;
using System.Linq;

namespace Yatzy {
    public class ScoreCalculator {
        
        
        
        public int CalculateChanceScore(IEnumerable<int> input) {
            return input.Sum();
        }

        public int CalculateYatzyScore(int[] input) {
            var firstRoll = input[0];
            return input.Any(num => num != firstRoll) ? 0 : 50;
        }
    }
}