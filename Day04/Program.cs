using BenchmarkDotNet.Running;
using Day04.Benchmarks;
using Day04.Solutions;

var input = File.ReadAllLines("input.txt");

var answerA1 = new SolutionA1(input).Solve();
Console.WriteLine($"A1 = {answerA1}");
var answerA2 = new SolutionA2(input).Solve();
Console.WriteLine($"A2 = {answerA2}");
var answerB1 = new SolutionB1(input).Solve();
Console.WriteLine($"B1 = {answerB1}");
var answerB2 = new SolutionB2(input).Solve();
Console.WriteLine($"B2 = {answerB2}");

BenchmarkRunner.Run<SolutionABenchmark>();
BenchmarkRunner.Run<SolutionBBenchmark>();
