using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Day01.Solutions
{
    public class SolutionB4
    {
        private readonly string[] _input;

        public SolutionB4(string[] input)
        {
            _input = input;
        }

        public int Solve()
        {
            int includedMax = 0, includedMid =0, includedMin = 0;

            var currentElfCalories = 0;
            ref var searchSpace = ref MemoryMarshal.GetArrayDataReference(_input);
            var lengthMinusOne = _input.Length - 1;
            for (var i = 0; i <= lengthMinusOne; i++)
            {
                var entry = Unsafe.Add(ref searchSpace, i);
                if (entry == string.Empty)
                {
                    IncludeIfShould(ref includedMax, ref includedMid, ref includedMin, currentElfCalories);
                    currentElfCalories = 0;
                    continue;
                }

                currentElfCalories += Convert.ToInt32(entry);
                if (i == lengthMinusOne)
                {
                    IncludeIfShould(ref includedMax, ref includedMid, ref includedMin, currentElfCalories);
                }
            }

            return includedMax + includedMid + includedMin;
        }

        private static void IncludeIfShould(ref int includedMax, ref int includedMid, ref int includedMin, int currentElfCalories)
        {
            if (currentElfCalories <= includedMin) return;
            if (currentElfCalories > includedMax)
            {
                includedMin = includedMid;
                includedMid = includedMax;
                includedMax = currentElfCalories;
            }
            else if (currentElfCalories > includedMid)
            {
                includedMin = includedMid;
                includedMid = currentElfCalories;
            }
            else if (currentElfCalories > includedMin)
            {
                includedMin = currentElfCalories;
            }
        }
    } 
}
