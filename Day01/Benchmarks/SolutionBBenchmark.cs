using BenchmarkDotNet.Attributes;
using Day01.Solutions;

namespace Day01.Benchmarks
{
    [MemoryDiagnoser]
    public class SolutionBBenchmark
    {
        private readonly SolutionB1 _solutionB1 = new(File.ReadAllLines("input.txt"));
        private readonly SolutionB2 _solutionB2 = new(File.ReadAllLines("input.txt"));
        private readonly SolutionB3 _solutionB3 = new(File.ReadAllLines("input.txt"));
        private readonly SolutionB4 _solutionB4 = new(File.ReadAllLines("input.txt"));

        [Benchmark(Baseline = true)]
        public int SolutionB1() => _solutionB1.Solve();

        [Benchmark]
        public int SolutionB2() => _solutionB2.Solve();

        [Benchmark]
        public int SolutionB3() => _solutionB3.Solve();

        [Benchmark]
        public int SolutionB4() => _solutionB4.Solve();
    }
}
