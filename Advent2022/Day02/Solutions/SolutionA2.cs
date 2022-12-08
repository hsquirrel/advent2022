namespace Day02.Solutions
{
    public class SolutionA2
    {
        private readonly string[] _input;

        public SolutionA2(string[] input)
        {
            _input = input;
        }

        public int Solve()
        {
            // 1st dimention is opponent; index 0 = rock, 1 = paper, 2 = scissors
            // 2nd dimention is me; index 0 = rock, 1 = paper, 2 = scissors
            var scores = new int[3, 3]
            {   // me
                // 0 1 2
                {  4,8,3}, //0 0pponent
                {  1,5,9}, //1
                {  7,2,6}  //2
            };

            var totalScore = 0;

            foreach (var line in _input)
            {
                var opponent = ConvertToIndex(line[0]);
                var me = ConvertToIndex(line[2]);

                totalScore += scores[opponent, me];
            }

            return totalScore;
        }

        private static int ConvertToIndex(char input)
        {
            return input switch
            {
                'A' or 'X' => 0,
                'B' or 'Y' => 1,
                'C' or 'Z' => 2,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
