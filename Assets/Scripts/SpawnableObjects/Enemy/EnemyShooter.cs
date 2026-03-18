using static UnityEngine.Random;
using System.Collections;
using UnityEngine;
using System;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _minShootingPauseTime;
    [SerializeField] private float _maxShootingPauseTime;
    [SerializeField] private Transform _bulletsSpawnPlace;

    private Coroutine _coroutine;

    public event Action<Vector3, Transform> Shooted;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Shooting());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Shooting()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(Range(_minShootingPauseTime, _maxShootingPauseTime));

            Shooted?.Invoke(_bulletsSpawnPlace.position, transform);
        }
    }
}
