using System.Buffers;
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
    [Params(100, 1000, 10000, 100000)]
    public int _cnt;

    [Benchmark(Description = "Array")]
    public void Array()
    {
        var array = new int[_cnt];
        array[0] = 1;
    }

    [Benchmark(Description = "MemoryPool")]
    public void MemoryPool()
    {
        using var rentedArray = MemoryPool<int>.Shared.Rent(_cnt);
        var array = rentedArray.Memory.Span;
        array[1] = 2;
    }

    [Benchmark(Description = "ArrayPool")]
    public void ArrayPool()
    {
        var array = ArrayPool<int>.Shared.Rent(_cnt);
        array[0] = 3;
        ArrayPool<int>.Shared.Return(array);
    }
}