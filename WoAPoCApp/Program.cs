using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using BenchmarkDotNet.Diagnosers;
using WoAPoCApp;
using Microsoft.VSDiagnostics;

class Program
{
    static void Main(string[] args) {

        var config = ManualConfig.Create(DefaultConfig.Instance)
            .AddJob(Job.Default.WithToolchain(InProcessEmitToolchain.Instance));

        BenchmarkRunner.Run<DemoPoC>(config);

    }
}
