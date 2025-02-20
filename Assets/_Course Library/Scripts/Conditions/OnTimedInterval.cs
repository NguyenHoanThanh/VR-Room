using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Within a range in seconds, call an event, continues for lifetime of object.
/// </summary>
public class OnTimedInterval : MonoBehaviour
{
    [Tooltip("The minimum range")]
    public float minInterval = 0.0f;

    [Tooltip("The maximum range")]
    public float maxInterval = 1.0f;

    private Coroutine _coroutine;

    // Called once the wait is over
    public UnityEvent OnIntervalElapsed = new UnityEvent();

    public void StopInterval()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void Start()
    {
        _coroutine = StartCoroutine(IntervalRoutine());
    }

    private IEnumerator IntervalRoutine()
    {
        float interval = Random.Range(minInterval, maxInterval);
        yield return new WaitForSeconds(interval);

        PlayEvent();
        StartCoroutine(IntervalRoutine());
    }

    private void PlayEvent()
    {
        OnIntervalElapsed.Invoke();
    }
}