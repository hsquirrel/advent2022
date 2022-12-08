namespace Day01.Solutions
{
    public class SolutionA1
    {
        private readonly string[] _input;

        public SolutionA1(string[] input)
        {
            _input = input;
        }

        public int Solve()
        {
            var elves = new List<int> { 0 };
            var currentElf = 0;
            var maxElfCalories = 0;
            foreach(var entry in _input)
            {
                if (string.IsNullOrWhiteSpace(entry))
                {
                    if (elves[currentElf] > maxElfCalories)
                    {
                        maxElfCalories = elves[currentElf];
                    }
                    elves.Add(0);
                    currentElf++;
                    continue;
                }

                elves[currentElf] += Convert.ToInt32(entry);
            }

            return maxElfCalories;
        }
    }
}
