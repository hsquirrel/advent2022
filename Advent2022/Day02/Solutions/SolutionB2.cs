namespace Day02.Solutions
{
    public class SolutionB2
    {
        private readonly string[] _input;

        public SolutionB2(string[] input)
        {
            _input = input;
        }

        public int Solve()
        {
            var scores = new Dictionary<string, int>
            {
                {"A X", 3},
                {"A Y", 4},
                {"A Z", 8},
                {"B X", 1},
                {"B Y", 5},
                {"B Z", 9},
                {"C X", 2},
                {"C Y", 6},
                {"C Z", 7},
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
