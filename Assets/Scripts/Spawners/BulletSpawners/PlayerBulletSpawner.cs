using UnityEngine;

public class PlayerBulletSpawner : BulletSpawner<EnemyTarget>
{
    [SerializeField] private ScoreCounter _scoreCounter;

    protected override void SubscribeBulletTrigger(Bullet<EnemyTarget> bullet)
    {
        if (bullet.TryGetComponent(out BulletTrigger<EnemyTarget> bulletTrigger))
        {
            bulletTrigger.Defeated += _scoreCounter.IncreaseScores;
            bulletTrigger.Hit += _hitSpawner.GetFromPool;
        }
    }

    protected override void UnsubscribeBulletTrigger(Bullet<EnemyTarget> bullet)
    {
        if (bullet.TryGetComponent(out BulletTrigger<EnemyTarget> bulletTrigger))
        {
            bulletTrigger.Defeated -= _scoreCounter.IncreaseScores;
            bulletTrigger.Hit -= _hitSpawner.GetFromPool;
        }
    }
}
