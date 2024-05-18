using BenchmarkDotNet.Running;
using DotNet.Benchmarks;

var serializeSummary = BenchmarkRunner.Run<SerializeTest>();

var cloneInjectionSummary = BenchmarkRunner.Run<CloneInjectionTest>();
