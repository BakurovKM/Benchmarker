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

    [Benchmark(Description = "[]Any")]
    public void Any()
    {
        int[] array = [1,2,3,4,5];
        for (var i = 0; i < _cnt; i++)
        {
            var r = array.Any();
        }
    }
    
    [Benchmark(Description = "[]Length")]
    public void Length()
    {
        int[] array = [1,2,3,4,5];
        for (var i = 0; i < _cnt; i++)
        {
            var r = array.Length != 0;
        }
    }
    
    [Benchmark(Description = "LstCount")]
    public void Count()
    {
        List<int> array = [1,2,3,4,5];
        for (var i = 0; i < _cnt; i++)
        {
            var r = array.Count != 0;
        }
    }
}