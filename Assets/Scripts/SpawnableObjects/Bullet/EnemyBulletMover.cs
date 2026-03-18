using UnityEngine;

public class EnemyBulletMover : BulletMover
{
    public override void StartMoving(Transform directionTransform)
    {
        _coroutine = StartCoroutine(Moving(directionTransform.right));
    }
}
