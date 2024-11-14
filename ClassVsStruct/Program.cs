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

    private record TestClass(int id);
    private record struct TestStruct(int id);

    [Benchmark(Description = "ListClass")]
    public void ListClass()
    {
        var lst = new List<TestClass>();
        for (var i = 0; i < _cnt; i++)
        {
            lst.Add(new TestClass(i));
        }
    }
    
    [Benchmark(Description = "ListStruct")]
    public void ListStruct()
    {
        var lst = new List<TestStruct>();
        for (var i = 0; i < _cnt; i++)
        {
            lst.Add(new TestStruct(i));
        }
    }
    
    [Benchmark(Description = "ArrayStruct")]
    public void ArrayStruct()
    {
        var arr = new TestStruct[_cnt];
        for (var i = 0; i < _cnt; i++)
        {
            arr[i] = new TestStruct(i);
        }
    }
    
    [Benchmark(Description = "ArrayOnStackStruct")]
    public void ArrayOnStackStruct()
    {
        Span<TestStruct> arr = stackalloc TestStruct[_cnt];
        for (var i = 0; i < _cnt; i++)
        {
            arr[i] = new TestStruct(i);
        }
    }
}