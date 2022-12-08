namespace Day02.Solutions
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
            var totalScore = 0;

            foreach (var line in _input)
            {
                var opponent = line[0];
                var me = line[2];

                var roundScore = 0;
                roundScore += ShapeScore(me);
                roundScore += OutcomeScore(me, opponent);

                totalScore += roundScore;
            }

            return totalScore;
        }

        private static int ShapeScore(char me)
        {
            return me switch
            {
                'X' => 1,
                'Y' => 2,
                'Z' => 3,
                _ => throw new InvalidOperationException(),
            };
        }

        private static int OutcomeScore(char me, char opponent)
        {
            if (IsWin(me, opponent))
            {
                return 6;
            }
            else if (IsTie(me, opponent))
            {
                return 3;
            }
            else if (IsLoss(me, opponent))
            {
                return 0;
            }
            throw new InvalidOperationException();
        }

        private static bool IsWin(char me, char opponent)
        {
            if (
                me == 'X' && opponent == 'C' ||
                me == 'Y' && opponent == 'A' ||
                me == 'Z' && opponent == 'B'
                )
            {
                return true;
            }
            return false;
        }

        private static bool IsTie(char me, char opponent)
        {
            if (
                me == 'X' && opponent == 'A' ||
                me == 'Y' && opponent == 'B' ||
                me == 'Z' && opponent == 'C'
                )
            {
                return true;
            }
            return false;
        }

        private static bool IsLoss(char me, char opponent)
        {
            if (
                me == 'X' && opponent == 'B' ||
                me == 'Y' && opponent == 'C' ||
                me == 'Z' && opponent == 'A'
                )
            {
                return true;
            }
            return false;
        }
    }
}
