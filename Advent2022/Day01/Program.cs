using BenchmarkDotNet.Running;
using Day01.Benchmarks;
using Day01.Solutions;

var input = File.ReadAllLines("input.txt");

var answerA1 = new SolutionA1(input).Solve();
Console.WriteLine($"A1 = {answerA1}");
var answerA2 = new SolutionA2(input).Solve();
Console.WriteLine($"A2 = {answerA2}");
var answerB1 = new SolutionB1(input).Solve();
Console.WriteLine($"B1 = {answerB1}");
var answerB2 = new SolutionB2(input).Solve();
Console.WriteLine($"B2 = {answerB2}");
var answerB3 = new SolutionB3(input).Solve();
Console.WriteLine($"B3 = {answerB3}");
var answerB4 = new SolutionB4(input).Solve();
Console.WriteLine($"B4 = {answerB4}");


BenchmarkRunner.Run<SolutionABenchmark>();
BenchmarkRunner.Run<SolutionBBenchmark>();
