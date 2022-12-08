using BenchmarkDotNet.Attributes;
using Day01.Solutions;

namespace Day01.Benchmarks
{
    [MemoryDiagnoser]
    public class SolutionABenchmark
    {
        private readonly SolutionA1 _solutionA1 = new(File.ReadAllLines("input.txt"));
        private readonly SolutionA2 _solutionA2 = new(File.ReadAllLines("input.txt"));

        [Benchmark(Baseline = true)]
        public int SolutionA1() => _solutionA1.Solve();

        [Benchmark]
        public int SolutionA2() => _solutionA2.Solve();
    }
}
