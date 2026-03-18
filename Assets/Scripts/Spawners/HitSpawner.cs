using System;
using System.Collections.Generic;
using UnityEngine;

public class HitSpawner : MonoBehaviour
{
    [SerializeField] private Hit _hitPrefab;
    [SerializeField] private int _maxPoolSize;
    [SerializeField] private int _maxActiveHits;

    private Queue<Hit> _hits;

    protected bool IsPossibleToSpawn => (_maxPoolSize - _hits.Count) < _maxActiveHits;

    public event Action GameFinished;

    private void Awake()
    {
        CreatePool();
    }

    public void GetFromPool(Vector3 position)
    {
        if (IsPossibleToSpawn)
        {
            Hit hit = _hits.Dequeue();
            hit.gameObject.SetActive(true);
            hit.Exploded += GiveBackToPool;

            GameFinished += hit.Reset;
            hit.Restarted += GiveBackToPool;

            hit.Explode(position);
        }
    }

    public void GiveBackAllToPool()
    {
        GameFinished?.Invoke();
    }

    private void GiveBackToPool(Hit hit)
    {
        hit.Exploded -= GiveBackToPool;
        hit.gameObject.SetActive(false);
        _hits.Enqueue(hit);
    }

    private void CreatePool()
    {
        _hits = new Queue<Hit>();

        for (int i = 0; i < _maxPoolSize; i++)
        {
            Hit hit = Instantiate(_hitPrefab);
            hit.gameObject.SetActive(false);
            _hits.Enqueue(hit);
        }
    }
}
