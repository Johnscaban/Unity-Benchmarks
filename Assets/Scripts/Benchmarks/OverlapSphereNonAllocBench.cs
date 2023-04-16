using UnityEngine;

public class OverlapSphereNonAllocBench : Benchmark
{
    private const float OVERLAP_SPHERE_RADIUS = 10f;

    private readonly Collider[] collisions = new Collider[100];

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, OVERLAP_SPHERE_RADIUS);
    }

    public override void Initialize()
    {
        BenchmarkName = "OverlapSphere NonAlloc";
        MaxRecommendedIterations = 250000;

        Benchmarks.Add(new BenchmarkData("OverlapSphere", Benchmark_OverlapSphere));
        Benchmarks.Add(new BenchmarkData("OverlapSphereNonAlloc", Benchmark_OverlapSphereNonAlloc));
    }

    private void Benchmark_OverlapSphere()
    {
        var result = Physics.OverlapSphere(transform.position, OVERLAP_SPHERE_RADIUS);
    }

    private void Benchmark_OverlapSphereNonAlloc()
    {
        var result = Physics.OverlapSphereNonAlloc(transform.position, OVERLAP_SPHERE_RADIUS, collisions);
    }
}
