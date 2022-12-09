namespace Day04.Solutions
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
            var total = 0;

            foreach (var line in _input)
            {
                var ranges = line.Split(',');
                if (OverlapExists(ranges[0], ranges[1])) total++;
            }

            return total;
        }

        private static bool OverlapExists(string leftRange, string rightRange)
        {
            var leftBoundaries = leftRange.Split('-');
            var leftMin = Convert.ToInt32(leftBoundaries[0]);
            var leftMax = Convert.ToInt32(leftBoundaries[1]);
            var rightBoundaries = rightRange.Split('-');
            var rightMin = Convert.ToInt32(rightBoundaries[0]);
            var rightMax = Convert.ToInt32(rightBoundaries[1]);
            if (leftMin <= rightMax && leftMax >= rightMin) return true;
            return false;
        }
    }
}
