namespace Day03.Solutions
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
            var total = 0;

            foreach (var line in _input)
            {
                var numItemsPerBin = line.Length / 2;
                var bin1 = line.ToCharArray(0, numItemsPerBin);
                var bin2 = line.ToCharArray(numItemsPerBin, numItemsPerBin);
                var bin1Items = new HashSet<char>(bin1);
                foreach (var item in bin2)
                {
                    if (bin1Items.Contains(item))
                    {
                        total += ToPriority(item);
                        break;
                    }
                }
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
