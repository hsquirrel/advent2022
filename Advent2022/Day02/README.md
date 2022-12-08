# The Problem

--- Day 2: Rock Paper Scissors ---
The Elves begin to set up camp on the beach. To decide whose tent gets to be closest to the snack storage, a giant Rock Paper Scissors tournament is already in progress.

Rock Paper Scissors is a game between two players. Each game contains many rounds; in each round, the players each simultaneously choose one of Rock, Paper, or Scissors using a hand shape. Then, a winner for that round is selected: Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock. If both players choose the same shape, the round instead ends in a draw.

Appreciative of your help yesterday, one Elf gives you an encrypted strategy guide (your puzzle input) that they say will be sure to help you win. "The first column is what your opponent is going to play: A for Rock, B for Paper, and C for Scissors. The second column--" Suddenly, the Elf is called away to help with someone's tent.

The second column, you reason, must be what you should play in response: X for Rock, Y for Paper, and Z for Scissors. Winning every time would be suspicious, so the responses must have been carefully chosen.

The winner of the whole tournament is the player with the highest score. Your total score is the sum of your scores for each round. The score for a single round is the score for the shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors) plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won).

Since you can't be sure if the Elf is trying to help you or trick you, you should calculate the score you would get if you were to follow the strategy guide.

For example, suppose you were given the following strategy guide:

A Y
B X
C Z
This strategy guide predicts and recommends the following:

In the first round, your opponent will choose Rock (A), and you should choose Paper (Y). This ends in a win for you with a score of 8 (2 because you chose Paper + 6 because you won).
In the second round, your opponent will choose Paper (B), and you should choose Rock (X). This ends in a loss for you with a score of 1 (1 + 0).
The third round is a draw with both players choosing Scissors, giving you a score of 3 + 3 = 6.
In this example, if you were to follow the strategy guide, you would get a total score of 15 (8 + 1 + 6).

What would your total score be if everything goes exactly according to your strategy guide?

Your puzzle answer was 11767.

--- Part Two ---
The Elf finishes helping with the tent and sneaks back over to you. "Anyway, the second column says how the round needs to end: X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win. Good luck!"

The total score is still calculated in the same way, but now you need to figure out what shape to choose so the round ends as indicated. The example above now goes like this:

In the first round, your opponent will choose Rock (A), and you need the round to end in a draw (Y), so you also choose Rock. This gives you a score of 1 + 3 = 4.
In the second round, your opponent will choose Paper (B), and you choose Rock so you lose (X) with a score of 1 + 0 = 1.
In the third round, you will defeat your opponent's Scissors with Rock for a score of 1 + 6 = 7.
Now that you're correctly decrypting the ultra top secret strategy guide, you would get a total score of 12.

Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide?

Your puzzle answer was 13886.

Both parts of this puzzle are complete! They provide two gold stars: **

# The Solutions

## Part 1

SolutionA1 simply loops through each line of input, splits apart the two moves, calculates a move
score and outcome score, and adds it to the total score. Very understandable logically, but I knew
this wasn't going to be even close to the the most efficient way of solving the problem.

SolutionA2 ditches the on-the-fly calculations in favor lookups. I precalculate the possible
scores in a 3x3 array, convert the individual moves into indices into the arrary, and then look up
the value to add to the total. I suspected this would be far more efficient.

SolutionA3 is a variant on SolutionA2, only I wondered if I traded off some memory if I could get
more performance by doing a dictionary lookup for the scores on the value of the entire input line
instead of splitting out the moves and converting them to indices into an array.

Here are the performance results. As suspected, SolutionA1 performed the worst. However,
SolutionA2, while faster, wasn't as big of a leap as I was expecting, and it allocated a small
amount of heap memory that I also wasn't expecting. SolutionB3 was significantly faster with the
expected tradeoff of significantly more heap allocation.

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i3-1005G1 CPU 1.20GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|     Method |     Mean |    Error |   StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| SolutionA1 | 41.11 μs | 0.113 μs | 0.094 μs |  1.00 |      - |         - |          NA |
| SolutionA2 | 36.94 μs | 0.152 μs | 0.135 μs |  0.90 |      - |      80 B |          NA |
| SolutionA3 | 29.78 μs | 0.213 μs | 0.199 μs |  0.72 | 0.4578 |     992 B |          NA |

## Part 2

SolutionB1 is essentially SolutionA1 with a preliminary step to determine what the second move
should be. It was quick to code, easy to understand, and had no hope of being the most efficient.

SolutionB2 is the same as SolutionA3 with different precalculated values for the inputs.

Here are the performance results. SolutionB2 is twice as fast as SolutionB1. A significant gain
over the exact same solution in SolutionA3, which makes sense. There are more steps being replaced
by lookup from SolutionB1 to SolutionB2 than SolutionA1 to SolutionA3. This will always be the
case with lookups. The more work you replace, the more valuable the hit to memory will be in terms
of increased speed.

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i3-1005G1 CPU 1.20GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|     Method |     Mean |    Error |   StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| SolutionB1 | 55.24 μs | 0.443 μs | 0.415 μs |  1.00 |      - |         - |          NA |
| SolutionB2 | 28.95 μs | 0.105 μs | 0.088 μs |  0.52 | 0.4578 |     992 B |          NA |
