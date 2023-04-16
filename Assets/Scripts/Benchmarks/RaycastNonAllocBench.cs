using UnityEngine;

public class RaycastNonAllocBench : Benchmark
{
    private const float RAYCAST_ALL_DISTANCE = 100f;

    private readonly RaycastHit[] hits = new RaycastHit[100];

    public override void Initialize()
    {
        BenchmarkName = "Raycast NonAlloc";
        MaxRecommendedIterations = 250000;

        Benchmarks.Add(new BenchmarkData("RaycastAll", Benchmark_RaycastAll));
        Benchmarks.Add(new BenchmarkData("RaycastNonAlloc", Benchmark_RaycastNonAlloc));
    }

    private void Benchmark_RaycastAll()
    {
        var result = Physics.RaycastAll(transform.position, transform.forward, RAYCAST_ALL_DISTANCE);
    }

    private void Benchmark_RaycastNonAlloc()
    {
        var result = Physics.RaycastNonAlloc(transform.position, transform.forward, hits, RAYCAST_ALL_DISTANCE);
    }
}
