namespace Day03.Solutions
{
    public class SolutionB3
    {
        private readonly string[] _input;

        public SolutionB3(string[] input)
        {
            _input = input;
        }

        public int Solve()
        {
            var total = 0;

            for (var i = 0; i < _input.Length; i += 3)
            {
                var sack1 = _input[i].ToCharArray();
                var sack2 = _input[i + 1].ToCharArray();
                var sack3 = _input[i + 2].ToCharArray();
                var sack1Items = new HashSet<char>(sack1);
                var sack2Items = new HashSet<char>(sack2);
                var sack3Items = new HashSet<char>(sack3);
                var minNumItems = Math.Min(Math.Min(sack1.Length, sack2.Length), sack3.Length);
                for (var j = 0; j < minNumItems; j++)
                {
                    var sack1Item = sack1[j];
                    var sack2Item = sack2[j];
                    var sack3Item = sack3[j];

                    if (sack1Item == sack2Item && sack1Item == sack3Item)
                    {
                        total += ToPriority(sack1Item);
                        break;
                    }

                    if (sack1Items.Contains(sack3Item) && sack2Items.Contains(sack3Item))
                    {
                        total += ToPriority(sack3Item);
                        break;
                    }

                    if (sack1Items.Contains(sack2Item) && sack3Items.Contains(sack2Item))
                    {
                        total += ToPriority(sack2Item);
                        break;
                    }

                    if (sack2Items.Contains(sack1Item) && sack3Items.Contains(sack1Item))
                    {
                        total += ToPriority(sack1Item);
                        break;
                    }

                    sack1Items.Add(sack1Item);
                    sack2Items.Add(sack2Item);
                    sack3Items.Add(sack3Item);
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
