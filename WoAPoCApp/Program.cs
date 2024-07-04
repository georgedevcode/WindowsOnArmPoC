using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using WoAPoCApp;

class Program
{
    static void Main(string[] args) {


        var config = ManualConfig.Create(DefaultConfig.Instance);

        config.AddJob(Job.Default.WithToolchain(InProcessEmitToolchain.Instance));

        BenchmarkRunner.Run<DemoPoC>(config);

    }
}
