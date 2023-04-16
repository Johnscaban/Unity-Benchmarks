using UnityEngine;

public class TransformCachingBench : Benchmark
{
    private Transform cachedTransform;

    public override void Initialize()
    {
        BenchmarkName = "Transform Caching";
        
        cachedTransform = transform;
        
        Benchmarks.Add(new BenchmarkData("Not caching", Benchmark_Not_Caching));
        Benchmarks.Add(new BenchmarkData("Cached per test", Benchmark_Cached_Per_Test));
        Benchmarks.Add(new BenchmarkData("Fully cached", Benchmark_Fully_Cached));
    }

    private void Benchmark_Not_Caching()
    {
        var pos = transform.position;
        var rot = transform.rotation;
        var scale = transform.localScale;
    }

    private void Benchmark_Cached_Per_Test()
    {
        var t = transform;
        var pos = t.position;
        var rot = t.rotation;
        var scale = t.localScale;
    }

    private void Benchmark_Fully_Cached()
    {
        var pos = cachedTransform.position;
        var rot = cachedTransform.rotation;
        var scale = cachedTransform.localScale;
    }
}