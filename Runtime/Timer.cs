using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float _startdelay = 0;
    public float _delay = 1;
    public bool _repeat;

    WaitForSeconds _waitStartDelay;
    WaitForSeconds _waitDelay;

    public UnityEvent OntimeReached;

    bool _timerRunning = false;

    private void Awake()
    {
        _waitStartDelay = new WaitForSeconds(_startdelay);
        _waitDelay = new WaitForSeconds(_delay);
    }

    public void RestartTimer()
    {
        StopTimer();
        StartTimer();
    }
    public void StartTimer()
    {
        if (!_timerRunning)
            StartCoroutine(Timing());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
        _timerRunning = false;
    }

    private void OnEnable()
    {
        StartCoroutine(Timing());
    }

    private void OnDisable()
    {
        _timerRunning = false;
    }

    public void SetDelay(float newDelay)
    {
        _delay = newDelay;
        _waitDelay = new WaitForSeconds(_delay);
    }

    public void SetStartDelay(float newStartDelay)
    {
        _startdelay = newStartDelay;
        _waitStartDelay = new WaitForSeconds(_startdelay);
    }

    IEnumerator Timing()
    {
        _timerRunning = true;
        yield return _waitStartDelay;

        while (_repeat)
        {
            yield return _waitDelay;
            OntimeReached.Invoke();
        }

        yield return _waitDelay;
        OntimeReached.Invoke();

        _timerRunning = false;
    }
}
