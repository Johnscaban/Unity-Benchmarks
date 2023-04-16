using System.Text;

public class StringBench : Benchmark
{
    private const int COUNT = 100;
    private const string PHRASE = "This is a test phrase ";

    public override void Initialize()
    {
        BenchmarkName = "String Builder";
        MaxRecommendedIterations = 3000;

        Benchmarks.Add(new BenchmarkData("Concatenation", Benchmark_Concatenation));
        Benchmarks.Add(new BenchmarkData("StringBuilder", Benchmark_StringBuilder));
    }

    private void Benchmark_Concatenation()
    {
        var value = "";
        for (int i = 0; i < COUNT; i++)
            value += PHRASE;
    }

    private void Benchmark_StringBuilder()
    {
        var builder = new StringBuilder();
        for (int i = 0; i < COUNT; i++)
            builder.Append(PHRASE);

        var value = builder.ToString();
    }
}
