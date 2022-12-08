namespace Day02.Solutions
{
    public class SolutionA3
    {
        private readonly string[] _input;

        public SolutionA3(string[] input)
        {
            _input = input;
        }

        public int Solve()
        {
            var scores = new Dictionary<string, int>
            {
                {"A X", 4},
                {"A Y", 8},
                {"A Z", 3},
                {"B X", 1},
                {"B Y", 5},
                {"B Z", 9},
                {"C X", 7},
                {"C Y", 2},
                {"C Z", 6},
            };

            var totalScore = 0;

            foreach (var line in _input)
            {
                totalScore += scores[line];
            }

            return totalScore;
        }
    }
}
