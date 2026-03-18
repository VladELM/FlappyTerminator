using System;
using System.Collections;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private float _explodingTime;

    private WaitForSeconds _explodingValue;
    private Coroutine _coroutine;

    public event Action<Hit> Exploded;
    public event Action<Hit> Restarted;

    public void Reset()
    {
        Restarted?.Invoke(this);
    }

    private void Awake()
    {
        _explodingValue = new WaitForSeconds(_explodingTime);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Explode(Vector3 position)
    {
        transform.position = position;
        _coroutine = StartCoroutine(Exploding());
    }

    private IEnumerator Exploding()
    {
        yield return _explodingValue;

        Exploded?.Invoke(this);
    }
}
