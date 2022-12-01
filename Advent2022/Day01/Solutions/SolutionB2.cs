namespace Day01.Solutions
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
            var numberOfElvesToInclude = 3;
            var included = new LinkedList<int>();
            for (var i = 0; i < numberOfElvesToInclude; i++)
            {
                included.AddLast(0);
            }

            var currentElfCalories = 0;
            for (var i = 0; i < _input.Length; i++)
            {
                var entry = _input[i];
                if (entry == string.Empty)
                {
                    IncludeIfShould(included, currentElfCalories);
                    currentElfCalories = 0;
                    continue;
                }

                currentElfCalories += Convert.ToInt32(entry);
                if (i == _input.Length - 1) IncludeIfShould(included, currentElfCalories);
            }

            var totalCalories = 0;
            foreach(var elf in included)
            {
                totalCalories += elf;
            }

            return totalCalories;
        }

        private static void IncludeIfShould(LinkedList<int> included, int value)
        {
            if (included.First == null) return;
            if (value <= included.First.Value) return;
            
            var includeAfter = included.First;
            while (includeAfter.Next != null && value > includeAfter.Next.Value)
            {
                includeAfter = includeAfter.Next;
            }
            included.AddAfter(includeAfter, value);
            included.RemoveFirst();
        }
    } 
}
