namespace Day03.Solutions
{
    public class SolutionA4
    {
        private readonly string[] _input;

        public SolutionA4(string[] input)
        {
            _input = input;
        }

        public int Solve()
        {
            var total = 0;

            foreach (var line in _input)
            {
                var numItemsPerBin = line.Length / 2;
                var items = line.ToCharArray();

                var seenItems = new Dictionary<char, int>(); //<item, bin>
                for (var i = 0; i < numItemsPerBin; i++)
                {
                    var item1 = items[i];
                    var item2 = items[i + numItemsPerBin];
                    if (item1 == item2)
                    {
                        total += ToPriority(item1);
                        break;
                    }
                    if (seenItems.ContainsKey(item1) && seenItems[item1] != 1)
                    {
                        total += ToPriority(item1);
                        break;
                    }
                    if (seenItems.ContainsKey(item2) && seenItems[item2] != 2)
                    {
                        total += ToPriority(item2);
                        break;
                    }
                    seenItems[item1] = 1;
                    seenItems[item2] = 2;
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
