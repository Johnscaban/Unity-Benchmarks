using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinqBench : Benchmark
{
    private struct LinqData
    {
        public int Value;
        public float ValueTwo;
    }

    private const int COUNT = 10000;
    private const int THRESHOLD = 5000;

    private readonly List<LinqData> dataForIteration = new List<LinqData>();

    public override void Initialize()
    {        
        for (int i = 0; i < COUNT; i++)
        {
            dataForIteration.Add(new LinqData()
            {
                Value = Random.Range(0, 1000000),
                ValueTwo = Random.Range(0f, 1000000f)
            });
        }

        BenchmarkName = "Linq vs Loop";
        MaxRecommendedIterations = 1000;

        Benchmarks.Add(new BenchmarkData("Linq", Benchmark_Linq));
        Benchmarks.Add(new BenchmarkData("For Loop", Benchmark_For_Loop));
        Benchmarks.Add(new BenchmarkData("Cached For Loop", Benchmark_Cached_For_Loop));
        Benchmarks.Add(new BenchmarkData("Foreach Loop", Benchmark_Foreach_Loop));
    }

    private void Benchmark_Linq()
    {
        var values = dataForIteration.Where(d => d.Value > THRESHOLD).Select(v => v.ValueTwo).ToList();
    }

    private void Benchmark_For_Loop()
    {
        var values = new List<float>();
        for (int i = 0; i < dataForIteration.Count; i++)
        {
            if (dataForIteration[i].Value > THRESHOLD)
                values.Add(dataForIteration[i].ValueTwo);
        }
    }

    private void Benchmark_Cached_For_Loop()
    {
        var values = new List<float>();
        var count = dataForIteration.Count;
        for (int i = 0; i < count; i++)
        {
            if (dataForIteration[i].Value > THRESHOLD)
                values.Add(dataForIteration[i].ValueTwo);
        }
    }

    private void Benchmark_Foreach_Loop()
    {
        var values = new List<float>();
        foreach (var data in dataForIteration)
        {
            if (data.Value > THRESHOLD)
                values.Add(data.ValueTwo);
        }
    }
}