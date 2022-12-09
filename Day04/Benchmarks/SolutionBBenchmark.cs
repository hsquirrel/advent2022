using BenchmarkDotNet.Attributes;
using Day04.Solutions;

namespace Day04.Benchmarks
{
    [MemoryDiagnoser]
    public class SolutionBBenchmark
    {
        private readonly SolutionB1 _solutionB1 = new(File.ReadAllLines("input.txt"));
        private readonly SolutionB2 _solutionB2 = new(File.ReadAllLines("input.txt"));

        [Benchmark(Baseline = true)]
        public int SolutionB1() => _solutionB1.Solve();

        [Benchmark]
        public int SolutionB2() => _solutionB2.Solve();
    }
}
