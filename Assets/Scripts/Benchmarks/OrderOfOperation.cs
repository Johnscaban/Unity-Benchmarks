using UnityEngine;

public class OrderOfOperation : Benchmark
{
    private readonly Vector3 vector3 = new(789, 123, 456);

    private const float MULTIPLIER = 2035.72f;

    public override void Initialize()
    {
        BenchmarkName = "Order of Operation";

        Benchmarks.Add(new BenchmarkData("FxFxV", Benchmark_FxFxV));
        Benchmarks.Add(new BenchmarkData("FxVxF", Benchmark_FxVxF));
        Benchmarks.Add(new BenchmarkData("VxFxF", Benchmark_VxFxF));
    }

    private void Benchmark_FxFxV()
    {
        var result = MULTIPLIER * MULTIPLIER * vector3;
    }

    private void Benchmark_FxVxF()
    {
        var result = MULTIPLIER * vector3 * MULTIPLIER;
    }

    private void Benchmark_VxFxF()
    {
        var result = vector3 * MULTIPLIER * MULTIPLIER;
    }

    // Integer math is faster than floating point, which is faster than vector
    // https://docs.unity3d.com/Manual/BestPracticeUnderstandingPerformanceInUnity7.html
}