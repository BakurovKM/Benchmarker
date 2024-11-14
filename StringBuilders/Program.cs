using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using StringBuilders;

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

    [Benchmark(Description = "ValueSB")]
    public void ValueSB()
    {
        for (var i = 0; i < _cnt; i++)
        {
            var sb = new ValueStringBuilder();
            for (var j = 0; j < 100; j++)
            {
                sb.Append(j.ToString());
            }
            
            var s = sb.ToString();
        }
    }

    [Benchmark(Description = "SB")]
    public void SB()
    {
        for (var i = 0; i < _cnt; i++)
        {
            var sb = new StringBuilder();
            for (var j = 0; j < 100; j++)
            {
                sb.Append(j.ToString());
            }

            var s = sb.ToString();
        }
    }
}