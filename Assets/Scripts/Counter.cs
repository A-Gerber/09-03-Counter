using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _startValue = 0.0f;
    [SerializeField] private float _step = 1.0f;
    [SerializeField] private float _delay = 0.5f;

    public event Action<float> Changed;

    private WaitForSeconds _wait;
    private float _currentValue;
    private bool _isWork = false;

    public float StartValue => _startValue;

    private void Start()
    {
        _currentValue = _startValue;
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        InputReader();
    }

    private void InputReader()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ManageWork();
        }
    }

    private void ManageWork()
    {
        if (_isWork == false)
        {
            _isWork = true;
            StartCoroutine(Count());
        }
        else
        {
            _isWork = false;
            StopCoroutine(Count());
        }
    }

    private void MakeStep()
    {
        _currentValue += _step;

        Changed?.Invoke(_currentValue);
    }

    private IEnumerator Count()
    {
        while (_isWork)
        {
            yield return _wait;
            MakeStep();
        }
    }
}