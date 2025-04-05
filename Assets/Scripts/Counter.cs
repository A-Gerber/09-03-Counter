using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _startValue = 0.0f;
    [SerializeField] private float _step = 1.0f;

    private float _currentValue;

    public float StartValue => _startValue;

    public bool IsWork { get; private set; } = false;

    public event Action<float> Changed;

    public void MakeStep()
    {
        _currentValue += _step;

        Changed?.Invoke(_currentValue);
    }

    public void Enable()
    {
        IsWork = true;
    }

    public void Disable()
    {
        IsWork = false;
    }

    private void Start()
    {
        _currentValue = _startValue;
    }
}