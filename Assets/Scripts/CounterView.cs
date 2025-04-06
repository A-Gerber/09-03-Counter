using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _counterText;
    [SerializeField] private Counter _counter;


    private void Start()
    {
        _counterText.text = _counter.StartValue.ToString("");
    }

    private void OnEnable()
    {
        _counter.Changed += OutputCurrentValue;
    }

    private void OnDisable()
    {
        _counter.Changed -= OutputCurrentValue;
    }

    private void OutputCurrentValue(float currentValue)
    {
        _counterText.text = currentValue.ToString("");
    }
}