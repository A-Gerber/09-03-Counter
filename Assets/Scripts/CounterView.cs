using System.Collections;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _counterText;
    [SerializeField] private Counter _counter;
    [SerializeField] private float _delay = 0.5f;

    private WaitForSeconds _wait;

    private void Start()
    {
        _counterText.text = _counter.StartValue.ToString("");
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_counter.IsWork == false)
            {
                _counter.Enable();
                StartCoroutine(Name());
            }
            else
            {
                _counter.Disable();
                StopCoroutine(Name());
            }
        }
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

    private IEnumerator Name()
    {
        while (_counter.IsWork)
        {
            yield return _wait;
            _counter.MakeStep();
        }
    }
}