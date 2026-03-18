using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletSpawner<T>: MonoBehaviour where T : Target
{
    [SerializeField] protected int _maxPoolSize;
    [SerializeField] protected int _maxActiveBullets;
    [SerializeField] protected HitSpawner _hitSpawner;
    [SerializeField] private Bullet<T> _bulletPrefab;

    protected Queue<Bullet<T>> _bullets;

    public event Action GameFinished;

    protected bool IsPossibleToSpawn => (_maxPoolSize - _bullets.Count) < _maxActiveBullets;

    private void Awake()
    {
        CreatePool();
    }

    public void GetFromPool(Vector3 spawnPosition, Transform directionTransform)
    {
        if (IsPossibleToSpawn)
        {
            Bullet<T> bullet = _bullets.Dequeue();
            bullet.gameObject.SetActive(true);
            bullet.Initialize(spawnPosition, directionTransform);

            GameFinished += bullet.NotifyToDestroy;
            bullet.Destroyed += GiveBackToPool;

            SubscribeBulletTrigger(bullet);
        }
    }

    public void GiveBackAllToPool()
    {
        GameFinished?.Invoke();
    }

    protected abstract void SubscribeBulletTrigger(Bullet<T> bullet);
    protected abstract void UnsubscribeBulletTrigger(Bullet<T> bullet);

    private void GiveBackToPool(Bullet<T> bullet)
    {
        UnsubscribeBulletTrigger(bullet);

        GameFinished -= bullet.NotifyToDestroy;
        bullet.Destroyed -= GiveBackToPool;

        bullet.gameObject.SetActive(false);
        _bullets.Enqueue(bullet);
    }

    private void CreatePool()
    {
        _bullets = new Queue<Bullet<T>>();

        for (int i = 0; i < _maxPoolSize; i++)
        {
            Bullet<T> bullet = Instantiate(_bulletPrefab);
            bullet.gameObject.SetActive(false);
            _bullets.Enqueue(bullet);
        }
    }
}
