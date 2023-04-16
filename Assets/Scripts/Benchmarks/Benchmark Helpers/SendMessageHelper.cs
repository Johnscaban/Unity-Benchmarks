using UnityEngine;

/// <summary>
/// This is just an simple class for the benchmark <see cref="SendMessageBench"/> to call the function <see cref="CallThisFunction(int)"/>.
/// </summary>
public class SendMessageHelper : MonoBehaviour
{
    public void CallThisFunction(int a)
    {
        var value = 1 + a;
    }
}
