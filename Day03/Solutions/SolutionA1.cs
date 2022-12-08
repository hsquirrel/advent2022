namespace Day03.Solutions
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
                var numItemsPerBin = line.Length / 2;
                var bin1 = line.ToCharArray(0, numItemsPerBin);
                var bin2 = line.ToCharArray(numItemsPerBin, numItemsPerBin);
                var offender = bin1.Intersect(bin2).Single();
                total += ToPriority(offender);
            }

            return total;
        }

        private static int ToPriority(char offender)
        {
            var ascii = (int)offender;
            if (ascii >= 97) return ascii - 96;
            return ascii - 38;
        }
    }
}
