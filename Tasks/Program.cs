using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<MyBenchmark>();
    }
}

[MemoryDiagnoser]
public class MyBenchmark
{
    private const int _cnt = 1000000;
    
    [Benchmark(Description = "AwaitTask")]
    public async Task AwaitTask()
    {
        var array = new int[_cnt];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = await AwaitTask(i);
        }
    }
    
    [Benchmark(Description = "AwaitValueTask")]
    public async Task AwaitValueTask()
    {
        var array = new int[_cnt];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = await AwaitValueTask(i);
        }
    }

    [Benchmark(Description = "NoAwaitTask")]
    public async Task NoAwaitTask()
    {
        var array = new int[_cnt];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = await NoAwaitTask(i);
        }
    }
 
    private async Task<int> AwaitTask(int i)
    {
        return await Task.FromResult(i);
    }
    
    private async ValueTask<int> AwaitValueTask(int i)
    {
        return await ValueTask.FromResult(i);
    }
    
    private Task<int> NoAwaitTask(int i)
    {
        return Task.FromResult(i);
    }
}