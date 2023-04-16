using UnityEngine;

public class FindBench : Benchmark
{
    private const int TREE_COUNT = 50;
    private const int LAYER_COUNT = 50;
    private const int OBJECTS_PER_LAYER = 5;

    public override void Initialize()
    {
        var last = transform;
        for (int i = 0; i < TREE_COUNT; i++)
        {
            var treeObj = new GameObject($"Tree {i}");
            treeObj.transform.SetParent(last);

            for (int j = 0; j < LAYER_COUNT; j++)
            {
                var layerObj = new GameObject($"Layer {j}");
                layerObj.transform.SetParent(treeObj.transform);

                for (int k = 0; k < OBJECTS_PER_LAYER; k++)
                {
                    var obj = new GameObject($"Obj {k}")
                    {
                        tag = "Find"
                    };

                    obj.AddComponent<FindHelper>();
                    obj.transform.SetParent(layerObj.transform);
                }
            }
        }

        BenchmarkName = "Find Objects";
        MaxRecommendedIterations = 1000;

        Benchmarks.Add(new BenchmarkData("FindGameObjectsWithTag", Benchmark_FindGameObjectsWithTag));
        Benchmarks.Add(new BenchmarkData("FindObjectsOfType", Benchmark_FindObjectsOfType));
    }

    private void Benchmark_FindGameObjectsWithTag()
    {
        var values = GameObject.FindGameObjectsWithTag("Find");
    }

    private void Benchmark_FindObjectsOfType()
    {
        var values = FindObjectsOfType<FindHelper>();
    }
}