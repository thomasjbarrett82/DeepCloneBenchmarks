using BenchmarkDotNet.Running;

namespace DotNet;

public class Program {
    public static void Main(string[] args) {
        var summary = BenchmarkRunner.Run<DeepCopyBenchmarks>();
    }
}
