namespace Day03.Solutions
{
    public class SolutionA3
    {
        private readonly string[] _input;

        public SolutionA3(string[] input)
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
                var bin1Items = new HashSet<char>(numItemsPerBin);
                var bin2Items = new HashSet<char>(numItemsPerBin);
                for (var i = 0; i < numItemsPerBin; i++)
                {
                    var bin1Item = bin1[i];
                    var bin2Item = bin2[i];

                    if (bin1Item == bin2Item)
                    {
                        total += ToPriority(bin1Item);
                        break;
                    }

                    if (bin1Items.Contains(bin2Item))
                    {
                        total += ToPriority(bin2Item);
                        break;
                    }

                    if (bin2Items.Contains(bin1Item))
                    {
                        total += ToPriority(bin1Item);
                        break;
                    }

                    bin1Items.Add(bin1Item);
                    bin2Items.Add(bin2Item);
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
