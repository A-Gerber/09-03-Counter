using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const int StartButton = 0;

    [SerializeField] private float _startValue = 0.0f;
    [SerializeField] private float _step = 1.0f;
    [SerializeField] private float _delay = 0.5f;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;
    private float _currentValue;
    private bool _isWork = false;

    public event Action<float> Changed;

    public float StartValue => _startValue;

    private void Start()
    {
        _currentValue = _startValue;
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (Input.GetMouseButtonDown(StartButton))
        {
            ManageWork();
        }
    }

    private void ManageWork()
    {
        if (_isWork == false)
        {
            _isWork = true;
            _coroutine = StartCoroutine(Count());
        }
        else
        {
            _isWork = false;

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
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