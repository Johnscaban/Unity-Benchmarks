using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public struct BenchmarkData
{
    public readonly string Name;
    public readonly Action Action;
    public long Result;

    public BenchmarkData(string name, Action action)
    {
        Name = name;
        Action = action;
        Result = 0;
    }
}

public abstract class Benchmark : MonoBehaviour
{
    public string BenchmarkName { get; protected set; }
    public int MaxRecommendedIterations { get; protected set; } = int.MaxValue;

    protected readonly List<BenchmarkData> Benchmarks = new List<BenchmarkData>();

    public void Awake() => Initialize();

    public abstract void Initialize();

    public IEnumerable<BenchmarkData> RunBenchmark(int iterations)
    {
        foreach (var benchmark in Benchmarks)
            yield return Run(benchmark);

        BenchmarkData Run(BenchmarkData data)
        {
            Stopwatch watch = Stopwatch.StartNew();
            
            for (var i = 0; i < iterations; i++)
                data.Action();

            watch.Stop();
            data.Result = watch.ElapsedMilliseconds;

            return data;
        }
    }
}