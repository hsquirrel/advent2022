# The Problem

--- Day 3: Rucksack Reorganization ---
One Elf has the important job of loading all of the rucksacks with supplies for the jungle journey. Unfortunately, that Elf didn't quite follow the packing instructions, and so a few items now need to be rearranged.

Each rucksack has two large compartments. All items of a given type are meant to go into exactly one of the two compartments. The Elf that did the packing failed to follow this rule for exactly one item type per rucksack.

The Elves have made a list of all of the items currently in each rucksack (your puzzle input), but they need your help finding the errors. Every item type is identified by a single lowercase or uppercase letter (that is, a and A refer to different types of items).

The list of items for each rucksack is given as characters all on a single line. A given rucksack always has the same number of items in each of its two compartments, so the first half of the characters represent items in the first compartment, while the second half of the characters represent items in the second compartment.

For example, suppose you have the following list of contents from six rucksacks:

vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw
The first rucksack contains the items vJrwpWtwJgWrhcsFMMfFFhFp, which means its first compartment contains the items vJrwpWtwJgWr, while the second compartment contains the items hcsFMMfFFhFp. The only item type that appears in both compartments is lowercase p.
The second rucksack's compartments contain jqHRNqRjqzjGDLGL and rsFMfFZSrLrFZsSL. The only item type that appears in both compartments is uppercase L.
The third rucksack's compartments contain PmmdzqPrV and vPwwTWBwg; the only common item type is uppercase P.
The fourth rucksack's compartments only share item type v.
The fifth rucksack's compartments only share item type t.
The sixth rucksack's compartments only share item type s.
To help prioritize item rearrangement, every item type can be converted to a priority:

Lowercase item types a through z have priorities 1 through 26.
Uppercase item types A through Z have priorities 27 through 52.
In the above example, the priority of the item type that appears in both compartments of each rucksack is 16 (p), 38 (L), 42 (P), 22 (v), 20 (t), and 19 (s); the sum of these is 157.

Find the item type that appears in both compartments of each rucksack. What is the sum of the priorities of those item types?

Your puzzle answer was 7850.

--- Part Two ---
As you finish identifying the misplaced items, the Elves come to you with another issue.

For safety, the Elves are divided into groups of three. Every Elf carries a badge that identifies their group. For efficiency, within each group of three Elves, the badge is the only item type carried by all three Elves. That is, if a group's badge is item type B, then all three Elves will have item type B somewhere in their rucksack, and at most two of the Elves will be carrying any other item type.

The problem is that someone forgot to put this year's updated authenticity sticker on the badges. All of the badges need to be pulled out of the rucksacks so the new authenticity stickers can be attached.

Additionally, nobody wrote down which item type corresponds to each group's badges. The only way to tell which item type is the right one is by finding the one item type that is common between all three Elves in each group.

Every set of three lines in your list corresponds to a single group, but each group can have a different badge item type. So, in the above example, the first group's rucksacks are the first three lines:

vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
And the second group's rucksacks are the next three lines:

wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw
In the first group, the only item type that appears in all three rucksacks is lowercase r; this must be their badges. In the second group, their badge item type must be Z.

Priorities for these items must still be found to organize the sticker attachment efforts: here, they are 18 (r) for the first group and 52 (Z) for the second group. The sum of these is 70.

Find the item type that corresponds to the badges of each three-Elf group. What is the sum of the priorities of those item types?

Your puzzle answer was 2581.

Both parts of this puzzle are complete! They provide two gold stars: **

# The Solutions

## Part 1

For SolutionA1 I recognized that this is a simple set intersection problem so I used the built in
features for performing the necessary set operations. For SolutionA2 I wanted to take advantage of
the fact that we know there can only be 1 item in the intersection and build in some short-circuit
logic once that item is found. For SolutionA3 I wanted to push that short-circuit idea further by
allowing a short-circuit during the building of the sets. SolutionA4 was just a curiosity. I
wondered if not actually tracking the two bins as separate structures could potentially have some
benefits (especially in memory).

I was tempted to try and outdo the performance of using the built-in HashSet with a custom bitmap
implementation (using [flags]Enum in C#). These sorts of set operations can be performed extremely
efficiently with bitwise operations, but I didn't want to spend the time creating a 56 item
bitmap, and I have some concern that mapping the input to the correct enum value would eat up any
gains. I'm still curious though.

Here are the performance results. As suspected, SolutionA1, the first, simplest thing that popped
into my mind once again is the worst of the bunch. SolutionA2 performed admirably and probably has
the best balance of speed and memory in general. SolutionA3 showed once again that if you're
willing to throw memory at it, it's not difficult to squeeze a little more speed out of these
solutions. And SolutionA4 was pretty much a failed experiment.

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i3-1005G1 CPU 1.20GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|     Method |     Mean |   Error |  StdDev | Ratio | RatioSD |     Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|--------:|--------:|------:|--------:|---------:|----------:|------------:|
| SolutionA1 | 185.0 μs | 1.31 μs | 1.23 μs |  1.00 |    0.00 |  99.6094 | 203.81 KB |        1.00 |
| SolutionA2 | 110.6 μs | 0.61 μs | 0.54 μs |  0.60 |    0.01 |  81.4209 | 166.31 KB |        0.82 |
| SolutionA3 | 100.6 μs | 1.50 μs | 2.67 μs |  0.56 |    0.02 | 136.5967 | 279.19 KB |        1.37 |
| SolutionA4 | 129.0 μs | 1.52 μs | 1.42 μs |  0.70 |    0.01 | 126.4648 | 258.51 KB |        1.27 |

## Part 2

SolutionB1 follows the same approach as SolutionA1. It's still as set intersection problem, just
with more sets. SolutionB2 follows the same approach as SolutionA2 and SolutionB3 follows
SolutionA3. The problems are very similar, so my ideas were as well. There is no SolutionB4
because SolutionA4 was a dud.

Here are the performance results. The baseline SolutionB1 wasn't difficult to improve upon. We see
similar improvements in SolutionB2 as we did in SolutionA2, and given what we see next with
SolutionB3, this appears to be the best of the approaches I tried. SolutionB3 surprised me. It
appears that jumping through hoops to try and short circuit during the building of the sets
doesn't pay off when you go from 2 to 3 sets. I suspect it would get even worse as the number of
sets involved increases. The probability of hitting the short-circuit condition drops
precipitously with each additional set, but the amount of work needed to check the conditions
increases. Not a very good combination, and something that I didn't think about up front.

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2251/21H2/November2021Update)
Intel Core i3-1005G1 CPU 1.20GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|     Method |     Mean |   Error |  StdDev | Ratio |     Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|--------:|--------:|------:|---------:|----------:|------------:|
| SolutionB1 | 192.1 μs | 1.30 μs | 1.21 μs |  1.00 |  93.7500 | 191.73 KB |        1.00 |
| SolutionB2 | 124.9 μs | 1.44 μs | 1.13 μs |  0.65 |  83.9844 | 171.95 KB |        0.90 |
| SolutionB3 | 207.6 μs | 1.51 μs | 1.41 μs |  1.08 | 118.8965 | 243.29 KB |        1.27 |


