using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet<T> : MonoBehaviour where T: Target
{
    [SerializeField] private BulletTrigger<T> _bulletTrigger;
    [SerializeField] private BulletMover _bulletMover;

    public event Action<Bullet<T>> Destroyed;

    private void OnDisable()
    {
        _bulletTrigger.Exited -= _bulletMover.StopMoving;
        _bulletTrigger.Exited -= NotifyToDestroy;
    }

    public void Initialize(Vector3 position, Transform directionTransform)
    {
        transform.position = position;
        Subscribe();
        _bulletMover.StartMoving(directionTransform);
    }

    private void Subscribe()
    {
        _bulletTrigger.Exited += _bulletMover.StopMoving;
        _bulletTrigger.Exited += NotifyToDestroy;
    }

    public void NotifyToDestroy()
    {
        Destroyed?.Invoke(this);
    }
}
