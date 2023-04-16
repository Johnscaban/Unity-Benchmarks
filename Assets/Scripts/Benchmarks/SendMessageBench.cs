public class SendMessageBench : Benchmark
{
    public override void Initialize()
    {
        BenchmarkName = "Send Message";
        
        Benchmarks.Add(new BenchmarkData("SendMessage", Benchmark_SendMessage));
        Benchmarks.Add(new BenchmarkData("GetComponent", Benchmark_GetComponent));
    }

    private void Benchmark_SendMessage()
    {
        SendMessage(nameof(SendMessageHelper.CallThisFunction), 10);
    }

    private void Benchmark_GetComponent()
    {
        var caller = GetComponent<SendMessageHelper>();
        caller.CallThisFunction(10);
    }
}