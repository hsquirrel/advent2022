namespace Day02.Solutions
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
            var totalScore = 0;

            foreach (var line in _input)
            {
                var opponent = line[0];
                var outcome = line[2];
                var me = ChooseAttack(opponent, outcome);

                var roundScore = 0;
                roundScore += ShapeScore(me);
                roundScore += OutcomeScore(me, opponent);

                totalScore += roundScore;
            }

            return totalScore;
        }

        private static char ChooseAttack(char opponent, char outcome)
        {
            return outcome switch
            {
                'X' => ChooseLosingAttack(opponent),
                'Y' => ChooseDrawingAttack(opponent),
                'Z' => ChooseWinningAttack(opponent),
                _ => throw new InvalidOperationException(),
            };
        }

        private static char ChooseLosingAttack(char opponent)
        {
            return opponent switch
            {
                'A' => 'Z',
                'B' => 'X',
                'C' => 'Y',
                _ => throw new InvalidOperationException(),
            };
        }

        private static char ChooseDrawingAttack(char opponent)
        {
            return opponent switch
            {
                'A' => 'X',
                'B' => 'Y',
                'C' => 'Z',
                _ => throw new InvalidOperationException(),
            };
        }

        private static char ChooseWinningAttack(char opponent)
        {
            return opponent switch
            {
                'A' => 'Y',
                'B' => 'Z',
                'C' => 'X',
                _ => throw new InvalidOperationException(),
            };
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
