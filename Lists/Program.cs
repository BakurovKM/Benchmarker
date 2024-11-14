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
    
    [Benchmark(Description = "List")]
    public void List()
    {
        var list = new List<int>();
        for (var i = 0; i < _cnt; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark(Description = "ListWithCapacity")]
    public void ListWithCapacity()
    {
        var list = new List<int>(_cnt);
        for (var i = 0; i < list.Capacity; i++)
        {
            list.Add(i);
        }
    }
    
    [Benchmark(Description = "ListWithCapacity2")]
    public void ListWithCapacity2()
    {
        var list = new List<int>(_cnt);
        for (var i = 0; i < list.Capacity; i++)
        {
            list.Add(i);
        }
        
        for (var i = 0; i < _cnt; i++)
        {
            list.Add(i);
        }
    }
}