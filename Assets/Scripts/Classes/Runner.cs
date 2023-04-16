using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Runner : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;

    [SerializeField] private Slider iterationSlider;
    [SerializeField] private TMP_Text iterationText;
    [SerializeField] private Transform buttonParent;
    [SerializeField] private BenchmarkButton buttonPrefab;

    private Benchmark confirmBenchmark;

    private int Iterations => (int)iterationSlider.value;

    private void Start()
    {
        iterationSlider.onValueChanged.AddListener(f => iterationText.text = f.ToString("N0"));
        iterationSlider.value = 500000; // Default value for slider

        InitializeBenchmarks();
    }

    private void InitializeBenchmarks()
    {
        foreach (Benchmark benchmark in GetComponentsInChildren<Benchmark>())
        {
            BenchmarkButton benchButton = Instantiate(buttonPrefab, buttonParent);
            benchButton.Initialize(benchmark.BenchmarkName);

            benchButton.button.onClick.AddListener(() => {
                if (Iterations > benchmark.MaxRecommendedIterations && confirmBenchmark != benchmark)
                {
                    confirmBenchmark = benchmark;
                    iterationSlider.value = benchmark.MaxRecommendedIterations;
                    resultText.text = GetExceedMaxIterations(benchmark);
                }
                else
                {
                    confirmBenchmark = null;
                    RunBenchmarks(benchmark);
                }
            });
        }
    }

    private void RunBenchmarks(Benchmark benchmark)
    {
        StringBuilder builder = new StringBuilder();

        builder.Append($"<color=orange>{benchmark.BenchmarkName} x {Iterations}</color>\n");

        foreach (var result in benchmark.RunBenchmark(Iterations))
            builder.Append($"{result.Name}: {result.Result}\n");

        resultText.text = builder.ToString();
    }

    private string GetExceedMaxIterations(Benchmark benchmark) => $"<color=red>Max recommended iterations for this benchmark is {benchmark.MaxRecommendedIterations}. Click the button again to confirm any count (This may crash your computer)";
}