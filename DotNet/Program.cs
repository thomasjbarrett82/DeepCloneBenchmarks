using BenchmarkDotNet.Running;
using DotNet;

var serializeSummary = BenchmarkRunner.Run<SerializeTest>();

var cloneInjectionSummary = BenchmarkRunner.Run<CloneInjectionTest>();
