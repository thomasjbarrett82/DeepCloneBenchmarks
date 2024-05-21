using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;

namespace DotNet;

public class Program {
    public static void Main(string[] args) {
        ManualConfig config = ManualConfig
            .Create(DefaultConfig.Instance)
            .AddJob(Job.Dry
                .WithToolchain(InProcessEmitToolchain.DontLogOutput)
                .WithIterationCount(100)
            );
        _ = BenchmarkRunner.Run(typeof(DeepCopyBenchmarks), config, args);
    }
}
