namespace Day04.Solutions
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
            var total = 0;

            foreach (var line in _input)
            {
                ParseBoundaries(line, 
                    out int leftMin, out int leftMax, 
                    out int rightMin, out int rightMax);
                if (OverlapExists(leftMin, leftMax, rightMin, rightMax)) total++;
            }

            return total;
        }

        private static void ParseBoundaries(ReadOnlySpan<char> line, out int leftMin, out int leftMax, out int rightMin, out int rightMax)
        {
            var seperatorLocation = line.IndexOf(',');
            var leftRange = line[..seperatorLocation];
            var rightRange = line[(seperatorLocation + 1)..];

            seperatorLocation = leftRange.IndexOf('-');
            leftMin = Convert.ToInt32(leftRange[..seperatorLocation].ToString());
            leftMax = Convert.ToInt32(leftRange[(seperatorLocation + 1)..].ToString());

            seperatorLocation = rightRange.IndexOf('-');
            rightMin = Convert.ToInt32(rightRange[..seperatorLocation].ToString());
            rightMax = Convert.ToInt32(rightRange[(seperatorLocation + 1)..].ToString());
        }

        private static bool OverlapExists(int leftMin, int leftMax, int rightMin, int rightMax)
        {
            if (leftMin <= rightMax && leftMax >= rightMin) return true;
            return false;
        }
    }
}
