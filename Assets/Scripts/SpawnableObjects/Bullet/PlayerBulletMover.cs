using UnityEngine;

public class PlayerBulletMover : BulletMover
{
    public override void StartMoving(Transform directionTransform)
    {
        transform.eulerAngles = new Vector3(0f, 0f, directionTransform.eulerAngles.z);
        _coroutine = StartCoroutine(Moving(directionTransform.right));
    }
}
