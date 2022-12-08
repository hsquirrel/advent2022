namespace Day03.Solutions
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

            for (var i = 0; i < _input.Length; i += 3)
            {
                var sack1 = _input[i].ToCharArray();
                var sack2 = _input[i + 1].ToCharArray();
                var sack3 = _input[i + 2].ToCharArray();
                var offender = sack1.Intersect(sack2).Intersect(sack3).Single();
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
