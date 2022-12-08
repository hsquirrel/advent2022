namespace Day01.Solutions
{
    public class SolutionB1
    {
        private readonly string[] _input;

        public SolutionB1(string[] input)
        {
            _input = input;
        }

        public int Solve()
        {
            var elves = new List<int> { 0 };
            var currentElf = 0;
            foreach (var entry in _input)
            {
                if (string.IsNullOrWhiteSpace(entry))
                {
                    elves.Add(0);
                    currentElf++;
                    continue;
                }

                elves[currentElf] += Convert.ToInt32(entry);
            }

            var calories = elves.OrderDescending().Take(3).Sum();

            return calories;
        }
    } 
}
