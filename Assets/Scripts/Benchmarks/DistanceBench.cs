using UnityEngine;

public class DistanceBench : Benchmark
{
    private readonly Vector3 a = new(1038, 2819.43f, 103);
    private readonly Vector3 b = new(632.34f, 12.1f, 9238.98f);

    public override void Initialize()
    {
        BenchmarkName = "Distance";
        
        Benchmarks.Add(new BenchmarkData("Vector3.Distance", Benchmark_Vector3_Distance));
        Benchmarks.Add(new BenchmarkData("Square Magnitude", Benchmark_Square_Magnitude));
    }

    private void Benchmark_Vector3_Distance()
    {
        var value = Vector3.Distance(a, b);
    }

    private void Benchmark_Square_Magnitude()
    {
        var value = (a - b).sqrMagnitude;
    }
}