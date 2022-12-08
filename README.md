# Advent of Code 2022

These are my solutions, written in C# on .NET 7, to the 
[Advent of Code 2022](https://adventofcode.com/2022) challenge.

My idea is to write the very first solution that comes to mind (SolutionA1 for the first problem 
of the day and SolutionB1 for the second) and then attempt a few different approaches looking for
either more elegant or more efficient solutions. I utilize the BenchmarkDotNet toolset to measure
the efficiency of each solution.

I have no interest competing on any leaderboards. This is just for fun, and as such, I will only be
working on solutions when I have some spare time that I feel like dedicating to it. I definitely
will not be keeping pace with the calendar. However, the fun is in the solving, so I will not be
looking at anyone else's solutions until I have finished the day's challenge myself.

I talk a little about about each day's solutions in that day's readme, but I've included the
performance results here because they are fun to look at. They mean absolutely nothing out of
context, but so be it.

## [Day 1](./Day01/)

|     Method |     Mean |    Error |   StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| SolutionA1 | 34.57 μs | 0.328 μs | 0.307 μs |  1.00 | 1.0376 |    2232 B |        1.00 |
| SolutionA2 | 32.93 μs | 0.101 μs | 0.094 μs |  0.95 |      - |         - |        0.00 |

|     Method |     Mean |    Error |   StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| SolutionB1 | 37.90 μs | 0.329 μs | 0.308 μs |  1.00 | 2.0752 |    4424 B |        1.00 |
| SolutionB2 | 30.35 μs | 0.094 μs | 0.073 μs |  0.80 | 0.4272 |     904 B |        0.20 |
| SolutionB3 | 29.10 μs | 0.099 μs | 0.082 μs |  0.77 |      - |         - |        0.00 |
| SolutionB4 | 27.99 μs | 0.086 μs | 0.080 μs |  0.74 |      - |         - |        0.00 |

## [Day 2](./Day02/)

|     Method |     Mean |    Error |   StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| SolutionA1 | 41.11 μs | 0.113 μs | 0.094 μs |  1.00 |      - |         - |          NA |
| SolutionA2 | 36.94 μs | 0.152 μs | 0.135 μs |  0.90 |      - |      80 B |          NA |
| SolutionA3 | 29.78 μs | 0.213 μs | 0.199 μs |  0.72 | 0.4578 |     992 B |          NA |

|     Method |     Mean |    Error |   StdDev | Ratio |   Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| SolutionB1 | 55.24 μs | 0.443 μs | 0.415 μs |  1.00 |      - |         - |          NA |
| SolutionB2 | 28.95 μs | 0.105 μs | 0.088 μs |  0.52 | 0.4578 |     992 B |          NA |

## [Day 3](./day03/)

|     Method |     Mean |   Error |  StdDev | Ratio | RatioSD |     Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|--------:|--------:|------:|--------:|---------:|----------:|------------:|
| SolutionA1 | 185.0 μs | 1.31 μs | 1.23 μs |  1.00 |    0.00 |  99.6094 | 203.81 KB |        1.00 |
| SolutionA2 | 110.6 μs | 0.61 μs | 0.54 μs |  0.60 |    0.01 |  81.4209 | 166.31 KB |        0.82 |
| SolutionA3 | 100.6 μs | 1.50 μs | 2.67 μs |  0.56 |    0.02 | 136.5967 | 279.19 KB |        1.37 |
| SolutionA4 | 129.0 μs | 1.52 μs | 1.42 μs |  0.70 |    0.01 | 126.4648 | 258.51 KB |        1.27 |

|     Method |     Mean |   Error |  StdDev | Ratio |     Gen0 | Allocated | Alloc Ratio |
|----------- |---------:|--------:|--------:|------:|---------:|----------:|------------:|
| SolutionB1 | 192.1 μs | 1.30 μs | 1.21 μs |  1.00 |  93.7500 | 191.73 KB |        1.00 |
| SolutionB2 | 124.9 μs | 1.44 μs | 1.13 μs |  0.65 |  83.9844 | 171.95 KB |        0.90 |
| SolutionB3 | 207.6 μs | 1.51 μs | 1.41 μs |  1.08 | 118.8965 | 243.29 KB |        1.27 |
