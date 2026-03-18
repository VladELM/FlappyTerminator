using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Moving());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void Initialize()
    {
        _coroutine = StartCoroutine(Moving());
    }

    private IEnumerator Moving()
    {
        while (true)
        {
            yield return null;

            transform.Translate(_speed * Time.deltaTime, 0f, 0f);
        }
    }
}
