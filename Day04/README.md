# The Problem

--- Day 4: Camp Cleanup ---
Space needs to be cleared before the last supplies can be unloaded from the ships, and so several Elves have been assigned the job of cleaning up sections of the camp. Every section has a unique ID number, and each Elf is assigned a range of section IDs.

However, as some of the Elves compare their section assignments with each other, they've noticed that many of the assignments overlap. To try to quickly find overlaps and reduce duplicated effort, the Elves pair up and make a big list of the section assignments for each pair (your puzzle input).

For example, consider the following list of section assignment pairs:

2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8
For the first few pairs, this list means:

Within the first pair of Elves, the first Elf was assigned sections 2-4 (sections 2, 3, and 4), while the second Elf was assigned sections 6-8 (sections 6, 7, 8).
The Elves in the second pair were each assigned two sections.
The Elves in the third pair were each assigned three sections: one got sections 5, 6, and 7, while the other also got 7, plus 8 and 9.
This example list uses single-digit section IDs to make it easier to draw; your actual list might contain larger numbers. Visually, these pairs of section assignments look like this:

.234.....  2-4
.....678.  6-8

.23......  2-3
...45....  4-5

....567..  5-7
......789  7-9

.2345678.  2-8
..34567..  3-7

.....6...  6-6
...456...  4-6

.23456...  2-6
...45678.  4-8
Some of the pairs have noticed that one of their assignments fully contains the other. For example, 2-8 fully contains 3-7, and 6-6 is fully contained by 4-6. In pairs where one assignment fully contains the other, one Elf in the pair would be exclusively cleaning sections their partner will already be cleaning, so these seem like the most in need of reconsideration. In this example, there are 2 such pairs.

In how many assignment pairs does one range fully contain the other?

Your puzzle answer was 573.

--- Part Two ---
It seems like there is still quite a bit of duplicate work planned. Instead, the Elves would like to know the number of pairs that overlap at all.

In the above example, the first two pairs (2-4,6-8 and 2-3,4-5) don't overlap, while the remaining four pairs (5-7,7-9, 2-8,3-7, 6-6,4-6, and 2-6,4-8) do overlap:

5-7,7-9 overlaps in a single section, 7.
2-8,3-7 overlaps all of the sections 3 through 7.
6-6,4-6 overlaps in a single section, 6.
2-6,4-8 overlaps in sections 4, 5, and 6.
So, in this example, the number of overlapping assignment pairs is 4.

In how many assignment pairs do the ranges overlap?

Your puzzle answer was 867.

Both parts of this puzzle are complete! They provide two gold stars: **

# The Solutions

## Part 1

SolutionA1 is a simple approach where you compare the endpoints of the ranges for the two cases
where a subset can exist (the left is a subset of the right, or the right is a subset of the
left). For SolutionA2 I realized that the problem itself is extremely simply and in the end I
don't know of a way to eliminate converting the input to ints and doing the comparisons. So I
needed to optimize elswhere, and it was pretty easy to spot a quick win. There's lots of string
parsing in this problem. Splitting each line into constituent parts to get to the numbers of
interest. This was causing a lot of string alocations for strings that I only needed temporarily
to get to the next string to break down, and so on. This is where `Span<T>` shines, so this
solution replaces the string manipulation with Span manipulation.

Here are the performance results. I'm still don't think about `Span<T>` as often as I should. It
was an incredibly easy optimization with a huge payoff.

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i3-1005G1 CPU 1.20GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|     Method |     Mean |   Error |  StdDev | Ratio |     Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|--------:|--------:|------:|---------:|----------:|------------:|
| SolutionA1 | 170.7 μs | 1.12 μs | 1.05 μs |  1.00 | 146.9727 | 300.27 KB |        1.00 |
| SolutionA2 | 104.0 μs | 0.88 μs | 0.82 μs |  0.61 |  58.9600 | 120.59 KB |        0.40 |

## Part 2

SolutionB1 uses SolutionA1 as a starting point except the endpoint checks are easier if only
checking for an overlap instead of a subset. SolutionB2 takes the same `Span<T>` approach as
SolutionA2.

Here are the performance results. As mentioned above, `Span<T>` for the win.

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i3-1005G1 CPU 1.20GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|     Method |      Mean |    Error |   StdDev | Ratio |     Gen0 | Allocated | Alloc Ratio |
|----------- |----------:|---------:|---------:|------:|---------:|----------:|------------:|
| SolutionB1 | 168.92 μs | 1.227 μs | 1.088 μs |  1.00 | 146.9727 | 300.27 KB |        1.00 |
| SolutionB2 |  97.99 μs | 1.213 μs | 1.134 μs |  0.58 |  58.9600 | 120.59 KB |        0.40 |
