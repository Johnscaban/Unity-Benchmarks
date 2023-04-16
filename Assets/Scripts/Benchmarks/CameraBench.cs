using UnityEngine;

public class CameraBench : Benchmark
{
    private Camera cachedCam;

    public override void Initialize()
    {
        BenchmarkName = "Camera Access";
        
        cachedCam = Camera.main; // Cache the camera for the "Cached" test

        Benchmarks.Add(new BenchmarkData("Camera.main", Benchmark_Camera_main));
        Benchmarks.Add(new BenchmarkData("FindWithTag", Benchmark_FindWithTag));
        Benchmarks.Add(new BenchmarkData("FindObjectOfType", Benchmark_FindObjectOfType));
        Benchmarks.Add(new BenchmarkData("Cached Camera", Benchmark_Cached_Camera));
    }

    private void Benchmark_Camera_main()
    {
        var cam = Camera.main;
        var aspect = cam.aspect;
    }

    private void Benchmark_FindWithTag()
    {
        var cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        var aspect = cam.aspect;
    }

    private void Benchmark_FindObjectOfType()
    {
        var cam = FindObjectOfType<Camera>();
        var aspect = cam.aspect;
    }

    private void Benchmark_Cached_Camera()
    {
        var aspect = cachedCam.aspect;
    }
}
