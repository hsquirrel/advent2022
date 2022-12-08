using BenchmarkDotNet.Attributes;
using Day03.Solutions;

namespace Day03.Benchmarks
{
    [MemoryDiagnoser]
    public class SolutionABenchmark
    {
        private readonly SolutionA1 _solutionA1 = new(File.ReadAllLines("input.txt"));
        private readonly SolutionA2 _solutionA2 = new(File.ReadAllLines("input.txt"));
        private readonly SolutionA3 _solutionA3 = new(File.ReadAllLines("input.txt"));
        private readonly SolutionA4 _solutionA4 = new(File.ReadAllLines("input.txt"));

        [Benchmark(Baseline = true)]
        public int SolutionA1() => _solutionA1.Solve();

        [Benchmark]
        public int SolutionA2() => _solutionA2.Solve();

        [Benchmark]
        public int SolutionA3() => _solutionA3.Solve();

        [Benchmark]
        public int SolutionA4() => _solutionA4.Solve();
    }
}
