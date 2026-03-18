public class EnemyBulletSpawner : BulletSpawner<PlayerTarget>
{
    protected override void SubscribeBulletTrigger(Bullet<PlayerTarget> bullet)
    {
        if (bullet.TryGetComponent(out BulletTrigger<PlayerTarget> bulletTrigger))
            bulletTrigger.Hit += _hitSpawner.GetFromPool;
    }

    protected override void UnsubscribeBulletTrigger(Bullet<PlayerTarget> bullet)
    {
        if (bullet.TryGetComponent(out BulletTrigger<PlayerTarget> bulletTrigger))
            bulletTrigger.Hit -= _hitSpawner.GetFromPool;
    }
}
