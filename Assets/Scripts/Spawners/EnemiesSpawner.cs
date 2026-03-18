using static UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    
    [SerializeField] private int _maxPoolSize;
    [SerializeField] private int _maxActiveEnemiesAmount;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    [SerializeField] private float _minOffsetY;
    [SerializeField] private float _maxOffsetY;
    [SerializeField] private EnemyBulletSpawner _bulletSpawner;

    private Queue<Enemy> _enemies;
    private Coroutine _coroutine;

    private bool IsPossibleToSpawn => (_maxPoolSize - _enemies.Count) < _maxActiveEnemiesAmount;

    public event Action GameFinished;
    
    private void Awake()
    {
        CreatePool();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Spawning());
    }

    public void GiveBackAllToPool()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        GameFinished?.Invoke();
    }

    public void StartSpawning()
    {
        _coroutine = StartCoroutine(Spawning());
    }

    private void CreatePool()
    {
        _enemies = new Queue<Enemy>();

        for (int i = 0; i < _maxPoolSize; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            enemy.gameObject.SetActive(false);
            _enemies.Enqueue(enemy);
        }
    }

    private void GetFromPool()
    {
        Enemy enemy = _enemies.Dequeue();
        enemy.gameObject.SetActive(true);
        Vector3 position = new Vector3 (transform.position.x,
                                        transform.position.y + Range(_minOffsetY, _maxOffsetY),
                                        transform.position.z);
        enemy.Initialize(position);
        GameFinished += enemy.Reset;
        enemy.Restarted += GiveBackToPool;

        if (enemy.TryGetComponent(out EnemyTrigger enemyTrigger))
            enemyTrigger.Exited += GiveBackToPool;

        if (enemy.TryGetComponent(out EnemyShooter enemyShooter))
            enemyShooter.Shooted += _bulletSpawner.GetFromPool;
    }

    private void GiveBackToPool(Enemy enemy)
    {
        if (enemy.TryGetComponent(out EnemyTrigger enemyTrigger))
            enemyTrigger.Exited -= GiveBackToPool;

        if (enemy.TryGetComponent(out EnemyShooter enemyShooter))
            enemyShooter.Shooted -= _bulletSpawner.GetFromPool;

        GameFinished -= enemy.Reset;
        enemy.Restarted -= GiveBackToPool;

        enemy.gameObject.SetActive(false);
        _enemies.Enqueue(enemy);
    }

    private IEnumerator Spawning()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(Range(_minSpawnTime, _maxSpawnTime));

            if (IsPossibleToSpawn)
                GetFromPool();
        }
    }
}
