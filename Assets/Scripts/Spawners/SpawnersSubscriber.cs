using UnityEngine;

public class SpawnersSubscriber : MonoBehaviour
{
    [SerializeField] private Restarter _restarter;
    [SerializeField] private PlayerBulletSpawner _playerBulletSpawner;
    [SerializeField] private HitSpawner _playerHitSpawner;
    [SerializeField] private EnemiesSpawner _enemiesSpawner;
    [SerializeField] private EnemyBulletSpawner _enemyBulletSpawner;
    [SerializeField] private HitSpawner _enemyHitSpawner;

    private void Start()
    {
        _restarter.GameFinished += _playerBulletSpawner.GiveBackAllToPool;
        _restarter.GameFinished += _playerHitSpawner.GiveBackAllToPool;
        _restarter.GameFinished += _enemiesSpawner.GiveBackAllToPool;
        _restarter.GameFinished += _enemyBulletSpawner.GiveBackAllToPool;
        _restarter.GameFinished += _enemyHitSpawner.GiveBackAllToPool;
        _restarter.GameFinished += _enemiesSpawner.GiveBackAllToPool;

        _restarter.Restarted += _enemiesSpawner.StartSpawning;
    }

    private void OnDisable()
    {
        _restarter.GameFinished -= _playerBulletSpawner.GiveBackAllToPool;
        _restarter.GameFinished -= _playerHitSpawner.GiveBackAllToPool;
        _restarter.GameFinished -= _enemiesSpawner.GiveBackAllToPool;
        _restarter.GameFinished -= _enemyBulletSpawner.GiveBackAllToPool;
        _restarter.GameFinished -= _enemyHitSpawner.GiveBackAllToPool;
        _restarter.GameFinished -= _enemiesSpawner.GiveBackAllToPool;

        _restarter.Restarted -= _enemiesSpawner.StartSpawning;
    }
}
