namespace Day03.Solutions
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

            for (var i = 0; i < _input.Length; i += 3)
            {
                var sack1 = _input[i].ToCharArray();
                var sack2 = _input[i + 1].ToCharArray();
                var sack3 = _input[i + 2].ToCharArray();
                var sack1Items = new HashSet<char>(sack1);
                var sack2Items = new HashSet<char>(sack2);
                foreach (var item in sack3)
                {
                    if (sack1Items.Contains(item) && sack2Items.Contains(item))
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
