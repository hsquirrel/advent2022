# The Problem

--- Day 1: Calorie Counting ---
Santa's reindeer typically eat regular reindeer food, but they need a lot of magical energy to deliver presents on Christmas. For that, their favorite snack is a special type of star fruit that only grows deep in the jungle. The Elves have brought you on their annual expedition to the grove where the fruit grows.

To supply enough magical energy, the expedition needs to retrieve a minimum of fifty stars by December 25th. Although the Elves assure you that the grove has plenty of fruit, you decide to grab any fruit you see along the way, just in case.

Collect stars by solving puzzles. Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

The jungle must be too overgrown and difficult to navigate in vehicles or access from the air; the Elves' expedition traditionally goes on foot. As your boats approach land, the Elves begin taking inventory of their supplies. One important consideration is food - in particular, the number of Calories each Elf is carrying (your puzzle input).

The Elves take turns writing down the number of Calories contained by the various meals, snacks, rations, etc. that they've brought with them, one item per line. Each Elf separates their own inventory from the previous Elf's inventory (if any) by a blank line.

For example, suppose the Elves finish writing their items' Calories and end up with the following list:

1000
2000
3000

4000

5000
6000

7000
8000
9000

10000
This list represents the Calories of the food carried by five Elves:

The first Elf is carrying food with 1000, 2000, and 3000 Calories, a total of 6000 Calories.
The second Elf is carrying one food item with 4000 Calories.
The third Elf is carrying food with 5000 and 6000 Calories, a total of 11000 Calories.
The fourth Elf is carrying food with 7000, 8000, and 9000 Calories, a total of 24000 Calories.
The fifth Elf is carrying one food item with 10000 Calories.
In case the Elves get hungry and need extra snacks, they need to know which Elf to ask: they'd like to know how many Calories are being carried by the Elf carrying the most Calories. In the example above, this is 24000 (carried by the fourth Elf).

Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?

Your puzzle answer was 67633.

--- Part Two ---
By the time you calculate the answer to the Elves' question, they've already realized that the Elf carrying the most Calories of food might eventually run out of snacks.

To avoid this unacceptable situation, the Elves would instead like to know the total Calories carried by the top three Elves carrying the most Calories. That way, even if one of those Elves runs out of snacks, they still have two backups.

In the example above, the top three Elves are the fourth Elf (with 24000 Calories), then the third Elf (with 11000 Calories), then the fifth Elf (with 10000 Calories). The sum of the Calories carried by these three elves is 45000.

Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?

Your puzzle answer was 199628.

Both parts of this puzzle are complete! They provide two gold stars: **

# The Solutions

## Part 1

SolutionA1 is a simple loop in which I add up each individual elf's calories replacing the maximum
calories if the current elf's is more. It's worth noting here that I have a bug in this solution.
The input does not have an empty line at the end, so if the maximum had been the last elf, this
would give the wrong answer. I noticed the defect while working on other solutions, but chose to
leave it here because it was honestly the solution I used to submit my answer.

SolutionA2 is based on SolutionA1, only I fixed the aforementioned bug and stopped storing the
individual elf results since they are not needed for the final answer.

Here are the performance results. SolutionA2 in slightly faster, and doesn't need any heap
allocation.

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i3-1005G1 CPU 1.20GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|     Method |     Mean |    Error |   StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| SolutionA1 | 34.57 μs | 0.328 μs | 0.307 μs |  1.00 | 1.0376 |    2232 B |        1.00 |
| SolutionA2 | 32.93 μs | 0.101 μs | 0.094 μs |  0.95 |      - |         - |        0.00 |

## Part 2

SolutionB1 again simply loops through all the input, storing each elf's value, sorts them all
descending and takes the top 3. Since I based this off of SolutionA1, it suffers from the same
defect as mentioned above, and I chose to leave it that way for posterity.

SolutionB2 uses a configurable number of elves to include (making it the most flexible of the
solutions) to set up a doubly-linked list representing the top n values. As each elf's value is
calculated, it is inserted in the proper position in the list if it should be included in the top
n and the lowest value is removed. The final value is made by adding up the values that ended up
in the list.

SolutionB3 ditches the configurablility/flexability of the linked list for a solution hard coded
to have 3 top spots. However, the logic is still essentially the same as SolutionB2. The idea here
was primarily to optimize memory.

SolutionB4 is the same as SolutionB3 except it uses a pretty gimmicky way of looping that can eek
out the slightest performance advantages. Thanks to [this video](https://youtu.be/cwBrWn4m9y8)
from Nick Chapsas for introducing me to the concept. I'm pretty sure I will NEVER do this in my
professional life, but it was fun to play around with.

Here are the performance results. Each iteration was indeed an approvement on the previous. Yes,
SolutionB4's insane looping construct is in fact faster. Utterly obscure, but faster.

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i3-1005G1 CPU 1.20GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|     Method |     Mean |    Error |   StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| SolutionB1 | 37.90 μs | 0.329 μs | 0.308 μs |  1.00 | 2.0752 |    4424 B |        1.00 |
| SolutionB2 | 30.35 μs | 0.094 μs | 0.073 μs |  0.80 | 0.4272 |     904 B |        0.20 |
| SolutionB3 | 29.10 μs | 0.099 μs | 0.082 μs |  0.77 |      - |         - |        0.00 |
| SolutionB4 | 27.99 μs | 0.086 μs | 0.080 μs |  0.74 |      - |         - |        0.00 |
