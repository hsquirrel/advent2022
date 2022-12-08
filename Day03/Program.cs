using BenchmarkDotNet.Running;
using Day03.Benchmarks;
using Day03.Solutions;

var input = File.ReadAllLines("input.txt");

var answerA1 = new SolutionA1(input).Solve();
Console.WriteLine($"A1 = {answerA1}");
var answerA2 = new SolutionA2(input).Solve();
Console.WriteLine($"A2 = {answerA2}");
var answerA3 = new SolutionA3(input).Solve();
Console.WriteLine($"A3 = {answerA3}");
var answerA4 = new SolutionA4(input).Solve();
Console.WriteLine($"A4 = {answerA4}");
var answerB1 = new SolutionB1(input).Solve();
Console.WriteLine($"B1 = {answerB1}");
var answerB2 = new SolutionB2(input).Solve();
Console.WriteLine($"B2 = {answerB2}");
var answerB3 = new SolutionB3(input).Solve();
Console.WriteLine($"B3 = {answerB3}");

BenchmarkRunner.Run<SolutionABenchmark>();
BenchmarkRunner.Run<SolutionBBenchmark>();
