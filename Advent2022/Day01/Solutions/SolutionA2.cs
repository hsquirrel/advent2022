namespace Day01.Solutions
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
            var currentElfCalories = 0;
            var maxElfCalories = 0;
            for (var i = 0; i < _input.Length; i++)
            {
                var entry = _input[i];
                if (string.IsNullOrWhiteSpace(entry))
                {
                    if (currentElfCalories > maxElfCalories)
                    {
                        maxElfCalories = currentElfCalories;
                    }
                    currentElfCalories = 0;
                    continue;
                }

                currentElfCalories += Convert.ToInt32(entry);
                if (i == _input.Length - 1)
                {
                    if (currentElfCalories > maxElfCalories)
                    {
                        maxElfCalories = currentElfCalories;
                    }
                }
            }

            return maxElfCalories;
        }
    }
}
