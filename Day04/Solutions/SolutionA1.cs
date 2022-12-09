namespace Day04.Solutions
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
            var total = 0;

            foreach (var line in _input)
            {
                var ranges = line.Split(',');
                if (SubsetExists(ranges[0], ranges[1])) total++;
            }

            return total;
        }

        private static bool SubsetExists(string leftRange, string rightRange)
        {
            var leftBoundaries = leftRange.Split('-');
            var leftMin = Convert.ToInt32(leftBoundaries[0]);
            var leftMax = Convert.ToInt32(leftBoundaries[1]);
            var rightBoundaries = rightRange.Split('-');
            var rightMin = Convert.ToInt32(rightBoundaries[0]);
            var rightMax = Convert.ToInt32(rightBoundaries[1]);
            if (leftMin <= rightMin && leftMax >= rightMax) return true;
            if (rightMin <= leftMin && rightMax >= leftMax) return true;
            return false;
        }
    }
}
