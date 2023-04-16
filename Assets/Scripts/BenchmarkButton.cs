using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BenchmarkButton : MonoBehaviour
{
    [SerializeField] private TMP_Text buttonText;
    public Button button;

    public void Initialize(string text)
    {
        buttonText.text = text;
    }
}