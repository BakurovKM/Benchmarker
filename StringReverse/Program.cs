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
    private int _cnt;
    private string _data;
    
    [GlobalSetup]
    public void Setup()
    {
        _cnt = 1000000;
        _data = $"{Guid.NewGuid()}";
    }
    
    [Benchmark(Description = "ReverseByArray")]
    public void ReverseByArray()
    {
        for (var i = 0; i < _cnt; i++)
        {
            var charArray = _data.ToCharArray();
            Array.Reverse(charArray);
            var newStr = new string(charArray);
        }
    }

    /*xXx
    [Benchmark(Description = "ReverseByCreate")]
    public void ReverseByCreate()
    {
        for (var i = 0; i < _cnt; i++)
        {
            var newStr = string.Create(_data.Length, _data, (chars, state) =>
            {
                state.AsSpan().CopyTo(chars);
                chars.Reverse();
            });
        }
    }*/
}